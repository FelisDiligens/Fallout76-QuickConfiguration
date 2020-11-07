using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini
{
    // TODO: Rewrite every IniFiles.Instance.GetXXX to use the Configuration class instead.
    public class Configuration
    {
        #region [Preferences] section

        // Effect:  When true, opens mod manager on tool launch.
        // Default: false
        public static bool bOpenModManagerOnLaunch
        {
            get
            {
                return IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bOpenModManagerOnLaunch", false);
            }
            set
            {
                IniFiles.Instance.Set(IniFile.Config, "Preferences", "bOpenModManagerOnLaunch", value);
            }
        }

        // Effect:  When true, doesn't check for updates, nor does it display the "What's new" dialogue.
        // Default: false
        public static bool bIgnoreUpdates
        {
            get
            {
                return IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bIgnoreUpdates", false);
            }
            set
            {
                IniFiles.Instance.Set(IniFile.Config, "Preferences", "bIgnoreUpdates", value);
            }
        }

        // Effect:  When true, doesn't display the "What's new" dialogue.
        // Default: false
        public static bool bDisableWhatsNew
        {
            get
            {
                return IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bDisableWhatsNew", false);
            }
            set
            {
                IniFiles.Instance.Set(IniFile.Config, "Preferences", "bDisableWhatsNew", value);
            }
        }

        // Effect:  When true, applies changes automatically when tool is closed by user.
        // Default: false
        public static bool bAutoApply
        {
            get
            {
                return IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bAutoApply", false);
            }
            set
            {
                IniFiles.Instance.Set(IniFile.Config, "Preferences", "bAutoApply", value);
            }
        }

        // Effect:  When true, stops utilizing Fallout76Custom.ini for most *.ini tweaks.
        // Default: false
        public static bool bAlternativeINIMode
        {
            get
            {
                return IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bAlternativeINIMode", false);
            }
            set
            {
                IniFiles.Instance.Set(IniFile.Config, "Preferences", "bAlternativeINIMode", value);
            }
        }

        // Effect:  When true, denies NTFS write permissions to the "Documents\My Games\Fallout 76" folder.
        // Default: false
        public static bool bDenyNTFSWritePermission
        {
            get
            {
                return IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bDenyNTFSWritePermission", false);
            }
            set
            {
                IniFiles.Instance.Set(IniFile.Config, "Preferences", "bDenyNTFSWritePermission", value);
            }
        }

        // Effect:  When false, asks the user whether to make a backup on click on 'Apply'.
        // Default: false
        public static bool bSkipBackupQuestion
        {
            get
            {
                return IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bSkipBackupQuestion", false);
            }
            set
            {
                IniFiles.Instance.Set(IniFile.Config, "Preferences", "bSkipBackupQuestion", value);
            }
        }

        public static uint uGameEdition
        {
            get
            {
                return IniFiles.Instance.GetUInt(IniFile.Config, "Preferences", "uGameEdition", 0);
            }
        }

        public static uint uLaunchOption
        {
            get
            {
                return IniFiles.Instance.GetUInt(IniFile.Config, "Preferences", "uLaunchOption", 1);
            }
        }

        // Effect:  When true, quits tool on game launch.
        // Default: false
        public static bool bQuitOnLaunch
        {
            get
            {
                return IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bQuitOnLaunch", false);
            }
            set
            {
                IniFiles.Instance.Set(IniFile.Config, "Preferences", "bQuitOnLaunch", value);
            }
        }
        #endregion


        #region [NuclearWinter] section

        // Default: false
        public static bool bNWMode
        {
            get
            {
                return IniFiles.Instance.GetBool(IniFile.Config, "NuclearWinter", "bNWMode",
                        IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bNWMode", false)); // backward compatibility
            }
            set
            {
                IniFiles.Instance.Set(IniFile.Config, "NuclearWinter", "bNWMode", value);
                IniFiles.Instance.Remove(IniFile.Config, "Preferences", "bNWMode");
            }
        }

        // Default: true
        public static bool bRenameCustomINI
        {
            get
            {
                return IniFiles.Instance.GetBool(IniFile.Config, "NuclearWinter", "bRenameCustomINI", true);
            }
            set
            {
                IniFiles.Instance.Set(IniFile.Config, "NuclearWinter", "bRenameCustomINI", value);
            }
        }

        // Default: false
        public static bool bAutoDisableMods
        {
            get
            {
                return IniFiles.Instance.GetBool(IniFile.Config, "bAutoDisableMods", "bAutoDisableMods", false);
            }
            set
            {
                IniFiles.Instance.Set(IniFile.Config, "NuclearWinter", "bAutoDisableMods", value);
            }
        }

        // Default: true
        public static bool bRenameDLLs
        {
            get
            {
                return IniFiles.Instance.GetBool(IniFile.Config, "NuclearWinter", "bRenameDLLs", true);
            }
            set
            {
                IniFiles.Instance.Set(IniFile.Config, "NuclearWinter", "bRenameDLLs", value);
            }
        }

        #endregion


        #region [Mods] section
        public static bool bUseHardlinks
        {
            get
            {
                return IniFiles.Instance.GetBool(IniFile.Config, "Mods", "bUseHardlinks", true);
            }
            set
            {
                IniFiles.Instance.Set(IniFile.Config, "Mods", "bUseHardlinks", value);
            }
        }
        #endregion
    }
}
