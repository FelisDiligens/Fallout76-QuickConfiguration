using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Fo76ini.Mods
{
    /// <summary>
    /// Bundles functions that help with working with mods.
    /// They don't affect any files and don't change any state.
    /// </summary>
    public static class ModHelpers
    {
        public static string[] ResourceFolders = new string[] { "meshes", "strings", "music", "sound", "textures", "materials", "interface", "geoexporter", "programs", "vis", "scripts", "misc", "shadersfx", "lodsettings", "video" };
        public static string[] GeneralFolders = new string[] { "meshes", "interface", "materials" };
        public static string[] TextureFolders = new string[] { "textures", "effects" };
        public static string[] SoundFolders = new string[] { "sound", "music" };

        /// <summary>
        /// Converts ManagedMod.ArchiveCompression and ManagedMod.ArchiveFormat to an Archive2.Preset.
        /// Automatically determines appropriate compression and format if needed.
        /// </summary>
        public static Archive2.Preset GetArchive2Preset(ManagedMod mod)
        {
            return GetArchive2Preset(mod.ManagedFolderPath, mod.Format, mod.Compression);
        }

        /// <summary>
        /// Converts ManagedMod.ArchiveCompression and ManagedMod.ArchiveFormat to an Archive2.Preset.
        /// Automatically determines appropriate compression and format if needed.
        /// </summary>
        public static Archive2.Preset GetArchive2Preset(String managedFolderPath, Archive2.Format? format, Archive2.Compression? compression)
        {
            var preset = new Archive2.Preset();

            // No detection needed:
            if (compression != null && format != null)
            {
                preset.compression = (Archive2.Compression)compression;
                preset.format = (Archive2.Format)format;
                return preset;
            }

            // Detect mod type:

            int generalFoldersCount = 0;
            int textureFoldersCount = 0;
            int soundFoldersCount = 0;

            IEnumerable<string> folders = Directory.EnumerateDirectories(managedFolderPath);
            foreach (string path in folders)
            {
                string folderName = Path.GetFileName(path).ToLower();

                if (GeneralFolders.Contains(folderName))
                    generalFoldersCount++;
                else if (TextureFolders.Contains(folderName))
                    textureFoldersCount++;
                else if (SoundFolders.Contains(folderName))
                    soundFoldersCount++;
            }

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
        /// Compares both versions and returns which is greater.
        /// Tries to parse the version numbers and falls back to string comparison if that fails.
        /// </summary>
        /// <param name="installedVersionStr"></param>
        /// <param name="latestVersionStr"></param>
        /// <returns>
        ///  0 = equal
        /// >0 = installed version is more up-to-date than "latest" (?)
        /// <0 = update available
        /// </returns>
        public static int CompareVersion(string installedVersionStr, string latestVersionStr)
        {
            Regex versionRegex = new Regex(@"\d+(?:\.\d+)+");
            if (versionRegex.IsMatch(installedVersionStr) &&
                versionRegex.IsMatch(latestVersionStr))
            {
                try
                {
                    Version installedVersion = new Version(installedVersionStr);
                    Version latestVersion = new Version(latestVersionStr);
                    return installedVersion.CompareTo(latestVersion);
                }
                catch
                {
                    Console.WriteLine($"ModHelpers.CompareVersion failed to parse versions!\nInstalled: {installedVersionStr}\nLatest: {latestVersionStr}\nFalling back to string comparison.");
                }
            }
            return installedVersionStr == latestVersionStr ? 0 : -1;
        }

        /// <summary>
        /// Checks whether the specified folder contains files that can be packed into a *.ba2 archive.
        /// </summary>
        public static bool AreFilesAvailableToPack(string path)
        {
            // Directory empty?
            if (Utils.IsDirectoryEmpty(path))
                return false;

            // Everything that doesn't belong in *.ba2 archives (not an exhaustive list):
            string[] ignoreExtensions = new string[]
            {
                // Text files: (readmes / instructions)
                ".txt", ".rtf",
                // Config files:
                ".ini", ".json", ".xml", ".yaml", ".conf", ".config",
                // Images: (e.g. screenshots)
                ".jpg", ".jpeg", ".png", ".gif", ".bmp",
                // Programs:
                ".exe", ".pdb", ".dll",
            };

            // Does the directory contain a file that should not be ignored?
            foreach (string file in Directory.EnumerateFiles(path, "*.*", SearchOption.AllDirectories))
            {
                if (!ignoreExtensions.Contains(Path.GetExtension(file).ToLower()))
                    return true;
            }

            return false;
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
                string lowerPath = lowerMod.ManagedFolderPath;

                // If not enabled or non-existant, we don't need to check.
                if (!lowerMod.Enabled || !Directory.Exists(lowerPath))
                    continue;

                // Get a list of files with relative paths:
                List<string> lowerRelPaths = new List<string>();
                foreach (string filePath in Directory.EnumerateFiles(lowerPath, "*.*", SearchOption.AllDirectories))
                    lowerRelPaths.Add(Utils.MakeRelativePath(lowerPath, filePath));

                // Iterate over all mods whose files could get overwritten:
                for (int l = 0; l < i; l++)
                {
                    ManagedMod upperMod = mods[l];
                    string upperPath = upperMod.ManagedFolderPath;

                    // If not enabled or non-existant, we don't need to check.
                    if (!upperMod.Enabled || !Directory.Exists(upperPath))
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
        public static List<Conflict> GetConflictingArchiveNames(List<ManagedMod> mods)
        {
            List<string> customArchiveNames = new List<string>();
            List<Conflict> conflictingArchiveNames = new List<Conflict>();
            foreach (ManagedMod mod in mods)
            {
                if (mod.Method == ManagedMod.DeploymentMethod.SeparateBA2 && mod.Enabled)
                {
                    if (customArchiveNames.Contains(mod.ArchiveName.ToLower()))
                    {
                        Conflict conflict = new Conflict();
                        conflict.conflictText = $"{mod.Title} uses a taken archive name: {mod.ArchiveName}";
                        conflict.conflictingArchiveName = mod.ArchiveName;
                        conflictingArchiveNames.Add(conflict);
                    }
                    else
                    {
                        customArchiveNames.Add(mod.ArchiveName.ToLower());
                    }
                }
            }
            return conflictingArchiveNames;
        }
    }
}
