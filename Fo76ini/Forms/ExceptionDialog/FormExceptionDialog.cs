using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Forms.ExceptionDialog
{
    public partial class FormExceptionDialog : Form
    {
        public FormExceptionDialog()
        {
            InitializeComponent();

            this.FormClosing += this.FormExceptionDialog_FormClosing;
        }

        public static FormExceptionDialog OpenDialog (Exception ex)
        {
            FormExceptionDialog form = new FormExceptionDialog();

            try
            {
                form.textBoxDebugText.Text = $"Operating system:  {Utils.GetOSName()} {Utils.GetOSArchitecture()}\r\n" +
                                             $"Program version:   {Shared.VERSION}\r\n" +
                                             $"Program locale:    {Localization.locale}\r\n" +
                                             $"Game edition:      {Shared.GameEdition}\r\n" +
                                             "\r\n" +
                                             $"************** Exception Text **************\r\n{ex.GetType()}: {ex.Message}\r\n{ex.StackTrace}\r\n";
            }
            catch
            {
                form.textBoxDebugText.Text = $"************** Exception Text **************\r\n{ex.GetType()}: {ex.Message}\r\n{ex.StackTrace}\r\n";
            }

            form.ShowDialog();

            return form;
        }

        private void buttonCloseProgram_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonCopyText_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(this.textBoxDebugText.Text);
        }

        private void FormExceptionDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}
