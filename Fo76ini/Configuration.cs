using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Syroot.Windows.IO;
using Fo76ini.Utilities;
using System.Globalization;

namespace Fo76ini
{
    /// <summary>
    /// Provides properties and methods to access the config.ini.
    /// </summary>
    public static class Configuration
    {
        #region Properties

        public class Mods
        {
            /// <summary>
            /// Description:
            /// Reduces disk space and deployment time.
            /// </summary>
            public static bool UseHardlinks
            {
                get
                {
                    return IniFiles.Config.GetBool("Mods", "bUseHardlinks", true);
                }
                set
                {
                    IniFiles.Config.Set("Mods", "bUseHardlinks", value);
                }
            }

            public static bool UseSymlinks
            {
                get
                {
                    return IniFiles.Config.GetBool("Mods", "bUseSymlinks", true);
                }
                set
                {
                    IniFiles.Config.Set("Mods", "bUseSymlinks", value);
                }
            }

            public static bool UnpackBA2ByDefault
            {
                get
                {
                    return IniFiles.Config.GetBool("Mods", "bUnpackBA2ByDefault", false);
                }
                set
                {
                    IniFiles.Config.Set("Mods", "bUnpackBA2ByDefault", value);
                }
            }

            public static bool FreezeBundledArchives
            {
                get
                {
                    return IniFiles.Config.GetBool("Mods", "bFreezeBundledArchives", false);
                }
                set
                {
                    IniFiles.Config.Set("Mods", "bFreezeBundledArchives", value);
                }
            }

            public static bool ShowRemoteModNames
            {
                get
                {
                    return IniFiles.Config.GetBool("Mods", "bShowRemoteModNames", false);
                }
                set
                {
                    IniFiles.Config.Set("Mods", "bShowRemoteModNames", value);
                }
            }

            public static FormMods.ModListStyle ModListStyle
            {
                get
                {
                    return (FormMods.ModListStyle)IniFiles.Config.GetInt("Mods", "iModListStyle", (int)FormMods.ModListStyle.Standard);
                }
                set
                {
                    IniFiles.Config.Set("Mods", "iModListStyle", (int)value);
                }
            }
        }

        public class NuclearWinter
        {
            public static bool ShowNWModeBtn
            {
                get
                {
                    return IniFiles.Config.GetBool("NuclearWinter", "bShowNWModeBtn", false);
                }
                set
                {
                    IniFiles.Config.Set("NuclearWinter", "bShowNWModeBtn", value);
                }
            }

            public static bool AutoDisableMods
            {
                get
                {
                    return IniFiles.Config.GetBool("NuclearWinter", "bAutoDisableMods", true);
                }
                set
                {
                    IniFiles.Config.Set("NuclearWinter", "bAutoDisableMods", value);
                }
            }

            public static bool AutoDeployMods
            {
                get
                {
                    return IniFiles.Config.GetBool("NuclearWinter", "bAutoDeployMods", true);
                }
                set
                {
                    IniFiles.Config.Set("NuclearWinter", "bAutoDeployMods", value);
                }
            }

            public static bool RenameDLLs
            {
                get
                {
                    return IniFiles.Config.GetBool("NuclearWinter", "bRenameDLLs", true);
                }
                set
                {
                    IniFiles.Config.Set("NuclearWinter", "bRenameDLLs", value);
                }
            }
        }

        public class Gallery
        {
            public static bool SearchDirsRecursively
            {
                get
                {
                    return IniFiles.Config.GetBool("Gallery", "bSearchDirectoriesRecursively", false);
                }
                set
                {
                    IniFiles.Config.Set("Gallery", "bSearchDirectoriesRecursively", value);
                }
            }

            public static string[] CustomPaths
            {
                get
                {
                    return IniFiles.Config.GetString("Gallery", "sCustomPathsList", "").Split(',');
                }
                set
                {
                    IniFiles.Config.Set("Gallery", "sCustomPathsList", String.Join(",", value));
                }
            }
        }

