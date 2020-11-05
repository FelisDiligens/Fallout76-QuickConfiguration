﻿using Fo76ini.Mods;
using Newtonsoft.Json.Linq;
using SharpCompress.Common;
using SharpCompress.Readers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Fo76ini
{
    public class Mod
    {
        public enum FileType
        {
            Loose,
            BundledBA2,
            SeparateBA2
        }

        public enum ArchiveFormat
        {
            Auto,
            General,
            Textures
        }

        public enum ArchiveCompression
        {
            Auto,
            Compressed,
            Uncompressed
        }

        private String title;
        private String managedFolderName;
        public Mod.FileType Type;
        private String root;
        private bool enabled;

        public int ID = -1;
        private String url = "";
        public String Version = "";
        /*public String LatestVersion = "";
        public String ThumbnailURL = "";
        public String Thumbnail = "";
        public String PublicName = "";*/

        public String URL
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                this.ID = NexusMods.GetIDFromURL(value);
            }
        }

        /*
         * Directly access NexusMods' info
         */
        public String PublicName
        {
            get
            {
                if (this.ID >= 0 && NexusMods.Mods.ContainsKey(this.ID))
                    return NexusMods.Mods[this.ID].Title;
                else
                    return this.Title;
            }
        }

        public String Thumbnail
        {
            get
            {
                if (this.ID >= 0 && NexusMods.Mods.ContainsKey(this.ID))
                    return NexusMods.Mods[this.ID].Thumbnail;
                else
                    return "";
            }
        }

        public String LatestVersion
        {
            get
            {
                if (this.ID >= 0 && NexusMods.Mods.ContainsKey(this.ID))
                    return NexusMods.Mods[this.ID].LatestVersion;
                else
                    return "";
            }
        }

        public NMMod RemoteInfo
        {
            get
            {
                if (this.ID >= 0 && NexusMods.Mods.ContainsKey(this.ID))
                    return NexusMods.Mods[this.ID];
                else
                    return null;
            }
        }

        /* Does only apply for FileType.Loose */
        private List<String> looseFiles = new List<String>();

        /* Does only apply for FileType.SeparateBA2 */
        public Mod.ArchiveCompression Compression = Mod.ArchiveCompression.Auto;
        private String archiveName = "untitled.ba2";
        public Mod.ArchiveFormat Format = Mod.ArchiveFormat.Auto;
        public bool freeze = false;
        private bool frozen = false;

        public Mod()
        {
            this.title = "Untitled";
            this.managedFolderName = "Untitled";
            this.enabled = false;
            this.Type = Mod.FileType.BundledBA2;
            this.root = "Data";
        }

        // Deep copy:
        public Mod(Mod mod)
        {
            this.title = mod.title;
            this.managedFolderName = mod.managedFolderName;
            this.enabled = mod.enabled;
            this.Type = mod.Type;
            this.root = mod.root;
            this.looseFiles = new List<String>(mod.looseFiles);
            this.Compression = mod.Compression;
            this.Format = mod.Format;
            this.archiveName = mod.archiveName;
            this.freeze = mod.freeze;
            this.frozen = mod.frozen;

            this.ID = mod.ID;
            this.URL = mod.URL;
            this.Version = mod.Version;
            /*this.LatestVersion = mod.LatestVersion;
            this.ThumbnailURL = mod.ThumbnailURL;
            this.Thumbnail = mod.Thumbnail;
            this.PublicName = mod.PublicName;*/
        }

        public Mod CreateDeepCopy()
        {
            return new Mod(this);
        }

        public Mod(String title, String managedFolderName, Mod.FileType type, bool enabled)
        {
            this.Title = title;
            this.ManagedFolder = managedFolderName;
            this.isEnabled = enabled;
            this.Type = type;
        }

        public String Title
        {
            get { return this.title; }
            set { this.title = value.Trim().Length > 0 ? value.Trim() : "Untitled"; }
        }

        public String ArchiveName
        {
            get { return this.archiveName; }
            set
            {
                if (value.Trim().Length < 0)
                    return;
                this.archiveName = Utils.GetValidFileName(value, ".ba2");
            }
        }

        public String GetTypeName()
        {
            return Enum.GetName(typeof(Mod.FileType), (int)this.Type);
        }

        public String GetFormatName()
        {
            return Enum.GetName(typeof(Mod.ArchiveFormat), (int)this.Format);
        }

        public String GetManagedPath()
        {
            return Path.Combine(Shared.GamePath, "Mods", this.ManagedFolder);
        }

        public String RootFolder
        {
            get { return this.root; }
            set { this.root = value; }
        }

        public String ManagedFolder
        {
            get { return this.managedFolderName; }
            set { this.managedFolderName = value; }
        }

        public bool isEnabled
        {
            get { return this.enabled; }
            set { this.enabled = value; }
        }

        public bool isFrozen()
        {
            return this.frozen && File.Exists(GetFrozenArchivePath());
        }

        public void OverwriteFrozen(bool isFrozen)
        {
            ManagedMods.Instance.logFile.WriteLine($"Manually overwritten: (Mod){this.Title}.frozen = {isFrozen}");
            this.frozen = isFrozen;
        }

        public void Freeze (Action<String, int> updateProgress = null, Action<bool> done = null)
        {
            try
            {
                // Check if mod is not frozen:
                if (this.isFrozen())
                    return;

                if (updateProgress != null)
                    updateProgress($"Freezing {this.Title}", -1);

                // Create archive:
                String tempPath = Path.Combine(Shared.GamePath, "Mods", "frozen.ba2");
                Archive2.Create(tempPath, GetManagedPath(), ManagedMods.Instance.GetArchive2Preset(this));

                // Failed?
                if (!File.Exists(tempPath))
                {
                    ManagedMods.Instance.logFile.WriteLine("Error while freezing mod: Couldn't create *.ba2 file. Please check archive2.log.txt.\n");
                    if (done != null)
                        done(false);
                    return;
                }

                this.frozen = true;
                this.freeze = true;

                // Remove contents of managed folder:
                if (Directory.Exists(GetManagedPath()))
                    Directory.Delete(GetManagedPath(), true);
                Directory.CreateDirectory(GetManagedPath());

                // Move frozen.ba2 into folder:
                File.Move(tempPath, GetFrozenArchivePath());

                if (done != null)
                    done(true);

            }
            catch (Archive2Exception ex)
            {
                ManagedMods.Instance.logFile.WriteLine($"Archive2Exception occured while freezing mod '{this.Title}': {ex.Message}\n{ex.StackTrace}\n");
                MsgBox.Get("archive2Error").Show(MessageBoxIcon.Error);
                if (done != null)
                    done(false);
                return;
            }
            catch (Exception ex)
            {
                ManagedMods.Instance.logFile.WriteLine($"Unhandled exception occured while freezing mod '{this.Title}': {ex.Message}\n{ex.StackTrace}\n");
                if (done != null)
                    done(false);
            }
        }

        public void Unfreeze(Action<String, int> updateProgress = null, Action<bool> done = null)
        {
            try
            {
                // Check if mod is frozen:
                if (!this.isFrozen())
                {
                    ManagedMods.Instance.logFile.WriteLine($"Cannot unfreeze a mod ('{this.Title}') which isn't frozen.\n");
                    if (done != null)
                        done(false);
                    return;
                }

                if (updateProgress != null)
                    updateProgress($"Unfreezing {this.Title}", -1);

                this.frozen = false;
                this.freeze = false;

                // Move frozen.ba2 out of folder:
                String tempPath = Path.Combine(Shared.GamePath, "Mods", "frozen.ba2");
                File.Move(GetFrozenArchivePath(), tempPath);

                // Remove contents of managed folder:
                if (Directory.Exists(GetManagedPath()))
                    Directory.Delete(GetManagedPath(), true);
                Directory.CreateDirectory(GetManagedPath());

                // Extract frozen archive:
                Archive2.Extract(tempPath, GetManagedPath());

                // Remove frozen archive:
                File.Delete(tempPath);

                if (done != null)
                    done(true);
            }
            catch (Archive2Exception ex)
            {
                ManagedMods.Instance.logFile.WriteLine($"Archive2Exception occured while unfreezing mod '{this.Title}': {ex.Message}\n{ex.StackTrace}\n");
                MsgBox.Get("archive2Error").Show(MessageBoxIcon.Error);
                if (done != null)
                    done(false);
                return;
            }
            catch (Exception ex)
            {
                ManagedMods.Instance.logFile.WriteLine($"Unhandled exception occured while unfreezing mod '{this.Title}': {ex.Message}\n{ex.StackTrace}\n");
                if (done != null)
                    done(false);
                return;
            }
        }

        public String GetFrozenArchivePath()
        {
            return Path.Combine(GetManagedPath(), "frozen.ba2");
        }

        public void AddFile(String path)
        {
            if (this.Type == Mod.FileType.Loose)
                this.looseFiles.Add(path);
            else
                throw new InvalidOperationException($"Can't add loose files to a \"{this.GetTypeName()}\" type mod.");
        }

        public void ClearFiles()
        {
            this.looseFiles.Clear();
        }

        public List<String> LooseFiles
        {
            get { return this.looseFiles; }
            set
            {
                if (this.Type == Mod.FileType.Loose)
                    this.looseFiles = value;
                else
                    throw new InvalidOperationException($"Can't set loose files because mod is of \"{this.GetTypeName()}\" type.");
            }
        }

        override public String ToString()
        {
            return $"Mod \"{Title}\":\n  Enabled: {isEnabled}\n  Installation type: {this.GetTypeName()}\n  Root folder: {RootFolder}\n  File count: {this.looseFiles.Count}";
        }

        public XElement Serialize()
        {
            // <Mod title="Some awesome mod" root="Data" modFolder="awesome" installType="BA2Archive" enabled="true" />
            XElement xmlMod = new XElement("Mod",
                new XAttribute("title", this.title),
                new XAttribute("enabled", this.enabled),
                new XAttribute("modFolder", this.managedFolderName),
                new XAttribute("installType", this.GetTypeName()));

            if (this.URL != "")
                xmlMod.Add(new XAttribute("url", this.URL));

            if (this.Version != "")
                xmlMod.Add(new XAttribute("version", this.Version));

            /*if (this.LatestVersion != "")
                xmlMod.Add(new XAttribute("latestVersion", this.LatestVersion));

            if (this.ThumbnailURL != "")
                xmlMod.Add(new XAttribute("thumbnailUrl", this.ThumbnailURL));

            if (this.Thumbnail != "")
                xmlMod.Add(new XAttribute("thumbnail", this.Thumbnail));

            if (this.PublicName != "")
                xmlMod.Add(new XAttribute("publicName", this.PublicName));*/

            if (this.Type == Mod.FileType.Loose && this.enabled)
                foreach (String filePath in this.looseFiles)
                    xmlMod.Add(new XElement("File", new XAttribute("path", filePath)));

            if (this.Type == Mod.FileType.SeparateBA2)
            {
                String compressionStr = Enum.GetName(typeof(Mod.ArchiveCompression), (int)Compression);
                xmlMod.Add(new XAttribute("archiveName", archiveName));
                xmlMod.Add(new XAttribute("compression", compressionStr));
                xmlMod.Add(new XAttribute("format", this.GetFormatName()));
                if (frozen)
                    xmlMod.Add(new XAttribute("frozen", frozen));
            }

            if (this.Type == Mod.FileType.Loose)
            {
                xmlMod.Add(new XAttribute("root", this.root));
            }

            return xmlMod;
        }

        public static Mod Deserialize(XElement xmlMod)
        {
            if (xmlMod.Attribute("title") == null ||
                xmlMod.Attribute("modFolder") == null ||
                xmlMod.Attribute("enabled") == null ||
                xmlMod.Attribute("installType") == null)
                throw new InvalidDataException("Some attributes are missing.");
            Mod mod = new Mod();
            mod.Title = xmlMod.Attribute("title").Value;
            mod.ManagedFolder = xmlMod.Attribute("modFolder").Value;

            if (xmlMod.Attribute("url") != null)
                mod.URL = xmlMod.Attribute("url").Value;

            if (xmlMod.Attribute("version") != null)
                mod.Version = xmlMod.Attribute("version").Value;

            /*if (xmlMod.Attribute("latestVersion") != null)
                mod.LatestVersion = xmlMod.Attribute("latestVersion").Value;

            if (xmlMod.Attribute("thumbnailUrl") != null)
                mod.ThumbnailURL = xmlMod.Attribute("thumbnailUrl").Value;

            if (xmlMod.Attribute("thumbnail") != null)
                mod.Thumbnail = xmlMod.Attribute("thumbnail").Value;

            if (xmlMod.Attribute("publicName") != null)
                mod.PublicName = xmlMod.Attribute("publicName").Value;*/

            try
            {
                mod.isEnabled = Convert.ToBoolean(xmlMod.Attribute("enabled").Value);
            }
            catch (FormatException ex)
            {
                throw new InvalidDataException($"Invalid 'enabled' value: {xmlMod.Attribute("enabled").Value}");
            }
            switch (xmlMod.Attribute("installType").Value)
            {
                case "Loose":
                    mod.Type = Mod.FileType.Loose;
                    break;
                case "BA2Archive": // Backward compatibility
                case "BundledBA2":
                case "BundledBA2Textures": // Backward compatibility
                    mod.Type = Mod.FileType.BundledBA2;
                    break;
                case "SeparateBA2":
                    mod.Type = Mod.FileType.SeparateBA2;
                    break;
                default:
                    throw new InvalidDataException($"Invalid mod installation type: {xmlMod.Attribute("installType").Value}");
            }
            if (xmlMod.Attribute("format") != null)
            {
                switch (xmlMod.Attribute("format").Value)
                {
                    case "General":
                        mod.Format = Mod.ArchiveFormat.General;
                        break;
                    case "DDS": // Backward compatibility
                    case "Textures":
                        mod.Format = Mod.ArchiveFormat.Textures;
                        break;
                    case "Auto":
                    default:
                        mod.Format = Mod.ArchiveFormat.Auto;
                        break;
                }
            }
            if (mod.Type == Mod.FileType.SeparateBA2 &&
                xmlMod.Attribute("compression") != null &&
                xmlMod.Attribute("archiveName") != null)
            {
                switch (xmlMod.Attribute("compression").Value)
                {
                    case "Default": // Backward compatibility
                    case "Compressed":
                        mod.Compression = Mod.ArchiveCompression.Compressed;
                        break;
                    case "None": // Backward compatibility
                    case "Uncompressed":
                        mod.Compression = Mod.ArchiveCompression.Uncompressed;
                        break;
                    case "Auto":
                    default:
                        mod.Compression = Mod.ArchiveCompression.Auto;
                        break;
                }
                //mod.Compression = Archive2.GetCompression(xmlMod.Attribute("compression").Value);
                mod.ArchiveName = xmlMod.Attribute("archiveName").Value;
                if (xmlMod.Attribute("frozen") != null)
                {
                    mod.frozen = Convert.ToBoolean(xmlMod.Attribute("frozen").Value);
                    mod.freeze = mod.frozen;
                }
            }
            if (mod.Type == Mod.FileType.Loose &&
                xmlMod.Attribute("root") != null)
            {
                mod.RootFolder = xmlMod.Attribute("root").Value;
                if (mod.isEnabled)
                    foreach (XElement xmlFile in xmlMod.Descendants("File"))
                        if (xmlFile.Attribute("path") != null)
                            mod.AddFile(xmlFile.Attribute("path").Value);
                        else
                            throw new InvalidDataException("path attribute is missing from <File> tag");
            }
            return mod;
        }
    }

    public class ManagedMods
    {
        private static ManagedMods instance = null;
        private static readonly object padlock = new object();

        public static ManagedMods Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ManagedMods();
                    }
                    return instance;
                }
            }
        }

        private ManagedMods()
        {
            Shared.LoadGameEdition();
            Shared.LoadGamePath();

            bool nwMode = IniFiles.Instance.GetBool(IniFile.Config, "Mods", "bDisableMods", false);
            this.ModsDisabled = nwMode;
            this.WriteDataDirs = IniFiles.Instance.GetBool(IniFile.Config, "Mods", "bWriteSResourceDataDirsFinal", false);
            this.logFile = new Log(Log.GetFilePath("modmanager.log.txt"));
        }

        private List<Mod> mods = new List<Mod>();
        private List<Mod> changedMods = new List<Mod>();
        public bool ModsDisabled = false;
        public bool WriteToF76Custom = true;
        public bool WriteDataDirs = false;
        public Log logFile;

        // Use lower-case, plz
        private List<String> whitelistedDlls = new List<String>() {
            "bink2w64.dll",
            "chrome_elf.dll",
            "concrt140.dll",
            "d3dcompiler_43.dll",
            "libcef.dll",
            "libegl.dll", // "libEGL.dll",
            "libglesv2.dll", // "libGLESv2.dll",
            "msvcp140.dll",
            "ortp_x64.dll",
            "steam_api64.dll",
            "vccorlib140.dll",
            "vcruntime140.dll",
            "vivoxsdk_x64.dll",
            "d3dcompiler_46.dll",
            "d3dcompiler_47.dll"
            // "x3daudio1_7.dll" ?
        };

        public static String GetEditionSuffix(int gameEdition)
        {
            return ManagedMods.GetEditionSuffix((GameEdition)gameEdition);
        }

        public static String GetGamePathKey(int gameEdition)
        {
            return ManagedMods.GetGamePathKey((GameEdition)gameEdition);
        }

        public static String GetEditionSuffix(GameEdition gameEdition)
        {
            switch (gameEdition)
            {
                case GameEdition.Steam:
                    return "Steam";
                case GameEdition.BethesdaNet:
                    return "BethesdaNet";
                case GameEdition.BethesdaNetPTS:
                    return "BethesdaNetPTS";
                case GameEdition.MSStore:
                    return "MSStore";
                default:
                    return "";
            }
        }

        public static String GetGamePathKey (GameEdition gameEdition)
        {
            return "sGamePath" + GetEditionSuffix(gameEdition);
        }

        private List<Mod> CreateDeepCopy(List<Mod> original)
        {
            List<Mod> copy = new List<Mod>();
            foreach (Mod mod in original)
                copy.Add(mod.CreateDeepCopy());
            return copy;
        }

        public List<Mod> Mods
        {
            get { return this.changedMods; }
        }

        private void DeleteAt(int index)
        {
            String managedFolderPath = Path.Combine(Shared.GamePath, "Mods", this.changedMods[index].ManagedFolder);
            if (Directory.Exists(managedFolderPath))
                Directory.Delete(managedFolderPath, true);
            this.changedMods.RemoveAt(index);
            //this.mods.RemoveAt(index);
        }

        /// <summary>
        /// Delete all files of the mod and remove it from the list.
        /// Saves the manifest afterwards.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="done"></param>
        public void DeleteMod(int index, Action done = null)
        {
            DeleteAt(index);
            this.Save();
            if (done != null)
                done();
        }

        public void DeleteMods(List<int> indices, Action done = null)
        {
            indices = indices.OrderByDescending(i => i).ToList();
            foreach (int index in indices)
                DeleteAt(index);
            this.Save();
            if (done != null)
                done();
        }

        public void UnfreezeMods(List<int> indices, Action<String, int> updateProgress = null, Action done = null)
        {
            foreach (int index in indices)
            {
                Mod mod = this.Mods[index];
                if (updateProgress != null)
                    updateProgress($"Unfreezing {mod.Title}...", (index + 1) / indices.Count() * 100);
                mod.Unfreeze();
            }
            if (done != null)
                done();
        }

        public bool ValidateGamePath(String path)
        {
            return path != null && path.Trim().Length > 0 && Directory.Exists(path) && Directory.Exists(Path.Combine(path, "Data"));
        }

        public bool ValidateGamePath()
        {
            return this.ValidateGamePath(Shared.GamePath);
        }

        public String RenameManagedFolder(String currentManagedFolderName, String newManagedFolderName)
        {
            newManagedFolderName = Utils.GetValidFileName(newManagedFolderName);
            if (currentManagedFolderName == newManagedFolderName)
                return currentManagedFolderName;
            if (!Directory.Exists(Path.Combine(Shared.GamePath, "Mods", currentManagedFolderName)))
                return currentManagedFolderName;

            Mod deployedMod = null;
            Mod changedMod = null;
            foreach (Mod mod in this.mods)
                if (mod.ManagedFolder == currentManagedFolderName)
                    deployedMod = mod;
            foreach (Mod mod in this.changedMods)
                if (mod.ManagedFolder == currentManagedFolderName)
                    changedMod = mod;
            if (deployedMod == null || changedMod == null)
            {
                MsgBox.Get("modDetailsMoveManagedFolderFailed").FormatText("Internal error").Show(MessageBoxIcon.Error);
                return currentManagedFolderName;
            }

            String currentManagedFolderPath = deployedMod.GetManagedPath();
            String newManagedFolderPath = Utils.GetUniquePath(Path.Combine(Shared.GamePath, "Mods", newManagedFolderName));
            newManagedFolderName = Path.GetFileName(newManagedFolderPath);
            try
            {
                Directory.Move(currentManagedFolderPath, newManagedFolderPath);
                deployedMod.ManagedFolder = newManagedFolderName;
                changedMod.ManagedFolder = newManagedFolderName;
                this.Save();
                return newManagedFolderName;
            }
            catch (Exception exc)
            {
                MsgBox.Get("modDetailsMoveManagedFolderFailed").FormatText(exc.Message).Show(MessageBoxIcon.Error);
            }
            return currentManagedFolderName;
        }

        public Archive2.Preset GetArchive2Preset(Mod mod)
        {
            var preset = new Archive2.Preset();

            // No detection needed, "convert" Mod.ArchiveCompression to Archive2.Compression and Mod.ArchiveFormat to Archive2.Format:
            if (mod.Compression != Mod.ArchiveCompression.Auto && mod.Format != Mod.ArchiveFormat.Auto)
            {
                preset.compression = mod.Compression == Mod.ArchiveCompression.Compressed ? Archive2.Compression.Default : Archive2.Compression.None;
                preset.format = mod.Format == Mod.ArchiveFormat.General ? Archive2.Format.General : Archive2.Format.DDS;

                return preset;
            }

            // Detect mod type:
            // String[] resourceFolders = new string[] { "meshes", "strings", "music", "sound", "textures", "materials", "interface", "geoexporter", "programs", "vis", "scripts", "misc", "shadersfx", "lodsettings" };
            String[] generalFolders = new string[] { "meshes", "strings", "interface", "materials" };
            String[] textureFolders = new string[] { "textures", "effects" };
            String[] soundFolders = new string[] { "sound", "music" };

            int generalFoldersCount = 0;
            int textureFoldersCount = 0;
            int soundFoldersCount = 0;

            String managedFolderPath = mod.GetManagedPath();
            IEnumerable<String> folders = Directory.EnumerateDirectories(managedFolderPath);
            foreach (String path in folders)
            {
                String folderName = Path.GetFileName(path).ToLower();

                if (generalFolders.Contains(folderName))
                    generalFoldersCount++;
                else if (textureFolders.Contains(folderName))
                    textureFoldersCount++;
                else if (soundFolders.Contains(folderName))
                    soundFoldersCount++;
            }
            
            //int fileCount = Directory.EnumerateFiles(managedFolderPath).Count();
            //if (fileCount == 0)

            if (soundFoldersCount > generalFoldersCount && soundFoldersCount > textureFoldersCount)
            {
                preset.compression = Archive2.Compression.None;
                preset.format = Archive2.Format.General;
            } else if (textureFoldersCount > generalFoldersCount && textureFoldersCount > soundFoldersCount)
            {
                preset.compression = Archive2.Compression.Default;
                preset.format = Archive2.Format.DDS;
            } else
            {
                preset.compression = Archive2.Compression.Default;
                preset.format = Archive2.Format.General;
            }

            return preset;
        }

        private void ManipulateModFolder(Mod mod, String managedFolderPath, Action<String, int> updateProgress = null)
        {
            foreach (String path in Directory.EnumerateFiles(managedFolderPath))
            {
                // If a *.ba2 archive was found, extract it:
                if (path.EndsWith(".ba2"))
                {
                    if (ExtractBA2Archive(path, managedFolderPath, updateProgress))
                        File.Delete(path);
                }

                // Remove crap:
                if (path.EndsWith(".txt"))
                    File.Delete(path);
            }

            String[] typicalFolders = new string[] { "meshes", "strings", "music", "sound", "textures", "materials", "interface", "geoexporter", "programs", "vis", "scripts", "misc", "shadersfx" };
            // Do it two times, because it changes files, so we need to check again.
            for (int i = 0; i < 2; i++)
            {
                // Search through all folders in the mod folder.
                foreach (String path in Directory.GetDirectories(managedFolderPath))
                {
                    String name = Path.GetFileName(path).ToLower();

                    // If only a data folder is in the mod folder... 
                    if (name == "data" && Directory.EnumerateFiles(managedFolderPath).Count() == 0)
                    {
                        // ... move all files in data on up:
                        Directory.Move(path, managedFolderPath);
                        // Delete the empty data folder afterwards:
                        // Directory.Delete(path);
                        break;
                    }

                    // If the mod folder contains "textures"...
                    if (name == "textures" && Directory.EnumerateFiles(managedFolderPath).Count() == 0)
                    {
                        // ... set ba2 format type to DDS
                        if (mod.Format != Mod.ArchiveFormat.Auto)
                        {
                            mod.Format = Mod.ArchiveFormat.Textures;
                            mod.RootFolder = "Data";
                            break;
                        }
                    }
                }
            }

            // Search through all files in the mod folder.
            foreach (String path in Directory.EnumerateFiles(managedFolderPath))
            {
                String name = Path.GetFileName(path).ToLower();
                String extension = Path.GetExtension(path).ToLower();

                // If the mod contains *.dll files...
                if (extension == ".dll")
                {
                    // ... then it probably has to be installed as loose files into the root directory:
                    mod.Type = Mod.FileType.Loose;
                    mod.RootFolder = ".";
                }
            }
        }

        private bool ExtractBA2Archive(String archivePath, String destinationPath, Action<String, int> updateProgress = null)
        {
            String filePath = Path.GetFullPath(archivePath);
            String fileName = Path.GetFileNameWithoutExtension(filePath);
            String fileExtension = Path.GetExtension(filePath);

            // Rename *.ba2 file if necessary:
            if (fileName.Contains(",") || fileName != Utils.GetValidFileName(fileName))
            {
                String newFileName = Utils.GetValidFileName(fileName).Replace(",", "_") + fileExtension;
                String newFilePath = Path.Combine(Path.GetDirectoryName(filePath), newFileName);
                File.Move(filePath, newFilePath);
                fileName = newFileName;
                filePath = newFilePath;
            }

            if (fileExtension.ToLower() == ".ba2")
            {
                // For *.ba2 archives, Archive2 has to be installed:
                if (!Archive2.ValidatePath())
                {
                    MsgBox.ShowID("modsArchive2Missing", MessageBoxIcon.Error);
                    return false;
                }

                if (updateProgress != null)
                    updateProgress($"Extracting {fileName}.ba2 ...", -1);

                Archive2.Extract(filePath, destinationPath);

                return true;
            }
            else
                return false;
        }

        private bool ExtractModArchive(String archivePath, String managedFolderPath, Action<String, int> updateProgress = null)
        {
            String filePath = Path.GetFullPath(archivePath);
            String fileName = Path.GetFileNameWithoutExtension(filePath);
            String fileExtension = Path.GetExtension(filePath);

            if (fileExtension.ToLower() == ".ba2")
            {
                return ExtractBA2Archive(filePath, managedFolderPath);
            }
            else if ((new String[] { ".zip", ".rar", ".tar", ".tar.gz", ".gz", ".xz", ".lz", ".bz2" }).Contains(fileExtension.ToLower()))
            {
                try
                {
                    using (Stream stream = File.OpenRead(filePath))
                    using (var reader = ReaderFactory.Open(stream))
                    {
                        while (reader.MoveToNextEntry())
                        {
                            if (!reader.Entry.IsDirectory)
                            {
                                if (updateProgress != null)
                                    updateProgress(reader.Entry.Key, -1);
                                reader.WriteEntryToDirectory(managedFolderPath, new ExtractionOptions()
                                {
                                    ExtractFullPath = true,
                                    Overwrite = true
                                });
                            }
                        }
                    }

                    return true;
                }
                catch (InvalidOperationException exc)
                {
                    MsgBox.Get("modsExtractUnknownError").FormatText(exc.Message).Show(MessageBoxIcon.Error);
                    return false;
                }
            }
            else if ((new String[] { ".7z" }).Contains(fileExtension.ToLower()))
            {
                try
                {
                    Utils.ExtractArchive(filePath, managedFolderPath);

                    if (Directory.Exists(managedFolderPath))
                    {
                        return true;
                    }
                    else
                    {
                        MsgBox.ShowID("modsExtractUnknownErrorText", MessageBoxIcon.Error);
                        //MessageBox.Show($"Please uncompress the archive and add the mod as a folder.", "Archive couldn't be uncompressed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception exc)
                {
                    MsgBox.Get("modsExtractUnknownError7zip").FormatText(exc.Message).Show(MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                //MessageBox.Show($"*{fileExtension} files are not supported.\nPlease uncompress the archive and add the mod as a folder.", "Unsupported file format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MsgBox.Get("modsArchiveTypeNotSupported").FormatText(fileExtension).Show(MessageBoxIcon.Error);
                return false;
            }
        }

        public void InstallModArchiveFrozen(String filePath, Action<String, int> updateProgress = null, Action<bool> done = null)
        {
            // Some conditions have to be met:
            if (Shared.GamePath == null)
            {
                this.logFile.WriteLine("Couldn't import *.ba2 file: No game path has been set.");
                if (done != null)
                    done(false);
                return;
            }

            if (!File.Exists(filePath))
            {
                // Path too long?
                // https://stackoverflow.com/questions/5188527/how-to-deal-with-files-with-a-name-longer-than-259-characters
                // https://docs.microsoft.com/de-de/archive/blogs/jeremykuhne/more-on-new-net-path-handling
                if (File.Exists(@"\\?\" + filePath))
                {
                    filePath = @"\\?\" + filePath;
                }
                else
                {
                    this.logFile.WriteLine($"Error while importing *.ba2 file: Couldn't locate file: {filePath}");
                    if (done != null)
                        done(false);
                    throw new FileNotFoundException(filePath);
                }
            }

            try
            {
                // Create Mods folder:
                if (!Directory.Exists(Path.Combine(Shared.GamePath, "Mods")))
                    Directory.CreateDirectory(Path.Combine(Shared.GamePath, "Mods"));

                // Get paths:
                filePath = Path.GetFullPath(filePath);
                String fileName = Path.GetFileNameWithoutExtension(filePath);
                String fileExtension = Path.GetExtension(filePath);
                String managedFolderPath = Utils.GetUniquePath(Path.Combine(Shared.GamePath, "Mods", fileName));
                String managedFolder = Path.GetFileName(managedFolderPath);

                // Create a new mod:
                Mod mod = new Mod();
                mod.Title = fileName;
                mod.ManagedFolder = managedFolder;
                mod.RootFolder = "Data";
                mod.ArchiveName = fileName;
                mod.Type = Mod.FileType.SeparateBA2;
                // TODO: Detect archive format:
                // mod.Compression = Archive2.Compression.??
                // mod.Format = Mod.ArchiveFormat.??
                mod.freeze = true;
                mod.OverwriteFrozen(true);
                mod.isEnabled = false;

                // Copy the archive:
                if (updateProgress != null)
                    updateProgress($"Copying {Path.GetFileName(filePath)}", -1);

                if (!Directory.Exists(managedFolderPath))
                    Directory.CreateDirectory(managedFolderPath);

                File.Copy(filePath, Path.Combine(managedFolderPath, "frozen.ba2"));
                this.AddInstalledMod(mod);
                this.Save();

                if (done != null)
                    done(true);
            }
            catch (UnauthorizedAccessException ex)
            {
                MsgBox.Get("modsAccessDenied").FormatText("UnauthorizedAccessException: " + ex.Message).Show(MessageBoxIcon.Error);
                this.logFile.WriteLine($"UnauthorizedAccessException occured while importing a folder: {ex.Message}\n{ex.StackTrace}\n");
                if (done != null)
                    done(false);
                return;
            }
            catch (Exception ex)
            {
                this.logFile.WriteLine($"Unhandled exception occured while importing a *.ba2 file: {ex.Message}\n{ex.StackTrace}\n");
                if (done != null)
                    done(false);
                return;
            }
        }

        /// <summary>
        /// Extracts the archive and adds the mod.
        /// Saves the manifest afterwards.
        /// </summary>
        /// <param name="filePath">Path to archive</param>
        /// <param name="updateProgress">Callback: Progress has been made.</param>
        /// <param name="done">Callback: It's done.</param>
        public void InstallModArchive(String filePath, Action<String, int> updateProgress = null, Action<bool> done = null)
        {
            // Some conditions have to be met:
            if (Shared.GamePath == null)
            {
                this.logFile.WriteLine("Couldn't import *.ba2 file: No game path has been set.");
                if (done != null)
                    done(false);
                return;
            }

            if (!File.Exists(filePath))
            {
                // Path too long?
                // https://stackoverflow.com/questions/5188527/how-to-deal-with-files-with-a-name-longer-than-259-characters
                // https://docs.microsoft.com/de-de/archive/blogs/jeremykuhne/more-on-new-net-path-handling
                if (File.Exists(@"\\?\" + filePath))
                {
                    filePath = @"\\?\" + filePath;
                }
                else
                {
                    this.logFile.WriteLine($"Error while importing *.ba2 file: Couldn't locate file: {filePath}");
                    if (done != null)
                        done(false);
                    throw new FileNotFoundException(filePath);
                }
            }


            if (!Archive2.ValidatePath())
            {
                MsgBox.ShowID("modsArchive2Missing", MessageBoxIcon.Error);
                this.logFile.WriteLine("Archive2 is missing.");
                if (done != null)
                    done(false);
                return;
            }

            try
            {
                // Create Mods folder:
                if (!Directory.Exists(Path.Combine(Shared.GamePath, "Mods")))
                    Directory.CreateDirectory(Path.Combine(Shared.GamePath, "Mods"));

                // Get paths:
                filePath = Path.GetFullPath(filePath);
                String fileName = Path.GetFileNameWithoutExtension(filePath);
                String fileExtension = Path.GetExtension(filePath);
                String managedFolderPath = Utils.GetUniquePath(Path.Combine(Shared.GamePath, "Mods", fileName));
                String managedFolder = Path.GetFileName(managedFolderPath);
                /*if (Directory.Exists(managedFolderPath))
                {
                    managedFolder += DateTime.Now.ToString("(yyyy-MM-dd_HH-mm-ss)");
                    managedFolderPath = Path.Combine(this.GamePath, "Mods", managedFolder);
                }*/

                // Create a new mod:
                Mod mod = new Mod();
                mod.Title = fileName;
                mod.ManagedFolder = managedFolder;
                mod.RootFolder = "Data";
                mod.ArchiveName = fileName;
                mod.Type = Mod.FileType.BundledBA2;
                mod.isEnabled = false;

                // Extract the archive:
                if (updateProgress != null)
                    updateProgress($"Extracting {Path.GetFileName(filePath)}", -1);
                if (ExtractModArchive(filePath, managedFolderPath, updateProgress))
                {
                    ManipulateModFolder(mod, managedFolderPath, updateProgress);
                    this.AddInstalledMod(mod);
                    this.Save();
                }

                if (done != null)
                    done(true);
            }
            catch (Archive2Exception ex)
            {
                ManagedMods.Instance.logFile.WriteLine($"Archive2Exception occured while importing an archive: {ex.Message}\n{ex.StackTrace}\n");
                MsgBox.Get("archive2Error").Show(MessageBoxIcon.Error);
                if (done != null)
                    done(false);
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                MsgBox.Get("modsAccessDenied").FormatText("UnauthorizedAccessException: " + ex.Message).Show(MessageBoxIcon.Error);
                this.logFile.WriteLine($"UnauthorizedAccessException occured while importing an archive: {ex.Message}\n{ex.StackTrace}\n");
                if (done != null)
                    done(false);
                return;
            }
            catch (Exception ex)
            {
                this.logFile.WriteLine($"Unhandled exception occured while importing an archive: {ex.Message}\n{ex.StackTrace}\n");
                if (done != null)
                    done(false);
                return;
            }
        }

        /// <summary>
        /// Copies the folder's contents and adds the mod.
        /// Saves the manifest afterwards.
        /// </summary>
        /// <param name="folderPath">Path to directory</param>
        /// <param name="updateProgress">Callback: "Copying file xyz" and percentage.</param>
        /// <param name="done">Callback: It's done.</param>
        public void InstallModFolder(String folderPath, Action<String, int> updateProgress = null, Action<bool> done = null)
        {
            // Some conditions have to be met:
            if (Shared.GamePath == null)
            {
                this.logFile.WriteLine("Couldn't import folder: No game path has been set.");
                if (done != null)
                    done(false);
                return;
            }

            if (!Directory.Exists(folderPath))
            {
                // Path too long?
                // https://stackoverflow.com/questions/5188527/how-to-deal-with-files-with-a-name-longer-than-259-characters
                // https://docs.microsoft.com/de-de/archive/blogs/jeremykuhne/more-on-new-net-path-handling
                if (Directory.Exists(@"\\?\" + folderPath))
                {
                    folderPath = @"\\?\" + folderPath;
                }
                else
                {
                    this.logFile.WriteLine($"Error while importing a folder: Couldn't locate folder: {folderPath}");
                    if (done != null)
                        done(false);
                    throw new FileNotFoundException(folderPath);
                }
            }


            if (!Archive2.ValidatePath())
            {
                MsgBox.ShowID("modsArchive2Missing", MessageBoxIcon.Error);
                this.logFile.WriteLine("Archive2 is missing.");
                if (done != null)
                    done(false);
                return;
            }

            try
            {
                // Create Mods folder:
                if (!Directory.Exists(Path.Combine(Shared.GamePath, "Mods")))
                    Directory.CreateDirectory(Path.Combine(Shared.GamePath, "Mods"));

                // Get paths:
                folderPath = Path.GetFullPath(folderPath);
                String folderName = Path.GetFileName(folderPath);
                String managedFolderPath = Utils.GetUniquePath(Path.Combine(Shared.GamePath, "Mods", folderName));
                String managedFolder = Path.GetFileName(managedFolderPath);

                // Create a new mod:
                Mod mod = new Mod();
                mod.Title = folderName;
                mod.ManagedFolder = managedFolder;
                mod.RootFolder = "Data";
                mod.ArchiveName = folderName;
                mod.Type = Mod.FileType.BundledBA2;
                mod.isEnabled = false;

                // Copy every file found in the folder:
                if (updateProgress != null)
                    updateProgress($"Indexing {folderName}...", -1);
                IEnumerable<String> files = Directory.EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories);
                float count = (float)files.Count();
                if (count == 0)
                {
                    this.logFile.WriteLine($"Imported folder is empty. Abort.");
                    if (done != null)
                        done(false);
                    return;
                }
                int i = 0;
                foreach (String file in files)
                {
                    if (updateProgress != null)
                        updateProgress($"Copying {Path.GetFileName(file)} ...", Convert.ToInt32((float)i++ / (float)count * 100));

                    // Make a relative path, create directories and copy file:
                    String destinationPath = Path.Combine(managedFolderPath, Utils.MakeRelativePath(folderPath, file));
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                    File.Copy(file, destinationPath);
                }

                ManipulateModFolder(mod, managedFolderPath, updateProgress);

                // Add to mods:
                AddInstalledMod(mod);
                this.Save();

                if (done != null)
                    done(true);
            }
            catch (Archive2Exception ex)
            {
                ManagedMods.Instance.logFile.WriteLine($"Archive2Exception occured while importing a folder: {ex.Message}\n{ex.StackTrace}\n");
                MsgBox.Get("archive2Error").Show(MessageBoxIcon.Error);
                if (done != null)
                    done(false);
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                MsgBox.Get("modsAccessDenied").FormatText("UnauthorizedAccessException: " + ex.Message).Show(MessageBoxIcon.Error);
                this.logFile.WriteLine($"UnauthorizedAccessException occured while importing a folder: {ex.Message}\n{ex.StackTrace}\n");
                if (done != null)
                    done(false);
                return;
            }
            catch (Exception ex)
            {
                this.logFile.WriteLine($"Unhandled exception occured while importing a folder: {ex.Message}\n{ex.StackTrace}\n");
                if (done != null)
                    done(false);
                return;
            }
        }

        private void AddInstalledMod(Mod mod)
        {
            mods.Add(mod.CreateDeepCopy());
            AddMod(mod);
        }

        public void AddMod(Mod mod)
        {
            changedMods.Add(mod);
        }

        public void EnableMod(int index)
        {
            if (changedMods[index].isEnabled)
                return;
            changedMods[index].isEnabled = true;
        }

        public void DisableMod(int index)
        {
            if (!changedMods[index].isEnabled)
                return;
            changedMods[index].isEnabled = false;
        }

        public void ToggleMod(int index, bool enabled)
        {
            if (changedMods[index].isEnabled == enabled)
                return;
            changedMods[index].isEnabled = enabled;
        }

        public bool isModEnabled(int index)
        {
            return changedMods[index].isEnabled;
        }

        private int MoveMod(int oldIndex, int newIndex)
        {
            // https://stackoverflow.com/questions/450233/generic-list-moving-an-item-within-the-list
            Mod mod = this.changedMods[oldIndex];

            this.changedMods.RemoveAt(oldIndex);

            // the actual index could have shifted due to the removal
            // if (newIndex > oldIndex) newIndex--;

            this.changedMods.Insert(newIndex, mod);

            return newIndex;
        }


        public int MoveModUp(int index)
        {
            if (index > 0)
                return MoveMod(index, index - 1);
            return index;
        }

        public int MoveModDown(int index)
        {
            if (index < this.changedMods.Count - 1)
                return MoveMod(index, index + 1);
            return index;
        }

        /// <summary>
        /// Compares this.mods and this.changedMods.
        /// Since this.mods represents the state on disk and this.changedMods represents changed that are due,
        /// if both aren't equal then deployment is necessary.
        /// </summary>
        /// <returns></returns>
        public bool isDeploymentNecessary()
        {
            if (this.changedMods.Count() != this.mods.Count())
                return true;
            for (int i = 0; i < this.changedMods.Count(); i++)
            {
                if (this.changedMods[i].isEnabled != this.mods[i].isEnabled ||
                    this.changedMods[i].LooseFiles.Count() != this.mods[i].LooseFiles.Count() ||
                    this.changedMods[i].RootFolder != this.mods[i].RootFolder ||
                    this.changedMods[i].Type != this.mods[i].Type ||
                    this.changedMods[i].ManagedFolder != this.mods[i].ManagedFolder ||
                    this.changedMods[i].Compression != this.mods[i].Compression ||
                    this.changedMods[i].Format != this.mods[i].Format ||
                    this.changedMods[i].freeze != this.mods[i].freeze)
                    return true;
            }
            return false;
        }

        /*public String GamePath
        {
            get { return this.gamePath; }
            set
            {
                if (value != null && Directory.Exists(value))
                    this.gamePath = Path.GetFullPath(value);
            }
        }*/

        public String GetModPath(int index)
        {
            return Path.Combine(Shared.GamePath, "Mods", this.changedMods[index].ManagedFolder);
        }

        public String GetInstalledModPath(int index)
        {
            return Path.Combine(Shared.GamePath, "Mods", this.mods[index].ManagedFolder);
        }

        public struct Conflict
        {
            public String conflictText;
            public List<String> conflictingFiles;
        }

        public List<Conflict> GetConflictingFiles()
        {
            //List<String> conflictingFiles = new List<String>();
            //List<String> conflictingMods = new List<String>();
            List<Conflict> conflictingMods = new List<Conflict>();
            for (int i = 1; i < this.changedMods.Count; i++)
            {
                Mod lowerMod = this.changedMods[i];
                String lowerPath = Path.Combine(Shared.GamePath, "Mods", lowerMod.ManagedFolder);
                if (!lowerMod.isEnabled && Directory.Exists(lowerPath))
                    continue;
                List<String> lowerRelPaths = new List<String>();
                foreach (String filePath in Directory.EnumerateFiles(lowerPath, "*.*", SearchOption.AllDirectories))
                    lowerRelPaths.Add(Utils.MakeRelativePath(lowerPath, filePath));

                //for (int l = i - 1; l >= 0; l--)
                for (int l = 0; l < i; l++)
                {
                    Conflict conflict = new Conflict();
                    conflict.conflictingFiles = new List<String>();
                    Mod upperMod = this.changedMods[l];
                    String upperPath = Path.Combine(Shared.GamePath, "Mods", upperMod.ManagedFolder);
                    if (!upperMod.isEnabled && Directory.Exists(upperPath))
                        continue;
                    IEnumerable<String> upperFiles = Directory.EnumerateFiles(upperPath, "*.*", SearchOption.AllDirectories);
                    foreach (String filePath in upperFiles)
                    {
                        String relUpperPath = Utils.MakeRelativePath(upperPath, filePath);
                        if (!relUpperPath.Contains("frozen.ba2") && lowerRelPaths.Contains(relUpperPath))
                        {
                            if (!conflict.conflictingFiles.Contains(relUpperPath))
                                conflict.conflictingFiles.Add(relUpperPath);
                            conflict.conflictText = lowerMod.Title + " overrides " + upperMod.Title;
                        }
                    }
                    if (conflict.conflictingFiles.Count > 0)
                        conflictingMods.Add(conflict);
                }
            }
            return conflictingMods;
        }

        public void ImportInstalledMods()
        {
            // Get all archives:
            List<String> sResourceIndexFileList = (new List<String>(IniFiles.Instance.GetString(IniFile.F76Custom, "Archive", "sResourceIndexFileList", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))).Distinct().ToList();
            List<String> sResourceArchive2List = (new List<String>(IniFiles.Instance.GetString(IniFile.F76Custom, "Archive", "sResourceArchive2List", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))).Distinct().ToList();

            // Prepare list:
            List<String> installedMods = new List<String>();
            installedMods.AddRange(sResourceIndexFileList);
            installedMods.AddRange(sResourceArchive2List);
            installedMods.Remove("bundled.ba2");
            installedMods.Remove("bundled_textures.ba2");
            foreach (Mod mod in this.mods)
                if (mod.Type == Mod.FileType.SeparateBA2)
                    installedMods.Remove(mod.ArchiveName);

            // Ignore any game files ("SeventySix - *.ba2"):
            foreach (String archiveName in sResourceIndexFileList)
                if (archiveName.StartsWith("SeventySix"))
                    installedMods.Remove(archiveName);
            foreach (String archiveName in sResourceArchive2List)
                if (archiveName.StartsWith("SeventySix"))
                    installedMods.Remove(archiveName);

            // Import every archive:
            foreach (String archiveName in installedMods)
            {
                String path = Path.Combine(Shared.GamePath, "Data", archiveName);
                Console.WriteLine(path);
                if (File.Exists(path))
                {
                    // Import archive:
                    this.InstallModArchiveFrozen(path);
                    File.Delete(path);

                    // Remove from lists:
                    if (sResourceIndexFileList.Contains(archiveName))
                        sResourceIndexFileList.Remove(archiveName);
                    if (sResourceArchive2List.Contains(archiveName))
                        sResourceArchive2List.Remove(archiveName);
                }
            }

            // Save *.ini files:
            sResourceIndexFileList = sResourceIndexFileList.Distinct().ToList();
            sResourceArchive2List = sResourceArchive2List.Distinct().ToList();
            if (sResourceIndexFileList.Count > 0)
                IniFiles.Instance.Set(IniFile.F76Custom, "Archive", "sResourceIndexFileList", String.Join(",", sResourceIndexFileList.ToArray()));
            else
                IniFiles.Instance.Remove(IniFile.F76Custom, "Archive", "sResourceIndexFileList");
            if (sResourceArchive2List.Count > 0)
                IniFiles.Instance.Set(IniFile.F76Custom, "Archive", "sResourceArchive2List", String.Join(",", sResourceArchive2List.ToArray()));
            else
                IniFiles.Instance.Remove(IniFile.F76Custom, "Archive", "sResourceArchive2List");
            IniFiles.Instance.SaveAll();
        }

        public XDocument Serialize()
        {
            /*
             Fallout76\Mods\manifest.xml
             <Mods>
                <Mod ... />
                <Mod ... />
                <Mod ... />
             </Mods>
             */

            XDocument xmlDoc = new XDocument();
            XElement xmlRoot = new XElement("Mods");
            xmlDoc.Add(xmlRoot);
            foreach (Mod mod in mods)
            {
                if (Directory.Exists(mod.GetManagedPath()))
                    xmlRoot.Add(mod.Serialize());
            }
            return xmlDoc;
        }

        public void Unload()
        {
            this.mods.Clear();
            this.changedMods.Clear();

            Shared.ClearGamePath();
        }

        public void Load()
        {
            this.mods.Clear();
            this.changedMods.Clear();

            if (Shared.GamePath == null)
                return;

            if (!IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bMultipleGameEditionsUsed", false))
                this.LoadINILists();

            String manifestPath = Path.Combine(Shared.GamePath, "Mods", "manifest.xml");

            if (!File.Exists(manifestPath))
                return;

            XDocument xmlDoc = XDocument.Load(manifestPath);

            foreach (XElement xmlMod in xmlDoc.Descendants("Mod"))
            {
                try
                {
                    Mod mod = Mod.Deserialize(xmlMod);
                    if (!Directory.Exists(Path.Combine(Shared.GamePath, "Mods", mod.ManagedFolder)))
                        continue;
                    this.AddInstalledMod(mod);
                }
                catch (Exception ex)
                {
                    /* InvalidDataException, ArgumentException */
                    MsgBox.Get("modsInvalidManifestEntry").FormatText(ex.Message).Show(MessageBoxIcon.Warning);
                }
            }
        }

        public void Save()
        {
            if (Shared.GamePath == null)
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(Path.Combine(Shared.GamePath, "Mods")))
                Directory.CreateDirectory(Path.Combine(Shared.GamePath, "Mods"));

            this.CopyINILists();
            this.Serialize().Save(Path.Combine(Shared.GamePath, "Mods", "manifest.xml"));
        }

        private class DeployArchive
        {
            public String tempPath;
            public String archiveName;
            public Archive2.Format format = Archive2.Format.General;
            public Archive2.Compression compression = Archive2.Compression.Default;
            public int count = 0;

            public DeployArchive(String name, String tempFolderPath)
            {
                this.tempPath = Path.Combine(tempFolderPath, name);
                if (name == "general")
                    this.archiveName = "bundled.ba2";
                else
                    this.archiveName = "bundled_" + name + ".ba2";

                /*if (Directory.Exists(this.tempPath))
                    Directory.Delete(this.tempPath, true);*/
                Directory.CreateDirectory(this.tempPath);
            }
        }

        public void Deploy(Action<String, int> updateProgress = null, Action<bool> done = null)
        {
            try
            {
                this.logFile.WriteLine("\n\n");
                this.logFile.WriteTimeStamp();
                this.logFile.WriteLine($"Version {Shared.VERSION}, deploying...");

                /*
                 * Check if everything is ready for deployment:
                 */

                // Archive2 existing?
                if (!Archive2.ValidatePath())
                {
                    MsgBox.ShowID("modsArchive2Missing", MessageBoxIcon.Error);
                    this.logFile.WriteLine("Failed: Couldn't find Archive2");
                    if (done != null)
                        done(false);
                    return;
                }

                // Game path existing?
                if (Shared.GamePath == null)
                {
                    if (done != null)
                        done(false);
                    return;
                }

                // Game path valid?
                if (!Directory.Exists(Path.Combine(Shared.GamePath, "Data")))
                {
                    MsgBox.ShowID("modsGamePathInvalid", MessageBoxIcon.Error);
                    this.logFile.WriteLine("Failed: Game path invalid");
                    if (done != null)
                        done(false);
                    return;
                }

                // Check if we don't have multiple mods with the same archive name:
                List<String> customArchiveNames = new List<String>();
                foreach (Mod mod in this.changedMods)
                {
                    if (mod.Type == Mod.FileType.SeparateBA2 && mod.isEnabled)
                    {
                        if (customArchiveNames.Contains(mod.ArchiveName.ToLower()))
                        {
                            MsgBox.Get("modsSameArchiveName").FormatText(mod.ArchiveName, mod.Title).Show(MessageBoxIcon.Error);
                            this.logFile.WriteLine($"Conflict: Multiple mods with the same archive name. (1st conflict: '{mod.ArchiveName}', '{mod.Title}')");
                            if (done != null)
                                done(false);
                            return;
                        }
                        else
                        {
                            customArchiveNames.Add(mod.ArchiveName.ToLower());
                        }
                    }
                }



                /*
                 * Check / declare parameters
                 */

                // NW Mode:
                if (this.ModsDisabled)
                {
                    this.logFile.WriteLine("NOTE: Nuclear Winter mode enabled. (Disable Mods checkbox checked)");
                    IniFiles.Instance.Set(IniFile.Config, "Mods", "bDisableMods", this.ModsDisabled);
                }
                else
                {
                    IniFiles.Instance.Set(IniFile.Config, "Mods", "bDisableMods", false);
                }

                // Hard links:
                bool useHardlinks = IniFiles.Instance.GetBool(IniFile.Config, "Mods", "bUseHardlinks", true);
                this.logFile.WriteLine("Deployment method: " + (useHardlinks ? "Make hard links" : "Make copies (slow)"));

                // Create temp folder:
                String tempPath = Path.Combine(Shared.GamePath, "temp");
                if (Directory.Exists(tempPath))
                    Directory.Delete(tempPath, true);
                Directory.CreateDirectory(tempPath);

                // Setup 'DeployArchives' for every bundled archive:
                DeployArchive generalArchive = new DeployArchive("general", tempPath);
                DeployArchive texturesArchive = new DeployArchive("textures", tempPath);
                texturesArchive.format = Archive2.Format.DDS;
                DeployArchive soundsArchive = new DeployArchive("sounds", tempPath);
                soundsArchive.compression = Archive2.Compression.None;
                var archives = new List<DeployArchive>() { generalArchive, texturesArchive, soundsArchive };

                // Frozen bundled archives feature:
                bool freezeBundledArchives = IniFiles.Instance.GetBool(IniFile.Config, "Mods", "bFreezeBundledArchives", false);
                bool frozenBundledArchivesAvailable = false;
                bool repackBundledArchives = true;
                String frozenBundledFolder = Path.Combine(Shared.GamePath, "Mods", "_frozen");
                if (freezeBundledArchives)
                {
                    this.logFile.WriteLine($"NOTE: Experimental feature 'Freeze bundled archives' enabled.");

                    // Create folder:
                    if (!Directory.Exists(frozenBundledFolder))
                        Directory.CreateDirectory(frozenBundledFolder);

                    // Do we have frozen archives?
                    foreach (DeployArchive archive in archives)
                        frozenBundledArchivesAvailable = frozenBundledArchivesAvailable || File.Exists(Path.Combine(frozenBundledFolder, archive.archiveName));

                    // Don't repack archives when disabling mods:
                    if (this.ModsDisabled)
                        repackBundledArchives = false;

                    // Ask user whether to deploy frozen archives or repack them:
                    else if (frozenBundledArchivesAvailable)
                        repackBundledArchives = MsgBox.Get("modsRepackFrozenBundledArchives").Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                }

                // Parse lists:
                // sResourceIndexFileList, sResourceArchive2List, sResourceDataDirsFinal
                List<String> sResourceIndexFileList = LoadResourceList("sResourceIndexFileList");
                List<String> sResourceDataDirsFinal = new List<String>(IniFiles.Instance.GetString(IniFile.F76Custom, "Archive", "sResourceDataDirsFinal", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));


                /*
                 *****************************************************
                 * Beginning of deployment:
                 *****************************************************
                 */


                /*
                 * Remove any leftover files from previous installations:
                 */

                this.logFile.WriteLine($"\n\nREMOVING MODS\n");

                // Remove all loose files:
                int i = 0;
                foreach (Mod mod in this.mods)
                {
                    if (updateProgress != null)
                        updateProgress($"[1/4] Removing files of mod {mod.Title} ({i} of {this.mods.Count})", Convert.ToInt32((float)i / (float)this.mods.Count * 20));

                    if (!mod.isEnabled)
                        continue;

                    if (mod.Type == Mod.FileType.Loose)
                    {
                        foreach (String relFilePath in mod.LooseFiles)
                        {
                            String installedFilePath = Path.Combine(Shared.GamePath, mod.RootFolder, relFilePath).Replace("\\.\\", "\\");

                            // Delete file, if existing:
                            if (File.Exists(installedFilePath))
                                File.Delete(installedFilePath);

                            // Use backups, if there are any:
                            if (File.Exists(installedFilePath + ".old"))
                                File.Move(installedFilePath + ".old", installedFilePath);
                            else
                            {
                                // Remove empty folders one by one, if existing:
                                String parent = Path.GetDirectoryName(installedFilePath);
                                while (Directory.Exists(parent) && Utils.IsDirectoryEmpty(parent))
                                {
                                    Directory.Delete(parent);
                                    parent = Path.GetDirectoryName(parent);
                                }
                            }
                        }
                        this.logFile.WriteLine($"Loose files of mod {mod.Title} removed.");
                    }
                    else if (mod.Type == Mod.FileType.SeparateBA2)
                    {
                        String path = Path.Combine(Shared.GamePath, "Data", mod.ArchiveName);
                        if (File.Exists(path))
                            File.Delete(path);

                        if (sResourceIndexFileList.Contains(mod.ArchiveName))
                        {
                            sResourceIndexFileList = sResourceIndexFileList.Distinct().ToList();
                            sResourceIndexFileList.Remove(mod.ArchiveName);
                        }
                        this.logFile.WriteLine($"*.ba2 archive of mod {mod.Title} removed.");
                    }

                    i++;
                }


                /*
                 * Copy all mods
                 */

                this.logFile.WriteLine($"\n\nCOPYING MODS\n");

                i = 0;
                /*int enabledBA2GeneralMods = 0;
                int enabledBA2TexturesMods = 0;*/
                int enabledLooseMods = 0;
                List<String> allModRelPaths = new List<String>();
                int enabledModsCount = this.changedMods.Count(n => n.isEnabled);
                float modPercent = 1f / (float)enabledModsCount * 0.8f;
                foreach (Mod mod in this.changedMods)
                {
                    /*
                     * Skip if nuclear winter mode is enabled.
                     * Skip if mod is disabled.
                     * Show error if mod folder wasn't found
                     */
                    if (this.ModsDisabled)
                        break;

                    if (!mod.isEnabled)
                        continue;

                    String progressModName = $"{mod.Title} ({i + 1} of {enabledModsCount})";
                    int progressPercent = Convert.ToInt32((float)i / (float)enabledModsCount * 80 + 20);

                    if (updateProgress != null)
                        updateProgress($"[2/4] Deploying mod {progressModName}", progressPercent);

                    String managedFolderPath = Path.Combine(Shared.GamePath, "Mods", mod.ManagedFolder);
                    if (!Directory.Exists(managedFolderPath))
                    {
                        //MessageBox.Show($"Directory \"{managedFolderPath}\" does not exist.\nPlease restart the mod manager and add the mod again.", $"Mod {mod.Title} couldn't be deployed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MsgBox.Get("modsDeployErrorModDirNotFound")
                            .FormatTitle(mod.Title)
                            .FormatText(managedFolderPath)
                            .Show(MessageBoxIcon.Error);
                        continue;
                    }

                    /*
                     * Copy files into temporary folder for bundled archives
                     */
                    if (mod.Type == Mod.FileType.BundledBA2)
                    {
                        // Frozen bundled feature:
                        if (!repackBundledArchives)
                        {
                            this.logFile.WriteLine($"[Bundled] Skipping {mod.Title}");
                            continue;
                        }

                        // Check if root folder is data:
                        if (!mod.RootFolder.Contains("Data"))
                        {
                            MsgBox.Get("modsDeployErrorBA2RootIsNotData")
                                .FormatTitle(mod.Title)
                                .Show(MessageBoxIcon.Error);
                            //MessageBox.Show("The root folder has to be set to \".\\Data\" for mods, that are to be installed as a bundled *.ba2 archive.", $"Mod {mod.Title} couldn't be deployed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }

                        this.logFile.WriteLine($"[Bundled] Copying files of {mod.Title} to temp folder.");

                        int generalFiles = 0;
                        int DDSFiles = 0;
                        int soundFiles = 0;

                        // Copy all files to temp data path:
                        // String[] files = Directory.GetFiles(managedFolderPath, "*.*", SearchOption.AllDirectories);
                        IEnumerable<String> files = Directory.EnumerateFiles(managedFolderPath, "*.*", SearchOption.AllDirectories);
                        int count = files.Count();
                        int f = 0;
                        foreach (String filePath in files)
                        {
                            if (updateProgress != null)
                                updateProgress($"[2/4] Copying file {f} of {count} (\"{Path.GetFileName(filePath)}\") of mod {progressModName}", progressPercent + (int)((float)f++ / (float)count * modPercent * 100));

                            // Make a relative path, create directories and copy file:
                            String relativePath = Utils.MakeRelativePath(managedFolderPath, filePath);
                            String destinationPath;
                            if (relativePath.Trim().ToLower().StartsWith("sound") || relativePath.Trim().ToLower().StartsWith("music") ||
                                filePath.ToLower().EndsWith(".wav") || filePath.ToLower().EndsWith(".xwm") || filePath.ToLower().EndsWith(".fuz") || filePath.ToLower().EndsWith(".lip"))
                            {
                                soundFiles++;
                                destinationPath = Path.Combine(soundsArchive.tempPath, relativePath);
                            }
                            else if (filePath.ToLower().EndsWith(".dds"))
                            {
                                DDSFiles++;
                                destinationPath = Path.Combine(texturesArchive.tempPath, relativePath);
                            }
                            else
                            {
                                generalFiles++;
                                destinationPath = Path.Combine(generalArchive.tempPath, relativePath);
                            }
                            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                            if (useHardlinks)
                                Utils.CreateHardLink(filePath, destinationPath, true);
                            else
                                File.Copy(filePath, destinationPath, true);
                        }

                        // Increment counter:
                        if (generalFiles > 0)
                        {
                            //enabledBA2GeneralMods++;
                            generalArchive.count++;
                            this.logFile.WriteLine($"   General files copied: {generalFiles}");
                        }
                        if (DDSFiles > 0)
                        {
                            //enabledBA2TexturesMods++;
                            texturesArchive.count++;
                            this.logFile.WriteLine($"   *.dds files copied:   {DDSFiles}");
                        }
                        if (soundFiles > 0)
                        {
                            //enabledBA2TexturesMods++;
                            soundsArchive.count++;
                            this.logFile.WriteLine($"   Sound files copied:   {soundFiles}");
                        }
                    }
                    /*
                     * Install separate archive:
                     */
                    else if (mod.Type == Mod.FileType.SeparateBA2)
                    {
                        // Check if root folder is data:
                        if (!mod.RootFolder.Contains("Data"))
                        {
                            MsgBox.Get("modsDeployErrorBA2RootIsNotData")
                                .FormatTitle(mod.Title)
                                .Show(MessageBoxIcon.Error);
                            //MessageBox.Show("The root folder has to be set to \".\\Data\" for mods, that are to be installed as a bundled *.ba2 archive.", $"Mod {mod.Title} couldn't be deployed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            continue;
                        }

                        // Check if folder is empty:
                        if (!mod.isFrozen() && Utils.IsDirectoryEmpty(mod.GetManagedPath()))
                        {
                            this.logFile.WriteLine($"[Separate] Skipping {mod.Title} because it's folder is empty.");
                            continue;
                        }

                        if (mod.freeze)
                        {
                            if (mod.isFrozen())
                            {
                                this.logFile.WriteLine($"[Separate] Copying frozen archive of {mod.Title}.");
                                this.logFile.WriteLine($"    Archive name: {mod.ArchiveName}");
                            }
                            else
                            {
                                Archive2.Preset preset = GetArchive2Preset(mod);

                                this.logFile.WriteLine($"[Separate] Freezing archive of {mod.Title}.");
                                this.logFile.WriteLine($"    Archive name: {mod.ArchiveName}");
                                this.logFile.WriteLine($"    Format:       {Enum.GetName(typeof(Archive2.Format), (int)preset.format)}");
                                this.logFile.WriteLine($"    Compression:  {Enum.GetName(typeof(Archive2.Compression), (int)preset.compression)}");

                                if (updateProgress != null)
                                    updateProgress($"[2/4] Creating a *ba2 archive of mod {progressModName}", progressPercent + (int)(modPercent * 100));
                                mod.Freeze();
                            }

                            // Copy archive:
                            if (updateProgress != null)
                                updateProgress($"[2/4] Copying frozen *ba2 archive of mod {progressModName}", progressPercent + (int)(modPercent * 100));

                            string frozenPath = mod.GetFrozenArchivePath();
                            string destPath = Path.Combine(Shared.GamePath, "Data", mod.ArchiveName);
                            if (useHardlinks)
                                Utils.CreateHardLink(frozenPath, destPath, true);
                            else
                                File.Copy(frozenPath, destPath, true);
                        }
                        else
                        {
                            if (mod.isFrozen())
                            {
                                mod.Unfreeze();
                            }

                            Archive2.Preset preset = GetArchive2Preset(mod);

                            this.logFile.WriteLine($"[Separate] Creating archive of {mod.Title}.");
                            this.logFile.WriteLine($"    Archive name: {mod.ArchiveName}");
                            this.logFile.WriteLine($"    Format:       {Enum.GetName(typeof(Archive2.Format), (int)preset.format)}");
                            this.logFile.WriteLine($"    Compression:  {Enum.GetName(typeof(Archive2.Compression), (int)preset.compression)}");

                            // Create archive:
                            if (updateProgress != null)
                                updateProgress($"[2/4] Creating a *ba2 archive of mod {progressModName}", progressPercent + (int)(modPercent * 100));
                            Archive2.Create(Path.Combine(Shared.GamePath, "Data", mod.ArchiveName), managedFolderPath, preset);
                        }
                        sResourceIndexFileList.Add(mod.ArchiveName);
                    }
                    /*
                     * Install loose files:
                     */
                    else if (mod.Type == Mod.FileType.Loose)
                    {
                        // Loose files
                        List<String> modRelPaths = new List<String>();
                        // String[] files = Directory.GetFiles(managedFolderPath, "*.*", SearchOption.AllDirectories);
                        IEnumerable<String> files = Directory.GetFiles(managedFolderPath, "*.*", SearchOption.AllDirectories);
                        int count = files.Count();
                        int f = 0;
                        foreach (String filePath in files)
                        {
                            if (updateProgress != null)
                                updateProgress($"[2/4] Copying file {f} of {count} (\"{Path.GetFileName(filePath)}\") of mod {progressModName}", progressPercent + (int)((float)f++ / (float)count * modPercent * 100));
                            String relPath = Utils.MakeRelativePath(managedFolderPath, filePath);
                            modRelPaths.Add(relPath);
                            String destinationPath = Path.Combine(Shared.GamePath, mod.RootFolder, relPath);
                            Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                            if (!allModRelPaths.Contains(relPath) && File.Exists(destinationPath) && !File.Exists(destinationPath + ".old"))
                                File.Move(destinationPath, destinationPath + ".old");

                            if (useHardlinks)
                                Utils.CreateHardLink(filePath, destinationPath, true);
                            else
                                File.Copy(filePath, destinationPath, true);
                        }
                        mod.LooseFiles = modRelPaths;
                        allModRelPaths.AddRange(modRelPaths);
                        enabledLooseMods++;

                        this.logFile.WriteLine($"[Loose] Files of {mod.Title} copied.");
                    }

                    i++;
                }


                /*
                 * Create all bundled archives
                 */

                this.logFile.WriteLine($"\n\nBUNDLED ARCHIVES\n");

                sResourceIndexFileList = sResourceIndexFileList.Distinct().ToList();
                if (repackBundledArchives)
                {
                    // Create / delete archives:
                    foreach (DeployArchive archive in archives)
                    {
                        String bundledFrozenArchivePath = Path.Combine(frozenBundledFolder, archive.archiveName);
                        String bundledLiveArchivePath = Path.Combine(Shared.GamePath, "Data", archive.archiveName);

                        if (!this.ModsDisabled && archive.count > 0 && !Utils.IsDirectoryEmpty(archive.tempPath))
                        {
                            // Deploy when files exist and NW mode is disabled:
                            if (updateProgress != null)
                                updateProgress($"[3/4] Creating {archive.archiveName}...", -1);

                            if (freezeBundledArchives)
                            {
                                this.logFile.WriteLine($"Freezing {archive.archiveName}");
                                Archive2.Create(bundledFrozenArchivePath, archive.tempPath, archive.compression, archive.format);

                                if (updateProgress != null)
                                    updateProgress($"[3/4] Copying {archive.archiveName}...", -1);

                                if (useHardlinks)
                                    Utils.CreateHardLink(bundledFrozenArchivePath, bundledLiveArchivePath, true);
                                else
                                    File.Copy(bundledFrozenArchivePath, bundledLiveArchivePath, true);
                            }
                            else
                            {
                                this.logFile.WriteLine($"Creating {archive.archiveName}");
                                Archive2.Create(bundledLiveArchivePath, archive.tempPath, archive.compression, archive.format);

                                // Freeze feature disabled, let's clean up junk:
                                if (File.Exists(bundledFrozenArchivePath))
                                {
                                    this.logFile.WriteLine($"Removing frozen {archive.archiveName}");
                                    File.Delete(bundledFrozenArchivePath);
                                }
                            }

                            // Insert entry into list:
                            sResourceIndexFileList.Insert(0, archive.archiveName);
                        }
                        else
                        {
                            // Remove archive when NW mode is active or mod is disabled:

                            // Delete files:
                            if (!this.ModsDisabled && File.Exists(bundledFrozenArchivePath))
                            {
                                this.logFile.WriteLine($"Removing frozen {archive.archiveName}");
                                File.Delete(bundledFrozenArchivePath);
                            }

                            if (File.Exists(bundledLiveArchivePath))
                            {
                                this.logFile.WriteLine($"Removing {archive.archiveName}");
                                File.Delete(bundledLiveArchivePath);
                            }

                            // Remove entry from list:
                            sResourceIndexFileList.Remove(archive.archiveName);
                        }
                    }
                }
                else
                {
                    // Deploy frozen archives:
                    foreach (DeployArchive archive in archives)
                    {
                        if (updateProgress != null)
                            updateProgress($"[3/4] Deploying {archive.archiveName}...", -1);

                        String bundledFrozenArchivePath = Path.Combine(frozenBundledFolder, archive.archiveName);
                        String bundledLiveArchivePath = Path.Combine(Shared.GamePath, "Data", archive.archiveName);

                        if (this.ModsDisabled)
                        {
                            this.logFile.WriteLine($"Removing {archive.archiveName}");
                            File.Delete(bundledLiveArchivePath);
                            sResourceIndexFileList.Remove(archive.archiveName);
                        }
                        else if (File.Exists(bundledFrozenArchivePath) && !File.Exists(bundledLiveArchivePath))
                        {
                            this.logFile.WriteLine($"Deploying frozen {archive.archiveName}");
                            if (useHardlinks)
                                Utils.CreateHardLink(bundledFrozenArchivePath, bundledLiveArchivePath, true);
                            else
                                File.Copy(bundledFrozenArchivePath, bundledLiveArchivePath, true);

                            sResourceIndexFileList.Insert(0, archive.archiveName);
                        }
                        else if (!File.Exists(bundledFrozenArchivePath) && File.Exists(bundledLiveArchivePath))
                        {
                            this.logFile.WriteLine($"Removing {archive.archiveName}");
                            File.Delete(bundledLiveArchivePath);
                            sResourceIndexFileList.Remove(archive.archiveName);
                        }
                        else if (File.Exists(bundledLiveArchivePath))
                        {
                            this.logFile.WriteLine($"Skipping {archive.archiveName}");
                        }
                    }
                }

                /*
                 * Finishing up...
                 */

                if (updateProgress != null)
                    updateProgress("[4/4] Finishing up...", -1);
                this.logFile.WriteLine($"\n\nFINISHING UP");


                // Renaming *.dll files
                if (!this.ModsDisabled)
                    RestoreAddedDLLs();

                // Writing lists to *.ini files
                this.logFile.WriteLine($"   Changing values in *.ini files...");
                SaveResourceList("sResourceIndexFileList", sResourceIndexFileList);

                // sResourceDataDirsFinal
                if (this.WriteDataDirs)
                {
                    sResourceDataDirsFinal.Clear();
                    String[] resourceFolders = new string[] { "meshes", "strings", "music", "sound", "textures", "materials", "interface", "geoexporter", "programs", "vis", "scripts", "misc", "shadersfx", "lodsettings" };
                    foreach (String folder in Directory.GetDirectories(Path.Combine(Shared.GamePath, "Data")))
                    {
                        String folderName = Path.GetFileName(folder);
                        if (resourceFolders.Contains(folderName.ToLower()))
                            sResourceDataDirsFinal.Add(folderName.ToUpper() + "\\");
                    }
                    if (sResourceDataDirsFinal.Count() > 0)
                    {
                        IniFiles.Instance.Set(IniFile.F76Custom, "Archive", "sResourceDataDirsFinal", String.Join(",", sResourceDataDirsFinal.Distinct()));
                        IniFiles.Instance.Set(IniFile.F76Custom, "Archive", "bInvalidateOlderFiles", true);
                    }
                    else
                    {
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Archive", "sResourceDataDirsFinal");
                        IniFiles.Instance.Remove(IniFile.F76Custom, "Archive", "bInvalidateOlderFiles");
                    }
                }
                else
                {
                    IniFiles.Instance.Remove(IniFile.F76Custom, "Archive", "sResourceDataDirsFinal");
                    IniFiles.Instance.Remove(IniFile.F76Custom, "Archive", "bInvalidateOlderFiles");
                }

                CopyINILists();

                // Save *.ini files:
                this.logFile.WriteLine($"      Saving.");
                IniFiles.Instance.SaveAll();

                // Save manifest.xml:
                this.mods = CreateDeepCopy(this.changedMods);
                this.Save();

                // Remove temp folder:
                Directory.Delete(tempPath, true);

                this.logFile.WriteLine("Done.\n");

                if (done != null)
                    done(true);
            }
            catch (Archive2RequirementsException ex)
            {
                ManagedMods.Instance.logFile.WriteLine($"Archive2RequirementsException occured while deploying: {ex.Message}\n{ex.StackTrace}\n");
                MsgBox.Get("archive2InstallRequirements").Show(MessageBoxIcon.Error);
                if (done != null)
                    done(false);
                return;
            }
            catch (Archive2Exception ex)
            {
                ManagedMods.Instance.logFile.WriteLine($"Archive2Exception occured while deploying: {ex.Message}\n{ex.StackTrace}\n");
                MsgBox.Get("archive2Error").Show(MessageBoxIcon.Error);
                if (done != null)
                    done(false);
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                MsgBox.Get("modsAccessDenied").FormatText("UnauthorizedAccessException: " + ex.Message).Show(MessageBoxIcon.Error);
                this.logFile.WriteLine($"UnauthorizedAccessException occured while deploying: {ex.Message}\n{ex.StackTrace}\n");
                if (done != null)
                    done(false);
            }
            catch (Exception ex)
            {
                this.logFile.WriteLine($"Unhandled exception occured: \"{ex.GetType().Name}: {ex.Message}\"\n{ex.StackTrace}");
                if (done != null)
                    done(false);
            }
        }

        public List<String> LoadResourceList (String key)
        {
            List<String> list = new List<String>(IniFiles.Instance.GetString(IniFile.F76Custom, "Archive", key, "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            list.AddRange(IniFiles.Instance.GetString(IniFile.Config, "Archive", key, "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            return list;
        }

        public void SaveResourceList (String key, List<String> list)
        {
            list = list.Distinct().ToList();
            int count = list.Count();
            String value = String.Join(",", list);
              
            IniFile iniFile = WriteToF76Custom ? IniFile.F76Custom : IniFile.Config;
            IniFile otherIniFile = !WriteToF76Custom ? IniFile.F76Custom : IniFile.Config;

            //this.logFile.WriteLine($"   Changing values in *.ini files...");
            this.logFile.WriteLine($"       writting to {IniFiles.Instance.GetIniName(iniFile)}");
            if (count > 0)
            {
                IniFiles.Instance.Set(iniFile, "Archive", key, value);
                this.logFile.WriteLine($"      {key}={value}");
            }
            else
            {
                IniFiles.Instance.Remove(iniFile, "Archive", key);
                this.logFile.WriteLine($"      {key} removed.");
            }
            IniFiles.Instance.Remove(otherIniFile, "Archive", key);
        }

        public void ResolveNWResourceLists()
        {
            SaveResourceList("sResourceIndexFileList", LoadResourceList("sResourceIndexFileList"));
            SaveResourceList("sResourceArchive2List", LoadResourceList("sResourceArchive2List"));
            CopyINILists();
        }

        public void RenameAddedDLLs()
        {
            // Iterate through every *.dll file in game path:
            IEnumerable<String> files = Directory.EnumerateFiles(Shared.GamePath, "*.dll");
            this.logFile.WriteLine($"Renaming \'*.dll\' files to \'*.dll.nwmode\'.");
            foreach (String filePath in files)
            {
                // If not whitelisted...
                String fileName = Path.GetFileName(filePath);
                if (!this.whitelistedDlls.Contains(fileName.ToLower()))
                {
                    // ... rename it:
                    if (!File.Exists(filePath + ".nwmode"))
                    {
                        File.Move(filePath, filePath + ".nwmode");
                        this.logFile.WriteLine($"   Renamed {fileName}");
                    }

                    // ... or delete it:
                    else
                    {
                        File.Delete(filePath);
                        this.logFile.WriteLine($"   Deleted {fileName}");
                    }
                }
            }
        }

        public void RestoreAddedDLLs()
        {
            // Iterate through every *.dll.nwmode file in game path:
            IEnumerable<String> files = Directory.EnumerateFiles(Shared.GamePath, "*.dll.nwmode");
            this.logFile.WriteLine($"Restoring \'*.dll.nwmode\' files to \'*.dll\'.");
            foreach (String filePath in files)
            {
                String fileName = Path.GetFileName(filePath);
                String originalFilePath = Path.Combine(Path.GetDirectoryName(filePath), fileName.Replace(".dll.nwmode", ".dll"));

                // Rename or delete, if the original exists:
                if (!File.Exists(originalFilePath))
                {
                    File.Move(filePath, originalFilePath);
                    this.logFile.WriteLine($"   Renamed {fileName}");
                }
                else
                {
                    // Assuming that the same *.dll file has been copied during deployment:
                    File.Delete(filePath); // we can just delete it.
                    this.logFile.WriteLine($"   Deleted {fileName}");
                }
            }
        }

        public void CopyINILists()
        {
            String suffix = ManagedMods.GetEditionSuffix(Shared.GameEdition);
            IniFiles.Instance.Set(IniFile.Config, "Mods", "sResourceIndexFileList" + suffix, String.Join(",", LoadResourceList("sResourceIndexFileList")));
            IniFiles.Instance.Set(IniFile.Config, "Mods", "sResourceArchive2List" + suffix, String.Join(",", LoadResourceList("sResourceArchive2List")));
            IniFiles.Instance.Set(IniFile.Config, "Mods", "sResourceDataDirsFinal" + suffix, String.Join(",", IniFiles.Instance.GetString(IniFile.F76Custom, "Archive", "sResourceDataDirsFinal", "")));
            IniFiles.Instance.SaveConfig();
        }

        public void LoadINILists()
        {
            String suffix = ManagedMods.GetEditionSuffix(Shared.GameEdition);
            List<String> sResourceIndexFileList = IniFiles.Instance.GetString(IniFile.Config, "Mods", "sResourceIndexFileList" + suffix, "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            List<String> sResourceArchive2List = IniFiles.Instance.GetString(IniFile.Config, "Mods", "sResourceArchive2List" + suffix, "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            String sResourceDataDirsFinal = IniFiles.Instance.GetString(IniFile.Config, "Mods", "sResourceDataDirsFinal" + suffix, "");

            if (sResourceIndexFileList.Count > 0 || IniFiles.Instance.Exists(IniFile.F76Custom, "Mods", "sResourceIndexFileList"))
                SaveResourceList("sResourceIndexFileList", sResourceIndexFileList);
                //IniFiles.Instance.Set(IniFile.F76Custom, "Archive", "sResourceIndexFileList", sResourceIndexFileList);
            if (sResourceArchive2List.Count > 0 || IniFiles.Instance.Exists(IniFile.F76Custom, "Mods", "sResourceArchive2List"))
                SaveResourceList("sResourceArchive2List", sResourceArchive2List);
                // IniFiles.Instance.Set(IniFile.F76Custom, "Archive", "sResourceArchive2List", sResourceArchive2List);
            if (sResourceDataDirsFinal.Length > 0 && this.WriteDataDirs || IniFiles.Instance.Exists(IniFile.F76Custom, "Mods", "sResourceDataDirsFinal"))
                IniFiles.Instance.Set(IniFile.F76Custom, "Archive", "sResourceDataDirsFinal", sResourceDataDirsFinal);

            /*if (IniFiles.Instance.GetString(IniFile.F76Custom, "Mods", "sResourceIndexFileList", "").Trim().Length == 0)
                IniFiles.Instance.Remove(IniFile.F76Custom, "Mods", "sResourceIndexFileList");
            if (IniFiles.Instance.GetString(IniFile.F76Custom, "Mods", "sResourceArchive2List", "").Trim().Length == 0)
                IniFiles.Instance.Remove(IniFile.F76Custom, "Mods", "sResourceArchive2List");*/
            if (IniFiles.Instance.GetString(IniFile.F76Custom, "Mods", "sResourceDataDirsFinal", "").Trim().Length == 0)
                IniFiles.Instance.Remove(IniFile.F76Custom, "Mods", "sResourceDataDirsFinal");
        }
    }
}
