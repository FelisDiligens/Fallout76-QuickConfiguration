using Fo76ini.Forms.FormIniError;
using Fo76ini.Forms.FormMain;
using Fo76ini.Forms.FormMain.Tabs;
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
    public partial class FormMain : Form, IExposeComponents
    {
        public ToolTip ToolTip => this.toolTip;

        private FormMods formMods = new FormMods();
        private FormWelcome formWelcome = new FormWelcome();

        private GameInstance game;

        private UserControlTweaks userControlTweaks = new UserControlTweaks();
        private UserControlPipboy userControlPipboy = new UserControlPipboy();
        private UserControlGallery userControlGallery = new UserControlGallery();
        private UserControlCustom userControlCustom = new UserControlCustom();
        private UserControlProfiles userControlProfiles = new UserControlProfiles();
        private UserControlSettings userControlSettings = new UserControlSettings();
        private UserControlNexusMods userControlNexusMods = new UserControlNexusMods();
        private UserControlHome userControlHome = new UserControlHome();

        public FormMain()
        {
            InitializeComponent();

            if (this.DesignMode)
                return;

            /*
             * Add views to ViewControl:
             */
            this.viewControl.AddViews(new UserControl[] {
                userControlHome,
                userControlTweaks,
                userControlPipboy,
                userControlGallery,
                userControlCustom,
                userControlSettings,
                userControlNexusMods,
                userControlProfiles,
            });
            this.viewControl.SelectedIndex = 0;
            this.viewControl.SelectedIndexChanged += ViewControl_SelectedIndexChanged;

            /*
             * Handle events of views
             */
            userControlSettings.NuclearWinterModeToggled += userControlSettings_NuclearWinterModeToggled;
            userControlSettings.OpenProfileEditorRequested += userControlSettings_OpenProfileEditorRequested;
            userControlHome.UpdateButtonClicked += UserControlHome_UpdateButtonClicked;

            // Handle changes:
            ProfileManager.ProfileChanged += OnProfileChanged;
            FormMods.NWModeUpdated += OnNWModeUpdated;

            /*
             * Translations
             */

            // Make this form translatable:
            LocalizedForm form = new LocalizedForm(this, this.toolTip);
            form.SpecialControls.Add(this.userControlGallery.contextMenuStripGallery);
            form.SpecialControls.Add(this.userControlSideNav.contextMenuStripBrowse);
            form.SpecialControls.Add(this.userControlTweaks.contextMenuStripOverallQualityPresets);
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
                "toolStripStatusLabelGameText",
                "toolStripStatusLabelEditionText",
                "toolStripStatusLabel1",
                "labelPipboyResolutionSpacer",
                "richTextBoxWhatsNew",
                "buttonRefreshGallery"
            });

            Localization.NewTranslationsAvailable += Localization_NewTranslationsAvailable;


            /*
             * Event handlers:
             */

            this.FormClosing += this.FormMain_FormClosing;
            this.Shown += this.FormMain_Shown;
            this.KeyDown += this.FormMain_KeyDown;

            // Disable scroll wheel on UI elements to prevent the user from accidentally changing values:
            Utils.PreventChangeOnMouseWheelForAllElements(this);

            this.userControlSideNav.SelectedTabIndex = 0;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            this.timerCheckFiles.Enabled = true;

            // Load translations
            if (Initialization.FirstStart)
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

            // Apply theme:
            Theming.ApplyTheme(Configuration.Appearance.AppTheme, this);
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            // Necessary to init controls:
            ProfileManager.Feedback();

            // Open welcome dialog on first start:
            if (Initialization.FirstStart)
                formWelcome.OpenDialog();
            else
                this.backgroundWorkerTranslationsCheckForUpdates.RunWorkerAsync();

            // If nxm:// link has been provided, open the mod manager:
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && args[1].StartsWith("nxm://"))
                this.formMods.OpenUI();
        }

        public void OnLanguageChanged(object sender, TranslationEventArgs e)
        {
            this.Refresh(); // Forces redraw
        }

        private void OnProfileChanged(object sender, ProfileEventArgs e)
        {
            this.game = e.ActiveGameInstance;
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
         * Event handlers
         **************************************************************
         */

        #region Nuclear Winter Mode

        private void userControlSettings_NuclearWinterModeToggled(object sender, EventArgs e)
        {
            DisableUI();
            formMods.ToggleNuclearWinterModeThreaded();
        }

        private void OnNWModeUpdated(object sender, NuclearWinterEventArgs e)
        {
            this.Invoke(new Action(() => {
                EnableUI();
            }));
        }

        /// <summary>
        /// Show loading screen in front of every control.
        /// </summary>
        public void DisableUI()
        {
            this.pictureBoxLoadingGIF.Visible = true;
            this.pictureBoxLoadingGIF.Width = this.Width;
        }

        /// <summary>
        /// Makes the loading GIF invisible.
        /// </summary>
        public void EnableUI()
        {
            this.pictureBoxLoadingGIF.Visible = false;
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
                addF76.ClearAllComments();
                IniFiles.F76.Merge(addF76);

                IniFile addF76Prefs = new IniFile(Path.Combine(IniFiles.ParentPath, $"{game.IniPrefix}Prefs.add.ini"));
                addF76Prefs.Load();
                addF76Prefs.ClearAllComments();
                IniFiles.F76Prefs.Merge(addF76Prefs);

                IniFile addF76Custom = new IniFile(Path.Combine(IniFiles.ParentPath, $"{game.IniPrefix}Custom.add.ini"));
                addF76Custom.Load();
                addF76Custom.ClearAllComments();
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

        /// <summary>
        /// Calling this function will immediately stop the tool and run the updater:
        /// </summary>
        private void UpdateNow()
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

        #endregion

        #region Navigation side bar

        // TAB "Home" button:
        private void userControlSideNav2_HomeClicked(object sender, EventArgs e)
        {
            //this.tabControl1.SelectedTab = this.tabPageHome;
            this.viewControl.SelectedView = this.userControlHome;
        }

        // TAB "Tweaks" button:
        private void userControlSideNav2_TweaksClicked(object sender, EventArgs e)
        {
            //this.tabControl1.SelectedTab = this.tabPageTweaks;
            this.viewControl.SelectedView = this.userControlTweaks;

            // "Fixing" the web browser not rendering by resizing the window, which helps for some reason:
            // (https://stackoverflow.com/a/68837431)
            // TODO
            this.Height += 1;
            this.Height -= 1;
        }

        // WINDOW "Mods" button:
        private void navButtonMods_Click(object sender, EventArgs e)
        {
            this.formMods.OpenUI();
        }

        // TAB "Pip-Boy" button:
        private void userControlSideNav2_PipboyClicked(object sender, EventArgs e)
        {
            //this.tabControl1.SelectedTab = this.tabPagePipBoy;
            this.viewControl.SelectedView = this.userControlPipboy;
        }

        // TAB "Gallery" button:
        private void userControlSideNav2_GalleryClicked(object sender, EventArgs e)
        {
            //this.tabControl1.SelectedTab = this.tabPageGallery;
            this.viewControl.SelectedView = this.userControlGallery;
        }

        // TAB "Custom tweaks" button:
        private void userControlSideNav2_CustomClicked(object sender, EventArgs e)
        {
            //this.tabControl1.SelectedTab = this.tabPageCustom;
            this.viewControl.SelectedView = this.userControlCustom;
        }

        // TAB "Settings" button:
        private void navButtonSettings_Click(object sender, EventArgs e)
        {
            //this.tabControl1.SelectedTab = this.tabPageSettings;
            this.viewControl.SelectedView = this.userControlSettings;
        }

        // TAB "NexusMods" button:
        private void userControlSideNav2_NexusClicked(object sender, EventArgs e)
        {
            //this.tabControl1.SelectedTab = this.tabPageNexusMods;
            this.viewControl.SelectedView = this.userControlNexusMods;
        }

        // TAB "Profiles" button:
        private void userControlSideNav2_ProfileClicked(object sender, EventArgs e)
        {
            //this.tabControl1.SelectedTab = this.tabPageProfiles;
            this.viewControl.SelectedView = this.userControlProfiles;
        }

        // "Update" button:
        private void userControlSideNav_UpdateClicked(object sender, EventArgs e)
        {
            UpdateNow();
        }

        private void ViewControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.userControlSideNav.SelectedTabIndex = this.tabControl1.SelectedIndex;
            this.userControlSideNav.SelectedTabIndex = this.viewControl.SelectedIndex;
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


        #region Events from views

        private void UserControlHome_UpdateButtonClicked(object sender, EventArgs e)
        {
            UpdateNow();
        }

        public void OpenProfileEditor()
        {
            //this.tabControl1.SelectedTab = this.tabPageProfiles;
            this.viewControl.SelectedView = this.userControlProfiles;
            this.userControlProfiles.OpenProfileEditor();
        }

        private void userControlSettings_OpenProfileEditorRequested(object sender, EventArgs e)
        {
            OpenProfileEditor();
        }

        #endregion

        private void backgroundWorkerTranslationsCheckForUpdates_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!Configuration.IgnoreUpdates && Configuration.Localization.NotifyAboutAvailableUpdates)
                Localization.CheckForUpdates();
        }

        private void Localization_NewTranslationsAvailable(object sender, EventArgs e)
        {
            this.Invoke((MethodInvoker)(() => {
                MsgBox.Get("translationsUpdateAvailable").Popup(MessageBoxIcon.Information);
            }));
        }
    }
}
