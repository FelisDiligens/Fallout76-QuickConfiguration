using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fo76ini.Mods
{
    /// <summary>
    /// Bundles methods that handle the installation and import of mods.
    /// External files --> Managed mods
    /// </summary>
    public static class ModInstallations
    {
        /// <summary>
        /// Extracts the archive and adds the mod to the list.
        /// Saves the xml file afterwards.
        /// </summary>
        public static void InstallArchive(ManagedMods mods, string filePath, bool useSourceBA2Archive)
        {
            ManagedMod newMod = ModInstallations.FromArchive(filePath, useSourceBA2Archive);
            mods.Add(newMod);
            //mods.Save();
        }

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
            mod.ArchiveName = fileNameWOEx + ".ba2";

            // Extract mod:
            ModInstallations.ExtractArchive(filePath, mod.ManagedFolderPath);
            // ManipulateModFolder(mod, managedFolderPath, updateProgress);

            // Freeze mod conditionally:
            if (useSourceBA2Archive && fileExtension == ".ba2")
            {
                // Copy *.ba2 into FrozenData:
                FileInfo frozenPath = new FileInfo(mod.FrozenArchivePath);
                Directory.CreateDirectory(frozenPath.DirectoryName);
                File.Copy(filePath, frozenPath.FullName, true);

                mod.Frozen = true;
                mod.Freeze = true;
                mod.PreviousMethod = ManagedMod.DeploymentMethod.SeparateBA2;
                mod.Method = ManagedMod.DeploymentMethod.SeparateBA2;
            }

            return mod;
        }

        /// <summary>
        /// Copies the folder and adds the mod to the list.
        /// Saves the xml file afterwards.
        /// </summary>
        public static void InstallFolder(ManagedMods mods, string folderPath)
        {
            ManagedMod newMod = ModInstallations.FromFolder(folderPath);
            mods.Add(newMod);
            //mods.Save();
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
            mod.ArchiveName = folderName + ".ba2";

            // Copy folder:
            CopyDirectory(folderPath, mod.ManagedFolderPath);

            // ManipulateModFolder(mod, managedFolderPath, updateProgress);

            return mod;
        }

        /// <summary>
        /// Looks through the resource lists in the *.ini and imports *.ba2 archives.
        /// </summary>
        public static void ImportInstalledMods(ManagedMods mods)
        {
            // TODO: Should use resources.txt

            // Get all archives:
            ResourceList IndexFileList = ResourceList.GetResourceIndexFileList();
            ResourceList Archive2List = ResourceList.GetResourceArchive2List();

            /*
             * Prepare list:
             */

            // Add all archives:
            List<string> installedMods = new List<string>();
            installedMods.AddRange(IndexFileList);
            installedMods.AddRange(Archive2List);

            // Remove bundled archives:
            installedMods = installedMods.FindAll(e => !e.ToLower().Contains("bundled"));

            // Remove currently managed archives:
            foreach (ManagedMod mod in mods)
                if (mod.PreviousMethod == ManagedMod.DeploymentMethod.SeparateBA2)
                    installedMods.Remove(mod.CurrentArchiveName);

            // Ignore any game files ("SeventySix - *.ba2"):
            foreach (string archiveName in IndexFileList)
                if (archiveName.StartsWith("SeventySix"))
                    installedMods.Remove(archiveName);
            foreach (string archiveName in Archive2List)
                if (archiveName.StartsWith("SeventySix"))
                    installedMods.Remove(archiveName);

            /*
             * Import installed mods:
             */

            foreach (string archiveName in installedMods)
            {
                string path = Path.Combine(mods.GamePath, "Data", archiveName);
                Console.WriteLine(path);
                if (File.Exists(path))
                {
                    // Import archive:
                    ModInstallations.InstallArchive(mods, path, true);
                    File.Delete(path);

                    // Remove from lists:
                    IndexFileList.Remove(archiveName);
                    Archive2List.Remove(archiveName);
                }
            }

            // Save *.ini files:
            IndexFileList.CommitToINI();
            Archive2List.CommitToINI();
            //IniFiles.Instance.SaveAll();

            //mods.Save();
        }

        /// <summary>
        /// Extracts an archive into the given folder. (Throws exceptions)
        /// </summary>
        /// <param name="archivePath"></param>
        /// <param name="destinationPath"></param>
        /// <param name="updateProgress"></param>
        public static void ExtractArchive(string archivePath, string destinationPath, Action<string, int> updateProgress = null)
        {
            string filePath = Path.GetFullPath(archivePath);
            string fileName = Path.GetFileName(filePath);
            string fileExtension = Path.GetExtension(filePath);

            Directory.CreateDirectory(destinationPath);

            if (updateProgress != null)
                updateProgress($"Extracting {fileName} ...", -1);

            if (fileExtension.ToLower() == ".ba2")
            {
                // Use Archive2.exe to extract:
                Archive2.Extract(filePath, destinationPath);
                // Might throw a Archive2Exception
            }
            else if ((new string[] { ".zip", ".rar", ".tar", ".7z" }).Contains(fileExtension.ToLower()))
            {
                // Use 7-Zip (7za.exe) to extract:
                Utils.ExtractArchive(filePath, destinationPath);

                if (!Directory.Exists(destinationPath))
                    throw new FileNotFoundException("Something went wrong.");
                //MsgBox.ShowID("modsExtractUnknownErrorText", MessageBoxIcon.Error);
                //MsgBox.Get("modsExtractUnknownErrorText").FormatText(exc.Message).Show(MessageBoxIcon.Error);
            }
            else
            {
                throw new NotSupportedException($"File type not supported: {fileExtension}");
                //MsgBox.Get("modsArchiveTypeNotSupported").FormatText(fileExtension).Show(MessageBoxIcon.Error);
            }
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
