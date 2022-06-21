using Fo76ini.Forms.FormTextPrompt;
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
        private bool preventClosing = false;

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
            InitializeSidePanelControls();
            InitializeObjectListView();

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
        }

        private void OnProfileChanged(object sender, ProfileEventArgs e)
        {
            this.game = e.ActiveGameInstance;
            ReloadModManager();
        }

        private void FormMods_Load(object sender, EventArgs e)
        {
            Configuration.LoadWindowState("FormMods", this);
            Configuration.LoadListViewState("FormMods.OLV", this.objectListViewMods);
        }

        private void FormMods_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                CloseSidePanel();
                Configuration.SaveWindowState("FormMods", this);
                Configuration.SaveListViewState("FormMods.OLV", this.objectListViewMods);
                e.Cancel = true;
                if (!preventClosing)
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
                EnableUI();
                if (!Directory.Exists(Path.Combine(game.GamePath, "Mods")))
                    Directory.CreateDirectory(Path.Combine(game.GamePath, "Mods"));
                CloseSidePanel();
                LoadMods(game.GamePath);
                UpdateUI();
                TriggerNWModeUpdated();

                if (!LegacyManagedMods.CheckLegacy(game.GamePath))
                    Mods.SaveResources();
            }
            catch (Exception exc)
            {
                if (exc is UnauthorizedAccessException && !Utils.HasAdminRights())
                {
                    MsgBox.Popup("Failed to load mods",
                        $"Try to start the program with admin rights.\n" +
                        $"Right-click on the desktop icon or *.exe file and click on 'Run as administrator'.\n\n" +
                        $"{exc.GetType()}: {exc.Message}",
                        MessageBoxIcon.Error);
                }
                else
                {
                    MsgBox.Popup("Failed to load mods", $"Failed to load mods.\n" +
                        $"{exc.GetType()}: {exc.Message}", MessageBoxIcon.Error);
                }

                this.DisableUI();
                this.preventClosing = false;
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

            Show();
            Focus();

            if (!ConvertLegacyConditional())
            {
                Hide();
                return;
            }
        }

        /// <summary>
        /// Updates the form.
        /// </summary>
        private void UpdateUI()
        {
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
            isUpdating = true;
            UpdateObjectListView();
            isUpdating = false;
        }

        private void EnableUI()
        {
            this.tabControl1.Enabled = true;
            this.pictureBoxModsLoadingGIF.Visible = false;
            this.tabPageModsSettings.Enabled = true;
            this.buttonModsDeploy.Enabled = true;
            this.menuStrip1.Enabled = true;
            this.checkBoxDisableMods.Enabled = true;
            //this.listViewMods.Enabled = true;
            this.toolStrip1.Enabled = true;
            this.preventClosing = false;
            this.timerCheckForNXM.Start();
        }

        private void DisableUI()
        {
            this.tabControl1.Enabled = false;
            this.buttonModsDeploy.Enabled = false;
            this.menuStrip1.Enabled = false;
            this.checkBoxDisableMods.Enabled = false;
            this.preventClosing = true;
            this.timerCheckForNXM.Stop();
        }

        private void DisableUI_SidePanelOpen()
        {
            //this.listViewMods.Enabled = false;
            this.toolStrip1.Enabled = false;
            this.buttonModsDeploy.Enabled = false;
            this.checkBoxDisableMods.Enabled = false;
            this.menuStrip1.Enabled = false;
            this.tabPageModsSettings.Enabled = false;
            this.preventClosing = true;
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
            ModDeployment.LogFile.WriteLine("\n");
            ModDeployment.LogFile.WriteTimeStamp();
            ModDeployment.LogFile.WriteLine("Enabling Nuclear Winter mode");

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
            ModDeployment.LogFile.WriteLine("NW mode enabled, done.");
        }

        public void DisableNuclearWinterMode()
        {
            ModDeployment.LogFile.WriteLine("\n");
            ModDeployment.LogFile.WriteTimeStamp();
            ModDeployment.LogFile.WriteLine("Disabling Nuclear Winter mode");

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
            ModDeployment.LogFile.WriteLine("NW mode disabled, done.");
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
            if (Mods == null)
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Error);
                TriggerNWModeUpdated();
                return;
            }

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
                    MsgBox.Get("nwModeEnabled").Popup(MessageBoxIcon.Information);
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
            if (Mods != null)
                args.NuclearWinterModeEnabled = Mods.NuclearWinterModeEnabled;
            else
                args.NuclearWinterModeEnabled = false;
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

        // Timer:
        private void timerCheckForNXM_Tick(object sender, EventArgs e)
        {
            string txtPath = Path.Combine(Shared.AppConfigFolder, "nxm.txt");
            if (File.Exists(txtPath))
            {
                string nxmLink = File.ReadAllText(txtPath);
                File.Delete(txtPath);
                OpenUI();
                DownloadModThreaded(nxmLink, UpdateProgress);
            }
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

            // These shortcuts only apply to the mod list:
            if (this.objectListViewMods.Focused)
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
                else if (e.Control && e.KeyCode == Keys.A)
                {
                    SelectAll();
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    DeselectAll();
                }
            }
        }

        #endregion

        #region Toolstrip event handler

        // Open mod folder:
        private void toolStripButtonModOpenFolder_Click(object sender, EventArgs e)
        {
            OpenSelectedModsFolder();
        }

        // Move up
        private void toolStripButtonMoveUp_Click(object sender, EventArgs e)
        {
            MoveSelectedModsUp();
            UpdateModList();
        }

        // Move down
        private void toolStripButtonMoveDown_Click(object sender, EventArgs e)
        {
            MoveSelectedModsDown();
            UpdateModList();
        }

        // Check/uncheck all
        private void toolStripButtonCheckAll_Click(object sender, EventArgs e)
        {
            ToggleCheckboxes();

            UpdateModList();
            UpdateStatusStrip();
            if (sidePanelStatus != SidePanelStatus.Closed)
                UpdateSidePanel();
        }

        // Delete mod
        private void toolStripButtonDeleteMod_Click(object sender, EventArgs e)
        {
            DeleteSelectedMods();
        }

        // Freeze mod(s)
        private void toolStripButtonFreeze_Click(object sender, EventArgs e)
        {
            FreezeSelectedMods();
            UpdateModList();
        }

        // Unfreeze mod(s)
        private void toolStripButtonModUnfreeze_Click(object sender, EventArgs e)
        {
            UnfreezeSelectedMods();
            UpdateModList();
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
            Process.Start(Shared.URLs.AppModManagerHelpURL);
            // Previous pages:
            // https://www.nexusmods.com/fallout76/articles/40
            // https://www.nexusmods.com/fallout76/mods/546
            // https://felisdiligens.github.io/Fo76ini/ManageMods.html
            // Well, I have moved info pages a lot, lol.
        }

        // Help > Log files > Show modmanager.log.txt
        private void showModmanagerlogtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(ModDeployment.LogFile.GetFilePath()))
                Utils.OpenNotepad(ModDeployment.LogFile.GetFilePath());
        }

        // Help > Log files > Show archive2.log.txt
        private void showArchive2logtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Archive2.LogFile.GetFilePath()))
                Utils.OpenNotepad(Archive2.LogFile.GetFilePath());
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
                    SetSelectedIndex(Mods.Count - 1);
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
                    SetSelectedIndex(Mods.Count - 1);
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
                    DeselectAll();
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
                else if (File.Exists(longFilePath))
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
                    DeselectAll();
                UpdateUI();
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
                    DeselectAll();
                UpdateUI();
            });
        }

        private bool DeployMods()
        {
            try
            {
                bool invalidateBundledFrozenArchives = true;
                if (IniFiles.Config.GetBool("Mods", "bFreezeBundledArchives", false))
                    invalidateBundledFrozenArchives = MsgBox.Get("modsRepackFrozenBundledArchives").Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
                ModDeployment.Deploy(Mods, UpdateProgress, invalidateBundledFrozenArchives);
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
                UpdateUI();
                EnableUI();
                if (success)
                {
                    if (Mods.ModsDisabled)
                        MsgBox.Get("modsDisabledDone").Popup(MessageBoxIcon.Information);
                    else
                        MsgBox.Get("modsDeployedDone").Popup(MessageBoxIcon.Information);
                    DisplayAllDone();
                }
                else
                {
                    MsgBox.Get("modsDeploymentFailed").Popup(MessageBoxIcon.Information);
                }
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
                    if (mod.RemoteInfo != null && mod.Version != mod.RemoteInfo.LatestVersion)
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

        private void DownloadModThreaded(string nxmLink, Action<Progress> ProgressChanged = null)
        {
            if (!NexusMods.User.IsLoggedIn)
            {
                MsgBox.ShowID("nexusModsNotLoggedIn", MessageBoxIcon.Information);
                return;
            }
            bool unpackBA2ByDefault = IniFiles.Config.GetBool("Mods", "bUnpackBA2ByDefault", false);
            RunThreaded(() => {
                ShowLoadingUI();
                CloseSidePanel();
            }, () => {
                return ModInstallations.InstallRemote(Mods, nxmLink, !unpackBA2ByDefault, ProgressChanged);
            }, (success) => {
                EnableUI();
                if (success)
                    MsgBox.Popup("Success", "Mod downloaded and installed!", MessageBoxIcon.Information);
                else
                    MsgBox.Popup("Failed", "Something went wrong.", MessageBoxIcon.Error);
                UpdateUI();
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
