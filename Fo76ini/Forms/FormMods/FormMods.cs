using Fo76ini.Interface;
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
using System.Xml;

namespace Fo76ini
{
    public partial class FormMods : Form
    {
        private int selectedIndex = -1;
        private List<int> selectedIndices = new List<int>();

        private GameInstance game;
        private ManagedMods Mods;

        public static event NuclearWinterEventHandler NWModeUpdated;

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
                "labelModTitle",
                "labelModsDeploy",
                "labelModSummary",
                "labelModLatestVersion",
                "labelModAuthor",
                "labelModEndorseStatus",
                "labelModGUID",
                "labelModInstallWarning",
                "toolStripStatusLabelModCount",
                "toolStripStatusLabelDeploymentStatus",
                "toolStripStatusLabelSpacer",
                "toolStripStatusLabelEnabledCount"
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
        }

        private void OnProfileChanged(object sender, ProfileEventArgs e)
        {
            this.game = e.ActiveGameInstance;
            ReloadModManager();
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
                CloseSidePanel();
                Configuration.SaveWindowState("FormMods", this);
                Configuration.SaveListViewState("FormMods", this.listViewMods);
                e.Cancel = true;
                if (this.buttonModsDeploy.Enabled)
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
            if (!game.ValidateGamePath())
                return;
            try
            {
                CloseSidePanel();
                LoadMods(game.GamePath);
                UpdateUI();
                TriggerNWModeUpdated();

                if (!LegacyManagedMods.CheckLegacy(game.GamePath))
                    Mods.SaveResources();
            }
            catch (Exception exc)
            {
                MsgBox.Popup("Failed to load mods", $"Failed to load mods.\n{exc.GetType()}: {exc.Message}", MessageBoxIcon.Error);
            }
        }

        private bool ConvertLegacyConditional()
        {
            if (LegacyManagedMods.CheckLegacy(game.GamePath))
            {
                DialogResult resp = MsgBox.ShowID("modsLegacyFormatDetected", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.No)
                    return false;
                else if (resp == DialogResult.Yes)
                    ConvertLegacyThreaded();
            }
            return true;
        }

        private void ConvertLegacyThreaded()
        {
            RunThreaded(() => {
                ShowLoadingUI();
            }, () => {
                LegacyManagedMods.ConvertLegacy(Mods, game.Edition, UpdateProgress);
                return true;
            }, (success) => {
                UpdateUI();
                EnableUI();
            });
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

            if (!ConvertLegacyConditional())
                return;

            Show();
            Focus();
        }

        /// <summary>
        /// Updates the form.
        /// </summary>
        private void UpdateUI()
        {
            UpdateSelectedIndices();
            UpdateModList();
            UpdateSettings();
            UpdateStatusStrip();
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
            //UpdateSelectedIndices();
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
                    case ManagedMod.DeploymentMethod.LooseFiles:
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

            LoadTextBoxResourceList(Mods.Resources);
        }

        private void UpdateSelectedIndices()
        {
            this.selectedIndices.Clear();
            foreach (ListViewItem item in this.listViewMods.SelectedItems)
                this.selectedIndices.Add(item.Index);
        }

        private void RestoreSelectedIndices()
        {
            // Doesn't work.
            foreach (ListViewItem item in this.listViewMods.Items)
                if (selectedIndices.Contains(item.Index))
                    item.Selected = true;
                else
                    item.Selected = false;
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
            this.tabControl1.SelectedIndex = 0;
            this.tabPageModsSettings.Enabled = false;

            this.pictureBoxModsLoadingGIF.Visible = true;
            this.pictureBoxModsLoadingGIF.Width = this.Width;
            this.pictureBoxModsLoadingGIF.Height = this.tabControl1.Height;
            this.pictureBoxModsLoadingGIF.Anchor =
                AnchorStyles.Top    |
                AnchorStyles.Bottom |
                AnchorStyles.Left   |
                AnchorStyles.Right;
        }

        #endregion

        /*
         **********************************************************************************
         * Nuclear Winter mode
         **********************************************************************************
         */

        #region Nuclear Winter mode

        public void ToggleNuclearWinterMode()
        {
            if (Mods.NuclearWinterModeEnabled)
                DisableNuclearWinterMode();
            else
                EnableNuclearWinterMode();
        }

