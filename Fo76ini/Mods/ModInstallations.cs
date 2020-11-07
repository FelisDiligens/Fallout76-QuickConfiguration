using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Mods
{
    /// <summary>
    /// Bundles methods that handle the installation and import of mods.
    /// </summary>
    public static class ModInstallations
    {
        /// <summary>
        /// Creates a new mod from any supported archive. (zip, tar, rar, 7z, ba2)
        /// BA2 files can be installed frozen if needed.
        /// </summary>
        /// <param name="filePath">Path to archive</param>
        /// <param name="useSourceBA2Archive">When false, creates a new "frozen" mod.</param>
        /// <returns></returns>
        public static ManagedMod FromArchive(string filePath, bool useSourceBA2Archive = false)
        {
            // Get path information:
            filePath = EnsureLongPathSupport(filePath);
            string fileNameWOEx = Path.GetFileNameWithoutExtension(filePath);
            string fileExtension = Path.GetExtension(filePath);

            // Install mod:
            ManagedMod mod = new ManagedMod();
            mod.Title = fileNameWOEx;
            mod.PendingDiskState.ArchiveName = fileNameWOEx + ".ba2";

            // Extract mod:
            ModHelpers.ExtractArchive(filePath, mod.GetManagedFolderPath());
            // ManipulateModFolder(mod, managedFolderPath, updateProgress);

            // Freeze mod conditionally:
            if (useSourceBA2Archive && fileExtension == ".ba2")
            {
                mod.CurrentDiskState.Frozen = true;
                mod.CurrentDiskState.Method = ManagedMod.DiskState.DeploymentMethod.SeparateBA2;
                mod.FrozenDiskState = mod.CurrentDiskState.CreateDeepCopy();
                mod.PendingDiskState = mod.CurrentDiskState.CreateDeepCopy();

                // Copy *.ba2 into FrozenData:
                FileInfo frozenPath = new FileInfo(mod.FrozenDiskState.GetFrozenArchivePath());
                Directory.CreateDirectory(frozenPath.DirectoryName);
                File.Copy(filePath, frozenPath.FullName, true);
            }

            return mod;
        }

        /// <summary>
        /// Creates a new mod from a folder.
        /// </summary>
        /// <param name="folderPath">Path to folder</param>
        /// <returns></returns>
        public static ManagedMod FromFolder(string folderPath)
        {
            // Get path information:
            folderPath = EnsureLongPathSupport(folderPath);
            string folderName = Path.GetFileName(folderPath);

            // Install mod:
            ManagedMod mod = new ManagedMod();
            mod.Title = folderName;
            mod.PendingDiskState.ArchiveName = folderName + ".ba2";

            // Copy folder:
            CopyDirectory(folderPath, mod.GetManagedFolderPath());

            // ManipulateModFolder(mod, managedFolderPath, updateProgress);

            return mod;
        }

        /// <summary>
        /// Recursively copy every file and subdirectory to a new destination.
        /// </summary>
        /// <param name="sourcePath">Path *from* where we copy files.</param>
        /// <param name="destinationPath">Path *to* where we copy files.</param>
        public static void CopyDirectory(string sourcePath, string destinationPath)
        {
            DirectoryInfo dir = new DirectoryInfo(sourcePath);

            Directory.CreateDirectory(destinationPath);

            foreach (FileInfo file in dir.GetFiles())
                file.CopyTo(Path.Combine(destinationPath, file.Name), true);

            foreach (DirectoryInfo subdir in dir.GetDirectories())
                CopyDirectory(subdir.FullName, Path.Combine(destinationPath, subdir.Name));
        }

        /// <summary>
        /// If a path exceeds the 259 character limit, all io methods stop working.
        /// Adding @"\\?\" to the beginning of a path works around this issue.
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns>The file path with an added @"\\?\" at the beginning if needed.</returns>
        private static string EnsureLongPathSupport(string filePath)
        {
            if (!File.Exists(filePath))
            {
                // Path too long?
                // https://stackoverflow.com/questions/5188527/how-to-deal-with-files-with-a-name-longer-than-259-characters
                // https://docs.microsoft.com/de-de/archive/blogs/jeremykuhne/more-on-new-net-path-handling
                if (File.Exists(@"\\?\" + filePath))
                {
                    filePath = @"\\?\" + filePath;
                }
            }
            return filePath;
        }
    }
}
