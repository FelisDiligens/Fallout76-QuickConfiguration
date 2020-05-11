using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini
{
    public partial class FormMods : Form
    {
        public FormModDetails formModDetails;
        //private UILoader uiLoader = new UILoader();

        private int selectedIndex = -1;
        private bool isUpdating = false;

        public FormMods()
        {
            InitializeComponent();
            formModDetails = new FormModDetails(this);

            // Game Edition
            /*uiLoader.LinkList(
                new RadioButton[] { this.radioButtonEditionBethesdaNet, this.radioButtonEditionSteam },
                new String[] { "1", "2" },
                IniFile.Config, "Preferences", "uGameEdition",
                "0"
            );*/


            this.FormClosing += this.FormMods_FormClosing;
            this.listViewMods.ItemCheck += this.listViewMods_ItemCheck;

            /*
             * Drag&Drop
             */
            this.listViewMods.AllowDrop = true;
            this.listViewMods.DragEnter += new DragEventHandler(listViewMods_DragEnter);
            this.listViewMods.DragDrop += new DragEventHandler(listViewMods_DragDrop);

            ManagedMods.Instance.Load();
            UpdateUI();
        }

        public void UpdateUI()
        {
            UpdateModList();
            UpdateSettings();
            UpdateLabel();
        }

        private void UpdateModList()
        {
            isUpdating = true;
            this.listViewMods.Items.Clear();
            for (int i = 0; i < ManagedMods.Instance.Mods.Count; i++)
            {
                Mod mod = ManagedMods.Instance.Mods[i];
                String type = "";
                String format = "";
                String archiveName = "";
                String rootDir = "";
                bool enabled = ManagedMods.Instance.isModEnabled(i);
               switch (mod.Format)
                {
                    case Mod.ArchiveFormat.General:
                        format = Translation.localizedStrings["modsTableFormatGeneral"];
                        break;
                    case Mod.ArchiveFormat.Textures:
                        format = Translation.localizedStrings["modsTableFormatTextures"];
                        break;
                    default:
                        format = Translation.localizedStrings["modsTableFormatAutoDetect"];
                        break;
                }

                switch (mod.Type)
                {
                    case Mod.FileType.BundledBA2:
                        type = Translation.localizedStrings["modsTableTypeBundled"];
                        format = Translation.localizedStrings["notApplicable"];
                        archiveName = "bundled.ba2";
                        rootDir = "Data";
                        break;
                    case Mod.FileType.SeparateBA2:
                        type = Translation.localizedStrings["modsTableTypeSeparate"];
                        archiveName = mod.ArchiveName;
                        rootDir = "Data";
                        break;
                    case Mod.FileType.Loose:
                        type = Translation.localizedStrings["modsTableTypeLoose"];
                        format = Translation.localizedStrings["notApplicable"];
                        archiveName = Translation.localizedStrings["notApplicable"];
                        rootDir = mod.RootFolder;
                        break;
                }

                ListViewItem modItem = new ListViewItem(mod.Title, i);
                modItem.ForeColor = enabled ? Color.DarkGreen : Color.DarkRed;
                modItem.SubItems.Add(type);
                modItem.SubItems.Add(rootDir);
                modItem.SubItems.Add(archiveName);
                modItem.SubItems.Add(format);
                modItem.Checked = enabled;
                if (selectedIndex == i)
                    modItem.Selected = enabled;

                this.listViewMods.Items.Add(modItem);
            }
            isUpdating = false;
        }

        private void UpdateSettings()
        {
            this.checkBoxDisableMods.Checked = ManagedMods.Instance.nuclearWinterMode;
            //this.textBoxArchive2Path.Text = Archive2.Archive2Path;
            this.textBoxGamePath.Text = ManagedMods.Instance.GamePath;
            this.checkBoxModsBundledBA2Compression.Checked = ManagedMods.Instance.bundledCompression != Archive2.Compression.None;
            this.checkBoxModsBundledTexturesBA2Compression.Checked = ManagedMods.Instance.bundledTexturesCompression != Archive2.Compression.None;
            /*uint gameEdition = IniFiles.Instance.GetUInt(IniFile.Config, "Preferences", "uGameEdition", 0);
            switch (gameEdition)
            {
                case (uint)GameEdition.BethesdaNet:
                    this.radioButtonEditionBethesdaNet.Checked = true;
                    break;
                case (uint)GameEdition.Steam:
                    this.radioButtonEditionSteam.Checked = true;
                    break;
            }*/
            //uiLoader.Update();
        }

        private void UpdateLabel()
        {
            if (ManagedMods.Instance.isDeploymentNecessary())
                this.DisplayDeploymentNecessary();
            else
                this.DisplayAllDone();
        }

        private void EnableUI()
        {
            this.tabControl1.Enabled = true;
            this.buttonModsDeploy.Enabled = true;
            this.menuStrip1.Enabled = true;
            this.checkBoxDisableMods.Enabled = true;
        }

        private void DisableUI()
        {
            this.tabControl1.Enabled = false;
            this.buttonModsDeploy.Enabled = false;
            this.menuStrip1.Enabled = false;
            this.checkBoxDisableMods.Enabled = false;
        }

        public void ModDetailsFeedback(Mod changedMod)
        {
            ManagedMods.Instance.Mods[selectedIndex] = changedMod.CreateCopy();
        }

        public void ModDetailsClosed()
        {
            UpdateModList();
            EnableUI();
        }


        /*
         * Event handler
         */

        private void FormMods_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                if (this.buttonModsDeploy.Enabled && (true || MsgBox.ShowID("modsOnCloseDeploymentNecessary", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    Hide();
            }
        }

        
        private void listViewMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewMods.SelectedItems.Count > 0)
                selectedIndex = this.listViewMods.SelectedItems[0].Index;
            else
                selectedIndex = -1;
        }

        // Deploy
        private void buttonModsDeploy_Click(object sender, EventArgs e)
        {
            if (!ManagedMods.Instance.ValidateGamePath())
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Information);
                return;
            }
            Thread thread = new Thread(Deploy);
            thread.IsBackground = true;
            thread.Start();
        }

        // Disable mods
        private void checkBoxDisableMods_CheckedChanged(object sender, EventArgs e)
        {
            ManagedMods.Instance.nuclearWinterMode = checkBoxDisableMods.Checked;
            IniFiles.Instance.Set(IniFile.Config, "Mods", "bDisableMods", checkBoxDisableMods.Checked);
            DisplayDeploymentNecessary();
        }

        // Drag & Drop
        void listViewMods_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        void listViewMods_DragDrop(object sender, DragEventArgs e)
        {
            if (!ManagedMods.Instance.ValidateGamePath())
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Information);
                return;
            }
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            Thread thread = new Thread(() => InstallBulk(files));
            thread.IsBackground = true;
            thread.Start();
        }

        /*
         * Mod order buttons
         */

        // Edit mod details:
        private void toolStripButtonModEdit_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0)
            {
                SystemSounds.Beep.Play();
                return;
            }

            DisableUI();
            //Utils.SetFormPosition(this.formModDetails, this.Location.X + 60, this.Location.Y + 30);
            Utils.SetFormPosition(this.formModDetails, this.Location.X + (int)(this.Width / 2 - this.formModDetails.Width / 2), this.Location.Y + (int)(this.Height / 2 - this.formModDetails.Height / 2));
            this.formModDetails.UpdateUI(ManagedMods.Instance.Mods[selectedIndex]);
            this.formModDetails.Show();
        }

        // Open mod folder:
        private void toolStripButtonModOpenFolder_Click(object sender, EventArgs e)
        {
            if (!ManagedMods.Instance.ValidateGamePath())
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Information);
                return;
            }
            if (selectedIndex >= 0)
            {
                String path = ManagedMods.Instance.Mods[selectedIndex].GetManagedPath();
                if (Directory.Exists(path))
                    Utils.OpenExplorer(path);
                else
                    MsgBox.Get("modDirNotExist").FormatText(path).Show(MessageBoxIcon.Error);
            }
            else
            {
                String path = Path.Combine(ManagedMods.Instance.GamePath, "Mods");
                if (Directory.Exists(path))
                    Utils.OpenExplorer(path);
            }
        }

        // Move up
        private void toolStripButtonMoveUp_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0)
                return;
            selectedIndex = ManagedMods.Instance.MoveModUp(selectedIndex);
            UpdateModList();
            UpdateLabel();
        }

        // Move down
        private void toolStripButtonMoveDown_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0)
                return;
            selectedIndex = ManagedMods.Instance.MoveModDown(selectedIndex);
            UpdateModList();
            UpdateLabel();
        }

        // Mod enabled/disabled
        private void listViewMods_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isUpdating)
                return;

            if (e.NewValue == CheckState.Checked)
            {
                ManagedMods.Instance.EnableMod(e.Index);
                listViewMods.Items[e.Index].ForeColor = Color.DarkGreen;
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                ManagedMods.Instance.DisableMod(e.Index);
                listViewMods.Items[e.Index].ForeColor = Color.DarkRed;
            }

            UpdateLabel();
        }

        // Check/uncheck all
        private void toolStripButtonCheckAll_Click(object sender, EventArgs e)
        {
            selectedIndex = -1;
            bool state = false;
            foreach (ListViewItem item in listViewMods.Items)
            {
                if (!item.Checked)
                {
                    state = true;
                    break;
                }
            }
            foreach (Mod mod in ManagedMods.Instance.Mods)
                mod.isEnabled = state;
            UpdateModList();
            UpdateLabel();
        }

        // Delete mod
        private void toolStripButtonDeleteMod_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0)
                return;
            if (this.listViewMods.SelectedItems.Count > 1)
            {
                DialogResult res = MsgBox.Get("modsDeleteBulkBtn").FormatText(this.listViewMods.SelectedItems.Count.ToString()).Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    List<int> indices = new List<int>();
                    foreach (ListViewItem item in this.listViewMods.SelectedItems)
                        indices.Add(item.Index);
                    Thread thread = new Thread(() => DeleteModsBulk(indices));
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
            else
            {
                Mod mod = ManagedMods.Instance.Mods[selectedIndex];
                DialogResult res = MsgBox.Get("modsDeleteBtn").FormatText(mod.Title).Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    Thread thread = new Thread(() => DeleteMod(selectedIndex));
                    thread.IsBackground = true;
                    thread.Start();
                }
            }
        }

        // Add mod archive
        private void toolStripButtonAddMod_Click(object sender, EventArgs e)
        {
            if (!ManagedMods.Instance.ValidateGamePath())
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Information);
                return;
            }
            if (this.openFileDialogMod.ShowDialog() == DialogResult.OK)
            {
                Thread thread = new Thread(() => InstallModArchive(this.openFileDialogMod.FileName));
                thread.IsBackground = true;
                thread.Start();
            }
        }

        // Add mod folder
        private void toolStripButtonAddModFolder_Click(object sender, EventArgs e)
        {
            if (!ManagedMods.Instance.ValidateGamePath())
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Information);
                return;
            }
            if (this.folderBrowserDialogMod.ShowDialog() == DialogResult.OK)
            {
                Thread thread = new Thread(() => InstallModFolder(this.folderBrowserDialogMod.SelectedPath));
                thread.IsBackground = true;
                thread.Start();
            }
        }



        /*
         * Menu
         */

        // File > Add mod > From archive
        private void fromArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButtonAddMod_Click(sender, e);
        }

        // File > Add mod > From folder
        private void fromFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButtonAddModFolder_Click(sender, e);
        }

        // File > Import installed mods
        private void toolStripMenuItemModsImport_Click(object sender, EventArgs e)
        {
            if (!ManagedMods.Instance.ValidateGamePath())
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Information);
                return;
            }
            if (MsgBox.ShowID("modsImportQuestion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ManagedMods.Instance.ImportInstalledMods();
                this.UpdateModList();
            }
        }

        // File > Deploy
        private void deployToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonModsDeploy_Click(sender, e);
        }

        // View > Show conflicting files
        private void showConflictingFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<ManagedMods.Conflict> conflicts = ManagedMods.Instance.GetConflictingFiles();
            if (conflicts.Count == 0)
            {
                MsgBox.ShowID("modsNoConflictingFiles", MessageBoxIcon.Information);
                return;
            }
            String tempFile = Path.GetTempFileName();
            using (StreamWriter f = File.AppendText(tempFile))
            {
                f.WriteLine("Conflicting mods:");
                foreach (ManagedMods.Conflict conflict in conflicts)
                {
                    f.WriteLine("\n* " +conflict.conflictText + " (" + conflict.conflictingFiles.Count + " conflicting file" + (conflict.conflictingFiles.Count == 1 ? "" : "s") + ")");
                    foreach (String conflictingFile in conflict.conflictingFiles)
                        f.WriteLine("    -> " + conflictingFile);
                }
            }
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "notepad.exe",
                Arguments = tempFile
            };
            Process.Start(startInfo);
        }


        // View > Reload UI
        private void reloadUIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.UpdateUI();
        }

        // Help > Show README
        private void showREADMEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://felisdiligens.github.io/Fo76ini/ManageMods.html");
        }

        // Tools > Repair *.dds files
        private void repairddsFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MsgBox.Get("modsRepairDDSQuestion").Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                Thread thread = new Thread(RepairDDSFiles);
                thread.IsBackground = true;
                thread.Start();
            }
        }



        /*
         * Settings
         */

        private void checkBoxModsBundledBA2Compression_CheckedChanged(object sender, EventArgs e)
        {
            ManagedMods.Instance.bundledCompression = checkBoxModsBundledBA2Compression.Checked ? Archive2.Compression.Default : Archive2.Compression.None;
        }

        private void checkBoxModsBundledTexturesBA2Compression_CheckedChanged(object sender, EventArgs e)
        {
            ManagedMods.Instance.bundledTexturesCompression = checkBoxModsBundledTexturesBA2Compression.Checked ? Archive2.Compression.Default : Archive2.Compression.None;
        }

        // Pick game path
        private void buttonPickGamePath_Click(object sender, EventArgs e)
        {
            if (ManagedMods.Instance.isDeploymentNecessary())
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
                    ManagedMods.Instance.GamePath = path;
                    IniFiles.Instance.Set(IniFile.Config, "Preferences", ManagedMods.Instance.GamePathKey, path);
                    IniFiles.Instance.SaveConfig();
                    ManagedMods.Instance.Load();
                    UpdateUI();
                }
                else
                    MsgBox.ShowID("modsGamePathInvalid");
            }
        }

        // Game path textbox changed
        private void textBoxGamePath_TextChanged(object sender, EventArgs e)
        {
            if (this.textBoxGamePath.Focused)
            {
                if (ManagedMods.Instance.isDeploymentNecessary())
                {
                    if (this.textBoxGamePath.Text != ManagedMods.Instance.GamePath)
                        this.textBoxGamePath.Text = ManagedMods.Instance.GamePath;
                    return;
                }
                else if (Directory.Exists(Path.Combine(this.textBoxGamePath.Text, "Data")))
                {
                    ManagedMods.Instance.GamePath = this.textBoxGamePath.Text;
                    IniFiles.Instance.Set(IniFile.Config, "Preferences", ManagedMods.Instance.GamePathKey, this.textBoxGamePath.Text);
                    IniFiles.Instance.SaveConfig();
                    ManagedMods.Instance.Load();
                    UpdateUI();
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

        // Bethesda.net picked
        /*private void radioButtonEditionBethesdaNet_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonEditionBethesdaNet.Checked)
                ChangeGameEdition(GameEdition.BethesdaNet);
        }

        // Steam picked
        private void radioButtonEditionSteam_CheckedChanged(object sender, EventArgs e)
        {
            if (this.radioButtonEditionSteam.Checked)
                ChangeGameEdition(GameEdition.Steam);
        }*/

        public void ChangeGameEdition(GameEdition gameEdition)
        {
            IniFiles.Instance.Set(IniFile.Config, "Preferences", "uGameEdition", (uint)gameEdition);
            ManagedMods.Instance.Unload();
            ManagedMods.Instance.GamePathKey = "sGamePath" + (gameEdition == GameEdition.Steam ? "Steam" : "BethesdaNet");
            ManagedMods.Instance.GamePath = IniFiles.Instance.GetString(IniFile.Config, "Preferences", ManagedMods.Instance.GamePathKey, "");
            this.textBoxGamePath.Text = ManagedMods.Instance.GamePath;
            ManagedMods.Instance.Load();
            UpdateUI();
        }


        /*
         * Threads
         */

        private void InstallModArchive(String path)
        {
            Invoke(() => DisableUI());
            Invoke(() => ProgressBarMarquee());
            ManagedMods.Instance.InstallModArchive(path,
                (text, percent) => {
                    Invoke(() => Display(text));
                },
                () => {
                    Invoke(() => ProgressBarContinuous(100));
                    Invoke(() => HideLabel());
                    Invoke(() => EnableUI());
                    Invoke(() => selectedIndex = ManagedMods.Instance.Mods.Count - 1);
                    Invoke(() => UpdateModList());
                    Invoke(() => UpdateLabel());
                }
            );
        }

        private void InstallModFolder(String path)
        {
            Invoke(() => DisableUI());
            Invoke(() => ProgressBarContinuous(0));
            ManagedMods.Instance.InstallModFolder(path,
                (text, percent) => {
                    Invoke(() => Display(text));
                    Invoke(() => { if (percent >= 0) { ProgressBarContinuous(percent); } else { ProgressBarMarquee(); } });
                },
                () => {
                    Invoke(() => ProgressBarContinuous(100));
                    Invoke(() => HideLabel());
                    Invoke(() => EnableUI());
                    Invoke(() => selectedIndex = ManagedMods.Instance.Mods.Count - 1);
                    Invoke(() => UpdateModList());
                    Invoke(() => UpdateLabel());
                }
            );
        }

        private void InstallBulk(String[] files)
        {
            foreach (string filePath in files)
            {
                String fullFilePath = Path.GetFullPath(filePath);
                if (fullFilePath.Length > 259 && Directory.Exists(@"\\?\" + fullFilePath))
                    fullFilePath = @"\\?\" + fullFilePath;
                try
                {
                    if (Directory.Exists(fullFilePath))
                        InstallModFolder(fullFilePath);
                    else if ((new String[] { ".ba2", ".zip", ".rar", ".7z", ".tar", ".tar.gz", ".gz" }).Contains(Path.GetExtension(fullFilePath)))
                        InstallModArchive(fullFilePath);
                    else
                        MsgBox.Get("modsArchiveTypeNotSupported").FormatText(Path.GetExtension(fullFilePath)).Show(MessageBoxIcon.Error);
                }
                catch (FileNotFoundException exc)
                {
                    Console.WriteLine($"File not found: ({fullFilePath.Length}) {exc.Message}");
                }
            }
        }

        private void DeleteMod(int index)
        {
            Invoke(() => DisableUI());
            Invoke(() => ProgressBarMarquee());
            ManagedMods.Instance.DeleteMod(index, () => {
                Invoke(() => ProgressBarContinuous(100));
                Invoke(() => EnableUI());
                Invoke(() => selectedIndex = -1);
                Invoke(() => UpdateModList());
                Invoke(() => UpdateLabel());
            });
        }

        private void DeleteModsBulk(List<int> indices)
        {
            Invoke(() => DisableUI());
            Invoke(() => ProgressBarMarquee());
            ManagedMods.Instance.DeleteMods(indices, () => {
                Invoke(() => ProgressBarContinuous(100));
                Invoke(() => EnableUI());
                Invoke(() => selectedIndex = -1);
                Invoke(() => UpdateModList());
                Invoke(() => UpdateLabel());
            });
        }

        private void Deploy()
        {
            Invoke(() => DisableUI());
            Invoke(() => ProgressBarContinuous(0));
            Invoke(() => Display("Deploying..."));
            ManagedMods.Instance.Deploy(
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

        private void RepairDDSFiles()
        {
            Invoke(() => DisableUI());
            Invoke(() => ProgressBarContinuous(0));
            Invoke(() => Display("Preparing..."));
            ManagedMods.Instance.RepairDDSFiles(
                (text, percent) => {
                    Invoke(() => Display(text));
                    Invoke(() => { if (percent >= 0) { ProgressBarContinuous(percent); } else { ProgressBarMarquee(); } });
                },
                (corruptFiles) => {
                    Invoke(() => ProgressBarContinuous(100));
                    Invoke(() => DisplayAllDone());
                    Invoke(() => RepairDone(corruptFiles));
                    Invoke(() => EnableUI());
                }
            );
        }

        private void RepairDone(List<String> corruptFiles)
        {
            if (corruptFiles.Count > 0)
            {
                Log log = new Log("repair.log.txt");
                foreach (String path in corruptFiles)
                    log.WriteLine(path);
                log.WriteLine("");

                this.labelModsDeploy.ForeColor = Color.Red;
                this.labelModsDeploy.Text = $"{corruptFiles.Count} unrestorable files. See repair.log.txt";
                this.labelModsDeploy.Visible = true;
            }
            else
            {
                this.labelModsDeploy.ForeColor = Color.Green;
                this.labelModsDeploy.Text = "Repaired, done.";
                this.labelModsDeploy.Visible = true;
            }
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

        private void Display(String text)
        {
            this.labelModsDeploy.ForeColor = Color.Black;
            this.labelModsDeploy.Text = text;
            this.labelModsDeploy.Visible = true;
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
    }
}
