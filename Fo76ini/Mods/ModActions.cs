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
    /// Bundles functions that change the state or the files of a mod.
    /// </summary>
    public static class ModActions
    {
        /*public static void RenameManagedFolder(ManagedMod mod)
        {
            // Don't unnecessarily move folder:
            if (mod.CurrentDiskState.ManagedFolderName == mod.PendingDiskState.ManagedFolderName)
                return;

            // Rename folder:
            if (Directory.Exists(mod.CurrentDiskState.GetManagedFolderPath()))
                Directory.Move(mod.CurrentDiskState.GetManagedFolderPath(), mod.PendingDiskState.GetManagedFolderPath());

            // Change DiskState and save:
            mod.CurrentDiskState.ManagedFolderName = mod.PendingDiskState.ManagedFolderName;
            ManagedMods.Instance.Save();
        }*/

        public static void Delete(ManagedMod mod)
        {
            // Delete managed folder:
            if (Directory.Exists(mod.CurrentDiskState.GetManagedFolderPath()))
                Directory.Delete(mod.CurrentDiskState.GetManagedFolderPath(), true);

            // Delete frozen archive:
            if (mod.FrozenDiskState.Frozen &&
                mod.FrozenDiskState.Method == ManagedMod.DiskState.DeploymentMethod.SeparateBA2 &&
                File.Exists(mod.FrozenDiskState.GetFrozenArchivePath()))
            {
                File.Delete(mod.FrozenDiskState.GetFrozenArchivePath());
            }
        }

        public static void Freeze(ManagedMod mod)
        {
            // TODO: Remove connection to ManagedMods
            // Only freeze if not already frozen:
            if (mod.FrozenDiskState.Frozen)
            {
                // TODO: ModActions.Freeze: Should the mod get "refrozen"?
                ManagedMods.Instance.logFile.WriteLine($"Cannot freeze a mod ('{mod.Title}') that is already frozen.\n");
                return;
            }

            Directory.CreateDirectory(mod.CurrentDiskState.GetFrozenDataPath());

            string managedPath = mod.CurrentDiskState.GetManagedFolderPath();
            string frozenPath = mod.PendingDiskState.GetFrozenArchivePath();

            // Create archive:
            Archive2.Create(frozenPath, managedPath, ModHelpers.GetArchive2Preset(mod.PendingDiskState));

            // Failed?
            if (!File.Exists(frozenPath))
            {
                ManagedMods.Instance.logFile.WriteLine("Error while freezing mod: Couldn't create *.ba2 file. Please check archive2.log.txt.\n");
                return;
            }

            // Change DiskState and save:
            mod.FrozenDiskState = mod.CurrentDiskState.CreateDeepCopy();
            mod.FrozenDiskState.Frozen = true;
            mod.FrozenDiskState.Method = ManagedMod.DiskState.DeploymentMethod.SeparateBA2;
            mod.FrozenDiskState.ArchiveName = mod.FrozenDiskState.GetFrozenArchiveName();
            mod.FrozenDiskState.Compression = mod.PendingDiskState.Compression;
            mod.FrozenDiskState.Format = mod.PendingDiskState.Format;
            ManagedMods.Instance.Save();
        }

        public static void Unfreeze(ManagedMod mod, Action<string, int> updateProgress = null, Action<bool> done = null)
        {
            try
            {
                // Only unfreeze if actually frozen:
                if (!mod.FrozenDiskState.Frozen)
                {
                    ManagedMods.Instance.logFile.WriteLine($"Cannot unfreeze a mod ('{mod.Title}') that isn't frozen.\n");
                    if (done != null)
                        done(false);
                    return;
                }

                if (updateProgress != null)
                    updateProgress($"Unfreezing {mod.Title}", -1);

                // Delete *.ba2:
                File.Delete(mod.FrozenDiskState.GetFrozenArchivePath());

                // Change DiskState and save:
                mod.FrozenDiskState.Frozen = false;

                if (done != null)
                    done(true);
            }
            catch (Archive2Exception ex)
            {
                ManagedMods.Instance.logFile.WriteLine($"Archive2Exception occured while unfreezing mod '{mod.Title}': {ex.Message}\n{ex.StackTrace}\n");
                MsgBox.Get("archive2Error").Show(MessageBoxIcon.Error);
                if (done != null)
                    done(false);
                return;
            }
            catch (Exception ex)
            {
                ManagedMods.Instance.logFile.WriteLine($"Unhandled exception occured while unfreezing mod '{mod.Title}': {ex.Message}\n{ex.StackTrace}\n");
                if (done != null)
                    done(false);
                return;
            }
        }

        private static void ManipulateModFolder(ManagedMod mod, Action<string, int> updateProgress = null)
        {
            string managedFolderPath = mod.CurrentDiskState.GetManagedFolderPath();
            foreach (string path in Directory.EnumerateFiles(managedFolderPath))
            {
                // If a *.ba2 archive was found, extract it:
                if (path.EndsWith(".ba2"))
                {
                    try
                    {
                        Archive2.Extract(path, managedFolderPath);
                        File.Delete(path);
                    }
                    catch (Archive2Exception ex) { }
                }
            }

            //String[] typicalFolders = new string[] { "meshes", "strings", "music", "sound", "textures", "materials", "interface", "geoexporter", "programs", "vis", "scripts", "misc", "shadersfx" };

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
                        if (mod.PendingDiskState.Format != ManagedMod.DiskState.ArchiveFormat.Auto)
                        {
                            mod.PendingDiskState.Format = ManagedMod.DiskState.ArchiveFormat.Textures;
                            mod.PendingDiskState.RootFolder = "Data";
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
                    mod.PendingDiskState.Method = ManagedMod.DiskState.DeploymentMethod.Loose;
                    mod.PendingDiskState.RootFolder = ".";
                }
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

        public static void RenameAddedDLLs()
        {
            // Iterate through every *.dll file in game path:
            IEnumerable<string> files = Directory.EnumerateFiles(Shared.GamePath, "*.dll");
            ManagedMods.Instance.logFile.WriteLine($"Renaming \'*.dll\' files to \'*.dll.nwmode\'.");
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
                        ManagedMods.Instance.logFile.WriteLine($"   Renamed {fileName}");
                    }

                    // ... or delete it:
                    else
                    {
                        File.Delete(filePath);
                        ManagedMods.Instance.logFile.WriteLine($"   Deleted {fileName}");
                    }
                }
            }
        }

        public static void RestoreAddedDLLs()
        {
            // Iterate through every *.dll.nwmode file in game path:
            IEnumerable<string> files = Directory.EnumerateFiles(Shared.GamePath, "*.dll.nwmode");
            ManagedMods.Instance.logFile.WriteLine($"Restoring \'*.dll.nwmode\' files to \'*.dll\'.");
            foreach (string filePath in files)
            {
                string fileName = Path.GetFileName(filePath);
                string originalFilePath = Path.Combine(Path.GetDirectoryName(filePath), fileName.Replace(".dll.nwmode", ".dll"));

                // Rename or delete, if the original exists:
                if (!File.Exists(originalFilePath))
                {
                    File.Move(filePath, originalFilePath);
                    ManagedMods.Instance.logFile.WriteLine($"   Renamed {fileName}");
                }
                else
                {
                    // Assuming that the same *.dll file has been copied during deployment:
                    File.Delete(filePath); // we can just delete it.
                    ManagedMods.Instance.logFile.WriteLine($"   Deleted {fileName}");
                }
            }
        }
    }
}
