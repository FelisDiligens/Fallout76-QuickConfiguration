namespace Fo76ini.Forms.FormMain.Tabs
{
    partial class UserControlHome
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.webBrowserWhatsNew = new System.Windows.Forms.WebBrowser();
            this.panelUpdate = new System.Windows.Forms.Panel();
            this.pictureBoxButtonUpdate = new Fo76ini.Controls.PictureBoxButton();
            this.labelNewVersion = new System.Windows.Forms.Label();
            this.linkLabelManualDownloadPage = new System.Windows.Forms.LinkLabel();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelConfigVersion = new System.Windows.Forms.Label();
            this.labelTranslationAuthor = new System.Windows.Forms.Label();
            this.labelAuthorName = new System.Windows.Forms.Label();
            this.labelTranslationBy = new System.Windows.Forms.Label();
            this.userControlHero = new Fo76ini.Controls.UserControlHero();
            this.backgroundWorkerGetLatestVersion = new System.ComponentModel.BackgroundWorker();
            this.tabControlWithoutHeader1 = new Fo76ini.Controls.TabControlWithoutHeader();
            this.tabPageHome = new System.Windows.Forms.TabPage();
            this.panelWebLinks = new System.Windows.Forms.Panel();
            this.styledButtonNukacrypt = new Fo76ini.Controls.StyledButton();
            this.styledButtonxTranslator = new Fo76ini.Controls.StyledButton();
            this.styledButtonNukesAndDragonsBuildPlanner = new Fo76ini.Controls.StyledButton();
            this.styledButtonBethesdaNetStatus = new Fo76ini.Controls.StyledButton();
            this.styledButtonBugReports = new Fo76ini.Controls.StyledButton();
            this.styledButtonWikiAndGuides = new Fo76ini.Controls.StyledButton();
            this.styledButtonGitHub = new Fo76ini.Controls.StyledButton();
            this.styledButtonNexusMods = new Fo76ini.Controls.StyledButton();
            this.pictureBoxButtonSupport = new Fo76ini.Controls.PictureBoxButton();
            this.labelWebLinks = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.pictureBoxScrapedServerStatus = new System.Windows.Forms.PictureBox();
            this.buttonReloadServerStatus = new System.Windows.Forms.Button();
            this.labelScrapedServerStatus = new System.Windows.Forms.Label();
            this.labelServerStatus = new System.Windows.Forms.Label();
            this.styledButtonWhatsNew = new Fo76ini.Controls.StyledButton();
            this.pictureBoxSpinnerCheckForUpdates = new System.Windows.Forms.PictureBox();
            this.tabPageWhatsNew = new System.Windows.Forms.TabPage();
            this.styledButtonGoBack = new Fo76ini.Controls.StyledButton();
            this.backgroundWorkerScrapeServerStatus = new System.ComponentModel.BackgroundWorker();
            this.timerReenableRefreshServerStatus = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxSpacer1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxSpacer2 = new System.Windows.Forms.PictureBox();
            this.panelUpdate.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.tabControlWithoutHeader1.SuspendLayout();
            this.tabPageHome.SuspendLayout();
            this.panelWebLinks.SuspendLayout();
            this.panelContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScrapedServerStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerCheckForUpdates)).BeginInit();
            this.tabPageWhatsNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpacer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpacer2)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowserWhatsNew
            // 
            this.webBrowserWhatsNew.AllowNavigation = false;
            this.webBrowserWhatsNew.AllowWebBrowserDrop = false;
            this.webBrowserWhatsNew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserWhatsNew.IsWebBrowserContextMenuEnabled = false;
            this.webBrowserWhatsNew.Location = new System.Drawing.Point(3, 43);
            this.webBrowserWhatsNew.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserWhatsNew.Name = "webBrowserWhatsNew";
            this.webBrowserWhatsNew.ScriptErrorsSuppressed = true;
            this.webBrowserWhatsNew.Size = new System.Drawing.Size(662, 435);
            this.webBrowserWhatsNew.TabIndex = 52;
            this.webBrowserWhatsNew.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowserWhatsNew_DocumentCompleted);
            // 
            // panelUpdate
            // 
            this.panelUpdate.Controls.Add(this.pictureBoxButtonUpdate);
            this.panelUpdate.Controls.Add(this.labelNewVersion);
            this.panelUpdate.Controls.Add(this.linkLabelManualDownloadPage);
            this.panelUpdate.Location = new System.Drawing.Point(3, 229);
            this.panelUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.panelUpdate.Name = "panelUpdate";
            this.panelUpdate.Size = new System.Drawing.Size(295, 110);
            this.panelUpdate.TabIndex = 50;
            // 
            // pictureBoxButtonUpdate
            // 
            this.pictureBoxButtonUpdate.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxButtonUpdate.ButtonText = "Update now!";
            this.pictureBoxButtonUpdate.ButtonTextColor = System.Drawing.Color.White;
            this.pictureBoxButtonUpdate.ButtonTextFont = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pictureBoxButtonUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pictureBoxButtonUpdate.Image = global::Fo76ini.Properties.Resources.button;
            this.pictureBoxButtonUpdate.ImageHover = global::Fo76ini.Properties.Resources.button_hover;
            this.pictureBoxButtonUpdate.Location = new System.Drawing.Point(3, 29);
            this.pictureBoxButtonUpdate.Name = "pictureBoxButtonUpdate";
            this.pictureBoxButtonUpdate.Size = new System.Drawing.Size(293, 48);
            this.pictureBoxButtonUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxButtonUpdate.TabIndex = 46;
            // 
            // labelNewVersion
            // 
            this.labelNewVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNewVersion.ForeColor = System.Drawing.Color.Crimson;
            this.labelNewVersion.Location = new System.Drawing.Point(3, 6);
            this.labelNewVersion.Margin = new System.Windows.Forms.Padding(3);
            this.labelNewVersion.Name = "labelNewVersion";
            this.labelNewVersion.Size = new System.Drawing.Size(293, 20);
            this.labelNewVersion.TabIndex = 16;
            this.labelNewVersion.Text = "There is a newer version available: {0}";
            this.labelNewVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabelManualDownloadPage
            // 
            this.linkLabelManualDownloadPage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelManualDownloadPage.Location = new System.Drawing.Point(3, 80);
            this.linkLabelManualDownloadPage.Margin = new System.Windows.Forms.Padding(3);
            this.linkLabelManualDownloadPage.Name = "linkLabelManualDownloadPage";
            this.linkLabelManualDownloadPage.Size = new System.Drawing.Size(293, 20);
            this.linkLabelManualDownloadPage.TabIndex = 2;
            this.linkLabelManualDownloadPage.TabStop = true;
            this.linkLabelManualDownloadPage.Text = "Or download and install manually...";
            this.linkLabelManualDownloadPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabelManualDownloadPage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelManualDownloadPage_LinkClicked);
            // 
            // panelTitle
            // 
            this.panelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTitle.Controls.Add(this.labelWelcome);
            this.panelTitle.Controls.Add(this.labelDescription);
            this.panelTitle.Location = new System.Drawing.Point(3, 3);
            this.panelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(662, 69);
            this.panelTitle.TabIndex = 53;
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(15, 10);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(326, 30);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome to Quick Configuration";
            // 
            // labelDescription
            // 
            this.labelDescription.BackColor = System.Drawing.Color.Transparent;
            this.labelDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(17, 40);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(642, 29);
            this.labelDescription.TabIndex = 6;
            this.labelDescription.Text = "This tool allows you to change various game settings and install mods.";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(17, 6);
            this.labelVersion.Margin = new System.Windows.Forms.Padding(3);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(58, 17);
            this.labelVersion.TabIndex = 7;
            this.labelVersion.Text = "Version:";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.Location = new System.Drawing.Point(17, 29);
            this.labelAuthor.Margin = new System.Windows.Forms.Padding(3);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(56, 17);
            this.labelAuthor.TabIndex = 8;
            this.labelAuthor.Text = "Author:";
            // 
            // labelConfigVersion
            // 
            this.labelConfigVersion.AutoSize = true;
            this.labelConfigVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfigVersion.Location = new System.Drawing.Point(130, 6);
            this.labelConfigVersion.Name = "labelConfigVersion";
            this.labelConfigVersion.Size = new System.Drawing.Size(14, 17);
            this.labelConfigVersion.TabIndex = 9;
            this.labelConfigVersion.Text = "?";
            // 
            // labelTranslationAuthor
            // 
            this.labelTranslationAuthor.AutoSize = true;
            this.labelTranslationAuthor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTranslationAuthor.Location = new System.Drawing.Point(130, 75);
            this.labelTranslationAuthor.Name = "labelTranslationAuthor";
            this.labelTranslationAuthor.Size = new System.Drawing.Size(79, 17);
            this.labelTranslationAuthor.TabIndex = 12;
            this.labelTranslationAuthor.Text = "FelisDiligens";
            // 
            // labelAuthorName
            // 
            this.labelAuthorName.AutoSize = true;
            this.labelAuthorName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthorName.Location = new System.Drawing.Point(130, 29);
            this.labelAuthorName.Name = "labelAuthorName";
            this.labelAuthorName.Size = new System.Drawing.Size(79, 17);
            this.labelAuthorName.TabIndex = 10;
            this.labelAuthorName.Text = "FelisDiligens";
            // 
            // labelTranslationBy
            // 
            this.labelTranslationBy.AutoSize = true;
            this.labelTranslationBy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTranslationBy.Location = new System.Drawing.Point(17, 75);
            this.labelTranslationBy.Margin = new System.Windows.Forms.Padding(3);
            this.labelTranslationBy.Name = "labelTranslationBy";
            this.labelTranslationBy.Size = new System.Drawing.Size(100, 17);
            this.labelTranslationBy.TabIndex = 11;
            this.labelTranslationBy.Text = "Translation by:";
            // 
            // userControlHero
            // 
            this.userControlHero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlHero.Location = new System.Drawing.Point(0, 0);
            this.userControlHero.Margin = new System.Windows.Forms.Padding(0);
            this.userControlHero.Name = "userControlHero";
            this.userControlHero.Size = new System.Drawing.Size(676, 168);
            this.userControlHero.TabIndex = 51;
            // 
            // tabControlWithoutHeader1
            // 
            this.tabControlWithoutHeader1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlWithoutHeader1.Controls.Add(this.tabPageHome);
            this.tabControlWithoutHeader1.Controls.Add(this.tabPageWhatsNew);
            this.tabControlWithoutHeader1.Location = new System.Drawing.Point(0, 171);
            this.tabControlWithoutHeader1.Multiline = true;
            this.tabControlWithoutHeader1.Name = "tabControlWithoutHeader1";
            this.tabControlWithoutHeader1.SelectedIndex = 0;
            this.tabControlWithoutHeader1.Size = new System.Drawing.Size(676, 499);
            this.tabControlWithoutHeader1.TabIndex = 54;
            // 
            // tabPageHome
            // 
            this.tabPageHome.BackColor = System.Drawing.Color.White;
            this.tabPageHome.Controls.Add(this.panelWebLinks);
            this.tabPageHome.Controls.Add(this.panelContent);
            this.tabPageHome.Controls.Add(this.panelTitle);
            this.tabPageHome.Controls.Add(this.panelUpdate);
            this.tabPageHome.Location = new System.Drawing.Point(4, 22);
            this.tabPageHome.Name = "tabPageHome";
            this.tabPageHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHome.Size = new System.Drawing.Size(668, 473);
            this.tabPageHome.TabIndex = 0;
            this.tabPageHome.Text = "tabPageHome";
            // 
            // panelWebLinks
            // 
            this.panelWebLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWebLinks.Controls.Add(this.pictureBoxSpacer2);
            this.panelWebLinks.Controls.Add(this.pictureBoxSpacer1);
            this.panelWebLinks.Controls.Add(this.styledButtonNukacrypt);
            this.panelWebLinks.Controls.Add(this.styledButtonxTranslator);
            this.panelWebLinks.Controls.Add(this.styledButtonNukesAndDragonsBuildPlanner);
            this.panelWebLinks.Controls.Add(this.styledButtonBethesdaNetStatus);
            this.panelWebLinks.Controls.Add(this.styledButtonBugReports);
            this.panelWebLinks.Controls.Add(this.styledButtonWikiAndGuides);
            this.panelWebLinks.Controls.Add(this.styledButtonGitHub);
            this.panelWebLinks.Controls.Add(this.styledButtonNexusMods);
            this.panelWebLinks.Controls.Add(this.pictureBoxButtonSupport);
            this.panelWebLinks.Controls.Add(this.labelWebLinks);
            this.panelWebLinks.Location = new System.Drawing.Point(466, 75);
            this.panelWebLinks.Name = "panelWebLinks";
            this.panelWebLinks.Size = new System.Drawing.Size(199, 381);
            this.panelWebLinks.TabIndex = 54;
            // 
            // styledButtonNukacrypt
            // 
            this.styledButtonNukacrypt.BackColor = System.Drawing.Color.Transparent;
            this.styledButtonNukacrypt.BorderWidth = ((uint)(0u));
            this.styledButtonNukacrypt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.styledButtonNukacrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styledButtonNukacrypt.ForeColor = System.Drawing.Color.Black;
            this.styledButtonNukacrypt.Highlight = false;
            this.styledButtonNukacrypt.HighlightBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.styledButtonNukacrypt.Image = global::Fo76ini.Properties.Resources.nukacrypt_16;
            this.styledButtonNukacrypt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonNukacrypt.Location = new System.Drawing.Point(6, 204);
            this.styledButtonNukacrypt.Margin = new System.Windows.Forms.Padding(2);
            this.styledButtonNukacrypt.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.styledButtonNukacrypt.MouseOverBackColor = System.Drawing.Color.Silver;
            this.styledButtonNukacrypt.Name = "styledButtonNukacrypt";
            this.styledButtonNukacrypt.Padding = 2;
            this.styledButtonNukacrypt.Size = new System.Drawing.Size(190, 23);
            this.styledButtonNukacrypt.TabIndex = 22;
            this.styledButtonNukacrypt.Tag = "WebLink";
            this.styledButtonNukacrypt.Text = "NukaCrypt";
            this.styledButtonNukacrypt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonNukacrypt.UseVisualStyleBackColor = true;
            this.styledButtonNukacrypt.Click += new System.EventHandler(this.styledButtonNukacrypt_Click);
            // 
            // styledButtonxTranslator
            // 
            this.styledButtonxTranslator.BackColor = System.Drawing.Color.Transparent;
            this.styledButtonxTranslator.BorderWidth = ((uint)(0u));
            this.styledButtonxTranslator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.styledButtonxTranslator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styledButtonxTranslator.ForeColor = System.Drawing.Color.Black;
            this.styledButtonxTranslator.Highlight = false;
            this.styledButtonxTranslator.HighlightBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.styledButtonxTranslator.Image = global::Fo76ini.Properties.Resources.xTranslator_16px;
            this.styledButtonxTranslator.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonxTranslator.Location = new System.Drawing.Point(6, 231);
            this.styledButtonxTranslator.Margin = new System.Windows.Forms.Padding(2);
            this.styledButtonxTranslator.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.styledButtonxTranslator.MouseOverBackColor = System.Drawing.Color.Silver;
            this.styledButtonxTranslator.Name = "styledButtonxTranslator";
            this.styledButtonxTranslator.Padding = 2;
            this.styledButtonxTranslator.Size = new System.Drawing.Size(190, 23);
            this.styledButtonxTranslator.TabIndex = 21;
            this.styledButtonxTranslator.Tag = "WebLink";
            this.styledButtonxTranslator.Text = "xTranslator";
            this.styledButtonxTranslator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonxTranslator.UseVisualStyleBackColor = true;
            this.styledButtonxTranslator.Click += new System.EventHandler(this.styledButtonxTranslator_Click);
            // 
            // styledButtonNukesAndDragonsBuildPlanner
            // 
            this.styledButtonNukesAndDragonsBuildPlanner.BackColor = System.Drawing.Color.Transparent;
            this.styledButtonNukesAndDragonsBuildPlanner.BorderWidth = ((uint)(0u));
            this.styledButtonNukesAndDragonsBuildPlanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.styledButtonNukesAndDragonsBuildPlanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styledButtonNukesAndDragonsBuildPlanner.ForeColor = System.Drawing.Color.Black;
            this.styledButtonNukesAndDragonsBuildPlanner.Highlight = false;
            this.styledButtonNukesAndDragonsBuildPlanner.HighlightBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.styledButtonNukesAndDragonsBuildPlanner.Image = global::Fo76ini.Properties.Resources.nukesdragons_16;
            this.styledButtonNukesAndDragonsBuildPlanner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonNukesAndDragonsBuildPlanner.Location = new System.Drawing.Point(6, 177);
            this.styledButtonNukesAndDragonsBuildPlanner.Margin = new System.Windows.Forms.Padding(2);
            this.styledButtonNukesAndDragonsBuildPlanner.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.styledButtonNukesAndDragonsBuildPlanner.MouseOverBackColor = System.Drawing.Color.Silver;
            this.styledButtonNukesAndDragonsBuildPlanner.Name = "styledButtonNukesAndDragonsBuildPlanner";
            this.styledButtonNukesAndDragonsBuildPlanner.Padding = 2;
            this.styledButtonNukesAndDragonsBuildPlanner.Size = new System.Drawing.Size(190, 23);
            this.styledButtonNukesAndDragonsBuildPlanner.TabIndex = 20;
            this.styledButtonNukesAndDragonsBuildPlanner.Tag = "WebLink";
            this.styledButtonNukesAndDragonsBuildPlanner.Text = "N&D Build Planner";
            this.styledButtonNukesAndDragonsBuildPlanner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonNukesAndDragonsBuildPlanner.UseVisualStyleBackColor = true;
            this.styledButtonNukesAndDragonsBuildPlanner.Click += new System.EventHandler(this.styledButtonNukesAndDragonsBuildPlanner_Click);
            // 
            // styledButtonBethesdaNetStatus
            // 
            this.styledButtonBethesdaNetStatus.BackColor = System.Drawing.Color.Transparent;
            this.styledButtonBethesdaNetStatus.BorderWidth = ((uint)(0u));
            this.styledButtonBethesdaNetStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.styledButtonBethesdaNetStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styledButtonBethesdaNetStatus.ForeColor = System.Drawing.Color.Black;
            this.styledButtonBethesdaNetStatus.Highlight = false;
            this.styledButtonBethesdaNetStatus.HighlightBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.styledButtonBethesdaNetStatus.Image = global::Fo76ini.Properties.Resources.bethesda_16;
            this.styledButtonBethesdaNetStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonBethesdaNetStatus.Location = new System.Drawing.Point(6, 150);
            this.styledButtonBethesdaNetStatus.Margin = new System.Windows.Forms.Padding(2);
            this.styledButtonBethesdaNetStatus.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.styledButtonBethesdaNetStatus.MouseOverBackColor = System.Drawing.Color.Silver;
            this.styledButtonBethesdaNetStatus.Name = "styledButtonBethesdaNetStatus";
            this.styledButtonBethesdaNetStatus.Padding = 2;
            this.styledButtonBethesdaNetStatus.Size = new System.Drawing.Size(190, 23);
            this.styledButtonBethesdaNetStatus.TabIndex = 19;
            this.styledButtonBethesdaNetStatus.Tag = "WebLink";
            this.styledButtonBethesdaNetStatus.Text = "Bethesda.net status page";
            this.styledButtonBethesdaNetStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonBethesdaNetStatus.UseVisualStyleBackColor = true;
            this.styledButtonBethesdaNetStatus.Click += new System.EventHandler(this.styledButtonBethesdaNetStatus_Click);
            // 
            // styledButtonBugReports
            // 
            this.styledButtonBugReports.BackColor = System.Drawing.Color.Transparent;
            this.styledButtonBugReports.BorderWidth = ((uint)(0u));
            this.styledButtonBugReports.Cursor = System.Windows.Forms.Cursors.Hand;
            this.styledButtonBugReports.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styledButtonBugReports.ForeColor = System.Drawing.Color.Black;
            this.styledButtonBugReports.Highlight = false;
            this.styledButtonBugReports.HighlightBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.styledButtonBugReports.Image = global::Fo76ini.Properties.Resources.bug_3_16;
            this.styledButtonBugReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonBugReports.Location = new System.Drawing.Point(6, 110);
            this.styledButtonBugReports.Margin = new System.Windows.Forms.Padding(2);
            this.styledButtonBugReports.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.styledButtonBugReports.MouseOverBackColor = System.Drawing.Color.Silver;
            this.styledButtonBugReports.Name = "styledButtonBugReports";
            this.styledButtonBugReports.Padding = 2;
            this.styledButtonBugReports.Size = new System.Drawing.Size(190, 23);
            this.styledButtonBugReports.TabIndex = 18;
            this.styledButtonBugReports.Tag = "WebLink";
            this.styledButtonBugReports.Text = "Bug reports";
            this.styledButtonBugReports.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonBugReports.UseVisualStyleBackColor = true;
            this.styledButtonBugReports.Click += new System.EventHandler(this.styledButtonBugReports_Click);
            // 
            // styledButtonWikiAndGuides
            // 
            this.styledButtonWikiAndGuides.BackColor = System.Drawing.Color.Transparent;
            this.styledButtonWikiAndGuides.BorderWidth = ((uint)(0u));
            this.styledButtonWikiAndGuides.Cursor = System.Windows.Forms.Cursors.Hand;
            this.styledButtonWikiAndGuides.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styledButtonWikiAndGuides.ForeColor = System.Drawing.Color.Black;
            this.styledButtonWikiAndGuides.Highlight = false;
            this.styledButtonWikiAndGuides.HighlightBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.styledButtonWikiAndGuides.Image = global::Fo76ini.Properties.Resources.help_16;
            this.styledButtonWikiAndGuides.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonWikiAndGuides.Location = new System.Drawing.Point(6, 83);
            this.styledButtonWikiAndGuides.Margin = new System.Windows.Forms.Padding(2);
            this.styledButtonWikiAndGuides.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.styledButtonWikiAndGuides.MouseOverBackColor = System.Drawing.Color.Silver;
            this.styledButtonWikiAndGuides.Name = "styledButtonWikiAndGuides";
            this.styledButtonWikiAndGuides.Padding = 2;
            this.styledButtonWikiAndGuides.Size = new System.Drawing.Size(190, 23);
            this.styledButtonWikiAndGuides.TabIndex = 17;
            this.styledButtonWikiAndGuides.Tag = "WebLink";
            this.styledButtonWikiAndGuides.Text = "Wiki & guides";
            this.styledButtonWikiAndGuides.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonWikiAndGuides.UseVisualStyleBackColor = true;
            this.styledButtonWikiAndGuides.Click += new System.EventHandler(this.styledButtonWikiAndGuides_Click);
            // 
            // styledButtonGitHub
            // 
            this.styledButtonGitHub.BackColor = System.Drawing.Color.Transparent;
            this.styledButtonGitHub.BorderWidth = ((uint)(0u));
            this.styledButtonGitHub.Cursor = System.Windows.Forms.Cursors.Hand;
            this.styledButtonGitHub.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styledButtonGitHub.ForeColor = System.Drawing.Color.Black;
            this.styledButtonGitHub.Highlight = false;
            this.styledButtonGitHub.HighlightBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.styledButtonGitHub.Image = global::Fo76ini.Properties.Resources.github_16;
            this.styledButtonGitHub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonGitHub.Location = new System.Drawing.Point(6, 56);
            this.styledButtonGitHub.Margin = new System.Windows.Forms.Padding(2);
            this.styledButtonGitHub.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.styledButtonGitHub.MouseOverBackColor = System.Drawing.Color.Silver;
            this.styledButtonGitHub.Name = "styledButtonGitHub";
            this.styledButtonGitHub.Padding = 2;
            this.styledButtonGitHub.Size = new System.Drawing.Size(190, 23);
            this.styledButtonGitHub.TabIndex = 16;
            this.styledButtonGitHub.Tag = "WebLink";
            this.styledButtonGitHub.Text = "GitHub";
            this.styledButtonGitHub.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonGitHub.UseVisualStyleBackColor = true;
            this.styledButtonGitHub.Click += new System.EventHandler(this.styledButtonGitHub_Click);
            // 
            // styledButtonNexusMods
            // 
            this.styledButtonNexusMods.BackColor = System.Drawing.Color.Transparent;
            this.styledButtonNexusMods.BorderWidth = ((uint)(0u));
            this.styledButtonNexusMods.Cursor = System.Windows.Forms.Cursors.Hand;
            this.styledButtonNexusMods.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styledButtonNexusMods.ForeColor = System.Drawing.Color.Black;
            this.styledButtonNexusMods.Highlight = false;
            this.styledButtonNexusMods.HighlightBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.styledButtonNexusMods.Image = global::Fo76ini.Properties.Resources.nexus_16;
            this.styledButtonNexusMods.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonNexusMods.Location = new System.Drawing.Point(6, 29);
            this.styledButtonNexusMods.Margin = new System.Windows.Forms.Padding(2);
            this.styledButtonNexusMods.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.styledButtonNexusMods.MouseOverBackColor = System.Drawing.Color.Silver;
            this.styledButtonNexusMods.Name = "styledButtonNexusMods";
            this.styledButtonNexusMods.Padding = 2;
            this.styledButtonNexusMods.Size = new System.Drawing.Size(190, 23);
            this.styledButtonNexusMods.TabIndex = 15;
            this.styledButtonNexusMods.Tag = "WebLink";
            this.styledButtonNexusMods.Text = "NexusMods";
            this.styledButtonNexusMods.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonNexusMods.UseVisualStyleBackColor = true;
            this.styledButtonNexusMods.Click += new System.EventHandler(this.styledButtonNexusMods_Click);
            // 
            // pictureBoxButtonSupport
            // 
            this.pictureBoxButtonSupport.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxButtonSupport.ButtonText = null;
            this.pictureBoxButtonSupport.ButtonTextColor = System.Drawing.Color.Empty;
            this.pictureBoxButtonSupport.ButtonTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pictureBoxButtonSupport.Image = global::Fo76ini.Properties.Resources.BuyMeACoffee;
            this.pictureBoxButtonSupport.ImageHover = global::Fo76ini.Properties.Resources.BuyMeACoffee_hover;
            this.pictureBoxButtonSupport.Location = new System.Drawing.Point(6, 282);
            this.pictureBoxButtonSupport.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.pictureBoxButtonSupport.Name = "pictureBoxButtonSupport";
            this.pictureBoxButtonSupport.Size = new System.Drawing.Size(168, 34);
            this.pictureBoxButtonSupport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.pictureBoxButtonSupport.TabIndex = 13;
            this.pictureBoxButtonSupport.Click += new System.EventHandler(this.pictureBoxButtonSupport_Click);
            // 
            // labelWebLinks
            // 
            this.labelWebLinks.AutoSize = true;
            this.labelWebLinks.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWebLinks.Location = new System.Drawing.Point(3, 6);
            this.labelWebLinks.Margin = new System.Windows.Forms.Padding(3, 0, 3, 6);
            this.labelWebLinks.Name = "labelWebLinks";
            this.labelWebLinks.Size = new System.Drawing.Size(69, 17);
            this.labelWebLinks.TabIndex = 8;
            this.labelWebLinks.Text = "Web links";
            // 
            // panelContent
            // 
            this.panelContent.Controls.Add(this.pictureBoxScrapedServerStatus);
            this.panelContent.Controls.Add(this.buttonReloadServerStatus);
            this.panelContent.Controls.Add(this.labelScrapedServerStatus);
            this.panelContent.Controls.Add(this.labelServerStatus);
            this.panelContent.Controls.Add(this.styledButtonWhatsNew);
            this.panelContent.Controls.Add(this.labelVersion);
            this.panelContent.Controls.Add(this.labelTranslationBy);
            this.panelContent.Controls.Add(this.labelAuthorName);
            this.panelContent.Controls.Add(this.labelTranslationAuthor);
            this.panelContent.Controls.Add(this.labelConfigVersion);
            this.panelContent.Controls.Add(this.labelAuthor);
            this.panelContent.Controls.Add(this.pictureBoxSpinnerCheckForUpdates);
            this.panelContent.Location = new System.Drawing.Point(3, 75);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(457, 151);
            this.panelContent.TabIndex = 54;
            // 
            // pictureBoxScrapedServerStatus
            // 
            this.pictureBoxScrapedServerStatus.Image = global::Fo76ini.Properties.Resources.help_24;
            this.pictureBoxScrapedServerStatus.Location = new System.Drawing.Point(133, 49);
            this.pictureBoxScrapedServerStatus.Name = "pictureBoxScrapedServerStatus";
            this.pictureBoxScrapedServerStatus.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxScrapedServerStatus.TabIndex = 41;
            this.pictureBoxScrapedServerStatus.TabStop = false;
            // 
            // buttonReloadServerStatus
            // 
            this.buttonReloadServerStatus.FlatAppearance.BorderSize = 0;
            this.buttonReloadServerStatus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.buttonReloadServerStatus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver;
            this.buttonReloadServerStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReloadServerStatus.Image = global::Fo76ini.Properties.Resources.available_updates;
            this.buttonReloadServerStatus.Location = new System.Drawing.Point(194, 47);
            this.buttonReloadServerStatus.Name = "buttonReloadServerStatus";
            this.buttonReloadServerStatus.Size = new System.Drawing.Size(28, 28);
            this.buttonReloadServerStatus.TabIndex = 40;
            this.buttonReloadServerStatus.Tag = "SmallButton";
            this.buttonReloadServerStatus.UseVisualStyleBackColor = true;
            this.buttonReloadServerStatus.Click += new System.EventHandler(this.buttonReloadServerStatus_Click);
            // 
            // labelScrapedServerStatus
            // 
            this.labelScrapedServerStatus.AutoSize = true;
            this.labelScrapedServerStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelScrapedServerStatus.Location = new System.Drawing.Point(160, 52);
            this.labelScrapedServerStatus.Margin = new System.Windows.Forms.Padding(0);
            this.labelScrapedServerStatus.Name = "labelScrapedServerStatus";
            this.labelScrapedServerStatus.Size = new System.Drawing.Size(14, 17);
            this.labelScrapedServerStatus.TabIndex = 39;
            this.labelScrapedServerStatus.Text = "?";
            // 
            // labelServerStatus
            // 
            this.labelServerStatus.AutoSize = true;
            this.labelServerStatus.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerStatus.Location = new System.Drawing.Point(17, 52);
            this.labelServerStatus.Margin = new System.Windows.Forms.Padding(3);
            this.labelServerStatus.Name = "labelServerStatus";
            this.labelServerStatus.Size = new System.Drawing.Size(92, 17);
            this.labelServerStatus.TabIndex = 38;
            this.labelServerStatus.Text = "Server status:";
            // 
            // styledButtonWhatsNew
            // 
            this.styledButtonWhatsNew.BackColor = System.Drawing.Color.Transparent;
            this.styledButtonWhatsNew.BorderWidth = ((uint)(0u));
            this.styledButtonWhatsNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.styledButtonWhatsNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styledButtonWhatsNew.ForeColor = System.Drawing.Color.DarkOrange;
            this.styledButtonWhatsNew.Highlight = false;
            this.styledButtonWhatsNew.Image = global::Fo76ini.Properties.Resources.report_3_16;
            this.styledButtonWhatsNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonWhatsNew.Location = new System.Drawing.Point(20, 110);
            this.styledButtonWhatsNew.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.styledButtonWhatsNew.MouseOverBackColor = System.Drawing.Color.Silver;
            this.styledButtonWhatsNew.Name = "styledButtonWhatsNew";
            this.styledButtonWhatsNew.Padding = 2;
            this.styledButtonWhatsNew.Size = new System.Drawing.Size(413, 23);
            this.styledButtonWhatsNew.TabIndex = 20;
            this.styledButtonWhatsNew.Tag = "";
            this.styledButtonWhatsNew.Text = "What\'s new?";
            this.styledButtonWhatsNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonWhatsNew.UseVisualStyleBackColor = true;
            this.styledButtonWhatsNew.Click += new System.EventHandler(this.styledButtonWhatsNew_Click);
            // 
            // pictureBoxSpinnerCheckForUpdates
            // 
            this.pictureBoxSpinnerCheckForUpdates.Image = global::Fo76ini.Properties.Resources.Spinner_24;
            this.pictureBoxSpinnerCheckForUpdates.Location = new System.Drawing.Point(100, 2);
            this.pictureBoxSpinnerCheckForUpdates.Name = "pictureBoxSpinnerCheckForUpdates";
            this.pictureBoxSpinnerCheckForUpdates.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxSpinnerCheckForUpdates.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSpinnerCheckForUpdates.TabIndex = 37;
            this.pictureBoxSpinnerCheckForUpdates.TabStop = false;
            this.pictureBoxSpinnerCheckForUpdates.Visible = false;
            // 
            // tabPageWhatsNew
            // 
            this.tabPageWhatsNew.BackColor = System.Drawing.Color.White;
            this.tabPageWhatsNew.Controls.Add(this.styledButtonGoBack);
            this.tabPageWhatsNew.Controls.Add(this.webBrowserWhatsNew);
            this.tabPageWhatsNew.Location = new System.Drawing.Point(4, 22);
            this.tabPageWhatsNew.Name = "tabPageWhatsNew";
            this.tabPageWhatsNew.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWhatsNew.Size = new System.Drawing.Size(668, 473);
            this.tabPageWhatsNew.TabIndex = 1;
            this.tabPageWhatsNew.Text = "tabPageWhatsNew";
            // 
            // styledButtonGoBack
            // 
            this.styledButtonGoBack.BorderWidth = ((uint)(1u));
            this.styledButtonGoBack.ForeColor = System.Drawing.Color.Black;
            this.styledButtonGoBack.Highlight = false;
            this.styledButtonGoBack.Image = global::Fo76ini.Properties.Resources.arrow_left_16;
            this.styledButtonGoBack.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonGoBack.Location = new System.Drawing.Point(24, 10);
            this.styledButtonGoBack.Name = "styledButtonGoBack";
            this.styledButtonGoBack.Padding = 6;
            this.styledButtonGoBack.Size = new System.Drawing.Size(119, 23);
            this.styledButtonGoBack.TabIndex = 54;
            this.styledButtonGoBack.Text = "Go back";
            this.styledButtonGoBack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonGoBack.UseVisualStyleBackColor = true;
            this.styledButtonGoBack.Click += new System.EventHandler(this.styledButtonGoBack_Click);
            // 
            // backgroundWorkerScrapeServerStatus
            // 
            this.backgroundWorkerScrapeServerStatus.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerScrapeServerStatus_DoWork);
            this.backgroundWorkerScrapeServerStatus.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerScrapeServerStatus_RunWorkerCompleted);
            // 
            // timerReenableRefreshServerStatus
            // 
            this.timerReenableRefreshServerStatus.Interval = 10000;
            this.timerReenableRefreshServerStatus.Tick += new System.EventHandler(this.timerReenableRefreshServerStatus_Tick);
            // 
            // pictureBoxSpacer1
            // 
            this.pictureBoxSpacer1.BackColor = System.Drawing.Color.Silver;
            this.pictureBoxSpacer1.Location = new System.Drawing.Point(6, 141);
            this.pictureBoxSpacer1.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBoxSpacer1.Name = "pictureBoxSpacer1";
            this.pictureBoxSpacer1.Size = new System.Drawing.Size(187, 1);
            this.pictureBoxSpacer1.TabIndex = 55;
            this.pictureBoxSpacer1.TabStop = false;
            // 
            // pictureBoxSpacer2
            // 
            this.pictureBoxSpacer2.BackColor = System.Drawing.Color.Silver;
            this.pictureBoxSpacer2.Location = new System.Drawing.Point(6, 262);
            this.pictureBoxSpacer2.Margin = new System.Windows.Forms.Padding(6);
            this.pictureBoxSpacer2.Name = "pictureBoxSpacer2";
            this.pictureBoxSpacer2.Size = new System.Drawing.Size(187, 1);
            this.pictureBoxSpacer2.TabIndex = 56;
            this.pictureBoxSpacer2.TabStop = false;
            // 
            // UserControlHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlWithoutHeader1);
            this.Controls.Add(this.userControlHero);
            this.Name = "UserControlHome";
            this.Size = new System.Drawing.Size(676, 670);
            this.panelUpdate.ResumeLayout(false);
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.tabControlWithoutHeader1.ResumeLayout(false);
            this.tabPageHome.ResumeLayout(false);
            this.panelWebLinks.ResumeLayout(false);
            this.panelWebLinks.PerformLayout();
            this.panelContent.ResumeLayout(false);
            this.panelContent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxScrapedServerStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerCheckForUpdates)).EndInit();
            this.tabPageWhatsNew.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpacer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpacer2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserWhatsNew;
        private System.Windows.Forms.Panel panelUpdate;
        private Controls.PictureBoxButton pictureBoxButtonUpdate;
        private System.Windows.Forms.Label labelNewVersion;
        private System.Windows.Forms.LinkLabel linkLabelManualDownloadPage;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.PictureBox pictureBoxSpinnerCheckForUpdates;
        private System.Windows.Forms.Label labelConfigVersion;
        public System.Windows.Forms.Label labelTranslationAuthor;
        private System.Windows.Forms.Label labelAuthorName;
        public System.Windows.Forms.Label labelTranslationBy;
        private Controls.UserControlHero userControlHero;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGetLatestVersion;
        private Controls.TabControlWithoutHeader tabControlWithoutHeader1;
        private System.Windows.Forms.TabPage tabPageHome;
        private System.Windows.Forms.TabPage tabPageWhatsNew;
        private Controls.StyledButton styledButtonGoBack;
        private System.Windows.Forms.Panel panelWebLinks;
        private System.Windows.Forms.Label labelWebLinks;
        private System.Windows.Forms.Panel panelContent;
        private Controls.PictureBoxButton pictureBoxButtonSupport;
        private Controls.StyledButton styledButtonNexusMods;
        private Controls.StyledButton styledButtonGitHub;
        private Controls.StyledButton styledButtonBethesdaNetStatus;
        private Controls.StyledButton styledButtonBugReports;
        private Controls.StyledButton styledButtonWikiAndGuides;
        private Controls.StyledButton styledButtonWhatsNew;
        private Controls.StyledButton styledButtonNukesAndDragonsBuildPlanner;
        private Controls.StyledButton styledButtonxTranslator;
        private System.Windows.Forms.Label labelScrapedServerStatus;
        public System.Windows.Forms.Label labelServerStatus;
        private System.Windows.Forms.Button buttonReloadServerStatus;
        private System.Windows.Forms.PictureBox pictureBoxScrapedServerStatus;
        private System.ComponentModel.BackgroundWorker backgroundWorkerScrapeServerStatus;
        private System.Windows.Forms.Timer timerReenableRefreshServerStatus;
        private Controls.StyledButton styledButtonNukacrypt;
        private System.Windows.Forms.PictureBox pictureBoxSpacer2;
        private System.Windows.Forms.PictureBox pictureBoxSpacer1;
    }
}
