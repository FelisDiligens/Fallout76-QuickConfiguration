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
            Utils.DeleteDirectory(mod.ManagedFolderPath);

            // Delete frozen archive:
            Utils.DeleteFile(mod.FrozenArchivePath);
        }

        /// <summary>
        /// Deletes all files of the mod and removes it from the list.
        /// Saves the xml file afterwards.
        /// </summary>
        public static void DeleteMod(ManagedMods mods, int index, Action<Progress> ProgressChanged = null)
        {
            ModDeployment.Remove(mods[index], mods.Resources, mods.GamePath);
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
                ModActions.DeleteMod(mods, index);
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

            // Getting preset:
            Archive2.Preset preset = ModHelpers.GetArchive2Preset(mod);

            ModDeployment.LogFile.WriteLine($"      Freezing mod '{mod.Title}'...");
            ModDeployment.LogFile.WriteLine($"         Format:      {preset.format}");
            ModDeployment.LogFile.WriteLine($"         Compression: {preset.compression}");
            ModDeployment.LogFile.WriteLine($"         Destination: FrozenData\\{mod.FrozenArchiveName}");

            // Create archive:
            Archive2.Create(mod.FrozenArchivePath, mod.ManagedFolderPath, preset);

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

        /// <summary>
        /// Renames the managed folder.
        /// </summary>
        /// <param name="mod"></param>
        /// <param name="newFolderName"></param>
        /// <returns>True if successful, False otherwise</returns>
        public static bool RenameFolder(ManagedMod mod, string newFolderName)
        {
            // Don't rename if folder name is equal:
            if (mod.ManagedFolderName == newFolderName)
                return false;

            // Don't rename if folder name is invalid:
            if (!Utils.IsFileNameValid(newFolderName))
                return false;

            // Don't rename if folder already exists:
            string newFolderPath = Path.Combine(mod.GamePath, "Mods", newFolderName);
            if (Directory.Exists(newFolderPath))
                return false;

            // Try to rename folder:
            try
            {
                Directory.Move(mod.ManagedFolderPath, newFolderPath);
            }
            catch
            {
                return false;
            }

            // Successful?
            mod.ManagedFolderName = newFolderName;
            return true;
        }

        public static void DetectOptimalModInstallationOptions(ManagedMod mod, Action<Progress> ProgressChanged = null)
        {
            ProgressChanged?.Invoke(Progress.Indetermined("Detecting installation options."));

            /*
             * Searching through folder:
             */

            bool resourceFoldersFound = false;
            bool generalFoldersFound = false;
            bool texturesFolderFound = false;
            bool soundFoldersFound = false;
            bool stringsFolderFound = false;
            bool dataFolderFound = false;
            bool videoFolderFound = false;
            bool dllFound = false;

            foreach (string folderPath in Directory.EnumerateDirectories(mod.ManagedFolderPath))
            {
                string folderName = Path.GetFileName(folderPath).ToLower();

                if (ModHelpers.ResourceFolders.Contains(folderName))
                    resourceFoldersFound = true;
                if (ModHelpers.GeneralFolders.Contains(folderName))
                    generalFoldersFound = true;
                if (ModHelpers.TextureFolders.Contains(folderName))
                    texturesFolderFound = true;
                if (ModHelpers.SoundFolders.Contains(folderName))
                    soundFoldersFound = true;
                if (folderName == "strings")
                    stringsFolderFound = true;
                if (folderName == "data")
                    dataFolderFound = true;
                if (folderName == "video")
                    videoFolderFound = true;
            }

            foreach (string filePath in Directory.EnumerateFiles(mod.ManagedFolderPath))
            {
                string fileExtension = Path.GetExtension(filePath).ToLower();

                if (fileExtension == ".dll")
                    dllFound = true;
            }


            /*
             * Detecting optimal installation options:
             */

            if (resourceFoldersFound)
            {
                mod.Method = ManagedMod.DeploymentMethod.SeparateBA2;
                mod.Format = ManagedMod.ArchiveFormat.Auto;
                mod.Compression = ManagedMod.ArchiveCompression.Auto;
                mod.RootFolder = "Data";
            }

            if (stringsFolderFound || videoFolderFound)
            {
                mod.Method = ManagedMod.DeploymentMethod.LooseFiles;
                mod.RootFolder = "Data";
            }

            if (dllFound || dataFolderFound)
            {
                mod.Method = ManagedMod.DeploymentMethod.LooseFiles;
                mod.RootFolder = ".";
            }

            if (generalFoldersFound)
            {
                mod.Method = ManagedMod.DeploymentMethod.SeparateBA2;
                mod.Format = ManagedMod.ArchiveFormat.General;
                mod.Compression = ManagedMod.ArchiveCompression.Compressed;
                mod.RootFolder = "Data";
            }

            if (texturesFolderFound)
            {
                mod.Method = ManagedMod.DeploymentMethod.SeparateBA2;
                mod.Format = ManagedMod.ArchiveFormat.Textures;
                mod.Compression = ManagedMod.ArchiveCompression.Compressed;
                mod.RootFolder = "Data";
            }

            if (soundFoldersFound)
            {
                mod.Method = ManagedMod.DeploymentMethod.SeparateBA2;
                mod.Format = ManagedMod.ArchiveFormat.General;
                mod.Compression = ManagedMod.ArchiveCompression.Uncompressed;
                mod.RootFolder = "Data";
            }

            if (generalFoldersFound && texturesFolderFound ||
                generalFoldersFound && soundFoldersFound   ||
                texturesFolderFound && soundFoldersFound)
            {
                mod.Method = ManagedMod.DeploymentMethod.BundledBA2;
                mod.Format = ManagedMod.ArchiveFormat.Auto;
                mod.Compression = ManagedMod.ArchiveCompression.Auto;
                mod.RootFolder = "Data";
            }
        }

        public static void CleanUpFolder(string folderPath, Action<Progress> ProgressChanged = null)
        {
            ProgressChanged?.Invoke(Progress.Indetermined("Cleaning up mod folder."));

            foreach (string subFolderPath in Directory.EnumerateDirectories(folderPath))
            {
                string subFolderName = Path.GetFileName(subFolderPath).ToLower();

                // Move data folder one up:
                if (subFolderName == "data")
                    ModInstallations.MoveDirectory(subFolderPath, folderPath);
            }

            foreach (String filePath in Directory.EnumerateFiles(folderPath))
            {
                string fileExtension = Path.GetExtension(filePath).ToLower().Trim();

                // Extract archives within folder:
                if (fileExtension == ".ba2" || SevenZip.SupportedFileTypes.Contains(fileExtension))
                {
                    ModInstallations.ExtractArchive(filePath, folderPath, ProgressChanged);
                    File.Delete(filePath);
                }

                // Delete crap:
                else if (fileExtension == ".txt")
                    File.Delete(filePath);
            }
        }
    }
}
