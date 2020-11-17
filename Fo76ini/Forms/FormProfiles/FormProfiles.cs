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

        public FormProfiles()
        {
            InitializeComponent();

            // Make this form translatable:
            Localization.LocalizedForms.Add(new LocalizedForm(this, null));

            this.listViewGameInstances.HeaderStyle = ColumnHeaderStyle.None;

            this.FormClosing += this.Form1_FormClosing;

            UpdateUI();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ProfileManager.Save();
                ProfileManager.Feedback();
            }
        }

        private void UpdateUI ()
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
                if (ProfileManager.SelectedGameIndex != index)
                {
                    ProfileManager.SelectedGameIndex = index;
                    UpdateUI();
                }
            }
        }

        private void listBoxProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.SelectedProfileIndex = this.listBoxProfile.SelectedIndex;
            UpdateUI();
        }

        private void radioButtonEditionBethesdaNet_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.Edition = GameEdition.BethesdaNet;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.BethesdaNet);
            UpdateUI();
        }

        private void radioButtonEditionBethesdaNetPTS_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.Edition = GameEdition.BethesdaNetPTS;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.BethesdaNetPTS);
            UpdateUI();
        }

        private void radioButtonEditionSteam_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.Edition = GameEdition.Steam;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.Steam);
            UpdateUI();
        }

        private void radioButtonEditionMSStore_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.Edition = GameEdition.MSStore;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.MSStore);
            UpdateUI();
        }

        private void textBoxGamePath_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.GamePath = this.textBoxGamePath.Text;
            this.textBoxGamePath.ForeColor = ProfileManager.SelectedGame.ValidateGamePath() ? Color.Black : Color.Maroon;
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
                    UpdateUI();
                }
                else
                    MsgBox.ShowID("modsGamePathInvalid");
            }
        }

        private void AddNewGame()
        {
            GameInstance game = new GameInstance();
            ProfileManager.AddGame(game);
            ProfileManager.SelectGame(game);
        }

        private void AddNewProfile()
        {
            Profile profile = new Profile();
            profile.CopyINI();
            ProfileManager.SelectedGame.AddProfile(profile);
            ProfileManager.SelectedGame.SelectProfile(profile);
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
            this.gameToolStripMenuItem.Text = ProfileManager.SelectedGame.Title;
        }

        private void contextMenuStripProfile_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.profileToolStripMenuItem.Text = ProfileManager.SelectedGame.SelectedProfile.Name;
        }

        private void openFolderProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utils.OpenExplorer(ProfileManager.SelectedGame.SelectedProfile.FolderPath);
        }

        private void renameProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String oldName = ProfileManager.SelectedGame.SelectedProfile.Name;
            TextPrompt.Prompt($"Edit name of profile {oldName}", oldName, (newName) => {
                if (newName.Trim() != "")
                {
                    ProfileManager.SelectedGame.SelectedProfile.Name = newName;
                    UpdateUI();
                }
            });
        }

        private void deleteProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ProfileManager.SelectedGame.Profiles.Count == 1)
            {
                MsgBox.Get("errorAtLeastOneGameOrProfile").Show(MessageBoxIcon.Error);
                return;
            }

            if (MsgBox.Get("deleteQuestion").FormatText(ProfileManager.SelectedGame.SelectedProfile.Name).Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProfileManager.SelectedGame.SelectedProfile.DeleteFolder();
                ProfileManager.SelectedGame.RemoveProfile(ProfileManager.SelectedGame.SelectedProfile);
                ProfileManager.SelectedGame.SelectedProfileIndex -= 1;
                UpdateUI();
            }
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
                    UpdateUI();
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

            if (MsgBox.Get("deleteQuestion").FormatText(ProfileManager.SelectedGame.Title).Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProfileManager.SelectedGame.DeleteProfiles();
                ProfileManager.RemoveGame(ProfileManager.SelectedGame);
                ProfileManager.SelectedGameIndex -= 1;
                UpdateUI();
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
    }
}
