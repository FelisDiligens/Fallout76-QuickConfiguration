using Fo76ini.Mods;
using System;

namespace Fo76ini
{
    partial class FormMods
    {
        /*
         * Settings
         */

        private void UpdateSettings()
        {
            this.checkBoxDisableMods.Checked = this.Mods.ModsDisabled;

            /*
             * Behavior
             */
            this.checkBoxAddArchivesAsBundled.Checked = Configuration.Mods.UnpackBA2ByDefault;
            this.checkBoxFreezeBundledArchives.Checked = Configuration.Mods.FreezeBundledArchives;

            if (Configuration.Mods.UseHardlinks)
                this.radioButtonModsUseHardlinks.Checked = true;
            else if (Configuration.Mods.UseSymlinks)
                this.radioButtonModsUseSymlinks.Checked = true;
            else
                this.radioButtonModsCopyFiles.Checked = true;

            switch (Configuration.Mods.BundledLoadOrder)
            {
                case ModDeployment.BundledLoadOrder.PutFirst:
                    this.radioButtonBundledFirstinLO.Checked = true;
                    break;
                case ModDeployment.BundledLoadOrder.PutLast:
                    this.radioButtonBundledLastinLO.Checked = true;
                    break;
            }

            /*
             * Interface
             */
            this.checkBoxModsUseRemoteModNames.Checked = Configuration.Mods.ShowRemoteModNames;

            switch (Configuration.Mods.ModListStyle)
            {
                case ModListStyle.Alternative:
                    this.radioButtonModsUseAlternativeList.Checked = true;
                    break;
                case ModListStyle.Standard:
                default:
                    this.radioButtonModsUseStandardList.Checked = true;
                    break;
            }

            LoadTextBoxResourceList(Mods.Resources);
        }


        #region Resource list textboxes
        private void LoadTextBoxResourceList(ResourceList list)
        {
            this.textBoxResourceList.Text = list.ToString("\n").Replace("\n", "\r\n");
        }

        // Clean lists
        private void buttonModsCleanList_Click(object sender, EventArgs e)
        {
            // Load list:
            ResourceList list = ResourceList.FromString(this.textBoxResourceList.Text.Replace("\r\n", "\n"));

            // Remove non-existing files:
            list.CleanUp(this.game.GamePath);

            LoadTextBoxResourceList(list);
        }

        // Apply changes
        private void buttonModsApplyTextBox_Click(object sender, EventArgs e)
        {
            ResourceList list = ResourceList.FromString(this.textBoxResourceList.Text.Replace("\r\n", "\n"));
            Mods.Resources.ReplaceRange(list);
            Mods.Save();
            LoadTextBoxResourceList(Mods.Resources);
        }

        // Reset
        private void buttonModsResetTextbox_Click(object sender, EventArgs e)
        {
            LoadTextBoxResourceList(Mods.Resources);
        }

        #endregion

        #region Settings - Checkboxes
        // Alternative *.ba2 import method
        private void checkBoxAddArchivesAsBundled_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Mods.UnpackBA2ByDefault = this.checkBoxAddArchivesAsBundled.Checked;
            IniFiles.Config.Save();
        }

        // Hard links
        private void radioButtonModsUseHardlinks_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonModsUseHardlinks.Checked)
            {
                Configuration.Mods.UseHardlinks = true;
                Configuration.Mods.UseSymlinks = false;
                IniFiles.Config.Save();
            }
        }

        // Sym links
        private void radioButtonModsUseSymlinks_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonModsUseSymlinks.Checked)
            {
                Configuration.Mods.UseHardlinks = false;
                Configuration.Mods.UseSymlinks = true;
                IniFiles.Config.Save();
            }
        }

        // Copy files
        private void radioButtonModsCopyFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonModsCopyFiles.Checked)
            {
                Configuration.Mods.UseHardlinks = false;
                Configuration.Mods.UseSymlinks = false;
                IniFiles.Config.Save();
            }
        }

        // Bundled load order: first
        private void radioButtonBundledFirstinLO_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonBundledFirstinLO.Checked)
                Configuration.Mods.BundledLoadOrder = ModDeployment.BundledLoadOrder.PutFirst;
        }

        // Bundled load order: last
        private void radioButtonBundledLastinLO_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonBundledLastinLO.Checked)
                Configuration.Mods.BundledLoadOrder = ModDeployment.BundledLoadOrder.PutLast;
        }

        // Freeze bundled archives
        private void checkBoxFreezeBundledArchives_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Mods.FreezeBundledArchives = this.checkBoxFreezeBundledArchives.Checked;
            IniFiles.Config.Save();
        }

        // Show the mod title from NexusMods, if available.
        private void checkBoxModsUseRemoteModNames_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Mods.ShowRemoteModNames = this.checkBoxModsUseRemoteModNames.Checked;
            IniFiles.Config.Save();
            DeselectAll();
            UpdateModList();
        }
        #endregion
    }
}
