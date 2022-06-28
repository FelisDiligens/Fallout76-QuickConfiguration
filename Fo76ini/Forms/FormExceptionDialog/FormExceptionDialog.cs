using Fo76ini.Profiles;
using Fo76ini.Utilities;
using System;
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

            //form.Text = $"{ex.GetType()}: {ex.Message}\r\n\r\n";
            form.textBoxDebugText.Text = $"*************** Error message ***************\r\n" +
                                         $"{ex.GetType()}: {ex.Message}\r\n\r\n";

            try
            {
                form.textBoxDebugText.Text += $"**************** System Info ****************\r\n" +
                                              $"Operating system:  {Utils.GetOSName()} {Utils.GetOSArchitecture()}\r\n" +
                                              $"Program version:   {Shared.VERSION}\r\n" +
                                              $"User agent:        {Shared.AppUserAgent}\r\n" +
                                              $"Running as admin:  " + (Utils.HasAdminRights() ? "Yes" : "No") + "\r\n" +
                                              $"System culture:    {System.Globalization.CultureInfo.CurrentUICulture.EnglishName}\r\n";
                                                                    /* InstalledUICulture, CurrentUICulture, CurrentCulture */
            }
            catch { }

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

                form.textBoxDebugText.Text += $"App locale:        {Localization.Locale}\r\n" +
                                              $"Game edition:      {currentGameEdition}\r\n";
            } 
            catch { }

            // Set culture to english, so the exceptions and stack traces are written in english:
            System.Globalization.CultureInfo originalCultureInfo = System.Globalization.CultureInfo.CurrentUICulture;
            System.Globalization.CultureInfo.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            // Print stack trace:
            form.textBoxDebugText.Text += $"\r\n**************** Stack Trace ****************\r\n" +
                                          $"If any files are listed (like \"at ... in ...\\*.cs:line 123\"):\r\nThose are files on *my* computer, so don't worry if you can't find them.\r\n\r\n" +
                                          $"{ex.GetType()}: {ex.Message}\r\n" +
                                          $"{GetStackTraceWithRelativePaths(ex.StackTrace)}\r\n";

            // Print stack traces of all inner exceptions:
            Exception innerEx = ex.InnerException;
            while (innerEx != null)
            {
                form.textBoxDebugText.Text += $"\r\n************** Inner Exception **************\r\n" +
                                              $"{innerEx.GetType()}: {innerEx.Message}\r\n" + 
                                              $"{GetStackTraceWithRelativePaths(innerEx.StackTrace)}\r\n";
                innerEx = innerEx.InnerException;
            }

            System.Globalization.CultureInfo.CurrentUICulture = originalCultureInfo;

            form.ShowDialog();

            return form;
        }

        private static string GetStackTraceWithRelativePaths(string stackTrace)
        {
            String projectBasePath = @"D:\Workspace\Fallout 76 Quick Configuration\Fallout76-QuickConfiguration\Fo76ini";
            if (stackTrace == null)
                return "";
            return stackTrace.Replace(projectBasePath, ".");
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
