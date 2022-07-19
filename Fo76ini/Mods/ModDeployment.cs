using Fo76ini.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fo76ini.Mods
{
    /// <summary>
    /// Bundles functions that add, remove, or change game files.
    /// Managed mods --> Game files
    /// </summary>
    public static class ModDeployment
    {
        // TODO: Clean FrozenData?
        public static TextWriter LogFile;
        public static string LogFilePath;

        public enum BundledLoadOrder
        {
            PutFirst = 0,
            PutLast = 1
        }

        static ModDeployment()
        {
            ModDeployment.LogFilePath = Log.GetFilePath("modmanager.log.txt");
            ModDeployment.LogFile = Log.Open(LogFilePath);

#if DEBUG
            ModDeployment.LogFile = Console.Out;
#endif
        }

        public static void Deploy(ManagedMods mods, Action<Progress> ProgressChanged, bool invalidateBundledFrozenArchives = true)
        {
            LogFile.WriteLine("\n\n");
            LogFile.WriteLine(Log.GetTimeStamp());
            LogFile.WriteLine($"Version {Shared.VERSION}, deploying...");
            LogFile.WriteLine($"Game path: {mods.GamePath}");

            // TODO: More descriptive ProgressChanged
            ProgressChanged?.Invoke(Progress.Indetermined("Deploying..."));

            // Check for conflicts:
            LogFile.WriteLine("Checking for conflicting archive names...");
            List<ModHelpers.Conflict> conflicts = ModHelpers.GetConflictingArchiveNames(mods.Mods);
            if (conflicts.Count > 0)
            {
                LogFile.WriteLine("Conflicts found, abort.");
                foreach (ModHelpers.Conflict conflict in conflicts)
                    LogFile.WriteLine($"   Conflict: {conflict.conflictText}");
                throw new DeploymentFailedException("Conflicting archive names.");
            }

            // Restore *.dll files:
            RestoreAddedDLLs(mods.GamePath);

            // Remove all currently deployed mods:
            ProgressChanged?.Invoke(Progress.Indetermined("Removing mods..."));
            ModDeployment.RemoveAll(mods);
            mods.Save();

            // If mods are enabled:
            if (!mods.ModsDisabled)
            {
                LogFile.WriteLine("Installing mods...");

                // Deploy all SeparateBA2 and Loose mods:
                int counter = 0;
                int enabledMods = mods.EnabledCount;
                foreach (ManagedMod mod in mods)
                {
                    if (mod.Enabled &&
                        Directory.Exists(mod.ManagedFolderPath) &&
                        !Utils.IsDirectoryEmpty(mod.ManagedFolderPath))
                    {
                        ProgressChanged?.Invoke(Progress.Ongoing($"Installing mod: {++counter} of {enabledMods} - {mod.Title}...", (float)(counter) / (float)enabledMods));
                        switch (mod.Method)
                        {
                            case ManagedMod.DeploymentMethod.SeparateBA2:
                                ProgressChanged?.Invoke(Progress.Ongoing($"Creating archive: {counter} of {enabledMods} - {mod.Title}...", (float)(counter) / (float)enabledMods));
                                DeploySeparateArchive(mod, mods.Resources);
                                mods.Save();
                                break;
                            case ManagedMod.DeploymentMethod.LooseFiles:
                                ProgressChanged?.Invoke(Progress.Ongoing($"Copying files: {counter} of {enabledMods} - {mod.Title}...", (float)(counter) / (float)enabledMods));
                                DeployLooseFiles(mods, mod, mods.GamePath);
                                mods.Save();
                                break;
                        }
                    }
                }

                // Deploy all BundledBA2 mods:
                ProgressChanged?.Invoke(Progress.Indetermined($"Building bundled archives..."));
                ModDeployment.DeployBundledArchives(mods, Configuration.Mods.FreezeBundledArchives, invalidateBundledFrozenArchives);

                mods.Save();
                ProgressChanged?.Invoke(Progress.Done("Mods deployed."));
            }
            else
                ProgressChanged?.Invoke(Progress.Done("Mods removed."));

            LogFile.WriteLine("Deployment finished.");
            LogFile.WriteLine($"Resource list ({mods.Resources.Count} files): \"{mods.Resources}\"");
            LogFile.Flush();
        }

        /// <summary>
        /// Used in the deployment chain to deploy a single mod with the Loose method.
        /// </summary>
        private static void DeployLooseFiles(ManagedMods mods, ManagedMod mod, String GamePath)
        {
            LogFile.WriteLine($"   Installing mod '{mod.Title}' as LooseFiles");

            mod.LooseFiles.Clear();

            // Iterate over each file in the managed folder ...
            foreach (string filePath in Directory.EnumerateFiles(mod.ManagedFolderPath, "*.*", SearchOption.AllDirectories))
            {
                // ... extract the relative path ...
                string relPath = Utils.MakeRelativePath(mod.ManagedFolderPath, filePath);
                mod.LooseFiles.Add(relPath);

                // ... determine the full destination path ...
                string destinationPath = Path.Combine(GamePath, mod.RootFolder, relPath);
                FileInfo destInfo = new FileInfo(destinationPath);
                Directory.CreateDirectory(destInfo.DirectoryName);

                // ... make a backup if the file already exists ...
                if (File.Exists(destinationPath) && !DoesLooseFileBelongToMod(mods, destinationPath) && !File.Exists(destinationPath + ".old"))
                    File.Move(destinationPath, destinationPath + ".old");

                // ... and copy the file (and replace it if necessary).
                LogFile.WriteLine($"      Copying: \"{relPath}\"");
                CopyFileOrMakeLink(filePath, destinationPath, true);
            }

            mod.CurrentRootFolder = mod.RootFolder;
            mod.Deployed = true;
            mod.PreviousMethod = ManagedMod.DeploymentMethod.LooseFiles;
        }

        /// <summary>
        /// Used in the deployment chain to deploy a single mod with the SeparateBA2 method.
        /// Freezes a mod if necessary.
        /// </summary>
        private static void DeploySeparateArchive(ManagedMod mod, ResourceList resources)
        {
            LogFile.WriteLine($"   Installing mod '{mod.Title}' as SeparateBA2");

            // If mod is supposed to be deployed frozen...
            if (mod.Freeze)
            {
                // ... freeze if necessary ...
                if (!mod.Frozen)
                {
                    //LogFile.WriteLine($"      Freezing mod...");
                    ModActions.Freeze(mod);
                }

                LogFile.WriteLine($"      Copying frozen archive...");

                // ... and copy it to the Data folder.
                CopyFileOrMakeLink(
                    mod.FrozenArchivePath,
                    mod.ArchivePath,
                    true);
            }

            // If mod isn't supposed to be deployed frozen...
            else
            {
                // ... unfreeze mod if needed ...
                if (mod.Frozen)
                {
                    LogFile.WriteLine($"      Unfreezing mod...");
                    ModActions.Unfreeze(mod);
                }

                // Getting preset:
                Archive2.Preset preset = ModHelpers.GetArchive2Preset(mod);

                LogFile.WriteLine($"      Creating new archive...");
                LogFile.WriteLine($"         Format:      {preset.format}");
                LogFile.WriteLine($"         Compression: {preset.compression}");

                // ... and create a new archive.
                Archive2.Create(
                    mod.ArchivePath,
                    mod.ManagedFolderPath,
                    preset);
            }

            // Finally, update the disk state ...
            mod.CurrentArchiveName = mod.ArchiveName;
            mod.CurrentCompression = mod.Frozen ? mod.FrozenCompression : mod.Compression;
            mod.CurrentFormat = mod.Frozen ? mod.FrozenFormat : mod.Format;
            mod.Deployed = true;
            mod.PreviousMethod = ManagedMod.DeploymentMethod.SeparateBA2;

            // ... and add the archive to the resource list.
            resources.Add(mod.ArchiveName);

            LogFile.WriteLine($"      Installed.");
        }

        /// <summary>
        /// Used in the deployment chain to deploy mods with the BundledBA2 method.
        /// </summary>
        private static void DeployBundledArchives(ManagedMods mods, bool freezeArchives = false, bool invalidateFrozenArchives = true)
        {
            LogFile.WriteLine($"   Installing BundledBA2 mods...");
            DeployArchiveList archives = new DeployArchiveList(mods.GamePath);

            // We want to use frozen archives but haven't invalidated them...
            // ... so just copy bundled archives if available:
            if (freezeArchives && !invalidateFrozenArchives)
            {
                CopyFrozenBundledArchives(mods.Resources, archives);
                return;
            }

            // Otherwise iterate over each enabled mod...
            foreach (ManagedMod mod in mods)
            {
                if (mod.Enabled && mod.Method == ManagedMod.DeploymentMethod.BundledBA2)
                {
                    LogFile.WriteLine($"      Copy files of mod '{mod.Title}' to temp folder...");

                    // ... copy it's files into temporary folders ...
                    CopyFilesToTempSorted(mod, archives);
                    mod.Deployed = true;
                    mod.PreviousMethod = ManagedMod.DeploymentMethod.BundledBA2;
                }
            }

            // ... and pack those folders to archives.
            PackBundledArchives(mods.Resources, archives, freezeArchives);
        }

        /// <summary>
        /// Used in the deployment chain to copy frozen bundled archives from FrozenData to Data.
        /// </summary>
        private static void CopyFrozenBundledArchives(ResourceList resources, DeployArchiveList archives)
        {
            LogFile.WriteLine($"      Copy frozen bundled archives...");

            // For each archive...
            foreach (DeployArchive archive in
                // (reverse order of archives if we put them at the beginning of the load order)
                (Configuration.Mods.BundledLoadOrder == BundledLoadOrder.PutFirst ? archives.Reverse() : archives))
            {
                // ... if it had been frozen ...
                if (File.Exists(archive.GetFrozenArchivePath()))
                {
                    LogFile.WriteLine($"         Copying {archive.ArchiveName}");

                    // ... copy it into the Data folder ...
                    CopyFileOrMakeLink(
                        archive.GetFrozenArchivePath(),
                        archive.GetArchivePath(),
                        true);

                    // ... and add it to the resource list.
                    switch (Configuration.Mods.BundledLoadOrder)
                    {
                        case BundledLoadOrder.PutFirst:
                            resources.Insert(0, archive.ArchiveName);
                            break;
                        case BundledLoadOrder.PutLast:
                            resources.Add(archive.ArchiveName);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Used in the deployment chain to pack each bundled temporary folder to an archive.
        /// </summary>
        private static void PackBundledArchives(ResourceList resources, DeployArchiveList archives, bool freezeArchives)
        {
            // For each archive...
            foreach (DeployArchive archive in
                // (reverse order of archives if we put them at the beginning of the load order)
                (Configuration.Mods.BundledLoadOrder == BundledLoadOrder.PutFirst ? archives.Reverse() : archives))
            {
                // ... if needed ...
                if (archive.Count > 0 && !Utils.IsDirectoryEmpty(archive.TempPath))
                {
                    // ... pack the temporary folder to an archive ...
                    if (freezeArchives)
                    {
                        LogFile.WriteLine($"      Freezing archive '{archive.ArchiveName}'");

                        // either freeze to FrozenData and then copy to Data:
                        Archive2.Create(archive.GetFrozenArchivePath(), archive.TempPath, archive.Compression, archive.Format);

                        CopyFileOrMakeLink(
                            archive.GetFrozenArchivePath(),
                            archive.GetArchivePath(),
                            true);
                    }
                    else
                    {
                        LogFile.WriteLine($"      Creating archive '{archive.ArchiveName}'");

                        // or create directly in Data:
                        Archive2.Create(archive.GetArchivePath(), archive.TempPath, archive.Compression, archive.Format);
                    }

                    // ... and add it to the resource list.
                    switch (Configuration.Mods.BundledLoadOrder)
                    {
                        case BundledLoadOrder.PutFirst:
                            resources.Insert(0, archive.ArchiveName);
                            break;
                        case BundledLoadOrder.PutLast:
                            resources.Add(archive.ArchiveName);
                            break;
                    }
                }
            }

            // Clean up after we're finished.
            LogFile.WriteLine($"      Deleting temporary folder...");
            archives.DeleteTempFolder();
        }

        /// <summary>
        /// Used in the deployment chain to copy individual files to a temporary folder.
        /// It sorts files into different temporary folders.
        /// Each temporary folder gets packed to a bundled *.ba2 archive.
        /// </summary>
        private static void CopyFilesToTempSorted(ManagedMod mod, DeployArchiveList archives)
        {
            // Iterate over each file in the managed folder:
            IEnumerable<string> files = Directory.EnumerateFiles(mod.ManagedFolderPath, "*.*", SearchOption.AllDirectories);
            foreach (string filePath in files)
            {
                FileInfo info = new FileInfo(filePath);
                string fileExtension = info.Extension.ToLower();

                // Make a relative path:
                string relativePath = Utils.MakeRelativePath(mod.ManagedFolderPath, filePath);

                // Determine the type of archive:
                string destinationPath;
                if (relativePath.Trim().ToLower().StartsWith("sound") || relativePath.Trim().ToLower().StartsWith("music") ||
                    (new string[] { ".wav", ".xwm", ".fuz", ".lip" }).Contains(fileExtension))
                {
                    archives.SoundsArchive.Count++;
                    destinationPath = Path.Combine(archives.SoundsArchive.TempPath, relativePath);
                }
                else if (fileExtension == ".dds")
                {
                    archives.TexturesArchive.Count++;
                    destinationPath = Path.Combine(archives.TexturesArchive.TempPath, relativePath);
                }
                else
                {
                    archives.GeneralArchive.Count++;
                    destinationPath = Path.Combine(archives.GeneralArchive.TempPath, relativePath);
                }

                // Copy the file to the correct temp folder:
                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                // Archive2 doesn't like symlinks apparently,
                // so only copy or create hardlink:
                CopyFileOrMakeHardLink(filePath, destinationPath, true);
            }
        }

        public static void RemoveAll(ManagedMods mods)
        {
            LogFile.WriteLine("Removing all installed mods");

            // Delete bundled archives:
            DeployArchiveList deployArchives = new DeployArchiveList(mods.GamePath);
            foreach (DeployArchive deployArchive in deployArchives)
            {
                LogFile.WriteLine($"   Removing {deployArchive.ArchiveName}");
                if (File.Exists(deployArchive.GetArchivePath()))
                    File.Delete(deployArchive.GetArchivePath());
                mods.Resources.Remove(deployArchive.ArchiveName);
            }
            LogFile.WriteLine($"   Deleting temporary folders");
            deployArchives.DeleteTempFolder();

            // Remove mods:
            foreach (ManagedMod mod in mods)
            {
                LogFile.WriteLine($"   Removing mod {mod.Title}");
                ModDeployment.Remove(mod, mods.Resources, mods.GamePath);
            }

            mods.Save();
            LogFile.Flush();
        }

        public static void Remove(ManagedMod mod, ResourceList resources, String GamePath)
        {
            if (mod.Deployed)
            {
                switch (mod.PreviousMethod)
                {
                    case ManagedMod.DeploymentMethod.BundledBA2:
                        LogFile.WriteLine($"      Skipped (mod is bundled)");
                        break;

                    case ManagedMod.DeploymentMethod.SeparateBA2:
                        LogFile.WriteLine($"      Deleting {mod.CurrentArchiveName}");
                        File.Delete(mod.CurrentArchivePath);
                        resources.Remove(mod.CurrentArchiveName);
                        break;

                    case ManagedMod.DeploymentMethod.LooseFiles:
                        LogFile.WriteLine($"      Deleting loose files");
                        foreach (string relFilePath in mod.LooseFiles)
                        {
                            string installedFilePath = Path.GetFullPath(Path.Combine(GamePath, mod.CurrentRootFolder, relFilePath)); // .Replace("\\.\\", "\\")

                            // Delete file, if existing:
                            if (File.Exists(installedFilePath))
                                File.Delete(installedFilePath);

                            // Rename backup, if there is one:
                            if (File.Exists(installedFilePath + ".old"))
                                File.Move(installedFilePath + ".old", installedFilePath);

                            // Remove empty folders one by one, if existing:
                            else
                                RemoveEmptyFolders(Path.GetDirectoryName(installedFilePath));
                        }
                        mod.LooseFiles.Clear();
                        break;
                }

                mod.Deployed = false;
            }
        }

        // Use lower-case, plz
        private static List<string> whitelistedDlls = new List<string>() {
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

        public static void RenameAddedDLLs(string GamePath)
        {
            LogFile.WriteLine("Renaming non-whitelisted *.dll to *.dll.nwmode");
            // Iterate through every *.dll file in game path:
            IEnumerable<string> files = Directory.EnumerateFiles(GamePath, "*.dll");
            foreach (string filePath in files)
            {
                // If not whitelisted...
                string fileName = Path.GetFileName(filePath);
                if (!whitelistedDlls.Contains(fileName.ToLower()))
                {
                    // ... rename it:
                    if (!File.Exists(filePath + ".nwmode"))
                    {
                        File.Move(filePath, filePath + ".nwmode");
                        LogFile.WriteLine($"   Renamed {fileName}");
                    }

                    // ... or delete it:
                    else
                    {
                        File.Delete(filePath);
                        LogFile.WriteLine($"   Deleted {fileName}");
                    }
                }
            }
        }

        public static void RestoreAddedDLLs(string GamePath)
        {
            LogFile.WriteLine("Renaming *.dll.nwmode to *.dll");
            // Iterate through every *.dll.nwmode file in game path:
            IEnumerable<string> files = Directory.EnumerateFiles(GamePath, "*.dll.nwmode");
            foreach (string filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                string originalFilePath = Path.Combine(Path.GetDirectoryName(filePath), fileName.Replace(".dll.nwmode", ".dll"));

                // Rename or delete, if the original exists:
                if (!File.Exists(originalFilePath))
                {
                    File.Move(filePath, originalFilePath);
                    LogFile.WriteLine($"   Renamed {fileName}");
                }
                else
                {
                    // Assuming that the same *.dll file has been copied during deployment:
                    File.Delete(filePath); // we can just delete it.
                    LogFile.WriteLine($"   Deleted {fileName}");
                }
            }
        }

        private static void RemoveEmptyFolders(string parent)
        {
            while (Directory.Exists(parent) && Utils.IsDirectoryEmpty(parent))
            {
                Directory.Delete(parent);
                parent = Path.GetDirectoryName(parent);
            }
        }

        /// <summary>
        /// Copy a file or create a hard link to that file.
        /// Symbolic links will not be created.
        /// </summary>
        private static void CopyFileOrMakeHardLink(string filePath, string destinationPath, bool overwrite)
        {
            if (Configuration.Mods.UseHardlinks)
                Utils.CreateHardLink(filePath, destinationPath, overwrite);
            else
                File.Copy(filePath, destinationPath, overwrite);
        }

        /// <summary>
        /// Copy a file or create a (hard or sym) link to that file.
        /// </summary>
        private static void CopyFileOrMakeLink(string filePath, string destinationPath, bool overwrite)
        {
            if (Configuration.Mods.UseHardlinks)
                Utils.CreateHardLink(filePath, destinationPath, overwrite);
            else if (Configuration.Mods.UseSymlinks && Utils.HasAdminRights())
                Utils.CreateSymbolicLink(filePath, destinationPath, overwrite);
            else
                File.Copy(filePath, destinationPath, overwrite);
        }

        /// <summary>
        /// Searches through each mod.LooseFiles entry to find if the file belongs to a mod.
        /// </summary>
        /// <param name="mods"></param>
        /// <param name="fullPath">Has to be a full path, not a relative path</param>
        /// <returns>true, if a mod has installed this file. false otherwise.</returns>
        private static bool DoesLooseFileBelongToMod(ManagedMods mods, string fullPath)
        {
            foreach (ManagedMod mod in mods)
            {
                if (mod.PreviousMethod == ManagedMod.DeploymentMethod.LooseFiles)
                {
                    foreach (string relPath in mod.LooseFiles)
                    {
                        string installedPath = Path.Combine(mods.GamePath, mod.RootFolder, relPath);
                        if (installedPath == fullPath)
                            return true;
                    }
                }
            }
            return false;
        }

        private class DeployArchiveList : IEnumerable<DeployArchive>
        {
            public DeployArchive GeneralArchive;
            public DeployArchive TexturesArchive;
            public DeployArchive SoundsArchive;

            public string GamePath;
            public string TempPath;

            public DeployArchiveList(String gamePath)
            {
                this.GamePath = gamePath;
                this.TempPath = Path.Combine(GamePath, "tmp");

                GeneralArchive = new DeployArchive("General", GamePath, TempPath);
                TexturesArchive = new DeployArchive("Textures", GamePath, TempPath);
                TexturesArchive.Format = Archive2.Format.DDS;
                SoundsArchive = new DeployArchive("Sounds", GamePath, TempPath);
                SoundsArchive.Compression = Archive2.Compression.None;
            }

            public void DeleteTempFolder()
            {
                Utils.DeleteDirectory(TempPath);
            }

            public List<DeployArchive> GetList()
            {
                return new List<DeployArchive>() { GeneralArchive, TexturesArchive, SoundsArchive };
            }

            public IEnumerator<DeployArchive> GetEnumerator()
            {
                return this.GetList().GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        private class DeployArchive
        {
            public string GamePath;
            public string TempPath;
            public string ArchiveName;
            public Archive2.Format Format = Archive2.Format.General;
            public Archive2.Compression Compression = Archive2.Compression.Default;
            public int Count = 0;

            public DeployArchive(string name, string gamePath, string tempFolderPath)
            {
                this.GamePath = gamePath;
                this.TempPath = Path.Combine(tempFolderPath, name);
                if (name == "General")
                    this.ArchiveName = "Bundled.ba2";
                else
                    this.ArchiveName = "Bundled - " + name + ".ba2";

                /*if (Directory.Exists(this.tempPath))
                    Directory.Delete(this.tempPath, true);*/
                Directory.CreateDirectory(this.TempPath);
            }

            public string GetArchivePath()
            {
                return Path.Combine(GamePath, "Data", this.ArchiveName);
            }

            public string GetFrozenArchivePath()
            {
                return Path.Combine(GamePath, "FrozenData", this.ArchiveName);
            }
        }

        public class DeploymentFailedException : Exception
        {
            public DeploymentFailedException() { }
            public DeploymentFailedException(string message) : base(message) { }
            public DeploymentFailedException(string message, Exception inner) : base(message, inner) { }
        }
    }
}