        public class NexusMods
        {
            public static bool AutoUpdateProfile
            {
                get
                {
                    return IniFiles.Config.GetBool("NexusMods", "bAutoUpdateProfile", true);
                }
                set
                {
                    IniFiles.Config.Set("NexusMods", "bAutoUpdateProfile", value);
                }
            }

            public static bool DownloadThumbnailsOnUpdate
            {
                get
                {
                    return IniFiles.Config.GetBool("NexusMods", "bDownloadThumbnailsOnUpdate", true);
                }
                set
                {
                    IniFiles.Config.Set("NexusMods", "bDownloadThumbnailsOnUpdate", value);
                }
            }

            // In use?:
            // IniFiles.Instance.GetBool(IniFile.Config, "NexusMods", "bAutoUpdateModInfo", false);
        }


        /// <summary>
        /// Description:
        /// No need to press apply anymore.
        /// </summary>
        public static bool AutoApply
        {
            get
            {
                return IniFiles.Config.GetBool("Preferences", "bAutoApply", false);
            }
            set
            {
                IniFiles.Config.Set("Preferences", "bAutoApply", value);
            }
        }

        /// <summary>
        /// Description:
        /// "When enabled, closes the tool when the game is launched.
        /// Only works if launched through the tool.
        /// </summary>
        public static bool QuitOnLaunch
        {
            get
            {
                return IniFiles.Config.GetBool("Preferences", "bQuitOnLaunch", false);
            }
            set
            {
                IniFiles.Config.Set("Preferences", "bQuitOnLaunch", value);
            }
        }

        /// <summary>
        /// Description:
        /// When enabled, the tool will play custom notification sounds.
        /// </summary>
        public static bool PlayNotificationSounds
        {
            get
            {
                return IniFiles.Config.GetBool("Preferences", "bPlayNotificationSound", true);
            }
            set
            {
                IniFiles.Config.Set("Preferences", "bPlayNotificationSound", value);
            }
        }

        /// <summary>
        /// Description:
        /// Won't check for updates on startup and hides the big update button.
        /// </summary>
        public static bool IgnoreUpdates
        {
            get
            {
                return IniFiles.Config.GetBool("Preferences", "bIgnoreUpdates", false);
            }
            set
            {
                IniFiles.Config.Set("Preferences", "bIgnoreUpdates", value);
            }
        }

        /// <summary>
        /// Description:
        /// Requires a restart.
        /// </summary>
        public static bool ShowWhatsNew
        {
            get
            {
                return IniFiles.Config.GetBool("Preferences", "bShowWhatsNew", true);
            }
            set
            {
                IniFiles.Config.Set("Preferences", "bShowWhatsNew", value);
            }
        }

        public static string SelectedLanguage
        {
            get
            {
                return IniFiles.Config.GetString("Preferences", "sLanguage", CultureInfo.CurrentUICulture.Name);
            }
            set
            {
                IniFiles.Config.Set("Preferences", "sLanguage", value);
            }
        }

        /// <summary>
        /// Description:
        /// When you download mods using the 'Vortex' / 'Mod Manager Download' button on NexusMods,
        /// the tool will download the file to this folder.
        /// </summary>
        public static string DownloadPath
        {
            get
            {
                return Path.GetFullPath(IniFiles.Config.GetString("Preferences", "sDownloadPath", DefaultDownloadPath));
            }
            set
            {
                IniFiles.Config.Set("Preferences", "sDownloadPath", value);
            }
        }

        public static string DefaultDownloadPath
        {
            get
            {
                return KnownFolders.Downloads.Path;
            }
        }

        /// <summary>
        /// Description:
        /// The tool uses Archive2.exe to extract and pack *.ba2 files.
        /// You can set the path where the tool looks for Archive2.exe.
        /// </summary>
        public static string Archive2Path
        {
            get
            {
                return IniFiles.Config.GetString("Preferences", "sArchiveTwoPath", Archive2.DefaultArchive2Path);
            }
            set
            {
                IniFiles.Config.Set("Preferences", "sArchiveTwoPath", value);
            }
        }

