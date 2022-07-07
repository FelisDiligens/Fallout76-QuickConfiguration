using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComboxExtended;
using Fo76ini.Interface;
using Fo76ini.Profiles;
using Fo76ini.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using Fo76ini;
using Fo76ini.Ini;
using Fo76ini.Forms.FormIniError;
using Fo76ini.Forms.FormWelcome;
using Fo76ini.Tweaks;
using Fo76ini.Utilities;

namespace Fo76ini.Forms.FormMain.Tabs
{
    public partial class UserControlProfiles : UserControl
    {
        bool UpdatingUI = false;

        public UserControlProfiles()
        {
            InitializeComponent();

            HideTabHeader();

            this.comboBoxGameEdition.Items.Add(new ComboBoxItem("Steam", Resources.steam_24px));
            this.comboBoxGameEdition.Items.Add(new ComboBoxItem("Steam (PTS)", Resources.steam_24px));
            this.comboBoxGameEdition.Items.Add(new ComboBoxItem("Xbox", Resources.xbox_24));
            this.comboBoxGameEdition.Items.Add(new ComboBoxItem("Other", Resources.help_24));
            this.comboBoxGameEdition.Items.Add(new ComboBoxItem("---"));
            this.comboBoxGameEdition.Items.Add(new ComboBoxItem("Bethesda.net Launcher (deprecated)", Resources.bethesda_24));
            this.comboBoxGameEdition.Items.Add(new ComboBoxItem("Bethesda.net Launcher - PTS (deprecated)", Resources.bethesda_24));

            this.Size = new Size(800, 600);

            this.listViewGameInstances.HeaderStyle = ColumnHeaderStyle.None;

            this.panelAdvancedOptions.Visible = false;

            ProfileManager.ProfileChanged += OnProfileChanged;

            this.labelSelectTitle.Font = new Font(CustomFonts.Overseer, 20, FontStyle.Regular);
            this.labelEditTitle.Font = new Font(CustomFonts.Overseer, 20, FontStyle.Regular);
        }

        private void OnProfileChanged(object sender, ProfileEventArgs e)
        {
            UpdateList();
        }

        private void HideTabHeader()
        {
            // https://stackoverflow.com/a/10346520
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
            tabControl.TabStop = false;
        }

