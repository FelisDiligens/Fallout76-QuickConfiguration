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
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.timerCheckFiles = new System.Windows.Forms.Timer(this.components);
            this.backgroundWorkerLoadGallery = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerGetLatestVersion = new System.ComponentModel.BackgroundWorker();
            this.pictureBoxLoadingGIF = new System.Windows.Forms.PictureBox();
            this.backgroundWorkerTranslationsCheckForUpdates = new System.ComponentModel.BackgroundWorker();
            this.viewControl = new Fo76ini.Controls.ViewControl();
            this.userControlSideNav = new Fo76ini.Forms.FormMain.UserControlSideNav();
            this.toolTip = new Fo76ini.Controls.CustomToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingGIF)).BeginInit();
            this.SuspendLayout();
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
            // pictureBoxLoadingGIF
            // 
            this.pictureBoxLoadingGIF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLoadingGIF.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBoxLoadingGIF.Image = global::Fo76ini.Properties.Resources.Rolling_1s_200px_light;
            this.pictureBoxLoadingGIF.Location = new System.Drawing.Point(0, -2);
            this.pictureBoxLoadingGIF.Name = "pictureBoxLoadingGIF";
            this.pictureBoxLoadingGIF.Size = new System.Drawing.Size(16, 613);
            this.pictureBoxLoadingGIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxLoadingGIF.TabIndex = 15;
            this.pictureBoxLoadingGIF.TabStop = false;
            this.pictureBoxLoadingGIF.Visible = false;
            // 
            // backgroundWorkerTranslationsCheckForUpdates
            // 
            this.backgroundWorkerTranslationsCheckForUpdates.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerTranslationsCheckForUpdates_DoWork);
            // 
            // viewControl
            // 
            this.viewControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewControl.BackColor = System.Drawing.Color.White;
            this.viewControl.Location = new System.Drawing.Point(200, -2);
            this.viewControl.Margin = new System.Windows.Forms.Padding(0);
            this.viewControl.Name = "viewControl";
            this.viewControl.Size = new System.Drawing.Size(684, 613);
            this.viewControl.TabIndex = 18;
            // 
            // userControlSideNav
            // 
            this.userControlSideNav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.userControlSideNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.userControlSideNav.Location = new System.Drawing.Point(0, -2);
            this.userControlSideNav.Name = "userControlSideNav";
            this.userControlSideNav.SelectedTabIndex = -1;
            this.userControlSideNav.Size = new System.Drawing.Size(200, 613);
            this.userControlSideNav.TabIndex = 17;
            this.userControlSideNav.PlayClicked += new System.EventHandler(this.navButtonPlay_Click);
            this.userControlSideNav.ApplyClicked += new System.EventHandler(this.navButtonApply_Click);
            this.userControlSideNav.SettingsClicked += new System.EventHandler(this.navButtonSettings_Click);
            this.userControlSideNav.ModsClicked += new System.EventHandler(this.navButtonMods_Click);
            this.userControlSideNav.UpdateClicked += new System.EventHandler(this.userControlSideNav_UpdateClicked);
            this.userControlSideNav.HomeClicked += new System.EventHandler(this.userControlSideNav2_HomeClicked);
            this.userControlSideNav.TweaksClicked += new System.EventHandler(this.userControlSideNav2_TweaksClicked);
            this.userControlSideNav.PipboyClicked += new System.EventHandler(this.userControlSideNav2_PipboyClicked);
            this.userControlSideNav.GalleryClicked += new System.EventHandler(this.userControlSideNav2_GalleryClicked);
            this.userControlSideNav.CustomClicked += new System.EventHandler(this.userControlSideNav2_CustomClicked);
            this.userControlSideNav.ProfileClicked += new System.EventHandler(this.userControlSideNav2_ProfileClicked);
            this.userControlSideNav.NexusClicked += new System.EventHandler(this.userControlSideNav2_NexusClicked);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 20000;
            this.toolTip.BackColor = System.Drawing.Color.White;
            this.toolTip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolTip.ForeColor = System.Drawing.Color.Black;
            this.toolTip.InitialDelay = 500;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Padding = new System.Drawing.Size(6, 6);
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ShowAlways = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 611);
            this.Controls.Add(this.pictureBoxLoadingGIF);
            this.Controls.Add(this.viewControl);
            this.Controls.Add(this.userControlSideNav);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(900, 650);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fallout 76 Quick Configuration";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoadingGIF)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public Controls.CustomToolTip toolTip;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Timer timerCheckFiles;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoadGallery;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGetLatestVersion;
        private System.Windows.Forms.PictureBox pictureBoxLoadingGIF;
        private Forms.FormMain.UserControlSideNav userControlSideNav;
        private Controls.ViewControl viewControl;
        private System.ComponentModel.BackgroundWorker backgroundWorkerTranslationsCheckForUpdates;
    }
}

