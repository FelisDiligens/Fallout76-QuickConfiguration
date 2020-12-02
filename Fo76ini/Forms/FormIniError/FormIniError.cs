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

            return form.ShowDialog();
        }

        private void buttonResetFile_Click(object sender, EventArgs e)
        {
            MsgBox.Show("Warning", "This will reset (some if not all) of your settings.\nAre you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            // TODO: Reset *.ini file
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
            Utils.OpenURL("https://github.com/FelisDiligens/Fallout76-QuickConfiguration/wiki/Troubleshooting#couldnt-parse-ini-files-error-message-on-start");
        }
    }
}
