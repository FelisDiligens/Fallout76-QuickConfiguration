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

            // Make this form translatable:
            LocalizedForm form = new LocalizedForm(this, null);
            Localization.LocalizedForms.Add(form);
        }

        public DialogResult OpenDialog()
        {
            this.UpdatingUI = true;

            switch (ProfileManager.SelectedGame.Edition)
            {
                case GameEdition.Steam:
                    this.radioButtonEditionSteam.Checked = true;
                    break;
                case GameEdition.SteamPTS:
                    this.radioButtonEditionSteamPTS.Checked = true;
                    break;
                case GameEdition.Xbox:
                    this.radioButtonEditionMSStore.Checked = true;
                    break;
                default:
                    this.radioButtonEditionUnknown.Checked = true;
                    break;
            }

            this.textBoxGamePath.Text = ProfileManager.SelectedGame.GamePath;

            this.UpdatingUI = false;
            return this.ShowDialog();
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

        private void radioButtonEditionSteam_CheckedChanged(object sender, EventArgs e)
        {
            ProfileManager.SelectedGame.Edition = GameEdition.Steam;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.Steam);
            ProfileManager.SelectedGame.Title = "Steam";
        }

        private void radioButtonEditionSteamPTS_CheckedChanged(object sender, EventArgs e)
        {
            ProfileManager.SelectedGame.Edition = GameEdition.SteamPTS;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.SteamPTS);
            ProfileManager.SelectedGame.Title = "Steam (PTS)";
        }

        private void radioButtonEditionMSStore_CheckedChanged(object sender, EventArgs e)
        {
            ProfileManager.SelectedGame.Edition = GameEdition.Xbox;
            ProfileManager.SelectedGame.SetDefaultSettings(GameEdition.Xbox);
            ProfileManager.SelectedGame.Title = "Microsoft Store";
        }

        private void radioButtonEditionUnknown_CheckedChanged(object sender, EventArgs e)
        {
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
                //TextPrompt.Prompt("Found a path. Proceed?", foundPath, (newPath) => this.textBoxGamePath.Text = newPath);
                this.textBoxGamePath.Text = foundPath;
            else
                MsgBox.ShowID("gamePathAutoDetectFailed", MessageBoxIcon.Information);
        }
    }
}
