using Fo76ini.Ini;
using Fo76ini.Interface;
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

namespace Fo76ini.Forms.FormIniError
{
    public partial class FormIniError : Form
    {
        IniParsingException Exception;

        public FormIniError()
        {
            InitializeComponent();

            this.FormClosing += FormIniError_FormClosing;
        }

        public static DialogResult OpenDialog(IniParsingException exc)
        {
            FormIniError form = new FormIniError();
            form.Exception = exc;

            form.labelErrorMessage.Text = exc.Message;
            form.labelFileName.Text = exc.FileName;
            form.labelLineNumber.Text = exc.LineNumber.ToString();

            // Fill rich text box:
            StreamReader reader = File.OpenText(exc.FilePath);
            int lineNumber = 0;
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                if (line == null)
                    break;
                lineNumber++;

                string lineNumStr = $"{lineNumber} ".PadLeft(4);
                if (lineNumber == exc.LineNumber)
                {
                    form.richTextBox.AppendRichText(lineNumStr, false, Color.Red);
                    form.richTextBox.AppendRichText(line.PadRight(48), true, Color.White, Color.Red);
                }
                else if (Math.Abs(lineNumber - exc.LineNumber) <= 3)
                {
                    form.richTextBox.AppendRichText(lineNumStr, false, Color.FromArgb(120, 120, 120));
                    form.richTextBox.AppendRichText(line, true);
                }
            }
            reader.Close();

            form.HideDetails();

            return form.ShowDialog();
        }

        private void buttonResetFile_Click(object sender, EventArgs e)
        {
            DialogResult result = MsgBox.Show("Warning", "This will reset (some if not all) of your settings.\nAre you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            
            if (result == DialogResult.Yes)
            {
                // Reset Fallout76Prefs.ini:
                if (Exception.FileName.EndsWith("Prefs.ini"))
                {
                    File.Copy(
                        IniFiles.DefaultF76PrefsPath,
                        Exception.FilePath,
                        true
                    );
                }

                // Delete Fallout76Custom.ini:
                else if (Exception.FileName.EndsWith("Custom.ini"))
                {
                    File.Delete(Exception.FilePath);
                }

                // Reset Fallout76.ini:
                else
                {
                    File.Copy(
                        IniFiles.DefaultF76Path,
                        Exception.FilePath,
                        true
                    );
                }

                this.DialogResult = DialogResult.Ignore;
            }
        }

        private void buttonOpenEditor_Click(object sender, EventArgs e)
        {
            Utils.OpenFile(Exception.FilePath);
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            // this.DialogResult = DialogResult.Abort;
            // Application.Exit(); // Doesn't immediately terminate program.
            Environment.Exit(Exception.HResult); // Does immediately terminate program.
        }

        private void buttonTryAgain_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
        }

        private void linkLabelShowHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // TODO: New wiki page
            Utils.OpenURL("https://github.com/FelisDiligens/Fallout76-QuickConfiguration/wiki/Troubleshooting#couldnt-parse-ini-files-error-message-on-start");
        }

        private void buttonToggleDetails_Click(object sender, EventArgs e)
        {
            if (this.panelDetails.Visible)
                HideDetails();
            else
                ShowDetails();
        }

        private void FormIniError_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Environment.Exit(Exception.HResult);
            }
        }

        private void ShowDetails()
        {
            this.panelDetails.Visible = true;
            this.buttonToggleDetails.Text = "/\\ Hide details";
            this.Height = this.panelDetails.Top + this.panelDetails.Height + 38;
            this.Top -= 200;
        }

        private void HideDetails()
        {
            this.panelDetails.Visible = false;
            this.buttonToggleDetails.Text = "\\/ Show details";
            this.Height = this.panelDetails.Top + 38;
            this.Top += 200;
        }
    }
}
