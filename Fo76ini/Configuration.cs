using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Fo76ini
{
    public static class Configuration
    {
        // https://stackoverflow.com/questions/1873658/net-windows-forms-remember-windows-size-and-location
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

        public static void SaveListViewState(string formName, ListView listView)
        {
            List<int> widths = new List<int>();
            foreach (ColumnHeader column in listView.Columns)
            {
                widths.Add(column.Width);
            }
            IniFiles.Config.Set(formName, "sColumnWidths", string.Join(",", widths));
        }

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

        /*#region [Preferences] section

        // Effect:  When true, opens mod manager on tool launch.
        // Default: false
        public static bool bOpenModManagerOnLaunch
        {
            get
            {
                return IniFiles.Config.GetBool("Preferences", "bOpenModManagerOnLaunch", false);
            }
            set
            {
                IniFiles.Config.Set("Preferences", "bOpenModManagerOnLaunch", value);
            }
        }

        // Effect:  When true, doesn't check for updates, nor does it display the "What's new" dialogue.
        // Default: false
        public static bool bIgnoreUpdates
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

        // Effect:  When true, doesn't display the "What's new" dialogue.
        // Default: false
        public static bool bDisableWhatsNew
        {
            get
            {
                return IniFiles.Config.GetBool("Preferences", "bDisableWhatsNew", false);
            }
            set
            {
                IniFiles.Config.Set("Preferences", "bDisableWhatsNew", value);
            }
        }

        // Effect:  When true, applies changes automatically when tool is closed by user.
        // Default: false
        public static bool bAutoApply
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

        // Effect:  When true, stops utilizing Fallout76Custom.ini for most *.ini tweaks.
        // Default: false
        public static bool bAlternativeINIMode
        {
            get
            {
                return IniFiles.Config.GetBool( "Preferences", "bAlternativeINIMode", false);
            }
            set
            {
                IniFiles.Config.Set("Preferences", "bAlternativeINIMode", value);
            }
        }

        // Effect:  When true, denies NTFS write permissions to the "Documents\My Games\Fallout 76" folder.
        // Default: false
        public static bool bDenyNTFSWritePermission
        {
            get
            {
                return IniFiles.Config.GetBool( "Preferences", "bDenyNTFSWritePermission", false);
            }
            set
            {
                IniFiles.Config.Set("Preferences", "bDenyNTFSWritePermission", value);
            }
        }

        // Effect:  When false, asks the user whether to make a backup on click on 'Apply'.
        // Default: false
        public static bool bSkipBackupQuestion
        {
            get
            {
                return IniFiles.Config.GetBool( "Preferences", "bSkipBackupQuestion", false);
            }
            set
            {
                IniFiles.Config.Set("Preferences", "bSkipBackupQuestion", value);
            }
        }

        public static uint uGameEdition
        {
            get
            {
                return IniFiles.Config.GetUInt("Preferences", "uGameEdition", 0);
            }
        }

        public static uint uLaunchOption
        {
            get
            {
                return IniFiles.Config.GetUInt("Preferences", "uLaunchOption", 1);
            }
        }

        // Effect:  When true, quits tool on game launch.
        // Default: false
        public static bool bQuitOnLaunch
        {
            get
            {
                return IniFiles.Config.GetBool( "Preferences", "bQuitOnLaunch", false);
            }
            set
            {
                IniFiles.Config.Set("Preferences", "bQuitOnLaunch", value);
            }
        }
        #endregion


        #region [NuclearWinter] section
        */
        // Default: false
        public static bool bNWMode
        {
            get
            {
                return IniFiles.Config.GetBool("NuclearWinter", "bNWMode",
                        IniFiles.Config.GetBool("Preferences", "bNWMode", false)); // backward compatibility
            }
            set
            {
                IniFiles.Config.Set("NuclearWinter", "bNWMode", value);
                IniFiles.Config.Remove("Preferences", "bNWMode");
            }
        }
        /*
        // Default: true
        public static bool bRenameCustomINI
        {
            get
            {
                return IniFiles.Config.GetBool( "NuclearWinter", "bRenameCustomINI", true);
            }
            set
            {
                IniFiles.Config.Set("NuclearWinter", "bRenameCustomINI", value);
            }
        }

        // Default: false
        public static bool bAutoDisableMods
        {
            get
            {
                return IniFiles.Config.GetBool( "bAutoDisableMods", "bAutoDisableMods", false);
            }
            set
            {
                IniFiles.Config.Set("NuclearWinter", "bAutoDisableMods", value);
            }
        }

        // Default: true
        public static bool bRenameDLLs
        {
            get
            {
                return IniFiles.Config.GetBool( "NuclearWinter", "bRenameDLLs", true);
            }
            set
            {
                IniFiles.Config.Set("NuclearWinter", "bRenameDLLs", value);
            }
        }

        #endregion


        #region [Mods] section*/
        public static bool bUseHardlinks
        {
            get
            {
                return IniFiles.Config.GetBool("Mods", "bUseHardlinks", true);
            }
            set
            {
                IniFiles.Config.Set("Mods", "bUseHardlinks", value);
            }
        }/*

        public static bool bFreezeBundledArchives
        {
            get
            {
                return IniFiles.Config.GetBool( "Mods", "bFreezeBundledArchives", false);
            }
            set
            {
                IniFiles.Config.Set("Mods", "bFreezeBundledArchives", value);
            }
        }

        public static bool bUnpackBA2ByDefault
        {
            get
            {
                return IniFiles.Config.GetBool( "Mods", "bUnpackBA2ByDefault", false);
            }
            set
            {
                IniFiles.Config.Set("Mods", "bUnpackBA2ByDefault", value);
            }
        }
        #endregion*/
    }
}
