using Fo76ini.Forms.FormIniError;
using Fo76ini.Forms.FormSettings;
using Fo76ini.Forms.FormWelcome;
using Fo76ini.Ini;
using Fo76ini.Interface;
using Fo76ini.Profiles;
using Fo76ini.Properties;
using Fo76ini.Tweaks;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Fo76ini
{
    public partial class FormMain : Form
    {
        private FormMods formMods = new FormMods();
        private FormSettings formSettings = new FormSettings();
        private FormWelcome formWelcome = new FormWelcome();

        private GameInstance game;

        public readonly bool FirstStart;

        public FormMain()
        {
            InitializeComponent();

            // Handle changes:
            ProfileManager.ProfileChanged += OnProfileChanged;
            FormMods.NWModeUpdated += OnNWModeUpdated;

            /*
             * Translations
             */

            // Make this form translatable:
            LocalizedForm form = new LocalizedForm(this, this.toolTip);
            form.SpecialControls.Add(this.userControlGallery.contextMenuStripGallery);
            Localization.LocalizedForms.Add(form);

            // Handle translations:
            Translation.LanguageChanged += OnLanguageChanged;

            // Add control elements to blacklist:
            Translation.BlackList.AddRange(new string[] {
                "labelConfigVersion",
                "labelAuthorName",
                "labelTranslationAuthor",
                "groupBoxWIP",
                "labelNewVersion",
                "labelGameEdition",
                "toolStripStatusLabelGameText",
                "toolStripStatusLabelEditionText",
                "toolStripStatusLabel1",
                "labelPipboyResolutionSpacer",
                "richTextBoxWhatsNew",
                "buttonRefreshGallery"
            });


            /*
             * Event handlers:
             */

            this.FormClosing += this.FormMain_FormClosing;
            this.Shown += this.FormMain_Shown;
            this.KeyDown += this.FormMain_KeyDown;

            this.backgroundWorkerGetLatestVersion.RunWorkerCompleted += backgroundWorkerGetLatestVersion_RunWorkerCompleted;

            // Disable scroll wheel on UI elements to prevent the user from accidentally changing values:
            Utils.PreventChangeOnMouseWheelForAllElements(this);

        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.timerCheckFiles.Enabled = true;

            // Load translations
            if (FirstStart)
                Localization.DownloadLanguageFiles(); // Download language on first start! Might hang the program for a while, if the internet connection is bad, though...
            Localization.GenerateDefaultTemplate();
            Localization.LookupLanguages();

            Configuration.LoadWindowState("Form1", this);

            // Remove updater, if present:
            try
            {
                string updaterPath = Path.Combine(Shared.AppConfigFolder, "Updater");
                Utils.DeleteDirectory(updaterPath);
            }
            catch
            {
                // Yeah, well or not.
            }

            // Load UI:
            UpdateNWModeUI(false);

            // What's new:
            LoadWhatsNew();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            // Necessary to init controls:
            ProfileManager.Feedback();

            // Open welcome dialog on first start:
            if (Initialization.FirstStart)
                formWelcome.OpenDialog();

            // Check for updates:
            CheckVersion();
            IniFiles.Config.Set("General", "sPreviousVersion", Shared.VERSION);

            // If nxm:// link has been provided, open the mod manager:
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && args[1].StartsWith("nxm://"))
                this.formMods.OpenUI();
        }

        private void OnProfileChanged(object sender, ProfileEventArgs e)
        {
            this.game = e.ActiveGameInstance;

            // Change image
            this.pictureBoxButtonGameEdition.SetImages(
                e.ActiveGameInstance.Get128pxBitmap(),
                e.ActiveGameInstance.Get128pxHoverBitmap()
            );

            // Change caption
            this.toolStripStatusLabelEditionText.Text = e.ActiveGameInstance.GetCaption();
            this.labelGameEdition.Text = e.ActiveGameInstance.GetCaption();


            this.toolStripStatusLabelGameText.Text = e.ActiveGameInstance?.Title;
        }


        // Winforms Double Buffering
        // https://stackoverflow.com/questions/3718380/winforms-double-buffering/3718648#3718648
        // fixes the visual artifacts when scrolling
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                Process.Start(Shared.URLs.AppGithubWikiURL);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Configuration.SaveWindowState("Form1", this);
                if (Configuration.AutoApply)
                    ApplyChanges();
            }
        }

        /*
         **************************************************************
         * Check version
         **************************************************************
         */

        #region Check version

        public void CheckVersion(bool force = false)
        {
            if (this.backgroundWorkerGetLatestVersion.IsBusy)
                return;

            this.labelConfigVersion.Text = Shared.VERSION;
            IniFiles.Config.Set("General", "sVersion", Shared.VERSION);

            panelUpdate.Visible = false;

            if (!force && Configuration.IgnoreUpdates)
            {
                this.labelConfigVersion.ForeColor = Color.Black;
                return;
            }

            this.labelConfigVersion.ForeColor = Color.Gray;
            this.pictureBoxSpinnerCheckForUpdates.Visible = true;

            // Checking version in background:
            this.backgroundWorkerGetLatestVersion.RunWorkerAsync();
        }

        private void backgroundWorkerGetLatestVersion_DoWork(object sender, DoWorkEventArgs e)
        {
            Versioning.GetLatestVersion();
        }

        private void backgroundWorkerGetLatestVersion_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.pictureBoxSpinnerCheckForUpdates.Visible = false;

            // Failed:
            if (Shared.LatestVersion == null)
            {
                this.labelConfigVersion.ForeColor = Color.Black;
                panelUpdate.Visible = false;
                return;
            }

            if (Versioning.UpdateAvailable)
            {
                panelUpdate.Visible = true;
                labelNewVersion.Text = string.Format(Localization.GetString("newVersionAvailable"), Shared.LatestVersion);
                labelNewVersion.ForeColor = Color.Crimson;
                this.labelConfigVersion.ForeColor = Color.Red;
            }
            else
            {
                // All good, latest version:
                panelUpdate.Visible = false;
                this.labelConfigVersion.ForeColor = Color.DarkGreen;
            }
        }

        #endregion

        /*
         **************************************************************
         * Event handlers
         **************************************************************
         */

        #region Nuclear Winter Mode

        private void OnNWModeUpdated(object sender, NuclearWinterEventArgs e)
        {
            this.Invoke(new Action(() => {
                UpdateNWModeUI(e.NuclearWinterModeEnabled);
            }));
        }
        
        private void UpdateNWModeUI (bool nwModeEnabled)
        {
            if (nwModeEnabled)
            {
                this.buttonNWMode.Text = Localization.GetString("adventuremode");
                this.buttonNWMode.Image = Resources.adventures;
            }
            else
            {
                this.buttonNWMode.Text = Localization.GetString("nuclearwintermode");
                this.buttonNWMode.Image = Resources.fire;
            }

            this.toolStripStatusLabelNuclearWinterModeActive.Visible = nwModeEnabled;

            this.buttonNWMode.Visible = nwModeEnabled || Configuration.NuclearWinter.ShowNWModeBtn;

            EnableUI();
            Focus();
        }

        private void toolStripButtonToggleNuclearWinterMode_Click(object sender, EventArgs e)
        {
            DisableUI();
            formMods.ToggleNuclearWinterModeThreaded();
        }

        #endregion

        #region Apply, Launch, and so on.
        public void ApplyChanges()
        {
            // Add custom lines to *.ini files:
            try
            {
                IniFile addF76 = new IniFile(Path.Combine(IniFiles.ParentPath, $"{game.IniPrefix}.add.ini"));
                addF76.Load();
                IniFiles.F76.Merge(addF76);

                IniFile addF76Prefs = new IniFile(Path.Combine(IniFiles.ParentPath, $"{game.IniPrefix}Prefs.add.ini"));
                addF76Prefs.Load();
                IniFiles.F76Prefs.Merge(addF76Prefs);

                IniFile addF76Custom = new IniFile(Path.Combine(IniFiles.ParentPath, $"{game.IniPrefix}Custom.add.ini"));
                addF76Custom.Load();
                IniFiles.F76Custom.Merge(addF76Custom);
            }
            catch (IniParsingException exc)
            {
                MsgBox.Get("customIniFilesParsingError").FormatText(exc.Message).Show(MessageBoxIcon.Error);
            }

            // Save changes:
            IniFiles.Save();
        }

        // "Apply" button:
        private void navButtonApply_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            MsgBox.Get("changesApplied").Popup(MessageBoxIcon.Information);
        }

        // "Play" button:
        private void navButtonPlay_Click(object sender, EventArgs e)
        {
            if (Configuration.AutoApply)
                ApplyChanges();
            this.game.LaunchGame();
            if (Configuration.QuitOnLaunch)
                Application.Exit();
        }

        // "Settings" button:
        private void navButtonSettings_Click(object sender, EventArgs e)
        {
            formSettings.ShowSettings();
        }

        // "Mods" button:
        private void navButtonMods_Click(object sender, EventArgs e)
        {
            this.formMods.OpenUI();
        }

        #endregion

        // "Get the latest version from NexusMods" link:
        private void linkLabelManualDownloadPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelManualDownloadPage.LinkVisited = true;
            Process.Start(Shared.URLs.AppNexusModsDownloadURL);
        }

        private void buttonUpdateNow_Click(object sender, EventArgs e)
        {
            // Set sInstallationPath:
            //string installationPath = Path.GetFullPath(AppContext.BaseDirectory);
            IniFiles.Config.Set("Updater", "sInstallationPath", Shared.AppInstallationFolder);
            IniFiles.Config.Save();

            // Copy updater.exe to <config-path>\Updater\:
            string updaterPath = Path.Combine(Shared.AppConfigFolder, "Updater");
            Directory.CreateDirectory(updaterPath);
            Directory.CreateDirectory(Path.Combine(updaterPath, "7z"));
            foreach (string filePath in Directory.EnumerateFiles(Shared.AppInstallationFolder, "*", SearchOption.AllDirectories))
            {
                string relPath = Utils.MakeRelativePath(Shared.AppInstallationFolder, filePath);
                string destPath = Path.Combine(updaterPath, relPath);
                Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                File.Copy(filePath, destPath, true);
            }

            // Run updater.exe:
            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = Path.Combine(updaterPath, "updater.exe");
                // If the program is installed into C:\Program Files (x86)\ then run the updater as admin:
                if (Shared.AppInstallationFolder.Contains("C:\\Program Files"))
                    startInfo.Verb = "runas";
                Process.Start(startInfo);
                Environment.Exit(0);
            }
            catch (Win32Exception)
            {
                MsgBox.PlayErrorSound();
            }
        }

        #region Tool strip

        /*
         * Tool strip:
         */

        private void toolConfigurationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(Shared.AppConfigFolder);
        }

        private void toolLanguagesFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(Shared.AppTranslationsFolder);
        }

        private void toolInstallationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(Directory.GetParent(Application.ExecutablePath).ToString());
        }

        private void gameFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.game.ValidateGamePath())
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Error);
                return;
            }
            Utils.OpenExplorer(this.game.GamePath);
        }

        private void gamesConfigurationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(IniFiles.ParentPath);
        }

        private void toolStripButtonNexusMods_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Shared.URLs.AppNexusModsURL);
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckVersion(true);
        }

        private void showUpdaterlogtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(Path.Combine(Shared.AppConfigFolder, "update.log.txt")))
                Utils.OpenNotepad(Path.Combine(Shared.AppConfigFolder, "update.log.txt"));
        }

        private void editFallout76iniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(IniFiles.F76.FilePath))
                Utils.OpenFile(IniFiles.F76.FilePath);
        }

        private void editFallout76PrefsiniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(IniFiles.F76Prefs.FilePath))
                Utils.OpenFile(IniFiles.F76Prefs.FilePath);
        }

        private void editFallout76CustominiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (File.Exists(IniFiles.F76Custom.FilePath))
                Utils.OpenFile(IniFiles.F76Custom.FilePath);
        }

        private void steamScreenshotFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string steamFolder = @"C:\Program Files (x86)\Steam\userdata\";
            if (Directory.Exists(steamFolder))
            {
                steamFolder = Path.Combine(Directory.GetDirectories(steamFolder)[0], @"760\remote\1151340\screenshots");
                Utils.OpenExplorer(steamFolder);
            }
        }

        private void gamePhotosFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string photosFolder = Path.Combine(IniFiles.ParentPath, "Photos");
            if (Directory.Exists(photosFolder))
            {
                photosFolder = Directory.GetDirectories(photosFolder)[0];
                Utils.OpenExplorer(photosFolder);
            }
        }

        private void showProfiles_OnClick(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.tabPageProfiles;
        }

        #endregion

        // Check, if *.ini files have been changed:
        private void timerCheckFiles_Tick(object sender, EventArgs e)
        {
            if (!IniFiles.IsLoaded())
                return;

            // TODO: Give an option to reload the *.ini files.
            // Check every 5 seconds, if files have been modified:
            if (IniFiles.FilesHaveBeenModified())
            {
                IniFiles.UpdateLastModifiedDates();

                // Don't prompt, if Fallout 76 is running...
                if (!Utils.IsProcessRunning("Project76") &&  // !Utils.IsProcessRunning("Project76_GamePass") && 
                    !Utils.IsProcessRunning("Fallout76"))
                    MsgBox.Get("iniFilesModified").Popup(MessageBoxIcon.Warning);
            }
        }

        public void DisableUI()
        {
            this.pictureBoxLoadingGIF.Visible = true;
            this.pictureBoxLoadingGIF.Width = this.Width;
        }

        public void EnableUI()
        {
            this.pictureBoxLoadingGIF.Visible = false;
        }
        

        /*
         * What's new:
         */

        private void LoadWhatsNew()
        {
            this.panelWhatsNew.Visible = true;
            if (!Configuration.ShowWhatsNew)
                this.panelWhatsNew.Visible = false;
            string WhatsNewTestFile = Path.Combine(Shared.AppConfigFolder, "What's new.rtf");
            if (File.Exists(WhatsNewTestFile))
                this.richTextBoxWhatsNew.LoadFile(WhatsNewTestFile);
            else
                this.backgroundWorkerDownloadRTF.RunWorkerAsync();
        }

        private void backgroundWorkerDownloadRTF_DoWork(object sender, DoWorkEventArgs ev)
        {
            try
            {
                WebClient wc = new WebClient();
                byte[] raw = wc.DownloadData(Shared.URLs.RemoteWhatsNewRTFURL);
                ev.Result = (object)Encoding.UTF8.GetString(raw).Trim();
            }
            catch (Exception ex)
            {
                ev.Result = (object)$"{{\\rtf1Couldn't retrieve 'What's new.rtf': \"{ex.GetType().Name}: {ex.Message}\"}}";
            }
        }

        private void backgroundWorkerDownloadRTF_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs ev)
        {
            this.richTextBoxWhatsNew.Rtf = (string)ev.Result;
        }

        private void pictureBoxButtonGameEdition_Load(object sender, EventArgs e)
        {

        }

        private void pictureBoxLoadingGIF_Click(object sender, EventArgs e)
        {

        }
    }
}
