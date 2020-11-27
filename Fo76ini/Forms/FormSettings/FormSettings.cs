﻿using Fo76ini.Forms.FormTextPrompt;
using Fo76ini.Interface;
using Fo76ini.NexusAPI;
using Fo76ini.Profiles;
using Fo76ini.Properties;
using Fo76ini.Tweaks;
using Fo76ini.Tweaks.Config;
using Fo76ini.Tweaks.Inis;
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

        public FormSettings()
        {
            InitializeComponent();

            // Make this form translatable:
            Localization.LocalizedForms.Add(new LocalizedForm(this, toolTip));

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

            this.listViewGameInstances.HeaderStyle = ColumnHeaderStyle.None;

            this.backgroundWorkerDownloadLanguages.RunWorkerCompleted += backgroundWorkerDownloadLanguages_RunWorkerCompleted;
            this.backgroundWorkerRetrieveProfileInfo.RunWorkerCompleted += backgroundWorkerRetrieveProfileInfo_RunWorkerCompleted;
            this.FormClosing += FormSettings_FormClosing;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            LinkedTweaks.LoadValues();
            UpdateGamesTab();
            RefreshNMUI();
            if (IniFiles.Config.GetBool("NexusMods", "bAutoUpdateProfile", true))
                UpdateNMProfile();
        }

        private void FormSettings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ProfileManager.Save();
                ProfileManager.Feedback();
                this.Hide();
            }
        }

        #region General

        public void LinkInfo()
        {
            LinkedTweaks.LinkInfo(checkBoxReadOnly, toolTip, iniReadOnlyTweak);
            LinkedTweaks.LinkInfo(checkBoxAutoApply, toolTip, autoApplyTweak);
            LinkedTweaks.LinkInfo(checkBoxIgnoreUpdates, toolTip, ignoreUpdatesTweak);
            LinkedTweaks.LinkInfo(checkBoxPlayNotificationSound, toolTip, playNotificationSoundsTweak);
            LinkedTweaks.LinkInfo(checkBoxQuitOnGameLaunch, toolTip, toolQuitOnLaunchTweak);
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

        private void buttonAutoDetect_Click(object sender, EventArgs e)
        {
            // Search most common installation directories (probably good enough for now):
            string foundPath = "";
            string steamPath = @"C:\Program Files(x86)\Steam\steamapps\common\Fallout76";
            string bethNetPath = @"C:\Program Files (x86)\Bethesda.net Launcher\games\Fallout76";
            string xboxPathC = @"C:\Program Files\ModifiableWindowsApps\Fallout76";
            string xboxPathD = @"D:\Program Files\ModifiableWindowsApps\Fallout76";

            GameEdition edition = ProfileManager.SelectedGame.Edition;

            if (edition == GameEdition.Steam && GameInstance.ValidateGamePath(steamPath))
                foundPath = steamPath;

            if ((edition == GameEdition.BethesdaNet || edition == GameEdition.BethesdaNetPTS) && GameInstance.ValidateGamePath(bethNetPath))
                foundPath = bethNetPath;

            if (edition == GameEdition.MSStore && GameInstance.ValidateGamePath(xboxPathC))
                foundPath = xboxPathC;

            if (edition == GameEdition.MSStore && GameInstance.ValidateGamePath(xboxPathD))
                foundPath = xboxPathD;

            /*
              Registry? I only found this:
                Path: Computer\HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\Uninstall\Fallout 76
                Name: Path
                Type: REG_SZ
                Data: "D:\Bethesda.net\Fallout76"
             */

            if (foundPath != "")
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

        private string errorMessageDownloadLanguages = null;
        private string messageDownloadLanguages = null;
        private void backgroundWorkerDownloadLanguages_DoWork(object sender, DoWorkEventArgs e)
        {
            // Download / update languages:
            try
            {
                WebClient wc = new WebClient();
                wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);

                byte[] raw = wc.DownloadData("https://raw.githubusercontent.com/FelisDiligens/Fallout76-QuickConfiguration/master/Translations/list.txt");
                string encoded = Encoding.UTF8.GetString(raw).Trim();

                string[] list = encoded.Split('\n', ',');

                foreach (string file in list)
                {
                    wc.DownloadFile("https://raw.githubusercontent.com/FelisDiligens/Fallout76-QuickConfiguration/master/Translations/" + file, Path.Combine(Localization.LanguageFolder, file));
                }

                errorMessageDownloadLanguages = null;
                messageDownloadLanguages = string.Join(", ", list);
            }
            catch (WebException ex)
            {
                errorMessageDownloadLanguages = ex.ToString();
                messageDownloadLanguages = null;
            }
            catch
            {
                errorMessageDownloadLanguages = "Unknown error";
                messageDownloadLanguages = null;
            }
        }

        private void backgroundWorkerDownloadLanguages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (errorMessageDownloadLanguages != null)
                MsgBox.Get("failed").FormatText("Downloading language files failed.\n" + errorMessageDownloadLanguages).Popup(MessageBoxIcon.Error);
            else
                MsgBox.Get("downloadLanguagesFinished").FormatText(messageDownloadLanguages).Popup(MessageBoxIcon.Information);
            this.buttonDownloadLanguages.Enabled = true;
            this.pictureBoxSpinnerDownloadLanguages.Visible = false;
            Localization.LookupLanguages();
        }

        #endregion

        #region NexusAPI

        /*
         * Interface:
         */

        public void RefreshNMUI()
        {
            bool loggedIn = NexusMods.IsLoggedIn;

            this.labelNMNotLoggedIn.Visible = !loggedIn;
            this.linkLabelNMGetAPIKey.Visible = !loggedIn;

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
            this.labelNMDescAPIKey.Visible = loggedIn;
            this.labelNMAPIKeyStatus.Visible = loggedIn;


            this.textBoxAPIKey.Text = NexusMods.Profile.APIKey;

            this.labelNMUserName.Text = NexusMods.Profile.UserName;
            this.labelNMUserID.Text = NexusMods.Profile.UserID.ToString();

            switch (NexusMods.Profile.Status)
            {
                case NMProfile.Membership.Premium:
                    this.labelNMMembership.Text = Localization.GetString("nmPremiumAccount");
                    this.labelNMMembership.ForeColor = Color.PaleGreen;
                    break;
                case NMProfile.Membership.Supporter:
                    this.labelNMMembership.Text = Localization.GetString("nmSupporterAccount");
                    this.labelNMMembership.ForeColor = Color.Orange;
                    break;
                case NMProfile.Membership.Basic:
                default:
                    this.labelNMMembership.Text = Localization.GetString("nmBasicAccount");
                    this.labelNMMembership.ForeColor = Color.White;
                    break;
            }

            if (!NexusMods.Profile.ValidKey)
            {
                this.labelNMAPIKeyStatus.Text = Localization.GetString("invalid");
                this.labelNMAPIKeyStatus.ForeColor = Color.Red;
            }
            else
            {
                this.labelNMAPIKeyStatus.Text = Localization.GetString("valid");
                this.labelNMAPIKeyStatus.ForeColor = Color.PaleGreen;
            }

            this.labelNMDailyRateLimit.Text = string.Format(Localization.GetString("nmRateLimitLeft"), NexusMods.Profile.DailyRateLimit);
            this.labelNMHourlyRateLimit.Text = string.Format(Localization.GetString("nmRateLimitLeft"), NexusMods.Profile.HourlyRateLimit);
            if (NexusMods.Profile.DailyRateLimitResetString != "")
            {
                TimeSpan diff = NexusMods.Profile.DailyRateLimitReset - DateTime.Now;
                this.labelNMDailyRateLimitReset.Text = string.Format(Localization.GetString("nmResetTime"), diff.Hours, diff.Minutes);
            }
            else
            {
                this.labelNMDailyRateLimitReset.Text = Localization.GetString("nmResetTimeNever");
            }

            this.pictureBoxNMProfilePicture.Image = Resources.user_white;
            if (NexusMods.Profile.ProfilePicture != null)
            {
                string profilePicPath = Path.Combine(NexusMods.FolderPath, NexusMods.Profile.ProfilePicture);
                if (File.Exists(profilePicPath))
                    this.pictureBoxNMProfilePicture.Image = Image.FromFile(profilePicPath);
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
            if (this.textBoxAPIKey.Text == "")
                return;
            this.pictureBoxNMProfilePicture.Image = Resources.Spinner_200;
            this.backgroundWorkerRetrieveProfileInfo.RunWorkerAsync();
        }

        private void buttonNMUpdateProfile_Click(object sender, EventArgs e)
        {
            UpdateNMProfile();
        }

        private void buttonNWLogout_Click(object sender, EventArgs e)
        {
            if (MsgBox.Get("areYouSure").FormatText("Do you really want to remove your profile?").Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.pictureBoxNMProfilePicture.Image = Resources.user_white;
                this.textBoxAPIKey.Text = "";
                NexusMods.Profile.Remove();
                RefreshNMUI();
                MsgBox.Get("done").FormatText("Logged out").Popup(MessageBoxIcon.Information);
            }
        }

        private void buttonNWDeleteAll_Click(object sender, EventArgs e)
        {
            // TODO: Simplify this, add new msgbox

            if (MsgBox.Get("areYouSure").FormatText("Do you really want to delete all remote information?").Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NexusMods.ClearRemoteInfo();
                // TODO: UpdateModList?
                //this.UpdateModList();

                // TODO: Make this a method of NexusMods
                try
                {
                    string path = Path.Combine(NexusMods.ThumbnailsPath);
                    if (Directory.Exists(path))
                        Directory.Delete(path, true);
                }
                catch
                {
                    // Uhh....
                }

                MsgBox.Get("done").FormatText("Removed remote information").Popup(MessageBoxIcon.Information);
            }
        }

        private void linkLabelNMGetAPIKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelNMGetAPIKey.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.nexusmods.com/users/myaccount?tab=api%20access");
        }

        private void textBoxAPIKey_TextChanged(object sender, EventArgs e)
        {
            IniFiles.Config.Set("NexusMods", "sAPIKey", this.textBoxAPIKey.Text);
            IniFiles.Config.Save();
            NexusMods.Profile.APIKey = this.textBoxAPIKey.Text;
        }

        private void checkBoxShowAPIKey_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxAPIKey.UseSystemPasswordChar = !this.checkBoxShowAPIKey.Checked;
            this.textBoxAPIKey.PasswordChar = !this.checkBoxShowAPIKey.Checked ? '\u2022' : '\0';
        }

        private void pictureBoxNMProfilePicture_Click(object sender, EventArgs e)
        {
            if (NexusMods.Profile.UserID >= 0)
                System.Diagnostics.Process.Start($"https://www.nexusmods.com/users/{NexusMods.Profile.UserID}");
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
            NexusMods.Profile.Load();
            NexusMods.Profile.Update();
            NexusMods.Profile.Save();
        }

        private void backgroundWorkerRetrieveProfileInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            RefreshNMUI();
        }

        #endregion

        private INIReadOnlyTweak iniReadOnlyTweak = new INIReadOnlyTweak();
        private AutoApplyTweak autoApplyTweak = new AutoApplyTweak();
        private IgnoreUpdatesTweak ignoreUpdatesTweak = new IgnoreUpdatesTweak();
        private PlayNotificationSoundsTweak playNotificationSoundsTweak = new PlayNotificationSoundsTweak();
        private ToolQuitOnLaunchTweak toolQuitOnLaunchTweak = new ToolQuitOnLaunchTweak();
    }
}
