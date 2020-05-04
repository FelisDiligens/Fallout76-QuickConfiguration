using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            ComboBoxContainer.Add("ModArchiveFormat", new ComboBoxContainer(
                this.comboBoxModArchiveFormat,
                new String[] {
                    "Auto-detect",
                    "General",
                    "Textures (*.dds files)"
                }
            ));
        }

        public void UpdateUI(Mod mod = null)
        {
            this.labelModDetailRepairStatus.Visible = false;

            if (mod != null)
                this.changedMod = mod.CreateCopy();

            this.checkBoxModDetailsEnabled.Checked = this.changedMod.isEnabled;

            this.Text = "Edit " + this.changedMod.Title;
            this.textBoxModName.Text = this.changedMod.Title;
            this.textBoxModFolderName.Text = this.changedMod.ManagedFolder;
            this.textBoxModRootDir.Text = this.changedMod.RootFolder;

            switch (this.changedMod.Format)
            {
                case Mod.ArchiveFormat.General:
                    this.comboBoxModArchiveFormat.SelectedIndex = 1;
                    break;
                case Mod.ArchiveFormat.Textures:
                    this.comboBoxModArchiveFormat.SelectedIndex = 2;
                    break;
                default:
                    this.comboBoxModArchiveFormat.SelectedIndex = 0;
                    break;
            }

            switch (this.changedMod.Type)
            {
                case Mod.FileType.BundledBA2:
                    this.comboBoxModInstallAs.SelectedIndex = 0;

                    //this.checkBoxModBA2Compression.Checked = ManagedMods.Instance.bundledCompression != Archive2.Compression.None;
                    //this.checkBoxModBA2Compression.Checked = ManagedMods.Instance.bundledTexturesCompression != Archive2.Compression.None;
                    this.checkBoxModBA2Compression.Visible = false;

                    //this.textBoxModArchiveName.Text = "";
                    this.textBoxModArchiveName.Visible = false;
                    this.labelModArchiveName.Visible = false;

                    this.labelModInstallInto.Visible = false;
                    this.textBoxModRootDir.Visible = false;
                    this.buttonModPickRootDir.Visible = false;

                    this.comboBoxModArchiveFormat.Visible = false;
                    this.labelModArchiveFormat.Visible = false;
                    break;
                case Mod.FileType.SeparateBA2:
                    this.comboBoxModInstallAs.SelectedIndex = 1;

                    this.checkBoxModBA2Compression.Checked = this.changedMod.Compression != Archive2.Compression.None;
                    this.checkBoxModBA2Compression.Visible = true;

                    this.comboBoxModArchiveFormat.Visible = true;
                    this.labelModArchiveFormat.Visible = true;

                    this.textBoxModArchiveName.Text = this.changedMod.ArchiveName;
                    this.textBoxModArchiveName.Visible = true;
                    this.labelModArchiveName.Visible = true;

                    this.labelModInstallInto.Visible = false;
                    this.textBoxModRootDir.Visible = false;
                    this.buttonModPickRootDir.Visible = false;
                    break;
                case Mod.FileType.Loose:
                    this.comboBoxModInstallAs.SelectedIndex = 2;
                    this.textBoxModArchiveName.Visible = false;
                    this.labelModArchiveName.Visible = false;
                    this.checkBoxModBA2Compression.Visible = false;
                    this.comboBoxModArchiveFormat.Visible = false;
                    this.labelModArchiveFormat.Visible = false;

                    this.labelModInstallInto.Visible = true;
                    this.textBoxModRootDir.Visible = true;
                    this.buttonModPickRootDir.Visible = true;
                    break;
            }
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
            switch (this.comboBoxModInstallAs.SelectedIndex)
            {
                case 0: // Bundled *.ba2 archive
                    this.changedMod.Type = Mod.FileType.BundledBA2;
                    break;
                case 1: // Separate *.ba2 archive
                    this.changedMod.Type = Mod.FileType.SeparateBA2;
                    break;
                case 2: // Loose files
                    this.changedMod.Type = Mod.FileType.Loose;
                    break;
            }
            UpdateUI();
        }

        private void comboBoxModArchiveFormat_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.comboBoxModArchiveFormat.SelectedIndex)
            {
                case 0: // Auto-detect
                    this.changedMod.Format = Mod.ArchiveFormat.Auto;
                    break;
                case 1: // General
                    this.changedMod.Format = Mod.ArchiveFormat.General;
                    break;
                case 2: // DDS
                    this.changedMod.Format = Mod.ArchiveFormat.Textures;
                    break;
            }
            UpdateUI();
        }

        private void checkBoxModBA2Compression_CheckedChanged(object sender, EventArgs e)
        {
            if (this.changedMod.Type == Mod.FileType.SeparateBA2)
                this.changedMod.Compression = checkBoxModBA2Compression.Checked ? Archive2.Compression.Default : Archive2.Compression.None;
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
            if (textBoxModArchiveName.Focused && Directory.Exists(this.textBoxModRootDir.Text))
                this.changedMod.RootFolder = this.textBoxModRootDir.Text;
        }

        private void textBoxModArchiveName_TextChanged(object sender, EventArgs e)
        {
            if (textBoxModArchiveName.Focused)
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

        private void buttonModRepairDDS_Click(object sender, EventArgs e)
        {
            DialogResult res = MsgBox.Get("modsRepairDDSQuestion").Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                this.labelModDetailRepairStatus.Visible = true;
                this.labelModDetailRepairStatus.ForeColor = SystemColors.HotTrack;
                Thread thread = new Thread(() => {
                    this.changedMod.RepairDDSFiles(
                        (text, percent) => {
                            Invoke(() => SetLabel($"{text} ({percent}%)"));
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
            if (corruptFiles.Count > 0)
            {
                Log log = new Log("repair.log.txt");
                foreach (String path in corruptFiles)
                    log.WriteLine(path);
                log.WriteLine("");

                this.labelModDetailRepairStatus.ForeColor = Color.Red;
                this.labelModDetailRepairStatus.Text = $"{corruptFiles.Count} unrestorable files. See repair.log.txt";
            }
            else
            {
                this.labelModDetailRepairStatus.ForeColor = Color.Green;
                this.labelModDetailRepairStatus.Text = "Done.";
            }
        }

        private void SetLabel(String text)
        {
            this.labelModDetailRepairStatus.Text = text;
        }

        private void Invoke(Action func)
        {
            this.labelModDetailRepairStatus.Invoke(func);
        }
    }
}
