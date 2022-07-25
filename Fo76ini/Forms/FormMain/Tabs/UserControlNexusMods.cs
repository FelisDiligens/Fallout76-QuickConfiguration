using Fo76ini.Interface;
using Fo76ini.NexusAPI;
using Fo76ini.Properties;
using Fo76ini.Utilities;
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

namespace Fo76ini.Forms.FormMain.Tabs
{
    public partial class UserControlNexusMods : UserControl
    {
        public UserControlNexusMods()
        {
            InitializeComponent();

            if (this.DesignMode)
                return;

            // Handle translations:
            Translation.LanguageChanged += Translation_LanguageChanged;

            // Add control elements to blacklist:
            Translation.BlackList.AddRange(new string[] {
                "labelNMUserID",
                "labelNMHourlyRateLimit",
                "labelNMAPIKeyStatus",
                "labelNMUserName",
                "labelNMDailyRateLimitReset",
                "labelNMMembership",
                "labelNMDailyRateLimit"
            });

            SingleSignOn.SSOFinished += SingleSignOn_SSOFinished;

            this.labelNexusTitle.Font = new Font(CustomFonts.Overseer, 20, FontStyle.Regular);
        }

        private void Translation_LanguageChanged(object sender, TranslationEventArgs e)
        {
            Translation translation = (Translation)sender;

            if (translation.UsesNonLatinCharacters)
                this.labelNexusTitle.Font = new Font("Impact", 18, FontStyle.Regular);
            else
                this.labelNexusTitle.Font = new Font(CustomFonts.Overseer, 20, FontStyle.Regular);
        }

        private void UserControlNexusMods_Load(object sender, EventArgs e)
        {
            if (this.DesignMode)
                return;

            RefreshNMUI();
            if (Configuration.NexusMods.AutoUpdateProfile)
                UpdateNMProfile();
        }

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
            this.labelNMRateLimitReset.Visible = loggedIn;
            this.labelNMDescDailyRateLimit.Visible = loggedIn;
            this.labelNMDescHourlyRateLimit.Visible = loggedIn;
            this.labelNMDescLimitReset.Visible = loggedIn;
            this.labelNMDescMembership.Visible = loggedIn;
            this.labelNMDescUserID.Visible = loggedIn;
            this.labelNMMembership.Visible = loggedIn;
            this.labelNMUserID.Visible = loggedIn;

            this.linkLabelEnableAPIKey.Visible = !APIKeyTextboxEnabled && !loggedIn;


            /*
             * Visiblility of buttons:
             */

            this.buttonNMLogin.Visible = !loggedIn;
            this.buttonNMLoginManually.Visible = !loggedIn && APIKeyTextboxEnabled;
            this.buttonNWLogout.Visible = loggedIn;
            this.buttonNMUpdateProfile.Visible = loggedIn;
            // this.buttonNWDeleteCache.Visible = true;


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

            DateTime hourlyRateLimitReset;
            if (NexusMods.User.HourlyRateLimitResetString != "" &&
                NexusMods.User.TryParseHourlyRateLimitReset(out hourlyRateLimitReset))
            {
                TimeSpan diff = hourlyRateLimitReset - DateTime.Now;
                if (diff.TotalSeconds <= 0)
                    this.labelNMRateLimitReset.Text = string.Format(Localization.GetString("nmResetTime"), "0", "0");
                else
                    this.labelNMRateLimitReset.Text = string.Format(Localization.GetString("nmResetTime"), diff.Hours, diff.Minutes);
            }
            else
            {
                this.labelNMRateLimitReset.Text = Localization.GetString("unknown");
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

            this.checkBoxNMUpdateProfile.Checked = Configuration.NexusMods.AutoUpdateProfile;
            //this.checkBoxNMUpdateModInfo.Checked = IniFiles.Instance.GetBool(IniFile.Config, "NexusMods", "bAutoUpdateModInfo", false);
            this.checkBoxNMDownloadThumbnails.Checked = Configuration.NexusMods.DownloadThumbnailsOnUpdate;
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
            this.Invoke(new Action(() => {
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
                Utils.OpenURL("https://www.nexusmods.com/users/" + NexusMods.User.UserID);
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
            Utils.OpenURL(Shared.URLs.AppNexusLoginFailedHelpURL);
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
    }
}
