using Fo76ini.Forms.FormIniError;
using Fo76ini.Forms.FormSettings;
using Fo76ini.Forms.FormTextPrompt;
using Fo76ini.Forms.FormWelcome;
using Fo76ini.Ini;
using Fo76ini.Interface;
using Fo76ini.Mods;
using Fo76ini.NexusAPI;
using Fo76ini.Profiles;
using Fo76ini.Properties;
using Fo76ini.Tweaks;
using Fo76ini.Utilities;
using IniParser.Model;
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
        private FormMods formMods;
        private FormWelcome formWelcome = new FormWelcome();
        private FormSettings formSettings;

        private GameInstance game;

        public readonly bool FirstStart;

        public FormMain()
        {
            InitializeComponent();

            // Determine whether this is the very first start of the tool on the system:
            FirstStart = !File.Exists(IniFiles.ConfigPath) && !File.Exists(ProfileManager.XMLPath);

            // Handle changes:
            ProfileManager.ProfileChanged += OnProfileChanged;

            // Create FormMods:
            formMods = new FormMods();
            FormMods.NWModeUpdated += OnNWModeUpdated;
            //UpdateNWModeUI(false);

            /*
             * Translations
             */

            // Make this form translatable:
            LocalizedForm form = new LocalizedForm(this, this.toolTip);
            form.SpecialControls.Add(this.contextMenuStripGallery);
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
             * Dropdowns
             */

            #region Dropdowns

            // Let's add options to the drop-down menus:

            // Display resolution usage statistics (and lists):
            // https://store.steampowered.com/hwsurvey/Steam-Hardware-Software-Survey-Welcome-to-Steam
            // https://www.rapidtables.com/web/dev/screen-resolution-statistics.html
            // https://w3codemasters.in/most-common-screen-resolutions/
            // https://www.reneelab.com/video-with-4-3-format.html
            // https://www.overclock.net/threads/list-of-display-resolutions-aspect-ratios.539967/
            // https://en.wikipedia.org/wiki/List_of_common_resolutions
            DropDown.Add("Resolution", new DropDown(
                this.comboBoxResolution,
                new string[] {
                    "Custom",
                    "",
                    "┌───────────────────────────────┐",
                    "│  4:3                          │",
                    "├───────────────────────────────┤",
                    "│ [4:3]    640 x  480 (VGA)     │",
                    "│ [4:3]    800 x  600 (SVGA)    │",
                    "│ [4:3]    960 x  720           │",
                    "│ [4:3]   1024 x  768 (XGA)     │",
                    "│ [4:3]   1152 x  864           │",
                    "│ [4:3]   1280 x  960           │",
                    "│ [4:3]   1400 x 1050           │",
                    "│ [4:3]   1440 x 1080           │",
                    "│ [4:3]   1600 x 1200           │",
                    "│ [4:3]   1920 x 1440           │",
                    "│ [4:3]   2048 x 1536           │",
                    "│ [4:3]   2880 x 2160           │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  5:3                          │",
                    "├───────────────────────────────┤",
                    "│ [5:3]    800 x  480           │",
                    "│ [5:3]   1280 x  768 (WXGA)    │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  5:4                          │",
                    "├───────────────────────────────┤",
                    "│ [5:4]   1152 x  960           │",
                    "│ [5:4]   1280 x 1024           │",
                    "│ [5:4]   2560 x 2048           │",
                    "│ [5:4]   5120 x 4096           │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  8:5                          │",
                    "├───────────────────────────────┤",
                    "│ [8:5]   1280 x  800           │",
                    "│ [8:5]   1440 x  900           │",
                    "│ [8:5]   1680 x 1050           │",
                    "│ [8:5]   1920 x 1200           │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  16:9                         │",
                    "├───────────────────────────────┤",
                    "│ [16:9]  1024 x  576           │",
                    "│ [16:9]  1152 x  648           │",
                    "│ [16:9]  1280 x  720 (HD)      │",
                    "│ [16:9]  1360 x  768           │",
                    "│ [16:9]  1365 x  768           │",
                    "│ [16:9]  1366 x  768           │",
                    "│ [16:9]  1536 x  864           │",
                    "│ [16:9]  1600 x  900           │",
                    "│ [16:9]  1920 x 1080 (Full HD) │",
                    "│ [16:9]  2560 x 1440 (WQHD)    │",
                    "│ [16:9]  3200 x 1800           │",
                    "│ [16:9]  3840 x 2160 (4K UHD1) │",
                    "│ [16:9]  5120 x 2880 (5K)      │",
                    "│ [16:9]  7680 x 4320 (8K UHD2) │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  16:10                        │",
                    "├───────────────────────────────┤",
                    "│ [16:10]  640 x  400           │",
                    "│ [16:10] 1280 x  800           │",
                    "│ [16:10] 1440 x  900           │",
                    "│ [16:10] 1680 x 1050           │",
                    "│ [16:10] 1920 x 1200           │",
                    "│ [16:10] 2560 x 1600           │",
                    "│ [16:10] 3840 x 2400           │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  17:9                         │",
                    "├───────────────────────────────┤",
                    "│ [17:9]  2048 x 1080           │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  21:9                         │",
                    "├───────────────────────────────┤",
                    "│ [21:9]  1920 x  800           │",
                    "│ [21:9]  2560 x 1080           │",
                    "│ [21:9]  3440 x 1440           │",
                    "│ [21:9]  3840 x 1600           │",
                    "│ [21:9]  5120 x 2160           │",
                    "│                               │",
                    "│                               │",
                    "└───────────────────────────────┘",
                    ""
                }
            ));

            DropDown.Add("DisplayMode", new DropDown(
                this.comboBoxDisplayMode,
                new string[] {
                    "Fullscreen",
                    "Windowed",
                    "Borderless windowed",
                    "Borderless windowed (Fullscreen)"
                }
            ));

            DropDown.Add("AntiAliasing", new DropDown(
                this.comboBoxAntiAliasing,
                new string[] {
                    "TAA (default)",
                    "FXAA",
                    "Disabled"
                }
            ));

            DropDown.Add("AnisotropicFiltering", new DropDown(
                this.comboBoxAnisotropicFiltering,
                new string[] {
                    "None",
                    "2x",
                    "4x",
                    "8x (default)",
                    "16x"
                }
            ));

            DropDown.Add("ShadowTextureResolution", new DropDown(
                this.comboBoxShadowTextureResolution,
                new string[] {
                    "512 = Potato",
                    "1024 = Low",
                    "2048 = High (default)",
                    "4096 = Ultra"
                }
            ));

            DropDown.Add("ShadowBlurriness", new DropDown(
                this.comboBoxShadowBlurriness,
                new string[] {
                    "1x",
                    "2x",
                    "3x = Default, recommended"
                }
            ));

            DropDown.Add("VoiceChatMode", new DropDown(
                this.comboBoxVoiceChatMode,
                new string[] {
                    "Auto",
                    "Area",
                    "Team",
                    "None"
                }
            ));

            DropDown.Add("ShowActiveEffectsOnHUD", new DropDown(
                this.comboBoxShowActiveEffectsOnHUD,
                new string[] {
                    "Disabled",
                    "Detrimental",
                    "All"
                }
            ));

            DropDown.Add("iDirShadowSplits", new DropDown(
                this.comboBoxiDirShadowSplits,
                new string[] {
                    "1 - Low",
                    "2 - High / Medium",
                    "3 - Ultra"
                }
            ));

            #endregion

            /*
             * Event handlers:
             */

            // Disable scroll wheel on UI elements to prevent the user from accidentally changing values:
            Utils.PreventChangeOnMouseWheelForAllElements(this);

            // Event handler:
            this.FormClosing += this.FormMain_FormClosing;
            this.Shown += this.FormMain_Shown;
            this.KeyDown += this.FormMain_KeyDown;
            this.pictureBoxGameEdition.MouseEnter += this.pictureBoxGameEdition_MouseEnter;
            this.pictureBoxGameEdition.MouseLeave += this.pictureBoxGameEdition_MouseLeave;

            this.backgroundWorkerGetLatestVersion.RunWorkerCompleted += backgroundWorkerGetLatestVersion_RunWorkerCompleted;

            InitAccountProfileRadiobuttons();

            // Pipboy:
            InitPipboy();

            // Danger Zone:
            this.tabControl1.TabPages.Remove(this.tabPageDangerZone);
            FormSettings.SettingsClosing += (object sender, EventArgs e) =>
            {
                if (FormSettings.DangerZoneEnabled && !this.tabControl1.TabPages.Contains(this.tabPageDangerZone))
                {
                    this.tabControl1.TabPages.Add(this.tabPageDangerZone);
                    LinkDangerZoneControls();
                }
            };
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Create folders, if not present:
            Directory.CreateDirectory(Shared.AppConfigFolder);
            Directory.CreateDirectory(Localization.LanguageFolder);
            Directory.CreateDirectory(IniFiles.ParentPath);

            // Link tweaks
            LinkInfo();
            LinkSliders();
            LinkControlsToTweaks();
            LinkPipboyControls();

            // Load config.ini
            IniFiles.LoadConfig();

            // Load game instances
            ProfileManager.Load();
            formSettings = new FormSettings();

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
            this.LoadGallery();

            MakePictureBoxButton(this.pictureBoxUpdateButton, "updateNowButton");

            // What's new:
            LoadWhatsNew();
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            // Show welcome dialog:
            if (FirstStart)
                formWelcome.OpenDialog();

            // Check for updates
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
            this.timerCheckFiles.Enabled = false;
            while (true)
            {
                try
                {
                    IniFiles.Load(game);
                    break;
                }
                catch (IniParsingException exc)
                {
                    DialogResult result = FormIniError.OpenDialog(exc);
                    if (result == DialogResult.Retry)
                    {
                        continue;
                    }
                    else if (result == DialogResult.Ignore)
                    {
                        continue;
                    }
                    else if (result == DialogResult.Abort)
                    {
                        Environment.Exit(-1);
                        return;
                    }
                    //MsgBox.Get("iniParsingError").FormatText(exc.Message).Show(MessageBoxIcon.Error);
                    //Application.Exit();
                    //return;
                }
            }
            LinkedTweaks.LoadValues();
            // TODO: For some reason, it won't update the resolution combobox, unless I add this workaround:
            numCustomRes_ValueChanged(null, null);

            // Change image
            switch (e.ActiveGameInstance.Edition)
            {
                case GameEdition.Steam:
                    this.pictureBoxGameEdition.Image = GameInstance.Get128pxBitmap(GameEdition.Steam);
                    this.toolStripStatusLabelEditionText.Text = "Steam";
                    this.labelGameEdition.Text = "Steam";
                    break;
                case GameEdition.SteamPTS:
                    this.pictureBoxGameEdition.Image = GameInstance.Get128pxBitmap(GameEdition.SteamPTS);
                    this.toolStripStatusLabelEditionText.Text = "Steam (PTS)";
                    this.labelGameEdition.Text = "Steam\n(PTS)";
                    break;
                case GameEdition.BethesdaNet:
                    this.pictureBoxGameEdition.Image = GameInstance.Get128pxBitmap(GameEdition.BethesdaNet);
                    this.toolStripStatusLabelEditionText.Text = "Bethesda.net";
                    this.labelGameEdition.Text = "Bethesda";
                    break;
                case GameEdition.BethesdaNetPTS:
                    this.pictureBoxGameEdition.Image = GameInstance.Get128pxBitmap(GameEdition.BethesdaNetPTS);
                    this.toolStripStatusLabelEditionText.Text = "Bethesda.net (PTS)";
                    this.labelGameEdition.Text = "Bethesda\n(PTS)";
                    break;
                case GameEdition.MSStore:
                    this.pictureBoxGameEdition.Image = GameInstance.Get128pxBitmap(GameEdition.MSStore);
                    this.toolStripStatusLabelEditionText.Text = "Xbox / Microsoft Store";
                    this.labelGameEdition.Text = "Xbox";
                    break;
                default:
                    this.pictureBoxGameEdition.Image = GameInstance.Get128pxBitmap(GameEdition.Unknown);
                    this.toolStripStatusLabelEditionText.Text = Localization.GetString("unknown");
                    this.labelGameEdition.Text = Localization.GetString("unknown");
                    break;
            }

            LoadAccountProfile();
            LoadCustomTab();

            this.toolStripStatusLabelGameText.Text = e.ActiveGameInstance?.Title;
            this.timerCheckFiles.Enabled = true;
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
                if (IniFiles.Config.GetBool("Preferences", "bAutoApply", false))
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

            if (!force && IniFiles.Config.GetBool("Preferences", "bIgnoreUpdates", false))
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

            // ShowWhatsNewConditionally(); // TODO: Why is this here though?

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
                this.toolStripButtonToggleNuclearWinterMode.Text = Localization.GetString("adventuremode");
                this.toolStripButtonToggleNuclearWinterMode.Image = Resources.adventures;
            }
            else
            {
                this.toolStripButtonToggleNuclearWinterMode.Text = Localization.GetString("nuclearwintermode");
                this.toolStripButtonToggleNuclearWinterMode.Image = Resources.fire;
            }

            this.toolStripStatusLabelNuclearWinterModeActive.Visible = nwModeEnabled;

            this.toolStripButtonToggleNuclearWinterMode.Visible = nwModeEnabled || IniFiles.Config.GetBool("NuclearWinter", "bShowNWModeBtn", false);

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
        private void toolStripButtonApply_Click(object sender, EventArgs e)
        {
            ApplyChanges();
            MsgBox.Get("changesApplied").Popup(MessageBoxIcon.Information);
        }

        private void toolStripButtonLaunchGame_Click(object sender, EventArgs e)
        {
            if (IniFiles.Config.GetBool("Preferences", "bAutoApply", false))
                ApplyChanges();
            this.game.LaunchGame();
            if (IniFiles.Config.GetBool("Preferences", "bQuitOnLaunch", false))
                Application.Exit();
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
            catch (Win32Exception ex)
            {
                MsgBox.PlayErrorSound();
            }
        }

        #region Tool strip

        /*
         * Tool strip:
         */

        private void toolStripButtonManageMods_Click(object sender, EventArgs e)
        {
            this.formMods.OpenUI();
        }

        private void toolConfigurationFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(Shared.AppConfigFolder);
        }

        private void toolLanguagesFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(Localization.LanguageFolder);
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

        private void showSettings_OnClick(object sender, EventArgs e)
        {
            formSettings.ShowSettings();
        }

        private void showProfiles_OnClick(object sender, EventArgs e)
        {
            formSettings.ShowProfiles();
        }

        private void pictureBoxGameEdition_MouseEnter(object sender, EventArgs e)
        {
            this.pictureBoxGameEdition.Image = this.game.Get128pxHoverBitmap();
        }

        private void pictureBoxGameEdition_MouseLeave(object sender, EventArgs e)
        {
            this.pictureBoxGameEdition.Image = this.game.Get128pxBitmap();
        }

        #endregion

        // Check, if *.ini files have been changed:
        private void timerCheckFiles_Tick(object sender, EventArgs e)
        {
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

        private void MakePictureBoxButton(PictureBox pictureBox, string localizedStringID)
        {
            pictureBox.Paint += new PaintEventHandler((paintSender, paintEventArgs) =>
            {
                paintEventArgs.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                string text = Localization.GetString(localizedStringID);

                Font font = new Font("Microsoft Sans Serif", 12f, FontStyle.Bold);

                SizeF textSize = paintEventArgs.Graphics.MeasureString(text, font);
                PointF locationToDraw = new PointF();
                locationToDraw.X = (pictureBox.Width / 2) - (textSize.Width / 2);
                locationToDraw.Y = (pictureBox.Height / 2) - (textSize.Height / 2);

                paintEventArgs.Graphics.DrawString(text, font, Brushes.White, locationToDraw);
            });
            pictureBox.MouseEnter += new EventHandler((mouseSender, mouseEventArgs) =>
            {
                pictureBox.Image = Resources.button_hover;
                pictureBox.Cursor = Cursors.Hand;
            });
            pictureBox.MouseLeave += new EventHandler((mouseSender, mouseEventArgs) =>
            {
                pictureBox.Image = Resources.button;
                pictureBox.Cursor = Cursors.Default;
            });
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

        #region Credentials
        /*
         * Credentials
         */

        List<RadioButton> accountProfileRadioButtons
        {
            get
            {
                return new List<RadioButton> {
                    radioButtonAccount1,
                    radioButtonAccount2,
                    radioButtonAccount3,
                    radioButtonAccount4,
                    radioButtonAccount5,
                    radioButtonAccount6,
                    radioButtonAccount7,
                    radioButtonAccount8,
                    radioButtonAccount9,
                    radioButtonAccount10,
                    radioButtonAccount11,
                    radioButtonAccount12,
                    radioButtonAccount13,
                    radioButtonAccount14,
                    radioButtonAccount15,
                    radioButtonAccount16
                };
            }
        }

        // Show password:
        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // https://stackoverflow.com/questions/8185747/how-can-i-unmask-password-text-box-and-mask-it-back-to-password
            this.textBoxPassword.UseSystemPasswordChar = !this.checkBoxShowPassword.Checked;
            this.textBoxPassword.PasswordChar = !this.checkBoxShowPassword.Checked ? '\u2022' : '\0';
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            int index = GetSelectedAccountProfileRadiobuttonIndex();
            if (this.textBoxUserName.Text == "")
            {
                IniFiles.Config.Remove("Login", $"s76UserName{index}");
                IniFiles.F76Custom.Remove("Login", "s76UserName");
            }
            else
            {
                IniFiles.Config.Set("Login", $"s76UserName{index}", this.textBoxUserName.Text);
                IniFiles.F76Custom.Set("Login", "s76UserName", this.textBoxUserName.Text);
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            int index = GetSelectedAccountProfileRadiobuttonIndex();
            if (this.textBoxPassword.Text == "")
            {
                IniFiles.Config.Remove("Login", $"s76Password{index}");
                IniFiles.F76Custom.Remove("Login", "s76Password");
            }
            else
            {
                IniFiles.Config.Set("Login", $"s76Password{index}", this.textBoxPassword.Text);
                IniFiles.F76Custom.Set("Login", "s76Password", this.textBoxPassword.Text);
            }
        }

        // If a radiobuttons gets checked, load username and password of a profile.
        private void radioButtonAccount_CheckedChanged(object sender, EventArgs e)
        {
            int index = GetSelectedAccountProfileRadiobuttonIndex();
            IniFiles.Config.Set("Login", "uActiveAccountProfile", index);
            if (index == 0)
            {
                this.textBoxUserName.Text = IniFiles.GetString("Login", "s76UserName", "");
                this.textBoxPassword.Text = IniFiles.GetString("Login", "s76Password", "");
            }
            else
            {
                this.textBoxUserName.Text = IniFiles.Config.GetString("Login", $"s76UserName{index}", "");
                this.textBoxPassword.Text = IniFiles.Config.GetString("Login", $"s76Password{index}", "");
            }
        }

        private void radioButtonAccountNone_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxUserName.Text = IniFiles.GetString("Login", "s76UserName", "");
            this.textBoxPassword.Text = IniFiles.GetString("Login", "s76Password", "");
        }

        private int GetSelectedAccountProfileRadiobuttonIndex()
        {
            int index = 1;
            foreach (RadioButton rbutton in accountProfileRadioButtons)
            {
                if (rbutton.Checked)
                    break;
                index++;
            }
            if (index > accountProfileRadioButtons.Count)
                index = 0;
            return index;
        }

        private void SetSelectedAccountProfileRadiobuttonIndex(int index)
        {
            if (index <= 0)
            {
                this.radioButtonAccountNone.Checked = true;
                return;
            }
            accountProfileRadioButtons[index - 1].Checked = true;
        }

        // Assigns event handler to radiobuttons (Account #1, Account #2, ...):
        private void InitAccountProfileRadiobuttons()
        {
            foreach (RadioButton rbutton in accountProfileRadioButtons)
                rbutton.CheckedChanged += radioButtonAccount_CheckedChanged;
        }

        // Gets current account profile and sets the according radiobutton
        private void LoadAccountProfile()
        {
            //int index = IniFiles.Config.GetInt("Login", "uActiveAccountProfile", 0);
            int index = 0;
            string username = IniFiles.GetString("Login", "s76UserName", "");
            string password = IniFiles.GetString("Login", "s76Password", "");
            if (username != "" && password != "")
            {
                for (int i = 1; i <= accountProfileRadioButtons.Count(); i++)
                {
                    if (username == IniFiles.Config.GetString("Login", $"s76UserName{i}", "") &&
                        password == IniFiles.Config.GetString("Login", $"s76Password{i}", ""))
                    {
                        index = i;
                        break;
                    }
                }
            }
            SetSelectedAccountProfileRadiobuttonIndex(index);
        }
        #endregion

        #region Custom tab

        private string customAddFilePath = null;

        private void comboBoxCustomFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileName;
            switch (this.comboBoxCustomFile.SelectedIndex)
            {
                case 0:
                    fileName = $"{game.IniPrefix}.add.ini";
                    break;
                case 1:
                    fileName = $"{game.IniPrefix}Prefs.add.ini";
                    break;
                case 2:
                    fileName = $"{game.IniPrefix}Custom.add.ini";
                    break;
                default:
                    return;
            }
            this.customAddFilePath = Path.Combine(IniFiles.ParentPath, fileName);

            if (File.Exists(this.customAddFilePath))
                this.textBoxCustom.Text = File.ReadAllText(this.customAddFilePath);
            else
                this.textBoxCustom.Text = "";

            this.buttonCustomSave.Text = this.buttonCustomSave.Text.TrimEnd('*');
        }

        private void textBoxCustom_TextChanged(object sender, EventArgs e)
        {
            if (!this.buttonCustomSave.Text.EndsWith("*"))
                this.buttonCustomSave.Text += "*";
        }

        private void buttonCustomSave_Click(object sender, EventArgs e)
        {
            if (this.textBoxCustom.Text == "")
            {
                if (File.Exists(this.customAddFilePath))
                    File.Delete(this.customAddFilePath);
            }
            else
            {
                File.WriteAllText(this.customAddFilePath, this.textBoxCustom.Text);
            }

            if (this.buttonCustomSave.Text.EndsWith("*"))
                this.buttonCustomSave.Text = this.buttonCustomSave.Text.TrimEnd('*');
        }

        private void LoadCustomTab ()
        {
            this.comboBoxCustomFile.Items.Clear();
            this.comboBoxCustomFile.Items.AddRange(new string[] {
                $"{game.IniPrefix}.ini",
                $"{game.IniPrefix}Prefs.ini",
                $"{game.IniPrefix}Custom.ini"
            });
            this.comboBoxCustomFile.SelectedIndex = 0;
        }

        #endregion

        #region Resolution combobox

        // Detect resolution:
        private void buttonDetectResolution_Click(object sender, EventArgs e)
        {
            Size res = Utils.GetDisplayResolution();
            this.numCustomResW.Value = res.Width;
            this.numCustomResH.Value = res.Height;
        }

        private void comboBoxResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If "Custom" selected, skip:
            if (this.comboBoxResolution.SelectedIndex == 0)
                return;

            // If an invalid option has been selected, set to "Custom" and skip:
            string res = this.comboBoxResolution.SelectedItem.ToString();
            Size? displaySize = GetResolutionFromString(res);
            if (!displaySize.HasValue)
            {
                this.comboBoxResolution.SelectedIndex = 0;
                return;
            }

            int width = displaySize.Value.Width;
            int height = displaySize.Value.Height;

            // Set the values of the NumericUpDowns (which in turn will trigger the event handlers which set the values in the *.ini files)
            if (this.numCustomResW.Value != width)
                this.numCustomResW.Value = width;

            if (this.numCustomResH.Value != height)
                this.numCustomResH.Value = height;
        }

        /// <summary>
        /// Extracts width and height from a string that looks like this: "[16:9] 1920 x 1080 (Full HD)"
        /// </summary>
        /// <returns>Width and height if a valid option has been selected. Otherwise null.</returns>
        private Size? GetResolutionFromString(String res)
        {
            if (!res.Contains("x"))
                return null;
            string[] split = res.Split('x').Select(x => x.Trim()).ToArray();
            int width = Convert.ToInt32(Regex.Match(split[0], @"[0-9]+$").Groups[0].Value);
            int height = Convert.ToInt32(Regex.Match(split[1], @"^[0-9]+").Groups[0].Value);
            return new Size(width, height);
        }

        /// <summary>
        /// Searches through the resolution combobox for an option that matches the given size.
        /// </summary>
        /// <param name="size"></param>
        /// <returns>The first occurence if a match was found. Otherwise -1.</returns>
        private int FindIndexInResolutionComboBox(Size size)
        {
            for (int i = 0; i < this.comboBoxResolution.Items.Count; i++)
            {
                string res = this.comboBoxResolution.Items[i].ToString();
                Size? s = GetResolutionFromString(res);
                if (s?.Width == size.Width && s?.Height == size.Height)
                    return i;
            }
            return -1;
        }

        private void numCustomRes_ValueChanged(object sender, EventArgs e)
        {
            Size size = new Size(
                Convert.ToInt32(numCustomResW.Value),
                Convert.ToInt32(numCustomResH.Value)
            );
            int i = FindIndexInResolutionComboBox(size);
            if (i > -1)
                this.comboBoxResolution.SelectedIndex = i;
            else
                this.comboBoxResolution.SelectedIndex = 0;
        }

        #endregion

        private void buttonCameraPositionReset_Click(object sender, EventArgs e)
        {
            this.applyCameraNodeAnimationsTweak.ResetValue();
            this.cameraOverShoulderPosXTweak.ResetValue();
            this.cameraOverShoulderPosZTweak.ResetValue();
            this.cameraOverShoulderCombatPosXTweak.ResetValue();
            this.cameraOverShoulderCombatPosZTweak.ResetValue();
            this.cameraOverShoulderCombatAddYTweak.ResetValue();
            this.cameraOverShoulderMeleeCombatPosXTweak.ResetValue();
            this.cameraOverShoulderMeleeCombatPosZTweak.ResetValue();
            this.cameraOverShoulderMeleeCombatAddYTweak.ResetValue();
            LinkedTweaks.LoadValues();
        }

        /*
         * What's new:
         */

        private void LoadWhatsNew()
        {
            this.panelWhatsNew.Visible = true;
            if (!IniFiles.Config.GetBool("Preferences", "bShowWhatsNew", true))
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
    }
}
