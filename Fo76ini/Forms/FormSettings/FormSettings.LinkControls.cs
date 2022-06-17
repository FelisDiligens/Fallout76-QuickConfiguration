using Fo76ini.Tweaks;
using Fo76ini.Tweaks.Config;
using Fo76ini.Tweaks.Inis;
using Fo76ini.Tweaks.NuclearWinterMode;
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
            LinkedTweaks.LinkInfo(checkBoxReadOnly, toolTip, iniReadOnlyTweak);
            LinkedTweaks.LinkInfo(checkBoxAutoApply, toolTip, autoApplyTweak);
            LinkedTweaks.LinkInfo(checkBoxIgnoreUpdates, toolTip, ignoreUpdatesTweak);
            LinkedTweaks.LinkInfo(checkBoxPlayNotificationSound, toolTip, playNotificationSoundsTweak);
            LinkedTweaks.LinkInfo(checkBoxQuitOnGameLaunch, toolTip, toolQuitOnLaunchTweak);
            LinkedTweaks.LinkInfo(checkBoxNWRenameDLL, toolTip, renameDLLsTweak);
            LinkedTweaks.LinkInfo(checkBoxNWAutoDeployMods, toolTip, deployModsOnNWModeTweak);
            LinkedTweaks.LinkInfo(checkBoxNWAutoDisableMods, toolTip, removeModsOnNWModeTweak);
            LinkedTweaks.LinkInfo(checkBoxShowNWBtn, toolTip, showNWModeButtonTweak);
            LinkedTweaks.LinkInfo(labelArchiveTwoPath, toolTip, archiveTwoPathTweak);
            LinkedTweaks.LinkInfo(labelSevenZipPath, toolTip, sevenZipPathTweak);
            LinkedTweaks.LinkInfo(labelDownloadsPath, toolTip, downloadPathTweak);
            LinkedTweaks.LinkInfo(textBoxArchiveTwoPath, toolTip, archiveTwoPathTweak);
            LinkedTweaks.LinkInfo(textBoxSevenZipPath, toolTip, sevenZipPathTweak);
            LinkedTweaks.LinkInfo(textBoxDownloadsPath, toolTip, downloadPathTweak);
            LinkedTweaks.LinkInfo(buttonPickArchiveTwoPath, toolTip, archiveTwoPathTweak);
            LinkedTweaks.LinkInfo(buttonPickSevenZipPath, toolTip, sevenZipPathTweak);
            LinkedTweaks.LinkInfo(buttonPickDownloadsPath, toolTip, downloadPathTweak);
        }

        public void LinkControlsToTweaks()
        {
            // Make *.ini files read-only
            LinkedTweaks.LinkTweak(checkBoxReadOnly, iniReadOnlyTweak);

            // Automatically apply changes when tool is closed or game is launched
            LinkedTweaks.LinkTweak(checkBoxAutoApply, autoApplyTweak);

            // Don't check for updates on startup.
            LinkedTweaks.LinkTweak(checkBoxIgnoreUpdates, ignoreUpdatesTweak);

            // Play notification sounds
            LinkedTweaks.LinkTweak(checkBoxPlayNotificationSound, playNotificationSoundsTweak);

            // Close the tool when the game is launched.
            LinkedTweaks.LinkTweak(checkBoxQuitOnGameLaunch, toolQuitOnLaunchTweak);


            /*
             * Nuclear Winter options
             */

            // Rename added *.dll files
            LinkedTweaks.LinkTweak(checkBoxNWRenameDLL, renameDLLsTweak);

            // Automatically deploy mods
            LinkedTweaks.LinkTweak(checkBoxNWAutoDeployMods, deployModsOnNWModeTweak);

            // Automatically remove mods
            LinkedTweaks.LinkTweak(checkBoxNWAutoDisableMods, removeModsOnNWModeTweak);

            // Show/hide NW mode toggle button
            LinkedTweaks.LinkTweak(checkBoxShowNWBtn, showNWModeButtonTweak);
        }

        private SevenZipPathTweak sevenZipPathTweak = new SevenZipPathTweak();
        private ArchiveTwoPathTweak archiveTwoPathTweak = new ArchiveTwoPathTweak();
        private DownloadPathTweak downloadPathTweak = new DownloadPathTweak();

        private INIReadOnlyTweak iniReadOnlyTweak = new INIReadOnlyTweak();
        private AutoApplyTweak autoApplyTweak = new AutoApplyTweak();
        private IgnoreUpdatesTweak ignoreUpdatesTweak = new IgnoreUpdatesTweak();
        private PlayNotificationSoundsTweak playNotificationSoundsTweak = new PlayNotificationSoundsTweak();
        private ToolQuitOnLaunchTweak toolQuitOnLaunchTweak = new ToolQuitOnLaunchTweak();

        private DeployModsOnNWModeTweak deployModsOnNWModeTweak = new DeployModsOnNWModeTweak();
        private RemoveModsOnNWModeTweak removeModsOnNWModeTweak = new RemoveModsOnNWModeTweak();
        private RenameDLLsTweak renameDLLsTweak = new RenameDLLsTweak();
        private ShowNWModeButtonTweak showNWModeButtonTweak = new ShowNWModeButtonTweak();
    }
}
