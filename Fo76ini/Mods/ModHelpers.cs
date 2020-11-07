using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Mods
{
    /// <summary>
    /// Bundles functions that help with working with mods.
    /// They don't change the state of a mod.
    /// </summary>
    public static class ModHelpers
    {
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
        /// Basically converts ManagedMod.DiskState to Archive2.Preset.
        /// Automatically determines appropriate compression and format if needed.
        /// </summary>
        /// <param name="diskState"></param>
        /// <returns></returns>
        public static Archive2.Preset GetArchive2Preset(ManagedMod.DiskState diskState)
        {
            var preset = new Archive2.Preset();

            // No detection needed, "convert" ArchiveCompression to Archive2.Compression and ArchiveFormat to Archive2.Format:
            if (diskState.Compression != ManagedMod.DiskState.ArchiveCompression.Auto && diskState.Format != ManagedMod.DiskState.ArchiveFormat.Auto)
            {
                preset.compression = diskState.Compression == ManagedMod.DiskState.ArchiveCompression.Compressed ? Archive2.Compression.Default : Archive2.Compression.None;
                preset.format = diskState.Format == ManagedMod.DiskState.ArchiveFormat.General ? Archive2.Format.General : Archive2.Format.DDS;

                return preset;
            }

            // Detect mod type:
            // String[] resourceFolders = new string[] { "meshes", "strings", "music", "sound", "textures", "materials", "interface", "geoexporter", "programs", "vis", "scripts", "misc", "shadersfx", "lodsettings" };
            string[] generalFolders = new string[] { "meshes", "strings", "interface", "materials" };
            string[] textureFolders = new string[] { "textures", "effects" };
            string[] soundFolders = new string[] { "sound", "music" };

            int generalFoldersCount = 0;
            int textureFoldersCount = 0;
            int soundFoldersCount = 0;

            string managedFolderPath = diskState.GetManagedFolderPath();
            IEnumerable<string> folders = Directory.EnumerateDirectories(managedFolderPath);
            foreach (string path in folders)
            {
                string folderName = Path.GetFileName(path).ToLower();

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
            }
            else if (textureFoldersCount > generalFoldersCount && textureFoldersCount > soundFoldersCount)
            {
                preset.compression = Archive2.Compression.Default;
                preset.format = Archive2.Format.DDS;
            }
            else
            {
                preset.compression = Archive2.Compression.Default;
                preset.format = Archive2.Format.General;
            }

            return preset;
        }

        /// <summary>
        /// Represents a conflict between mods. Used as the return value of the GetConflictingFiles() and the GetConflictingArchiveNames() methods.
        /// </summary>
        public struct Conflict
        {
            public string conflictText;
            public string conflictingArchiveName;
            public List<string> conflictingFiles;
        }

        /// <summary>
        /// Checks if enabled mods lower on the list overwrite files of enabled mods higher on the list.
        /// </summary>
        /// <returns>A list of conflicting mods.</returns>
        public static List<Conflict> GetConflictingFiles(List<ManagedMod> mods)
        {
            List<Conflict> conflictingMods = new List<Conflict>();

            // Mods higher in the list (upperMod) can get overwritten by mods lower in the list (lowerMod).

            // Iterate over all mods:
            for (int i = 1; i < mods.Count; i++)
            {
                ManagedMod lowerMod = mods[i];
                string lowerPath = lowerMod.GetManagedFolderPath();

                // If not enabled or non-existant, we don't need to check.
                if (!lowerMod.isEnabled() || !Directory.Exists(lowerPath))
                    continue;

                // Get a list of files with relative paths:
                List<string> lowerRelPaths = new List<string>();
                foreach (string filePath in Directory.EnumerateFiles(lowerPath, "*.*", SearchOption.AllDirectories))
                    lowerRelPaths.Add(Utils.MakeRelativePath(lowerPath, filePath));

                // Iterate over all mods whose files could get overwritten:
                for (int l = 0; l < i; l++)
                {
                    ManagedMod upperMod = mods[l];
                    string upperPath = upperMod.GetManagedFolderPath();

                    // If not enabled or non-existant, we don't need to check.
                    if (!upperMod.isEnabled() || !Directory.Exists(upperPath))
                        continue;

                    Conflict conflict = new Conflict();
                    conflict.conflictingFiles = new List<string>();
                    conflict.conflictText = lowerMod.Title + " overrides " + upperMod.Title;

                    // For each file...
                    foreach (string filePath in Directory.EnumerateFiles(upperPath, "*.*", SearchOption.AllDirectories))
                    {
                        string relUpperPath = Utils.MakeRelativePath(upperPath, filePath);

                        // ... check if it gets overwritten by the lower mod:
                        if (lowerRelPaths.Contains(relUpperPath))
                        {
                            // If it does, add it to the list of conflicting files:
                            if (!conflict.conflictingFiles.Contains(relUpperPath))
                                conflict.conflictingFiles.Add(relUpperPath);
                        }
                    }

                    // Add the conflict to the conflictingMods list, if files get overwritten:
                    if (conflict.conflictingFiles.Count > 0)
                        conflictingMods.Add(conflict);
                }
            }
            return conflictingMods;
        }

        /// <summary>
        /// Searches through the list of mods and returns a list of conflicting archive names.
        /// </summary>
        /// <param name="mods"></param>
        /// <returns></returns>
        public static List<Conflict> GetConflictingArchiveNames(List<ManagedMod> mods)
        {
            List<string> customArchiveNames = new List<string>();
            List<Conflict> conflictingArchiveNames = new List<Conflict>();
            foreach (ManagedMod mod in mods)
            {
                if (mod.PendingDiskState.Method == ManagedMod.DiskState.DeploymentMethod.SeparateBA2 && mod.isEnabled())
                {
                    if (customArchiveNames.Contains(mod.PendingDiskState.ArchiveName.ToLower()))
                    {
                        Conflict conflict = new Conflict();
                        conflict.conflictText = $"{mod.Title} uses a taken archive name: {mod.PendingDiskState.ArchiveName}";
                        conflict.conflictingArchiveName = mod.PendingDiskState.ArchiveName;
                        conflictingArchiveNames.Add(conflict);
                    }
                    else
                    {
                        customArchiveNames.Add(mod.PendingDiskState.ArchiveName.ToLower());
                    }
                }
            }
            return conflictingArchiveNames;
        }
    }
}
