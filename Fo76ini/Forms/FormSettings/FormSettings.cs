using Fo76ini.Forms.FormTextPrompt;
using Fo76ini.Interface;
using Fo76ini.NexusAPI;
using Fo76ini.Profiles;
using Fo76ini.Properties;
using Fo76ini.Tweaks;
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
            this.listViewGameInstances.DoubleClick += listViewGameInstances_DoubleClick;

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
            if (Configuration.NexusMods.AutoUpdateProfile)
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
            this.textBoxArchiveTwoPath.Text = Configuration.Archive2Path;
            this.textBoxSevenZipPath.Text = Configuration.SevenZipPath;
            this.textBoxDownloadsPath.Text = Configuration.DownloadPath;
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

        #region Profiles

        private void UpdateGamesTab()
        {
            UpdatingUI = true;

            // For each managed game instance...
            this.listViewGameInstances.Items.Clear();
            foreach (GameInstance game in ProfileManager.Games)
            {
                bool isSelected = ProfileManager.IsSelected(game);

                // ... add it to the list.
                ListViewItem gameItem = new ListViewItem(
                    game.Title + (isSelected ? $" [{Localization.GetString("selected")}]" : ""),
                    GetImageIndex(game.Edition)
                );
                this.listViewGameInstances.Items.Add(gameItem);

                // If it is the currently selected game, then...
                if (isSelected)
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
                        case GameEdition.SteamPTS:
                            this.radioButtonEditionSteamPTS.Checked = true;
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
                case GameEdition.SteamPTS:
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

        private void radioButtonEditionSteamPTS_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.Edition = GameEdition.SteamPTS;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.SteamPTS);
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
                {
                    switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(steamDefaultPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            return steamDefaultPath;
                        case DialogResult.Cancel:
                            return null;
                    }
                }

                // Bethesda.net launcher - no longer in use
                /*
                string bethNetDefaultPath = Path.Combine(d.Name, @"Program Files (x86)\Bethesda.net Launcher\games\Fallout76");
                if (GameInstance.ValidateGamePath(bethNetDefaultPath))
                {
                    switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(bethNetDefaultPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            return bethNetDefaultPath;
                        case DialogResult.Cancel:
                            return null;
                    }
                }
                */

                // Old Xbox default path
                string xboxModifiablePath = Path.Combine(d.Name, @"Program Files\ModifiableWindowsApps\Fallout 76");
                if (GameInstance.ValidateGamePath(xboxModifiablePath))
                {
                    switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(xboxModifiablePath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            return xboxModifiablePath;
                        case DialogResult.Cancel:
                            return null;
                    }
                }

                // New Xbox default path
                string xboxDefaultPath = Path.Combine(d.Name, @"XboxGames\Fallout 76\Content");
                if (GameInstance.ValidateGamePath(xboxDefaultPath))
                {
                    switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(xboxDefaultPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            return xboxDefaultPath;
                        case DialogResult.Cancel:
                            return null;
                    }
                }

                // When you create a library on a drive through Steam's 
                string steamLibraryPath = Path.Combine(d.Name, @"SteamLibrary\steamapps\common\Fallout76");
                if (GameInstance.ValidateGamePath(steamLibraryPath))
                {
                    switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(steamLibraryPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            return steamLibraryPath;
                        case DialogResult.Cancel:
                            return null;
                    }
                }

                // Search every top-level folder on the drive:
                foreach (string path in Directory.EnumerateDirectories(d.Name))
                {
                    if (GameInstance.ValidateGamePath(path))
                    {
                        switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(path).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            case DialogResult.Yes:
                                return path;
                            case DialogResult.Cancel:
                                return null;
                        }
                    }

                    // Search for a steamapps folder:
                    string steamSubDirPath = Path.Combine(path, @"steamapps\common\Fallout76");
                    if (GameInstance.ValidateGamePath(steamSubDirPath))
                    {
                        switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(steamSubDirPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            case DialogResult.Yes:
                                return steamSubDirPath;
                            case DialogResult.Cancel:
                                return null;
                        }
                    }

                    // New Xbox path:
                    string xboxSubDirPath = Path.Combine(d.Name, @"Fallout 76\Content");
                    if (GameInstance.ValidateGamePath(xboxSubDirPath))
                    {
                        switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(xboxSubDirPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            case DialogResult.Yes:
                                return xboxSubDirPath;
                            case DialogResult.Cancel:
                                return null;
                        }
                    }
                }
            }

            return null;
        }

        private void buttonAutoDetect_Click(object sender, EventArgs e)
        {
            string foundPath = AutoDetectGamePath();
            if (foundPath != null)
                //TextPrompt.Prompt("Found a path. Proceed?", foundPath, (newPath) => this.textBoxGamePath.Text = newPath);
                this.textBoxGamePath.Text = foundPath;
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

        private void listViewGameInstances_DoubleClick(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            renameGameToolStripMenuItem_Click(sender, e);
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

        private void textBoxArchiveTwoPath_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            Configuration.Archive2Path = this.textBoxArchiveTwoPath.Text;
        }

        private void buttonPickArchiveTwoPath_Click(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            this.openFileDialogArchiveTwoPath.FileName = Archive2.DefaultArchive2Path;
            if (this.openFileDialogArchiveTwoPath.ShowDialog() == DialogResult.OK)
            {
                string path = this.openFileDialogArchiveTwoPath.FileName;
                this.textBoxArchiveTwoPath.Text = path;
                Configuration.Archive2Path = this.textBoxArchiveTwoPath.Text;
            }
        }

        private void textBoxSevenZipPath_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            Configuration.SevenZipPath = this.textBoxSevenZipPath.Text;
        }

        private void buttonPickSevenZipPath_Click(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            this.openFileDialogSevenZipPath.FileName = Utils.DefaultSevenZipPath;
            if (this.openFileDialogSevenZipPath.ShowDialog() == DialogResult.OK)
            {
                string path = this.openFileDialogSevenZipPath.FileName;
                this.textBoxSevenZipPath.Text = path;
                Configuration.SevenZipPath = this.textBoxSevenZipPath.Text;
            }
        }

        private void textBoxDownloadsPath_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
        }

        private void buttonPickDownloadsPath_Click(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            this.folderBrowserDialog.SelectedPath = Configuration.DefaultDownloadPath;
            if (this.folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string path = this.folderBrowserDialog.SelectedPath;
                this.textBoxDownloadsPath.Text = path;
                Configuration.DownloadPath = this.textBoxDownloadsPath.Text;
            }
        }
    }
}
