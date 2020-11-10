using Fo76ini.Forms.FormTextPrompt;
using Fo76ini.Interface;
using Fo76ini.Profiles;
using Fo76ini.Utilities;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Fo76ini.Forms.FormProfiles
{
    public partial class FormProfiles : Form
    {
        private bool UpdatingUI = false;

        ProfileManager gameInstances;

        public FormProfiles()
        {
            InitializeComponent();

            this.listViewGameInstances.HeaderStyle = ColumnHeaderStyle.None;

            this.FormClosing += this.Form1_FormClosing;

            gameInstances = new ProfileManager();
            gameInstances.Load();
            UpdateUI();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                gameInstances.Save();
            }
        }

        private void UpdateUI ()
        {
            UpdatingUI = true;

            // For each managed game instance...
            this.listViewGameInstances.Items.Clear();
            foreach (GameInstance game in gameInstances.Games)
            {
                // ... add it to the list.
                ListViewItem gameItem = new ListViewItem(game.Title, GetImageIndex(game.Edition));
                this.listViewGameInstances.Items.Add(gameItem);

                // If it is the currently selected game, then...
                if (gameInstances.IsSelected(game))
                {
                    // ... select it in the list ...
                    gameItem.Selected = true;

                    // ... set the title of the window ...
                    this.Text = $"Profiles ({game.Title})";

                    // ... fill the list of profiles:
                    this.listBoxProfile.Items.Clear();
                    int i = 0;
                    foreach (Profile profile in game.Profiles)
                    {
                        this.listBoxProfile.Items.Add(profile.Name);
                        if (game.SelectedProfile.guid == profile.guid)
                            this.listBoxProfile.SelectedIndex = i;
                        i++;
                    }

                    // ... and update the settings:
                    this.radioButtonEditionBethesdaNet.Checked = game.Edition == GameEdition.BethesdaNet;
                    this.radioButtonEditionBethesdaNetPTS.Checked = game.Edition == GameEdition.BethesdaNetPTS;
                    this.radioButtonEditionSteam.Checked = game.Edition == GameEdition.Steam;
                    this.radioButtonEditionMSStore.Checked = game.Edition == GameEdition.MSStore;

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
                if (gameInstances.SelectedGameIndex != index)
                {
                    gameInstances.SelectedGameIndex = index;
                    UpdateUI();
                }
            }
        }

        private void listBoxProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            gameInstances.SelectedGame.SelectedProfileIndex = this.listBoxProfile.SelectedIndex;
            UpdateUI();
        }

        private void radioButtonEditionBethesdaNet_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            gameInstances.SelectedGame.Edition = GameEdition.BethesdaNet;
            gameInstances.SelectedGame.SetDefaultSettings(GameEdition.BethesdaNet);
            UpdateUI();
        }

        private void radioButtonEditionBethesdaNetPTS_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            gameInstances.SelectedGame.Edition = GameEdition.BethesdaNetPTS;
            gameInstances.SelectedGame.SetDefaultSettings(GameEdition.BethesdaNetPTS);
            UpdateUI();
        }

        private void radioButtonEditionSteam_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            gameInstances.SelectedGame.Edition = GameEdition.Steam;
            gameInstances.SelectedGame.SetDefaultSettings(GameEdition.Steam);
            UpdateUI();
        }

        private void radioButtonEditionMSStore_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            gameInstances.SelectedGame.Edition = GameEdition.MSStore;
            gameInstances.SelectedGame.SetDefaultSettings(GameEdition.MSStore);
            UpdateUI();
        }

        private void textBoxGamePath_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            gameInstances.SelectedGame.GamePath = this.textBoxGamePath.Text;
            this.textBoxGamePath.ForeColor = gameInstances.SelectedGame.ValidateGamePath() ? Color.Black : Color.Maroon;
        }

        private void radioButtonLaunchViaLink_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            gameInstances.SelectedGame.PreferredLaunchOption = LaunchOption.OpenURL;
        }

        private void radioButtonLaunchViaExecutable_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            gameInstances.SelectedGame.PreferredLaunchOption = LaunchOption.RunExec;
        }

        private void textBoxIniPrefix_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            gameInstances.SelectedGame.IniPrefix = this.textBoxIniPrefix.Text;
        }

        private void textBoxExecutable_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            gameInstances.SelectedGame.ExecutableName = this.textBoxExecutable.Text;
        }

        private void textBoxParameters_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            gameInstances.SelectedGame.ExecParameters = this.textBoxParameters.Text;
        }

        private void textBoxLaunchURL_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            gameInstances.SelectedGame.LauncherURL = this.textBoxLaunchURL.Text;
        }

        private void buttonPickGamePath_Click(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            this.openFileDialogGamePath.FileName = gameInstances.SelectedGame.ExecutableName;
            if (this.openFileDialogGamePath.ShowDialog() == DialogResult.OK)
            {
                string path = Path.GetDirectoryName(this.openFileDialogGamePath.FileName); // We want the path where Fallout76.exe resides.
                if (GameInstance.ValidateGamePath(path))
                {
                    this.textBoxGamePath.Text = path;
                    gameInstances.SelectedGame.GamePath = path;
                    UpdateUI();
                }
                else
                    MsgBox.ShowID("modsGamePathInvalid");
            }
        }

        private void AddNewGame()
        {
            GameInstance game = new GameInstance();
            this.gameInstances.AddGame(game);
            this.gameInstances.SelectGame(game);
        }

        private void AddNewProfile()
        {
            Profile profile = new Profile();
            profile.CopyINI();
            this.gameInstances.SelectedGame.AddProfile(profile);
            this.gameInstances.SelectedGame.SelectProfile(profile);
        }

        private void toolStripButtonAddGame_Click(object sender, EventArgs e)
        {
            AddNewGame();
            AddNewProfile();
            UpdateUI();
        }

        private void toolStripButtonAddProfile_Click(object sender, EventArgs e)
        {
            AddNewProfile();
            UpdateUI();
        }

        private void contextMenuStripGame_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.gameToolStripMenuItem.Text = gameInstances.SelectedGame.Title;
        }

        private void contextMenuStripProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.profileToolStripMenuItem.Text = gameInstances.SelectedGame.SelectedProfile.Name;
        }

        private void openFolderProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(gameInstances.SelectedGame.SelectedProfile.FolderPath);
        }

        private void renameProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String oldName = gameInstances.SelectedGame.SelectedProfile.Name;
            TextPrompt.Prompt($"Edit name of profile {oldName}", oldName, (newName) => {
                if (newName.Trim() != "")
                {
                    gameInstances.SelectedGame.SelectedProfile.Name = newName;
                    UpdateUI();
                }
            });
        }

        private void deleteProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameInstances.SelectedGame.Profiles.Count == 1)
            {
                MsgBox.Get("errorAtLeastOneGameOrProfile").Show(MessageBoxIcon.Error);
                return;
            }

            if (MsgBox.Get("deleteQuestion").FormatText(gameInstances.SelectedGame.SelectedProfile.Name).Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gameInstances.SelectedGame.SelectedProfile.DeleteFolder();
                gameInstances.SelectedGame.RemoveProfile(gameInstances.SelectedGame.SelectedProfile);
                gameInstances.SelectedGame.SelectedProfileIndex -= 1;
                UpdateUI();
            }
        }

        private void launchGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.gameInstances.SelectedGame.LaunchGame();
        }

        private void renameGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String oldName = gameInstances.SelectedGame.Title;
            TextPrompt.Prompt($"Edit title of game {oldName}", oldName, (newName) => {
                if (newName.Trim() != "")
                {
                    gameInstances.SelectedGame.Title = newName;
                    UpdateUI();
                }
            });
        }

        private void removeGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gameInstances.Games.Count == 1)
            {
                MsgBox.Get("errorAtLeastOneGameOrProfile").Show(MessageBoxIcon.Error);
                return;
            }

            if (MsgBox.Get("deleteQuestion").FormatText(gameInstances.SelectedGame.Title).Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gameInstances.SelectedGame.DeleteProfiles();
                gameInstances.RemoveGame(gameInstances.SelectedGame);
                gameInstances.SelectedGameIndex -= 1;
                UpdateUI();
            }
        }
    }
}
