using Fo76ini.Interface;
using Fo76ini.Profiles;
using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Fo76ini
{
    partial class Form1
    {
        public void OnLanguageChanged(object sender, TranslationEventArgs e)
        {
            Translation translation = (Translation)sender;

            // Set labels and stuff:
            this.labelOutdatedLanguage.Visible = translation.IsOutdated();

            this.labelTranslationAuthor.Visible = e.HasAuthor;
            this.labelTranslationBy.Visible = e.HasAuthor;
            this.labelTranslationAuthor.Text = e.HasAuthor ? translation.Author : "";

            this.RefreshNWModeButtonAppearance();
            this.CheckVersion();

            this.Refresh(); // Forces redraw
        }
        // TODO: FormMods needs OnLanguageChanged code.
        // formMods.UpdateUI(); // TODO: Changing the language before loading mods crashes the tool on startup.

        // TODO: Rewrite "Download / update language files" code
        private void buttonDownloadLanguages_Click(object sender, EventArgs e)
        {
            if (this.backgroundWorkerDownloadLanguages.IsBusy)
                return;
            this.groupBoxLocalization.Focus();
            this.buttonDownloadLanguages.Enabled = false;
            this.pictureBoxSpinnerDownloadLanguages.Visible = true;
            this.backgroundWorkerDownloadLanguages.RunWorkerAsync();
        }

        private string errorMessageDownloadLanguages = null;
        private string messageDownloadLanguages = null;
        private void backgroundWorkerDownloadLanguages_DoWork(object sender, DoWorkEventArgs e)
        {
            // Download / update languages:
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);

                byte[] raw = wc.DownloadData("https://raw.githubusercontent.com/FelisDiligens/Fallout76-QuickConfiguration/master/Fo76ini/languages/list.txt");
                string encoded = Encoding.UTF8.GetString(raw).Trim();

                string[] list = encoded.Split('\n', ',');

                foreach (string file in list)
                {
                    wc.DownloadFile("https://raw.githubusercontent.com/FelisDiligens/Fallout76-QuickConfiguration/master/Fo76ini/languages/" + file, Path.Combine(Localization.LanguageFolder, file));
                }

                errorMessageDownloadLanguages = null;
                messageDownloadLanguages = string.Join(", ", list);
                //MsgBox.Get("downloadLanguagesFinished").FormatText(String.Join(", ", list)).Popup(MessageBoxIcon.Information);
            }
            catch (WebException ex)
            {
                errorMessageDownloadLanguages = ex.ToString();
                messageDownloadLanguages = null;
                //MsgBox.Get("downloadLanguagesFailed").FormatText(ex.ToString()).Popup(MessageBoxIcon.Error);
            }
            catch
            {
                errorMessageDownloadLanguages = "Unknown error";
                messageDownloadLanguages = null;
                //MsgBox.Get("downloadLanguagesFailed").FormatText("Unknown error").Popup(MessageBoxIcon.Error);
            }
        }

        private void backgroundWorkerDownloadLanguages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (errorMessageDownloadLanguages != null)
                MsgBox.Get("downloadLanguagesFailed").FormatText(errorMessageDownloadLanguages).Popup(MessageBoxIcon.Error);
            else
                MsgBox.Get("downloadLanguagesFinished").FormatText(messageDownloadLanguages).Popup(MessageBoxIcon.Information);
            this.buttonDownloadLanguages.Enabled = true;
            this.pictureBoxSpinnerDownloadLanguages.Visible = false;
            Localization.LookupLanguages();
        }

        private void buttonRefreshLanguage_Click(object sender, EventArgs e)
        {
            // TODO
            Localization.LookupLanguages();
            this.RefreshNWModeButtonAppearance();
            this.CheckVersion();
            formMods.UpdateUI();
            this.Refresh();
            this.formMods.Refresh();
        }
    }
}
