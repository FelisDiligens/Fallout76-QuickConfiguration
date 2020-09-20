using Fo76ini.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini
{
    public partial class FormMods : Form
    {
        private void InitializeNMControls()
        {
            this.backgroundWorkerRetrieveModInfo.ProgressChanged += backgroundWorkerRetrieveModInfo_ProgressChanged;
            this.backgroundWorkerRetrieveModInfo.RunWorkerCompleted += backgroundWorkerRetrieveModInfo_RunWorkerCompleted;

            this.backgroundWorkerRetrieveProfileInfo.RunWorkerCompleted += backgroundWorkerRetrieveProfileInfo_RunWorkerCompleted;
        }

        /*
         * Interface:
         */

        public void UpdateNMProfile()
        {
            this.textBoxAPIKey.Text = NexusMods.Profile.APIKey;

            this.labelNMUserName.Text = NexusMods.Profile.UserName;
            
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

            this.labelNMDailyRateLimit.Text = String.Format(Localization.GetString("nmRateLimitLeft"), NexusMods.Profile.DailyRateLimit);
            if (NexusMods.Profile.DailyRateLimitResetString != "")
            {
                TimeSpan diff = NexusMods.Profile.DailyRateLimitReset - DateTime.Now;
                this.labelNMDailyRateLimitReset.Text = String.Format(Localization.GetString("nmResetTime"), diff.Hours, diff.Minutes);
            }
            else
            {
                this.labelNMDailyRateLimitReset.Text = Localization.GetString("nmResetTimeNever");
            }

            this.pictureBoxNMProfilePicture.Image = Resources.user_white;
            if (NexusMods.Profile.ProfilePicture != null)
            {
                String profilePicPath = Path.Combine(Shared.AppConfigFolder, NexusMods.Profile.ProfilePicture);
                if (File.Exists(profilePicPath))
                    this.pictureBoxNMProfilePicture.Image = Image.FromFile(profilePicPath);
            }
        }

        /*
         * Event handler:
         */

        // API Key:
        private void textBoxAPIKey_TextChanged(object sender, EventArgs e)
        {
            IniFiles.Instance.Set(IniFile.Config, "NexusMods", "sAPIKey", this.textBoxAPIKey.Text);
            IniFiles.Instance.SaveConfig();
            NexusMods.Profile.APIKey = this.textBoxAPIKey.Text;
        }

        private void buttonNMUpdateProfile_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorkerRetrieveProfileInfo.IsBusy)
                return;
            this.pictureBoxNMProfilePicture.Image = Resources.Spinner_200;
            this.backgroundWorkerRetrieveProfileInfo.RunWorkerAsync();
        }

        private void buttonNMUpdateModInfo_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorkerRetrieveModInfo.IsBusy)
                return;
            this.backgroundWorkerRetrieveModInfo.RunWorkerAsync();
        }

        private void linkLabelNMGetAPIKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelNMGetAPIKey.LinkVisited = true;
            System.Diagnostics.Process.Start("https://www.nexusmods.com/users/myaccount?tab=api%20access");
        }

        private void buttonNMDeleteThumbnails_Click(object sender, EventArgs e)
        {
            if (MsgBox.Get("nexusModsDeleteThumbnails").Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    String path = Path.Combine(Shared.GamePath, "Mods", "_thumbs");
                    if (Directory.Exists(path))
                        Directory.Delete(path, true);
                    MsgBox.Get("nexusModsDeleteThumbnailsSuccess").Popup(MessageBoxIcon.Information);
                }
                catch
                {
                    MsgBox.Get("nexusModsDeleteThumbnailsFailed").Popup(MessageBoxIcon.Error);
                }
            }
        }

        private void buttonNMRemoveAll_Click(object sender, EventArgs e)
        {
            if (MsgBox.Get("nexusModsRemoveProfile").Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.pictureBoxNMProfilePicture.Image = Resources.user_white;
                this.textBoxAPIKey.Text = "";
                NexusMods.Profile.Remove();
                UpdateNMProfile();
                MsgBox.Get("nexusModsRemoveProfileSuccess").Popup(MessageBoxIcon.Information);
            }
        }

        private void checkBoxShowAPIKey_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxAPIKey.UseSystemPasswordChar = !this.checkBoxShowAPIKey.Checked;
            this.textBoxAPIKey.PasswordChar = !this.checkBoxShowAPIKey.Checked ? '\u2022' : '\0';
        }

        private void buttonNMDeleteModInfo_Click(object sender, EventArgs e)
        {
            if (MsgBox.Get("nexusModsRemoveRemoteInfo").Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                NexusMods.ClearRemoteInfo();
                this.UpdateModList();
                MsgBox.Get("nexusModsRemoveRemoteInfoSuccess").Popup(MessageBoxIcon.Information);
            }
        }

        /*
         * Background worker:
         */

        // Retrieve mod info:

        private void backgroundWorkerRetrieveModInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 1;
            int len = ManagedMods.Instance.Mods.Count();
            foreach (Mod mod in ManagedMods.Instance.Mods)
            {
                if (mod.URL != "")
                {
                    this.backgroundWorkerRetrieveModInfo.ReportProgress((int)((float)i / (float)len * 100f), $"[{i}/{len}] Requesting info for \"{mod.Title}\"");
                    NexusMods.RefreshModInfo(mod.URL);
                }
                i++;
            }
            NexusMods.Save();
        }

        private void backgroundWorkerRetrieveModInfo_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.ProgressBarContinuous(e.ProgressPercentage);
            this.Display((String)e.UserState);
        }

        private void backgroundWorkerRetrieveModInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.UpdateModList();
            this.ProgressBarContinuous(100);
            this.DisplayAllDone();

            if (!this.backgroundWorkerRetrieveModInfo.IsBusy)
                this.backgroundWorkerRetrieveProfileInfo.RunWorkerAsync();

            MsgBox.Get("nexusModsRemoteInfoRefreshedSuccess").Popup();
        }

        // Retrieve profile info:

        private void backgroundWorkerRetrieveProfileInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            NexusMods.Profile.Load();
            NexusMods.Profile.Update();
            NexusMods.Profile.Save();
        }

        private void backgroundWorkerRetrieveProfileInfo_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateNMProfile();
        }
    }
}
