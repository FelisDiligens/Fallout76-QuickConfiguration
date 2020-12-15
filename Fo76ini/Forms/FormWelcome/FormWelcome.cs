using Fo76ini.Forms.FormTextPrompt;
using Fo76ini.Interface;
using Fo76ini.Profiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Forms.FormWelcome
{
    public partial class FormWelcome : Form
    {
        private bool UpdatingUI = false;

        public FormWelcome()
        {
            InitializeComponent();
            this.FormClosing += FormWelcome_FormClosing;
        }

        public static DialogResult OpenDialog()
        {
            FormWelcome form = new FormWelcome();
            form.UpdatingUI = true;

            switch (ProfileManager.SelectedGame.Edition)
            {
                case GameEdition.BethesdaNet:
                    form.radioButtonEditionBethesdaNet.Checked = true;
                    break;
                case GameEdition.BethesdaNetPTS:
                    form.radioButtonEditionBethesdaNetPTS.Checked = true;
                    break;
                case GameEdition.Steam:
                    form.radioButtonEditionSteam.Checked = true;
                    break;
                case GameEdition.MSStore:
                    form.radioButtonEditionMSStore.Checked = true;
                    break;
                default:
                    form.radioButtonEditionUnknown.Checked = true;
                    break;
            }

            form.textBoxGamePath.Text = ProfileManager.SelectedGame.GamePath;

            form.UpdatingUI = false;
            return form.ShowDialog();
        }

        private void FormWelcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                ProfileManager.Save();
                ProfileManager.Feedback();
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            ProfileManager.Save();
            ProfileManager.Feedback();
            this.DialogResult = DialogResult.OK;
        }

        private void radioButtonEditionBethesdaNet_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.Edition = GameEdition.BethesdaNet;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.BethesdaNet);
            ProfileManager.SelectedGame.Title = "Bethesda.net";
        }

        private void radioButtonEditionBethesdaNetPTS_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.Edition = GameEdition.BethesdaNetPTS;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.BethesdaNetPTS);
            ProfileManager.SelectedGame.Title = "Bethesda.net (PTS)";
        }

        private void radioButtonEditionSteam_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.Edition = GameEdition.Steam;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.Steam);
            ProfileManager.SelectedGame.Title = "Steam";
        }

        private void radioButtonEditionMSStore_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.Edition = GameEdition.MSStore;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.MSStore);
            ProfileManager.SelectedGame.Title = "Microsoft Store";
        }

        private void radioButtonEditionUnknown_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.Edition = GameEdition.Unknown;
            ProfileManager.SelectedGame.Title = "Unknown";
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
                    this.textBoxGamePath.Text = path;
                else
                    MsgBox.ShowID("modsGamePathInvalid");
            }
        }

        private void buttonAutoDetect_Click(object sender, EventArgs e)
        {
            string foundPath = FormSettings.FormSettings.AutoDetectGamePath();
            if (foundPath != null)
                TextPrompt.Prompt("Found a path. Proceed?", foundPath, (newPath) => this.textBoxGamePath.Text = newPath);
            else
                MsgBox.ShowID("gamePathAutoDetectFailed", MessageBoxIcon.Information);
        }
    }
}