        public void EnableNuclearWinterMode()
        {
            Mods.NuclearWinterModeEnabled = true;

            // Uninstall mods:
            if (!Mods.ModsDisabled &&
                IniFiles.Config.GetBool("NuclearWinter", "bAutoDisableMods", true))
            {
                Mods.ModsDisabled = true;
                this.DeployMods();
            }

            // Rename added *.dll files:
            if (IniFiles.Config.GetBool("NuclearWinter", "bRenameDLLs", true))
                ModDeployment.RenameAddedDLLs(Mods.GamePath);

            // Backwards-compatibility:
            IniFiles.Config.Set("NuclearWinter", "bNWMode", true);
            IniFiles.Config.Set("Preferences", "bNWMode", true);

            // Save and update UI:
            Mods.Save();
            TriggerNWModeUpdated();
        }

        public void DisableNuclearWinterMode()
        {
            Mods.NuclearWinterModeEnabled = false;

            // Install mods:
            if (Mods.ModsDisabled &&
                IniFiles.Config.GetBool("NuclearWinter", "bAutoDeployMods", true))
            {
                Mods.ModsDisabled = false;
                if (Mods.Count() > 0)
                    this.DeployMods();
            }

            // Restore added *.dll files:
            ModDeployment.RestoreAddedDLLs(Mods.GamePath);

            // Backwards-compatibility:
            IniFiles.Config.Set("NuclearWinter", "bNWMode", false);
            IniFiles.Config.Set("Preferences", "bNWMode", false);

            // Save and update UI:
            Mods.Save();
            TriggerNWModeUpdated();
        }

        private void TriggerNWModeUpdated()
        {
            if (NWModeUpdated != null)
                NWModeUpdated(null, BuildNuclearWinterEventArgs());
        }

        public bool IsNuclearWinterModeEnabled()
        {
            return Mods.NuclearWinterModeEnabled;
        }

        public void ToggleNuclearWinterModeThreaded()
        {
            if (Mods.NuclearWinterModeEnabled)
                DisableNuclearWinterModeThreaded();
            else
                EnableNuclearWinterModeThreaded();
        }

        public void EnableNuclearWinterModeThreaded()
        {
            Show();
            Focus();
            RunThreaded(() => {
                CloseSidePanel();
                ShowLoadingUI();
            }, () => {
                EnableNuclearWinterMode();
                return true;
            }, (success) => {
                if (success)
                    MsgBox.Get("nwModeDisabled").Popup(MessageBoxIcon.Information);
                UpdateUI();
                EnableUI();
                Hide();
            });
        }

        public void DisableNuclearWinterModeThreaded()
        {
            Show();
            Focus();
            RunThreaded(() => {
                CloseSidePanel();
                ShowLoadingUI();
            }, () => {
                DisableNuclearWinterMode();
                return true;
            }, (success) => {
                if (success)
                    MsgBox.Get("nwModeDisabled").Popup(MessageBoxIcon.Information);
                UpdateUI();
                EnableUI();
                Hide();
            });
        }

        private NuclearWinterEventArgs BuildNuclearWinterEventArgs()
        {
            NuclearWinterEventArgs args = new NuclearWinterEventArgs();
            args.NuclearWinterModeEnabled = Mods.NuclearWinterModeEnabled;
            return args;
        }

        #endregion

        /*
         **********************************************************************************
         * Event handler
         **********************************************************************************
         */

        // Deploy
        private void buttonModsDeploy_Click(object sender, EventArgs e)
        {
            DeployModsThreaded();
        }

