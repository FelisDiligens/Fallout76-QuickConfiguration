using Fo76ini;
using Fo76ini.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Cache;
using System.Threading;
using System.Windows.Forms;

namespace Fo76ini_Updater
{
    public partial class Updater : Form
    {
        TextWriter log;
        String logPath;
        Config config;

        String workingDir;
        String downloadPath;
        String extractionPath;
        String executablePath;

        bool aborted = false;

        /*
         * The form changes sizes depending on the current process.
         * While updating, it is collapsed.
         * If successfully updated, it is expanded.
         * If something went wrong, it gets fully expanded.
         */
        private Size CollapsedSize = new Size(300, 140);
        private Size ExpandedSize = new Size(300, 170);
        private Size FullyExpandedSize = new Size(300, 230);

        public Updater()
        {
            InitializeComponent();

            this.backgroundWorkerGatherInfo.RunWorkerCompleted += backgroundWorkerGatherInfo_RunWorkerCompleted;
        }

        /*
         * Execution order:
         * 
         * (Preparation)
         * 1. Updater_Load
         * 
         * (Gathering information)
         * 2. backgroundWorkerGatherInfo_DoWork
         * 3. backgroundWorkerGatherInfo_RunWorkerCompleted
         * 
         * (Downloading)
         * 4. Download
         * 5. DownloadFileCompleted
         * 
         * (Installing)
         * 6. backgroundWorkerInstall_DoWork
         */

        private void Updater_Load(object sender, EventArgs e)
        {
            this.pictureBoxLoading.Visible = false;
            this.progressBar.Visible = false;

            config = new Config();
            config.LoadIni();

            if (!config.HasInstallationPath())
            {
                FailState("Please run the updater through Fo76ini.exe.");
                Collapse();
                return;
            }

            workingDir = Path.GetFullPath(AppContext.BaseDirectory);
            executablePath = Path.Combine(config.InstallationPath, "Fo76ini.exe");

            logPath = Log.GetFilePath("update.log.txt");
            log = Log.Open(logPath);

            Collapse();
            log.WriteLine("\n\n\n------------------------------------------------------------------------------------------------------------");
            log.WriteLine(Log.GetTimeStamp());

            this.backgroundWorkerGatherInfo.RunWorkerAsync();
        }

        private void backgroundWorkerGatherInfo_DoWork(object sender, DoWorkEventArgs e)
        {
            /*
             * Step 1: Gather information
             */

            // The tool has to be closed:
            Invoke(() => SetLabel("Waiting for the tool to terminate...", Color.DimGray));
            while (Utils.IsProcessRunning("Fo76ini"))
                Thread.Sleep(500);

            Invoke(ShowLoadingGIF);
            Invoke(() => SetLabel("Updating, please wait...", Color.Black));

            // Get Download URL:
            Invoke(() => SetLabel($"Updating, please wait...\nContacting GitHub API...", Color.Black));
            if (!CheckRateLimit())
                aborted = true;
            if (!GetLatestReleaseURL())
                aborted = true;
        }

        private void backgroundWorkerGatherInfo_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (aborted)
                return;

            // Compare versions:
            if (config.HasVersionStrings() && Utils.CompareVersions(config.InstalledVersion, config.LatestVersion) >= 0)
            {
                // If update isn't necessary, then ask user, if they want to continue anyway:
                if (MessageBox.Show($"You already have the latest version.\nYour version: {config.InstalledVersion}\nLatest version: {config.LatestVersion}\nDo you want to continue updating anyway?", "Continue anyway?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    Invoke(() => SetLabel("You already have the latest version."));
                    Invoke(Expand);
                    return;
                }
            }

            Download();
        }

        private void Download()
        {
            /*
             * Step 2: Download
             */

            SetLabel($"Updating, please wait...\nDownloading {config.DownloadFileName}...", Color.Black);
            log.WriteLine($"Downloading file from {config.DownloadURL}");

            downloadPath = Path.Combine(workingDir, config.DownloadFileName);

            WebClient client = new WebClient();
            client.CachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
            client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(DownloadProgressChanged);
            client.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadFileCompleted);
            client.DownloadFileAsync(new Uri(config.DownloadURL), downloadPath);

            ShowProgressbar();
        }

