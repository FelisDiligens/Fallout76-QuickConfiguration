using Fo76ini.Mods;
using Fo76ini.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini
{
    public partial class FormMods : Form
    {
        private ManagedMod changedMod;

        private bool isUpdatingUI = false;
        private bool bulk = false;
        private int modCount = 1;

        private int editedIndex;
        private List<int> editedIndices;

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
                //CloseSidePanel();
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
            ExpandSidePanel();
            isUpdatingUI = true;

            if (mod != null)
                this.changedMod = mod.CreateDeepCopy();

            if (this.changedMod.RemoteInfo != null && this.changedMod.RemoteInfo.Thumbnail != "")
            {
                string thumbnailPath = Path.Combine(NexusMods.ThumbnailsPath, this.changedMod.RemoteInfo.Thumbnail);
                if (File.Exists(thumbnailPath))
                    this.pictureBoxModThumbnail.Image = Image.FromFile(thumbnailPath);
                else
                    this.pictureBoxModThumbnail.Image = Resources.bg;
            }

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

            // Not bulk?
            if (!this.bulk)
            {
                this.labelModArchiveName.Visible = true;
                this.textBoxModArchiveName.Visible = true;
            }

            this.checkBoxModDetailsEnabled.Checked = this.changedMod.PendingDiskState.Enabled;

            if (this.modCount > 1)
                this.labelModTitle.Text = string.Format(Localization.localizedStrings["modDetailsTitleBulkSelected"], this.modCount);
            else
                this.labelModTitle.Text = this.changedMod.RemoteInfo != null && this.changedMod.RemoteInfo.Title != "" ? this.changedMod.RemoteInfo.Title : this.changedMod.Title;
            this.textBoxModName.Text = this.changedMod.Title;
            this.textBoxModRootDir.Text = this.changedMod.PendingDiskState.RootFolder;
            this.textBoxModURL.Text = this.changedMod.URL;
            this.textBoxModVersion.Text = this.changedMod.Version;

            switch (this.changedMod.PendingDiskState.Method)
            {
                case ManagedMod.DiskState.DeploymentMethod.BundledBA2:
                    this.comboBoxModInstallAs.SelectedIndex = 0;

                    //this.checkBoxModBA2Compression.Checked = ManagedMods.Instance.bundledCompression != Archive2.Compression.None;
                    //this.checkBoxModBA2Compression.Checked = ManagedMods.Instance.bundledTexturesCompression != Archive2.Compression.None;
                    this.checkBoxFreezeArchive.Visible = false;

                    //this.textBoxModArchiveName.Text = "";
                    this.textBoxModArchiveName.Visible = false;
                    this.labelModArchiveName.Visible = false;
                    this.buttonModDetailsSuggestArchiveName.Visible = false;

                    this.labelModUnfreeze.Visible = false;
                    this.buttonModUnfreeze.Visible = false;

                    this.comboBoxModArchivePreset.Visible = false;
                    this.labelModArchivePreset.Visible = false;

                    this.labelModInstallInto.Visible = false;
                    this.textBoxModRootDir.Visible = false;
                    this.buttonModPickRootDir.Visible = false;
                    break;
                case ManagedMod.DiskState.DeploymentMethod.SeparateBA2:
                    this.comboBoxModInstallAs.SelectedIndex = 1;

                    this.checkBoxFreezeArchive.Checked = this.changedMod.PendingDiskState.Frozen;
                    this.checkBoxFreezeArchive.Visible = true;
                    this.labelModUnfreeze.Visible = this.changedMod.FrozenDiskState.Frozen;
                    this.buttonModUnfreeze.Visible = this.changedMod.FrozenDiskState.Frozen;

                    this.comboBoxModArchivePreset.Visible = true;
                    this.labelModArchivePreset.Visible = true;

                    this.textBoxModArchiveName.Text = this.changedMod.PendingDiskState.ArchiveName;
                    this.textBoxModArchiveName.Visible = true;
                    this.buttonModDetailsSuggestArchiveName.Visible = true;
                    this.labelModArchiveName.Visible = true;

                    this.labelModInstallInto.Enabled = false;
                    this.textBoxModRootDir.Enabled = false;
                    this.buttonModPickRootDir.Enabled = false;
                    this.labelModInstallInto.Visible = true;
                    this.textBoxModRootDir.Visible = true;
                    this.buttonModPickRootDir.Visible = true;
                    break;
                case ManagedMod.DiskState.DeploymentMethod.Loose:
                    this.comboBoxModInstallAs.SelectedIndex = 2;
                    this.textBoxModArchiveName.Visible = false;
                    this.buttonModDetailsSuggestArchiveName.Visible = false;
                    this.labelModArchiveName.Visible = false;
                    this.comboBoxModArchivePreset.Visible = false;
                    this.labelModArchivePreset.Visible = false;

                    this.checkBoxFreezeArchive.Visible = false;
                    this.labelModUnfreeze.Visible = false;
                    this.buttonModUnfreeze.Visible = false;

                    this.labelModUnfreeze.Visible = false;
                    this.buttonModUnfreeze.Visible = false;

                    this.labelModInstallInto.Enabled = true;
                    this.textBoxModRootDir.Enabled = true;
                    this.buttonModPickRootDir.Enabled = true;
                    this.labelModInstallInto.Visible = true;
                    this.textBoxModRootDir.Visible = true;
                    this.buttonModPickRootDir.Visible = true;
                    break;
            }

            // Is frozen?
            bool isFrozen = this.changedMod.FrozenDiskState.Frozen;
            /*this.comboBoxModArchivePreset.Enabled = !isFrozen;
            this.comboBoxModInstallAs.Enabled = !isFrozen;
            this.buttonModRepairDDS.Enabled = !isFrozen;*/
            this.groupBoxModDetailsInstallationOptions.Visible = !isFrozen;

            // Preset
            if (!isFrozen && this.changedMod.PendingDiskState.Method == ManagedMod.DiskState.DeploymentMethod.SeparateBA2)
            {
                bool isCompressed = this.changedMod.PendingDiskState.Compression == ManagedMod.DiskState.ArchiveCompression.Compressed;
                switch (this.changedMod.PendingDiskState.Format)
                {
                    case ManagedMod.DiskState.ArchiveFormat.General:
                        if (isCompressed)
                            this.comboBoxModArchivePreset.SelectedIndex = 2; // General
                        else
                            this.comboBoxModArchivePreset.SelectedIndex = 4; // Sound FX
                        break;
                    case ManagedMod.DiskState.ArchiveFormat.Textures:
                        this.comboBoxModArchivePreset.SelectedIndex = 3;     // Textures
                        break;
                    case ManagedMod.DiskState.ArchiveFormat.Auto:
                        this.comboBoxModArchivePreset.SelectedIndex = 1;     // Auto-detect
                        break;
                    default:
                        this.comboBoxModArchivePreset.SelectedIndex = 0;     // Please select
                        break;
                }
                if (this.changedMod.PendingDiskState.Compression == ManagedMod.DiskState.ArchiveCompression.Auto)
                    this.comboBoxModArchivePreset.SelectedIndex = 1;
            }

            // Bulk?
            this.checkBoxModDetailsEnabled.Visible = !this.bulk;
            this.labelModName.Visible = !this.bulk;
            this.textBoxModName.Visible = !this.bulk;
            this.labelModFolderName.Visible = !this.bulk;
            this.textBoxModFolderName.Visible = !this.bulk;

            //this.buttonModOpenFolder.Visible = !this.bulk;
            //this.buttonModRepairDDS.Visible = !this.bulk;
            this.buttonModUnfreeze.Enabled = !this.bulk;

            /*this.separator1.Visible = !this.bulk;
            this.separator2.Visible = !this.bulk;*/

            this.labelModDetailsBulkFrozenModsWarning.Visible = this.bulk;
            if (this.bulk)
            {
                this.labelModArchiveName.Visible = false;
                this.textBoxModArchiveName.Visible = false;
                this.buttonModDetailsSuggestArchiveName.Visible = false;
            }

            this.groupBoxModDetailsDetails.Visible = !this.bulk;

            isUpdatingUI = false;
        }

        /*
         * Properties changed:
         */

        private void comboBoxModInstallAs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdatingUI)
                return;
            switch (this.comboBoxModInstallAs.SelectedIndex)
            {
                case 0: // Bundled *.ba2 archive
                    this.changedMod.PendingDiskState.Method = ManagedMod.DiskState.DeploymentMethod.BundledBA2;
                    this.changedMod.PendingDiskState.Frozen = false;
                    break;
                case 1: // Separate *.ba2 archive
                    this.changedMod.PendingDiskState.Method = ManagedMod.DiskState.DeploymentMethod.SeparateBA2;
                    break;
                case 2: // Loose files
                    this.changedMod.PendingDiskState.Method = ManagedMod.DiskState.DeploymentMethod.Loose;
                    this.changedMod.PendingDiskState.Frozen = false;
                    break;
            }
            UpdateSidePanel();
        }

        private void comboBoxModArchivePreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdatingUI)
                return;
            switch (this.comboBoxModArchivePreset.SelectedIndex)
            {
                case 0: // Please select
                    /*this.changedMod.Format = Mod.ArchiveFormat.Auto;
                    this.changedMod.Compression = Archive2.Compression.Default;*/
                    break;
                case 1: // Auto-detect
                    this.changedMod.PendingDiskState.Format = ManagedMod.DiskState.ArchiveFormat.Auto;
                    this.changedMod.PendingDiskState.Compression = ManagedMod.DiskState.ArchiveCompression.Auto;
                    break;
                case 2: // General
                    this.changedMod.PendingDiskState.Format = ManagedMod.DiskState.ArchiveFormat.General;
                    this.changedMod.PendingDiskState.Compression = ManagedMod.DiskState.ArchiveCompression.Compressed;
                    break;
                case 3: // Textures
                    this.changedMod.PendingDiskState.Format = ManagedMod.DiskState.ArchiveFormat.Textures;
                    this.changedMod.PendingDiskState.Compression = ManagedMod.DiskState.ArchiveCompression.Compressed;
                    break;
                case 4: // Audio
                    this.changedMod.PendingDiskState.Format = ManagedMod.DiskState.ArchiveFormat.General;
                    this.changedMod.PendingDiskState.Compression = ManagedMod.DiskState.ArchiveCompression.Uncompressed;
                    break;
            }
            UpdateSidePanel();
        }

        private void buttonModPickRootDir_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialogPickRootDir.SelectedPath = Path.Combine(Shared.GamePath, "Data");
            if (this.folderBrowserDialogPickRootDir.ShowDialog() == DialogResult.OK)
            {
                string rootFolder = Utils.MakeRelativePath(Shared.GamePath, this.folderBrowserDialogPickRootDir.SelectedPath);
                this.textBoxModRootDir.Text = rootFolder;
                this.changedMod.PendingDiskState.RootFolder = rootFolder;
            }
        }

        private void textBoxModRootDir_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxModRootDir.Focused && Directory.Exists(this.textBoxModRootDir.Text))
                this.changedMod.PendingDiskState.RootFolder = this.textBoxModRootDir.Text;
        }

        private void textBoxModArchiveName_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxModArchiveName.Focused)
                this.changedMod.PendingDiskState.ArchiveName = this.textBoxModArchiveName.Text;
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
            this.changedMod.PendingDiskState.Enabled = this.checkBoxModDetailsEnabled.Checked;
        }

        private void checkBoxFreezeArchive_CheckedChanged(object sender, EventArgs e)
        {
            this.changedMod.PendingDiskState.Frozen = this.checkBoxFreezeArchive.Checked;
        }

        private void textBoxModFolderName_TextChanged(object sender, EventArgs e)
        {

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
            Thread thread = new Thread(() =>
            {
                Invoke(() => ProgressBarMarquee());
                //Invoke(() => Display("Unfreezing..."));
                // TODO: Unfreeze
                /*this.changedMod.Unfreeze(
                    (text, percent) =>
                    {
                        Invoke(() => Display(text));
                        //Invoke(() => ProgressBarContinuous(percent));
                    },
                    (success) =>
                    {
                        Invoke(() =>
                        {
                            Invoke(() => ProgressBarContinuous(100));
                            this.ModDetailsFeedback(this.changedMod);
                            UpdateSidePanel();
                            if (success)
                                DisplayAllDone();
                            else
                                DisplayFailState();
                        });
                    }
                );*/
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void buttonModDetailsSuggestArchiveName_Click(object sender, EventArgs e)
        {
            this.changedMod.PendingDiskState.ArchiveName = Utils.GetValidFileName(this.changedMod.Title, ".ba2");
            this.textBoxModArchiveName.Text = this.changedMod.PendingDiskState.ArchiveName;
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