        // Disable mods
        private void checkBoxDisableMods_CheckedChanged(object sender, EventArgs e)
        {
            this.Mods.ModsDisabled = checkBoxDisableMods.Checked;
            this.Mods.Save();
            UpdateStatusStrip();
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

            if (e.Control && e.KeyCode == Keys.S)
            {
                // Save changes:
                saveToolStripMenuItem_Click(sender, e);
            }

            if (e.Control && e.KeyCode == Keys.A)
            {
                // Select all:
                foreach (ListViewItem item in this.listViewMods.Items)
                    item.Selected = true;
                UpdateSelectedIndices();
            }

            // These shortcuts only apply to the mod list:
            if (this.listViewMods.Focused)
            {
                if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                {
                    // Delete mods:
                    toolStripButtonDeleteMod_Click(sender, e);
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
            if (isUpdating)
                return;

            if (this.listViewMods.SelectedItems.Count > 0)
                selectedIndex = this.listViewMods.SelectedItems[0].Index;
            else
                selectedIndex = -1;

            // Edit mod:
            UpdateSelectedIndices();
            if (selectedIndices.Count() > 0)
                EditMods(selectedIndices);
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

            UpdateStatusStrip();
            if (sidePanelStatus != SidePanelStatus.Closed)
                UpdateSidePanel();
        }

        #endregion

        #region Toolstrip event handler

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
            //CloseSidePanel();
            /*if (selectedIndex < 0)
                return;
            selectedIndex = ManagedMods.Instance.MoveModUp(selectedIndex);*/
            List<int> newSelectedIndices = new List<int>();
            if (selectedIndices.Count <= 0)
                return;
            else if (selectedIndices.Count == 1)
            {
                selectedIndex = Mods.MoveModUp(selectedIndex);
                newSelectedIndices.Add(selectedIndex);
            }
            else
            {
                selectedIndex = -1;
                selectedIndices = selectedIndices.OrderBy(i => i).ToList();
                foreach (int index in selectedIndices)
                    newSelectedIndices.Add(Mods.MoveModUp(index));
            }
            selectedIndices = newSelectedIndices;
            UpdateModList();
            UpdateStatusStrip();
        }

        // Move down
        private void toolStripButtonMoveDown_Click(object sender, EventArgs e)
        {
            UpdateSelectedIndices();
            //CloseSidePanel();
            /*if (selectedIndex < 0)
                return;
            selectedIndex = ManagedMods.Instance.MoveModDown(selectedIndex);*/
            List<int> newSelectedIndices = new List<int>();
            if (selectedIndices.Count <= 0)
                return;
            else if (selectedIndices.Count == 1)
            {
                selectedIndex = Mods.MoveModDown(selectedIndex);
                newSelectedIndices.Add(selectedIndex);
            }
            else
            {
                selectedIndex = -1;
                selectedIndices = selectedIndices.OrderByDescending(i => i).ToList();
                foreach (int index in selectedIndices)
                    newSelectedIndices.Add(Mods.MoveModDown(index));
            }
            selectedIndices = newSelectedIndices;
            UpdateModList();
            UpdateStatusStrip();
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
            UpdateSelectedIndices();
            UpdateModList();
            UpdateStatusStrip();
            if (sidePanelStatus != SidePanelStatus.Closed)
                UpdateSidePanel();
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


        #endregion

        #region Menustrip
        /*
         * Menu
         */

        // File > Add mod > Empty mod
        private void emptyModToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModInstallations.InstallBlank(Mods);
            UpdateModList();
        }

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
            if (this.openFileDialogBA2.ShowDialog() == DialogResult.OK)
                InstallModArchiveThreaded(this.openFileDialogBA2.FileName, true);
        }

