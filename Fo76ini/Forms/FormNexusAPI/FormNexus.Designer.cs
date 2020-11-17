namespace Fo76ini.Forms.FormNexusAPI
{
    partial class FormNexus
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNexus));
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelNMNotLoggedIn = new System.Windows.Forms.Label();
            this.labelNMUserID = new System.Windows.Forms.Label();
            this.labelNMDescUserID = new System.Windows.Forms.Label();
            this.labelNMHourlyRateLimit = new System.Windows.Forms.Label();
            this.linkLabelNMGetAPIKey = new System.Windows.Forms.LinkLabel();
            this.labelNMDescHourlyRateLimit = new System.Windows.Forms.Label();
            this.labelNMAPIKeyStatus = new System.Windows.Forms.Label();
            this.labelNMDescAPIKey = new System.Windows.Forms.Label();
            this.pictureBoxNMProfilePicture = new System.Windows.Forms.PictureBox();
            this.labelNMUserName = new System.Windows.Forms.Label();
            this.labelNMDescMembership = new System.Windows.Forms.Label();
            this.labelNMDailyRateLimitReset = new System.Windows.Forms.Label();
            this.labelNMMembership = new System.Windows.Forms.Label();
            this.labelNMDescLimitReset = new System.Windows.Forms.Label();
            this.labelNMDescDailyRateLimit = new System.Windows.Forms.Label();
            this.labelNMDailyRateLimit = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonNWDeleteAll = new System.Windows.Forms.Button();
            this.buttonNWLogout = new System.Windows.Forms.Button();
            this.checkBoxNMDownloadThumbnails = new System.Windows.Forms.CheckBox();
            this.labelNMOptions = new System.Windows.Forms.Label();
            this.checkBoxNMUpdateProfile = new System.Windows.Forms.CheckBox();
            this.checkBoxShowAPIKey = new System.Windows.Forms.CheckBox();
            this.labelNMInfo = new System.Windows.Forms.Label();
            this.textBoxAPIKey = new System.Windows.Forms.TextBox();
            this.labelNMAPIKeyTextBox = new System.Windows.Forms.Label();
            this.buttonNMUpdateProfile = new System.Windows.Forms.Button();
            this.backgroundWorkerRetrieveProfileInfo = new System.ComponentModel.BackgroundWorker();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNMProfilePicture)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.panel3.Controls.Add(this.labelNMNotLoggedIn);
            this.panel3.Controls.Add(this.labelNMUserID);
            this.panel3.Controls.Add(this.labelNMDescUserID);
            this.panel3.Controls.Add(this.labelNMHourlyRateLimit);
            this.panel3.Controls.Add(this.linkLabelNMGetAPIKey);
            this.panel3.Controls.Add(this.labelNMDescHourlyRateLimit);
            this.panel3.Controls.Add(this.labelNMAPIKeyStatus);
            this.panel3.Controls.Add(this.labelNMDescAPIKey);
            this.panel3.Controls.Add(this.pictureBoxNMProfilePicture);
            this.panel3.Controls.Add(this.labelNMUserName);
            this.panel3.Controls.Add(this.labelNMDescMembership);
            this.panel3.Controls.Add(this.labelNMDailyRateLimitReset);
            this.panel3.Controls.Add(this.labelNMMembership);
            this.panel3.Controls.Add(this.labelNMDescLimitReset);
            this.panel3.Controls.Add(this.labelNMDescDailyRateLimit);
            this.panel3.Controls.Add(this.labelNMDailyRateLimit);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(850, 170);
            this.panel3.TabIndex = 76;
            // 
            // labelNMNotLoggedIn
            // 
            this.labelNMNotLoggedIn.AutoSize = true;
            this.labelNMNotLoggedIn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMNotLoggedIn.Location = new System.Drawing.Point(173, 57);
            this.labelNMNotLoggedIn.Name = "labelNMNotLoggedIn";
            this.labelNMNotLoggedIn.Size = new System.Drawing.Size(335, 13);
            this.labelNMNotLoggedIn.TabIndex = 80;
            this.labelNMNotLoggedIn.Text = "Not logged in. Please enter your API key and click on \'Update profile\'.";
            // 
            // labelNMUserID
            // 
            this.labelNMUserID.AutoSize = true;
            this.labelNMUserID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMUserID.Location = new System.Drawing.Point(296, 107);
            this.labelNMUserID.Name = "labelNMUserID";
            this.labelNMUserID.Size = new System.Drawing.Size(16, 13);
            this.labelNMUserID.TabIndex = 79;
            this.labelNMUserID.Text = "-1";
            // 
            // labelNMDescUserID
            // 
            this.labelNMDescUserID.AutoSize = true;
            this.labelNMDescUserID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMDescUserID.Location = new System.Drawing.Point(173, 107);
            this.labelNMDescUserID.Name = "labelNMDescUserID";
            this.labelNMDescUserID.Size = new System.Drawing.Size(46, 13);
            this.labelNMDescUserID.TabIndex = 78;
            this.labelNMDescUserID.Text = "User-ID:";
            // 
            // labelNMHourlyRateLimit
            // 
            this.labelNMHourlyRateLimit.AutoSize = true;
            this.labelNMHourlyRateLimit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMHourlyRateLimit.Location = new System.Drawing.Point(611, 85);
            this.labelNMHourlyRateLimit.Name = "labelNMHourlyRateLimit";
            this.labelNMHourlyRateLimit.Size = new System.Drawing.Size(30, 13);
            this.labelNMHourlyRateLimit.TabIndex = 77;
            this.labelNMHourlyRateLimit.Text = "0 left";
            // 
            // linkLabelNMGetAPIKey
            // 
            this.linkLabelNMGetAPIKey.AutoSize = true;
            this.linkLabelNMGetAPIKey.LinkColor = System.Drawing.Color.Aqua;
            this.linkLabelNMGetAPIKey.Location = new System.Drawing.Point(173, 74);
            this.linkLabelNMGetAPIKey.Name = "linkLabelNMGetAPIKey";
            this.linkLabelNMGetAPIKey.Size = new System.Drawing.Size(87, 13);
            this.linkLabelNMGetAPIKey.TabIndex = 79;
            this.linkLabelNMGetAPIKey.TabStop = true;
            this.linkLabelNMGetAPIKey.Text = "Get your API key";
            this.linkLabelNMGetAPIKey.VisitedLinkColor = System.Drawing.Color.Fuchsia;
            this.linkLabelNMGetAPIKey.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNMGetAPIKey_LinkClicked);
            // 
            // labelNMDescHourlyRateLimit
            // 
            this.labelNMDescHourlyRateLimit.AutoSize = true;
            this.labelNMDescHourlyRateLimit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMDescHourlyRateLimit.Location = new System.Drawing.Point(483, 85);
            this.labelNMDescHourlyRateLimit.Name = "labelNMDescHourlyRateLimit";
            this.labelNMDescHourlyRateLimit.Size = new System.Drawing.Size(81, 13);
            this.labelNMDescHourlyRateLimit.TabIndex = 76;
            this.labelNMDescHourlyRateLimit.Text = "Hourly rate limit:";
            // 
            // labelNMAPIKeyStatus
            // 
            this.labelNMAPIKeyStatus.AutoSize = true;
            this.labelNMAPIKeyStatus.ForeColor = System.Drawing.Color.Red;
            this.labelNMAPIKeyStatus.Location = new System.Drawing.Point(296, 85);
            this.labelNMAPIKeyStatus.Name = "labelNMAPIKeyStatus";
            this.labelNMAPIKeyStatus.Size = new System.Drawing.Size(38, 13);
            this.labelNMAPIKeyStatus.TabIndex = 75;
            this.labelNMAPIKeyStatus.Text = "Invalid";
            // 
            // labelNMDescAPIKey
            // 
            this.labelNMDescAPIKey.AutoSize = true;
            this.labelNMDescAPIKey.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMDescAPIKey.Location = new System.Drawing.Point(173, 85);
            this.labelNMDescAPIKey.Name = "labelNMDescAPIKey";
            this.labelNMDescAPIKey.Size = new System.Drawing.Size(47, 13);
            this.labelNMDescAPIKey.TabIndex = 74;
            this.labelNMDescAPIKey.Text = "API key:";
            // 
            // pictureBoxNMProfilePicture
            // 
            this.pictureBoxNMProfilePicture.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxNMProfilePicture.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNMProfilePicture.Image")));
            this.pictureBoxNMProfilePicture.Location = new System.Drawing.Point(20, 20);
            this.pictureBoxNMProfilePicture.Name = "pictureBoxNMProfilePicture";
            this.pictureBoxNMProfilePicture.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxNMProfilePicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxNMProfilePicture.TabIndex = 65;
            this.pictureBoxNMProfilePicture.TabStop = false;
            this.pictureBoxNMProfilePicture.Click += new System.EventHandler(this.pictureBoxNMProfilePicture_Click);
            // 
            // labelNMUserName
            // 
            this.labelNMUserName.AutoSize = true;
            this.labelNMUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNMUserName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMUserName.Location = new System.Drawing.Point(170, 20);
            this.labelNMUserName.Name = "labelNMUserName";
            this.labelNMUserName.Size = new System.Drawing.Size(169, 33);
            this.labelNMUserName.TabIndex = 66;
            this.labelNMUserName.Text = "Anonymous";
            // 
            // labelNMDescMembership
            // 
            this.labelNMDescMembership.AutoSize = true;
            this.labelNMDescMembership.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMDescMembership.Location = new System.Drawing.Point(173, 64);
            this.labelNMDescMembership.Name = "labelNMDescMembership";
            this.labelNMDescMembership.Size = new System.Drawing.Size(67, 13);
            this.labelNMDescMembership.TabIndex = 67;
            this.labelNMDescMembership.Text = "Membership:";
            // 
            // labelNMDailyRateLimitReset
            // 
            this.labelNMDailyRateLimitReset.AutoSize = true;
            this.labelNMDailyRateLimitReset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMDailyRateLimitReset.Location = new System.Drawing.Point(611, 107);
            this.labelNMDailyRateLimitReset.Name = "labelNMDailyRateLimitReset";
            this.labelNMDailyRateLimitReset.Size = new System.Drawing.Size(36, 13);
            this.labelNMDailyRateLimitReset.TabIndex = 72;
            this.labelNMDailyRateLimitReset.Text = "Never";
            // 
            // labelNMMembership
            // 
            this.labelNMMembership.AutoSize = true;
            this.labelNMMembership.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMMembership.Location = new System.Drawing.Point(296, 64);
            this.labelNMMembership.Name = "labelNMMembership";
            this.labelNMMembership.Size = new System.Drawing.Size(33, 13);
            this.labelNMMembership.TabIndex = 68;
            this.labelNMMembership.Text = "Basic";
            // 
            // labelNMDescLimitReset
            // 
            this.labelNMDescLimitReset.AutoSize = true;
            this.labelNMDescLimitReset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMDescLimitReset.Location = new System.Drawing.Point(483, 107);
            this.labelNMDescLimitReset.Name = "labelNMDescLimitReset";
            this.labelNMDescLimitReset.Size = new System.Drawing.Size(57, 13);
            this.labelNMDescLimitReset.TabIndex = 71;
            this.labelNMDescLimitReset.Text = "Limit reset:";
            // 
            // labelNMDescDailyRateLimit
            // 
            this.labelNMDescDailyRateLimit.AutoSize = true;
            this.labelNMDescDailyRateLimit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMDescDailyRateLimit.Location = new System.Drawing.Point(483, 64);
            this.labelNMDescDailyRateLimit.Name = "labelNMDescDailyRateLimit";
            this.labelNMDescDailyRateLimit.Size = new System.Drawing.Size(74, 13);
            this.labelNMDescDailyRateLimit.TabIndex = 69;
            this.labelNMDescDailyRateLimit.Text = "Daily rate limit:";
            // 
            // labelNMDailyRateLimit
            // 
            this.labelNMDailyRateLimit.AutoSize = true;
            this.labelNMDailyRateLimit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMDailyRateLimit.Location = new System.Drawing.Point(611, 64);
            this.labelNMDailyRateLimit.Name = "labelNMDailyRateLimit";
            this.labelNMDailyRateLimit.Size = new System.Drawing.Size(30, 13);
            this.labelNMDailyRateLimit.TabIndex = 70;
            this.labelNMDailyRateLimit.Text = "0 left";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.buttonNWDeleteAll);
            this.panel1.Controls.Add(this.buttonNWLogout);
            this.panel1.Controls.Add(this.checkBoxNMDownloadThumbnails);
            this.panel1.Controls.Add(this.labelNMOptions);
            this.panel1.Controls.Add(this.checkBoxNMUpdateProfile);
            this.panel1.Controls.Add(this.checkBoxShowAPIKey);
            this.panel1.Controls.Add(this.labelNMInfo);
            this.panel1.Controls.Add(this.textBoxAPIKey);
            this.panel1.Controls.Add(this.labelNMAPIKeyTextBox);
            this.panel1.Controls.Add(this.buttonNMUpdateProfile);
            this.panel1.Location = new System.Drawing.Point(0, 169);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 343);
            this.panel1.TabIndex = 77;
            // 
            // buttonNWDeleteAll
            // 
            this.buttonNWDeleteAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.buttonNWDeleteAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNWDeleteAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNWDeleteAll.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonNWDeleteAll.Image = global::Fo76ini.Properties.Resources.delete_48;
            this.buttonNWDeleteAll.Location = new System.Drawing.Point(266, 7);
            this.buttonNWDeleteAll.Name = "buttonNWDeleteAll";
            this.buttonNWDeleteAll.Padding = new System.Windows.Forms.Padding(4);
            this.buttonNWDeleteAll.Size = new System.Drawing.Size(120, 120);
            this.buttonNWDeleteAll.TabIndex = 104;
            this.buttonNWDeleteAll.Text = "Delete cache";
            this.buttonNWDeleteAll.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonNWDeleteAll.UseVisualStyleBackColor = false;
            this.buttonNWDeleteAll.Click += new System.EventHandler(this.buttonNWDeleteAll_Click);
            // 
            // buttonNWLogout
            // 
            this.buttonNWLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(128)))), ((int)(((byte)(62)))));
            this.buttonNWLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNWLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNWLogout.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonNWLogout.Image = global::Fo76ini.Properties.Resources.exit_48;
            this.buttonNWLogout.Location = new System.Drawing.Point(140, 7);
            this.buttonNWLogout.Name = "buttonNWLogout";
            this.buttonNWLogout.Padding = new System.Windows.Forms.Padding(4);
            this.buttonNWLogout.Size = new System.Drawing.Size(120, 120);
            this.buttonNWLogout.TabIndex = 103;
            this.buttonNWLogout.Text = "Logout";
            this.buttonNWLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonNWLogout.UseVisualStyleBackColor = false;
            this.buttonNWLogout.Click += new System.EventHandler(this.buttonNWLogout_Click);
            // 
            // checkBoxNMDownloadThumbnails
            // 
            this.checkBoxNMDownloadThumbnails.AutoSize = true;
            this.checkBoxNMDownloadThumbnails.Checked = true;
            this.checkBoxNMDownloadThumbnails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNMDownloadThumbnails.Location = new System.Drawing.Point(15, 191);
            this.checkBoxNMDownloadThumbnails.Name = "checkBoxNMDownloadThumbnails";
            this.checkBoxNMDownloadThumbnails.Size = new System.Drawing.Size(127, 17);
            this.checkBoxNMDownloadThumbnails.TabIndex = 102;
            this.checkBoxNMDownloadThumbnails.Text = "Download thumbnails";
            this.checkBoxNMDownloadThumbnails.UseVisualStyleBackColor = true;
            this.checkBoxNMDownloadThumbnails.CheckedChanged += new System.EventHandler(this.checkBoxNMDownloadThumbnails_CheckedChanged);
            // 
            // labelNMOptions
            // 
            this.labelNMOptions.AutoSize = true;
            this.labelNMOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNMOptions.Location = new System.Drawing.Point(12, 146);
            this.labelNMOptions.Name = "labelNMOptions";
            this.labelNMOptions.Size = new System.Drawing.Size(61, 16);
            this.labelNMOptions.TabIndex = 101;
            this.labelNMOptions.Text = "Options";
            // 
            // checkBoxNMUpdateProfile
            // 
            this.checkBoxNMUpdateProfile.AutoSize = true;
            this.checkBoxNMUpdateProfile.Checked = true;
            this.checkBoxNMUpdateProfile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNMUpdateProfile.Location = new System.Drawing.Point(15, 168);
            this.checkBoxNMUpdateProfile.Name = "checkBoxNMUpdateProfile";
            this.checkBoxNMUpdateProfile.Size = new System.Drawing.Size(156, 17);
            this.checkBoxNMUpdateProfile.TabIndex = 100;
            this.checkBoxNMUpdateProfile.Text = "Update profile automatically";
            this.checkBoxNMUpdateProfile.UseVisualStyleBackColor = true;
            this.checkBoxNMUpdateProfile.CheckedChanged += new System.EventHandler(this.checkBoxNMUpdateProfile_CheckedChanged);
            // 
            // checkBoxShowAPIKey
            // 
            this.checkBoxShowAPIKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxShowAPIKey.AutoSize = true;
            this.checkBoxShowAPIKey.Location = new System.Drawing.Point(84, 315);
            this.checkBoxShowAPIKey.Name = "checkBoxShowAPIKey";
            this.checkBoxShowAPIKey.Size = new System.Drawing.Size(94, 17);
            this.checkBoxShowAPIKey.TabIndex = 98;
            this.checkBoxShowAPIKey.Text = "Show API Key";
            this.checkBoxShowAPIKey.UseVisualStyleBackColor = true;
            this.checkBoxShowAPIKey.CheckedChanged += new System.EventHandler(this.checkBoxShowAPIKey_CheckedChanged);
            // 
            // labelNMInfo
            // 
            this.labelNMInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNMInfo.ForeColor = System.Drawing.Color.DimGray;
            this.labelNMInfo.Location = new System.Drawing.Point(514, 18);
            this.labelNMInfo.Name = "labelNMInfo";
            this.labelNMInfo.Size = new System.Drawing.Size(320, 260);
            this.labelNMInfo.TabIndex = 96;
            this.labelNMInfo.Text = resources.GetString("labelNMInfo.Text");
            // 
            // textBoxAPIKey
            // 
            this.textBoxAPIKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxAPIKey.Location = new System.Drawing.Point(84, 288);
            this.textBoxAPIKey.Name = "textBoxAPIKey";
            this.textBoxAPIKey.Size = new System.Drawing.Size(748, 20);
            this.textBoxAPIKey.TabIndex = 92;
            this.textBoxAPIKey.UseSystemPasswordChar = true;
            this.textBoxAPIKey.TextChanged += new System.EventHandler(this.textBoxAPIKey_TextChanged);
            // 
            // labelNMAPIKeyTextBox
            // 
            this.labelNMAPIKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelNMAPIKeyTextBox.AutoSize = true;
            this.labelNMAPIKeyTextBox.Location = new System.Drawing.Point(12, 291);
            this.labelNMAPIKeyTextBox.Name = "labelNMAPIKeyTextBox";
            this.labelNMAPIKeyTextBox.Size = new System.Drawing.Size(48, 13);
            this.labelNMAPIKeyTextBox.TabIndex = 91;
            this.labelNMAPIKeyTextBox.Text = "API Key:";
            // 
            // buttonNMUpdateProfile
            // 
            this.buttonNMUpdateProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(142)))), ((int)(((byte)(53)))));
            this.buttonNMUpdateProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNMUpdateProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNMUpdateProfile.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonNMUpdateProfile.Image = global::Fo76ini.Properties.Resources.available_updates_48;
            this.buttonNMUpdateProfile.Location = new System.Drawing.Point(12, 7);
            this.buttonNMUpdateProfile.Name = "buttonNMUpdateProfile";
            this.buttonNMUpdateProfile.Padding = new System.Windows.Forms.Padding(4);
            this.buttonNMUpdateProfile.Size = new System.Drawing.Size(120, 120);
            this.buttonNMUpdateProfile.TabIndex = 94;
            this.buttonNMUpdateProfile.Text = "Update profile";
            this.buttonNMUpdateProfile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonNMUpdateProfile.UseVisualStyleBackColor = false;
            this.buttonNMUpdateProfile.Click += new System.EventHandler(this.buttonNMUpdateProfile_Click);
            // 
            // FormNexus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 511);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(860, 550);
            this.Name = "FormNexus";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "NexusMods API Integration";
            this.Load += new System.EventHandler(this.FormNexus_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNMProfilePicture)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelNMNotLoggedIn;
        private System.Windows.Forms.Label labelNMUserID;
        private System.Windows.Forms.Label labelNMDescUserID;
        private System.Windows.Forms.Label labelNMHourlyRateLimit;
        private System.Windows.Forms.LinkLabel linkLabelNMGetAPIKey;
        private System.Windows.Forms.Label labelNMDescHourlyRateLimit;
        private System.Windows.Forms.Label labelNMAPIKeyStatus;
        private System.Windows.Forms.Label labelNMDescAPIKey;
        private System.Windows.Forms.PictureBox pictureBoxNMProfilePicture;
        private System.Windows.Forms.Label labelNMUserName;
        private System.Windows.Forms.Label labelNMDescMembership;
        private System.Windows.Forms.Label labelNMDailyRateLimitReset;
        private System.Windows.Forms.Label labelNMMembership;
        private System.Windows.Forms.Label labelNMDescLimitReset;
        private System.Windows.Forms.Label labelNMDescDailyRateLimit;
        private System.Windows.Forms.Label labelNMDailyRateLimit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonNWLogout;
        private System.Windows.Forms.CheckBox checkBoxNMDownloadThumbnails;
        private System.Windows.Forms.Label labelNMOptions;
        private System.Windows.Forms.CheckBox checkBoxNMUpdateProfile;
        private System.Windows.Forms.CheckBox checkBoxShowAPIKey;
        private System.Windows.Forms.Label labelNMInfo;
        private System.Windows.Forms.TextBox textBoxAPIKey;
        private System.Windows.Forms.Label labelNMAPIKeyTextBox;
        private System.Windows.Forms.Button buttonNMUpdateProfile;
        private System.Windows.Forms.Button buttonNWDeleteAll;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRetrieveProfileInfo;
    }
}