        private void UpdateList()
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
                }
            }

            UpdatingUI = false;
        }

        private void UpdateEditingScreen()
        {
            UpdatingUI = true;

            GameInstance game = ProfileManager.SelectedGame;

            this.textBoxProfileName.Text = game.Title;

            switch (game.Edition)
            {
                case GameEdition.Steam:
                    this.comboBoxGameEdition.SelectedIndex = 0;
                    break;
                case GameEdition.SteamPTS:
                    this.comboBoxGameEdition.SelectedIndex = 1;
                    break;
                case GameEdition.Xbox:
                    this.comboBoxGameEdition.SelectedIndex = 2;
                    break;
                case GameEdition.BethesdaNet:
                    this.comboBoxGameEdition.SelectedIndex = 5;
                    break;
                case GameEdition.BethesdaNetPTS:
                    this.comboBoxGameEdition.SelectedIndex = 6;
                    break;
                default:
                    this.comboBoxGameEdition.SelectedIndex = 3;
                    break;
            }

            this.radioButtonLaunchViaLink.Checked = game.PreferredLaunchOption == LaunchOption.OpenURL;
            this.radioButtonLaunchViaExecutable.Checked = game.PreferredLaunchOption == LaunchOption.RunExec;

            this.textBoxGamePath.Text = game.GamePath;
            this.textBoxExecutable.Text = game.ExecutableName;
            this.textBoxIniPrefix.Text = game.IniPrefix;
            this.textBoxParameters.Text = game.ExecParameters;
            this.textBoxLaunchURL.Text = game.LauncherURL;

            this.labelLaunchOptionMSStoreNotice.Visible =
                game.Edition == GameEdition.Xbox &&
                game.PreferredLaunchOption == LaunchOption.RunExec;

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
                case GameEdition.Xbox:
                    return 3;
                default:
                    return 0;
            }
        }

        /*
         * Event handler for the selection screen
         */

        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            UpdateEditingScreen();
            this.tabControl.SelectedTab = this.tabPageEdit;
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
                    ProfileManager.Save();
                    UpdateList();
                }
            }
        }

        private void buttonAddProfile_Click(object sender, EventArgs e)
        {
            GameInstance game = new GameInstance();
            ProfileManager.AddGame(game);
            ProfileManager.SelectGame(game);
            UpdateList();
        }

        private void buttonDeleteProfile_Click(object sender, EventArgs e)
        {
            // At least one profile:
            if (ProfileManager.Count == 1)
            {
                MsgBox.Get("errorAtLeastOneGameOrProfile").Show(MessageBoxIcon.Error);
                return;
            }

            // "You sure?"
            if (MsgBox.Get("deleteQuestion")
                .FormatTitle(ProfileManager.SelectedGame.Title)
                .FormatText(ProfileManager.SelectedGame.Title)
                .Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProfileManager.RemoveGame(ProfileManager.SelectedGame);
                ProfileManager.SelectedGameIndex -= 1;
                UpdateList();
            }
        }


        /*
         * Event handler for the editing screen
         */

        private void linkLabelNavigationBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.tabControl.SelectedTab = this.tabPageSelect;
            ProfileManager.Save();
            ProfileManager.Feedback();
            UpdateList();
        }

        /* Profile */
        private void textBoxProfileName_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            string newName = this.textBoxProfileName.Text;
            if (newName.Trim() == "")
                ProfileManager.SelectedGame.Title = "Untitled";
            else
                ProfileManager.SelectedGame.Title = newName;
            UpdateList();
        }

        /* Game edition */
        #region Game edition

        private void comboBoxGameEdition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;

            GameEdition edition = GameEdition.Unknown;

            switch (this.comboBoxGameEdition.SelectedIndex)
            {
                case 0:
                    edition = GameEdition.Steam;
                    break;
                case 1:
                    edition = GameEdition.SteamPTS;
                    break;
                case 2:
                    edition = GameEdition.Xbox;
                    break;
                case 5:
                    edition = GameEdition.BethesdaNet;
                    break;
                case 6:
                    edition = GameEdition.BethesdaNetPTS;
                    break;
            }
            ProfileManager.SelectedGame.Edition = edition;
            ProfileManager.SelectedGame.SetDefaultSettings(edition);

            UpdateEditingScreen();
        }

        #endregion


        /* Game location */
        #region Game location

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

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string path = dialog.FileName; // We want the path where Fallout76.exe resides.
                if (GameInstance.ValidateGamePath(path))
                {
                    this.textBoxGamePath.Text = path;
                    ProfileManager.SelectedGame.GamePath = path;
                    UpdateEditingScreen();
                }
                else
                    MsgBox.ShowID("modsGamePathInvalid");
            }
            this.Focus();
        }

        private void linkLabelAutoDetect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string foundPath = GameInstance.AutoDetectGamePath();
            if (foundPath != null)
                this.textBoxGamePath.Text = foundPath;
            else
                MsgBox.ShowID("gamePathAutoDetectFailed", MessageBoxIcon.Information);
        }

        #endregion


        /* Launch options */
        #region Launch options

        private void radioButtonLaunchViaLink_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.PreferredLaunchOption = LaunchOption.OpenURL;

            this.labelLaunchOptionMSStoreNotice.Visible = false;
        }

        private void radioButtonLaunchViaExecutable_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.PreferredLaunchOption = LaunchOption.RunExec;

            this.labelLaunchOptionMSStoreNotice.Visible =
                ProfileManager.SelectedGame.Edition == GameEdition.Xbox &&
                ProfileManager.SelectedGame.PreferredLaunchOption == LaunchOption.RunExec;
        }

        #endregion


        /* Advanced options */
        #region Advanced options

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

        #endregion


        private void checkBoxMoreOptions_CheckedChanged(object sender, EventArgs e)
        {
            this.panelAdvancedOptions.Visible = checkBoxMoreOptions.Checked;
        }
    }
}
