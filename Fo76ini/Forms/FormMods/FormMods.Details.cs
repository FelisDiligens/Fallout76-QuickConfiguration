using Fo76ini.Interface;
using Fo76ini.Mods;
using Fo76ini.NexusAPI;
using Fo76ini.Properties;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Fo76ini
{
    // TODO: Should we remove bulk editing?
    // Bulk editing was kinda tacked on and doesn't really work that well anyway.
    // Removing it might be bad, though. Who knows, maybe someone uses this feature extensively?

    // TODO: Needs to be rewritten. It should not copy the mod. Instead, it should directly use the indexer.
    public partial class FormMods : Form
    {
        private ManagedMod changedMod;

        private bool isUpdatingSidePanel = false;
        private bool bulk = false;
        private int modCount = 1;

        private int editedIndex;
        private List<int> editedIndices;

        /// <summary>
        /// Sets up elements, adds event handlers, etc.
        /// </summary>
        private void InitializeDetailControls()
        {
            DropDown.Add("ModInstallAs", new DropDown(
                this.comboBoxModInstallAs,
                new string[] {
                    "Bundled *.ba2 archive",
                    "Separate *.ba2 archive",
                    "Loose files"
                }
            ));

            DropDown.Add("ModArchivePreset", new DropDown(
                this.comboBoxModArchivePreset,
                new string[] {
                    "-- Please select --",
                    "Auto-detect",
                    "General / Interface / Materials / Animations", /* Materials: *.bgsm; Interface: *.swf; */
                    "Textures (*.dds files)",
                    "Sound FX / Music / Voice",                     /* Voice: *.fuz; Lip-Sync: *.lip; Sound FX: *.xwm; */
                }
            ));

            this.pictureBoxCollapseDetails.MouseEnter += new EventHandler((mouseSender, mouseEventArgs) =>
            {
                this.pictureBoxCollapseDetails.BackColor = Color.LightGray;
                this.pictureBoxCollapseDetails.Cursor = Cursors.Hand;
            });
            this.pictureBoxCollapseDetails.MouseLeave += new EventHandler((mouseSender, mouseEventArgs) =>
            {
                this.pictureBoxCollapseDetails.BackColor = Color.Silver;
                this.pictureBoxCollapseDetails.Cursor = Cursors.Hand;
            });

            CollapseAndHideSidePanel();
        }


        /*
            Side panel
        */

        private void pictureBoxCollapseDetails_Click(object sender, EventArgs e)
        {
            if (this.panelModDetails.Visible)
                CollapseSidePanel();
            else
                ExpandSidePanel();
        }

        private void CloseSidePanel()
        {
            this.ModDetailsClosed();
            this.CollapseAndHideSidePanel();

            // Reset image, so the thumbnail gets unloaded:
            this.pictureBoxModThumbnail.Image = Resources.bg;
        }

        private void CollapseAndHideSidePanel()
        {
            this.pictureBoxCollapseDetails.Visible = false;
            this.panelModDetails.Visible = false;

            int tabWidth = this.tabPageModOrder.Width;
            this.listViewMods.Width = tabWidth - this.listViewMods.Location.X;
        }

        private void CollapseSidePanel()
        {
            this.pictureBoxCollapseDetails.Visible = true;
            this.pictureBoxCollapseDetails.Image = Resources.arrow_left_black;
            this.panelModDetails.Visible = false;

            int tabWidth = this.tabPageModOrder.Width;
            int buttonWidth = this.pictureBoxCollapseDetails.Width;
            this.pictureBoxCollapseDetails.Location = new Point(tabWidth - buttonWidth, this.pictureBoxCollapseDetails.Location.Y);
            this.listViewMods.Width = tabWidth - this.listViewMods.Location.X - buttonWidth + 1;
        }

        private void ExpandSidePanel()
        {
            this.pictureBoxCollapseDetails.Visible = true;
            this.pictureBoxCollapseDetails.Image = Resources.arrow_right_black;
            this.panelModDetails.Visible = true;

            int tabWidth = this.tabPageModOrder.Width;
            int buttonWidth = this.pictureBoxCollapseDetails.Width;
            int panelWidth = this.panelModDetails.Width;
            this.pictureBoxCollapseDetails.Location = new Point(tabWidth - panelWidth - buttonWidth + 1, this.pictureBoxCollapseDetails.Location.Y);
            this.listViewMods.Width = tabWidth - this.listViewMods.Location.X - panelWidth - buttonWidth + 2;
        }


        /*
         * Update UI:
         */

        public void UpdateSidePanel(ManagedMod mod = null, int modCount = -1)
        {
            // What mod are we editing?
            if (mod != null)
                this.changedMod = mod.CreateDeepCopy();

            if (this.changedMod == null)
                return;

            if (modCount > 1)
            {
                this.bulk = true;
                this.modCount = modCount;
            }
            else if (modCount == 1)
            {
                this.bulk = false;
                this.modCount = 1;
            }

            // Expand side panel:
            ExpandSidePanel();
            isUpdatingSidePanel = true;

            // Update thumbnail:
            if (this.changedMod.RemoteInfo != null && this.changedMod.RemoteInfo.Thumbnail != "")
            {
                string thumbnailPath = Path.Combine(NexusMods.ThumbnailsPath, this.changedMod.RemoteInfo.Thumbnail);
                if (File.Exists(thumbnailPath))
                    this.pictureBoxModThumbnail.Image = Image.FromFile(thumbnailPath);
                else
                    this.pictureBoxModThumbnail.Image = Resources.bg;
            }

            // Populate values:
            this.checkBoxModDetailsEnabled.Checked = this.changedMod.Enabled;
            this.checkBoxFreezeArchive.Checked = this.changedMod.Freeze;
            this.textBoxModArchiveName.Text = this.changedMod.ArchiveName;
            this.textBoxModName.Text = this.changedMod.Title;
            this.textBoxModRootDir.Text = this.changedMod.RootFolder;
            this.textBoxModURL.Text = this.changedMod.URL;
            this.textBoxModVersion.Text = this.changedMod.Version;

            switch (this.changedMod.Method)
            {
                case ManagedMod.DeploymentMethod.BundledBA2:
                    this.comboBoxModInstallAs.SelectedIndex = 0;
                    break;
                case ManagedMod.DeploymentMethod.SeparateBA2:
                    this.comboBoxModInstallAs.SelectedIndex = 1;
                    break;
                case ManagedMod.DeploymentMethod.Loose:
                    this.comboBoxModInstallAs.SelectedIndex = 2;
                    break;
            }

            if (this.modCount > 1)
                this.labelModTitle.Text = string.Format(Localization.localizedStrings["modDetailsTitleBulkSelected"], this.modCount);
            else
                this.labelModTitle.Text = this.changedMod.RemoteInfo != null && this.changedMod.RemoteInfo.Title != "" ? this.changedMod.RemoteInfo.Title : this.changedMod.Title;

            // Install into visible?
            this.labelModInstallInto.Visible = this.changedMod.Method == ManagedMod.DeploymentMethod.Loose;
            this.textBoxModRootDir.Visible = this.changedMod.Method == ManagedMod.DeploymentMethod.Loose;
            this.buttonModPickRootDir.Visible = this.changedMod.Method == ManagedMod.DeploymentMethod.Loose;

            // Preset visible?
            this.comboBoxModArchivePreset.Visible = this.changedMod.Method == ManagedMod.DeploymentMethod.SeparateBA2;
            this.labelModArchivePreset.Visible = this.changedMod.Method == ManagedMod.DeploymentMethod.SeparateBA2;

            // Archive name visible?
            this.labelModArchiveName.Visible = this.changedMod.Method == ManagedMod.DeploymentMethod.SeparateBA2;
            this.textBoxModArchiveName.Visible = this.changedMod.Method == ManagedMod.DeploymentMethod.SeparateBA2;
            this.buttonModDetailsSuggestArchiveName.Visible = this.changedMod.Method == ManagedMod.DeploymentMethod.SeparateBA2;

            // Frozen visible?
            this.checkBoxFreezeArchive.Visible = this.changedMod.Method == ManagedMod.DeploymentMethod.SeparateBA2;

            // Is frozen?
            this.groupBoxModDetailsInstallationOptions.Visible = !this.changedMod.Frozen;

            // Preset
            if (!this.changedMod.Frozen && this.changedMod.Method == ManagedMod.DeploymentMethod.SeparateBA2)
            {
                bool isCompressed = this.changedMod.Compression == ManagedMod.ArchiveCompression.Compressed;
                switch (this.changedMod.Format)
                {
                    case ManagedMod.ArchiveFormat.General:
                        if (isCompressed)
                            this.comboBoxModArchivePreset.SelectedIndex = 2; // General
                        else
                            this.comboBoxModArchivePreset.SelectedIndex = 4; // Sound FX
                        break;
                    case ManagedMod.ArchiveFormat.Textures:
                        this.comboBoxModArchivePreset.SelectedIndex = 3;     // Textures
                        break;
                    case ManagedMod.ArchiveFormat.Auto:
                        this.comboBoxModArchivePreset.SelectedIndex = 1;     // Auto-detect
                        break;
                    default:
                        this.comboBoxModArchivePreset.SelectedIndex = 0;     // Please select
                        break;
                }
                if (this.changedMod.Compression == ManagedMod.ArchiveCompression.Auto)
                    this.comboBoxModArchivePreset.SelectedIndex = 1;
            }

            // Bulk?
            this.checkBoxModDetailsEnabled.Visible = !this.bulk;
            this.buttonModUnfreeze.Enabled = !this.bulk;
            this.labelModDetailsBulkFrozenModsWarning.Visible = this.bulk;
            this.groupBoxModDetailsDetails.Visible = !this.bulk;

            isUpdatingSidePanel = false;
        }

        /*
         * Properties changed:
         */

        private void comboBoxModInstallAs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdatingSidePanel)
                return;
            switch (this.comboBoxModInstallAs.SelectedIndex)
            {
                case 0: // Bundled *.ba2 archive
                    this.changedMod.Method = ManagedMod.DeploymentMethod.BundledBA2;
                    this.changedMod.Freeze = false;
                    break;
                case 1: // Separate *.ba2 archive
                    this.changedMod.Method = ManagedMod.DeploymentMethod.SeparateBA2;
                    break;
                case 2: // Loose files
                    this.changedMod.Method = ManagedMod.DeploymentMethod.Loose;
                    this.changedMod.Freeze = false;
                    break;
            }
            UpdateSidePanel();
        }

        private void comboBoxModArchivePreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdatingSidePanel)
                return;
            switch (this.comboBoxModArchivePreset.SelectedIndex)
            {
                case 0: // Please select
                case 1: // Auto-detect
                    this.changedMod.Format = ManagedMod.ArchiveFormat.Auto;
                    this.changedMod.Compression = ManagedMod.ArchiveCompression.Auto;
                    break;
                case 2: // General
                    this.changedMod.Format = ManagedMod.ArchiveFormat.General;
                    this.changedMod.Compression = ManagedMod.ArchiveCompression.Compressed;
                    break;
                case 3: // Textures
                    this.changedMod.Format = ManagedMod.ArchiveFormat.Textures;
                    this.changedMod.Compression = ManagedMod.ArchiveCompression.Compressed;
                    break;
                case 4: // Audio
                    this.changedMod.Format = ManagedMod.ArchiveFormat.General;
                    this.changedMod.Compression = ManagedMod.ArchiveCompression.Uncompressed;
                    break;
            }
            UpdateSidePanel();
        }

        private void buttonModPickRootDir_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialogPickRootDir.SelectedPath = Path.Combine(this.game.GamePath, "Data");
            if (this.folderBrowserDialogPickRootDir.ShowDialog() == DialogResult.OK)
            {
                string rootFolder = Utils.MakeRelativePath(this.game.GamePath, this.folderBrowserDialogPickRootDir.SelectedPath);
                this.textBoxModRootDir.Text = rootFolder;
                this.changedMod.RootFolder = rootFolder;
            }
        }

        private void textBoxModRootDir_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxModRootDir.Focused && Directory.Exists(this.textBoxModRootDir.Text))
                this.changedMod.RootFolder = this.textBoxModRootDir.Text;
        }

        private void textBoxModArchiveName_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxModArchiveName.Focused)
                this.changedMod.ArchiveName = this.textBoxModArchiveName.Text;
        }

        private void textBoxModName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxModName.Focused)
            {
                this.changedMod.Title = this.textBoxModName.Text;
                if (this.changedMod.RemoteInfo == null || this.changedMod.RemoteInfo.Title == "")
                    this.labelModTitle.Text = this.changedMod.Title;
            }
        }

        private void checkBoxModDetailsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            this.changedMod.Enabled = this.checkBoxModDetailsEnabled.Checked;
        }

        private void checkBoxFreezeArchive_CheckedChanged(object sender, EventArgs e)
        {
            this.changedMod.Freeze = this.checkBoxFreezeArchive.Checked;
        }

        private void textBoxModURL_TextChanged(object sender, EventArgs e)
        {
            this.changedMod.URL = this.textBoxModURL.Text;
        }

        private void textBoxModVersion_TextChanged(object sender, EventArgs e)
        {
            this.changedMod.Version = this.textBoxModVersion.Text;
        }


        /*
         * Actions
         */

        private void buttonModUnfreeze_Click(object sender, EventArgs e)
        {
            RunThreaded(() => {
                DisableUI();
            }, () => {
                // TODO: This will cause issues:
                ModActions.Unfreeze(Mods, editedIndex, UpdateProgress);
                return true;
            }, (success) => {
                UpdateSidePanel();
                UpdateUI();
                EnableUI();
            });
        }

        private void buttonModDetailsSuggestArchiveName_Click(object sender, EventArgs e)
        {
            this.changedMod.ArchiveName = Utils.GetValidFileName(this.changedMod.Title, ".ba2");
            this.textBoxModArchiveName.Text = this.changedMod.ArchiveName;
        }

        private void buttonModDetailsApply_Click(object sender, EventArgs e)
        {
            this.ModDetailsFeedback(this.changedMod);
        }

        private void buttonModDetailsCancel_Click(object sender, EventArgs e)
        {
            this.CloseSidePanel();
        }

        private void buttonModDetailsOK_Click(object sender, EventArgs e)
        {
            this.ModDetailsFeedback(this.changedMod);
            this.ModDetailsClosed();
            this.CollapseAndHideSidePanel();
        }
    }
}
