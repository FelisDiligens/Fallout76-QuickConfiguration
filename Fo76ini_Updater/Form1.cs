using Fo76ini;
using IniParser;
using IniParser.Model;
using IniParser.Model.Configuration;
using IniParser.Parser;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini_Updater
{
    public partial class Updater : Form
    {
        WebClient client;
        Log log;

        String workingDir;
        String installationPath;
        String configPath;
        String downloadUrl;
        String downloadPath;
        String downloadFile;
        String extractionPath;
        String executablePath;
        String iniPath;

        FileIniDataParser iniParser;
        IniData config;

        public Updater()
        {
            InitializeComponent();
        }

        private void LoadIni ()
        {
            IniParserConfiguration iniParserConfig = new IniParserConfiguration();
            iniParserConfig.AllowCreateSectionsOnFly = true;
            iniParserConfig.AssigmentSpacer = "";
            iniParserConfig.CaseInsensitive = true;
            iniParserConfig.CommentRegex = new System.Text.RegularExpressions.Regex(@";.*");

            this.iniParser = new FileIniDataParser(new IniDataParser(iniParserConfig));
            config = this.iniParser.ReadFile(iniPath, new UTF8Encoding(false));
        }

        private void SaveIni()
        {
            this.iniParser.WriteFile(this.iniPath, this.config, new UTF8Encoding(false));
        }

        private void Updater_Load(object sender, EventArgs e)
        {
            configPath = Path.GetFullPath(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Fallout 76 Quick Configuration"));
            iniPath = Path.Combine(configPath, "config.ini");

            LoadIni();
            if (config["Updater"]["sInstallationPath"] == null)
            {
                FailState("Please run the updater through Fo76ini.exe.");
                Colapse();
                return;
            }

            installationPath = config["Updater"]["sInstallationPath"];
            workingDir = Path.GetFullPath(AppContext.BaseDirectory);
            extractionPath = Path.Combine(workingDir, "update");
            executablePath = Path.Combine(installationPath, "Fo76ini.exe");

            client = new WebClient();
            client.CachePolicy = new RequestCachePolicy(RequestCacheLevel.BypassCache);
            //client.Headers["User-Agent"] = "Fallout76-QuickConfiguration-Updater";

            log = new Log(Log.GetFilePath("update.log.txt"));

            Thread thread = new Thread(DoUpdate);
            thread.IsBackground = true;
            thread.Start();
        }

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

        private bool GetLatestReleaseURL()
        {
            // https://developer.github.com/v3/repos/releases/#get-the-latest-release
            log.WriteLine("Retrieving download URL with GitHub API...");
            JObject json;

            // Check rate limit
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

            // Make request
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://api.github.com/repos/FelisDiligens/Fallout76-QuickConfiguration/releases/latest");
                request.UserAgent = "Fallout76-QuickConfiguration-Updater";
                request.Accept = "application/vnd.github.v3+json";

                // https://developer.github.com/v3/#conditional-requests
                // "Making a conditional request and receiving a 304 response does not count against your Rate Limit"
                if (config["Updater"]["sLastDownloadURL"] != null && config["Updater"]["sLastDownloadFileName"] != null)
                {
                    if (config["Updater"]["sAPI_ETag"] != null)
                        request.Headers["If-Non-Match"] = config["Updater"]["sAPI_ETag"];
                    if (config["Updater"]["sAPI_Last-Modified"] != null)
                        //request.Headers["If-Modified-Since"] = config["Updater"]["sAPI_Last-Modified"];
                        request.IfModifiedSince = DateTime.Parse(config["Updater"]["sAPI_Last-Modified"]); //, "ddd, dd MMM yyyy HH:mm:ss"); // (GitHub's date strings are conform to RFC 1123)
                }

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                //raw = client.DownloadData("https://api.github.com/repos/FelisDiligens/Fallout76-QuickConfiguration/releases/latest");
                //resp = JObject.Parse(Encoding.UTF8.GetString(raw));
                if (response.StatusCode == HttpStatusCode.NotModified)
                {
                    log.WriteLine($"HTTP 304 - Not Modified: Cached download url is still valid.");
                    downloadUrl = config["Updater"]["sLastDownloadURL"];
                    downloadFile = config["Updater"]["sLastDownloadFileName"];
                    return true;
                }
                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream))
                {
                    json = JObject.Parse(reader.ReadToEnd());
                }
                config["Updater"]["sAPI_ETag"] = (String)response.Headers["ETag"];
                config["Updater"]["sAPI_Last-Modified"] = (String)response.Headers["Last-Modified"];
                SaveIni();
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    HttpWebResponse response = ((HttpWebResponse)ex.Response);
                    if (response.StatusCode == HttpStatusCode.NotModified)
                    {
                        log.WriteLine($"HTTP 304 - Not Modified: Cached download url is still valid.");
                        downloadUrl = config["Updater"]["sLastDownloadURL"];
                        downloadFile = config["Updater"]["sLastDownloadFileName"];
                        return true;
                    }
                    else
                    {
                        log.WriteLine($"Failed: Request denied. Dumping response to githubAPIresp.json.\n{ex}");
                        using (Stream s = File.Create(Path.Combine(configPath, "githubAPIresp.json")))
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
            JArray assets = (JArray)json["assets"];

            String browserDownloadURL = null;
            String fileName = null;
            foreach (JObject asset in assets)
            {
                fileName = (String)asset["name"];
                String contentType = (String)asset["content_type"];
                // if (contentType == "application/x-msdownload" && Path.GetExtension(name) == ".exe")
                if (contentType == "application/x-zip-compressed" && Path.GetExtension(fileName) == ".zip")
                {
                    // String url = (String)asset["url"];
                    browserDownloadURL = (String)asset["browser_download_url"];
                }
            }

            if (browserDownloadURL != null)
            {
                log.WriteLine($"Download URL found.");
                downloadUrl = browserDownloadURL;
                downloadFile = fileName;
                config["Updater"]["sLastDownloadURL"] = downloadUrl;
                config["Updater"]["sLastDownloadFileName"] = downloadFile;
                SaveIni();
                return true;
            }
            log.WriteLine("Failed: Download URL not found.");
            Invoke(() => FailState("Something went wrong,\ncheck update.log.txt for details."));
            return false;
        }

        private void DoUpdate()
        {
            Invoke(Colapse);
            log.WriteLine("\n\n\n------------------------------------------------------------------------------------------------------------");
            log.WriteTimeStamp();

            // The tool has to be closed:
            Invoke(() => SetLabel("Waiting for the tool to exit...", Color.DimGray));
            while (Utils.IsProcessRunning("Fo76ini"))
                Thread.Sleep(500);
            Invoke(() => SetLabel("Updating, please wait...", Color.Black));

            // Download
            Invoke(() => SetLabel($"Updating, please wait...\nContacting GitHub API...", Color.Black));
            if (!GetLatestReleaseURL())
                return;

            downloadPath = Path.Combine(workingDir, downloadFile);
            Invoke(() => SetLabel($"Updating, please wait...\nDownloading {this.downloadFile}...", Color.Black));
            try
            {
                log.WriteLine($"Downloading file from {downloadUrl}");
                client.DownloadFile(downloadUrl, downloadPath);
            }
            catch (WebException ex)
            {
                Invoke(() => FailState("Couldn't download file,\ncheck update.log.txt for details.", ex));
                return;
            }
            if (!File.Exists(downloadPath))
            {
                log.WriteLine($"{downloadFile} couldn't be found.");
                Invoke(() => FailState("Something went wrong,\ncheck update.log.txt for details."));
                return;
            }

            // Unpacking
            Invoke(() => SetLabel($"Updating, please wait...\nExtracting contents of {this.downloadFile}...", Color.Black));
            String sevenZipPath = Path.GetFullPath(".\\7z\\7za.exe");
            String arguments = $"x \"{downloadPath}\" -r -o\"{extractionPath}\" -y *";
            using (Process proc = new Process())
            {
                log.WriteLine("--------------------------------------------------------------------");
                log.WriteLine($"Unpacking file");
                log.WriteLine($">> 7za.exe {arguments}");
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
                return;
            }
            log.WriteLine("--------------------------------------------------------------------");

            // Replacing old files
            log.WriteLine("Installing update...");
            log.WriteLine($"From: {extractionPath}");
            log.WriteLine($"To:   {installationPath}");
            IEnumerable<String> files = Directory.EnumerateFiles(extractionPath, "*.*", SearchOption.AllDirectories);
            try
            {
                foreach (String file in files)
                {
                    String relPath = Utils.MakeRelativePath(extractionPath, file);
                    log.WriteLine($" - Copying \"{relPath}\"");
                    Invoke(() => SetLabel($"Updating, please wait...\nCopying {relPath}...", Color.Black));

                    String destPath = Path.Combine(installationPath, relPath);
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

            // Starting Fo76ini.exe
            log.WriteLine("Update finished\n\n");
            Invoke(() => SetLabel("Update finished", Color.ForestGreen));
            Invoke(Expand);
        }

        private void FailState(String text, Exception ex)
        {
            log.WriteLine(ex);
            Expand();
            SetLabel(text, Color.Red);
            this.buttonTryAgainAdmin.Visible = true;
        } // UnauthorizedAccessException, WebException, FileNotFoundException

        private void FailState(String text)
        {
            Expand();
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
            this.MaximumSize = new Size(300, 180);
            this.Size = this.MaximumSize;
            this.buttonStartTool.Enabled = true;
        }

        private void Colapse()
        {
            this.MaximumSize = this.MinimumSize;
            this.Size = this.MinimumSize;
            this.buttonStartTool.Enabled = false;
            this.buttonTryAgainAdmin.Visible = false;
        }
    }
}
