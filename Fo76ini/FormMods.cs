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
        private List<int> selectedIndices = new List<int>();
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
            this.KeyDown += this.FormMods_KeyDown;
            this.listViewMods.ItemCheck += this.listViewMods_ItemCheck;

            /*
             * Drag&Drop
             */
            this.listViewMods.AllowDrop = true;
            this.listViewMods.DragEnter += new DragEventHandler(listViewMods_DragEnter);
            this.listViewMods.DragDrop += new DragEventHandler(listViewMods_DragDrop);
            this.listViewMods.MouseUp += listViewMods_MouseUp;
        }

        public void OpenUI()
        {
            Utils.SetFormPosition(this, Form1.Instance.Location.X + Form1.Instance.Width, Form1.Instance.Location.Y);
            this.WindowState = FormWindowState.Normal;
            this.UpdateUI();
            this.Show();
            this.Focus();
        }

        public void UpdateUI()
        {
            UpdateModList();
            UpdateSettings();
            UpdateLabel();
        }

        private void UpdateModList()
        {
            /*
             * Iterate one row at a time...
             */
            isUpdating = true;
            this.listViewMods.Items.Clear();
            for (int i = 0; i < ManagedMods.Instance.Mods.Count; i++)
            {
                /*
                 * Define sub-items
                 */
                Mod mod = ManagedMods.Instance.Mods[i];

                bool isCompressed = mod.Compression == Archive2.Compression.None;
                bool enabled = ManagedMods.Instance.isModEnabled(i);

                var type = new ListViewItem.ListViewSubItem();
                var format = new ListViewItem.ListViewSubItem();
                var archiveName = new ListViewItem.ListViewSubItem();
                var rootDir = new ListViewItem.ListViewSubItem();
                var frozen = new ListViewItem.ListViewSubItem();
                var compressed = new ListViewItem.ListViewSubItem();
                compressed.Text = isCompressed ? Translation.localizedStrings["no"] : Translation.localizedStrings["yes"];
                compressed.ForeColor = isCompressed ? Color.Black : Color.DarkGreen;


                /*
                 * Define styles
                 */

                Font notApplicable = new Font(
                    format.Font.Name,
                    format.Font.Size - 1,
                    FontStyle.Italic,
                    format.Font.Unit
                );


                /*
                 * Fill sub-items
                 */

                // Frozen?
                if (mod.isFrozen())
                {
                    frozen.Text = Translation.localizedStrings["yes"];
                    frozen.ForeColor = Color.DarkCyan;
                }
                else if (mod.freeze)
                {
                    frozen.Text = Translation.localizedStrings["modTableFrozenPending"];
                    frozen.ForeColor = Color.DarkBlue;
                }
                else
                    frozen.Text = Translation.localizedStrings["no"];

                // Archive format
                switch (mod.Format)
                {
                    case Mod.ArchiveFormat.General:
                        format.Text = Translation.localizedStrings["modsTableFormatGeneral"];
                        format.ForeColor = Color.OrangeRed;
                        break;
                    case Mod.ArchiveFormat.Textures:
                        format.Text = Translation.localizedStrings["modsTableFormatTextures"];
                        format.ForeColor = Color.RoyalBlue;
                        break;
                    default:
                        format.Text = Translation.localizedStrings["modsTableFormatAutoDetect"];
                        //format.ForeColor = Color.Black;
                        break;
                }

                // Fill stuff depending on installation type
                switch (mod.Type)
                {
                    /*
                     * Bundled *.ba2 archive
                     */
                    case Mod.FileType.BundledBA2:
                        // Installation type
                        type.Text = Translation.localizedStrings["modsTableTypeBundled"];
                        type.ForeColor = Color.OrangeRed;

                        // Archive format
                        format.Text = Translation.localizedStrings["notApplicable"];
                        format.Font = notApplicable;
                        format.ForeColor = Color.Gray;

                        // Archive name
                        archiveName.Text = "bundled.ba2";
                        archiveName.Font = notApplicable;
                        archiveName.ForeColor = Color.Gray;

                        // Compressed?
                        compressed.Text = Translation.localizedStrings["notApplicable"];
                        compressed.Font = notApplicable;
                        compressed.ForeColor = Color.Gray;

                        // Frozen?
                        frozen.Text = Translation.localizedStrings["notApplicable"];
                        frozen.Font = notApplicable;
                        frozen.ForeColor = Color.Gray;

                        // Root dir
                        rootDir.Text = "Data";
                        rootDir.Font = notApplicable;
                        rootDir.ForeColor = Color.Gray;
                        break;

                    /*
                     * Separate *.ba2 archive
                     */
                    case Mod.FileType.SeparateBA2:
                        // Installation type
                        if (mod.isFrozen())
                        {
                            type.Text = Translation.localizedStrings["modsTableTypeSeparateFrozen"];
                            type.ForeColor = Color.Teal;
                        }
                        else
                        {
                            type.Text = Translation.localizedStrings["modsTableTypeSeparate"];
                            type.ForeColor = Color.Indigo;
                        }

                        // Archive name
                        archiveName.Text = mod.ArchiveName;

                        // Root dir
                        rootDir.Text = "Data";
                        rootDir.Font = notApplicable;
                        rootDir.ForeColor = Color.Gray;
                        break;

                    /*
                     * Loose files
                     */
                    case Mod.FileType.Loose:
                        // Installation type
                        type.Text = Translation.localizedStrings["modsTableTypeLoose"];
                        type.ForeColor = Color.MediumVioletRed;

                        // Archive format
                        format.Text = Translation.localizedStrings["notApplicable"];
                        format.Font = notApplicable;
                        format.ForeColor = Color.Gray;

                        // Archive name
                        archiveName.Text = Translation.localizedStrings["notApplicable"];
                        archiveName.Font = notApplicable;
                        archiveName.ForeColor = Color.Gray;

                        // Compressed?
                        compressed.Text = Translation.localizedStrings["notApplicable"];
                        compressed.Font = notApplicable;
                        compressed.ForeColor = Color.Gray;

                        // Frozen?
                        frozen.Text = Translation.localizedStrings["notApplicable"];
                        frozen.Font = notApplicable;
                        frozen.ForeColor = Color.Gray;

                        // Root dir
                        rootDir.Text = mod.RootFolder;
                        break;
                }


                /*
                 * Add row with our sub-items
                 */

                ListViewItem modItem = new ListViewItem(mod.Title, i);
                modItem.UseItemStyleForSubItems = false;
                modItem.ForeColor = enabled ? Color.DarkGreen : Color.DarkRed;
                modItem.SubItems.Add(type);
                modItem.SubItems.Add(rootDir);
                modItem.SubItems.Add(archiveName);
                modItem.SubItems.Add(format);
                modItem.SubItems.Add(compressed);
                modItem.SubItems.Add(frozen);
                modItem.Checked = enabled;
                if (selectedIndex == i)
                    modItem.Selected = true;
                if (selectedIndices.Contains(i))
                    modItem.Selected = true;

                this.listViewMods.Items.Add(modItem);
            }
            isUpdating = false;
        }

        private void UpdateSettings()
        {
            if (!IniFiles.Instance.IsLoaded())
                return;
            this.checkBoxDisableMods.Checked = ManagedMods.Instance.nuclearWinterMode;
            this.checkBoxAddArchivesAsBundled.Checked = IniFiles.Instance.GetBool(IniFile.Config, "Mods", "bUnpackBA2ByDefault", false);
            this.checkBoxModsUseHardlinks.Checked = IniFiles.Instance.GetBool(IniFile.Config, "Mods", "bUseHardlinks", false);
            //this.textBoxGamePath.Text = ManagedMods.Instance.GamePath;

            this.textBoxsResourceArchive2List.Text = String.Join(Environment.NewLine, IniFiles.Instance.GetString(IniFile.F76Custom, "Archive", "sResourceArchive2List", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            this.textBoxsResourceIndexFileList.Text = String.Join(Environment.NewLine, IniFiles.Instance.GetString(IniFile.F76Custom, "Archive", "sResourceIndexFileList", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
        }

        private void UpdateLabel(bool success = true)
        {
            if (ManagedMods.Instance.isDeploymentNecessary())
                this.DisplayDeploymentNecessary();
            else if (success)
                this.DisplayAllDone();
            else
                this.DisplayFailState();
        }

        private void UpdateSelectedIndices()
        {
            this.selectedIndices.Clear();
            foreach (ListViewItem item in this.listViewMods.SelectedItems)
                this.selectedIndices.Add(item.Index);
        }

        private void RestoreSelectedIndices()
        {
            this.listViewMods.Clear();
            foreach (int index in this.selectedIndices)
                this.listViewMods.Items[index].Selected = true;
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
            if (selectedIndices.Count() == 1)
                ManagedMods.Instance.Mods[selectedIndex] = changedMod.CreateCopy();
            else
            {
                foreach (int index in selectedIndices)
                {
                    if (!ManagedMods.Instance.Mods[index].isFrozen())
                    {
                        ManagedMods.Instance.Mods[index].Type = changedMod.Type;
                        ManagedMods.Instance.Mods[index].Compression = changedMod.Compression;
                        ManagedMods.Instance.Mods[index].Format = changedMod.Format;
                        ManagedMods.Instance.Mods[index].RootFolder = changedMod.RootFolder;
                        ManagedMods.Instance.Mods[index].freeze = changedMod.freeze;
                    }
                }
            }
        }

        public void ModDetailsClosed()
        {
            UpdateModList();
            EnableUI();
        }


        /*
         * Event handler
         */

        private void FormMods_Load(object sender, EventArgs e)
        {
            IniFiles.Instance.LoadWindowState("FormMods", this);
            IniFiles.Instance.LoadListViewState("FormMods", this.listViewMods);
        }

        private void FormMods_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                IniFiles.Instance.SaveWindowState("FormMods", this);
                IniFiles.Instance.SaveListViewState("FormMods", this.listViewMods);
                e.Cancel = true;
                if (this.buttonModsDeploy.Enabled && (true || MsgBox.ShowID("modsOnCloseDeploymentNecessary", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    Hide();
            }
        }

        private void FormMods_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                // Open README
                showREADMEToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                // Reload UI:
                reloadUIToolStripMenuItem_Click(sender, e);
            }

            // These shortcuts only apply to the mod list:
            if (this.listViewMods.Focused)
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {
                    // Delete mods:
                    toolStripButtonDeleteMod_Click(sender, e);
                }
                else if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
                {
                    // Edit mods:
                    toolStripButtonModEdit_Click(sender, e);
                }
                else if (e.Control && e.KeyCode == Keys.Up)
                {
                    // Move mods up:
                    toolStripButtonMoveUp_Click(sender, e);
                }
                else if (e.Control && e.KeyCode == Keys.Down)
                {
                    // Move mods down:
                    toolStripButtonMoveDown_Click(sender, e);
                }
            }
        }

        private void listViewMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewMods.SelectedItems.Count > 0)
                selectedIndex = this.listViewMods.SelectedItems[0].Index;
            else
                selectedIndex = -1;
        }

        private void listViewMods_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                toolStripButtonModEdit_Click(sender, (EventArgs)e);
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
            UpdateSelectedIndices();
            int modCount = selectedIndices.Count();
            if (modCount <= 0 || selectedIndex < 0)
            {
                SystemSounds.Beep.Play();
                return;
            }

            if (modCount == 1)
                this.formModDetails.UpdateUI(ManagedMods.Instance.Mods[selectedIndex], 1);
            else
            {
                Mod bulkMod = new Mod();
                Mod fallbackMod = null;
                int realModCount = 0;
                foreach (int index in selectedIndices)
                {
                    Mod mod = ManagedMods.Instance.Mods[index];
                    if (mod.isFrozen())
                        continue;
                    fallbackMod = mod;
                    bulkMod.Type = mod.Type;
                    bulkMod.Compression = mod.Compression;
                    bulkMod.Format = mod.Format;
                    bulkMod.freeze = false;
                    realModCount++;
                }
                bulkMod.RootFolder = "Data";
                if (realModCount == 0)
                {
                    SystemSounds.Beep.Play();
                    return;
                }
                else if (realModCount == 1)
                    this.formModDetails.UpdateUI(fallbackMod != null ? fallbackMod : ManagedMods.Instance.Mods[selectedIndex], 1);
                else
                    this.formModDetails.UpdateUI(bulkMod, realModCount);
            }

            DisableUI();
            Utils.SetFormPosition(this.formModDetails, this.Location.X + (int)(this.Width / 2 - this.formModDetails.Width / 2), this.Location.Y + (int)(this.Height / 2 - this.formModDetails.Height / 2));
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
            UpdateSelectedIndices();
            if (selectedIndices.Count > 0)
            {
                foreach (int index in selectedIndices)
                {
                    String path = ManagedMods.Instance.Mods[index].GetManagedPath();
                    if (Directory.Exists(path))
                        Utils.OpenExplorer(path);
                    else
                        MsgBox.Get("modDirNotExist").FormatText(path).Show(MessageBoxIcon.Error);
                }
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
            /*if (selectedIndex < 0)
                return;
            selectedIndex = ManagedMods.Instance.MoveModUp(selectedIndex);*/
            UpdateSelectedIndices();
            if (selectedIndices.Count <= 0)
                return;
            else if (selectedIndices.Count == 1)
            {
                selectedIndex = ManagedMods.Instance.MoveModUp(selectedIndex);
                selectedIndices.Clear();
            }
            else
            {
                selectedIndex = -1;
                selectedIndices = selectedIndices.OrderBy(i => i).ToList();
                List<int> newSelectedIndices = new List<int>();
                foreach (int index in selectedIndices)
                    newSelectedIndices.Add(ManagedMods.Instance.MoveModUp(index));
                selectedIndices = newSelectedIndices;
            }
            UpdateModList();
            UpdateLabel();
        }

        // Move down
        private void toolStripButtonMoveDown_Click(object sender, EventArgs e)
        {
            /*if (selectedIndex < 0)
                return;
            selectedIndex = ManagedMods.Instance.MoveModDown(selectedIndex);*/
            UpdateSelectedIndices();
            if (selectedIndices.Count <= 0)
                return;
            else if (selectedIndices.Count == 1)
            {
                selectedIndex = ManagedMods.Instance.MoveModDown(selectedIndex);
                selectedIndices.Clear();
            }
            else
            {
                selectedIndex = -1;
                selectedIndices = selectedIndices.OrderByDescending(i => i).ToList();
                List<int> newSelectedIndices = new List<int>();
                foreach (int index in selectedIndices)
                    newSelectedIndices.Add(ManagedMods.Instance.MoveModDown(index));
                selectedIndices = newSelectedIndices;
            }
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
            UpdateSelectedIndices();
            bool state = false;
            if (this.listViewMods.SelectedItems.Count <= 1)
            {
                selectedIndex = -1;
                foreach (ListViewItem item in this.listViewMods.Items)
                {
                    if (!item.Checked)
                    {
                        state = true;
                        break;
                    }
                }
                foreach (Mod mod in ManagedMods.Instance.Mods)
                    mod.isEnabled = state;
            }
            else
            {
                foreach (ListViewItem item in this.listViewMods.SelectedItems)
                {
                    if (!item.Checked)
                    {
                        state = true;
                        break;
                    }
                }
                foreach (ListViewItem item in this.listViewMods.SelectedItems)
                    ManagedMods.Instance.Mods[item.Index].isEnabled = state;
            }
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

        // Add frozen mod archive (*.ba2)
        private void toolStripButtonAddModFrozen_Click(object sender, EventArgs e)
        {
            if (!ManagedMods.Instance.ValidateGamePath())
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Information);
                return;
            }
            if (this.openFileDialogBA2.ShowDialog() == DialogResult.OK)
            {
                Thread thread = new Thread(() => InstallModArchiveFrozen(this.openFileDialogBA2.FileName));
                thread.IsBackground = true;
                thread.Start();
            }
        }

        // Unfreeze
        private void toolStripButtonUnfreeze_Click(object sender, EventArgs e)
        {
            if (!ManagedMods.Instance.ValidateGamePath())
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Information);
                return;
            }
            List<int> indices = new List<int>();
            foreach (ListViewItem item in this.listViewMods.SelectedItems)
                indices.Add(item.Index);
            Thread thread = new Thread(() => UnfreezeBulkMods(indices));
            thread.IsBackground = true;
            thread.Start();
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

        // File > Add mod > From *.ba2 archive (frozen)
        private void fromba2ArchivefrozenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButtonAddModFrozen_Click(sender, e);
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
            System.Diagnostics.Process.Start("https://www.nexusmods.com/fallout76/articles/40");
            // https://www.nexusmods.com/fallout76/mods/546
            // https://felisdiligens.github.io/Fo76ini/ManageMods.html
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

        // Clean lists
        private void buttonModsCleanLists_Click(object sender, EventArgs e)
        {
            List<String> sResourceIndexFileList = this.textBoxsResourceIndexFileList.Text.Replace(Environment.NewLine, "\n").Split(new char[] { '\n', ',' }, StringSplitOptions.RemoveEmptyEntries).Distinct().Select(x => x.Trim()).ToList();
            List<String> sResourceArchive2List = this.textBoxsResourceArchive2List.Text.Replace(Environment.NewLine, "\n").Split(new char[] { '\n', ',' }, StringSplitOptions.RemoveEmptyEntries).Distinct().Select(x => x.Trim()).ToList();

            String[] temp = new String[sResourceIndexFileList.Count()];
            sResourceIndexFileList.CopyTo(temp);
            foreach (String ba2file in temp)
            {
                Console.WriteLine(ba2file);
                if (!File.Exists(Path.Combine(ManagedMods.Instance.GamePath, "Data", ba2file)))
                    sResourceIndexFileList.Remove(ba2file);
            }

            temp = new String[sResourceArchive2List.Count()];
            sResourceArchive2List.CopyTo(temp);
            foreach (String ba2file in temp)
            {
                if (!File.Exists(Path.Combine(ManagedMods.Instance.GamePath, "Data", ba2file)))
                    sResourceArchive2List.Remove(ba2file);
                if (sResourceIndexFileList.Contains(ba2file))
                    sResourceArchive2List.Remove(ba2file);
            }
            this.textBoxsResourceIndexFileList.Text = String.Join(Environment.NewLine, sResourceIndexFileList);
            this.textBoxsResourceArchive2List.Text = String.Join(Environment.NewLine, sResourceArchive2List);
        }

        // Apply changes
        private void buttonModsApplyTextBoxes_Click(object sender, EventArgs e)
        {
            IniFiles.Instance.Set(IniFile.F76Custom, "Archive", "sResourceArchive2List", String.Join(",", this.textBoxsResourceArchive2List.Text.Replace(Environment.NewLine, "\n").Split(new char[] { '\n', ',' }, StringSplitOptions.RemoveEmptyEntries)));
            IniFiles.Instance.Set(IniFile.F76Custom, "Archive", "sResourceIndexFileList", String.Join(",", this.textBoxsResourceIndexFileList.Text.Replace(Environment.NewLine, "\n").Split(new char[] { '\n', ',' }, StringSplitOptions.RemoveEmptyEntries)));
            ManagedMods.Instance.CopyINILists();
            IniFiles.Instance.SaveAll();
        }

        // Reset
        private void buttonModsResetTextboxes_Click(object sender, EventArgs e)
        {
            this.textBoxsResourceArchive2List.Text = String.Join(Environment.NewLine, IniFiles.Instance.GetString(IniFile.F76Custom, "Archive", "sResourceArchive2List", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            this.textBoxsResourceIndexFileList.Text = String.Join(Environment.NewLine, IniFiles.Instance.GetString(IniFile.F76Custom, "Archive", "sResourceIndexFileList", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
        }


        public void ChangeGameEdition(GameEdition gameEdition)
        {
            ManagedMods.Instance.CopyINILists();
            ManagedMods.Instance.Unload();
            IniFiles.Instance.Set(IniFile.Config, "Preferences", "uGameEdition", (uint)gameEdition);
            ManagedMods.Instance.GameEdition = gameEdition;
            ManagedMods.Instance.GamePath = IniFiles.Instance.GetString(IniFile.Config, "Preferences", ManagedMods.Instance.GamePathKey, "");
            //this.textBoxGamePath.Text = ManagedMods.Instance.GamePath;
            ManagedMods.Instance.Load();
            UpdateUI();
        }

        // Alternative *.ba2 import method
        private void checkBoxAddArchivesAsBundled_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Instance.Set(IniFile.Config, "Mods", "bUnpackBA2ByDefault", this.checkBoxAddArchivesAsBundled.Checked);
            IniFiles.Instance.SaveConfig();
        }

        // Hard links
        private void checkBoxModsUseHardlinks_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Instance.Set(IniFile.Config, "Mods", "bUseHardlinks", this.checkBoxModsUseHardlinks.Checked);
            IniFiles.Instance.SaveConfig();
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
                (success) => {
                    Invoke(() => ProgressBarContinuous(100));
                    Invoke(() => HideLabel());
                    Invoke(() => EnableUI());
                    Invoke(() => selectedIndex = ManagedMods.Instance.Mods.Count - 1);
                    Invoke(() => UpdateModList());
                    Invoke(() => UpdateLabel(success));
                }
            );
        }

        private void InstallModArchiveFrozen(String path)
        {
            Invoke(() => DisableUI());
            Invoke(() => ProgressBarMarquee());
            ManagedMods.Instance.InstallModArchiveFrozen(path,
                (text, percent) => {
                    Invoke(() => Display(text));
                },
                (success) => {
                    Invoke(() => ProgressBarContinuous(100));
                    Invoke(() => HideLabel());
                    Invoke(() => EnableUI());
                    Invoke(() => selectedIndex = ManagedMods.Instance.Mods.Count - 1);
                    Invoke(() => UpdateModList());
                    Invoke(() => UpdateLabel(success));
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
                (success) => {
                    Invoke(() => ProgressBarContinuous(100));
                    Invoke(() => HideLabel());
                    Invoke(() => EnableUI());
                    Invoke(() => selectedIndex = ManagedMods.Instance.Mods.Count - 1);
                    Invoke(() => UpdateModList());
                    Invoke(() => UpdateLabel(success));
                }
            );
        }

        private void InstallBulk(String[] files)
        {
            foreach (string filePath in files)
            {
                bool unpackBA2ByDefault = IniFiles.Instance.GetBool(IniFile.Config, "Mods", "bUnpackBA2ByDefault", false);
                String fullFilePath = Path.GetFullPath(filePath);
                if (fullFilePath.Length > 259 && Directory.Exists(@"\\?\" + fullFilePath))
                    fullFilePath = @"\\?\" + fullFilePath;
                try
                {
                    if (Directory.Exists(fullFilePath))
                        InstallModFolder(fullFilePath);
                    else if ((new String[] { ".zip", ".rar", ".7z", ".tar", ".tar.gz", ".gz" }).Contains(Path.GetExtension(fullFilePath)))
                        InstallModArchive(fullFilePath);
                    else if (Path.GetExtension(fullFilePath).ToLower() == ".ba2")
                    {
                        if (unpackBA2ByDefault)
                            InstallModArchive(fullFilePath);
                        else
                            InstallModArchiveFrozen(fullFilePath);
                    }
                    else
                        MsgBox.Get("modsArchiveTypeNotSupported").FormatText(Path.GetExtension(fullFilePath)).Show(MessageBoxIcon.Error);
                }
                catch (FileNotFoundException exc)
                {
                    Console.WriteLine($"File not found: ({fullFilePath.Length}) {exc.Message}");
                }
            }
        }

        private void UnfreezeBulkMods(List<int> indices)
        {
            Invoke(DisableUI);
            ManagedMods.Instance.UnfreezeMods(indices,
                (text, percent) => {
                    Invoke(() => Display(text));
                    Invoke(() => { if (percent >= 0) { ProgressBarContinuous(percent); } else { ProgressBarMarquee(); } });
                },
                () => {
                    Invoke(() => EnableUI());
                    Invoke(() => UpdateModList());
                    Invoke(() => UpdateLabel());
                }
            );
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

        public void Deploy()
        {
            Invoke(() => DisableUI());
            Invoke(() => ProgressBarContinuous(0));
            Invoke(() => Display("Deploying..."));
            ManagedMods.Instance.Deploy(
                (text, percent) => {
                    Invoke(() => Display(text));
                    Invoke(() => { if (percent >= 0) { ProgressBarContinuous(percent); } else { ProgressBarMarquee(); } });
                },
                (success) => {
                    Invoke(() => {
                        UpdateUI();
                        ProgressBarContinuous(100);
                        EnableUI();

                        if (success)
                        {
                            DisplayAllDone();

                            if (ManagedMods.Instance.nuclearWinterMode)
                                MsgBox.Get("modsDisabledDone").Popup(MessageBoxIcon.Information);
                            else
                                MsgBox.Get("modsDeployedDone").Popup(MessageBoxIcon.Information);
                        }
                        else
                        {
                            DisplayFailState();
                            MsgBox.Get("modsDeploymentFailed").Popup(MessageBoxIcon.Information);
                        }
                    });
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
                    Invoke(() => {
                        ProgressBarContinuous(100);
                        //DisplayAllDone();
                        RepairDone(corruptFiles);
                        EnableUI();
                        MsgBox.Get("modsRepairDDSDone").Popup(MessageBoxIcon.Information);
                    });
                }
            );
        }

        private void RepairDone(List<String> corruptFiles)
        {
            if (corruptFiles.Count > 0)
            {
                Log log = new Log(Log.GetFilePath("repair.log.txt"));
                log.WriteLine($"Some textures couldn't be repaired:");
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
            //this.progressBarMods.MarqueeAnimationSpeed = 15;
        }

        private void ProgressBarContinuous(int value)
        {
            this.progressBarMods.Style = ProgressBarStyle.Continuous;
            this.progressBarMods.Value = Utils.Clamp(value, 0, 100);
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

        private void DisplayFailState()
        {
            this.labelModsDeploy.Visible = true;
            this.labelModsDeploy.ForeColor = Color.Red;
            this.labelModsDeploy.Text = Translation.localizedStrings["modsFailed"];
        }
    }
}
