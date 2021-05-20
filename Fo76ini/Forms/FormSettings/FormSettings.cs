using Fo76ini.Forms.FormTextPrompt;
using Fo76ini.Interface;
using Fo76ini.NexusAPI;
using Fo76ini.Profiles;
using Fo76ini.Properties;
using Fo76ini.Tweaks;
using Fo76ini.Tweaks.Config;
using Fo76ini.Tweaks.Inis;
using Fo76ini.Tweaks.NuclearWinterMode;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Forms.FormSettings
{
    public partial class FormSettings : Form
    {
        private bool UpdatingUI = false;

        public static event EventHandler SettingsClosing;

        public static bool DangerZoneEnabled = false;

        public FormSettings()
        {
            InitializeComponent();

            // Make this form translatable:
            LocalizedForm form = new LocalizedForm(this, this.toolTip);
            form.SpecialControls.Add(this.contextMenuStripGame);
            Localization.LocalizedForms.Add(form);

            // Handle translations:
            Translation.LanguageChanged += OnLanguageChanged;

            // Assign a dropdown menu to hold languages:
            Localization.AssignDropDown(this.comboBoxLanguage);

            Translation.BlackList.AddRange(new string[] {
                "buttonDownloadLanguages",
                "buttonRefreshLanguage",
                "labelNMUserID",
                "labelNMHourlyRateLimit",
                "labelNMAPIKeyStatus",
                "labelNMUserName",
                "labelNMDailyRateLimitReset",
                "labelNMMembership",
                "labelNMDailyRateLimit"
            });

            // Link tweaks
            LinkInfo();
            LinkControlsToTweaks();

            // Load NexusMods
            NexusMods.Load();


            // Init components / assign event handler:
            this.listViewGameInstances.HeaderStyle = ColumnHeaderStyle.None;

            this.backgroundWorkerDownloadLanguages.RunWorkerCompleted += backgroundWorkerDownloadLanguages_RunWorkerCompleted;
            this.backgroundWorkerRetrieveProfileInfo.RunWorkerCompleted += backgroundWorkerRetrieveProfileInfo_RunWorkerCompleted;
            this.FormClosing += FormSettings_FormClosing;

            SingleSignOn.SSOFinished += SingleSignOn_SSOFinished;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            LinkedTweaks.LoadValues();
            UpdateGamesTab();
            RefreshNMUI();
            if (IniFiles.Config.GetBool("NexusMods", "bAutoUpdateProfile", true))
                UpdateNMProfile();
            this.checkBoxHandleNXMLinks.Checked = NXMHandler.IsRegistered();
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ProfileManager.Save();
                ProfileManager.Feedback();
                if (SettingsClosing != null)
                    SettingsClosing(this, null);
                this.Hide();
            }
        }

        /// <summary>
        /// Opens the "General" tab and shows the form as a modal dialog box (ShowDialog).
        /// </summary>
        public void ShowSettings()
        {
            this.tabControl1.SelectedTab = this.tabPageGeneral;
            // Update the text fields for Archive2 and 7z
            this.textBoxArchiveTwoPath.Text = archiveTwoPathTweak.GetValue();
            this.textBoxSevenZipPath.Text = sevenZipPathTweak.GetValue();
            this.textBoxDownloadsPath.Text = downloadPathTweak.GetValue();
            this.ShowDialog();
        }

        /// <summary>
        /// Opens the "Game profiles" tab and shows the form as a modal dialog box (ShowDialog).
        /// </summary>
        public void ShowProfiles()
        {
            this.tabControl1.SelectedTab = this.tabPageGameProfiles;
            this.ShowDialog();
        }

        #region General

        public void LinkInfo()
        {
            LinkedTweaks.LinkInfo(checkBoxReadOnly, toolTip, iniReadOnlyTweak);
            LinkedTweaks.LinkInfo(checkBoxAutoApply, toolTip, autoApplyTweak);
            LinkedTweaks.LinkInfo(checkBoxIgnoreUpdates, toolTip, ignoreUpdatesTweak);
            LinkedTweaks.LinkInfo(checkBoxPlayNotificationSound, toolTip, playNotificationSoundsTweak);
            LinkedTweaks.LinkInfo(checkBoxQuitOnGameLaunch, toolTip, toolQuitOnLaunchTweak);
            LinkedTweaks.LinkInfo(checkBoxNWRenameDLL, toolTip, renameDLLsTweak);
            LinkedTweaks.LinkInfo(checkBoxNWAutoDeployMods, toolTip, deployModsOnNWModeTweak);
            LinkedTweaks.LinkInfo(checkBoxNWAutoDisableMods, toolTip, removeModsOnNWModeTweak);
            LinkedTweaks.LinkInfo(labelArchiveTwoPath, toolTip, archiveTwoPathTweak);
            LinkedTweaks.LinkInfo(labelSevenZipPath, toolTip, sevenZipPathTweak);
            LinkedTweaks.LinkInfo(labelDownloadsPath, toolTip, downloadPathTweak);
            LinkedTweaks.LinkInfo(textBoxArchiveTwoPath, toolTip, archiveTwoPathTweak);
            LinkedTweaks.LinkInfo(textBoxSevenZipPath, toolTip, sevenZipPathTweak);
            LinkedTweaks.LinkInfo(textBoxDownloadsPath, toolTip, downloadPathTweak);
            LinkedTweaks.LinkInfo(buttonPickArchiveTwoPath, toolTip, archiveTwoPathTweak);
            LinkedTweaks.LinkInfo(buttonPickSevenZipPath, toolTip, sevenZipPathTweak);
            LinkedTweaks.LinkInfo(buttonPickDownloadsPath, toolTip, downloadPathTweak);
        }

        public void LinkControlsToTweaks()
        {
            // Make *.ini files read-only
            LinkedTweaks.LinkTweak(checkBoxReadOnly, iniReadOnlyTweak);

            // Automatically apply changes when tool is closed or game is launched
            LinkedTweaks.LinkTweak(checkBoxAutoApply, autoApplyTweak);

            // Don't check for updates on startup.
            LinkedTweaks.LinkTweak(checkBoxIgnoreUpdates, ignoreUpdatesTweak);

            // Play notification sounds
            LinkedTweaks.LinkTweak(checkBoxPlayNotificationSound, playNotificationSoundsTweak);

            // Close the tool when the game is launched.
            LinkedTweaks.LinkTweak(checkBoxQuitOnGameLaunch, toolQuitOnLaunchTweak);


            /*
             * Nuclear Winter options
             */

            // Rename added *.dll files
            LinkedTweaks.LinkTweak(checkBoxNWRenameDLL, renameDLLsTweak);

            // Automatically deploy mods
            LinkedTweaks.LinkTweak(checkBoxNWAutoDeployMods, deployModsOnNWModeTweak);

            // Automatically remove mods
            LinkedTweaks.LinkTweak(checkBoxNWAutoDisableMods, removeModsOnNWModeTweak);
        }

        private void linkLabelEnableDangerZone_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (MsgBox.Show("Warning", "Tweaks in the danger zone might introduce graphical glitches or make the game crash.\nAre you sure you want to enable it?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                DangerZoneEnabled = true;
                this.linkLabelEnableDangerZone.Enabled = false;
            }
        }

        private void checkBoxIgnoreUpdates_CheckedChanged(object sender, EventArgs e)
        {
            // TODO: When checkBoxIgnoreUpdates gets checked, call Form1.CheckVersion
        }

        #endregion

        #region Profiles

        private void UpdateGamesTab()
        {
            UpdatingUI = true;

            // For each managed game instance...
            this.listViewGameInstances.Items.Clear();
            foreach (GameInstance game in ProfileManager.Games)
            {
                // ... add it to the list.
                ListViewItem gameItem = new ListViewItem(game.Title, GetImageIndex(game.Edition));
                this.listViewGameInstances.Items.Add(gameItem);

                // If it is the currently selected game, then...
                if (ProfileManager.IsSelected(game))
                {
                    // ... select it in the list ...
                    gameItem.Selected = true;

                    // ... set the title of the window ...
                    //this.Text = $"Profiles ({game.Title})";

                    // ... fill the list of profiles:
                    /*this.listBoxProfile.Items.Clear();
                    int i = 0;
                    foreach (Profile profile in game.Profiles)
                    {
                        this.listBoxProfile.Items.Add(profile.Name);
                        if (game.SelectedProfile.guid == profile.guid)
                            this.listBoxProfile.SelectedIndex = i;
                        i++;
                    }*/

                    // ... and update the settings:
                    switch (game.Edition)
                    {
                        case GameEdition.BethesdaNet:
                            this.radioButtonEditionBethesdaNet.Checked = true;
                            break;
                        case GameEdition.BethesdaNetPTS:
                            this.radioButtonEditionBethesdaNetPTS.Checked = true;
                            break;
                        case GameEdition.Steam:
                            this.radioButtonEditionSteam.Checked = true;
                            break;
                        case GameEdition.MSStore:
                            this.radioButtonEditionMSStore.Checked = true;
                            break;
                        default:
                            this.radioButtonEditionUnknown.Checked = true;
                            break;
                    }

                    this.radioButtonLaunchViaLink.Checked = game.PreferredLaunchOption == LaunchOption.OpenURL;
                    this.radioButtonLaunchViaExecutable.Checked = game.PreferredLaunchOption == LaunchOption.RunExec;

                    this.textBoxGamePath.Text = game.GamePath;
                    this.textBoxExecutable.Text = game.ExecutableName;
                    this.textBoxIniPrefix.Text = game.IniPrefix;
                    this.textBoxParameters.Text = game.ExecParameters;
                    this.textBoxLaunchURL.Text = game.LauncherURL;

                    this.labelLaunchOptionMSStoreNotice.Visible = game.Edition == GameEdition.MSStore;
                }
            }

            UpdatingUI = false;
        }

        private int GetImageIndex(GameEdition edition)
        {
            switch (edition)
            {
                case GameEdition.BethesdaNet:
                case GameEdition.BethesdaNetPTS:
                    return 1;
                case GameEdition.Steam:
                    return 2;
                case GameEdition.MSStore:
                    return 3;
                default:
                    return 0;
            }
        }


        private void listViewGameInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            if (this.listViewGameInstances.SelectedItems != null && this.listViewGameInstances.SelectedItems.Count > 0)
            {
                int index = this.listViewGameInstances.SelectedItems[0].Index;
                if (ProfileManager.SelectedGameIndex != index)
                {
                    ProfileManager.SelectedGameIndex = index;
                    UpdateGamesTab();
                }
            }
        }

        private void radioButtonEditionBethesdaNet_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.Edition = GameEdition.BethesdaNet;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.BethesdaNet);
            UpdateGamesTab();
        }

        private void radioButtonEditionBethesdaNetPTS_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.Edition = GameEdition.BethesdaNetPTS;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.BethesdaNetPTS);
            UpdateGamesTab();
        }

        private void radioButtonEditionSteam_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.Edition = GameEdition.Steam;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.Steam);
            UpdateGamesTab();
        }

        private void radioButtonEditionMSStore_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.Edition = GameEdition.MSStore;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.MSStore);
            UpdateGamesTab();
        }

        private void radioButtonEditionUnknown_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.Edition = GameEdition.Unknown;
            UpdateGamesTab();
        }

        private void textBoxGamePath_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.GamePath = this.textBoxGamePath.Text;
            this.textBoxGamePath.ForeColor = ProfileManager.SelectedGame.ValidateGamePath() ? Color.Black : Color.Maroon;
        }

        private void buttonPickGamePath_Click(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            this.openFileDialogGamePath.FileName = ProfileManager.SelectedGame.ExecutableName;
            if (this.openFileDialogGamePath.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetDirectoryName(this.openFileDialogGamePath.FileName); // We want the path where Fallout76.exe resides.
                if (GameInstance.ValidateGamePath(path))
                {
                    this.textBoxGamePath.Text = path;
                    ProfileManager.SelectedGame.GamePath = path;
                    UpdateGamesTab();
                }
                else
                    MsgBox.ShowID("modsGamePathInvalid");
            }
        }

        public static string AutoDetectGamePath()
        {
            /*
             * I could totally search through every single folder on a user's computer, but that would take way too long. So, I'll take shortcuts.
             * This is not about to find a path for every user 100% of the time, but an attempt to find a path for MOST users in the shortest amount of time.
             * If it can't find the path, the user likely knows enough about their computer to find it themselves. Even if it's a bit inconvenient.
             */

            // Search every drive:
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                // Only search fixed drives:
                if (d.DriveType != DriveType.Fixed)
                    continue;

                // Search for "default" paths that are the most common:
                string steamDefaultPath = Path.Combine(d.Name, @"Program Files (x86)\Steam\steamapps\common\Fallout76");
                if (GameInstance.ValidateGamePath(steamDefaultPath))
                    return steamDefaultPath;

                string bethNetDefaultPath = Path.Combine(d.Name, @"Program Files (x86)\Bethesda.net Launcher\games\Fallout76");
                if (GameInstance.ValidateGamePath(bethNetDefaultPath))
                    return bethNetDefaultPath;

                string xboxDefaultPath = Path.Combine(d.Name, @"Program Files\ModifiableWindowsApps\Fallout76");
                if (GameInstance.ValidateGamePath(xboxDefaultPath))
                    return xboxDefaultPath;

                // Try some exotic ones, maybe?
                string steamTopLevelPath = Path.Combine(d.Name, @"steamapps\common\Fallout76");
                if (GameInstance.ValidateGamePath(steamTopLevelPath))
                    return steamTopLevelPath;

                // Search every top-level folder on the drive:
                foreach (string path in Directory.EnumerateDirectories(d.Name))
                {
                    if (GameInstance.ValidateGamePath(path))
                        return path;

                    string steamSubDirPath = Path.Combine(path, @"steamapps\common\Fallout76");
                    if (GameInstance.ValidateGamePath(steamSubDirPath))
                        return steamSubDirPath;
                }
            }

            return null;
        }

        private void buttonAutoDetect_Click(object sender, EventArgs e)
        {
            string foundPath = AutoDetectGamePath();
            if (foundPath != null)
                TextPrompt.Prompt("Found a path. Proceed?", foundPath, (newPath) => this.textBoxGamePath.Text = newPath);
            else
                MsgBox.ShowID("gamePathAutoDetectFailed", MessageBoxIcon.Information);
        }

        private void radioButtonLaunchViaLink_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.PreferredLaunchOption = LaunchOption.OpenURL;
        }

        private void radioButtonLaunchViaExecutable_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.PreferredLaunchOption = LaunchOption.RunExec;
        }

        private void textBoxIniPrefix_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.IniPrefix = this.textBoxIniPrefix.Text;
        }

        private void textBoxExecutable_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.ExecutableName = this.textBoxExecutable.Text;
        }

        private void textBoxParameters_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.ExecParameters = this.textBoxParameters.Text;
        }

        private void textBoxLaunchURL_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.LauncherURL = this.textBoxLaunchURL.Text;
        }

        private void toolStripButtonAddGame_Click(object sender, EventArgs e)
        {
            GameInstance game = new GameInstance();
            ProfileManager.AddGame(game);
            ProfileManager.SelectGame(game);
            UpdateGamesTab();
        }
        private void launchGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfileManager.SelectedGame.LaunchGame();
        }

        private void renameGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String oldName = ProfileManager.SelectedGame.Title;
            TextPrompt.Prompt($"Edit title of game {oldName}", oldName, (newName) => {
                if (newName.Trim() != "")
                {
                    ProfileManager.SelectedGame.Title = newName;
                    UpdateGamesTab();
                }
            });
        }

        private void removeGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProfileManager.Count == 1)
            {
                MsgBox.Get("errorAtLeastOneGameOrProfile").Show(MessageBoxIcon.Error);
                return;
            }

            if (MsgBox.Get("deleteQuestion")
                .FormatTitle(ProfileManager.SelectedGame.Title)
                .FormatText(ProfileManager.SelectedGame.Title)
                .Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProfileManager.RemoveGame(ProfileManager.SelectedGame);
                ProfileManager.SelectedGameIndex -= 1;
                UpdateGamesTab();
            }
        }

        private void contextMenuStripGame_Opening(object sender, CancelEventArgs e)
        {
            this.gameToolStripMenuItem.Text = ProfileManager.SelectedGame.Title;
        }

        #endregion

        #region Translations

        public void OnLanguageChanged(object sender, TranslationEventArgs e)
        {
            Translation translation = (Translation)sender;
            this.labelOutdatedLanguage.Visible = translation.IsOutdated();
        }

        private void buttonDownloadLanguages_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorkerDownloadLanguages.IsBusy)
                return;
            this.groupBoxLocalization.Focus();
            this.buttonDownloadLanguages.Enabled = false;
            this.pictureBoxSpinnerDownloadLanguages.Visible = true;
            this.backgroundWorkerDownloadLanguages.RunWorkerAsync();
        }

        private void buttonRefreshLanguage_Click(object sender, EventArgs e)
        {
            Localization.LookupLanguages();
        }

        private Localization.DownloadResult languageFilesDownloadResult;
        private void backgroundWorkerDownloadLanguages_DoWork(object sender, DoWorkEventArgs e)
        {
            languageFilesDownloadResult = Localization.DownloadLanguageFiles();
        }

        private void backgroundWorkerDownloadLanguages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!languageFilesDownloadResult.Success)
                MsgBox.Get("failed")
                    .FormatText("Downloading language files failed.\n" + languageFilesDownloadResult.ErrorMessage)
                    .Popup(MessageBoxIcon.Error);
            else
                MsgBox.Get("downloadLanguagesFinished")
                    .FormatText(String.Join(", ", languageFilesDownloadResult.FileList))
                    .Popup(MessageBoxIcon.Information);

            this.buttonDownloadLanguages.Enabled = true;
            this.pictureBoxSpinnerDownloadLanguages.Visible = false;

            Localization.LookupLanguages();
        }

        #endregion

        #region NexusAPI

        /*
         * Interface:
         */

        /// <summary>
        /// As a last resort, if the SSO fails, the user can enter their API key manually.
        /// </summary>
        private bool APIKeyTextboxEnabled = false;

        public void RefreshNMUI()
        {
            /*
             * Visiblility of labels:
             */

            bool loggedIn = NexusMods.User.IsLoggedIn;

            // Labels:
            this.labelNMNotLoggedIn.Visible = !loggedIn;
            this.labelNMDailyRateLimit.Visible = loggedIn;
            this.labelNMHourlyRateLimit.Visible = loggedIn;
            this.labelNMDailyRateLimitReset.Visible = loggedIn;
            this.labelNMDescDailyRateLimit.Visible = loggedIn;
            this.labelNMDescHourlyRateLimit.Visible = loggedIn;
            this.labelNMDescLimitReset.Visible = loggedIn;
            this.labelNMDescMembership.Visible = loggedIn;
            this.labelNMDescUserID.Visible = loggedIn;
            this.labelNMMembership.Visible = loggedIn;
            this.labelNMUserID.Visible = loggedIn;

            this.linkLabelEnableAPIKey.Visible = !APIKeyTextboxEnabled && !loggedIn;


            /*
             * Position and visiblility of buttons:
             */

            int buttonMargin = 6;  // px
            int buttonOffset = 25; // px

            Button[] buttons = new Button[] { buttonNMLogin, buttonNMLoginManually, buttonNWLogout, buttonNMUpdateProfile, buttonNWDeleteCache };
            bool[] visiblity = new bool[] { !loggedIn, !loggedIn && APIKeyTextboxEnabled, loggedIn, loggedIn, true };

            for (int i = 0; i < buttons.Length; i++)
            {
                int left = buttonOffset;
                for (int j = 0; j < i; j++)
                {
                    if (j >= 0 && visiblity[j])
                        left += buttons[j].Width + buttonMargin;
                }
                buttons[i].Left = left;
                buttons[i].Visible = visiblity[i];
            }


            /*
             * API Key textbox:
             */

            this.textBoxAPIKey.Visible = APIKeyTextboxEnabled;
            this.checkBoxShowAPIKey.Visible = APIKeyTextboxEnabled;
            this.labelAPIKey.Visible = APIKeyTextboxEnabled;
            this.linkLabelAPIKeyHelp.Visible = APIKeyTextboxEnabled;
            this.pictureBoxAPIKeyHelp.Visible = APIKeyTextboxEnabled;

            if (APIKeyTextboxEnabled)
            {
                this.textBoxAPIKey.Text = NexusMods.User.APIKey;
            }


            /*
             * Fill in information:
             */

            this.labelNMUserName.Text = NexusMods.User.UserName;
            this.labelNMUserID.Text = NexusMods.User.UserID.ToString();

            switch (NexusMods.User.Status)
            {
                case NMUserProfile.Membership.Premium:
                    this.labelNMMembership.Text = Localization.GetString("nmPremiumAccount");
                    this.labelNMMembership.ForeColor = Color.PaleGreen;
                    break;
                case NMUserProfile.Membership.Supporter:
                    this.labelNMMembership.Text = Localization.GetString("nmSupporterAccount");
                    this.labelNMMembership.ForeColor = Color.Orange;
                    break;
                case NMUserProfile.Membership.Basic:
                default:
                    this.labelNMMembership.Text = Localization.GetString("nmBasicAccount");
                    this.labelNMMembership.ForeColor = Color.White;
                    break;
            }

            this.labelNMDailyRateLimit.Text = string.Format(Localization.GetString("nmRateLimitLeft"), NexusMods.User.DailyRateLimit);
            this.labelNMHourlyRateLimit.Text = string.Format(Localization.GetString("nmRateLimitLeft"), NexusMods.User.HourlyRateLimit);
            DateTime dailyRateLimitReset;
            if (NexusMods.User.DailyRateLimitResetString != "" &&
                NexusMods.User.TryParseDailyRateLimitReset(out dailyRateLimitReset))
            {
                TimeSpan diff = dailyRateLimitReset - DateTime.Now;
                this.labelNMDailyRateLimitReset.Text = string.Format(Localization.GetString("nmResetTime"), diff.Hours, diff.Minutes);
            }
            else
            {
                this.labelNMDailyRateLimitReset.Text = Localization.GetString("unknown");
            }

            this.pictureBoxNMProfilePicture.Image = Resources.user_white;
            if (NexusMods.User.ProfilePictureFileName != null &&
                File.Exists(NexusMods.User.ProfilePictureFilePath))
            {
                Bitmap bitmap;
                using (Image img = Image.FromFile(NexusMods.User.ProfilePictureFilePath))
                {
                    bitmap = new Bitmap(img);
                    this.pictureBoxNMProfilePicture.Image = bitmap;
                    //this.pictureBoxNMProfilePicture.Image = Image.FromFile(NexusMods.User.ProfilePictureFilePath);
                }
            }

            this.checkBoxNMUpdateProfile.Checked = IniFiles.Config.GetBool("NexusMods", "bAutoUpdateProfile", true);
            //this.checkBoxNMUpdateModInfo.Checked = IniFiles.Instance.GetBool(IniFile.Config, "NexusMods", "bAutoUpdateModInfo", false);
            this.checkBoxNMDownloadThumbnails.Checked = IniFiles.Config.GetBool("NexusMods", "bDownloadThumbnailsOnUpdate", true);
        }

        /*
         * Event handler:
         */

        private void UpdateNMProfile()
        {
            if (this.backgroundWorkerRetrieveProfileInfo.IsBusy)
                return;
            if (NexusMods.User.APIKey == "")
                return;
            this.pictureBoxNMProfilePicture.Image = Resources.Spinner_200;
            this.backgroundWorkerRetrieveProfileInfo.RunWorkerAsync();
        }

        private void buttonNMLogin_Click(object sender, EventArgs e)
        {
            MsgBox.Show("Login to NexusMods", "When the web browser opens, please click on 'Authorize' to login in.\nClick 'OK' to continue.", MessageBoxIcon.Information);
            backgroundWorkerSSOLogin.RunWorkerAsync();
        }

        private void SingleSignOn_SSOFinished(object sender, SSOEventArgs e)
        {
            // The SSOFinished event handler is called from another thread, therefore Invoke is required:
            this.tabPageNexusMods.Invoke(new Action(() => {
                if (e.success)
                {
                    NexusMods.User.APIKey = e.APIKey;
                    MsgBox.Popup("Success", "You are now logged in with your NexusMods account.", MessageBoxIcon.Information);
                    UpdateNMProfile();
                }
                else
                {
                    if (e.Exception != null)
                    {
                        if (e.Exception is PlatformNotSupportedException)
                        {
                            MsgBox.Show("Failed", "** WebSockets are not supported on Windows 7 and older. **\nBut you can still enter the API key manually to login. Please follow the instructions on the GitHub wiki.", MessageBoxIcon.Error);
                        }
                        else
                        {
                            MsgBox.Show("Failed", $"{e.Exception.GetType()}: {e.Exception.Message}", MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MsgBox.Popup("Failed", "Something went wrong.", MessageBoxIcon.Error);
                    }

                    APIKeyTextboxEnabled = true;
                    RefreshNMUI();
                }
            }));
        }

        private void linkLabelEnableAPIKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            APIKeyTextboxEnabled = true;
            RefreshNMUI();
        }

        private void buttonNMLoginManually_Click(object sender, EventArgs e)
        {
            UpdateNMProfile();
        }

        private void buttonNMUpdateProfile_Click(object sender, EventArgs e)
        {
            UpdateNMProfile();
        }

        private void buttonNWLogout_Click(object sender, EventArgs e)
        {
            if (MsgBox.Get("areYouSure").FormatText("Do you really want to log out?").Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.pictureBoxNMProfilePicture.Image = Resources.user_white;
                NexusMods.User.Remove();
                RefreshNMUI();
                MsgBox.Get("done").FormatText("Logged out").Popup(MessageBoxIcon.Information);
            }
        }

        private void buttonNWDeleteCache_Click(object sender, EventArgs e)
        {
            if (MsgBox.Get("areYouSure").FormatText("Do you really want to delete all remote information?").Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // TODO: Call FormMods.UpdateModList after deleting remote info
                NexusMods.DeleteCache();
                MsgBox.Get("done").FormatText("Removed remote information").Popup(MessageBoxIcon.Information);
            }
        }

        private void pictureBoxNMProfilePicture_Click(object sender, EventArgs e)
        {
            if (NexusMods.User.UserID >= 0)
                Utils.OpenURL("https://www.nexusmods.com/users/"+ NexusMods.User.UserID);
        }

        private void checkBoxShowAPIKey_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxAPIKey.UseSystemPasswordChar = !this.checkBoxShowAPIKey.Checked;
            this.textBoxAPIKey.PasswordChar = !this.checkBoxShowAPIKey.Checked ? '\u2022' : '\0';
        }

        private void textBoxAPIKey_TextChanged(object sender, EventArgs e)
        {
            NexusMods.User.APIKey = this.textBoxAPIKey.Text;
        }

        private void linkLabelAPIKeyHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Utils.OpenURL("https://github.com/FelisDiligens/Fallout76-QuickConfiguration/wiki/Troubleshooting:-Login-with-NexusMods-failed");
        }


        // Options:

        private void checkBoxNMUpdateProfile_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Config.Set("NexusMods", "bAutoUpdateProfile", this.checkBoxNMUpdateProfile.Checked);
            IniFiles.Config.Save();
        }

        private void checkBoxNMDownloadThumbnails_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Config.Set("NexusMods", "bDownloadThumbnailsOnUpdate", this.checkBoxNMDownloadThumbnails.Checked);
            IniFiles.Config.Save();
        }


        /*
         * Background worker:
         */

        // Retrieve profile info:

        private void backgroundWorkerRetrieveProfileInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            NexusMods.User.Update();
            NexusMods.User.Save();
        }

        private void backgroundWorkerRetrieveProfileInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RefreshNMUI();
        }

        private void backgroundWorkerSSOLogin_DoWork(object sender, DoWorkEventArgs e)
        {
            SingleSignOn.Connect();
        }

        #endregion

        private SevenZipPathTweak sevenZipPathTweak = new SevenZipPathTweak();
        private ArchiveTwoPathTweak archiveTwoPathTweak = new ArchiveTwoPathTweak();
        private DownloadPathTweak downloadPathTweak = new DownloadPathTweak();

        private INIReadOnlyTweak iniReadOnlyTweak = new INIReadOnlyTweak();
        private AutoApplyTweak autoApplyTweak = new AutoApplyTweak();
        private IgnoreUpdatesTweak ignoreUpdatesTweak = new IgnoreUpdatesTweak();
        private PlayNotificationSoundsTweak playNotificationSoundsTweak = new PlayNotificationSoundsTweak();
        private ToolQuitOnLaunchTweak toolQuitOnLaunchTweak = new ToolQuitOnLaunchTweak();

        private DeployModsOnNWModeTweak deployModsOnNWModeTweak = new DeployModsOnNWModeTweak();
        private RemoveModsOnNWModeTweak removeModsOnNWModeTweak = new RemoveModsOnNWModeTweak();
        private RenameDLLsTweak renameDLLsTweak = new RenameDLLsTweak();

        private void textBoxArchiveTwoPath_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            archiveTwoPathTweak.SetValue(this.textBoxArchiveTwoPath.Text);
        }

        private void buttonPickArchiveTwoPath_Click(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            this.openFileDialogArchiveTwoPath.FileName = archiveTwoPathTweak.DefaultValue;
            if (this.openFileDialogArchiveTwoPath.ShowDialog() == DialogResult.OK)
            {
                string path = this.openFileDialogArchiveTwoPath.FileName;
                this.textBoxArchiveTwoPath.Text = path;
                archiveTwoPathTweak.SetValue(this.textBoxArchiveTwoPath.Text);
            }
        }

        private void textBoxSevenZipPath_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            sevenZipPathTweak.SetValue(this.textBoxSevenZipPath.Text);
        }

        private void buttonPickSevenZipPath_Click(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            this.openFileDialogSevenZipPath.FileName = sevenZipPathTweak.DefaultValue;
            if (this.openFileDialogSevenZipPath.ShowDialog() == DialogResult.OK)
            {
                string path = this.openFileDialogSevenZipPath.FileName;
                this.textBoxSevenZipPath.Text = path;
                sevenZipPathTweak.SetValue(this.textBoxSevenZipPath.Text);
            }
        }

        private void textBoxDownloadsPath_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            downloadPathTweak.SetValue(this.textBoxDownloadsPath.Text);
        }

        private void buttonPickDownloadsPath_Click(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            this.openFileDialogSevenZipPath.FileName = downloadPathTweak.DefaultValue;
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = this.folderBrowserDialog.SelectedPath;
                this.textBoxDownloadsPath.Text = path;
                downloadPathTweak.SetValue(this.textBoxSevenZipPath.Text);
            }
        }

        private void checkBoxHandleNXMLinks_CheckedChanged(object sender, EventArgs e)
        {
            bool isRegistered = NXMHandler.IsRegistered();
            if (isRegistered == checkBoxHandleNXMLinks.Checked)
                return;

            try
            {
                if (isRegistered)
                    NXMHandler.Unregister();
                else
                    NXMHandler.Register();
            }
            catch (System.UnauthorizedAccessException ex)
            {
                MsgBox.Show("Access denied", "Start the tool as admin and try again.", MessageBoxIcon.Error);
                checkBoxHandleNXMLinks.Checked = isRegistered;
            }
            catch (Exception ex)
            {
                MsgBox.Show("Unknown error", "Start the tool as admin and try again.", MessageBoxIcon.Error);
                checkBoxHandleNXMLinks.Checked = isRegistered;
            }
        }
    }
}