        /// <summary>
        /// Description:
        /// The tool uses 7z.exe to extract various archives (zip, rar, 7z).
        /// You can set the path where the tool looks for 7z.exe.
        /// </summary>
        public static string SevenZipPath
        {
            get
            {
                return IniFiles.Config.GetString("Preferences", "sSevenZipPath", SevenZip.DefaultExecPath);
            }
            set
            {
                IniFiles.Config.Set("Preferences", "sSevenZipPath", value);
            }
        }

        public static bool SkipProfileManager
        {
            get
            {
                return IniFiles.Config.GetBool("Preferences", "bSkipProfileManager", true);
            }
            set
            {
                IniFiles.Config.Set("Preferences", "bSkipProfileManager", value);
            }
        }

        #endregion

        #region Methods

        // https://stackoverflow.com/questions/1873658/net-windows-forms-remember-windows-size-and-location
        /// <summary>
        /// Saves the position, size, and whether the form is maximized to the config file.
        /// </summary>
        public static void SaveWindowState(string formName, Form form)
        {
            if (form.WindowState == FormWindowState.Maximized)
            {
                IniFiles.Config.Set(formName, "iLocationX", form.RestoreBounds.Location.X);
                IniFiles.Config.Set(formName, "iLocationY", form.RestoreBounds.Location.Y);
                IniFiles.Config.Set(formName, "iWidth", form.RestoreBounds.Size.Width);
                IniFiles.Config.Set(formName, "iHeight", form.RestoreBounds.Size.Height);
                IniFiles.Config.Set(formName, "bMaximised", true);
            }
            else
            {
                IniFiles.Config.Set(formName, "iLocationX", form.Location.X);
                IniFiles.Config.Set(formName, "iLocationY", form.Location.Y);
                IniFiles.Config.Set(formName, "iWidth", form.Size.Width);
                IniFiles.Config.Set(formName, "iHeight", form.Size.Height);
                IniFiles.Config.Set(formName, "bMaximised", false);
            }
            IniFiles.Config.Save();
        }

        /// <summary>
        /// Restores the position, size, and whether the form is maximized from the config file.
        /// </summary>
        public static void LoadWindowState(string formName, Form form)
        {
            int locX = IniFiles.Config.GetInt(formName, "iLocationX", -1);
            int locY = IniFiles.Config.GetInt(formName, "iLocationY", -1);
            if (locX >= 0 && locY >= 0)
                form.Location = new System.Drawing.Point(locX, locY);

            int width = IniFiles.Config.GetInt(formName, "iWidth", form.Size.Width);
            int height = IniFiles.Config.GetInt(formName, "iHeight", form.Size.Height);
            if (width >= form.MinimumSize.Width && height >= form.MinimumSize.Height)
                form.Size = new System.Drawing.Size(width, height);

            if (IniFiles.Config.GetBool(formName, "bMaximised", false))
                form.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// Saves the width of all columns in a ListView object.
        /// </summary>
        public static void SaveListViewState(string formName, ListView listView)
        {
            List<int> widths = new List<int>();
            foreach (ColumnHeader column in listView.Columns)
            {
                widths.Add(column.Width);
            }
            IniFiles.Config.Set(formName, "sColumnWidths", string.Join(",", widths));
        }


        /// <summary>
        /// Restores the width of all columns in a ListView object.
        /// </summary>
        public static void LoadListViewState(string formName, ListView listView)
        {
            List<int> lWidths = new List<int>();
            string[] sWidths = IniFiles.Config.GetString(formName, "sColumnWidths", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string sWidth in sWidths)
                lWidths.Add(Convert.ToInt32(sWidth));

            int i = 0;
            foreach (ColumnHeader column in listView.Columns)
            {
                if (i < lWidths.Count)
                    column.Width = lWidths[i++];
            }
        }

        #endregion
    }
}
