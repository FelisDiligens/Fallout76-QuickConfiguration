using Fo76ini.Forms.ExceptionDialog;
using Fo76ini.Forms.FormProfiles;
using Fo76ini.Interface;
using Fo76ini.NexusAPI;
using Fo76ini.Profiles;
using Fo76ini.Utilities;
using System;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace Fo76ini
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // https://stackoverflow.com/questions/2859790/the-request-was-aborted-could-not-create-ssl-tls-secure-channel
            // On Windows 7, the API request would fail with this error message:
            // WebException: "The request was aborted: Could not create SSL/TLS secure channel"
            // Adding these lines fixes it:
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            /*
             * Handle NXM links:
             */
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && args[1].StartsWith("nxm://"))
            {
                File.WriteAllText(Path.Combine(Shared.AppConfigFolder, "nxm.txt"), args[1]);

                // If the tool already runs, then just quit:
                if (Utils.IsProcessRunning("Fo76ini"))
                    return;
                // if it doesn't, we'll open the mod manager later in Form1.cs.
            }

            // The program should only run once:
            if (Utils.IsProcessRunning("Fo76ini"))
            {
                MsgBox.Show("Program already runs", "An instance of this program already runs. Exiting...", MessageBoxIcon.Error);
                return;
            }

            Application.ThreadException += new ThreadExceptionEventHandler(HandleThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleUnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            /*
             * Preparing to launch app:
             */

            // Create folders, if not present:
            Directory.CreateDirectory(Shared.AppConfigFolder);
            Directory.CreateDirectory(Shared.AppTranslationsFolder);
            Directory.CreateDirectory(IniFiles.ParentPath);

            // Load config.ini:
            IniFiles.LoadConfig();

            // Load game profiles:
            ProfileManager.Load();

            // Load NexusMods:
            NexusMods.Load();

            // Show app:
            Application.Run(new FormProfiles());
        }

        private static void HandleThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception ex = e.Exception;
            FormExceptionDialog.OpenDialog(ex);
        }

        private static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = (Exception)e.ExceptionObject;
            FormExceptionDialog.OpenDialog(ex);
        }
    }
}
