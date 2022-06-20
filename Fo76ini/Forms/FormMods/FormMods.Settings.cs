using Fo76ini.Mods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            this.checkBoxAddArchivesAsBundled.Checked = IniFiles.Config.GetBool("Mods", "bUnpackBA2ByDefault", false);
            this.checkBoxModsUseHardlinks.Checked = IniFiles.Config.GetBool("Mods", "bUseHardlinks", true);
            this.checkBoxFreezeBundledArchives.Checked = IniFiles.Config.GetBool("Mods", "bFreezeBundledArchives", false);
            this.checkBoxModsUseRemoteModNames.Checked = IniFiles.Config.GetBool("Mods", "bShowRemoteModNames", true);

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
            IniFiles.Config.Set("Mods", "bUnpackBA2ByDefault", this.checkBoxAddArchivesAsBundled.Checked);
            IniFiles.Config.Save();
        }

        // Hard links
        private void checkBoxModsUseHardlinks_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Config.Set("Mods", "bUseHardlinks", this.checkBoxModsUseHardlinks.Checked);
            IniFiles.Config.Save();
        }

        // Freeze bundled archives
        private void checkBoxFreezeBundledArchives_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Config.Set("Mods", "bFreezeBundledArchives", this.checkBoxFreezeBundledArchives.Checked);
            IniFiles.Config.Save();
        }

        // Show the mod title from NexusMods, if available.
        private void checkBoxModsUseRemoteModNames_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Config.Set("Mods", "bShowRemoteModNames", this.checkBoxModsUseRemoteModNames.Checked);
            IniFiles.Config.Save();
            UpdateModList();
        }
        #endregion
    }
}
