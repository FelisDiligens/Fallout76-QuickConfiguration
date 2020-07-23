using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini
{
    public partial class FormModDetails : Form
    {
        private Mod changedMod;
        private FormMods formMods;

        private bool isUpdatingUI = false;
        private bool bulk = false;
        private int modCount = 1;

        public FormModDetails(FormMods formMods)
        {
            InitializeComponent();

            this.formMods = formMods;

            this.FormClosing += this.FormModDetails_FormClosing;

            ComboBoxContainer.Add("ModInstallAs", new ComboBoxContainer(
                this.comboBoxModInstallAs,
                new String[] {
                    "Bundled *.ba2 archive",
                    "Separate *.ba2 archive",
                    "Loose files"
                }
            ));

            ComboBoxContainer.Add("ModArchivePreset", new ComboBoxContainer(
                this.comboBoxModArchivePreset,
                new String[] {
                    "-- Please select --",
                    "General / Interface / Materials",      /* Materials: *.bgsm; Interface: *.swf; */
                    "Textures (*.dds files)",
                    "Uncompressed textures (*.dds files)",  /* Textures: *.dds; */
                    "Sound FX / Audio",                     /* Voice: *.fuz; Lip-Sync: *.lip; Sound FX: *.xwm; */
                }
            ));
        }

        public void UpdateUI(Mod mod = null, int modCount = -1)
        {
            isUpdatingUI = true;
            this.labelModDetailsStatus.Visible = false;

            if (mod != null)
                this.changedMod = mod.CreateCopy();

            if (modCount > 1)
            {
                this.bulk = true;
                this.modCount = modCount;
            }
            else if(modCount == 1)
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

            this.checkBoxModDetailsEnabled.Checked = this.changedMod.isEnabled;

            if (this.modCount > 1)
                this.Text = String.Format(Translation.localizedStrings["modDetailsTitleBulk"], this.modCount);
            else
                this.Text = String.Format(Translation.localizedStrings["modDetailsTitle"], this.changedMod.Title);
            this.textBoxModName.Text = this.changedMod.Title;
            this.textBoxModFolderName.Text = this.changedMod.ManagedFolder;
            this.textBoxModRootDir.Text = this.changedMod.RootFolder;

            switch (this.changedMod.Format)
            {
                case Mod.ArchiveFormat.General:
                    this.comboBoxModArchivePreset.SelectedIndex = 1;
                    break;
                case Mod.ArchiveFormat.Textures:
                    this.comboBoxModArchivePreset.SelectedIndex = 2;
                    break;
                default:
                    this.comboBoxModArchivePreset.SelectedIndex = 0;
                    break;
            }

            switch (this.changedMod.Type)
            {
                case Mod.FileType.BundledBA2:
                    this.comboBoxModInstallAs.SelectedIndex = 0;

                    //this.checkBoxModBA2Compression.Checked = ManagedMods.Instance.bundledCompression != Archive2.Compression.None;
                    //this.checkBoxModBA2Compression.Checked = ManagedMods.Instance.bundledTexturesCompression != Archive2.Compression.None;
                    this.checkBoxFreezeArchive.Visible = false;

                    //this.textBoxModArchiveName.Text = "";
                    this.textBoxModArchiveName.Visible = false;
                    this.labelModArchiveName.Visible = false;

                    this.labelModUnfreeze.Visible = false;
                    this.buttonModUnfreeze.Visible = false;

                    this.comboBoxModArchivePreset.Visible = false;
                    this.labelModArchivePreset.Visible = false;

                    this.labelModInstallInto.Visible = false;
                    this.textBoxModRootDir.Visible = false;
                    this.buttonModPickRootDir.Visible = false;
                    break;
                case Mod.FileType.SeparateBA2:
                    this.comboBoxModInstallAs.SelectedIndex = 1;

                    this.checkBoxFreezeArchive.Checked = this.changedMod.freeze;
                    this.checkBoxFreezeArchive.Visible = true;
                    this.labelModUnfreeze.Visible = this.changedMod.isFrozen();
                    this.buttonModUnfreeze.Visible = this.changedMod.isFrozen();

                    this.comboBoxModArchivePreset.Visible = true;
                    this.labelModArchivePreset.Visible = true;

                    this.textBoxModArchiveName.Text = this.changedMod.ArchiveName;
                    this.textBoxModArchiveName.Visible = true;
                    this.labelModArchiveName.Visible = true;

                    this.labelModInstallInto.Enabled = false;
                    this.textBoxModRootDir.Enabled = false;
                    this.buttonModPickRootDir.Enabled = false;
                    this.labelModInstallInto.Visible = true;
                    this.textBoxModRootDir.Visible = true;
                    this.buttonModPickRootDir.Visible = true;
                    break;
                case Mod.FileType.Loose:
                    this.comboBoxModInstallAs.SelectedIndex = 2;
                    this.textBoxModArchiveName.Visible = false;
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
            bool isFrozen = this.changedMod.isFrozen();
            /*this.comboBoxModArchivePreset.Enabled = !isFrozen;
            this.comboBoxModInstallAs.Enabled = !isFrozen;
            this.buttonModRepairDDS.Enabled = !isFrozen;*/
            this.groupBoxModDetailsInstallationOptions.Enabled = !isFrozen;

            // Preset
            if (!isFrozen && this.changedMod.Type == Mod.FileType.SeparateBA2)
            {
                bool isCompressed = this.changedMod.Compression == Archive2.Compression.Default;
                switch (this.changedMod.Format)
                {
                    case Mod.ArchiveFormat.General:
                        if (isCompressed)
                            this.comboBoxModArchivePreset.SelectedIndex = 1; // General
                        else
                            this.comboBoxModArchivePreset.SelectedIndex = 4; // Sound FX
                        break;
                    case Mod.ArchiveFormat.Textures:
                        if (isCompressed)
                            this.comboBoxModArchivePreset.SelectedIndex = 2; // Textures
                        else
                            this.comboBoxModArchivePreset.SelectedIndex = 3; // Uncompressed textures
                        break;
                    default:
                        this.comboBoxModArchivePreset.SelectedIndex = 0; // Please select
                        break;
                }
            }

            // Bulk?
            this.checkBoxModDetailsEnabled.Visible = !this.bulk;
            this.labelModName.Visible = !this.bulk;
            this.textBoxModName.Visible = !this.bulk;
            this.labelModFolderName.Visible = !this.bulk;
            this.textBoxModFolderName.Visible = !this.bulk;

            this.buttonModOpenFolder.Visible = !this.bulk;
            this.buttonModRepairDDS.Visible = !this.bulk;
            this.buttonModUnfreeze.Enabled = !this.bulk;

            /*this.separator1.Visible = !this.bulk;
            this.separator2.Visible = !this.bulk;*/
            this.progressBar1.Visible = !this.bulk;

            this.labelModDetailsBulkFrozenModsWarning.Visible = this.bulk;
            if (this.bulk)
            {
                this.labelModArchiveName.Visible = false;
                this.textBoxModArchiveName.Visible = false;
            }

            this.groupBoxModDetailsDetails.Visible = !this.bulk;

            isUpdatingUI = false;
        }

        private void UpdateModFolder()
        {
            this.changedMod.ManagedFolder = ManagedMods.Instance.RenameManagedFolder(this.changedMod.ManagedFolder, this.textBoxModFolderName.Text);
        }



        /*
         * Event handler:
         */


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, this.panel1.ClientRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }

        private void buttonModOpenFolder_Click(object sender, EventArgs e)
        {
            String path = this.changedMod.GetManagedPath();
            if (Directory.Exists(path))
                Utils.OpenExplorer(path);
            else
                MsgBox.Get("modDirNotExist").FormatText(path).Show(MessageBoxIcon.Error);
        }



        /*
         * Close window, Cancel, OK, Apply:
         */

        private void FormModDetails_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;

                // Closing the window is treated like "Cancel":
                this.buttonModDetailsCancel_Click(null, null);
                //this.formMods.ModDetailsClosed();
                //Hide();
            }
        }

        private void buttonModDetailsOK_Click(object sender, EventArgs e)
        {
            UpdateModFolder();
            this.formMods.ModDetailsFeedback(this.changedMod);
            this.formMods.ModDetailsClosed();
            Hide();
        }

        private void buttonModDetailsCancel_Click(object sender, EventArgs e)
        {
            this.formMods.ModDetailsClosed();
            Hide();
        }

        private void buttonModDetailsApply_Click(object sender, EventArgs e)
        {
            UpdateModFolder();
            this.formMods.ModDetailsFeedback(this.changedMod);
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
                    this.changedMod.Type = Mod.FileType.BundledBA2;
                    this.changedMod.freeze = false;
                    break;
                case 1: // Separate *.ba2 archive
                    this.changedMod.Type = Mod.FileType.SeparateBA2;
                    break;
                case 2: // Loose files
                    this.changedMod.Type = Mod.FileType.Loose;
                    this.changedMod.freeze = false;
                    break;
            }
            UpdateUI();
        }

        private void comboBoxModArchiveFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdatingUI)
                return;
            switch (this.comboBoxModArchivePreset.SelectedIndex)
            {
                case 0: // Please select
                    /*this.changedMod.Format = Mod.ArchiveFormat.Auto;
                    this.changedMod.Compression = Archive2.Compression.Default;*/
                    break;
                case 1: // General
                    this.changedMod.Format = Mod.ArchiveFormat.General;
                    this.changedMod.Compression = Archive2.Compression.Default;
                    break;
                case 2: // Textures
                    this.changedMod.Format = Mod.ArchiveFormat.Textures;
                    this.changedMod.Compression = Archive2.Compression.Default;
                    break;
                case 3: // Uncompressed textures
                    this.changedMod.Format = Mod.ArchiveFormat.Textures;
                    this.changedMod.Compression = Archive2.Compression.None;
                    break;
                case 4: // Audio
                    this.changedMod.Format = Mod.ArchiveFormat.General;
                    this.changedMod.Compression = Archive2.Compression.None;
                    break;
            }
            UpdateUI();
        }

        private void buttonModPickRootDir_Click(object sender, EventArgs e)
        {
            this.folderBrowserDialogPickRootDir.SelectedPath = Path.Combine(ManagedMods.Instance.GamePath, "Data");
            if (this.folderBrowserDialogPickRootDir.ShowDialog() == DialogResult.OK)
            {
                String rootFolder = Utils.MakeRelativePath(ManagedMods.Instance.GamePath, this.folderBrowserDialogPickRootDir.SelectedPath);
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
                this.changedMod.Title = this.textBoxModName.Text;
        }

        private void checkBoxModDetailsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            this.changedMod.isEnabled = this.checkBoxModDetailsEnabled.Checked;
        }

        private void textBoxModFolderName_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxFreezeArchive_CheckedChanged(object sender, EventArgs e)
        {
            this.changedMod.freeze = this.checkBoxFreezeArchive.Checked;
        }

        /*
         * Presets
         */

        private void radioButtonSeparateArchiveGeneral_CheckedChanged(object sender, EventArgs e)
        {
            // Compressed, General format
            if (isUpdatingUI)
                return;

            if (!this.changedMod.isFrozen() && this.changedMod.Type == Mod.FileType.SeparateBA2)
            {
                this.changedMod.Compression = Archive2.Compression.Default;
                this.changedMod.Format = Mod.ArchiveFormat.General;

                UpdateUI();
            }
        }

        private void radioButtonSeparateArchiveTextures_CheckedChanged(object sender, EventArgs e)
        {
            // Compressed, DDS format
            if (isUpdatingUI)
                return;

            if (!this.changedMod.isFrozen() && this.changedMod.Type == Mod.FileType.SeparateBA2)
            {
                this.changedMod.Compression = Archive2.Compression.Default;
                this.changedMod.Format = Mod.ArchiveFormat.Textures;

                UpdateUI();
            }
        }

        private void radioButtonSeparateArchiveSounds_CheckedChanged(object sender, EventArgs e)
        {
            // Uncompressed, General format
            if (isUpdatingUI)
                return;

            if (!this.changedMod.isFrozen() && this.changedMod.Type == Mod.FileType.SeparateBA2)
            {
                this.changedMod.Compression = Archive2.Compression.None;
                this.changedMod.Format = Mod.ArchiveFormat.General;

                UpdateUI();
            }
        }


        /*
         * Actions
         */

        private void buttonModUnfreeze_Click(object sender, EventArgs e)
        {
            this.labelModDetailsStatus.Visible = true;
            this.labelModDetailsStatus.ForeColor = SystemColors.HotTrack;
            Thread thread = new Thread(() =>
            {
                this.changedMod.Unfreeze(
                    (text, percent) =>
                    {
                        Invoke(() => SetProgress(text, percent));
                    },
                    (success) =>
                    {
                        Invoke(() =>
                        {
                            this.formMods.ModDetailsFeedback(this.changedMod);
                            UpdateUI();
                            if (success)
                                SetDone();
                            else
                                SetFailed();
                        });
                    }
                );
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void buttonModRepairDDS_Click(object sender, EventArgs e)
        {
            DialogResult res = MsgBox.Get("modsRepairDDSQuestion").Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.labelModDetailsStatus.Visible = true;
                this.labelModDetailsStatus.ForeColor = SystemColors.HotTrack;
                Thread thread = new Thread(() => {
                    this.changedMod.RepairDDSFiles(
                        (text, percent) => {
                            Invoke(() => SetProgress($"{text} ({percent}%)", percent));
                        }, (corruptFiles) => {
                            Invoke(() => RepairDone(corruptFiles));
                        }
                    );
                });
                thread.IsBackground = true;
                thread.Start();
            }
        }

        private void RepairDone(List<String> corruptFiles)
        {
            SetDone();
            if (corruptFiles.Count > 0)
            {
                Log log = new Log(Log.GetFilePath("repair.log.txt"));
                log.WriteLine($"Some textures couldn't be repaired for mod \"{this.changedMod.Title}\":");
                foreach (String path in corruptFiles)
                    log.WriteLine(path);
                log.WriteLine("");

                this.labelModDetailsStatus.ForeColor = Color.Red;
                this.labelModDetailsStatus.Text = $"{corruptFiles.Count} unrestorable files. See repair.log.txt";
            }
        }

        private void SetDone()
        {
            this.labelModDetailsStatus.Visible = true;
            this.labelModDetailsStatus.ForeColor = Color.Green;
            this.labelModDetailsStatus.Text = "Done.";
            this.progressBar1.Value = 100;
            this.progressBar1.Style = ProgressBarStyle.Continuous;
        }

        private void SetFailed()
        {
            this.labelModDetailsStatus.Visible = true;
            this.labelModDetailsStatus.ForeColor = Color.Red;
            this.labelModDetailsStatus.Text = "Failed.";
            this.progressBar1.Value = 100;
            this.progressBar1.Style = ProgressBarStyle.Continuous;
        }

        private void SetProgress(String text, int percent)
        {
            this.labelModDetailsStatus.Text = text;
            if (percent >= 0)
            {
                this.progressBar1.Value = Utils.Clamp(percent, 0, 100);
                this.progressBar1.Style = ProgressBarStyle.Continuous;
            }
            else
            {
                this.progressBar1.Style = ProgressBarStyle.Marquee;
            }
        }

        private void Invoke(Action func)
        {
            this.labelModDetailsStatus.Invoke(func);
        }
    }
}
