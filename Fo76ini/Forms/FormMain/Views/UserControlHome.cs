using Fo76ini.Interface;
using Fo76ini.API;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManagedDOMStyles;
using Fo76ini.API.BethesdaNet;

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
                this.labelConfigVersion.ForeColor = Theming.GetColor("TextColor", Color.Black);
                return;
            }

            this.labelConfigVersion.ForeColor = Theming.GetColor("Version.UnknownColor", Color.Gray);
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
                this.labelConfigVersion.ForeColor = Theming.GetColor("TextColor", Color.Black);
                panelUpdate.Visible = false;
                return;
            }

            if (Versioning.UpdateAvailable || Configuration.Debug.ForceShowUpdateButton)
            {
                panelUpdate.Visible = true;
                labelNewVersion.Text = string.Format(Localization.GetString("newVersionAvailable"), Shared.LatestVersion);
                //labelNewVersion.ForeColor = Color.Crimson;
                this.labelConfigVersion.ForeColor = Theming.GetColor("Version.OldColor", Color.Red);
            }
            else
            {
                // All good, latest version:
                panelUpdate.Visible = false;
                this.labelConfigVersion.ForeColor = Theming.GetColor("Version.LatestColor", Color.DarkGreen);
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
            if (Theming.CurrentTheme == ThemeType.Dark)
                this.webBrowserWhatsNew.Url = new Uri(Shared.URLs.RemoteWhatsNewDarkURL);
            else
                this.webBrowserWhatsNew.Url = new Uri(Shared.URLs.RemoteWhatsNewURL);
        }

        private void styledButtonWhatsNew_Click(object sender, EventArgs e)
        {
            // Web browser does only work on Windows 10 (and newer) for some reason:
            if (Utils.IsWindows10OrNewer())
            {
                LoadWhatsNew();

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
                if (Theming.CurrentTheme == ThemeType.Dark)
                    Utils.OpenURL(Shared.URLs.RemoteWhatsNewDarkURL);
                else
                    Utils.OpenURL(Shared.URLs.RemoteWhatsNewURL);
            }
        }

        private void styledButtonGoBack_Click(object sender, EventArgs e)
        {
            this.tabControlWithoutHeader1.SelectedTab = this.tabPageHome;
        }

        #endregion

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

        private void styledButtonNukacrypt_Click(object sender, EventArgs e)
        {
            Utils.OpenURL("https://nukacrypt.com/");
        }

        private void styledButtonxTranslator_Click(object sender, EventArgs e)
        {
            Utils.OpenURL("https://www.nexusmods.com/skyrimspecialedition/mods/134");
        }

        private void styledButtonMap76_Click(object sender, EventArgs e)
        {
            Utils.OpenURL("https://map76.com/");
        }

        #endregion

        #region Scrapping server status from Bethesda.net API

        /// <summary>
        /// Load the Server Status from Bethesda.net's API asynchronously and set up the UI accordingly.
        /// </summary>
        private void LoadServerStatus()
        {
            this.pictureBoxScrapedServerStatus.Image = Theming.CurrentTheme == ThemeType.Dark ? Resources.Rolling_1s_24px_dark : Resources.Rolling_1s_24px_light;
            this.labelScrapedServerStatus.Text = "...";
            this.buttonReloadServerStatus.Enabled = false;
            this.backgroundWorkerScrapeServerStatus.RunWorkerAsync();
        }

        private void timerReenableRefreshServerStatus_Tick(object sender, EventArgs e)
        {
            this.buttonReloadServerStatus.Enabled = true;
            this.timerReenableRefreshServerStatus.Stop();
        }

        private void buttonReloadServerStatus_Click(object sender, EventArgs e)
        {
            LoadServerStatus();
        }

        private void backgroundWorkerScrapeServerStatus_DoWork(object sender, DoWorkEventArgs e)
        {
            ServerStatus status = new ServerStatus();

            status.status = BethesdaNetAPI.ScrapeServerStatus();
            status.statusKey = BethesdaNetAPI.GetKeyFromStatus(status.status);
            status.localizedStatus = BethesdaNetAPI.GetLocalizedServerStatus(Localization.ShortLocale, status.statusKey);
            switch (status.statusKey)
            {
                case "operational":
                    status.image = Resources.status_operational_24;
                    break;
                case "maintenance":
                    status.image = Resources.status_maintenance_24;
                    break;
                case "partial":
                case "minor":
                case "degraded":
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

            Thread.Sleep(500); // Sneak in a little delay, so the user doesn't think that it's broken.
        }

        private void backgroundWorkerScrapeServerStatus_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ServerStatus status = (ServerStatus)e.Result;
            this.labelScrapedServerStatus.Text = status.localizedStatus;
            this.pictureBoxScrapedServerStatus.Image = status.image;
            this.buttonReloadServerStatus.Left = this.labelScrapedServerStatus.Left + this.labelScrapedServerStatus.Width + 6;
            this.timerReenableRefreshServerStatus.Start();
        }

        // Helper struct for the Background Worker.
        private struct ServerStatus
        {
            public String status;
            public String statusKey;
            public String localizedStatus;
            public Image image;
        }

        #endregion
    }
}