        // File > Import installed mods
        private void toolStripMenuItemModsImport_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowID("modsImportQuestion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ImportInstalledModsThreaded(UpdateProgress);
                this.UpdateModList();

                CloseSidePanel();
            }
        }

        // File > Deploy
        private void deployToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonModsDeploy_Click(sender, e);
        }

        // File > Save
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mods.Save();
            this.labelModsDeploy.Text = "Changes saved.";
            this.labelModsDeploy.ForeColor = Color.DarkGreen;
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
            if (this.sidePanelStatus != SidePanelStatus.Closed)
                UpdateSidePanel();
        }

        // View > Show loading animation
        private void showLoadingAnimationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunThreaded(() => {
                ShowLoadingUI();
            }, () => {
                for (int i = 1; i <= 5 * 2; i++)
                {
                    this.progressBarMods.Invoke(new Action(() => {
                        this.progressBarMods.Value = (int)((float)i * 100 / 10);
                    }));
                    Thread.Sleep(500);
                }
                return true;
            }, (success) => {
                this.progressBarMods.Value = 0;
                EnableUI();
            });
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

        // Tools > NexusMods > Update mod information
        private void updateModInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateRemoteModInfoThreaded();
        }

        // Tools > NexusMods > Endorse mods
        private void endorseModsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowID("nexusModsEndorseAllQuestion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                EndorseModsThreaded();
        }

        // Tools > NexusMods > Check for updates
        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckForUpdatesThreaded();
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
        #endregion



        /*
         **********************************************************************************
         * Threaded methods
         **********************************************************************************
         */
        #region Threaded methods

        private void InstallModArchiveThreaded(string path, bool freeze)
        {
            RunThreaded(() => {
                DisableUI();
                CloseSidePanel();
            }, () => {
                try
                {
                    ModInstallations.InstallArchive(Mods, path, freeze, UpdateProgress);
                }
                catch (Archive2RequirementsException exc)
                {
                    MsgBox.ShowID("archive2InstallRequirements", MessageBoxIcon.Error);
                    UpdateProgress(Progress.Aborted("Archive2 installation requirements not met.", exc));
                    return false;
                }
                catch (Archive2Exception exc)
                {
                    MsgBox.ShowID("archive2Error", MessageBoxIcon.Error);
                    UpdateProgress(Progress.Aborted("Archive2 error", exc));
                    return false;
                }
                catch (NotSupportedException exc)
                {
                    MsgBox.ShowID("modsArchiveTypeNotSupported", MessageBoxIcon.Error);
                    UpdateProgress(Progress.Aborted("Failed", exc));
                    return false;
                }
                catch (Exception exc)
                {
                    MsgBox.Get("failed").FormatText(exc.Message).Show(MessageBoxIcon.Error);
                    UpdateProgress(Progress.Aborted("Failed", exc));
                    return false;
                }
                return true;
            }, (success) => {
                EnableUI();
                if (success)
                {
                    selectedIndex = Mods.Count - 1;
                    selectedIndices.Clear();
                    selectedIndices.Add(selectedIndex);
                }
                UpdateModList();
                UpdateStatusStrip();
            });
        }

        private void InstallModFolderThreaded(string path)
        {
            RunThreaded(() => {
                DisableUI();
                CloseSidePanel();
            }, () => {
                try
                {
                    ModInstallations.InstallFolder(Mods, path, UpdateProgress);
                }
                catch (Archive2RequirementsException exc)
                {
                    MsgBox.ShowID("archive2InstallRequirements", MessageBoxIcon.Error);
                    UpdateProgress(Progress.Aborted("Archive2 installation requirements not met.", exc));
                    return false;
                }
                catch (Archive2Exception exc)
                {
                    MsgBox.ShowID("archive2Error", MessageBoxIcon.Error);
                    UpdateProgress(Progress.Aborted("Archive2 error", exc));
                    return false;
                }
                catch (Exception exc)
                {
                    MsgBox.Get("failed").FormatText(exc.Message).Show(MessageBoxIcon.Error);
                    UpdateProgress(Progress.Aborted("Failed", exc));
                    return false;
                }
                return true;
            }, (success) => {
                EnableUI();
                if (success)
                {
                    selectedIndex = Mods.Count - 1;
                    selectedIndices.Clear();
                    selectedIndices.Add(selectedIndex);
                }
                UpdateModList();
                UpdateStatusStrip();
            });
        }

        private void InstallBulkThreaded(string[] files)
        {
            RunThreaded(() => {
                DisableUI();
                CloseSidePanel();
            }, () => {
                try
                {
                    InstallBulk(files);
                }
                catch (Archive2RequirementsException exc)
                {
                    MsgBox.ShowID("archive2InstallRequirements", MessageBoxIcon.Error);
                    UpdateProgress(Progress.Aborted("Archive2 installation requirements not met.", exc));
                    return false;
                }
                catch (Archive2Exception exc)
                {
                    MsgBox.ShowID("archive2Error", MessageBoxIcon.Error);
                    UpdateProgress(Progress.Aborted("Archive2 error", exc));
                    return false;
                }
                catch (NotSupportedException exc)
                {
                    MsgBox.ShowID("modsArchiveTypeNotSupported", MessageBoxIcon.Error);
                    UpdateProgress(Progress.Aborted("Failed", exc));
                    return false;
                }
                catch (Exception exc)
                {
                    MsgBox.Get("failed").FormatText(exc.Message).Show(MessageBoxIcon.Error);
                    UpdateProgress(Progress.Aborted("Failed", exc));
                    return false;
                }
                return true;
            }, (success) => {
                EnableUI();
                if (success)
                {
                    selectedIndex = -1;
                    selectedIndices.Clear();
                    UpdateProgress(Progress.Done("Mods imported."));
                }
                UpdateModList();
                UpdateStatusStrip();
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
            RunThreaded(() => {
                CloseSidePanel();
                DisableUI();
            }, () => {
                ModActions.DeleteMod(Mods, index, UpdateProgress);
                return true;
            }, (success) => {
                EnableUI();
                if (success)
                {
                    selectedIndex = -1;
                    selectedIndices.Clear();
                }
                UpdateModList();
                UpdateStatusStrip();
            });
        }

        private void DeleteModsBulkThreaded(List<int> indices)
        {
            RunThreaded(() => {
                CloseSidePanel();
                DisableUI();
            }, () => {
                ModActions.DeleteMods(Mods, indices, UpdateProgress);
                return true;
            }, (success) => {
                EnableUI();
                if (success)
                {
                    selectedIndex = -1;
                    selectedIndices.Clear();
                }
                UpdateModList();
                UpdateStatusStrip();
            });
        }

        private bool DeployMods()
        {
            try
            {
                ModDeployment.Deploy(Mods, UpdateProgress);
            }
            catch (Archive2RequirementsException exc)
            {
                MsgBox.ShowID("archive2InstallRequirements", MessageBoxIcon.Error);
                UpdateProgress(Progress.Aborted("Archive2 installation requirements not met.", exc));
                return false;
            }
            catch (Archive2Exception exc)
            {
                MsgBox.ShowID("archive2Error", MessageBoxIcon.Error);
                UpdateProgress(Progress.Aborted("Archive2 error", exc));
                return false;
            }
            catch (Exception exc)
            {
                MsgBox.Get("failed").FormatText(exc.Message).Show(MessageBoxIcon.Error);
                UpdateProgress(Progress.Aborted("Failed", exc));
                return false;
            }
            return true;
        }

        private void DeployModsThreaded()
        {
            RunThreaded(() => {
                CloseSidePanel();
                ShowLoadingUI();
            }, () => {
                return DeployMods();
            }, (success) => {
                if (success)
                {
                    if (Mods.ModsDisabled)
                        MsgBox.Get("modsDisabledDone").Popup(MessageBoxIcon.Information);
                    else
                        MsgBox.Get("modsDeployedDone").Popup(MessageBoxIcon.Information);
                }
                else
                {
                    MsgBox.Get("modsDeploymentFailed").Popup(MessageBoxIcon.Information);
                }
                UpdateUI();
                EnableUI();
            });
        }

        private void UpdateRemoteModInfoThreaded()
        {
            if (!NexusMods.User.IsLoggedIn)
            {
                MsgBox.ShowID("nexusModsNotLoggedIn", MessageBoxIcon.Information);
                return;
            }
            RunThreaded(() => {
                CloseSidePanel();
                ShowLoadingUI();
            }, () => {
                UpdateRemoteModInfo(UpdateProgress);
                return true;
            }, (success) => {
                EnableUI();
                UpdateUI();
            });
        }

        private void CheckForUpdatesThreaded()
        {
            if (!NexusMods.User.IsLoggedIn)
            {
                MsgBox.ShowID("nexusModsNotLoggedIn", MessageBoxIcon.Information);
                return;
            }
            RunThreaded(() => {
                CloseSidePanel();
                ShowLoadingUI();
            }, () => {
                UpdateRemoteModInfo(UpdateProgress);
                return true;
            }, (success) => {
                EnableUI();
                UpdateModList();
                UpdateStatusStrip();

                // TODO: Check for updates could be so much better.
                List<string> modsWithUpdates = new List<string>();
                foreach (ManagedMod mod in Mods)
                    if (mod.RemoteInfo != null && Utils.CompareVersions(mod.Version, mod.RemoteInfo.LatestVersion) < 0)
                        modsWithUpdates.Add($"{mod.Title} (updated from {mod.Version} to {mod.RemoteInfo.LatestVersion})");

                if (modsWithUpdates.Count() > 0)
                {
                    MsgBox.Show("Updates available", $"{modsWithUpdates.Count()} updates found:\n\n{String.Join("\n", modsWithUpdates)}", MessageBoxIcon.Information);
                }
                else
                {
                    MsgBox.Show("Up to date", "No updates found.", MessageBoxIcon.Information);
                }
            });
        }

        private void EndorseModsThreaded()
        {
            if (!NexusMods.User.IsLoggedIn)
            {
                MsgBox.ShowID("nexusModsNotLoggedIn", MessageBoxIcon.Information);
                return;
            }
            RunThreaded(() => {
                CloseSidePanel();
                DisableUI();
            }, () => {
                EndorseMods(UpdateProgress);
                return true;
            }, (success) => {
                EnableUI();
            });
        }

        private void EndorseMods(Action<Progress> ProgressChanged = null)
        {
            int i = 0;
            foreach (ManagedMod mod in Mods)
            {
                i++;
                if (mod.RemoteInfo != null && mod.Version != null && mod.Version != "" && mod.RemoteInfo.Endorsement != NMMod.EndorseStatus.Endorsed)
                {
                    mod.RemoteInfo.Endorse(mod.Version);
                    ProgressChanged?.Invoke(Progress.Ongoing($"Endorsing \"{mod.Title}\"", (float)i / (float)Mods.Count()));
                }
            }
            ProgressChanged?.Invoke(Progress.Done("All mods endorsed."));
        }

        private void UpdateRemoteModInfo(Action<Progress> ProgressChanged = null)
        {
            int i = 0;
            int len = Mods.Count();
            List<int> updatedIDs = new List<int>();
            foreach (ManagedMod mod in Mods)
            {
                i++;
                if (mod.URL != "")
                {
                    // Don't update mods twice:
                    if (updatedIDs.Contains(mod.ID))
                        continue;
                    updatedIDs.Add(mod.ID);

                    // Don't update mods in quick succession (1 minute):
                    if (mod.RemoteInfo != null)
                    {
                        long lastUpdated = Utils.GetUnixTimeStamp() - mod.RemoteInfo.LastAccessTimestamp;
                        if (lastUpdated < 60)
                            continue;
                    }

                    ProgressChanged?.Invoke(Progress.Ongoing($"[{i}/{len}] Requesting info for \"{mod.Title}\"", (float)i / (float)len));
                    NexusMods.RequestModInformation(mod.URL);
                }
            }
            ProgressChanged?.Invoke(Progress.Done("Mod information updated."));
            NexusMods.Save();
        }

        private void ImportInstalledModsThreaded(Action<Progress> ProgressChanged = null)
        {
            RunThreaded(() => {
                ShowLoadingUI();
                CloseSidePanel();
            }, () => {
                ModInstallations.ImportInstalledMods(Mods, ProgressChanged);
                return true;
            }, (success) => {
                EnableUI();
            });
        }

        #endregion


        /*
         **********************************************************************************
         * Utility methods
         **********************************************************************************
         */
        #region Utility methods

        private void RunThreaded(Action prepareWork, Func<bool> doWork, Action<bool> finishWork)
        {
            Thread thread = new Thread(() =>
            {
                this.Invoke(prepareWork);
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

        private void DisplayDeploymentNecessary()
        {
            this.toolStripStatusLabelDeploymentStatus.Visible = true;
            this.toolStripStatusLabelDeploymentStatus.ForeColor = Color.Crimson;
            this.toolStripStatusLabelDeploymentStatus.Text = Localization.GetString("modsDeploymentNecessary");
        }

        private void DisplayAllDone()
        {
            this.toolStripStatusLabelDeploymentStatus.Visible = false;
        }

        private void UpdateStatusStrip()
        {
            if (Mods.isDeploymentNecessary())
                this.DisplayDeploymentNecessary();
            else
                this.DisplayAllDone();

            this.toolStripStatusLabelModCount.Text = Mods.Count().ToString();

            int enabledCount = 0;
            foreach (ManagedMod mod in Mods)
                if (mod.Enabled)
                    enabledCount++;
            this.toolStripStatusLabelEnabledCount.Text = enabledCount.ToString();
        }

        #endregion
    }


    public delegate void NuclearWinterEventHandler(object sender, NuclearWinterEventArgs e);

    public class NuclearWinterEventArgs : EventArgs
    {
        public bool NuclearWinterModeEnabled;
    }
}
