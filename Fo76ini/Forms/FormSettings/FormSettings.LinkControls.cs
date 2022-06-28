using Fo76ini.Tweaks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Forms.FormSettings
{
    partial class FormSettings
    {
        public void LinkInfo()
        {
            /*
             * Backwards-compatibility for translated tooltips:
             */

            LinkedTweaks.LinkInfo(checkBoxReadOnly, toolTip,
                "Fo76ini.Tweaks.Inis.INIReadOnlyTweak",
                "This option will make all *.ini files read-only immediately.\nEnable this if your settings get reverted.");

            LinkedTweaks.LinkInfo(checkBoxAutoApply, toolTip,
                "Fo76ini.Tweaks.Config.AutoApplyTweak",
                "No need to press apply anymore.");

            LinkedTweaks.LinkInfo(checkBoxIgnoreUpdates, toolTip,
                "Fo76ini.Tweaks.Config.IgnoreUpdatesTweak",
                "Won't check for updates on startup and hides the big update button.");

            LinkedTweaks.LinkInfo(checkBoxPlayNotificationSound, toolTip,
                "Fo76ini.Tweaks.Config.PlayNotificationSoundsTweak",
                "When enabled, the tool will play custom notification sounds.");
            
            LinkedTweaks.LinkInfo(checkBoxQuitOnGameLaunch, toolTip,
                "Fo76ini.Tweaks.Config.ToolQuitOnLaunchTweak",
                "When enabled, closes the tool when the game is launched.\nOnly works if launched through the tool.");

            LinkedTweaks.LinkInfo(checkBoxNWRenameDLL, toolTip,
                "Fo76ini.Tweaks.NuclearWinterMode.RenameDLLsTweak",
                "If checked, any *.dll files that don't belong to the game will be renamed.");

            LinkedTweaks.LinkInfo(checkBoxNWAutoDeployMods, toolTip,
                "Fo76ini.Tweaks.NuclearWinterMode.DeployModsOnNWModeTweak",
                "If checked, mods will be deployed when the Nuclear Winter mode is disabled.");

            LinkedTweaks.LinkInfo(checkBoxNWAutoDisableMods, toolTip,
                "Fo76ini.Tweaks.NuclearWinterMode.RemoveModsOnNWModeTweak",
                "If checked, mods will be removed when the Nuclear Winter mode is enabled.");
            
            LinkedTweaks.LinkInfo(checkBoxShowNWBtn, toolTip,
                "Fo76ini.Tweaks.NuclearWinterMode.ShowNWModeButtonTweak",
                "If checked, it will show the Nuclear Winter / Adventure mode button in the main window, so you can still toggle the deprecated NW mode.");

            LinkedTweaks.LinkInfo(checkBoxShowWhatsNew, toolTip,
                "Fo76ini.Tweaks.Config.ShowWhatsNewTweak",
                "Requires a restart.");

            string archiveTwoPathToolTipID = "Fo76ini.Tweaks.Config.ArchiveTwoPathTweak";
            string archiveTwoPathToolTipDesc = "The tool uses Archive2.exe to extract and pack *.ba2 files.\nYou can set the path where the tool looks for Archive2.exe.";
            LinkedTweaks.LinkInfo(labelArchiveTwoPath, toolTip, archiveTwoPathToolTipID, archiveTwoPathToolTipDesc);
            LinkedTweaks.LinkInfo(textBoxArchiveTwoPath, toolTip, archiveTwoPathToolTipID, archiveTwoPathToolTipDesc);
            LinkedTweaks.LinkInfo(buttonPickArchiveTwoPath, toolTip, archiveTwoPathToolTipID, archiveTwoPathToolTipDesc);

            string sevenZipPathToolTipID = "Fo76ini.Tweaks.Config.SevenZipPathTweak";
            string sevenZipPathToolTipDesc = "The tool uses 7z.exe to extract various archives (zip, rar, 7z).\nYou can set the path where the tool looks for 7z.exe.";
            LinkedTweaks.LinkInfo(labelSevenZipPath, toolTip, sevenZipPathToolTipID, sevenZipPathToolTipDesc);
            LinkedTweaks.LinkInfo(textBoxSevenZipPath, toolTip, sevenZipPathToolTipID, sevenZipPathToolTipDesc);
            LinkedTweaks.LinkInfo(buttonPickSevenZipPath, toolTip, sevenZipPathToolTipID, sevenZipPathToolTipDesc);

            string downloadsPathToolTipID = "Fo76ini.Tweaks.Config.DownloadPathTweak";
            string downloadsPathToolTipDesc = "When you download mods using the 'Vortex' / 'Mod Manager Download' button on NexusMods,\nthe tool will download the file to this folder.";
            LinkedTweaks.LinkInfo(labelDownloadsPath, toolTip, downloadsPathToolTipID, downloadsPathToolTipDesc);
            LinkedTweaks.LinkInfo(textBoxDownloadsPath, toolTip, downloadsPathToolTipID, downloadsPathToolTipDesc);
            LinkedTweaks.LinkInfo(buttonPickDownloadsPath, toolTip, downloadsPathToolTipID, downloadsPathToolTipDesc);
        }

        public void LinkControlsToTweaks()
        {
            // Make *.ini files read-only
            LinkedTweaks.Link(checkBoxReadOnly, (IniFiles.AreINIsReadOnly, IniFiles.SetINIsReadOnlySafe));


            /*
             * Behavior
             */

            // Automatically apply changes when tool is closed or game is launched
            LinkedTweaks.LinkProperty(checkBoxAutoApply, new Accessor<bool>(() => Configuration.AutoApply));

            // Don't check for updates on startup.
            LinkedTweaks.LinkProperty(checkBoxIgnoreUpdates, new Accessor<bool>(() => Configuration.IgnoreUpdates));

            // Play notification sounds
            LinkedTweaks.LinkProperty(checkBoxPlayNotificationSound, new Accessor<bool>(() => Configuration.PlayNotificationSounds));

            // Close the tool when the game is launched.
            LinkedTweaks.LinkProperty(checkBoxQuitOnGameLaunch, new Accessor<bool>(() => Configuration.QuitOnLaunch));


            /*
             * Nuclear Winter options
             */

            // Rename added *.dll files
            LinkedTweaks.LinkProperty(checkBoxNWRenameDLL, new Accessor<bool>(() => Configuration.NuclearWinter.RenameDLLs));

            // Automatically deploy mods
            LinkedTweaks.LinkProperty(checkBoxNWAutoDeployMods, new Accessor<bool>(() => Configuration.NuclearWinter.AutoDeployMods));

            // Automatically remove mods
            LinkedTweaks.LinkProperty(checkBoxNWAutoDisableMods, new Accessor<bool>(() => Configuration.NuclearWinter.AutoDisableMods));


            /*
             * User Interface
             */

            // Show/hide NW mode toggle button
            LinkedTweaks.LinkProperty(checkBoxShowNWBtn, new Accessor<bool>(() => Configuration.NuclearWinter.ShowNWModeBtn));

            // Show/hide What's new RTF in FormMain
            LinkedTweaks.LinkProperty(checkBoxShowWhatsNew, new Accessor<bool>(() => Configuration.ShowWhatsNew));
        }
    }
}
