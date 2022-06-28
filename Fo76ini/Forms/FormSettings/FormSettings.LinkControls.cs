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
        // TODO: FormSettings.LinkInfo
        public void LinkInfo()
        {
            //LinkedTweaks.LinkInfo(checkBoxReadOnly, toolTip, iniReadOnlyTweak);

            //LinkedTweaks.LinkInfo(checkBoxAutoApply, toolTip, autoApplyTweak);
            //LinkedTweaks.LinkInfo(checkBoxIgnoreUpdates, toolTip, ignoreUpdatesTweak);
            //LinkedTweaks.LinkInfo(checkBoxPlayNotificationSound, toolTip, playNotificationSoundsTweak);
            //LinkedTweaks.LinkInfo(checkBoxQuitOnGameLaunch, toolTip, toolQuitOnLaunchTweak);

            //LinkedTweaks.LinkInfo(checkBoxNWRenameDLL, toolTip, renameDLLsTweak);
            //LinkedTweaks.LinkInfo(checkBoxNWAutoDeployMods, toolTip, deployModsOnNWModeTweak);
            //LinkedTweaks.LinkInfo(checkBoxNWAutoDisableMods, toolTip, removeModsOnNWModeTweak);
            //LinkedTweaks.LinkInfo(checkBoxShowNWBtn, toolTip, showNWModeButtonTweak);

            //LinkedTweaks.LinkInfo(checkBoxShowWhatsNew, toolTip, showWhatsNewTweak);

            //LinkedTweaks.LinkInfo(labelArchiveTwoPath, toolTip, archiveTwoPathTweak);
            //LinkedTweaks.LinkInfo(textBoxArchiveTwoPath, toolTip, archiveTwoPathTweak);
            //LinkedTweaks.LinkInfo(buttonPickArchiveTwoPath, toolTip, archiveTwoPathTweak);

            //LinkedTweaks.LinkInfo(labelSevenZipPath, toolTip, sevenZipPathTweak);
            //LinkedTweaks.LinkInfo(textBoxSevenZipPath, toolTip, sevenZipPathTweak);
            //LinkedTweaks.LinkInfo(buttonPickSevenZipPath, toolTip, sevenZipPathTweak);

            //LinkedTweaks.LinkInfo(labelDownloadsPath, toolTip, downloadPathTweak);
            //LinkedTweaks.LinkInfo(textBoxDownloadsPath, toolTip, downloadPathTweak);
            //LinkedTweaks.LinkInfo(buttonPickDownloadsPath, toolTip, downloadPathTweak);
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
