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

                if (ProfileManager.SelectedGame != null)
                {
                    currentIniPrefix = ProfileManager.SelectedGame.IniPrefix;
                    if (ProfileManager.SelectedGame.ValidateGamePath())
                        currentGamePath = ProfileManager.SelectedGame.GamePath;
                }

                form.textBoxDebugText.Text = "*********** System information ***********\r\n" +
                                             $"Operating system:  {Utils.GetOSName()} {Utils.GetOSArchitecture()}\r\n" +
                                             $"Program version:   {Shared.VERSION}\r\n" +
                                             $"User agent:        {Shared.AppUserAgent}\r\n" +
                                             $"System locale:     {System.Globalization.CultureInfo.CurrentUICulture.Name}\r\n" +
                                             "\r\n"; /*+
                                             "************ Available files ************\r\n" +
                                             "config.ini:   " + (File.Exists(IniFiles.ConfigPath) ? "Yes" : "No") + "\r\n" +
                                             "profiles.xml: " + (File.Exists(ProfileManager.XMLPath) ? "Yes" : "No") + "\r\n";

                if (currentGamePath != null)
                {
                    form.textBoxDebugText.Text += "Mods\\managed.xml:   " + (File.Exists(Path.Combine(currentGamePath, "Mods", "managed.xml")) ? "Yes" : "No") + "\r\n" +
                                                  "Mods\\manifest.xml:  " + (File.Exists(Path.Combine(currentGamePath, "Mods", "manifest.xml")) ? "Yes" : "No") + "\r\n" +
                                                  "Mods\\resources.txt: " + (File.Exists(Path.Combine(currentGamePath, "Mods", "resources.txt")) ? "Yes" : "No") + "\r\n";
                }

                if (File.Exists(Path.Combine(IniFiles.ParentPath, $"Fallout76.ini")))
                    form.textBoxDebugText.Text += "Fallout76.ini\r\n";

                if (File.Exists(Path.Combine(IniFiles.ParentPath, $"Fallout76Prefs.ini")))
                    form.textBoxDebugText.Text += "Fallout76Prefs.ini\r\n";

                if (File.Exists(Path.Combine(IniFiles.ParentPath, $"Fallout76Custom.ini")))
                    form.textBoxDebugText.Text += "Fallout76Custom.ini\r\n";

                if (File.Exists(Path.Combine(IniFiles.ParentPath, $"Project76.ini")))
                    form.textBoxDebugText.Text += "Project76.ini\r\n";

                if (File.Exists(Path.Combine(IniFiles.ParentPath, $"Project76Prefs.ini")))
                    form.textBoxDebugText.Text += "Project76Prefs.ini\r\n";

                if (File.Exists(Path.Combine(IniFiles.ParentPath, $"Project76Custom.ini")))
                    form.textBoxDebugText.Text += "Project76Custom.ini\r\n";

                if (currentIniPrefix != "Fallout76" && currentIniPrefix != "Project76")
                {
                    form.textBoxDebugText.Text += $"{currentIniPrefix}.ini:       " + (File.Exists(Path.Combine(IniFiles.ParentPath, $"{currentIniPrefix}.ini")) ? "Yes" : "No") + "\r\n" +
                                                  $"{currentIniPrefix}Prefs.ini:  " + (File.Exists(Path.Combine(IniFiles.ParentPath, $"{currentIniPrefix}Prefs.ini")) ? "Yes" : "No") + "\r\n" +
                                                  $"{currentIniPrefix}Custom.ini: " + (File.Exists(Path.Combine(IniFiles.ParentPath, $"{currentIniPrefix}Custom.ini")) ? "Yes" : "No") + "\r\n";
                }*/

                /*form.textBoxDebugText.Text += "\r\n************* Game profiles *************";

                int gameIndex = 0;
                foreach (GameInstance game in ProfileManager.Games)
                {
                    form.textBoxDebugText.Text += $"\r\nProfile #{gameIndex}" + (ProfileManager.SelectedGameIndex == gameIndex ? " (selected)" : "") + "\r\n" +
                                                  $"   Edition:       {game.Edition}\r\n" +
                                                  $"   *.ini prefix:  {game.IniPrefix}\r\n" +
                                                  $"   Executable:    {game.ExecutableName}\r\n" +
                                                  $"   Game path:     " + (game.ValidateGamePath() ? "valid" : "invalid") + "\r\n" +
                                                  $"   Launch option: {game.PreferredLaunchOption}\r\n";

                    gameIndex++;
                }

                if (gameIndex == 0)
                    form.textBoxDebugText.Text += "\r\nNone or not loaded yet\r\n";

                form.textBoxDebugText.Text += "\r\n"; */
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
