using Fo76ini.Interface;
using Fo76ini.NexusAPI;
using Fo76ini.Properties;
using Fo76ini.Utilities;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Forms.FormMain.Tabs
{
    public partial class UserControlHome : UserControl
    {
        public UserControlHome()
        {
            InitializeComponent();

            this.Load += UserControlHome_Load;
            this.backgroundWorkerGetLatestVersion.DoWork += backgroundWorkerGetLatestVersion_DoWork;
            this.backgroundWorkerGetLatestVersion.RunWorkerCompleted += backgroundWorkerGetLatestVersion_RunWorkerCompleted;

            this.pictureBoxButtonUpdate.Click += PictureBoxButtonUpdate_Click;

            // Handle translations:
            Translation.LanguageChanged += OnLanguageChanged;

            Translation.BlackList.Add("labelScrapedServerStatus");
        }

        private void UserControlHome_Load(object sender, EventArgs e)
        {
            // What's new:
            LoadWhatsNew();

            // Check for updates:
            CheckVersion();
            IniFiles.Config.Set("General", "sPreviousVersion", Shared.VERSION);

            // Check Bethesda.net server status:
            LoadServerStatus();
        }

        public void OnLanguageChanged(object sender, TranslationEventArgs e)
        {
            Translation translation = (Translation)sender;

            // Set labels and stuff:
            this.labelTranslationAuthor.Visible = e.HasAuthor;
            this.labelTranslationBy.Visible = e.HasAuthor;
            this.labelTranslationAuthor.Text = e.HasAuthor ? translation.Author : "";

            // TODO: UpdateUI?
            this.CheckVersion();

            // Set font:
            this.labelWelcome.Font = CustomFonts.GetHeaderFont();

            //this.Refresh(); // Forces redraw
        }

        /*
         **************************************************************
         * Check version
         **************************************************************
         */

        #region Check version

        public void CheckVersion(bool force = false)
        {
            if (this.backgroundWorkerGetLatestVersion.IsBusy)
                return;

            this.labelConfigVersion.Text = Shared.VERSION;
            IniFiles.Config.Set("General", "sVersion", Shared.VERSION);

            panelUpdate.Visible = false;

            if (!force && Configuration.IgnoreUpdates)
            {
                this.labelConfigVersion.ForeColor = Color.Black;
                return;
            }

            this.labelConfigVersion.ForeColor = Color.Gray;
            this.pictureBoxSpinnerCheckForUpdates.Visible = true;

            // Checking version in background:
            this.backgroundWorkerGetLatestVersion.RunWorkerAsync();
        }

        private void backgroundWorkerGetLatestVersion_DoWork(object sender, DoWorkEventArgs e)
        {
            Versioning.GetLatestVersion();
        }

        private void backgroundWorkerGetLatestVersion_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.pictureBoxSpinnerCheckForUpdates.Visible = false;

            // Failed:
            if (Shared.LatestVersion == null)
            {
                this.labelConfigVersion.ForeColor = Color.Black;
                panelUpdate.Visible = false;
                return;
            }

            if (Versioning.UpdateAvailable || Configuration.Debug.ForceShowUpdateButton)
            {
                panelUpdate.Visible = true;
                labelNewVersion.Text = string.Format(Localization.GetString("newVersionAvailable"), Shared.LatestVersion);
                labelNewVersion.ForeColor = Color.Crimson;
                this.labelConfigVersion.ForeColor = Color.Red;
            }
            else
            {
                // All good, latest version:
                panelUpdate.Visible = false;
                this.labelConfigVersion.ForeColor = Color.DarkGreen;
            }
        }

        #endregion

        #region Update available

        // "Get the latest version from NexusMods" link:
        private void linkLabelManualDownloadPage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelManualDownloadPage.LinkVisited = true;
            Process.Start(Shared.URLs.AppNexusModsDownloadURL);
        }

        private void PictureBoxButtonUpdate_Click(object sender, EventArgs e)
        {
            if (UpdateButtonClicked != null)
                UpdateButtonClicked(sender, e);
        }
        public event EventHandler UpdateButtonClicked;

        #endregion




        #region What's new

        /*
         * What's new:
         */

        private void LoadWhatsNew()
        {
#if DEBUG
            string debugFile = Path.Combine(Shared.AppConfigFolder, "What's new.html");
            if (File.Exists(debugFile))
                this.webBrowserWhatsNew.DocumentText = File.ReadAllText(debugFile);
            else
#endif
                this.webBrowserWhatsNew.Url = new Uri(Shared.URLs.RemoteWhatsNewHTMLURL);
        }

        #endregion

        private void styledButtonWhatsNew_Click(object sender, EventArgs e)
        {
            // Web browser does only work on Windows 10 (and newer) for some reason:
            if (Utils.IsWindows10OrNewer())
            {
                this.tabControlWithoutHeader1.SelectedTab = this.tabPageWhatsNew;

                // "Fixing" the web browser not rendering by resizing the window, which helps for some reason:
                // (https://stackoverflow.com/a/68837431)
                // TODO
                this.ParentForm.Height += 1;
                this.ParentForm.Height -= 1;
            }
            else
            {
                // Open users web browser on Windows 7 instead:
                Utils.OpenURL(Shared.URLs.RemoteWhatsNewHTMLURL);
            }
        }

        private void styledButtonGoBack_Click(object sender, EventArgs e)
        {
            this.tabControlWithoutHeader1.SelectedTab = this.tabPageHome;
        }

        #region Web links

        private void pictureBoxButtonSupport_Click(object sender, EventArgs e)
        {
            Utils.OpenURL("https://ko-fi.com/felisdiligens");
        }

        private void styledButtonNexusMods_Click(object sender, EventArgs e)
        {
            Utils.OpenURL("https://www.nexusmods.com/fallout76/mods/546");
        }

        private void styledButtonGitHub_Click(object sender, EventArgs e)
        {
            Utils.OpenURL("https://github.com/FelisDiligens/Fallout76-QuickConfiguration");
        }

        private void styledButtonWikiAndGuides_Click(object sender, EventArgs e)
        {
            Utils.OpenURL("https://github.com/FelisDiligens/Fallout76-QuickConfiguration/wiki");
        }

        private void styledButtonBugReports_Click(object sender, EventArgs e)
        {
            Utils.OpenURL("https://www.nexusmods.com/fallout76/mods/546?tab=bugs");
        }

        private void styledButtonBethesdaNetStatus_Click(object sender, EventArgs e)
        {
            Utils.OpenURL("https://bethesda.net/status");
        }

        private void styledButtonNukesAndDragonsBuildPlanner_Click(object sender, EventArgs e)
        {
            Utils.OpenURL("https://nukesdragons.com/fallout-76/character");
        }

        private void styledButtonxTranslator_Click(object sender, EventArgs e)
        {
            Utils.OpenURL("https://www.nexusmods.com/skyrimspecialedition/mods/134");
        }

        #endregion

        #region Scrapping server status from Bethesda.net API

        /// <summary>
        /// Request the server status from Bethesda.net's API.
        /// </summary>
        /// <returns>Server status</returns>
        private String ScrapeServerStatus()
        {
            string f76Status = "unknown";

            // Send request:
            APIRequest request = new APIRequest("https://bethesda.net/en/status/api/statuses");
            request.Execute();

            if (request.Success && request.StatusCode == HttpStatusCode.OK)
            {
                // Scrap for Fallout 76 Status:
                JObject responseJSON = request.GetJObject();
                JArray components = (JArray)responseJSON["components"];
                foreach (JObject component in components)
                {
                    string id = component["id"].ToObject<string>();
                    string name = component["name"].ToObject<string>();
                    string status = component["status"].ToObject<string>();

                    if (id == "m39k311rzvkg" || name == "Fallout 76")
                        f76Status = status;
                }
            }
            else
            {
                if (!request.Success)
                    f76Status = $"Error: No connection";
                else
                    f76Status = $"Error: HTTP {request.StatusCode}";
            }

            return f76Status;
        }

        /// <summary>
        /// Request the localized string of the given server status in the given language from "api.locize.app".
        /// </summary>
        /// <param name="language">ISO code, two characters long</param>
        /// <param name="status">The server status as received from the Bethesda.net API.</param>
        /// <returns></returns>
        private String GetLocalizedServerStatus(String language, String status)
        {
            // Send request:
            APIRequest request = new APIRequest($"https://api.locize.app/657e9e0e-8225-4266-88dd-75f047f1a2b3/live/{language.ToLower()}/status");
            request.Execute();

            if (request.Success && request.StatusCode == HttpStatusCode.OK)
            {
                JObject responseJSON = request.GetJObject();
                JObject statusKeys = (JObject)responseJSON["statusKey"];

                // If translation does not exist, the server returns an empty JSON object {}
                // In this situation, fallback to English:
                if (statusKeys == null)
                    return GetLocalizedServerStatus("en", status);

                if (statusKeys[status] != null)
                    return statusKeys[status].ToObject<string>();

                return status;
            }

            return status;
        }

        /// <summary>
        /// Load the Server Status from Bethesda.net's API asynchronously and set up the UI accordingly.
        /// </summary>
        private void LoadServerStatus()
        {
            this.pictureBoxScrapedServerStatus.Image = Resources.Spinner_24;
            this.labelScrapedServerStatus.Text = "...";
            this.buttonReloadServerStatus.Enabled = false;
            this.backgroundWorkerScrapeServerStatus.RunWorkerAsync();
        }

        private void buttonReloadServerStatus_Click(object sender, EventArgs e)
        {
            LoadServerStatus();
        }

        private void backgroundWorkerScrapeServerStatus_DoWork(object sender, DoWorkEventArgs e)
        {
            ServerStatus status = new ServerStatus();

            status.statusKey = ScrapeServerStatus();
            status.localizedStatus = GetLocalizedServerStatus(Localization.ShortLocale, status.statusKey);
            switch (status.statusKey)
            {
                case "operational":
                    status.image = Resources.status_operational_24;
                    break;
                case "maintenance":
                    status.image = Resources.status_maintenance_24;
                    break;
                case "partial":
                    status.image = Resources.status_partial_24;
                    break;
                case "major":
                    status.image = Resources.status_major_24;
                    break;
                default:
                    status.image = Resources.help_24;
                    break;
            }

            e.Result = status;
        }

        private void backgroundWorkerScrapeServerStatus_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ServerStatus status = (ServerStatus)e.Result;
            this.labelScrapedServerStatus.Text = status.localizedStatus;
            this.pictureBoxScrapedServerStatus.Image = status.image;
            this.buttonReloadServerStatus.Left = this.labelScrapedServerStatus.Left + this.labelScrapedServerStatus.Width + 6;
            this.buttonReloadServerStatus.Enabled = true;
        }

        // Helper struct for the Background Worker.
        private struct ServerStatus
        {
            public String statusKey;
            public String localizedStatus;
            public Image image;
        }

        #endregion
    }
}
