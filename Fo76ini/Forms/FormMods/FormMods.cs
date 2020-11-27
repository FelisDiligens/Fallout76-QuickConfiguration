﻿using Fo76ini.Interface;
using Fo76ini.Mods;
using Fo76ini.NexusAPI;
using Fo76ini.Profiles;
using Fo76ini.Tweaks.ResourceLists;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace Fo76ini
{
    public partial class FormMods : Form
    {
        private int selectedIndex = -1;
        private List<int> selectedIndices = new List<int>();

        private GameInstance game;
        private ManagedMods Mods;

        /// <summary>
        /// isUpdating is set to true when updating the UI.
        /// The value is checked in event handlers and if it is true, the event will be ignored.
        /// TODO: Messy workaround, find a better solution, plz!
        /// </summary>
        private bool isUpdating = false;

        #region Related to opening, closing, or (re)loading the entire form
        public FormMods()
        {
            InitializeComponent();
            InitializeDetailControls();

            // Handle changes:
            ProfileManager.ProfileChanged += OnProfileChanged;

            // Make this form translatable:
            LocalizedForm form = new LocalizedForm(this, this.toolTip);
            Localization.LocalizedForms.Add(form);

            // Add control elements to blacklist:
            Translation.BlackList.AddRange(new string[] {
                "labelModsDeploy"
            });

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

        private void OnProfileChanged(object sender, ProfileEventArgs e)
        {
            this.game = e.ActiveGameInstance;
            ReloadModManager();
            // TODO ChangeGameEdition in FormMods - Old code
            /*public void ChangeGameEdition(GameEdition gameEdition)
            {
                ManagedMods.Instance.CopyINILists();
                ManagedMods.Instance.Unload();
                IniFiles.Instance.Set(IniFile.Config, "Preferences", "uGameEdition", (uint)gameEdition);
                ManagedMods.Instance.GameEdition = gameEdition;
                Shared.GamePath = IniFiles.Instance.GetString(IniFile.Config, "Preferences", Shared.GamePathKey, "");
                //this.textBoxGamePath.Text = Shared.GamePath;
                ManagedMods.Instance.Load();
                UpdateUI();
            }*/
        }

        private void FormMods_Load(object sender, EventArgs e)
        {
            Configuration.LoadWindowState("FormMods", this);
            Configuration.LoadListViewState("FormMods", this.listViewMods);
        }

        private void FormMods_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Configuration.SaveWindowState("FormMods", this);
                Configuration.SaveListViewState("FormMods", this.listViewMods);
                e.Cancel = true;
                if (this.buttonModsDeploy.Enabled && (true || MsgBox.ShowID("modsOnCloseDeploymentNecessary", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                    Hide();
            }
        }

        private void LoadMods(string GamePath)
        {
            Mods = new ManagedMods(GamePath);
            Mods.Load();
        }

        private void ReloadModManager()
        {
            if (!IniFiles.IsLoaded())
                return;
            LoadMods(this.game.GamePath);
            UpdateUI();
        }

        /// <summary>
        /// Checks whether the game path has been set, all required executables exist, and so on.
        /// Displays messageboxes if something is amiss.
        /// </summary>
        /// <returns>true if all is good. false if something is amiss.</returns>
        private bool CheckIntegrity()
        {
            if (this.game == null)
                return false;

            if (!this.game.ValidateGamePath())
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Error);
                return false;
            }
            if (!Archive2.ValidatePath())
            {
                MsgBox.ShowID("modsArchive2Missing", MessageBoxIcon.Error);
                return false;
            }
            if (!File.Exists(Utils.SevenZipPath))
            {
                MsgBox.ShowID("7ZipMissing", MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Opens the window and updates the form.
        /// </summary>
        public void OpenUI()
        {
            if (!CheckIntegrity())
                return;

            this.WindowState = FormWindowState.Normal;
            ReloadModManager();
            Show();
            Focus();
        }

        /// <summary>
        /// Updates the form.
        /// </summary>
        private void UpdateUI()
        {
            UpdateModList();
            UpdateSettings();
            UpdateProgressLabel();
        }

        #endregion

        #region User interface
        /// <summary>
        /// Goes through the mod list and updates the list view.
        /// </summary>
        private void UpdateModList()
        {
            /*
             * Iterate one row at a time...
             */
            isUpdating = true;
            this.listViewMods.Items.Clear();
            for (int i = 0; i < Mods.Count; i++)
            {
                /*
                 * Define sub-items
                 */

                var type = new ListViewItem.ListViewSubItem();
                var version = new ListViewItem.ListViewSubItem();
                var format = new ListViewItem.ListViewSubItem();
                var archiveName = new ListViewItem.ListViewSubItem();
                var rootDir = new ListViewItem.ListViewSubItem();
                var frozen = new ListViewItem.ListViewSubItem();
                var compressed = new ListViewItem.ListViewSubItem();


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
                 * Get some info
                 */

                ManagedMod mod = Mods[i];
                NMMod nmMod = mod.RemoteInfo;

                bool enabled = mod.Enabled;


                /*
                 * Fill sub-items
                 */

                // Version:
                if (mod.Version != "")
                {
                    if (nmMod != null)
                    {
                        int cmp = Utils.CompareVersions(nmMod.LatestVersion, mod.Version);
                        if (cmp > 0)
                        {
                            // Update available:
                            version.Text = $"{mod.Version} ({nmMod.LatestVersion})";
                            version.ForeColor = Color.DarkRed;
                        }
                        else
                        {
                            // Latest version:
                            version.Text = $"{mod.Version}";
                            version.ForeColor = Color.DarkGreen;
                        }
                    }
                    else
                    {
                        version.Text = $"{mod.Version}";
                        version.ForeColor = Color.Gray;
                    }
                }

                // Frozen?
                if (mod.Frozen)
                {
                    frozen.Text = Localization.GetString("yes"); // "Frozen"
                    frozen.ForeColor = Color.DarkCyan;
                }
                else if (mod.Freeze)
                {
                    frozen.Text = Localization.GetString("modTableFrozenPending"); // "Pending"
                    frozen.ForeColor = Color.DarkBlue;
                }
                else
                    frozen.Text = Localization.GetString("no"); // "Thawed"

                // Archive format
                switch (mod.Format)
                {
                    case ManagedMod.ArchiveFormat.General:
                        format.Text = Localization.GetString("modsTableFormatGeneral");
                        format.ForeColor = Color.OrangeRed;
                        break;
                    case ManagedMod.ArchiveFormat.Textures:
                        format.Text = Localization.GetString("modsTableFormatTextures");
                        format.ForeColor = Color.RoyalBlue;
                        break;
                    default:
                        format.Text = Localization.GetString("modsTableFormatAutoDetect");
                        format.ForeColor = Color.DimGray;
                        break;
                }

                // Archive compression
                switch (mod.Compression)
                {
                    case ManagedMod.ArchiveCompression.Compressed:
                        compressed.Text = Localization.GetString("yes");
                        compressed.ForeColor = Color.DarkGreen;
                        break;
                    case ManagedMod.ArchiveCompression.Uncompressed:
                        compressed.Text = Localization.GetString("no");
                        compressed.ForeColor = Color.Black;
                        break;
                    default:
                        compressed.Text = Localization.GetString("modsTableFormatAutoDetect");
                        compressed.ForeColor = Color.DimGray;
                        break;
                }

                // Fill stuff depending on installation type
                switch (mod.Method)
                {
                    /*
                     * Bundled *.ba2 archive
                     */
                    case ManagedMod.DeploymentMethod.BundledBA2:
                        // Installation type
                        type.Text = Localization.GetString("modsTableTypeBundled");
                        type.ForeColor = Color.OrangeRed;

                        // Archive format
                        format.Text = Localization.GetString("notApplicable");
                        format.Font = notApplicable;
                        format.ForeColor = Color.Silver;

                        // Archive name
                        archiveName.Text = "Bundled*.ba2";
                        archiveName.Font = notApplicable;
                        archiveName.ForeColor = Color.Silver;

                        // Compressed?
                        compressed.Text = Localization.GetString("notApplicable");
                        compressed.Font = notApplicable;
                        compressed.ForeColor = Color.Silver;

                        // Frozen?
                        frozen.Text = Localization.GetString("notApplicable");
                        frozen.Font = notApplicable;
                        frozen.ForeColor = Color.Silver;

                        // Root dir
                        rootDir.Text = "Data";
                        rootDir.Font = notApplicable;
                        rootDir.ForeColor = Color.Silver;
                        break;

                    /*
                     * Separate *.ba2 archive
                     */
                    case ManagedMod.DeploymentMethod.SeparateBA2:
                        // Installation type
                        if (mod.Freeze)
                        {
                            type.Text = Localization.GetString("modsTableTypeSeparateFrozen");
                            type.ForeColor = Color.Teal;
                        }
                        else
                        {
                            type.Text = Localization.GetString("modsTableTypeSeparate");
                            type.ForeColor = Color.Indigo;
                        }

                        // Archive name
                        archiveName.Text = mod.ArchiveName;

                        // Root dir
                        rootDir.Text = "Data";
                        rootDir.Font = notApplicable;
                        rootDir.ForeColor = Color.Silver;
                        break;

                    /*
                     * Loose files
                     */
                    case ManagedMod.DeploymentMethod.Loose:
                        // Installation type
                        type.Text = Localization.GetString("modsTableTypeLoose");
                        type.ForeColor = Color.MediumVioletRed;

                        // Archive format
                        format.Text = Localization.GetString("notApplicable");
                        format.Font = notApplicable;
                        format.ForeColor = Color.Silver;

                        // Archive name
                        archiveName.Text = Localization.GetString("notApplicable");
                        archiveName.Font = notApplicable;
                        archiveName.ForeColor = Color.Silver;

                        // Compressed?
                        compressed.Text = Localization.GetString("notApplicable");
                        compressed.Font = notApplicable;
                        compressed.ForeColor = Color.Silver;

                        // Frozen?
                        frozen.Text = Localization.GetString("notApplicable");
                        frozen.Font = notApplicable;
                        frozen.ForeColor = Color.Silver;

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
                modItem.SubItems.Add(version);
                modItem.SubItems.Add(type);
                //modItem.SubItems.Add(size);
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
            this.checkBoxDisableMods.Checked = this.Mods.ModsDisabled;
            this.checkBoxAddArchivesAsBundled.Checked = IniFiles.Config.GetBool("Mods", "bUnpackBA2ByDefault", false);
            this.checkBoxModsUseHardlinks.Checked = IniFiles.Config.GetBool("Mods", "bUseHardlinks", true);
            this.checkBoxFreezeBundledArchives.Checked = IniFiles.Config.GetBool("Mods", "bFreezeBundledArchives", false);

            LoadTextBoxResourceLists();
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
            this.pictureBoxModsLoadingGIF.Visible = false;
            this.tabPageModsSettings.Enabled = true;
            this.buttonModsDeploy.Enabled = true;
            this.menuStrip1.Enabled = true;
            this.checkBoxDisableMods.Enabled = true;
            this.listViewMods.Enabled = true;
            this.toolStrip1.Enabled = true;
        }

        private void DisableUI()
        {
            this.tabControl1.Enabled = false;
            this.buttonModsDeploy.Enabled = false;
            this.menuStrip1.Enabled = false;
            this.checkBoxDisableMods.Enabled = false;
        }

        private void DisableUI_SidePanelOpen()
        {
            this.listViewMods.Enabled = false;
            this.toolStrip1.Enabled = false;
            this.buttonModsDeploy.Enabled = false;
            this.checkBoxDisableMods.Enabled = false;
            this.menuStrip1.Enabled = false;
            this.tabPageModsSettings.Enabled = false;
        }

        private void ShowLoadingUI()
        {
            DisableUI();
            this.tabControl1.Enabled = true;
            this.pictureBoxModsLoadingGIF.Visible = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabPageModsSettings.Enabled = false;
        }

        #endregion

        public void ModDetailsFeedback(ManagedMod changedMod)
        {
            if (editedIndices.Count() == 1)
                Mods[editedIndex] = changedMod.CreateDeepCopy();
            else
            {
                foreach (int index in editedIndices)
                {
                    if (!Mods[index].Frozen)
                    {
                        // TODO: Bulk mod edit
                        /*ManagedMod.DiskState pendingState = ManagedMods.Instance.Mods[index].PendingDiskState;
                        pendingState.Method = changedMod.PendingDiskState.Method;
                        pendingState.Compression = changedMod.PendingDiskState.Compression;
                        pendingState.Format = changedMod.PendingDiskState.Format;
                        pendingState.RootFolder = changedMod.PendingDiskState.RootFolder;
                        pendingState.Frozen = changedMod.PendingDiskState.Frozen;*/
                    }
                }
            }
            UpdateModList();
        }

        public void ModDetailsClosed()
        {
            UpdateModList();
            EnableUI();
        }


        /*
         **********************************************************************************
         * Event handler
         **********************************************************************************
         */

        // Deploy
        private void buttonModsDeploy_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(Deploy);
            thread.IsBackground = true;
            thread.Start();
        }

        // Disable mods
        private void checkBoxDisableMods_CheckedChanged(object sender, EventArgs e)
        {
            this.Mods.ModsDisabled = checkBoxDisableMods.Checked;
            DisplayDeploymentNecessary();
        }

        private void saveDEVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mods.Save(); // TODO: Remove "Save (DEV)" button
        }

        #region All event handler that control the ListView

        private void FormMods_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                // Open guide
                showGuideToolStripMenuItem_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                // Reload UI:
                reloadUIToolStripMenuItem_Click(sender, e);
            }
            /*else if (e.Control == true && e.Shift && e.KeyCode == Keys.F12)
            {
                FormConsole.Instance.OpenUI();
            }*/

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

        // Drag & Drop
        void listViewMods_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        void listViewMods_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            InstallBulkThreaded(files);
        }

        // Mod enabled/disabled
        private void listViewMods_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isUpdating)
                return;

            if (e.NewValue == CheckState.Checked)
            {
                Mods.EnableMod(e.Index);
                listViewMods.Items[e.Index].ForeColor = Color.DarkGreen;
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                Mods.DisableMod(e.Index);
                listViewMods.Items[e.Index].ForeColor = Color.DarkRed;
            }

            UpdateProgressLabel();
        }

        #endregion

        #region Toolstrip event handler

        // Edit mod details:
        private void toolStripButtonModEdit_Click(object sender, EventArgs e)
        {
            UpdateSelectedIndices();
            this.editedIndex = this.selectedIndex;
            this.editedIndices = this.selectedIndices.ToList(); // Make a shallow copy

            int modCount = editedIndices.Count();
            if (modCount <= 0 || editedIndex < 0)
            {
                SystemSounds.Beep.Play();
                return;
            }

            if (modCount == 1)
                UpdateSidePanel(Mods[editedIndex], 1);
            //this.formModDetails.UpdateUI(ManagedMods.Instance.Mods[selectedIndex], 1);
            else
            {
                // TODO: BULK MOD EDIT
                /*
                LegacyMod bulkMod = new LegacyMod();
                LegacyMod fallbackMod = null;
                int realModCount = 0;
                foreach (int index in editedIndices)
                {
                    LegacyMod mod = ManagedMods.Instance.Mods[index];
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
                    UpdateSidePanel(fallbackMod != null ? fallbackMod : ManagedMods.Instance.Mods[editedIndex], 1);
                //this.formModDetails.UpdateUI(fallbackMod != null ? fallbackMod : ManagedMods.Instance.Mods[editedIndex], 1);
                else
                    UpdateSidePanel(bulkMod, realModCount);
                    //this.formModDetails.UpdateUI(bulkMod, realModCount);*/
            }

            //DisableUI_SidePanelOpen();
            //Utils.SetFormPosition(this.formModDetails, this.Location.X + (int)(this.Width / 2 - this.formModDetails.Width / 2), this.Location.Y + (int)(this.Height / 2 - this.formModDetails.Height / 2));
            //this.formModDetails.Show();
        }

        // Open mod folder:
        private void toolStripButtonModOpenFolder_Click(object sender, EventArgs e)
        {
            UpdateSelectedIndices();
            if (selectedIndices.Count > 0)
            {
                foreach (int index in selectedIndices)
                {
                    string path = Mods[index].ManagedFolderPath;
                    if (Directory.Exists(path))
                        Utils.OpenExplorer(path);
                    else
                        MsgBox.Get("modDirNotExist").FormatText(path).Show(MessageBoxIcon.Error);
                }
            }
            else
            {
                string path = Path.Combine(this.game.GamePath, "Mods");
                if (Directory.Exists(path))
                    Utils.OpenExplorer(path);
            }
        }

        // Move up
        private void toolStripButtonMoveUp_Click(object sender, EventArgs e)
        {
            UpdateSelectedIndices();
            CloseSidePanel();
            /*if (selectedIndex < 0)
                return;
            selectedIndex = ManagedMods.Instance.MoveModUp(selectedIndex);*/
            if (selectedIndices.Count <= 0)
                return;
            else if (selectedIndices.Count == 1)
            {
                selectedIndex = Mods.MoveModUp(selectedIndex);
                selectedIndices.Clear();
            }
            else
            {
                selectedIndex = -1;
                selectedIndices = selectedIndices.OrderBy(i => i).ToList();
                List<int> newSelectedIndices = new List<int>();
                foreach (int index in selectedIndices)
                    newSelectedIndices.Add(Mods.MoveModUp(index));
                selectedIndices = newSelectedIndices;
            }
            UpdateModList();
            UpdateProgressLabel();
        }

        // Move down
        private void toolStripButtonMoveDown_Click(object sender, EventArgs e)
        {
            UpdateSelectedIndices();
            CloseSidePanel();
            /*if (selectedIndex < 0)
                return;
            selectedIndex = ManagedMods.Instance.MoveModDown(selectedIndex);*/
            if (selectedIndices.Count <= 0)
                return;
            else if (selectedIndices.Count == 1)
            {
                selectedIndex = Mods.MoveModDown(selectedIndex);
                selectedIndices.Clear();
            }
            else
            {
                selectedIndex = -1;
                selectedIndices = selectedIndices.OrderByDescending(i => i).ToList();
                List<int> newSelectedIndices = new List<int>();
                foreach (int index in selectedIndices)
                    newSelectedIndices.Add(Mods.MoveModDown(index));
                selectedIndices = newSelectedIndices;
            }
            UpdateModList();
            UpdateProgressLabel();
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
                foreach (ManagedMod mod in Mods)
                    mod.Enabled = state;
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
                    Mods[item.Index].Enabled = state;
            }
            UpdateModList();
            UpdateProgressLabel();
        }

        // Delete mod
        private void toolStripButtonDeleteMod_Click(object sender, EventArgs e)
        {
            if (selectedIndex < 0)
                return;
            if (this.listViewMods.SelectedItems.Count > 1)
            {
                string count = this.listViewMods.SelectedItems.Count.ToString();
                DialogResult res = MsgBox.Get("deleteMultipleQuestion").FormatTitle(count).FormatText(count).Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    List<int> indices = new List<int>();
                    foreach (ListViewItem item in this.listViewMods.SelectedItems)
                        indices.Add(item.Index);
                    DeleteModsBulkThreaded(indices);
                }
            }
            else
            {
                ManagedMod mod = Mods[selectedIndex];
                DialogResult res = MsgBox.Get("deleteQuestion").FormatTitle(mod.Title).FormatText(mod.Title).Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    DeleteModThreaded(selectedIndex);
            }
        }

        // Add mod archive
        private void toolStripButtonAddMod_Click(object sender, EventArgs e)
        {
            if (this.openFileDialogMod.ShowDialog() == DialogResult.OK)
                InstallModArchiveThreaded(this.openFileDialogMod.FileName, false);
        }

        // Add mod folder
        private void toolStripButtonAddModFolder_Click(object sender, EventArgs e)
        {
            if (this.folderBrowserDialogMod.ShowDialog() == DialogResult.OK)
                InstallModFolderThreaded(this.folderBrowserDialogMod.SelectedPath);
        }

        // Add frozen mod archive (*.ba2)
        private void toolStripButtonAddModFrozen_Click(object sender, EventArgs e)
        {
            if (this.openFileDialogBA2.ShowDialog() == DialogResult.OK)
                InstallModArchiveThreaded(this.openFileDialogBA2.FileName, true);
        }

        // Unfreeze
        private void toolStripButtonUnfreeze_Click(object sender, EventArgs e)
        {
            List<int> indices = new List<int>();
            foreach (ListViewItem item in this.listViewMods.SelectedItems)
                indices.Add(item.Index);
            Thread thread = new Thread(() => UnfreezeBulkMods(indices));
            thread.IsBackground = true;
            thread.Start();
            CloseSidePanel();
        }


        #endregion

        #region Menustrip
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
            if (MsgBox.ShowID("modsImportQuestion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ModInstallations.ImportInstalledMods(Mods);
                this.UpdateModList();

                CloseSidePanel();
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
            // TODO: "Show conflicting files"... uhhh, well. As long as it works, I guess?
            List<ModHelpers.Conflict> conflicts = ModHelpers.GetConflictingFiles(Mods.Mods);
            if (conflicts.Count == 0)
            {
                MsgBox.ShowID("modsNoConflictingFiles", MessageBoxIcon.Information);
                return;
            }
            string tempFile = Path.GetTempFileName();
            using (StreamWriter f = File.AppendText(tempFile))
            {
                f.WriteLine("Conflicting mods:");
                foreach (ModHelpers.Conflict conflict in conflicts)
                {
                    f.WriteLine("\n* " + conflict.conflictText + " (" + conflict.conflictingFiles.Count + " conflicting file" + (conflict.conflictingFiles.Count == 1 ? "" : "s") + ")");
                    foreach (string conflictingFile in conflict.conflictingFiles)
                        f.WriteLine("    -> " + conflictingFile);
                }
            }
            Utils.OpenNotepad(tempFile);
        }


        // View > Reload UI
        private void reloadUIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.UpdateUI();
        }

        // Tools > Archive2 > Open Archive2
        private void openArchive2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Archive2.Explore();
        }

        // Tools > Archive2 > Explore *.ba2 archive
        private void exploreba2ArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialogBA2.ShowDialog() == DialogResult.OK)
            {
                Archive2.Explore(this.openFileDialogBA2.FileName);
            }
        }

        // Help > Show guide
        private void showGuideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/FelisDiligens/Fallout76-QuickConfiguration/wiki/Mod-Manager-Guide");
            // Previous pages:
            // https://www.nexusmods.com/fallout76/articles/40
            // https://www.nexusmods.com/fallout76/mods/546
            // https://felisdiligens.github.io/Fo76ini/ManageMods.html
            // Well, I have moved info pages a lot, lol.
        }

        // Help > Log files > Show modmanager.log.txt
        private void showModmanagerlogtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: Logfile
            /*if (File.Exists(ManagedMods.Instance.logFile.GetFilePath()))
                Utils.OpenNotepad(ManagedMods.Instance.logFile.GetFilePath());*/
        }

        // Help > Log files > Show archive2.log.txt
        private void showArchive2logtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Archive2.logFile.GetFilePath()))
                Utils.OpenNotepad(Archive2.logFile.GetFilePath());
        }

        #endregion


        /*
         * Settings
         */

        #region Resource list textboxes
        private void LoadTextBoxResourceLists()
        {
            this.textBoxsResourceIndexFileList.Text = ResourceList.GetResourceIndexFileList().ToString();
            this.textBoxsResourceArchive2List.Text = ResourceList.GetResourceArchive2List().ToString();
        }

        // Clean lists
        private void buttonModsCleanLists_Click(object sender, EventArgs e)
        {
            ResourceList IndexFileList = ResourceList.FromString(this.textBoxsResourceIndexFileList.Text);
            ResourceList Archive2List = ResourceList.FromString(this.textBoxsResourceArchive2List.Text);

            // Remove non-existing files:
            IndexFileList.CleanUp(this.game.GamePath);
            Archive2List.CleanUp(this.game.GamePath);

            // Remove duplicates:
            foreach (string ba2file in Archive2List)
                if (IndexFileList.Contains(ba2file))
                    Archive2List.Remove(ba2file);

            this.textBoxsResourceIndexFileList.Text = IndexFileList.ToString();
            this.textBoxsResourceArchive2List.Text = Archive2List.ToString();
        }

        // Apply changes
        private void buttonModsApplyTextBoxes_Click(object sender, EventArgs e)
        {
            //ManagedMods.Instance.logFile.WriteLine("\n\nSaving changes to resource lists...");

            ResourceList IndexFileList = ResourceList.FromString(this.textBoxsResourceIndexFileList.Text);
            IndexFileList.AssociateTweak(ResourceListTweak.GetSResourceIndexFileList());
            IndexFileList.CommitToINI();

            ResourceList Archive2List = ResourceList.FromString(this.textBoxsResourceArchive2List.Text);
            IndexFileList.AssociateTweak(ResourceListTweak.GetSResourceArchive2List());
            Archive2List.CommitToINI();

            IniFiles.Save();
        }

        // Reset
        private void buttonModsResetTextboxes_Click(object sender, EventArgs e)
        {
            LoadTextBoxResourceLists();
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

        private void checkBoxModsWriteSResourceDataDirsFinal_CheckedChanged(object sender, EventArgs e)
        {
            // TODO: sResourceDataDirsFinal checkbox
            /*ManagedMods.Instance.WriteDataDirs = this.checkBoxModsWriteSResourceDataDirsFinal.Checked;
            IniFiles.Instance.Set(IniFile.Config, "Mods", "bWriteSResourceDataDirsFinal", this.checkBoxModsWriteSResourceDataDirsFinal.Checked);
            IniFiles.Config.Save();*/
        }
        #endregion


        /*
         * Threads
         */

        private void UnfreezeBulkMods(List<int> indices)
        {
            // TODO: Multi-threading??
            ModActions.Unfreeze(Mods, indices);
            /*Invoke(DisableUI);
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
            );*/
        }

        public void Deploy()
        {
            // TODO: Multi-threading??
            ModDeployment.Deploy(Mods);
            /*Invoke(() => this.pictureBoxModsLoadingGIF.Visible = true);
            Invoke(() => ShowLoadingUI());
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
                        this.pictureBoxModsLoadingGIF.Visible = false;

                        if (success)
                        {
                            DisplayAllDone();

                            if (Mods.ModsDisabled)
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
            );*/
        }



        /*
         **********************************************************************************
         * Threaded methods
         **********************************************************************************
         */

        private void InstallModArchiveThreaded(string path, bool freeze)
        {
            DisableUI();
            CloseSidePanel();
            RunThreaded(() => {
                try
                {
                    ModInstallations.InstallArchive(Mods, path, freeze, UpdateProgress);
                }
                catch (Archive2RequirementsException exc)
                {
                    MsgBox.ShowID("archive2InstallRequirements", MessageBoxIcon.Error);
                    return false;
                }
                catch (Archive2Exception exc)
                {
                    MsgBox.ShowID("archive2Error", MessageBoxIcon.Error);
                    return false;
                }
                catch (NotSupportedException exc)
                {
                    MsgBox.ShowID("modsArchiveTypeNotSupported", MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception exc)
                {
                    MsgBox.Get("failed").FormatText(exc.Message).Show(MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }, (success) => {
                EnableUI();
                if (success)
                {
                    selectedIndex = Mods.Count - 1;
                }
                UpdateModList();
            });
        }

        private void InstallModFolderThreaded(string path)
        {
            DisableUI();
            CloseSidePanel();
            RunThreaded(() => {
                try
                {
                    ModInstallations.InstallFolder(Mods, path, UpdateProgress);
                }
                catch (Archive2RequirementsException exc)
                {
                    MsgBox.ShowID("archive2InstallRequirements", MessageBoxIcon.Error);
                    return false;
                }
                catch (Archive2Exception exc)
                {
                    MsgBox.ShowID("archive2Error", MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception exc)
                {
                    MsgBox.Get("failed").FormatText(exc.Message).Show(MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }, (success) => {
                EnableUI();
                if (success)
                {
                    selectedIndex = Mods.Count - 1;
                }
                UpdateModList();
            });
        }

        private void InstallBulkThreaded(string[] files)
        {
            DisableUI();
            CloseSidePanel();
            RunThreaded(() => {
                try
                {
                    InstallBulk(files);
                }
                catch (Archive2RequirementsException exc)
                {
                    MsgBox.ShowID("archive2InstallRequirements", MessageBoxIcon.Error);
                    return false;
                }
                catch (Archive2Exception exc)
                {
                    MsgBox.ShowID("archive2Error", MessageBoxIcon.Error);
                    return false;
                }
                catch (NotSupportedException exc)
                {
                    MsgBox.ShowID("modsArchiveTypeNotSupported", MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception exc)
                {
                    MsgBox.Get("failed").FormatText(exc.Message).Show(MessageBoxIcon.Error);
                    return false;
                }
                return true;
            }, (success) => {
                EnableUI();
                if (success)
                {
                    selectedIndex = -1;
                    UpdateProgress(Progress.Done("Mods imported."));
                }
                UpdateModList();
            });
        }

        private void InstallBulk(string[] files)
        {
            bool unpackBA2ByDefault = IniFiles.Config.GetBool("Mods", "bUnpackBA2ByDefault", false);
            int i = 0;
            foreach (string filePath in files)
            {
                UpdateProgress(Progress.Ongoing($"Importing {++i} of {files.Length} files/folders...", (float)i / (float)files.Length));
                string longFilePath = ModInstallations.EnsureLongPathSupport(filePath);
                if (Directory.Exists(longFilePath))
                    ModInstallations.InstallFolder(Mods, filePath);
                else
                    ModInstallations.InstallArchive(Mods, filePath, !unpackBA2ByDefault);
            }
        }

        private void DeleteModThreaded(int index)
        {
            DisableUI();
            CloseSidePanel();
            RunThreaded(() => {
                ModActions.DeleteMod(Mods, index, UpdateProgress);
                return true;
            }, (success) => {
                EnableUI();
                if (success)
                    selectedIndex = -1;
                UpdateModList();
            });
        }

        private void DeleteModsBulkThreaded(List<int> indices)
        {
            ModActions.DeleteMods(Mods, indices);
            DisableUI();
            CloseSidePanel();
            RunThreaded(() => {
                ModActions.DeleteMods(Mods, indices, UpdateProgress);
                return true;
            }, (success) => {
                EnableUI();
                if (success)
                {
                    selectedIndex = -1;
                }
                UpdateModList();
            });
        }



        /*
         **********************************************************************************
         * Utility methods
         **********************************************************************************
         */

        private void RunThreaded(Func<bool> doWork, Action<bool> finishWork)
        {
            Thread thread = new Thread(() =>
            {
                bool result = doWork();
                this.Invoke(new Action(() => finishWork(result)));
            });
            thread.IsBackground = true;
            thread.Start();
        }

        private void UpdateProgress(Progress progress)
        {
            this.progressBarMods.Invoke(new Action(() => {
                this.labelModsDeploy.Visible = true;
                progress.Update(labelModsDeploy, progressBarMods);
            }));
        }

        private void HideLabel()
        {
            this.labelModsDeploy.Visible = false;
        }

        private void DisplayDeploymentNecessary()
        {
            this.labelModsDeploy.Visible = true;
            this.labelModsDeploy.ForeColor = Color.Crimson;
            this.labelModsDeploy.Text = Localization.GetString("modsDeploymentNecessary");
        }

        private void DisplayAllDone()
        {
            this.labelModsDeploy.Visible = true;
            this.labelModsDeploy.ForeColor = Color.DarkGreen;
            this.labelModsDeploy.Text = Localization.GetString("modsAllDone");
        }

        private void UpdateProgressLabel()
        {
            if (Mods.isDeploymentNecessary())
                this.DisplayDeploymentNecessary();
            else
                this.DisplayAllDone();
        }
    }
}
