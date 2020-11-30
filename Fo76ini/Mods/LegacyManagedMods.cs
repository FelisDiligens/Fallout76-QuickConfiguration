using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Fo76ini.Mods
{
    public static class LegacyManagedMods
    {
        /// <summary>
        /// Checks whether there are mods have been managed by a version prior to v1.9.0.
        /// </summary>
        public static bool CheckLegacy(string gamePath)
        {
            return Directory.Exists(Path.Combine(gamePath, "Mods")) && 
                File.Exists(Path.Combine(gamePath, "Mods", "manifest.xml")) &&
                !File.Exists(Path.Combine(gamePath, "Mods", "managed.xml"));
        }

        /// <summary>
        /// Loads and converts legacy managed mods to the new format.
        /// It adds them to an already existing ManagedMods object.
        /// </summary>
        public static void ConvertLegacy(ManagedMods mods, Action<Progress> ProgressChanged = null)
        {
            Directory.CreateDirectory(Path.Combine(mods.GamePath, "FrozenData"));

            XDocument xmlDoc = XDocument.Load(Path.Combine(mods.ModsPath, "manifest.xml"));

            // I added a doNotImport="true" attribute, so I can check, whether the manifest.xml has only been generated for backwards-compatibility.
            // If it exists, we can just skip the import:
            if (xmlDoc.Root.Attribute("doNotImport") != null)
            {
                ProgressChanged?.Invoke(Progress.Aborted("Import skipped."));
                return;
            }

            int modCount = xmlDoc.Descendants("Mod").Count();
            int modIndex = 0;
            foreach (XElement xmlMod in xmlDoc.Descendants("Mod"))
            {
                modIndex++;

                if (xmlMod.Attribute("modFolder") == null)
                    continue;

                ManagedMod mod = new ManagedMod(mods.GamePath);

                string managedFolderName = xmlMod.Attribute("modFolder").Value;
                string managedFolderPath = Path.Combine(mods.ModsPath, managedFolderName);
                string frozenArchivePath = Path.Combine(mods.ModsPath, managedFolderName, "frozen.ba2");
                bool isFrozen = File.Exists(frozenArchivePath);

                if (xmlMod.Attribute("title") != null)
                    mod.Title = xmlMod.Attribute("title").Value;

                string progressTitle = $"Converting \"{mod.Title}\" ({modIndex} of {modCount})";
                float progressPercentage = (float)modIndex / (float)modCount;

                // In case the mod was "frozen" before,
                // we'll need to move the *.ba2 archive into the FrozenData folder and then extract it.
                if (isFrozen)
                {
                    ProgressChanged?.Invoke(Progress.Ongoing($"{progressTitle}: Extracting *.ba2 archive...", progressPercentage));
                    File.Move(frozenArchivePath, mod.FrozenArchivePath);
                    Archive2.Extract(mod.FrozenArchivePath, managedFolderPath);
                    mod.Frozen = true;
                    mod.Freeze = true;
                }

                // We need to rename the old folder to fit with the new format.
                if (Directory.Exists(managedFolderPath))
                {
                    ProgressChanged?.Invoke(Progress.Ongoing($"{progressTitle}: Moving managed folder...", progressPercentage));
                    if (Directory.Exists(mod.ManagedFolderPath))
                        Directory.Delete(mod.ManagedFolderPath, true);
                    Directory.Move(managedFolderPath, mod.ManagedFolderPath);
                }

                ProgressChanged?.Invoke(Progress.Ongoing($"{progressTitle}: Parsing XML...", progressPercentage));

                if (xmlMod.Attribute("url") != null)
                    mod.URL = xmlMod.Attribute("url").Value;

                if (xmlMod.Attribute("version") != null)
                    mod.Version = xmlMod.Attribute("version").Value;

                if (xmlMod.Attribute("enabled") != null)
                {
                    try
                    {
                        mod.Deployed = XmlConvert.ToBoolean(xmlMod.Attribute("enabled").Value);
                    }
                    catch
                    {
                        mod.Deployed = false;
                    }
                    mod.Enabled = mod.Deployed;
                }
                
                if (xmlMod.Attribute("installType") != null)
                {
                    switch (xmlMod.Attribute("installType").Value)
                    {
                        case "Loose":
                            mod.PreviousMethod = ManagedMod.DeploymentMethod.LooseFiles;
                            break;
                        case "SeparateBA2":
                            mod.PreviousMethod = ManagedMod.DeploymentMethod.SeparateBA2;
                            break;
                        case "BA2Archive": // Backward compatibility
                        case "BundledBA2":
                        case "BundledBA2Textures": // Backward compatibility
                        default:
                            mod.PreviousMethod = ManagedMod.DeploymentMethod.BundledBA2;
                            break;
                    }
                    mod.Method = mod.PreviousMethod;
                }

                if (xmlMod.Attribute("format") != null)
                {
                    switch (xmlMod.Attribute("format").Value)
                    {
                        case "General":
                            mod.CurrentFormat = ManagedMod.ArchiveFormat.General;
                            break;
                        case "DDS": // Backward compatibility
                        case "Textures":
                            mod.CurrentFormat = ManagedMod.ArchiveFormat.Textures;
                            break;
                        case "Auto":
                        default:
                            mod.CurrentFormat = ManagedMod.ArchiveFormat.Auto;
                            break;
                    }
                    mod.Format = mod.CurrentFormat;
                }

                if (xmlMod.Attribute("compression") != null)
                {
                    switch (xmlMod.Attribute("compression").Value)
                    {
                        case "Default": // Backward compatibility
                        case "Compressed":
                            mod.CurrentCompression = ManagedMod.ArchiveCompression.Compressed;
                            break;
                        case "None": // Backward compatibility
                        case "Uncompressed":
                            mod.CurrentCompression = ManagedMod.ArchiveCompression.Uncompressed;
                            break;
                        case "Auto":
                        default:
                            mod.CurrentCompression = ManagedMod.ArchiveCompression.Auto;
                            break;
                    }
                    mod.Compression = mod.CurrentCompression;
                }

                if (xmlMod.Attribute("archiveName") != null)
                {
                    mod.CurrentArchiveName = xmlMod.Attribute("archiveName").Value;
                    mod.ArchiveName = mod.CurrentArchiveName;
                }

                if (xmlMod.Attribute("root") != null)
                {
                    mod.CurrentRootFolder = xmlMod.Attribute("root").Value;
                    mod.RootFolder = mod.CurrentRootFolder;
                    foreach (XElement xmlFile in xmlMod.Descendants("File"))
                        if (xmlFile.Attribute("path") != null)
                            mod.LooseFiles.Add(xmlFile.Attribute("path").Value);
                }

                /*if (xmlMod.Attribute("frozen") != null)
                {
                    frozen = XmlConvert.ToBoolean(xmlMod.Attribute("frozen").Value);
                }*/

                mods.Add(mod);
            }

            ProgressChanged?.Invoke(Progress.Ongoing("Saving XML...", 1f));
            mods.Save();

            ProgressChanged?.Invoke(Progress.Done("Legacy mods imported."));
        }

        /// <summary>
        /// Generates and saves a legacy "manifest.xml" for backwards-compatibility.
        /// </summary>
        /// <param name="mods">Generate a legacy xml for these mods.</param>
        public static void GenerateLegacyXML(ManagedMods mods)
        {
            // I ported the old Serialize methods of the old Mod and old ManagedMods classes.
            // It now uses the new format, but generates an *.xml that is compatible with older versions.
            // Since there is now way more information saved: It uses the current disk state, not the pending one. (PreviousMethod, CurrentArchiveName, etc.)
            // In case the user wants to downgrade, they can.

            XDocument xmlDoc = new XDocument();
            XElement xmlRoot = new XElement("Mods");
            xmlRoot.Add(new XAttribute("doNotImport", true));
            xmlDoc.Add(xmlRoot);

            xmlDoc.AddFirst(new XComment($"\n  This file has been generated by v{Shared.VERSION} for backwards-compatibility.\n  It not actually being used anymore.\n"));

            foreach (ManagedMod mod in mods)
            {
                XElement xmlMod = new XElement("Mod",
                   new XAttribute("title", mod.Title),
                   new XAttribute("enabled", mod.Deployed),
                   new XAttribute("modFolder", mod.ManagedFolderName),
                   new XAttribute("installType", GetLegacyInstallMethodName(mod)));

                if (mod.URL != "")
                    xmlMod.Add(new XAttribute("url", mod.URL));

                if (mod.Version != "")
                    xmlMod.Add(new XAttribute("version", mod.Version));
                
                if (mod.PreviousMethod == ManagedMod.DeploymentMethod.SeparateBA2)
                {
                    xmlMod.Add(new XAttribute("archiveName", mod.CurrentArchiveName));
                    xmlMod.Add(new XAttribute("compression", GetLegacyArchiveCompressionName(mod)));
                    xmlMod.Add(new XAttribute("format", GetLegacyArchiveFormatName(mod)));

                    // We can't set the frozen flag anymore, because we store frozen archives differently now:
                    //if (mod.Frozen)
                        //xmlMod.Add(new XAttribute("frozen", mod.Frozen));
                }

                if (mod.PreviousMethod == ManagedMod.DeploymentMethod.LooseFiles && mod.CurrentRootFolder != "")
                    xmlMod.Add(new XAttribute("root", mod.CurrentRootFolder));

                if (mod.PreviousMethod == ManagedMod.DeploymentMethod.LooseFiles && mod.Deployed)
                    foreach (String filePath in mod.LooseFiles)
                        xmlMod.Add(new XElement("File", new XAttribute("path", filePath)));

                xmlRoot.Add(xmlMod);
            }

            xmlDoc.Save(Path.Combine(mods.ModsPath, "manifest.xml"));
        }

        /// <summary>
        /// Returns the legacy string of the install method:
        /// 
        /// public enum FileType
        /// {
        ///     Loose,
        ///     BundledBA2,
        ///     SeparateBA2
        /// }
        /// </summary>
        /// <returns>"Loose", "SeparateBA2", or "BundledBA2"</returns>
        private static string GetLegacyInstallMethodName(ManagedMod mod)
        {
            switch (mod.PreviousMethod)
            {
                case ManagedMod.DeploymentMethod.LooseFiles:
                    return "Loose";
                case ManagedMod.DeploymentMethod.SeparateBA2:
                    return "SeparateBA2";
                case ManagedMod.DeploymentMethod.BundledBA2:
                default:
                    return "BundledBA2";
            }
        }

        /// <summary>
        /// Returns the legacy string of ArchiveCompression.
        /// 
        /// public enum ArchiveCompression
        /// {
        ///     Auto,
        ///     Compressed,
        ///     Uncompressed
        /// }
        /// </summary>
        /// <returns>"Auto", "Compressed", or "Uncompressed"</returns>
        private static string GetLegacyArchiveCompressionName(ManagedMod mod)
        {
            switch (mod.CurrentCompression)
            {
                case ManagedMod.ArchiveCompression.Compressed:
                    return "Compressed";
                case ManagedMod.ArchiveCompression.Uncompressed:
                    return "Uncompressed";
                case ManagedMod.ArchiveCompression.Auto:
                default:
                    return "Auto";
            }
        }

        /// <summary>
        /// Returns the legacy string of ArchiveFormat.
        /// 
        /// public enum ArchiveFormat
        /// {
        ///     Auto,
        ///     General,
        ///     Textures
        /// }
        /// </summary>
        /// <returns>"Auto", "General", or "Textures"</returns>
        private static string GetLegacyArchiveFormatName(ManagedMod mod)
        {
            switch (mod.CurrentFormat)
            {
                case ManagedMod.ArchiveFormat.General:
                    return "General";
                case ManagedMod.ArchiveFormat.Textures:
                    return "Textures";
                case ManagedMod.ArchiveFormat.Auto:
                default:
                    return "Auto";
            }
        }
    }
}
