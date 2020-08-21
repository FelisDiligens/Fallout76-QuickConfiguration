using IniParser.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Fo76ini
{
    partial class Form1
    {
        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Translation translation = Localization.GetTranslation();
            Localization.ChangeLanguage(translation, this, this.formMods);
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

        private String errorMessageDownloadLanguages = null;
        private String messageDownloadLanguages = null;
        private void backgroundWorkerDownloadLanguages_DoWork(object sender, DoWorkEventArgs e)
        {
            // Download / update languages:
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);

                byte[] raw = wc.DownloadData("https://raw.githubusercontent.com/FelisDiligens/Fallout76-QuickConfiguration/master/Fo76ini/languages/list.txt");
                String encoded = Encoding.UTF8.GetString(raw).Trim();

                String[] list = encoded.Split('\n', ',');

                foreach (String file in list)
                {
                    wc.DownloadFile("https://raw.githubusercontent.com/FelisDiligens/Fallout76-QuickConfiguration/master/Fo76ini/languages/" + file, Path.Combine(Localization.languageFolder, file));
                }

                errorMessageDownloadLanguages = null;
                messageDownloadLanguages = String.Join(", ", list);
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
    }
}
