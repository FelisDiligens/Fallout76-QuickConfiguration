using Fo76ini.Controls;
using Fo76ini.Interface;
using Fo76ini.Mods;
using Fo76ini.API;
using Fo76ini.Profiles;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using CefSharp;
using Newtonsoft.Json;
using Fo76ini.Utilities.Browser;

namespace Fo76ini
{
    public partial class FormMods : Form, IExposeComponents
    {
        public ToolTip ToolTip => this.toolTip;

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

            this.menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            this.menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomToolStripColorTable());

            BrowserIPC.RecvMessage(
                this.browserModManager,
                Browser_RecvMessage
            );

#if DEBUG
            this.browserModManager.LoadUrl("http://localhost:3000/index.html"); // Webpack dev server
            this.browserModManager.LoadError += (_, args) =>
            {
                Console.WriteLine("Browser failed to contact webpack dev server: " + args.ErrorText);
                Console.WriteLine("Loading embedded resource instead...");
                if (args.ErrorCode == CefErrorCode.ConnectionRefused)
                    this.browserModManager.LoadUrl("resource://modmanager/index.html");
            };
#else
            // this.browserModManager.LoadUrl("local://modmanager/index.html");
            this.browserModManager.LoadUrl("resource://modmanager/index.html");
            this.browserModManager.LoadError += (_, args) =>
            {
                MsgBox.Show("Failed to load mod manager", $"Chromium failed to load embedded resource.\nError: {args.ErrorText}", MessageBoxIcon.Error);
            };
#endif
        }

        private object Browser_RecvMessage(object sender, string message, object data)
        {
            MsgBox.Show(message, data != null ? JsonConvert.SerializeObject(data) : "null");
            return null;
        }

        private void FormMods_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Configuration.SaveWindowState("FormMods", this);
                this.Mods.Save();
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
                LoadMods(game.GamePath);
                UpdateUI();
                TriggerNWModeUpdated();

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
                        $"{exc.GetType()}: {exc.Message}\n{exc.StackTrace}", MessageBoxIcon.Error);
                }

                this.DisableUI();
                this.preventClosing = false;
            }
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
            if (!File.Exists(SevenZip.ExecPath))
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
        }

#endregion

