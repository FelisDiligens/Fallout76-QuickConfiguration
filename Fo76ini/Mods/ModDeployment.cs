using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Mods
{
    public static class ModDeployment
    {
        // TODO: Disable mods checkbox
        // TODO: Frozen bundled archives

        public static void DeployAll (List<ManagedMod> mods, ResourceList resources)
        {
            // Check for conflicts:
            List<ModHelpers.Conflict> conflicts = ModHelpers.GetConflictingArchiveNames(mods);
            if (conflicts.Count > 0)
                throw new DeploymentFailedException("Conflicting archive names.");

            // Remove all currently deployed mods:
            ModDeployment.RemoveAll(mods, resources);

            // Deploy all mods:
            DeployArchiveList archives = new DeployArchiveList();
            foreach (ManagedMod mod in mods)
                ModDeployment.Deploy(mod, resources, archives);
            ModDeployment.PackBundledArchives(resources, archives);

            // TODO: RestoreAddedDLLs();
        }

        /// <summary>
        /// Used in the deployment chain to deploy a single mod.
        /// BundledBA2 method merely copies files into temporary folder for packing.
        /// </summary>
        private static void Deploy (ManagedMod mod, ResourceList resources, DeployArchiveList archives)
        {
            if (mod.CurrentDiskState.Enabled &&
                Directory.Exists(mod.GetManagedFolderPath()) &&
                !Utils.IsDirectoryEmpty(mod.GetManagedFolderPath()))
            {
                switch (mod.CurrentDiskState.Method)
                {
                    case ManagedMod.DiskState.DeploymentMethod.BundledBA2:
                        CopyFilesToTempSorted(mod, resources, archives);
                        mod.CurrentDiskState = mod.PendingDiskState.CreateDeepCopy();
                        break;
                    case ManagedMod.DiskState.DeploymentMethod.SeparateBA2:
                        DeploySeparateArchive(mod, resources);
                        break;
                    case ManagedMod.DiskState.DeploymentMethod.Loose:
                        DeployLooseFiles(mod);
                        break;
                }
            }
        }

        /// <summary>
        /// Used in the deployment chain to deploy a single mod with the Loose method.
        /// </summary>
        private static void DeployLooseFiles(ManagedMod mod)
        {
            mod.CurrentDiskState = mod.PendingDiskState.CreateDeepCopy();
            mod.CurrentDiskState.LooseFiles.Clear();

            // Iterate over each file in the managed folder ...
            foreach (string filePath in Directory.EnumerateFiles(mod.GetManagedFolderPath(), "*.*", SearchOption.AllDirectories))
            {
                // ... extract the relative path ...
                string relPath = Utils.MakeRelativePath(mod.GetManagedFolderPath(), filePath);
                mod.CurrentDiskState.LooseFiles.Add(relPath);

                // ... determine the full destination path ...
                string destinationPath = Path.Combine(Shared.GamePath, mod.PendingDiskState.RootFolder, relPath);
                FileInfo destInfo = new FileInfo(destinationPath);
                Directory.CreateDirectory(destInfo.DirectoryName);

                // ... make a backup if the file already exists ...
                if (File.Exists(destinationPath) && !File.Exists(destinationPath + ".old"))
                    File.Move(destinationPath, destinationPath + ".old");

                // ... and copy the file (and replace it if necessary).
                if (Configuration.bUseHardlinks)
                    Utils.CreateHardLink(filePath, destinationPath, true);
                else
                    File.Copy(filePath, destinationPath, true);
            }
        }

        /// <summary>
        /// Used in the deployment chain to deploy a single mod with the SeparateBA2 method.
        /// Freezes a mod if necessary.
        /// </summary>
        private static void DeploySeparateArchive(ManagedMod mod, ResourceList resources)
        {
            // If mod is supposed to be deployed frozen...
            if (mod.PendingDiskState.Frozen)
            {
                // ... freeze if necessary ...
                if (!mod.FrozenDiskState.Frozen)
                    ModActions.Freeze(mod);

                // ... and copy it to the Data folder.
                if (Configuration.bUseHardlinks)
                    Utils.CreateHardLink(
                        mod.FrozenDiskState.GetFrozenArchivePath(),
                        mod.PendingDiskState.GetArchivePath(),
                        true);
                else
                    File.Copy(
                        mod.FrozenDiskState.GetFrozenArchivePath(),
                        mod.PendingDiskState.GetArchivePath(),
                        true);
            }

            // If mod isn't supposed to be deployed frozen...
            else
            {
                // ... create a new archive ...
                Archive2.Create(
                    mod.PendingDiskState.GetArchivePath(),
                    mod.GetManagedFolderPath(),
                    ModHelpers.GetArchive2Preset(mod.PendingDiskState));

                // ... and delete the frozen archive if existing.
                if (mod.FrozenDiskState.Frozen)
                    File.Delete(mod.FrozenDiskState.GetFrozenArchivePath());
            }

            // Finally, update the disk state ...
            mod.CurrentDiskState = mod.PendingDiskState.CreateDeepCopy();
            mod.FrozenDiskState = mod.CurrentDiskState.CreateDeepCopy();

            // ... and add the archive to the resource list.
            resources.Add(mod.PendingDiskState.ArchiveName);
        }

        /// <summary>
        /// Used in the deployment chain to pack each bundled temporary folder to an archive.
        /// </summary>
        private static void PackBundledArchives(ResourceList resources, DeployArchiveList archives)
        {
            // For each archive...
            foreach (DeployArchive archive in archives)
            {
                // ... if needed ...
                if (archive.Count > 0 && !Utils.IsDirectoryEmpty(archive.TempPath))
                {
                    // ... pack the temporary folder to an archive ...
                    Archive2.Create(archive.GetArchivePath(), archive.TempPath, archive.Compression, archive.Format);

                    // ... and add it to the resource list.
                    resources.Insert(0, archive.ArchiveName);
                }
            }

            // Clean up after we're finished.
            archives.DeleteTempFolder();
        }

        /// <summary>
        /// Used in the deployment chain to copy individual files to a temporary folder.
        /// It sorts files into different temporary folders.
        /// Each temporary folder gets packed to a bundled *.ba2 archive.
        /// </summary>
        private static void CopyFilesToTempSorted(ManagedMod mod, ResourceList resources, DeployArchiveList archives)
        {
            // Iterate over each file in the managed folder:
            IEnumerable<string> files = Directory.EnumerateFiles(mod.GetManagedFolderPath(), "*.*", SearchOption.AllDirectories);
            foreach (string filePath in files)
            {
                FileInfo info = new FileInfo(filePath);
                string fileExtension = info.Extension.ToLower();

                // Make a relative path:
                string relativePath = Utils.MakeRelativePath(mod.GetManagedFolderPath(), filePath);

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

                if (Configuration.bUseHardlinks)
                    Utils.CreateHardLink(filePath, destinationPath, true);
                else
                    File.Copy(filePath, destinationPath, true);
            }
        }

        public static void RemoveAll (List<ManagedMod> mods, ResourceList resources)
        {
            // Delete bundled archives:
            DeployArchiveList deployArchives = new DeployArchiveList();
            foreach (DeployArchive deployArchive in deployArchives)
            {
                File.Delete(deployArchive.GetArchivePath());
                resources.Remove(deployArchive.ArchiveName);
            }

            // Remove mods:
            foreach (ManagedMod mod in mods)
                ModDeployment.Remove(mod, resources);

            // Save state:
            // ManagedMods.Instance.Save();
            // list.SaveTXT();
        }

        private static void Remove (ManagedMod mod, ResourceList resources)
        {
            if (mod.CurrentDiskState.Enabled)
            {
                switch (mod.CurrentDiskState.Method)
                {
                    case ManagedMod.DiskState.DeploymentMethod.BundledBA2:
                        break;

                    case ManagedMod.DiskState.DeploymentMethod.SeparateBA2:
                        File.Delete(mod.CurrentDiskState.GetArchivePath());
                        resources.Remove(mod.CurrentDiskState.ArchiveName);
                        break;

                    case ManagedMod.DiskState.DeploymentMethod.Loose:
                        foreach (string relFilePath in mod.CurrentDiskState.LooseFiles)
                        {
                            string installedFilePath = Path.GetFullPath(Path.Combine(Shared.GamePath, mod.CurrentDiskState.RootFolder, relFilePath)); // .Replace("\\.\\", "\\")

                            // Delete file, if existing:
                            File.Delete(installedFilePath);

                            // Rename backup, if there is one:
                            if (File.Exists(installedFilePath + ".old"))
                                File.Move(installedFilePath + ".old", installedFilePath);
                            
                            // Remove empty folders one by one, if existing:
                            else
                                RemoveEmptyFolders(Path.GetDirectoryName(installedFilePath));
                        }
                        break;
                }

                mod.CurrentDiskState.Enabled = false;
            }
        }

        private static void RemoveEmptyFolders (string parent)
        {
            while (Directory.Exists(parent) && Utils.IsDirectoryEmpty(parent))
            {
                Directory.Delete(parent);
                parent = Path.GetDirectoryName(parent);
            }
        }

        private class DeployArchiveList : IEnumerable<DeployArchive>
        {
            public DeployArchive GeneralArchive;
            public DeployArchive TexturesArchive;
            public DeployArchive SoundsArchive;

            public DeployArchiveList()
            {
                string tempPath = GetTempPath();

                GeneralArchive = new DeployArchive("General", tempPath);
                TexturesArchive = new DeployArchive("Textures", tempPath);
                TexturesArchive.Format = Archive2.Format.DDS;
                SoundsArchive = new DeployArchive("Sounds", tempPath);
                SoundsArchive.Compression = Archive2.Compression.None;
            }

            public void DeleteTempFolder()
            {
                if (Directory.Exists(GetTempPath()))
                    Directory.Delete(GetTempPath(), true);
            }

            public string GetTempPath()
            {
                return Path.Combine(Shared.GamePath, "tmp");
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
            public string TempPath;
            public string ArchiveName;
            public Archive2.Format Format = Archive2.Format.General;
            public Archive2.Compression Compression = Archive2.Compression.Default;
            public int Count = 0;

            public DeployArchive(string name, string tempFolderPath)
            {
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
                return Path.Combine(Shared.GamePath, "Data", this.ArchiveName);
            }

            public string GetFrozenArchivePath()
            {
                return Path.Combine(Shared.GamePath, "FrozenData", this.ArchiveName);
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
