using Fo76ini.Forms.ExceptionDialog;
using System;
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

            // TODO: nxm protocol handler
            // string[] args = Environment.GetCommandLineArgs();
            // MsgBox.Show("Arguments", $"{String.Join("\n", args)}");
            // args[1] = "nxm://fallout76/mods/<mod_id>/files/<file_id>?key=<long_random_string>&expires=<unix_timestamp>&user_id=<user_id>"

            Application.ThreadException += new ThreadExceptionEventHandler(HandleThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(HandleUnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new Form1());
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
