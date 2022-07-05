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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageInfo = new System.Windows.Forms.TabPage();
            this.pictureBoxButtonGameEdition = new Fo76ini.Controls.PictureBoxButton();
            this.panelWhatsNew = new System.Windows.Forms.Panel();
            this.richTextBoxWhatsNew = new System.Windows.Forms.RichTextBox();
            this.panelUpdate = new System.Windows.Forms.Panel();
            this.pictureBoxButtonUpdate = new Fo76ini.Controls.PictureBoxButton();
            this.labelNewVersion = new System.Windows.Forms.Label();
            this.linkLabelManualDownloadPage = new System.Windows.Forms.LinkLabel();
            this.pictureBoxSpinnerCheckForUpdates = new System.Windows.Forms.PictureBox();
            this.labelGameEdition = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.labelTranslationAuthor = new System.Windows.Forms.Label();
            this.labelTranslationBy = new System.Windows.Forms.Label();
            this.labelAuthorName = new System.Windows.Forms.Label();
            this.labelConfigVersion = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.tabPageTweaks = new System.Windows.Forms.TabPage();
            this.userControlTweaks = new Fo76ini.Forms.FormMain.UserControlTweaks();
            this.tabPagePipBoy = new System.Windows.Forms.TabPage();
            this.userControlPipboy1 = new Fo76ini.Forms.FormMain.UserControlPipboy();
            this.tabPageGallery = new System.Windows.Forms.TabPage();
            this.userControlGallery = new Fo76ini.Forms.FormMain.UserControlGallery();
            this.tabPageCustom = new System.Windows.Forms.TabPage();
            this.userControlCustom = new Fo76ini.Forms.FormMain.Tabs.UserControlCustom();
            this.tabPageProfiles = new System.Windows.Forms.TabPage();
            this.userControlProfiles = new Fo76ini.Forms.FormMain.Tabs.UserControlProfiles();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonNWMode = new System.Windows.Forms.Button();
            this.backgroundWorkerLoadGallery = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerGetLatestVersion = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelGame = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelGameText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelEdition = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelEditionText = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelNuclearWinterModeActive = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorkerDownloadRTF = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxLoadingGIF = new System.Windows.Forms.PictureBox();
            this.userControlSideNav2 = new Fo76ini.Forms.FormMain.UserControlSideNav();
            this.tabControl1.SuspendLayout();
            this.tabPageInfo.SuspendLayout();
            this.panelWhatsNew.SuspendLayout();
            this.panelUpdate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerCheckForUpdates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPageTweaks.SuspendLayout();
            this.tabPagePipBoy.SuspendLayout();
            this.tabPageGallery.SuspendLayout();
            this.tabPageCustom.SuspendLayout();
            this.tabPageProfiles.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingGIF)).BeginInit();
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
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageInfo);
            this.tabControl1.Controls.Add(this.tabPageTweaks);
            this.tabControl1.Controls.Add(this.tabPagePipBoy);
            this.tabControl1.Controls.Add(this.tabPageGallery);
            this.tabControl1.Controls.Add(this.tabPageCustom);
            this.tabControl1.Controls.Add(this.tabPageProfiles);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(201, -2);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(671, 558);
            this.tabControl1.TabIndex = 7;
            // 
            // tabPageInfo
            // 
            this.tabPageInfo.AutoScroll = true;
            this.tabPageInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.tabPageInfo.Controls.Add(this.pictureBoxButtonGameEdition);
            this.tabPageInfo.Controls.Add(this.panelWhatsNew);
            this.tabPageInfo.Controls.Add(this.panelUpdate);
            this.tabPageInfo.Controls.Add(this.pictureBoxSpinnerCheckForUpdates);
            this.tabPageInfo.Controls.Add(this.labelGameEdition);
            this.tabPageInfo.Controls.Add(this.pictureBox1);
            this.tabPageInfo.Controls.Add(this.pictureBox2);
            this.tabPageInfo.Controls.Add(this.labelTranslationAuthor);
            this.tabPageInfo.Controls.Add(this.labelTranslationBy);
            this.tabPageInfo.Controls.Add(this.labelAuthorName);
            this.tabPageInfo.Controls.Add(this.labelConfigVersion);
            this.tabPageInfo.Controls.Add(this.labelAuthor);
            this.tabPageInfo.Controls.Add(this.labelVersion);
            this.tabPageInfo.Controls.Add(this.labelDescription);
            this.tabPageInfo.Controls.Add(this.labelTitle);
            this.tabPageInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageInfo.Name = "tabPageInfo";
            this.tabPageInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageInfo.Size = new System.Drawing.Size(663, 532);
            this.tabPageInfo.TabIndex = 4;
            this.tabPageInfo.Text = "Info";
            this.tabPageInfo.UseVisualStyleBackColor = true;
            // 
            // pictureBoxButtonGameEdition
            // 
            this.pictureBoxButtonGameEdition.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.pictureBoxButtonGameEdition.BackColor = System.Drawing.Color.Black;
            this.pictureBoxButtonGameEdition.ButtonText = null;
            this.pictureBoxButtonGameEdition.ButtonTextColor = System.Drawing.Color.Empty;
            this.pictureBoxButtonGameEdition.ButtonTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pictureBoxButtonGameEdition.Image = global::Fo76ini.Properties.Resources.help_128;
            this.pictureBoxButtonGameEdition.ImageHover = global::Fo76ini.Properties.Resources.help_128_hover;
            this.pictureBoxButtonGameEdition.Location = new System.Drawing.Point(6, 338);
            this.pictureBoxButtonGameEdition.Name = "pictureBoxButtonGameEdition";
            this.pictureBoxButtonGameEdition.Size = new System.Drawing.Size(60, 60);
            this.pictureBoxButtonGameEdition.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxButtonGameEdition.TabIndex = 46;
            this.pictureBoxButtonGameEdition.Click += new System.EventHandler(this.showProfiles_OnClick);
            // 
            // panelWhatsNew
            // 
            this.panelWhatsNew.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelWhatsNew.BackColor = System.Drawing.Color.Silver;
            this.panelWhatsNew.Controls.Add(this.richTextBoxWhatsNew);
            this.panelWhatsNew.Location = new System.Drawing.Point(486, 0);
            this.panelWhatsNew.Margin = new System.Windows.Forms.Padding(0);
            this.panelWhatsNew.Name = "panelWhatsNew";
            this.panelWhatsNew.Size = new System.Drawing.Size(370, 443);
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
            this.richTextBoxWhatsNew.Size = new System.Drawing.Size(356, 344);
            this.richTextBoxWhatsNew.TabIndex = 43;
            this.richTextBoxWhatsNew.Text = "\n\n\n                          Loading \"What\'s new?\" content...";
            // 
            // panelUpdate
            // 
            this.panelUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.panelUpdate.Controls.Add(this.pictureBoxButtonUpdate);
            this.panelUpdate.Controls.Add(this.labelNewVersion);
            this.panelUpdate.Controls.Add(this.linkLabelManualDownloadPage);
            this.panelUpdate.Location = new System.Drawing.Point(93, 306);
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
            this.labelNewVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.pictureBoxSpinnerCheckForUpdates.Location = new System.Drawing.Point(176, 101);
            this.pictureBoxSpinnerCheckForUpdates.Name = "pictureBoxSpinnerCheckForUpdates";
            this.pictureBoxSpinnerCheckForUpdates.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxSpinnerCheckForUpdates.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSpinnerCheckForUpdates.TabIndex = 37;
            this.pictureBoxSpinnerCheckForUpdates.TabStop = false;
            this.pictureBoxSpinnerCheckForUpdates.Visible = false;
            // 
            // labelGameEdition
            // 
            this.labelGameEdition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelGameEdition.BackColor = System.Drawing.Color.Black;
            this.labelGameEdition.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelGameEdition.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGameEdition.ForeColor = System.Drawing.Color.White;
            this.labelGameEdition.Location = new System.Drawing.Point(0, 380);
            this.labelGameEdition.Name = "labelGameEdition";
            this.labelGameEdition.Size = new System.Drawing.Size(73, 59);
            this.labelGameEdition.TabIndex = 22;
            this.labelGameEdition.Text = "Unknown";
            this.labelGameEdition.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.labelGameEdition.Click += new System.EventHandler(this.showProfiles_OnClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Image = global::Fo76ini.Properties.Resources.icon_60;
            this.pictureBox1.Location = new System.Drawing.Point(6, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(60, 60);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 17;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox2.BackColor = System.Drawing.Color.Black;
            this.pictureBox2.Location = new System.Drawing.Point(-4, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(77, 443);
            this.pictureBox2.TabIndex = 18;
            this.pictureBox2.TabStop = false;
            // 
            // labelTranslationAuthor
            // 
            this.labelTranslationAuthor.AutoSize = true;
            this.labelTranslationAuthor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTranslationAuthor.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTranslationAuthor.Location = new System.Drawing.Point(206, 140);
            this.labelTranslationAuthor.Name = "labelTranslationAuthor";
            this.labelTranslationAuthor.Size = new System.Drawing.Size(172, 15);
            this.labelTranslationAuthor.TabIndex = 12;
            this.labelTranslationAuthor.Text = "FelisDiligens (aka. datasnake)";
            // 
            // labelTranslationBy
            // 
            this.labelTranslationBy.AutoSize = true;
            this.labelTranslationBy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTranslationBy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelTranslationBy.Location = new System.Drawing.Point(93, 141);
            this.labelTranslationBy.Name = "labelTranslationBy";
            this.labelTranslationBy.Size = new System.Drawing.Size(86, 15);
            this.labelTranslationBy.TabIndex = 11;
            this.labelTranslationBy.Text = "Translation by:";
            // 
            // labelAuthorName
            // 
            this.labelAuthorName.AutoSize = true;
            this.labelAuthorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthorName.Location = new System.Drawing.Point(206, 122);
            this.labelAuthorName.Name = "labelAuthorName";
            this.labelAuthorName.Size = new System.Drawing.Size(172, 15);
            this.labelAuthorName.TabIndex = 10;
            this.labelAuthorName.Text = "FelisDiligens (aka. datasnake)";
            // 
            // labelConfigVersion
            // 
            this.labelConfigVersion.AutoSize = true;
            this.labelConfigVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfigVersion.Location = new System.Drawing.Point(206, 105);
            this.labelConfigVersion.Name = "labelConfigVersion";
            this.labelConfigVersion.Size = new System.Drawing.Size(14, 15);
            this.labelConfigVersion.TabIndex = 9;
            this.labelConfigVersion.Text = "?";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.Location = new System.Drawing.Point(93, 123);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(49, 15);
            this.labelAuthor.TabIndex = 8;
            this.labelAuthor.Text = "Author:";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(93, 105);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(51, 15);
            this.labelVersion.TabIndex = 7;
            this.labelVersion.Text = "Version:";
            // 
            // labelDescription
            // 
            this.labelDescription.BackColor = System.Drawing.Color.Transparent;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(90, 54);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(393, 44);
            this.labelDescription.TabIndex = 6;
            this.labelDescription.Text = "This tool allows you to change various game settings and install mods.\r\nTip: Hove" +
    "r over an option, if you\'re unsure what it does.";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(88, 20);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(304, 30);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Fallout 76 Quick Configuration";
            // 
            // tabPageTweaks
            // 
            this.tabPageTweaks.Controls.Add(this.userControlTweaks);
            this.tabPageTweaks.Location = new System.Drawing.Point(4, 22);
            this.tabPageTweaks.Name = "tabPageTweaks";
            this.tabPageTweaks.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTweaks.Size = new System.Drawing.Size(663, 532);
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
            this.userControlTweaks.Size = new System.Drawing.Size(852, 439);
            this.userControlTweaks.TabIndex = 0;
            // 
            // tabPagePipBoy
            // 
            this.tabPagePipBoy.Controls.Add(this.userControlPipboy1);
            this.tabPagePipBoy.Location = new System.Drawing.Point(4, 22);
            this.tabPagePipBoy.Name = "tabPagePipBoy";
            this.tabPagePipBoy.Size = new System.Drawing.Size(663, 532);
            this.tabPagePipBoy.TabIndex = 12;
            this.tabPagePipBoy.Text = "Pip-Boy";
            this.tabPagePipBoy.UseVisualStyleBackColor = true;
            // 
            // userControlPipboy1
            // 
            this.userControlPipboy1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userControlPipboy1.Location = new System.Drawing.Point(0, 0);
            this.userControlPipboy1.Name = "userControlPipboy1";
            this.userControlPipboy1.Size = new System.Drawing.Size(852, 439);
            this.userControlPipboy1.TabIndex = 0;
            // 
            // tabPageGallery
            // 
            this.tabPageGallery.Controls.Add(this.userControlGallery);
            this.tabPageGallery.Location = new System.Drawing.Point(4, 22);
            this.tabPageGallery.Name = "tabPageGallery";
            this.tabPageGallery.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGallery.Size = new System.Drawing.Size(663, 532);
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
            this.userControlGallery.Size = new System.Drawing.Size(852, 439);
            this.userControlGallery.TabIndex = 0;
            // 
            // tabPageCustom
            // 
            this.tabPageCustom.Controls.Add(this.userControlCustom);
            this.tabPageCustom.Location = new System.Drawing.Point(4, 22);
            this.tabPageCustom.Name = "tabPageCustom";
            this.tabPageCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageCustom.Size = new System.Drawing.Size(663, 532);
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
            this.userControlCustom.Size = new System.Drawing.Size(852, 439);
            this.userControlCustom.TabIndex = 0;
            // 
            // tabPageProfiles
            // 
            this.tabPageProfiles.BackColor = System.Drawing.Color.White;
            this.tabPageProfiles.Controls.Add(this.userControlProfiles);
            this.tabPageProfiles.Location = new System.Drawing.Point(4, 22);
            this.tabPageProfiles.Name = "tabPageProfiles";
            this.tabPageProfiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageProfiles.Size = new System.Drawing.Size(663, 532);
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
            this.userControlProfiles.Size = new System.Drawing.Size(480, 439);
            this.userControlProfiles.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonNWMode);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(663, 532);
            this.tabPage1.TabIndex = 14;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonNWMode
            // 
            this.buttonNWMode.Image = global::Fo76ini.Properties.Resources.fire;
            this.buttonNWMode.Location = new System.Drawing.Point(136, 67);
            this.buttonNWMode.Name = "buttonNWMode";
            this.buttonNWMode.Size = new System.Drawing.Size(138, 63);
            this.buttonNWMode.TabIndex = 0;
            this.buttonNWMode.Text = "Nuclear Winter";
            this.buttonNWMode.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonNWMode.UseVisualStyleBackColor = true;
            this.buttonNWMode.Click += new System.EventHandler(this.toolStripButtonToggleNuclearWinterMode_Click);
            // 
            // backgroundWorkerGetLatestVersion
            // 
            this.backgroundWorkerGetLatestVersion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerGetLatestVersion_DoWork);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelGame,
            this.toolStripStatusLabelGameText,
            this.toolStripStatusLabelEdition,
            this.toolStripStatusLabelEditionText,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelNuclearWinterModeActive});
            this.statusStrip1.Location = new System.Drawing.Point(0, 559);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 22);
            this.statusStrip1.TabIndex = 16;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelGame
            // 
            this.toolStripStatusLabelGame.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelGame.Margin = new System.Windows.Forms.Padding(10, 3, 0, 2);
            this.toolStripStatusLabelGame.Name = "toolStripStatusLabelGame";
            this.toolStripStatusLabelGame.Size = new System.Drawing.Size(83, 17);
            this.toolStripStatusLabelGame.Text = "Game profile:";
            // 
            // toolStripStatusLabelGameText
            // 
            this.toolStripStatusLabelGameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelGameText.Name = "toolStripStatusLabelGameText";
            this.toolStripStatusLabelGameText.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusLabelGameText.Text = "?";
            // 
            // toolStripStatusLabelEdition
            // 
            this.toolStripStatusLabelEdition.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelEdition.Margin = new System.Windows.Forms.Padding(30, 3, 0, 2);
            this.toolStripStatusLabelEdition.Name = "toolStripStatusLabelEdition";
            this.toolStripStatusLabelEdition.Size = new System.Drawing.Size(48, 17);
            this.toolStripStatusLabelEdition.Text = "Edition:";
            // 
            // toolStripStatusLabelEditionText
            // 
            this.toolStripStatusLabelEditionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelEditionText.Name = "toolStripStatusLabelEditionText";
            this.toolStripStatusLabelEditionText.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusLabelEditionText.Text = "?";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(495, 17);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabelNuclearWinterModeActive
            // 
            this.toolStripStatusLabelNuclearWinterModeActive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabelNuclearWinterModeActive.ForeColor = System.Drawing.Color.OrangeRed;
            this.toolStripStatusLabelNuclearWinterModeActive.Name = "toolStripStatusLabelNuclearWinterModeActive";
            this.toolStripStatusLabelNuclearWinterModeActive.Size = new System.Drawing.Size(175, 17);
            this.toolStripStatusLabelNuclearWinterModeActive.Text = "Nuclear Winter mode is active";
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
            this.pictureBoxLoadingGIF.Size = new System.Drawing.Size(16, 583);
            this.pictureBoxLoadingGIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLoadingGIF.TabIndex = 15;
            this.pictureBoxLoadingGIF.TabStop = false;
            this.pictureBoxLoadingGIF.Visible = false;
            // 
            // userControlSideNav2
            // 
            this.userControlSideNav2.BackColor = System.Drawing.Color.Black;
            this.userControlSideNav2.Location = new System.Drawing.Point(0, -2);
            this.userControlSideNav2.Name = "userControlSideNav2";
            this.userControlSideNav2.Size = new System.Drawing.Size(200, 583);
            this.userControlSideNav2.TabIndex = 17;
            this.userControlSideNav2.PlayClicked += new System.EventHandler(this.navButtonPlay_Click);
            this.userControlSideNav2.ApplyClicked += new System.EventHandler(this.navButtonApply_Click);
            this.userControlSideNav2.SettingsClicked += new System.EventHandler(this.navButtonSettings_Click);
            this.userControlSideNav2.ModsClicked += new System.EventHandler(this.navButtonMods_Click);
            this.userControlSideNav2.UpdateClicked += new System.EventHandler(this.buttonUpdateNow_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 581);
            this.Controls.Add(this.pictureBoxLoadingGIF);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.userControlSideNav2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(900, 620);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fallout 76 Quick Configuration";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageInfo.ResumeLayout(false);
            this.tabPageInfo.PerformLayout();
            this.panelWhatsNew.ResumeLayout(false);
            this.panelUpdate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerCheckForUpdates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPageTweaks.ResumeLayout(false);
            this.tabPagePipBoy.ResumeLayout(false);
            this.tabPageGallery.ResumeLayout(false);
            this.tabPageCustom.ResumeLayout(false);
            this.tabPageProfiles.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingGIF)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Timer timerCheckFiles;
        private System.Windows.Forms.TabPage tabPageInfo;
        private System.Windows.Forms.Label labelGameEdition;
        private System.Windows.Forms.Label labelNewVersion;
        private System.Windows.Forms.LinkLabel linkLabelManualDownloadPage;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        public System.Windows.Forms.Label labelTranslationAuthor;
        public System.Windows.Forms.Label labelTranslationBy;
        private System.Windows.Forms.Label labelAuthorName;
        private System.Windows.Forms.Label labelConfigVersion;
        private System.Windows.Forms.Label labelAuthor;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageCustom;
        private System.Windows.Forms.TabPage tabPageGallery;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoadGallery;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGetLatestVersion;
        private System.Windows.Forms.PictureBox pictureBoxSpinnerCheckForUpdates;
        private System.Windows.Forms.Panel panelUpdate;
        private System.Windows.Forms.PictureBox pictureBoxLoadingGIF;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelGame;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelGameText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEdition;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelEditionText;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelNuclearWinterModeActive;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.RichTextBox richTextBoxWhatsNew;
        private System.Windows.Forms.Panel panelWhatsNew;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDownloadRTF;
        private Controls.PictureBoxButton pictureBoxButtonUpdate;
        private Controls.PictureBoxButton pictureBoxButtonGameEdition;
        private System.Windows.Forms.TabPage tabPageTweaks;
        private Forms.FormMain.UserControlTweaks userControlTweaks;
        private System.Windows.Forms.TabPage tabPagePipBoy;
        private Forms.FormMain.UserControlPipboy userControlPipboy1;
        private Forms.FormMain.UserControlGallery userControlGallery;
        private Forms.FormMain.Tabs.UserControlCustom userControlCustom;
        private System.Windows.Forms.TabPage tabPageProfiles;
        private Forms.FormMain.Tabs.UserControlProfiles userControlProfiles;
        private System.Windows.Forms.TabPage tabPage1;
        private Forms.FormMain.UserControlSideNav userControlSideNav2;
        private System.Windows.Forms.Button buttonNWMode;
    }
}

