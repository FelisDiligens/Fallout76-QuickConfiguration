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
            /*if (this.backgroundWorkerDownloadLanguages.IsBusy)
                return;
            this.groupBoxLocalization.Focus();
            this.buttonDownloadLanguages.Enabled = false;
            this.pictureBoxSpinnerDownloadLanguages.Visible = true;
            this.backgroundWorkerDownloadLanguages.RunWorkerAsync();*/
        }
    }
}
