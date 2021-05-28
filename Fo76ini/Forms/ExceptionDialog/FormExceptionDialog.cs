using Fo76ini.NexusAPI;
using Fo76ini.Profiles;
using Fo76ini.Utilities;
using System;
using System.IO;
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

        public static FormExceptionDialog OpenDialog(Exception ex)
        {
            FormExceptionDialog form = new FormExceptionDialog();

            try
            {
                string currentIniPrefix = "Fallout76";
                string currentGamePath = null;
                GameEdition currentGameEdition = GameEdition.Unknown;

                if (ProfileManager.SelectedGame != null)
                {
                    currentIniPrefix = ProfileManager.SelectedGame.IniPrefix;
                    if (ProfileManager.SelectedGame.ValidateGamePath())
                        currentGamePath = ProfileManager.SelectedGame.GamePath;
                    currentGameEdition = ProfileManager.SelectedGame.Edition;
                }

                form.textBoxDebugText.Text = $"Operating system:  {Utils.GetOSName()} {Utils.GetOSArchitecture()}\r\n" +
                                             $"Program version:   {Shared.VERSION}\r\n" +
                                             $"User agent:        {Shared.AppUserAgent}\r\n" +
                                             $"Running as admin:  " + (Utils.HasAdminRights() ? "Yes" : "No") + "\r\n" +
                                             $"Game edition:      {currentGameEdition}" +
                                             $"System locale:     {System.Globalization.CultureInfo.CurrentUICulture.Name}\r\n" +
                                             $"App locale:        {Localization.Locale}" +
                                             "\r\n";
            } 
            catch { }

            form.textBoxDebugText.Text += $"************** Stack trace **************\r\n" +
                                         $"If any files are listed (like \"D:\\Workspace\\...\\*.cs:line 123\"):\r\nThose are files on *my* computer, so don't worry if you can't find them.\r\n\r\n" +
                                         $"{ex.GetType()}: {ex.Message}\r\n{ex.StackTrace}\r\n";

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
