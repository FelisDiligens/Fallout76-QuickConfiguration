using System;
using System.ComponentModel;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace Fo76ini.Forms.FormWhatsNew
{
    public partial class FormWhatsNew : Form
    {
        public FormWhatsNew()
        {
            InitializeComponent();

            // Make this form translatable:
            Localization.LocalizedForms.Add(new LocalizedForm(this, null));

            Translation.BlackList.AddRange(new string[] {
                "richTextBox"
            });

            this.FormClosing += this.Form1_FormClosing;
            this.backgroundWorkerDownloadRTF.RunWorkerCompleted += backgroundWorkerDownloadRTF_RunWorkerCompleted;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                this.Hide();
        }

        private void FormWhatsNew_Load(object sender, EventArgs e)
        {
            if (IniFiles.Config.Exists("Debug", "sWhatsNewFilePath"))
                richTextBox.LoadFile(IniFiles.Config.GetString("Debug", "sWhatsNewFilePath"));
            else
                this.backgroundWorkerDownloadRTF.RunWorkerAsync();
        }

        private void backgroundWorkerDownloadRTF_DoWork(object sender, DoWorkEventArgs ev)
        {
            try
            {
                WebClient wc = new WebClient();
                byte[] raw = wc.DownloadData("https://raw.githubusercontent.com/FelisDiligens/Fallout76-QuickConfiguration/master/What's%20new.rtf");
                ev.Result = (object)Encoding.UTF8.GetString(raw).Trim();
            }
            catch (Exception ex)
            {
                ev.Result = (object)$"{{\\rtf1Couldn't retrieve 'What's new.rtf': \"{ex.GetType().Name}: {ex.Message}\"}}";
            }
        }

        private void backgroundWorkerDownloadRTF_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            richTextBox.Rtf = (string)e.Result;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void checkBoxDontShowAgain_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Config.Set("Preferences", "bDisableWhatsNew", this.checkBoxDontShowAgain.Checked);
            IniFiles.Config.Save();
        }
    }
}
