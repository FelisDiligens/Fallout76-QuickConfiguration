namespace Fo76ini
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.timerCheckFiles = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerLoadGallery = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerGetLatestVersion = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerDownloadRTF = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxLoadingGIF = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new Fo76ini.Controls.TabControlWithoutHeader();
            this.tabPageHome = new System.Windows.Forms.TabPage();
            this.userControlHero = new Fo76ini.Controls.UserControlHero();
            this.panelWhatsNew = new System.Windows.Forms.Panel();
            this.richTextBoxWhatsNew = new System.Windows.Forms.RichTextBox();
            this.panelUpdate = new System.Windows.Forms.Panel();
            this.pictureBoxButtonUpdate = new Fo76ini.Controls.PictureBoxButton();
            this.labelNewVersion = new System.Windows.Forms.Label();
            this.linkLabelManualDownloadPage = new System.Windows.Forms.LinkLabel();
            this.pictureBoxSpinnerCheckForUpdates = new System.Windows.Forms.PictureBox();
            this.labelTranslationAuthor = new System.Windows.Forms.Label();
            this.labelTranslationBy = new System.Windows.Forms.Label();
            this.labelAuthorName = new System.Windows.Forms.Label();
            this.labelConfigVersion = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.tabPageTweaks = new System.Windows.Forms.TabPage();
            this.userControlTweaks = new Fo76ini.Forms.FormMain.UserControlTweaks();
            this.tabPagePipBoy = new System.Windows.Forms.TabPage();
            this.userControlPipboy = new Fo76ini.Forms.FormMain.UserControlPipboy();
            this.tabPageGallery = new System.Windows.Forms.TabPage();
            this.userControlGallery = new Fo76ini.Forms.FormMain.UserControlGallery();
            this.tabPageCustom = new System.Windows.Forms.TabPage();
            this.userControlCustom = new Fo76ini.Forms.FormMain.Tabs.UserControlCustom();
            this.tabPageSettings = new System.Windows.Forms.TabPage();
            this.userControlSettings = new Fo76ini.Forms.FormMain.Tabs.UserControlSettings();
            this.tabPageProfiles = new System.Windows.Forms.TabPage();
            this.userControlProfiles = new Fo76ini.Forms.FormMain.Tabs.UserControlProfiles();
            this.tabPageNexusMods = new System.Windows.Forms.TabPage();
            this.userControlNexusMods = new Fo76ini.Forms.FormMain.Tabs.UserControlNexusMods();
            this.userControlSideNav = new Fo76ini.Forms.FormMain.UserControlSideNav();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingGIF)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageHome.SuspendLayout();
            this.panelWhatsNew.SuspendLayout();
            this.panelUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerCheckForUpdates)).BeginInit();
            this.tabPageTweaks.SuspendLayout();
            this.tabPagePipBoy.SuspendLayout();
            this.tabPageGallery.SuspendLayout();
            this.tabPageCustom.SuspendLayout();
            this.tabPageSettings.SuspendLayout();
            this.tabPageProfiles.SuspendLayout();
            this.tabPageNexusMods.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 20000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // colorDialog
            // 
            this.colorDialog.AnyColor = true;
            this.colorDialog.FullOpen = true;
            this.colorDialog.SolidColorOnly = true;
            // 
            // timerCheckFiles
            // 
            this.timerCheckFiles.Interval = 5000;
            this.timerCheckFiles.Tick += new System.EventHandler(this.timerCheckFiles_Tick);
            // 
            // backgroundWorkerGetLatestVersion
            // 
            this.backgroundWorkerGetLatestVersion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerGetLatestVersion_DoWork);
            // 
            // backgroundWorkerDownloadRTF
            // 
            this.backgroundWorkerDownloadRTF.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDownloadRTF_DoWork);
            this.backgroundWorkerDownloadRTF.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDownloadRTF_RunWorkerCompleted);
            // 
            // pictureBoxLoadingGIF
            // 
            this.pictureBoxLoadingGIF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLoadingGIF.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxLoadingGIF.Image = global::Fo76ini.Properties.Resources.Spinner_200;
            this.pictureBoxLoadingGIF.Location = new System.Drawing.Point(0, -2);
            this.pictureBoxLoadingGIF.Name = "pictureBoxLoadingGIF";
            this.pictureBoxLoadingGIF.Size = new System.Drawing.Size(16, 613);
            this.pictureBoxLoadingGIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLoadingGIF.TabIndex = 15;
            this.pictureBoxLoadingGIF.TabStop = false;
            this.pictureBoxLoadingGIF.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageHome);
            this.tabControl1.Controls.Add(this.tabPageTweaks);
            this.tabControl1.Controls.Add(this.tabPagePipBoy);
            this.tabControl1.Controls.Add(this.tabPageGallery);
            this.tabControl1.Controls.Add(this.tabPageCustom);
            this.tabControl1.Controls.Add(this.tabPageSettings);
            this.tabControl1.Controls.Add(this.tabPageProfiles);
            this.tabControl1.Controls.Add(this.tabPageNexusMods);
            this.tabControl1.Location = new System.Drawing.Point(200, -2);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(684, 613);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPageHome
            // 
            this.tabPageHome.AutoScroll = true;
            this.tabPageHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPageHome.Controls.Add(this.userControlHero);
            this.tabPageHome.Controls.Add(this.panelWhatsNew);
            this.tabPageHome.Controls.Add(this.panelUpdate);
            this.tabPageHome.Controls.Add(this.pictureBoxSpinnerCheckForUpdates);
            this.tabPageHome.Controls.Add(this.labelTranslationAuthor);
            this.tabPageHome.Controls.Add(this.labelTranslationBy);
            this.tabPageHome.Controls.Add(this.labelAuthorName);
            this.tabPageHome.Controls.Add(this.labelConfigVersion);
            this.tabPageHome.Controls.Add(this.labelAuthor);
            this.tabPageHome.Controls.Add(this.labelVersion);
            this.tabPageHome.Controls.Add(this.labelDescription);
            this.tabPageHome.Controls.Add(this.labelWelcome);
            this.tabPageHome.Location = new System.Drawing.Point(4, 22);
            this.tabPageHome.Name = "tabPageHome";
            this.tabPageHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHome.Size = new System.Drawing.Size(676, 557);
            this.tabPageHome.TabIndex = 4;
            this.tabPageHome.Text = "Home";
            this.tabPageHome.UseVisualStyleBackColor = true;
            // 
            // userControlHero
            // 
            this.userControlHero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlHero.Location = new System.Drawing.Point(0, 0);
            this.userControlHero.Margin = new System.Windows.Forms.Padding(0);
            this.userControlHero.Name = "userControlHero";
            this.userControlHero.Size = new System.Drawing.Size(676, 168);
            this.userControlHero.TabIndex = 46;
            // 
            // panelWhatsNew
            // 
            this.panelWhatsNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWhatsNew.BackColor = System.Drawing.Color.Silver;
            this.panelWhatsNew.Controls.Add(this.richTextBoxWhatsNew);
            this.panelWhatsNew.Location = new System.Drawing.Point(370, 168);
            this.panelWhatsNew.Margin = new System.Windows.Forms.Padding(0);
            this.panelWhatsNew.Name = "panelWhatsNew";
            this.panelWhatsNew.Size = new System.Drawing.Size(306, 389);
            this.panelWhatsNew.TabIndex = 45;
            // 
            // richTextBoxWhatsNew
            // 
            this.richTextBoxWhatsNew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxWhatsNew.BackColor = System.Drawing.Color.Silver;
            this.richTextBoxWhatsNew.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxWhatsNew.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBoxWhatsNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBoxWhatsNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.richTextBoxWhatsNew.Location = new System.Drawing.Point(10, 10);
            this.richTextBoxWhatsNew.Margin = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.richTextBoxWhatsNew.Name = "richTextBoxWhatsNew";
            this.richTextBoxWhatsNew.ReadOnly = true;
            this.richTextBoxWhatsNew.Size = new System.Drawing.Size(292, 379);
            this.richTextBoxWhatsNew.TabIndex = 43;
            this.richTextBoxWhatsNew.Text = "\n\n\n                          Loading \"What\'s new?\" content...";
            // 
            // panelUpdate
            // 
            this.panelUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelUpdate.Controls.Add(this.pictureBoxButtonUpdate);
            this.panelUpdate.Controls.Add(this.labelNewVersion);
            this.panelUpdate.Controls.Add(this.linkLabelManualDownloadPage);
            this.panelUpdate.Location = new System.Drawing.Point(7, 334);
            this.panelUpdate.Name = "panelUpdate";
            this.panelUpdate.Size = new System.Drawing.Size(299, 110);
            this.panelUpdate.TabIndex = 39;
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
            this.pictureBoxButtonUpdate.Click += new System.EventHandler(this.buttonUpdateNow_Click);
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
            // pictureBoxSpinnerCheckForUpdates
            // 
            this.pictureBoxSpinnerCheckForUpdates.Image = global::Fo76ini.Properties.Resources.Spinner_24;
            this.pictureBoxSpinnerCheckForUpdates.Location = new System.Drawing.Point(95, 262);
            this.pictureBoxSpinnerCheckForUpdates.Name = "pictureBoxSpinnerCheckForUpdates";
            this.pictureBoxSpinnerCheckForUpdates.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxSpinnerCheckForUpdates.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSpinnerCheckForUpdates.TabIndex = 37;
            this.pictureBoxSpinnerCheckForUpdates.TabStop = false;
            this.pictureBoxSpinnerCheckForUpdates.Visible = false;
            // 
            // labelTranslationAuthor
            // 
            this.labelTranslationAuthor.AutoSize = true;
            this.labelTranslationAuthor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTranslationAuthor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTranslationAuthor.Location = new System.Drawing.Point(125, 301);
            this.labelTranslationAuthor.Name = "labelTranslationAuthor";
            this.labelTranslationAuthor.Size = new System.Drawing.Size(177, 17);
            this.labelTranslationAuthor.TabIndex = 12;
            this.labelTranslationAuthor.Text = "FelisDiligens (aka. datasnake)";
            // 
            // labelTranslationBy
            // 
            this.labelTranslationBy.AutoSize = true;
            this.labelTranslationBy.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTranslationBy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTranslationBy.Location = new System.Drawing.Point(12, 302);
            this.labelTranslationBy.Name = "labelTranslationBy";
            this.labelTranslationBy.Size = new System.Drawing.Size(100, 17);
            this.labelTranslationBy.TabIndex = 11;
            this.labelTranslationBy.Text = "Translation by:";
            // 
            // labelAuthorName
            // 
            this.labelAuthorName.AutoSize = true;
            this.labelAuthorName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthorName.Location = new System.Drawing.Point(125, 283);
            this.labelAuthorName.Name = "labelAuthorName";
            this.labelAuthorName.Size = new System.Drawing.Size(177, 17);
            this.labelAuthorName.TabIndex = 10;
            this.labelAuthorName.Text = "FelisDiligens (aka. datasnake)";
            // 
            // labelConfigVersion
            // 
            this.labelConfigVersion.AutoSize = true;
            this.labelConfigVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfigVersion.Location = new System.Drawing.Point(125, 266);
            this.labelConfigVersion.Name = "labelConfigVersion";
            this.labelConfigVersion.Size = new System.Drawing.Size(14, 17);
            this.labelConfigVersion.TabIndex = 9;
            this.labelConfigVersion.Text = "?";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.Location = new System.Drawing.Point(12, 284);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(56, 17);
            this.labelAuthor.TabIndex = 8;
            this.labelAuthor.Text = "Author:";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(12, 266);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(58, 17);
            this.labelVersion.TabIndex = 7;
            this.labelVersion.Text = "Version:";
            // 
            // labelDescription
            // 
            this.labelDescription.BackColor = System.Drawing.Color.Transparent;
            this.labelDescription.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(12, 213);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(355, 53);
            this.labelDescription.TabIndex = 6;
            this.labelDescription.Text = "This tool allows you to change various game settings and install mods.";
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWelcome.Location = new System.Drawing.Point(10, 183);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Size = new System.Drawing.Size(326, 30);
            this.labelWelcome.TabIndex = 0;
            this.labelWelcome.Text = "Welcome to Quick Configuration";
            // 
            // tabPageTweaks
            // 
            this.tabPageTweaks.Controls.Add(this.userControlTweaks);
            this.tabPageTweaks.Location = new System.Drawing.Point(4, 22);
            this.tabPageTweaks.Name = "tabPageTweaks";
            this.tabPageTweaks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTweaks.Size = new System.Drawing.Size(676, 557);
            this.tabPageTweaks.TabIndex = 11;
            this.tabPageTweaks.Text = "Tweaks";
            this.tabPageTweaks.UseVisualStyleBackColor = true;
            // 
            // userControlTweaks
            // 
            this.userControlTweaks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlTweaks.Location = new System.Drawing.Point(0, 0);
            this.userControlTweaks.Name = "userControlTweaks";
            this.userControlTweaks.Size = new System.Drawing.Size(676, 557);
            this.userControlTweaks.TabIndex = 0;
            // 
            // tabPagePipBoy
            // 
            this.tabPagePipBoy.Controls.Add(this.userControlPipboy);
            this.tabPagePipBoy.Location = new System.Drawing.Point(4, 22);
            this.tabPagePipBoy.Name = "tabPagePipBoy";
            this.tabPagePipBoy.Size = new System.Drawing.Size(676, 557);
            this.tabPagePipBoy.TabIndex = 12;
            this.tabPagePipBoy.Text = "Pip-Boy";
            this.tabPagePipBoy.UseVisualStyleBackColor = true;
            // 
            // userControlPipboy
            // 
            this.userControlPipboy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlPipboy.Location = new System.Drawing.Point(0, 0);
            this.userControlPipboy.Name = "userControlPipboy";
            this.userControlPipboy.Size = new System.Drawing.Size(676, 557);
            this.userControlPipboy.TabIndex = 0;
            // 
            // tabPageGallery
            // 
            this.tabPageGallery.Controls.Add(this.userControlGallery);
            this.tabPageGallery.Location = new System.Drawing.Point(4, 22);
            this.tabPageGallery.Name = "tabPageGallery";
            this.tabPageGallery.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGallery.Size = new System.Drawing.Size(676, 557);
            this.tabPageGallery.TabIndex = 10;
            this.tabPageGallery.Text = "Gallery";
            this.tabPageGallery.UseVisualStyleBackColor = true;
            // 
            // userControlGallery
            // 
            this.userControlGallery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlGallery.Location = new System.Drawing.Point(0, 0);
            this.userControlGallery.Name = "userControlGallery";
            this.userControlGallery.Size = new System.Drawing.Size(676, 557);
            this.userControlGallery.TabIndex = 0;
            // 
            // tabPageCustom
            // 
            this.tabPageCustom.Controls.Add(this.userControlCustom);
            this.tabPageCustom.Location = new System.Drawing.Point(4, 22);
            this.tabPageCustom.Name = "tabPageCustom";
            this.tabPageCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustom.Size = new System.Drawing.Size(676, 557);
            this.tabPageCustom.TabIndex = 9;
            this.tabPageCustom.Text = "Custom";
            this.tabPageCustom.UseVisualStyleBackColor = true;
            // 
            // userControlCustom
            // 
            this.userControlCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlCustom.Location = new System.Drawing.Point(0, 0);
            this.userControlCustom.Name = "userControlCustom";
            this.userControlCustom.Size = new System.Drawing.Size(676, 557);
            this.userControlCustom.TabIndex = 0;
            // 
            // tabPageSettings
            // 
            this.tabPageSettings.Controls.Add(this.userControlSettings);
            this.tabPageSettings.Location = new System.Drawing.Point(4, 22);
            this.tabPageSettings.Name = "tabPageSettings";
            this.tabPageSettings.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSettings.Size = new System.Drawing.Size(676, 587);
            this.tabPageSettings.TabIndex = 14;
            this.tabPageSettings.Text = "Settings";
            this.tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // userControlSettings
            // 
            this.userControlSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlSettings.AutoScroll = true;
            this.userControlSettings.Location = new System.Drawing.Point(0, 0);
            this.userControlSettings.Name = "userControlSettings";
            this.userControlSettings.Size = new System.Drawing.Size(676, 587);
            this.userControlSettings.TabIndex = 3;
            this.userControlSettings.NuclearWinterModeToggled += new System.EventHandler(this.userControlSettings_NuclearWinterModeToggled);
            // 
            // tabPageProfiles
            // 
            this.tabPageProfiles.BackColor = System.Drawing.Color.White;
            this.tabPageProfiles.Controls.Add(this.userControlProfiles);
            this.tabPageProfiles.Location = new System.Drawing.Point(4, 22);
            this.tabPageProfiles.Name = "tabPageProfiles";
            this.tabPageProfiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProfiles.Size = new System.Drawing.Size(676, 557);
            this.tabPageProfiles.TabIndex = 13;
            this.tabPageProfiles.Text = "Profiles";
            // 
            // userControlProfiles
            // 
            this.userControlProfiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.userControlProfiles.BackColor = System.Drawing.Color.White;
            this.userControlProfiles.Location = new System.Drawing.Point(0, 0);
            this.userControlProfiles.Name = "userControlProfiles";
            this.userControlProfiles.Size = new System.Drawing.Size(471, 557);
            this.userControlProfiles.TabIndex = 0;
            // 
            // tabPageNexusMods
            // 
            this.tabPageNexusMods.Controls.Add(this.userControlNexusMods);
            this.tabPageNexusMods.Location = new System.Drawing.Point(4, 22);
            this.tabPageNexusMods.Name = "tabPageNexusMods";
            this.tabPageNexusMods.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNexusMods.Size = new System.Drawing.Size(676, 557);
            this.tabPageNexusMods.TabIndex = 15;
            this.tabPageNexusMods.Text = "NexusMods";
            this.tabPageNexusMods.UseVisualStyleBackColor = true;
            // 
            // userControlNexusMods
            // 
            this.userControlNexusMods.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlNexusMods.Location = new System.Drawing.Point(0, 0);
            this.userControlNexusMods.Name = "userControlNexusMods";
            this.userControlNexusMods.Size = new System.Drawing.Size(676, 557);
            this.userControlNexusMods.TabIndex = 0;
            // 
            // userControlSideNav
            // 
            this.userControlSideNav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.userControlSideNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.userControlSideNav.Location = new System.Drawing.Point(0, -2);
            this.userControlSideNav.Name = "userControlSideNav";
            this.userControlSideNav.Size = new System.Drawing.Size(200, 613);
            this.userControlSideNav.TabIndex = 17;
            this.userControlSideNav.PlayClicked += new System.EventHandler(this.navButtonPlay_Click);
            this.userControlSideNav.ApplyClicked += new System.EventHandler(this.navButtonApply_Click);
            this.userControlSideNav.SettingsClicked += new System.EventHandler(this.navButtonSettings_Click);
            this.userControlSideNav.ModsClicked += new System.EventHandler(this.navButtonMods_Click);
            this.userControlSideNav.UpdateClicked += new System.EventHandler(this.buttonUpdateNow_Click);
            this.userControlSideNav.HomeClicked += new System.EventHandler(this.userControlSideNav2_HomeClicked);
            this.userControlSideNav.TweaksClicked += new System.EventHandler(this.userControlSideNav2_TweaksClicked);
            this.userControlSideNav.PipboyClicked += new System.EventHandler(this.userControlSideNav2_PipboyClicked);
            this.userControlSideNav.GalleryClicked += new System.EventHandler(this.userControlSideNav2_GalleryClicked);
            this.userControlSideNav.CustomClicked += new System.EventHandler(this.userControlSideNav2_CustomClicked);
            this.userControlSideNav.ProfileClicked += new System.EventHandler(this.userControlSideNav2_ProfileClicked);
            this.userControlSideNav.NexusClicked += new System.EventHandler(this.userControlSideNav2_NexusClicked);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.pictureBoxLoadingGIF);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.userControlSideNav);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(900, 650);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fallout 76 Quick Configuration";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingGIF)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageHome.ResumeLayout(false);
            this.tabPageHome.PerformLayout();
            this.panelWhatsNew.ResumeLayout(false);
            this.panelUpdate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerCheckForUpdates)).EndInit();
            this.tabPageTweaks.ResumeLayout(false);
            this.tabPagePipBoy.ResumeLayout(false);
            this.tabPageGallery.ResumeLayout(false);
            this.tabPageCustom.ResumeLayout(false);
            this.tabPageSettings.ResumeLayout(false);
            this.tabPageProfiles.ResumeLayout(false);
            this.tabPageNexusMods.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Timer timerCheckFiles;
        private System.Windows.Forms.TabPage tabPageHome;
        private System.Windows.Forms.Label labelNewVersion;
        private System.Windows.Forms.LinkLabel linkLabelManualDownloadPage;
        public System.Windows.Forms.Label labelTranslationAuthor;
        public System.Windows.Forms.Label labelTranslationBy;
        private System.Windows.Forms.Label labelAuthorName;
        private System.Windows.Forms.Label labelConfigVersion;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelWelcome;
        private Fo76ini.Controls.TabControlWithoutHeader tabControl1;
        private System.Windows.Forms.TabPage tabPageCustom;
        private System.Windows.Forms.TabPage tabPageGallery;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoadGallery;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGetLatestVersion;
        private System.Windows.Forms.PictureBox pictureBoxSpinnerCheckForUpdates;
        private System.Windows.Forms.Panel panelUpdate;
        private System.Windows.Forms.PictureBox pictureBoxLoadingGIF;
        private System.Windows.Forms.RichTextBox richTextBoxWhatsNew;
        private System.Windows.Forms.Panel panelWhatsNew;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDownloadRTF;
        private Controls.PictureBoxButton pictureBoxButtonUpdate;
        private System.Windows.Forms.TabPage tabPageTweaks;
        private Forms.FormMain.UserControlTweaks userControlTweaks;
        private System.Windows.Forms.TabPage tabPagePipBoy;
        private Forms.FormMain.UserControlPipboy userControlPipboy;
        private Forms.FormMain.UserControlGallery userControlGallery;
        private Forms.FormMain.Tabs.UserControlCustom userControlCustom;
        private System.Windows.Forms.TabPage tabPageProfiles;
        private Forms.FormMain.Tabs.UserControlProfiles userControlProfiles;
        private System.Windows.Forms.TabPage tabPageSettings;
        private Forms.FormMain.UserControlSideNav userControlSideNav;
        private System.Windows.Forms.TabPage tabPageNexusMods;
        private Controls.UserControlHero userControlHero;
        private Forms.FormMain.Tabs.UserControlSettings userControlSettings;
        private Forms.FormMain.Tabs.UserControlNexusMods userControlNexusMods;
    }
}