#region User interface
        /// <summary>
        /// Goes through the mod list and updates the list view.
        /// </summary>
        private void UpdateModList()
        {
            isUpdating = true;
            isUpdating = false;
        }

        private void EnableUI()
        {
            this.preventClosing = false;
            this.timerCheckForNXM.Start();
        }

        private void DisableUI()
        {
            this.preventClosing = true;
            this.timerCheckForNXM.Stop();
        }

        private void DisableUI_SidePanelOpen()
        {
            this.preventClosing = true;
        }

        private void ShowLoadingUI()
        {
            DisableUI();
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
            ModDeployment.LogFile.WriteLine(Log.GetTimeStamp());
            ModDeployment.LogFile.WriteLine("Enabling Nuclear Winter mode");

            Mods.NuclearWinterModeEnabled = true;

            // Uninstall mods:
            if (!Mods.ModsDisabled &&
                Configuration.NuclearWinter.AutoDisableMods)
            {
                Mods.ModsDisabled = true;
                this.DeployMods();
            }

            // Rename added *.dll files:
            if (Configuration.NuclearWinter.RenameDLLs)
                ModDeployment.RenameAddedDLLs(Mods.GamePath);

            // Save and update UI:
            Mods.Save();
            TriggerNWModeUpdated();
            ModDeployment.LogFile.WriteLine("NW mode enabled, done.");
        }

        public void DisableNuclearWinterMode()
        {
            ModDeployment.LogFile.WriteLine("\n");
            ModDeployment.LogFile.WriteLine(Log.GetTimeStamp());
            ModDeployment.LogFile.WriteLine("Disabling Nuclear Winter mode");

            Mods.NuclearWinterModeEnabled = false;

            // Install mods:
            if (Mods.ModsDisabled &&
                Configuration.NuclearWinter.AutoDeployMods)
            {
                Mods.ModsDisabled = false;
                if (Mods.Count() > 0)
                    this.DeployMods();
            }

            // Restore added *.dll files:
            ModDeployment.RestoreAddedDLLs(Mods.GamePath);

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
        }

        // File > Add mod > From folder
        private void fromFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
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

        // Tools > Archive2 > Detect format and compression
        private void detectFormatAndCompressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.openFileDialogBA2.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo fileInfo = new FileInfo(this.openFileDialogBA2.FileName);
                    Archive2.Info info = Archive2.ReadFile(this.openFileDialogBA2.FileName);
                    String preset = "Unknown";
                    if (info.format == Archive2.Format.General &&
                        info.compression == Archive2.Compression.Default)
                        preset = "General / Meshes / Materials / Animations";
                    else if (info.format == Archive2.Format.DDS &&
                             info.compression == Archive2.Compression.Default)
                        preset = "Textures (*.dds files)";
                    else if (info.format == Archive2.Format.General &&
                             info.compression == Archive2.Compression.None)
                        preset = "Sound FX and Music / Interface and HUD";

                    MsgBox.Show("Archive2 info",
                        $"File name: {fileInfo.Name}\n" +
                        $"Format: {Archive2.GetFormatName(info.format)}\n" +
                        $"Compression: {Archive2.GetCompressionName(info.compression)}\n" +
                        $"Preset: \"{preset}\"\n" +
                        $"File count: {info.numOfFiles}", MessageBoxIcon.Information);
                }
                catch (Archive2Exception ex)
                {
                    MsgBox.Show("Failed to read archive", ex.ToString(), MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MsgBox.Show("Failed to open file", ex.ToString(), MessageBoxIcon.Error);
                }
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
            if (File.Exists(ModDeployment.LogFilePath))
                Utils.OpenNotepad(ModDeployment.LogFilePath);
        }

        // Help > Log files > Show archive2.log.txt
        private void showArchive2logtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Archive2.LogFilePath))
                Utils.OpenNotepad(Archive2.LogFilePath);
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
            }, () => {
                try
                {
                    ModInstallations.InstallArchive(Mods, path, freeze, -1, UpdateProgress);
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
                UpdateModList();
                UpdateStatusStrip();
            });
        }

        private void InstallModFolderThreaded(string path)
        {
            RunThreaded(() => {
                DisableUI();
            }, () => {
                try
                {
                    ModInstallations.InstallFolder(Mods, path, -1, UpdateProgress);
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
                UpdateModList();
                UpdateStatusStrip();
            });
        }

        private void InstallBulkThreaded(string[] files, int dropIndex = -1)
        {
            RunThreaded(() => {
                DisableUI();
            }, () => {
                try
                {
                    InstallBulk(files, dropIndex);
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
                    UpdateProgress(Progress.Done("Mods imported."));
                }
                UpdateModList();
                UpdateStatusStrip();
            });
        }

        private void InstallBulk(string[] files, int dropIndex = -1)
        {
            int i = 0;
            foreach (string filePath in files)
            {
                UpdateProgress(Progress.Ongoing($"Importing {++i} of {files.Length} files/folders...", (float)i / (float)files.Length));
                string longFilePath = ModInstallations.EnsureLongPathSupport(filePath);
                if (Directory.Exists(longFilePath))
                    ModInstallations.InstallFolder(Mods, filePath, dropIndex);
                else if (File.Exists(longFilePath))
                    ModInstallations.InstallArchive(Mods, filePath, !Configuration.Mods.UnpackBA2ByDefault, dropIndex);
            }
        }

        private void DeleteModThreaded(int index)
        {
            RunThreaded(() => {
                DisableUI();
            }, () => {
                try
                {
                    ModActions.DeleteMod(Mods, index, UpdateProgress);
                }
                catch (Exception ex)
                {
                    MsgBox.Show("Couldn't delete mod", $"{ex.GetType()}: {ex.Message}\n\nTry to run the mod manager with admin rights or delete the mod files yourself.\nIf the issue persists, write a bug report on NexusMods or GitHub.");
                    return false;
                }
                return true;
            }, (success) => {
                EnableUI();
                UpdateUI();
            });
        }

        private void DeleteModsBulkThreaded(List<int> indices)
        {
            RunThreaded(() => {
                DisableUI();
            }, () => {
                try
                {
                    ModActions.DeleteMods(Mods, indices, UpdateProgress);
                }
                catch (Exception ex)
                {
                    MsgBox.Show("Couldn't delete mod", $"{ex.GetType()}: {ex.Message}\n\nTry to run the mod manager with admin rights or delete the mod files yourself.\nIf the issue persists, write a bug report on NexusMods or GitHub.");
                    return false;
                }
                return true;
            }, (success) => {
                EnableUI();
                if (success)
                UpdateUI();
            });
        }

        private bool DeployMods()
        {
            try
            {
                bool invalidateBundledFrozenArchives = true;
                if (Configuration.Mods.FreezeBundledArchives)
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
                    if (mod.RemoteInfo != null && ModHelpers.CompareVersion(mod.Version, mod.RemoteInfo.LatestVersion) < 0)
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
            bool unpackBA2ByDefault = Configuration.Mods.UnpackBA2ByDefault;
            RunThreaded(() => {
                ShowLoadingUI();
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
        }

        private void DisplayDeploymentNecessary()
        {
        }

        private void DisplayAllDone()
        {
        }

        private void UpdateStatusStrip()
        {
            if (Mods.IsDeploymentNecessary())
                this.DisplayDeploymentNecessary();
            else
                this.DisplayAllDone();
        }

        #endregion

        private void showDevToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.browserModManager.ShowDevTools();
        }
    }


    public delegate void NuclearWinterEventHandler(object sender, NuclearWinterEventArgs e);

    public class NuclearWinterEventArgs : EventArgs
    {
        public bool NuclearWinterModeEnabled;
    }
}
