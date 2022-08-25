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
            this.webBrowserWhatsNew = new System.Windows.Forms.WebBrowser();
            this.panelUpdate = new System.Windows.Forms.Panel();
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
            this.labelWebLinks = new System.Windows.Forms.Label();
            this.panelContent = new System.Windows.Forms.Panel();
            this.tabPageWhatsNew = new System.Windows.Forms.TabPage();
            this.styledButtonNukesAndDragonsBuildPlanner = new Fo76ini.Controls.StyledButton();
            this.styledButtonBethesdaNetStatus = new Fo76ini.Controls.StyledButton();
            this.styledButtonBugReports = new Fo76ini.Controls.StyledButton();
            this.styledButtonWikiAndGuides = new Fo76ini.Controls.StyledButton();
            this.styledButtonGitHub = new Fo76ini.Controls.StyledButton();
            this.styledButtonNexusMods = new Fo76ini.Controls.StyledButton();
            this.pictureBoxButtonSupport = new Fo76ini.Controls.PictureBoxButton();
            this.styledButtonWhatsNew = new Fo76ini.Controls.StyledButton();
            this.pictureBoxSpinnerCheckForUpdates = new System.Windows.Forms.PictureBox();
            this.pictureBoxButtonUpdate = new Fo76ini.Controls.PictureBoxButton();
            this.styledButtonGoBack = new Fo76ini.Controls.StyledButton();
            this.styledButtonxTranslator = new Fo76ini.Controls.StyledButton();
            this.panelUpdate.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.tabControlWithoutHeader1.SuspendLayout();
            this.tabPageHome.SuspendLayout();
            this.panelWebLinks.SuspendLayout();
            this.panelContent.SuspendLayout();
            this.tabPageWhatsNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerCheckForUpdates)).BeginInit();
            this.SuspendLayout();
            // 
            // webBrowserWhatsNew
            // 
            this.webBrowserWhatsNew.AllowNavigation = false;
            this.webBrowserWhatsNew.AllowWebBrowserDrop = false;
            this.webBrowserWhatsNew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserWhatsNew.Location = new System.Drawing.Point(3, 43);
            this.webBrowserWhatsNew.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserWhatsNew.Name = "webBrowserWhatsNew";
            this.webBrowserWhatsNew.ScriptErrorsSuppressed = true;
            this.webBrowserWhatsNew.Size = new System.Drawing.Size(662, 435);
            this.webBrowserWhatsNew.TabIndex = 52;
            // 
            // panelUpdate
            // 
            this.panelUpdate.Controls.Add(this.pictureBoxButtonUpdate);
            this.panelUpdate.Controls.Add(this.labelNewVersion);
            this.panelUpdate.Controls.Add(this.linkLabelManualDownloadPage);
            this.panelUpdate.Location = new System.Drawing.Point(3, 208);
            this.panelUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.panelUpdate.Name = "panelUpdate";
            this.panelUpdate.Size = new System.Drawing.Size(295, 110);
            this.panelUpdate.TabIndex = 50;
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
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(58, 17);
            this.labelVersion.TabIndex = 7;
            this.labelVersion.Text = "Version:";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.Location = new System.Drawing.Point(17, 24);
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
            this.labelTranslationAuthor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTranslationAuthor.Location = new System.Drawing.Point(130, 41);
            this.labelTranslationAuthor.Name = "labelTranslationAuthor";
            this.labelTranslationAuthor.Size = new System.Drawing.Size(177, 17);
            this.labelTranslationAuthor.TabIndex = 12;
            this.labelTranslationAuthor.Text = "FelisDiligens (aka. datasnake)";
            // 
            // labelAuthorName
            // 
            this.labelAuthorName.AutoSize = true;
            this.labelAuthorName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthorName.Location = new System.Drawing.Point(130, 23);
            this.labelAuthorName.Name = "labelAuthorName";
            this.labelAuthorName.Size = new System.Drawing.Size(177, 17);
            this.labelAuthorName.TabIndex = 10;
            this.labelAuthorName.Text = "FelisDiligens (aka. datasnake)";
            // 
            // labelTranslationBy
            // 
            this.labelTranslationBy.AutoSize = true;
            this.labelTranslationBy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTranslationBy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTranslationBy.Location = new System.Drawing.Point(17, 42);
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
            this.tabPageHome.UseVisualStyleBackColor = true;
            // 
            // panelWebLinks
            // 
            this.panelWebLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
            this.panelContent.Size = new System.Drawing.Size(457, 115);
            this.panelContent.TabIndex = 54;
            // 
            // tabPageWhatsNew
            // 
            this.tabPageWhatsNew.Controls.Add(this.styledButtonGoBack);
            this.tabPageWhatsNew.Controls.Add(this.webBrowserWhatsNew);
            this.tabPageWhatsNew.Location = new System.Drawing.Point(4, 22);
            this.tabPageWhatsNew.Name = "tabPageWhatsNew";
            this.tabPageWhatsNew.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWhatsNew.Size = new System.Drawing.Size(668, 473);
            this.tabPageWhatsNew.TabIndex = 1;
            this.tabPageWhatsNew.Text = "tabPageWhatsNew";
            this.tabPageWhatsNew.UseVisualStyleBackColor = true;
            // 
            // styledButtonNukesAndDragonsBuildPlanner
            // 
            this.styledButtonNukesAndDragonsBuildPlanner.BackColor = System.Drawing.Color.Transparent;
            this.styledButtonNukesAndDragonsBuildPlanner.BorderWidth = ((uint)(0u));
            this.styledButtonNukesAndDragonsBuildPlanner.Cursor = System.Windows.Forms.Cursors.Hand;
            this.styledButtonNukesAndDragonsBuildPlanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styledButtonNukesAndDragonsBuildPlanner.ForeColor = System.Drawing.Color.Black;
            this.styledButtonNukesAndDragonsBuildPlanner.Highlight = false;
            this.styledButtonNukesAndDragonsBuildPlanner.Image = global::Fo76ini.Properties.Resources.nukesdragons_16;
            this.styledButtonNukesAndDragonsBuildPlanner.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonNukesAndDragonsBuildPlanner.Location = new System.Drawing.Point(6, 164);
            this.styledButtonNukesAndDragonsBuildPlanner.Margin = new System.Windows.Forms.Padding(2);
            this.styledButtonNukesAndDragonsBuildPlanner.Name = "styledButtonNukesAndDragonsBuildPlanner";
            this.styledButtonNukesAndDragonsBuildPlanner.Padding = 2;
            this.styledButtonNukesAndDragonsBuildPlanner.Size = new System.Drawing.Size(190, 23);
            this.styledButtonNukesAndDragonsBuildPlanner.TabIndex = 20;
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
            this.styledButtonBethesdaNetStatus.Image = global::Fo76ini.Properties.Resources.bethesda_16;
            this.styledButtonBethesdaNetStatus.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonBethesdaNetStatus.Location = new System.Drawing.Point(6, 137);
            this.styledButtonBethesdaNetStatus.Margin = new System.Windows.Forms.Padding(2);
            this.styledButtonBethesdaNetStatus.Name = "styledButtonBethesdaNetStatus";
            this.styledButtonBethesdaNetStatus.Padding = 2;
            this.styledButtonBethesdaNetStatus.Size = new System.Drawing.Size(190, 23);
            this.styledButtonBethesdaNetStatus.TabIndex = 19;
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
            this.styledButtonBugReports.Image = global::Fo76ini.Properties.Resources.bug_3_16;
            this.styledButtonBugReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonBugReports.Location = new System.Drawing.Point(6, 110);
            this.styledButtonBugReports.Margin = new System.Windows.Forms.Padding(2);
            this.styledButtonBugReports.Name = "styledButtonBugReports";
            this.styledButtonBugReports.Padding = 2;
            this.styledButtonBugReports.Size = new System.Drawing.Size(190, 23);
            this.styledButtonBugReports.TabIndex = 18;
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
            this.styledButtonWikiAndGuides.Image = global::Fo76ini.Properties.Resources.help_16;
            this.styledButtonWikiAndGuides.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonWikiAndGuides.Location = new System.Drawing.Point(6, 83);
            this.styledButtonWikiAndGuides.Margin = new System.Windows.Forms.Padding(2);
            this.styledButtonWikiAndGuides.Name = "styledButtonWikiAndGuides";
            this.styledButtonWikiAndGuides.Padding = 2;
            this.styledButtonWikiAndGuides.Size = new System.Drawing.Size(190, 23);
            this.styledButtonWikiAndGuides.TabIndex = 17;
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
            this.styledButtonGitHub.Image = global::Fo76ini.Properties.Resources.github_16;
            this.styledButtonGitHub.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonGitHub.Location = new System.Drawing.Point(6, 56);
            this.styledButtonGitHub.Margin = new System.Windows.Forms.Padding(2);
            this.styledButtonGitHub.Name = "styledButtonGitHub";
            this.styledButtonGitHub.Padding = 2;
            this.styledButtonGitHub.Size = new System.Drawing.Size(190, 23);
            this.styledButtonGitHub.TabIndex = 16;
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
            this.styledButtonNexusMods.Image = global::Fo76ini.Properties.Resources.nexus_16;
            this.styledButtonNexusMods.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonNexusMods.Location = new System.Drawing.Point(6, 29);
            this.styledButtonNexusMods.Margin = new System.Windows.Forms.Padding(2);
            this.styledButtonNexusMods.Name = "styledButtonNexusMods";
            this.styledButtonNexusMods.Padding = 2;
            this.styledButtonNexusMods.Size = new System.Drawing.Size(190, 23);
            this.styledButtonNexusMods.TabIndex = 15;
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
            this.pictureBoxButtonSupport.Location = new System.Drawing.Point(6, 229);
            this.pictureBoxButtonSupport.Margin = new System.Windows.Forms.Padding(3, 13, 3, 3);
            this.pictureBoxButtonSupport.Name = "pictureBoxButtonSupport";
            this.pictureBoxButtonSupport.Size = new System.Drawing.Size(168, 34);
            this.pictureBoxButtonSupport.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
            this.pictureBoxButtonSupport.TabIndex = 13;
            this.pictureBoxButtonSupport.Click += new System.EventHandler(this.pictureBoxButtonSupport_Click);
            // 
            // styledButtonWhatsNew
            // 
            this.styledButtonWhatsNew.BackColor = System.Drawing.Color.Transparent;
            this.styledButtonWhatsNew.BorderMouseDownColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.styledButtonWhatsNew.BorderMouseOverColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.styledButtonWhatsNew.BorderWidth = ((uint)(0u));
            this.styledButtonWhatsNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.styledButtonWhatsNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styledButtonWhatsNew.ForeColor = System.Drawing.Color.DarkOrange;
            this.styledButtonWhatsNew.Highlight = false;
            this.styledButtonWhatsNew.Image = global::Fo76ini.Properties.Resources.report_3_16;
            this.styledButtonWhatsNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonWhatsNew.Location = new System.Drawing.Point(20, 76);
            this.styledButtonWhatsNew.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.styledButtonWhatsNew.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.styledButtonWhatsNew.Name = "styledButtonWhatsNew";
            this.styledButtonWhatsNew.Padding = 2;
            this.styledButtonWhatsNew.Size = new System.Drawing.Size(202, 23);
            this.styledButtonWhatsNew.TabIndex = 20;
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
            // styledButtonxTranslator
            // 
            this.styledButtonxTranslator.BackColor = System.Drawing.Color.Transparent;
            this.styledButtonxTranslator.BorderWidth = ((uint)(0u));
            this.styledButtonxTranslator.Cursor = System.Windows.Forms.Cursors.Hand;
            this.styledButtonxTranslator.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.styledButtonxTranslator.ForeColor = System.Drawing.Color.Black;
            this.styledButtonxTranslator.Highlight = false;
            this.styledButtonxTranslator.Image = global::Fo76ini.Properties.Resources.xTranslator_16px;
            this.styledButtonxTranslator.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonxTranslator.Location = new System.Drawing.Point(6, 191);
            this.styledButtonxTranslator.Margin = new System.Windows.Forms.Padding(2);
            this.styledButtonxTranslator.Name = "styledButtonxTranslator";
            this.styledButtonxTranslator.Padding = 2;
            this.styledButtonxTranslator.Size = new System.Drawing.Size(190, 23);
            this.styledButtonxTranslator.TabIndex = 21;
            this.styledButtonxTranslator.Text = "xTranslator";
            this.styledButtonxTranslator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.styledButtonxTranslator.UseVisualStyleBackColor = true;
            this.styledButtonxTranslator.Click += new System.EventHandler(this.styledButtonxTranslator_Click);
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
            this.tabPageWhatsNew.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerCheckForUpdates)).EndInit();
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
    }
}
