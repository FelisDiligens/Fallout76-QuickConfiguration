using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini
{
    public partial class FormMods : Form
    {
        private ManagedMods mods = new ManagedMods();
        public String gamePathKey;

        public FormMods()
        {
            InitializeComponent();

            this.gamePathKey = "sGamePath" + (( new string[] { "", "BethesdaNet", "Steam" } )[IniFiles.Instance.GetInt(IniFile.Config, "Preferences", "uGameEdition", 0)]);

            String archive2Path = IniFiles.Instance.GetString(IniFile.Config, "Preferences", "sArchive2Path", "");
            String gamePath = IniFiles.Instance.GetString(IniFile.Config, "Preferences", this.gamePathKey, "");
            bool nwMode = IniFiles.Instance.GetBool(IniFile.Config, "Mods", "bDisableMods", false);
            if (archive2Path.Length > 0)
            {
                textBoxArchive2Path.Text = archive2Path;
                Archive2.Archive2Path = archive2Path;
            }
            if (gamePath.Length > 0)
            {
                textBoxGamePath.Text = gamePath;
                this.mods.GamePath = gamePath;
            }
            this.mods.nuclearWinterMode = nwMode;

            this.FormClosing += this.FormMods_FormClosing;

            this.checkedListBoxMods.ItemCheck += checkedListBoxMods_ItemCheck;
            this.checkedListBoxMods.SelectedIndexChanged += checkedListBoxMods_SelectedIndexChanged;
            this.textBoxModName.TextChanged += textBoxModName_TextChanged;
            this.checkBoxModsCheckAll.CheckedChanged += checkBoxModsCheckAll_CheckedChanged;
            // this.buttonModAddArchive.Click += this.buttonModAddArchive_Click;
            // this.buttonModAddFolder.Click += this.buttonModAddFolder_Click;
            this.buttonModMoveUp.Click += this.buttonModMoveUp_Click;
            this.buttonModMoveDown.Click += this.buttonModMoveDown_Click;
            this.buttonPickArchive2Path.Click += buttonPickArchive2Path_Click;
            this.buttonPickGamePath.Click += buttonPickGamePath_Click;

            /*
             * Drag&Drop
             */
            this.checkedListBoxMods.AllowDrop = true;
            this.checkedListBoxMods.DragEnter += new DragEventHandler(checkedListBoxMods_DragEnter);
            this.checkedListBoxMods.DragDrop += new DragEventHandler(checkedListBoxMods_DragDrop);

            mods.Load();
            UpdateModsUI();
        }

        public void ChangeGameEdition(GameEdition gameEdition)
        {
            this.gamePathKey = "sGamePath" + ((new string[] { "", "BethesdaNet", "Steam" })[(int)gameEdition]);
            String gamePath = IniFiles.Instance.GetString(IniFile.Config, "Preferences", this.gamePathKey, "");
            if (Directory.Exists(gamePath))
                this.mods.GamePath = gamePath;
            else
                this.mods = new ManagedMods();
            textBoxGamePath.Text = gamePath;
            mods.Load();
            UpdateModsUI();
        }

        public void UpdateModsUI()
        {
            if (this.mods.isDeploymentNecessary())
                DisplayDeploymentNecessary();
            else
                DisplayAllDone();

            this.checkedListBoxMods.Items.Clear();
            for (int i = 0; i < mods.Mods.Count; i++)
            {
                this.checkedListBoxMods.Items.Add(mods.Mods[i].Title, mods.isModEnabled(i));
            }

            if (this.checkedListBoxMods.SelectedIndex < 0 && !this.textBoxModName.Focused)
                HideModDetails();

            this.checkBoxModsNWMode.Checked = this.mods.nuclearWinterMode;

            this.checkBoxModsBundledBA2Compression.Checked = this.mods.bundledCompression != Archive2.Compression.None;
            this.checkBoxModsBundledTexturesBA2Compression.Checked = this.mods.bundledTexturesCompression != Archive2.Compression.None;
        }

        private void ShowModDetails(Mod mod)
        {
            foreach (Control control in this.groupBoxModEdit.Controls)
                control.Visible = true;
            this.groupBoxModEdit.Enabled = true;

            this.textBoxModName.Text = mod.Title;
            this.textBoxModRootDir.Text = mod.RootFolder;

            switch (mod.Type)
            {
                case Mod.FileType.BundledBA2:
                    this.radioButtonModBA2Archive.Checked = true;

                    this.groupBoxBA2.Enabled = false;
                    this.checkBoxModBA2Compression.Checked = mods.bundledCompression != Archive2.Compression.None;
                    this.radioButtonModBA2GeneralFormat.Checked = true;
                    this.textBoxModArchiveName.Text = "bundled.ba2";
                    break;
                case Mod.FileType.BundledBA2Textures:
                    this.radioButtonModBA2ArchiveTextures.Checked = true;

                    this.groupBoxBA2.Enabled = false;
                    this.checkBoxModBA2Compression.Checked = mods.bundledTexturesCompression != Archive2.Compression.None;
                    this.radioButtonModBA2DDSFormat.Checked = true;
                    this.textBoxModArchiveName.Text = "bundled_textures.ba2";
                    break;
                case Mod.FileType.SeparateBA2:
                    this.radioButtonModSeparateBA2.Checked = true;

                    this.groupBoxBA2.Enabled = true;
                    this.checkBoxModBA2Compression.Checked = mod.Compression != Archive2.Compression.None;
                    if (mod.Format == Archive2.Format.DDS)
                        this.radioButtonModBA2DDSFormat.Checked = true;
                    else
                        this.radioButtonModBA2GeneralFormat.Checked = true;
                    this.textBoxModArchiveName.Text = mod.ArchiveName;
                    break;
                case Mod.FileType.Loose:
                    this.radioButtonModLoose.Checked = true;

                    this.groupBoxBA2.Enabled = false;
                    this.checkBoxModBA2Compression.Checked = false;
                    this.radioButtonModBA2GeneralFormat.Checked = true;
                    this.textBoxModArchiveName.Text = "";
                    break;
            }

        }

        private void HideModDetails()
        {
            foreach (Control control in this.groupBoxModEdit.Controls)
                    control.Visible = false;
            this.groupBoxModEdit.Enabled = false;
        }

        private void EnableUI()
        {
            foreach (Control control in this.Controls)
                if (control.Name != "progressBarMods" && !control.Name.StartsWith("label"))
                    control.Enabled = true;
        }

        private void DisableUI()
        {
            foreach (Control control in this.Controls)
                if (control.Name != "progressBarMods" && !control.Name.StartsWith("label"))
                    control.Enabled = false;
        }



        /*
         * Event handler
         */

        private void FormMods_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                if (this.buttonModsDeploy.Enabled && (!this.mods.isDeploymentNecessary() || MsgBox.ShowID("modsOnCloseDeploymentNecessary", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    Hide();
            }
        }

        // Drag & Drop
        void checkedListBoxMods_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void checkedListBoxMods_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string filePath in files)
            {
                Console.WriteLine("Drag&Drop: " + filePath);

                Thread thread = null;
                if (Directory.Exists(filePath))
                    thread = new Thread(() => InstallModFolder(filePath));
                else if ((new String[] { ".ba2", ".zip", ".rar", ".7z", ".tar", ".tar.gz", ".gz" }).Contains(Path.GetExtension(filePath)))
                    thread = new Thread(() => InstallModArchive(filePath));
                else
                    MsgBox.Get("modsArchiveTypeNotSupported").FormatText(Path.GetExtension(filePath)).Show(MessageBoxIcon.Error);
                if (thread != null)
                {
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
        }


        // Pick game path
        private void buttonPickGamePath_Click(object sender, EventArgs e)
        {
            if (this.mods.isDeploymentNecessary())
            {
                MsgBox.ShowID("modsDeploymentNecessary");
                return;
            }
            if (this.openFileDialogGamePath.ShowDialog() == DialogResult.OK)
            {
                String path = Path.GetDirectoryName(this.openFileDialogGamePath.FileName); // We want the path where Fallout76.exe resides.
                if (Directory.Exists(Path.Combine(path, "Data")))
                {
                    this.textBoxGamePath.Text = path;
                    this.mods.GamePath = path;
                    IniFiles.Instance.Set(IniFile.Config, "Preferences", this.gamePathKey, path);
                    IniFiles.Instance.SaveConfig();
                    mods.Load();
                    UpdateModsUI();
                }
                else
                    MsgBox.ShowID("modsGamePathInvalid");
            }
        }

        // Game path textbox changed:
        private void textBoxGamePath_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxGamePath.Focused)
            {
                if (this.mods.isDeploymentNecessary())
                {
                    if (this.textBoxGamePath.Text != this.mods.GamePath)
                        this.textBoxGamePath.Text = this.mods.GamePath;
                    return;
                }
                else if (Directory.Exists(Path.Combine(this.textBoxGamePath.Text, "Data")))
                {
                    this.mods.GamePath = this.textBoxGamePath.Text;
                    IniFiles.Instance.Set(IniFile.Config, "Preferences", this.gamePathKey, this.textBoxGamePath.Text);
                    IniFiles.Instance.SaveConfig();
                    mods.Load();
                    UpdateModsUI();
                    this.textBoxGamePath.ForeColor = Color.Black;
                    this.textBoxGamePath.BackColor = Color.White;
                }
                else
                {
                    this.textBoxGamePath.ForeColor = Color.White;
                    this.textBoxGamePath.BackColor = Color.Red;
                }
            }
        }

        // Pick Archive2 patch
        private void buttonPickArchive2Path_Click(object sender, EventArgs e)
        {
            if (this.openFileDialogArchive2Path.ShowDialog() == DialogResult.OK)
            {
                String path = this.openFileDialogArchive2Path.FileName;
                this.textBoxArchive2Path.Text = path;
                Archive2.Archive2Path = path;
                IniFiles.Instance.Set(IniFile.Config, "Preferences", "sArchive2Path", path);
                IniFiles.Instance.SaveConfig();
            }
        }

        // Archive2 path textbox changed:
        private void textBoxArchive2Path_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxArchive2Path.Focused)
            {
                Archive2.Archive2Path = this.textBoxArchive2Path.Text;
                IniFiles.Instance.Set(IniFile.Config, "Preferences", "sArchive2Path", Archive2.Archive2Path);
                // IniFiles.Instance.SaveConfig();
            }
        }

        // Move up
        private void buttonModMoveUp_Click(object sender, EventArgs e)
        {
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            index = mods.MoveModUp(index);
            UpdateModsUI();
            this.checkedListBoxMods.SelectedIndex = index;
        }

        // Move down
        private void buttonModMoveDown_Click(object sender, EventArgs e)
        {
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            index = mods.MoveModDown(index);
            UpdateModsUI();
            this.checkedListBoxMods.SelectedIndex = index;
        }

        // Check/uncheck all
        private void checkBoxModsCheckAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.mods.Mods.Count; i++)
            {
                this.mods.ToggleMod(i, this.checkBoxModsCheckAll.Checked);
            }
            UpdateModsUI();
        }

        // CheckedList: Mod has been enabled/disabled
        private void checkedListBoxMods_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            CheckState st = e.NewValue;
            if (st == CheckState.Checked)
                this.mods.EnableMod(index);
            else if (st == CheckState.Unchecked)
                this.mods.DisableMod(index);
            UpdateModsUI();
            this.checkedListBoxMods.SelectedIndex = index;
        }

        // Mod name changed
        private void textBoxModName_TextChanged(object sender, EventArgs e)
        {
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            this.mods.Mods[index].Title = this.textBoxModName.Text;
            UpdateModsUI();
            this.checkedListBoxMods.SelectedIndex = index;
        }

        // CheckedList: Show mod details, when mod was selected
        private void checkedListBoxMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.textBoxModName.Focused)
                return;
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            ShowModDetails(this.mods.Mods[index]);
        }

        // Add mod archive
        private void fromArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialogMod.ShowDialog() == DialogResult.OK)
            {
                Thread thread = new Thread(() => InstallModArchive(this.openFileDialogMod.FileName));
                thread.IsBackground = true;
                thread.Start();
            }
        }
        private void buttonModAddArchive_Click(object sender, EventArgs e)
        {
            
        }

        // Add mod folder
        private void fromFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialogMod.ShowDialog() == DialogResult.OK)
            {
                Thread thread = new Thread(() => InstallModFolder(this.folderBrowserDialogMod.SelectedPath));
                thread.IsBackground = true;
                thread.Start();
            }
        }
        private void buttonModAddFolder_Click(object sender, EventArgs e)
        {

        }

        // Deploy mods:
        private void buttonModsDeploy_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(Deploy);
            thread.IsBackground = true;
            thread.Start();
        }
        private void deployToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonModsDeploy_Click(sender, e);
        }

        // Open mod folder
        private void buttonModOpenFolder_Click(object sender, EventArgs e)
        {
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            String path = this.mods.GetModPath(index);
            if (Directory.Exists(path))
                Utils.OpenExplorer(path);
            else
                MsgBox.Get("modDirNotExist").FormatText(path).Show(MessageBoxIcon.Error);
        }

        // Remove mod
        private void buttonModRemove_Click(object sender, EventArgs e)
        {
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            DialogResult res = MsgBox.Get("modsDeleteBtn").FormatText(mods.Mods[index].Title).Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Thread thread = new Thread(() => DeleteMod(index));
                thread.IsBackground = true;
                thread.Start();
            }
        }

        // Install type changed: Bundled *.ba2 archive (General)
        private void radioButtonModBA2Archive_CheckedChanged(object sender, EventArgs e)
        {
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            if (this.radioButtonModBA2Archive.Checked)
            {
                this.mods.Mods[index].Type = Mod.FileType.BundledBA2;
                this.mods.Mods[index].RootFolder = "Data";
                /* 
                // Disable "Install Into: [    ] [..]"
                this.textBoxModRootDir.Text = "Data";
                this.textBoxModRootDir.Enabled = false;
                this.buttonModPickRootDir.Enabled = false;
                this.labelModInstallInto.Enabled = false;

                // Disable BA2 settings
                this.groupBoxBA2.Enabled = false;
                this.checkBoxModBA2Compression.Checked = this.checkBoxModsBundledBA2Compression.Checked;
                this.radioButtonModBA2GeneralFormat.Checked = true; */
                this.ShowModDetails(this.mods.Mods[index]);
            }
        }

        // Install type changed: Bundled *.ba2 archive (Textures)
        private void radioButtonModBA2ArchiveTextures_CheckedChanged(object sender, EventArgs e)
        {
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            if (this.radioButtonModBA2ArchiveTextures.Checked)
            {
                this.mods.Mods[index].Type = Mod.FileType.BundledBA2Textures;
                this.mods.Mods[index].RootFolder = "Data";

                /* 
                // Disable "Install Into: [    ] [..]"
                this.textBoxModRootDir.Text = "Data";
                this.textBoxModRootDir.Enabled = false;
                this.buttonModPickRootDir.Enabled = false;
                this.labelModInstallInto.Enabled = false;

                // Disable BA2 settings
                this.groupBoxBA2.Enabled = false;
                this.checkBoxModBA2Compression.Checked = this.checkBoxModsBundledTexturesBA2Compression.Checked;
                this.radioButtonModBA2DDSFormat.Checked = true;*/
                this.ShowModDetails(this.mods.Mods[index]);
            }
        }

        // Install type changed: Separate *.ba2 archive
        private void radioButtonModSeparateBA2_CheckedChanged(object sender, EventArgs e)
        {
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            if (this.radioButtonModSeparateBA2.Checked)
            {
                this.mods.Mods[index].Type = Mod.FileType.SeparateBA2;
                this.mods.Mods[index].RootFolder = "Data";
                /* 
                // Disable "Install Into: [    ] [..]"
                this.textBoxModRootDir.Text = "Data";
                this.textBoxModRootDir.Enabled = false;
                this.buttonModPickRootDir.Enabled = false;
                this.labelModInstallInto.Enabled = false;

                // Enable BA2 settings
                this.groupBoxBA2.Enabled = true;
                this.checkBoxModBA2Compression.Checked = this.mods.Mods[index].Compression != Archive2.Compression.None;
                if (this.mods.Mods[index].Format == Archive2.Format.DDS)
                    this.radioButtonModBA2DDSFormat.Checked = true;
                else
                    this.radioButtonModBA2GeneralFormat.Checked = true; */

                this.ShowModDetails(this.mods.Mods[index]);
            }
        }

        // Install type changed: Loose files
        private void radioButtonModLoose_CheckedChanged(object sender, EventArgs e)
        {
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            if (this.radioButtonModLoose.Checked)
            {
                this.mods.Mods[index].Type = Mod.FileType.Loose;
                /* 
                // Enable "Install Into: [    ] [..]"
                this.textBoxModRootDir.Enabled = true;
                this.buttonModPickRootDir.Enabled = true;
                this.labelModInstallInto.Enabled = true;

                // Disable BA2 settings
                this.groupBoxBA2.Enabled = false;
                this.checkBoxModBA2Compression.Checked = false;
                this.radioButtonModBA2GeneralFormat.Checked = true; */
                this.ShowModDetails(this.mods.Mods[index]);
            }
        }

        /* Separate BA2 archive: [ ] Compress it */
        private void checkBoxModBA2Compression_CheckedChanged(object sender, EventArgs e)
        {
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            this.mods.Mods[index].Compression = checkBoxModBA2Compression.Checked ? Archive2.Compression.Default : Archive2.Compression.None;
        }

        /* Separate BA2 archive: Format set to General */
        private void radioButtonModBA2GeneralFormat_CheckedChanged(object sender, EventArgs e)
        {
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            if (radioButtonModBA2GeneralFormat.Checked)
                this.mods.Mods[index].Format = Archive2.Format.General;
        }

        /* Separate BA2 archive: Format set to DDS */
        private void radioButtonModBA2DDSFormat_CheckedChanged(object sender, EventArgs e)
        {
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            if (radioButtonModBA2DDSFormat.Checked)
                this.mods.Mods[index].Format = Archive2.Format.DDS;
        }

        /* Separate BA2 archive: Name changed */
        private void textBoxModArchiveName_TextChanged(object sender, EventArgs e)
        {
            if (!textBoxModArchiveName.Focused)
                return;
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            this.mods.Mods[index].ArchiveName = this.textBoxModArchiveName.Text;
        }

        // [ ] Compress bundled.ba2
        private void checkBoxModsBundledBA2Compression_CheckedChanged(object sender, EventArgs e)
        {
            this.mods.bundledCompression = checkBoxModsBundledBA2Compression.Checked ? Archive2.Compression.Default : Archive2.Compression.None;
        }

        // [ ] Compress bundled_textures.ba2
        private void checkBoxModsBundledTexturesBA2Compression_CheckedChanged(object sender, EventArgs e)
        {
            this.mods.bundledTexturesCompression = checkBoxModsBundledTexturesBA2Compression.Checked ? Archive2.Compression.Default : Archive2.Compression.None;
        }

        // [ ] Nuclear Winter Mode
        private void checkBoxModsNWMode_CheckedChanged(object sender, EventArgs e)
        {
            this.mods.nuclearWinterMode = this.checkBoxModsNWMode.Checked;
            IniFiles.Instance.Set(IniFile.Config, "Mods", "bDisableMods", this.mods.nuclearWinterMode);
        }

        // Pick Mod Root Folder:
        private void buttonModPickRootDir_Click(object sender, EventArgs e)
        {
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            this.folderBrowserDialogPickRootDir.SelectedPath = Path.Combine(this.mods.GamePath, "Data");
            if (this.folderBrowserDialogPickRootDir.ShowDialog() == DialogResult.OK)
            {
                String rootFolder = Utils.MakeRelativePath(this.mods.GamePath, this.folderBrowserDialogPickRootDir.SelectedPath);
                this.textBoxModRootDir.Text = rootFolder;
                this.mods.Mods[index].RootFolder = rootFolder;
            }
        }

        // Root folder changed:
        private void textBoxModRootDir_TextChanged(object sender, EventArgs e)
        {
            int index = this.checkedListBoxMods.SelectedIndex;
            if (index < 0)
                return;
            if (this.textBoxModRootDir.Focused)
                this.mods.Mods[index].RootFolder = this.textBoxModRootDir.Text;
        }

        // Show conflicting files:
        private void showConflictingFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String[] conflictingFiles = this.mods.GetConflictingFiles();
            if (conflictingFiles.Length == 0)
            {
                MsgBox.ShowID("modsNoConflictingFiles", MessageBoxIcon.Information);
                return;
            }
            String tempFile = Path.GetTempFileName();
            using (StreamWriter f = File.AppendText(tempFile))
            {
                foreach (String conflictingFile in conflictingFiles)
                    f.WriteLine(conflictingFile);
            }
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "notepad.exe",
                Arguments = tempFile
            };
            Process.Start(startInfo);
        }

        // Import installed mods:
        private void toolStripMenuItemModsImport_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowID("modsImportQuestion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.mods.ImportInstalledMods();
                this.UpdateModsUI();
            }
        }



        /*
         * These methods should be called using a Thread.
         */

        private void InstallModArchive(String path)
        {
            Invoke(() => DisableUI());
            Invoke(() => ProgressBarMarquee());
            this.mods.InstallModArchive(path,
                (text, percent) => {
                    Invoke(() => Display(text));
                },
                () => {
                    Invoke(() => ProgressBarContinuous(100));
                    Invoke(() => HideLabel());
                    Invoke(() => EnableUI());
                    Invoke(() => UpdateModsUI());
                    Invoke(() => this.checkedListBoxMods.SelectedIndex = this.mods.Mods.Count - 1);
                }
            );
        }

        private void InstallModFolder(String path)
        {
            Invoke(() => DisableUI());
            Invoke(() => ProgressBarContinuous(0));
            this.mods.InstallModFolder(path,
                (text, percent) => {
                    Invoke(() => Display(text));
                    Invoke(() => { if (percent >= 0) { ProgressBarContinuous(percent); } else { ProgressBarMarquee(); } });
                },
                () => {
                    Invoke(() => ProgressBarContinuous(100));
                    Invoke(() => HideLabel());
                    Invoke(() => EnableUI());
                    Invoke(() => UpdateModsUI());
                    Invoke(() => this.checkedListBoxMods.SelectedIndex = this.mods.Mods.Count - 1);
                }
            );
        }

        private void DeleteMod(int index)
        {
            Invoke(() => DisableUI());
            Invoke(() => ProgressBarMarquee());
            mods.DeleteMod(index, () => {
                Invoke(() => ProgressBarContinuous(100));
                Invoke(() => EnableUI());
                Invoke(() => UpdateModsUI());
            });
        }

        private void Deploy()
        {
            Invoke(() => DisableUI());
            Invoke(() => ProgressBarContinuous(0));
            Invoke(() => Display("Deploying..."));
            mods.Deploy(
                (text, percent) => {
                    Invoke(() => Display(text));
                    Invoke(() => { if (percent >= 0) { ProgressBarContinuous(percent); } else { ProgressBarMarquee(); } });
                },
                () => {
                    Invoke(() => ProgressBarContinuous(100));
                    Invoke(() => DisplayAllDone());
                    Invoke(() => EnableUI());
                }
            );
        }

        private void Invoke(Action func)
        {
            this.progressBarMods.Invoke(func);
        }

        private void ProgressBarMarquee()
        {
            this.progressBarMods.Style = ProgressBarStyle.Marquee;
            this.progressBarMods.MarqueeAnimationSpeed = 15;
        }

        private void ProgressBarContinuous(int value)
        {
            this.progressBarMods.Style = ProgressBarStyle.Continuous;
            this.progressBarMods.Value = value;
        }

        private void HideLabel()
        {
            this.labelModsDeploy.Visible = false;
        }

        private void DisplayDeploymentNecessary()
        {
            this.labelModsDeploy.Visible = true;
            this.labelModsDeploy.ForeColor = Color.Crimson;
            this.labelModsDeploy.Text = Translation.localizedStrings["modsDeploymentNecessary"];
        }

        private void DisplayAllDone()
        {
            this.labelModsDeploy.Visible = true;
            this.labelModsDeploy.ForeColor = Color.DarkGreen;
            this.labelModsDeploy.Text = Translation.localizedStrings["modsAllDone"];
        }

        private void Display(String text)
        {
            this.labelModsDeploy.ForeColor = Color.Black;
            this.labelModsDeploy.Text = text;
            this.labelModsDeploy.Visible = true;
        }

        private void showREADMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://felisdiligens.github.io/Fo76ini/ManageMods.html");
        }
    }
}
