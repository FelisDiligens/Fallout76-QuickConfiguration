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
            this.pictureBoxButtonUpdate = new Fo76ini.Controls.PictureBoxButton();
            this.labelNewVersion = new System.Windows.Forms.Label();
            this.linkLabelManualDownloadPage = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabelShowWhatsNew = new System.Windows.Forms.LinkLabel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelAuthor = new System.Windows.Forms.Label();
            this.pictureBoxSpinnerCheckForUpdates = new System.Windows.Forms.PictureBox();
            this.labelConfigVersion = new System.Windows.Forms.Label();
            this.labelTranslationAuthor = new System.Windows.Forms.Label();
            this.labelAuthorName = new System.Windows.Forms.Label();
            this.labelTranslationBy = new System.Windows.Forms.Label();
            this.userControlHero = new Fo76ini.Controls.UserControlHero();
            this.backgroundWorkerGetLatestVersion = new System.ComponentModel.BackgroundWorker();
            this.tabControlWithoutHeader1 = new Fo76ini.Controls.TabControlWithoutHeader();
            this.tabPageHome = new System.Windows.Forms.TabPage();
            this.tabPageWhatsNew = new System.Windows.Forms.TabPage();
            this.linkLabelGoBack = new System.Windows.Forms.LinkLabel();
            this.panelUpdate.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerCheckForUpdates)).BeginInit();
            this.tabControlWithoutHeader1.SuspendLayout();
            this.tabPageHome.SuspendLayout();
            this.tabPageWhatsNew.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowserWhatsNew
            // 
            this.webBrowserWhatsNew.AllowNavigation = false;
            this.webBrowserWhatsNew.AllowWebBrowserDrop = false;
            this.webBrowserWhatsNew.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserWhatsNew.Location = new System.Drawing.Point(3, 31);
            this.webBrowserWhatsNew.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserWhatsNew.Name = "webBrowserWhatsNew";
            this.webBrowserWhatsNew.ScriptErrorsSuppressed = true;
            this.webBrowserWhatsNew.Size = new System.Drawing.Size(662, 447);
            this.webBrowserWhatsNew.TabIndex = 52;
            // 
            // panelUpdate
            // 
            this.panelUpdate.Controls.Add(this.pictureBoxButtonUpdate);
            this.panelUpdate.Controls.Add(this.labelNewVersion);
            this.panelUpdate.Controls.Add(this.linkLabelManualDownloadPage);
            this.panelUpdate.Location = new System.Drawing.Point(3, 249);
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
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.linkLabelShowWhatsNew);
            this.panel1.Controls.Add(this.labelWelcome);
            this.panel1.Controls.Add(this.labelDescription);
            this.panel1.Controls.Add(this.labelVersion);
            this.panel1.Controls.Add(this.labelAuthor);
            this.panel1.Controls.Add(this.pictureBoxSpinnerCheckForUpdates);
            this.panel1.Controls.Add(this.labelConfigVersion);
            this.panel1.Controls.Add(this.labelTranslationAuthor);
            this.panel1.Controls.Add(this.labelAuthorName);
            this.panel1.Controls.Add(this.labelTranslationBy);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 184);
            this.panel1.TabIndex = 53;
            // 
            // linkLabelShowWhatsNew
            // 
            this.linkLabelShowWhatsNew.AutoSize = true;
            this.linkLabelShowWhatsNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelShowWhatsNew.Location = new System.Drawing.Point(17, 145);
            this.linkLabelShowWhatsNew.Name = "linkLabelShowWhatsNew";
            this.linkLabelShowWhatsNew.Size = new System.Drawing.Size(82, 16);
            this.linkLabelShowWhatsNew.TabIndex = 38;
            this.linkLabelShowWhatsNew.TabStop = true;
            this.linkLabelShowWhatsNew.Text = "What\'s new?";
            this.linkLabelShowWhatsNew.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowWhatsNew_LinkClicked);
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
            this.labelDescription.Size = new System.Drawing.Size(651, 39);
            this.labelDescription.TabIndex = 6;
            this.labelDescription.Text = "This tool allows you to change various game settings and install mods.";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(17, 79);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(58, 17);
            this.labelVersion.TabIndex = 7;
            this.labelVersion.Text = "Version:";
            // 
            // labelAuthor
            // 
            this.labelAuthor.AutoSize = true;
            this.labelAuthor.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthor.Location = new System.Drawing.Point(17, 97);
            this.labelAuthor.Name = "labelAuthor";
            this.labelAuthor.Size = new System.Drawing.Size(56, 17);
            this.labelAuthor.TabIndex = 8;
            this.labelAuthor.Text = "Author:";
            // 
            // pictureBoxSpinnerCheckForUpdates
            // 
            this.pictureBoxSpinnerCheckForUpdates.Image = global::Fo76ini.Properties.Resources.Spinner_24;
            this.pictureBoxSpinnerCheckForUpdates.Location = new System.Drawing.Point(100, 75);
            this.pictureBoxSpinnerCheckForUpdates.Name = "pictureBoxSpinnerCheckForUpdates";
            this.pictureBoxSpinnerCheckForUpdates.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxSpinnerCheckForUpdates.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSpinnerCheckForUpdates.TabIndex = 37;
            this.pictureBoxSpinnerCheckForUpdates.TabStop = false;
            this.pictureBoxSpinnerCheckForUpdates.Visible = false;
            // 
            // labelConfigVersion
            // 
            this.labelConfigVersion.AutoSize = true;
            this.labelConfigVersion.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelConfigVersion.Location = new System.Drawing.Point(130, 79);
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
            this.labelTranslationAuthor.Location = new System.Drawing.Point(130, 114);
            this.labelTranslationAuthor.Name = "labelTranslationAuthor";
            this.labelTranslationAuthor.Size = new System.Drawing.Size(177, 17);
            this.labelTranslationAuthor.TabIndex = 12;
            this.labelTranslationAuthor.Text = "FelisDiligens (aka. datasnake)";
            // 
            // labelAuthorName
            // 
            this.labelAuthorName.AutoSize = true;
            this.labelAuthorName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAuthorName.Location = new System.Drawing.Point(130, 96);
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
            this.labelTranslationBy.Location = new System.Drawing.Point(17, 115);
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
            this.tabPageHome.Controls.Add(this.panel1);
            this.tabPageHome.Controls.Add(this.panelUpdate);
            this.tabPageHome.Location = new System.Drawing.Point(4, 22);
            this.tabPageHome.Name = "tabPageHome";
            this.tabPageHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageHome.Size = new System.Drawing.Size(668, 473);
            this.tabPageHome.TabIndex = 0;
            this.tabPageHome.Text = "tabPageHome";
            this.tabPageHome.UseVisualStyleBackColor = true;
            // 
            // tabPageWhatsNew
            // 
            this.tabPageWhatsNew.Controls.Add(this.linkLabelGoBack);
            this.tabPageWhatsNew.Controls.Add(this.webBrowserWhatsNew);
            this.tabPageWhatsNew.Location = new System.Drawing.Point(4, 22);
            this.tabPageWhatsNew.Name = "tabPageWhatsNew";
            this.tabPageWhatsNew.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageWhatsNew.Size = new System.Drawing.Size(668, 473);
            this.tabPageWhatsNew.TabIndex = 1;
            this.tabPageWhatsNew.Text = "tabPageWhatsNew";
            this.tabPageWhatsNew.UseVisualStyleBackColor = true;
            // 
            // linkLabelGoBack
            // 
            this.linkLabelGoBack.AutoSize = true;
            this.linkLabelGoBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelGoBack.Location = new System.Drawing.Point(18, 12);
            this.linkLabelGoBack.Name = "linkLabelGoBack";
            this.linkLabelGoBack.Size = new System.Drawing.Size(74, 16);
            this.linkLabelGoBack.TabIndex = 53;
            this.linkLabelGoBack.TabStop = true;
            this.linkLabelGoBack.Text = "← Go back";
            this.linkLabelGoBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGoBack_LinkClicked);
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
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerCheckForUpdates)).EndInit();
            this.tabControlWithoutHeader1.ResumeLayout(false);
            this.tabPageHome.ResumeLayout(false);
            this.tabPageWhatsNew.ResumeLayout(false);
            this.tabPageWhatsNew.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserWhatsNew;
        private System.Windows.Forms.Panel panelUpdate;
        private Controls.PictureBoxButton pictureBoxButtonUpdate;
        private System.Windows.Forms.Label labelNewVersion;
        private System.Windows.Forms.LinkLabel linkLabelManualDownloadPage;
        private System.Windows.Forms.Panel panel1;
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
        private System.Windows.Forms.LinkLabel linkLabelShowWhatsNew;
        private Controls.TabControlWithoutHeader tabControlWithoutHeader1;
        private System.Windows.Forms.TabPage tabPageHome;
        private System.Windows.Forms.TabPage tabPageWhatsNew;
        private System.Windows.Forms.LinkLabel linkLabelGoBack;
    }
}