        private void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            // Display download progress:
            int percentage = Utils.Clamp((int)(e.BytesReceived / (float)e.TotalBytesToReceive * 100), 0, 100);
            this.progressBar.Value = percentage;
            SetLabel($"Updating, please wait...\nDownloading {config.DownloadFileName} ({Utils.GetFormatedSize(e.BytesReceived)} of {Utils.GetFormatedSize(e.TotalBytesToReceive)}, {percentage}%)...", Color.Black);
        }

        private void DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            HideProgressbar();

            if (e.Error != null)
            {
                Invoke(() => FailState("Couldn't download file,\ncheck update.log.txt for details."));
                log.WriteLine($"Couldn't download file, exception occured.\n{e.Error.GetType().Name}: {e.Error.Message}");
                aborted = true;
            }
            else if (!File.Exists(downloadPath))
            {
                log.WriteLine($"{config.DownloadFileName} couldn't be found.");
                Invoke(() => FailState("Something went wrong,\ncheck update.log.txt for details."));
                aborted = true;
            }
            else
            {
                // If no error happened, proceed installation:
                this.backgroundWorkerInstall.RunWorkerAsync();
            }
        }

        private void backgroundWorkerInstall_DoWork(object sender, DoWorkEventArgs e)
        {
            /*
             * Step 3: Installation
             */

            // Unpacking
            Invoke(() => SetLabel($"Updating, please wait...\nExtracting contents of {config.DownloadFileName}...", Color.Black));
            if (!ExtractArchive())
                return;

            // Replacing old files
            log.WriteLine("Installing update...");
            log.WriteLine($"From: {extractionPath}");
            log.WriteLine($"To:   {config.InstallationPath}");
            IEnumerable<String> files = Directory.EnumerateFiles(extractionPath, "*.*", SearchOption.AllDirectories);
            try
            {
                foreach (String file in files)
                {
                    String relPath = Utils.MakeRelativePath(extractionPath, file);
                    log.WriteLine($" - Copying \"{relPath}\"");
                    Invoke(() => SetLabel($"Updating, please wait...\nCopying {relPath}...", Color.Black));

                    String destPath = Path.Combine(config.InstallationPath, relPath);
                    if (!Directory.Exists(Path.GetDirectoryName(destPath)))
                        Directory.CreateDirectory(Path.GetDirectoryName(destPath));

                    File.Copy(
                        file,
                        destPath,
                        true
                    );
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Invoke(() => FailState("Couldn't copy files, access denied.\nTry again, but run 'updater.exe' as admin.", ex));
                return;
            }
            catch (IOException ex)
            {
                Invoke(() => FailState("Couldn't copy files.\nPlease run the updater through Fo76ini.exe.", ex));
                return;
            }
            Invoke(() => SetLabel($"Updating, please wait...", Color.Black));

            // Clean up
            log.WriteLine("Cleaning up files...");
            if (File.Exists(downloadPath))
                File.Delete(downloadPath);
            if (Directory.Exists(extractionPath))
                Directory.Delete(extractionPath, true);

            // Expand to show buttons:
            log.WriteLine("Update finished\n\n");
            Invoke(() => SetLabel("Update finished", Color.ForestGreen));
            Invoke(Expand);
        }

        private bool CheckRateLimit()
        {
            int limit = 0;
            int limitRemaining = 0;
            DateTime limitReset;
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.github.com/rate_limit");
                request.UserAgent = "Fallout76-QuickConfiguration-Updater";
                request.Accept = "application/vnd.github.v3+json";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                limit = Convert.ToInt32(response.Headers["X-RateLimit-Limit"]);
                limitRemaining = Convert.ToInt32(response.Headers["X-RateLimit-Remaining"]);
                limitReset = Utils.UnixTimeStampToDateTime(Convert.ToDouble(response.Headers["X-RateLimit-Reset"]));

                log.WriteLine($"API Rate Limit: {limitRemaining} of {limit} remaining.");
                if (limitRemaining <= 0)
                {
                    log.WriteLine("API Rate Limit exceeded.");
                    Invoke(() => FailState($"Can't access API, rate limit exceeded.\nTry again at {limitReset}"));
                    return false;
                }
            }
            catch (WebException ex)
            {

            }
            return true;
        }

        private bool GetLatestReleaseURL()
        {
            // https://developer.github.com/v3/repos/releases/#get-the-latest-release
            log.WriteLine("Retrieving download URL with GitHub API...");
            JObject json;

            /*
             * *********************************************
             * (1/2) Make request, get response
             * *********************************************
             */
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.github.com/repos/FelisDiligens/Fallout76-QuickConfiguration/releases/latest");
                request.UserAgent = "Fallout76-QuickConfiguration-Updater";
                request.Accept = "application/vnd.github.v3+json";

                // https://developer.github.com/v3/#conditional-requests
                // "Making a conditional request and receiving a 304 response does not count against your Rate Limit"
                if (config.HasCachedDownloadURL())
                {
                    if (config.HasETag())
                        request.Headers["If-Non-Match"] = config.ETag;
                    if (config.HasLastModified())
                        request.IfModifiedSince = DateTime.Parse(config.LastModified); //, "ddd, dd MMM yyyy HH:mm:ss"); // (GitHub's date strings are conform to RFC 1123)
                }

                // Get the response and...
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // ... skip if 304 - Not Modified:
                if (response.StatusCode == HttpStatusCode.NotModified)
                {
                    log.WriteLine($"HTTP 304 - Not Modified: Cached download url is still valid.");
                    return true;
                }

                // ... otherwise get *.json:
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = JObject.Parse(reader.ReadToEnd());
                }
                config.ETag = (String)response.Headers["ETag"];
                config.LatestVersion = (String)response.Headers["Last-Modified"];
                config.SaveIni();
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    // If we got a response...
                    HttpWebResponse response = ((HttpWebResponse)ex.Response);

                    // ... skip if 304 - Not Modified:
                    if (response.StatusCode == HttpStatusCode.NotModified)
                    {
                        log.WriteLine($"HTTP 304 - Not Modified: Cached download url is still valid.");
                        return true;
                    }

                    // ... otherwise abort with error message:
                    else
                    {
                        log.WriteLine($"Failed: Request denied. Dumping response to {Shared.AppConfigFolder}\\githubAPIresp.json.\n{ex}");
                        using (Stream s = File.Create(Path.Combine(Shared.AppConfigFolder, "githubAPIresp.json")))
                        {
                            response.GetResponseStream().CopyTo(s);
                        }
                        log.WriteLine($"Response headers:\nX-RateLimit-Limit: {response.Headers["X-RateLimit-Limit"]}\nX-RateLimit-Remaining: {response.Headers["X-RateLimit-Remaining"]}\nX-RateLimit-Reset: {response.Headers["X-RateLimit-Reset"]}");
                        Invoke(() => FailState("Error: API request denied,\ncheck update.log.txt for details.", ex));
                    }
                }
                else
                {
                    log.WriteLine($"Failed: Unable to contact GitHub API.\n{ex}");
                    Invoke(() => FailState("Unable to contact GitHub API.\nCheck your network connection.", ex));
                }
                return false;
            }
            catch (Exception ex)
            {
                log.WriteLine($"Failed - Unhandled exception:\n{ex}");
                Invoke(() => FailState("Something went wrong,\ncheck update.log.txt for details.", ex));
                return false;
            }

            /*
             * *********************************************
             * (2/2) Extract information
             * *********************************************
             */

            // Find version
            String tagName = json["tag_name"].ToString();
            config.LatestVersion = tagName;

            // Find download URL
            JArray assets = (JArray)json["assets"];

            String browserDownloadURL = null;
            String fileName = null;
            foreach (JObject asset in assets)
            {
                fileName = (String)asset["name"];
                String contentType = (String)asset["content_type"];
                // if (contentType == "application/x-msdownload" && Path.GetExtension(fileName) == ".exe")
                if (contentType == "application/x-zip-compressed" && Path.GetExtension(fileName) == ".zip")
                {
                    // String url = (String)asset["url"];
                    browserDownloadURL = (String)asset["browser_download_url"];
                }
            }

            if (browserDownloadURL != null)
            {
                log.WriteLine($"Download URL found.");
                config.DownloadURL = browserDownloadURL;
                config.DownloadFileName = fileName;
                config.SaveIni();
                return true;
            }
            log.WriteLine("Failed: Download URL not found.");
            Invoke(() => FailState("Couldn't get download URL,\ncheck update.log.txt for details."));
            return false;
        }

        private bool ExtractArchive()
        {
            extractionPath = Path.Combine(workingDir, Path.GetFileNameWithoutExtension(config.DownloadFileName));
            //extractionPath = Path.Combine(workingDir, "extracted");
            String sevenZipPath = Path.GetFullPath(".\\7z\\7z.exe");
            String arguments = $"x \"{downloadPath}\" -r -o\"{extractionPath}\" -y *";
            using (Process proc = new Process())
            {
                log.WriteLine("--------------------------------------------------------------------");
                log.WriteLine($"Unpacking file");
                log.WriteLine($">> 7z.exe {arguments}");
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.FileName = sevenZipPath;
                proc.StartInfo.Arguments = arguments;
                proc.StartInfo.CreateNoWindow = true;
                proc.Start();

                log.WriteLine(proc.StandardOutput.ReadToEnd() + "\n");
                log.WriteLine(proc.StandardError.ReadToEnd() + "\n");
                proc.WaitForExit();
            }
            if (!Directory.Exists(extractionPath))
            {
                Invoke(() => FailState("Something went wrong,\ncheck update.log.txt for details."));
                return false;
            }
            log.WriteLine("--------------------------------------------------------------------");
            return true;
        }


        /*
         * Event handler
         */

        private void buttonStartTool_Click(object sender, EventArgs e)
        {
            if (File.Exists(executablePath))
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo();
                    startInfo.FileName = executablePath;
                    Process.Start(startInfo);
                    Application.Exit();
                }
                catch (Exception ex)
                {
                    FailState("Tool couldn't be started.", ex);
                }
            }
            else
            {
                FailState("Fo76ini.exe couldn't be found.", new FileNotFoundException(executablePath));
            }
        }

        private void buttonTryAgainAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                using (Process proc = new Process())
                {
                    proc.StartInfo.FileName = Path.Combine(workingDir, "updater.exe");
                    proc.StartInfo.Verb = "runas";
                    proc.Start();
                }
                Application.Exit();
            }
            catch (Exception ex)
            {
                FailState("updater.exe couldn't be started.", ex);
            }
        }

        private void buttonShowLogFile_Click(object sender, EventArgs e)
        {
            if (File.Exists(logPath))
                Utils.OpenNotepad(logPath);
        }



        /*
         * Stuff
         */

        private void FailState(String text, Exception ex)
        {
            HideLoadingGIF();
            log.WriteLine(ex);
            ExpandFully();
            SetLabel(text, Color.Red);
            this.buttonTryAgainAdmin.Visible = true;
        } // UnauthorizedAccessException, WebException, FileNotFoundException

        private void FailState(String text)
        {
            HideLoadingGIF();
            ExpandFully();
            SetLabel(text, Color.Red);
            this.buttonTryAgainAdmin.Visible = true;
        }

        private void Invoke(Action func)
        {
            this.labelStatus.Invoke(func);
        }

        private void SetLabel(String text)
        {
            this.labelStatus.Text = text;
        }

        private void SetLabel(String text, Color color)
        {
            this.labelStatus.Text = text;
            this.labelStatus.ForeColor = color;
        }

        private void Expand()
        {
            this.SetSize(ExpandedSize);

            this.buttonStartTool.Visible = true;
            this.buttonTryAgainAdmin.Visible = false;
            this.buttonShowLogFile.Visible = false;

            this.pictureBoxLoading.Visible = false;
        }

        private void ExpandFully()
        {
            this.SetSize(FullyExpandedSize);

            this.buttonStartTool.Visible = true;
            this.buttonTryAgainAdmin.Visible = true;
            this.buttonShowLogFile.Visible = true;

            this.pictureBoxLoading.Visible = false;
        }

        private void Collapse()
        {
            this.SetSize(CollapsedSize);

            this.buttonStartTool.Visible = false;
            this.buttonTryAgainAdmin.Visible = false;
            this.buttonShowLogFile.Visible = false;
        }

        private void SetSize(Size size)
        {
            this.Size = size;
            this.MaximumSize = size;
            this.MinimumSize = size;
        }

        private void ShowLoadingGIF()
        {
            this.pictureBoxLoading.Visible = true;
        }

        private void HideLoadingGIF()
        {
            this.pictureBoxLoading.Visible = false;
        }

        private void ShowProgressbar()
        {
            this.progressBar.Visible = true;
        }

        private void HideProgressbar()
        {
            this.progressBar.Visible = false;
        }
    }
}
