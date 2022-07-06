using Fo76ini.Forms.FormTextPrompt;
using Fo76ini.Interface;
using Fo76ini.NexusAPI;
using Fo76ini.Profiles;
using Fo76ini.Tweaks;
using Fo76ini.Utilities;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Fo76ini.Forms.FormSettings
{
    public partial class FormSettings : Form
    {
        private bool UpdatingUI = false;

        public static bool DangerZoneEnabled = false;

        public FormSettings()
        {
            InitializeComponent();

            // Make this form translatable:
            LocalizedForm form = new LocalizedForm(this, this.toolTip);
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


            // Init components / assign event handler:
            this.backgroundWorkerDownloadLanguages.RunWorkerCompleted += backgroundWorkerDownloadLanguages_RunWorkerCompleted;
            this.backgroundWorkerRetrieveProfileInfo.RunWorkerCompleted += backgroundWorkerRetrieveProfileInfo_RunWorkerCompleted;
            this.FormClosing += FormSettings_FormClosing;

            //SingleSignOn.SSOFinished += SingleSignOn_SSOFinished;
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            LinkedTweaks.LoadValues();
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
            this.openFileDialogSevenZipPath.FileName = SevenZip.DefaultExecPath;
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

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.InitialDirectory = Configuration.DefaultDownloadPath;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string path = dialog.FileName;
                this.textBoxDownloadsPath.Text = path;
                Configuration.DownloadPath = this.textBoxDownloadsPath.Text;
            }
            this.Focus();
        }
    }
}
