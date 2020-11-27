using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fo76ini.Mods
{
    /// <summary>
    /// Bundles functions that change the state or the files of a mod, but don't affect game files.
    /// </summary>
    public static class ModActions
    {
        /// <summary>
        /// Deletes all files of 'mod'.
        /// This includes the managed folder and frozen archive.
        /// </summary>
        private static void DeleteFiles(ManagedMod mod)
        {
            // Delete managed folder:
            if (Directory.Exists(mod.ManagedFolderPath))
                Directory.Delete(mod.ManagedFolderPath, true);

            // Delete frozen archive:
            if (/*mod.Frozen &&
                mod.PreviousMethod == ManagedMod.DeploymentMethod.SeparateBA2 &&*/
                File.Exists(mod.FrozenArchivePath))
            {
                File.Delete(mod.FrozenArchivePath);
            }
        }

        /// <summary>
        /// Deletes all files of the mod and removes it from the list.
        /// Saves the xml file afterwards.
        /// </summary>
        public static void DeleteMod(ManagedMods mods, int index, Action<Progress> ProgressChanged = null)
        {
            ModActions.DeleteFiles(mods[index]);
            mods.RemoveAt(index);
            mods.Save();
            ProgressChanged?.Invoke(Progress.Done("Mod deleted."));
        }

        /// <summary>
        /// Deletes multiple mods and removes them from the list.
        /// Saves the xml file afterwards.
        /// </summary>
        public static void DeleteMods(ManagedMods mods, List<int> indices, Action<Progress> ProgressChanged = null)
        {
            indices = indices.OrderByDescending(i => i).ToList();
            int fi = 0;
            int count = indices.Count();
            foreach (int index in indices)
            {
                ProgressChanged?.Invoke(Progress.Ongoing($"Deleting mod {++fi} of {count}.", (float)(fi - 1) / (float)count));
                ModActions.DeleteFiles(mods[index]);
                mods.RemoveAt(index);
                mods.Save();
            }
            ProgressChanged?.Invoke(Progress.Done($"{count} mods deleted."));
        }

        /// <summary>
        /// Freezes the mod.
        /// </summary>
        public static void Freeze(ManagedMods mods, int index)
        {
            ModActions.Freeze(mods[index]);
            mods.Save();
        }

        /// <summary>
        /// Freezes the mods.
        /// </summary>
        public static void Freeze(ManagedMods mods, IEnumerable<int> indices)
        {
            foreach (int index in indices)
                ModActions.Freeze(mods[index]);
            mods.Save();
        }

        public static void Freeze(ManagedMod mod)
        {
            // TODO: Remove connection to ManagedMods
            // Only freeze if not already frozen:
            if (mod.Frozen && File.Exists(mod.FrozenArchivePath))
            {
                // TODO: ModActions.Freeze: Should the mod get "refrozen"?
                //ManagedMods.Instance.logFile.WriteLine($"Cannot freeze a mod ('{mod.Title}') that is already frozen.\n");
                return;
            }

            Directory.CreateDirectory(mod.FrozenDataPath);

            // Create archive:
            Archive2.Create(mod.FrozenArchivePath, mod.ManagedFolderPath, ModHelpers.GetArchive2Preset(mod));

            // Change DiskState and save:
            mod.Frozen = true;
            mod.FrozenCompression = mod.Compression;
            mod.FrozenFormat = mod.Format;
        }

        /// <summary>
        /// Unfreezes the mod.
        /// </summary>
        public static void Unfreeze(ManagedMods mods, int index, Action<Progress> ProgressChanged = null)
        {
            ModActions.Unfreeze(mods[index]);
            mods.Save();
            ProgressChanged?.Invoke(Progress.Done("Mod thawed."));
        }

        /// <summary>
        /// Unfreezes the mods.
        /// </summary>
        public static void Unfreeze(ManagedMods mods, IEnumerable<int> indices, Action<Progress> ProgressChanged = null)
        {
            int count = indices.Count();
            int n = 1;
            foreach (int index in indices)
            {
                ModActions.Unfreeze(mods[index]);
                ProgressChanged?.Invoke(Progress.Ongoing($"Unfreezing {n} of {count} mod(s)...", (float)n++ / (float)count));
            }
            mods.Save();
            ProgressChanged?.Invoke(Progress.Done($"{count} mod(s) thawed."));
        }

        public static void Unfreeze(ManagedMod mod)
        {
            // Delete *.ba2:
            if (File.Exists(mod.FrozenArchivePath))
                File.Delete(mod.FrozenArchivePath);

            // Change DiskState and save:
            mod.Frozen = false;
        }

        public static void ManipulateModFolder(ManagedMod mod, Action<Progress> ProgressChanged = null)
        {
            string managedFolderPath = mod.ManagedFolderPath;
            foreach (string path in Directory.EnumerateFiles(managedFolderPath))
            {
                // TODO: Install as frozen by default?
                // If a *.ba2 archive was found, extract it:
                if (path.EndsWith(".ba2"))
                {
                    try
                    {
                        ProgressChanged?.Invoke(Progress.Indetermined($"Extracting {Path.GetFileName(path)}"));
                        Archive2.Extract(path, managedFolderPath);
                        File.Delete(path);
                    }
                    catch (Archive2Exception ex) { }
                }
            }

            //String[] typicalFolders = new string[] { "meshes", "strings", "music", "sound", "textures", "materials", "interface", "geoexporter", "programs", "vis", "scripts", "misc", "shadersfx" };

            ProgressChanged?.Invoke(Progress.Indetermined("Cleaning mod folder up, detecting installation options."));

            // Do it two times, because it changes files, so we need to check again.
            for (int i = 0; i < 2; i++)
            {
                // Search through all folders in the mod folder.
                foreach (string path in Directory.GetDirectories(managedFolderPath))
                {
                    string name = Path.GetFileName(path).ToLower();

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
                        if (mod.Format != ManagedMod.ArchiveFormat.Auto)
                        {
                            mod.Format = ManagedMod.ArchiveFormat.Textures;
                            break;
                        }
                    }
                }
            }

            // Search through all files in the mod folder.
            foreach (string path in Directory.EnumerateFiles(managedFolderPath))
            {
                string name = Path.GetFileName(path).ToLower();
                string extension = Path.GetExtension(path).ToLower();

                // If the mod contains *.dll files...
                if (extension == ".dll")
                {
                    // ... then it probably has to be installed as loose files into the root directory:
                    mod.Method = ManagedMod.DeploymentMethod.Loose;
                    mod.RootFolder = ".";
                }
            }

            ProgressChanged?.Invoke(Progress.Done("Extracting finished."));
        }
    }
}
