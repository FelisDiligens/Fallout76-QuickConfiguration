using Fo76ini.Interface;
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
        public void ChangeLanguage(Form1 form1, FormMods formMods)
        {
            // Apply translation to forms:
            Translation translation = Localization.GetTranslation();
            translation.Apply();

            // Set labels and stuff:
            form1.labelOutdatedLanguage.Visible = translation.IsOutdated();

            form1.labelTranslationAuthor.Visible = false;
            form1.labelTranslationBy.Visible = false;
            if (translation.Author != "")
            {
                form1.labelTranslationAuthor.Visible = true;
                form1.labelTranslationBy.Visible = true;
                form1.labelTranslationAuthor.Text = translation.Author;
            }

            form1.RefreshNWModeButtonAppearance();
            form1.CheckVersion();
            // formMods.UpdateUI(); // TODO: Changing the language before loading mods crashes the tool on startup.

            // Force redraw:
            form1.Refresh();
            // formMods.Refresh();

            // Set sLanguage in config.ini:
            IniFiles.Config.Set("Preferences", "sLanguage", translation.ISO);
            Localization.locale = translation.ISO;

            if (translation.ISO != "en-US")
                Localization.GenerateTemplate(translation);
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangeLanguage(this, this.formMods);
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
                    wc.DownloadFile("https://raw.githubusercontent.com/FelisDiligens/Fallout76-QuickConfiguration/master/Fo76ini/languages/" + file, Path.Combine(Localization.languageFolder, file));
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
            Localization.LookupLanguages();
            this.RefreshNWModeButtonAppearance();
            this.CheckVersion();
            formMods.UpdateUI();
            this.Refresh();
            this.formMods.Refresh();
        }
    }
}
