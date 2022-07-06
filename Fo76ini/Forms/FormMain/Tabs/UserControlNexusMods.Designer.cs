namespace Fo76ini.Forms.FormMain.Tabs
{
    partial class UserControlNexusMods
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlNexusMods));
            this.labelTitleNexus = new System.Windows.Forms.Label();
            this.labelNexusDesc = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabelEnableAPIKey = new System.Windows.Forms.LinkLabel();
            this.pictureBoxAPIKeyHelp = new System.Windows.Forms.PictureBox();
            this.linkLabelAPIKeyHelp = new System.Windows.Forms.LinkLabel();
            this.buttonNMLoginManually = new System.Windows.Forms.Button();
            this.labelAPIKey = new System.Windows.Forms.Label();
            this.checkBoxShowAPIKey = new System.Windows.Forms.CheckBox();
            this.textBoxAPIKey = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonNMLogin = new System.Windows.Forms.Button();
            this.buttonNWDeleteCache = new System.Windows.Forms.Button();
            this.buttonNWLogout = new System.Windows.Forms.Button();
            this.checkBoxNMDownloadThumbnails = new System.Windows.Forms.CheckBox();
            this.labelNMOptions = new System.Windows.Forms.Label();
            this.checkBoxNMUpdateProfile = new System.Windows.Forms.CheckBox();
            this.buttonNMUpdateProfile = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelNMNotLoggedIn = new System.Windows.Forms.Label();
            this.labelNMUserID = new System.Windows.Forms.Label();
            this.labelNMDescUserID = new System.Windows.Forms.Label();
            this.labelNMHourlyRateLimit = new System.Windows.Forms.Label();
            this.labelNMDescHourlyRateLimit = new System.Windows.Forms.Label();
            this.pictureBoxNMProfilePicture = new System.Windows.Forms.PictureBox();
            this.labelNMUserName = new System.Windows.Forms.Label();
            this.labelNMDescMembership = new System.Windows.Forms.Label();
            this.labelNMRateLimitReset = new System.Windows.Forms.Label();
            this.labelNMMembership = new System.Windows.Forms.Label();
            this.labelNMDescLimitReset = new System.Windows.Forms.Label();
            this.labelNMDescDailyRateLimit = new System.Windows.Forms.Label();
            this.labelNMDailyRateLimit = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAPIKeyHelp)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNMProfilePicture)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitleNexus
            // 
            this.labelTitleNexus.AutoSize = true;
            this.labelTitleNexus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitleNexus.Location = new System.Drawing.Point(6, 6);
            this.labelTitleNexus.Name = "labelTitleNexus";
            this.labelTitleNexus.Size = new System.Drawing.Size(204, 24);
            this.labelTitleNexus.TabIndex = 4;
            this.labelTitleNexus.Text = "NexusMods Integration";
            // 
            // labelNexusDesc
            // 
            this.labelNexusDesc.AutoSize = true;
            this.labelNexusDesc.Location = new System.Drawing.Point(7, 30);
            this.labelNexusDesc.Name = "labelNexusDesc";
            this.labelNexusDesc.Size = new System.Drawing.Size(274, 13);
            this.labelNexusDesc.TabIndex = 75;
            this.labelNexusDesc.Text = "Login to your NexusMods account to use the integration.";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
            this.panel2.Controls.Add(this.linkLabelEnableAPIKey);
            this.panel2.Controls.Add(this.pictureBoxAPIKeyHelp);
            this.panel2.Controls.Add(this.linkLabelAPIKeyHelp);
            this.panel2.Controls.Add(this.buttonNMLoginManually);
            this.panel2.Controls.Add(this.labelAPIKey);
            this.panel2.Controls.Add(this.checkBoxShowAPIKey);
            this.panel2.Controls.Add(this.textBoxAPIKey);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.buttonNMLogin);
            this.panel2.Controls.Add(this.buttonNWDeleteCache);
            this.panel2.Controls.Add(this.buttonNWLogout);
            this.panel2.Controls.Add(this.checkBoxNMDownloadThumbnails);
            this.panel2.Controls.Add(this.labelNMOptions);
            this.panel2.Controls.Add(this.checkBoxNMUpdateProfile);
            this.panel2.Controls.Add(this.buttonNMUpdateProfile);
            this.panel2.Location = new System.Drawing.Point(0, 228);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(700, 372);
            this.panel2.TabIndex = 80;
            // 
            // linkLabelEnableAPIKey
            // 
            this.linkLabelEnableAPIKey.AutoSize = true;
            this.linkLabelEnableAPIKey.Location = new System.Drawing.Point(6, 318);
            this.linkLabelEnableAPIKey.Name = "linkLabelEnableAPIKey";
            this.linkLabelEnableAPIKey.Size = new System.Drawing.Size(287, 13);
            this.linkLabelEnableAPIKey.TabIndex = 113;
            this.linkLabelEnableAPIKey.TabStop = true;
            this.linkLabelEnableAPIKey.Text = "Login doesn\'t work? Click here to use your API key instead.";
            // 
            // pictureBoxAPIKeyHelp
            // 
            this.pictureBoxAPIKeyHelp.Image = global::Fo76ini.Properties.Resources.help_24;
            this.pictureBoxAPIKeyHelp.Location = new System.Drawing.Point(20, 258);
            this.pictureBoxAPIKeyHelp.Name = "pictureBoxAPIKeyHelp";
            this.pictureBoxAPIKeyHelp.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxAPIKeyHelp.TabIndex = 112;
            this.pictureBoxAPIKeyHelp.TabStop = false;
            // 
            // linkLabelAPIKeyHelp
            // 
            this.linkLabelAPIKeyHelp.AutoSize = true;
            this.linkLabelAPIKeyHelp.Location = new System.Drawing.Point(51, 264);
            this.linkLabelAPIKeyHelp.Name = "linkLabelAPIKeyHelp";
            this.linkLabelAPIKeyHelp.Size = new System.Drawing.Size(158, 13);
            this.linkLabelAPIKeyHelp.TabIndex = 111;
            this.linkLabelAPIKeyHelp.TabStop = true;
            this.linkLabelAPIKeyHelp.Text = "How do I login with an API key?";
            // 
            // buttonNMLoginManually
            // 
            this.buttonNMLoginManually.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(142)))), ((int)(((byte)(53)))));
            this.buttonNMLoginManually.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNMLoginManually.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNMLoginManually.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonNMLoginManually.Image = global::Fo76ini.Properties.Resources.login_48;
            this.buttonNMLoginManually.Location = new System.Drawing.Point(146, 23);
            this.buttonNMLoginManually.Name = "buttonNMLoginManually";
            this.buttonNMLoginManually.Padding = new System.Windows.Forms.Padding(4);
            this.buttonNMLoginManually.Size = new System.Drawing.Size(120, 120);
            this.buttonNMLoginManually.TabIndex = 110;
            this.buttonNMLoginManually.Text = "Log in with key";
            this.buttonNMLoginManually.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonNMLoginManually.UseVisualStyleBackColor = false;
            // 
            // labelAPIKey
            // 
            this.labelAPIKey.AutoSize = true;
            this.labelAPIKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAPIKey.Location = new System.Drawing.Point(6, 239);
            this.labelAPIKey.Name = "labelAPIKey";
            this.labelAPIKey.Size = new System.Drawing.Size(61, 16);
            this.labelAPIKey.TabIndex = 109;
            this.labelAPIKey.Text = "API Key";
            // 
            // checkBoxShowAPIKey
            // 
            this.checkBoxShowAPIKey.AutoSize = true;
            this.checkBoxShowAPIKey.Location = new System.Drawing.Point(20, 314);
            this.checkBoxShowAPIKey.Name = "checkBoxShowAPIKey";
            this.checkBoxShowAPIKey.Size = new System.Drawing.Size(93, 17);
            this.checkBoxShowAPIKey.TabIndex = 108;
            this.checkBoxShowAPIKey.Text = "Show API key";
            this.checkBoxShowAPIKey.UseVisualStyleBackColor = true;
            // 
            // textBoxAPIKey
            // 
            this.textBoxAPIKey.Location = new System.Drawing.Point(20, 288);
            this.textBoxAPIKey.Name = "textBoxAPIKey";
            this.textBoxAPIKey.Size = new System.Drawing.Size(726, 20);
            this.textBoxAPIKey.TabIndex = 107;
            this.textBoxAPIKey.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 106;
            this.label1.Text = "Actions";
            // 
            // buttonNMLogin
            // 
            this.buttonNMLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(142)))), ((int)(((byte)(53)))));
            this.buttonNMLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNMLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNMLogin.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonNMLogin.Image = global::Fo76ini.Properties.Resources.login_48;
            this.buttonNMLogin.Location = new System.Drawing.Point(20, 23);
            this.buttonNMLogin.Name = "buttonNMLogin";
            this.buttonNMLogin.Padding = new System.Windows.Forms.Padding(4);
            this.buttonNMLogin.Size = new System.Drawing.Size(120, 120);
            this.buttonNMLogin.TabIndex = 105;
            this.buttonNMLogin.Text = "Log in";
            this.buttonNMLogin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonNMLogin.UseVisualStyleBackColor = false;
            // 
            // buttonNWDeleteCache
            // 
            this.buttonNWDeleteCache.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(34)))), ((int)(((byte)(34)))));
            this.buttonNWDeleteCache.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNWDeleteCache.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNWDeleteCache.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonNWDeleteCache.Image = global::Fo76ini.Properties.Resources.delete_48;
            this.buttonNWDeleteCache.Location = new System.Drawing.Point(524, 23);
            this.buttonNWDeleteCache.Name = "buttonNWDeleteCache";
            this.buttonNWDeleteCache.Padding = new System.Windows.Forms.Padding(4);
            this.buttonNWDeleteCache.Size = new System.Drawing.Size(120, 120);
            this.buttonNWDeleteCache.TabIndex = 104;
            this.buttonNWDeleteCache.Text = "Delete cache";
            this.buttonNWDeleteCache.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonNWDeleteCache.UseVisualStyleBackColor = false;
            // 
            // buttonNWLogout
            // 
            this.buttonNWLogout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(128)))), ((int)(((byte)(62)))));
            this.buttonNWLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNWLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNWLogout.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonNWLogout.Image = global::Fo76ini.Properties.Resources.exit_48;
            this.buttonNWLogout.Location = new System.Drawing.Point(272, 23);
            this.buttonNWLogout.Name = "buttonNWLogout";
            this.buttonNWLogout.Padding = new System.Windows.Forms.Padding(4);
            this.buttonNWLogout.Size = new System.Drawing.Size(120, 120);
            this.buttonNWLogout.TabIndex = 103;
            this.buttonNWLogout.Text = "Logout";
            this.buttonNWLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonNWLogout.UseVisualStyleBackColor = false;
            // 
            // checkBoxNMDownloadThumbnails
            // 
            this.checkBoxNMDownloadThumbnails.AutoSize = true;
            this.checkBoxNMDownloadThumbnails.Checked = true;
            this.checkBoxNMDownloadThumbnails.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNMDownloadThumbnails.Location = new System.Drawing.Point(20, 200);
            this.checkBoxNMDownloadThumbnails.Name = "checkBoxNMDownloadThumbnails";
            this.checkBoxNMDownloadThumbnails.Size = new System.Drawing.Size(127, 17);
            this.checkBoxNMDownloadThumbnails.TabIndex = 102;
            this.checkBoxNMDownloadThumbnails.Text = "Download thumbnails";
            this.checkBoxNMDownloadThumbnails.UseVisualStyleBackColor = true;
            // 
            // labelNMOptions
            // 
            this.labelNMOptions.AutoSize = true;
            this.labelNMOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNMOptions.Location = new System.Drawing.Point(6, 155);
            this.labelNMOptions.Name = "labelNMOptions";
            this.labelNMOptions.Size = new System.Drawing.Size(60, 16);
            this.labelNMOptions.TabIndex = 101;
            this.labelNMOptions.Text = "Options";
            // 
            // checkBoxNMUpdateProfile
            // 
            this.checkBoxNMUpdateProfile.AutoSize = true;
            this.checkBoxNMUpdateProfile.Checked = true;
            this.checkBoxNMUpdateProfile.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxNMUpdateProfile.Location = new System.Drawing.Point(20, 177);
            this.checkBoxNMUpdateProfile.Name = "checkBoxNMUpdateProfile";
            this.checkBoxNMUpdateProfile.Size = new System.Drawing.Size(156, 17);
            this.checkBoxNMUpdateProfile.TabIndex = 100;
            this.checkBoxNMUpdateProfile.Text = "Update profile automatically";
            this.checkBoxNMUpdateProfile.UseVisualStyleBackColor = true;
            // 
            // buttonNMUpdateProfile
            // 
            this.buttonNMUpdateProfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(142)))), ((int)(((byte)(53)))));
            this.buttonNMUpdateProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNMUpdateProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonNMUpdateProfile.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonNMUpdateProfile.Image = global::Fo76ini.Properties.Resources.available_updates_48;
            this.buttonNMUpdateProfile.Location = new System.Drawing.Point(398, 23);
            this.buttonNMUpdateProfile.Name = "buttonNMUpdateProfile";
            this.buttonNMUpdateProfile.Padding = new System.Windows.Forms.Padding(4);
            this.buttonNMUpdateProfile.Size = new System.Drawing.Size(120, 120);
            this.buttonNMUpdateProfile.TabIndex = 94;
            this.buttonNMUpdateProfile.Text = "Update profile";
            this.buttonNMUpdateProfile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonNMUpdateProfile.UseVisualStyleBackColor = false;
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
            this.panel3.Controls.Add(this.labelNMDescHourlyRateLimit);
            this.panel3.Controls.Add(this.pictureBoxNMProfilePicture);
            this.panel3.Controls.Add(this.labelNMUserName);
            this.panel3.Controls.Add(this.labelNMDescMembership);
            this.panel3.Controls.Add(this.labelNMRateLimitReset);
            this.panel3.Controls.Add(this.labelNMMembership);
            this.panel3.Controls.Add(this.labelNMDescLimitReset);
            this.panel3.Controls.Add(this.labelNMDescDailyRateLimit);
            this.panel3.Controls.Add(this.labelNMDailyRateLimit);
            this.panel3.Location = new System.Drawing.Point(0, 59);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(700, 170);
            this.panel3.TabIndex = 79;
            // 
            // labelNMNotLoggedIn
            // 
            this.labelNMNotLoggedIn.AutoSize = true;
            this.labelNMNotLoggedIn.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMNotLoggedIn.Location = new System.Drawing.Point(173, 57);
            this.labelNMNotLoggedIn.Name = "labelNMNotLoggedIn";
            this.labelNMNotLoggedIn.Size = new System.Drawing.Size(73, 13);
            this.labelNMNotLoggedIn.TabIndex = 80;
            this.labelNMNotLoggedIn.Text = "Not logged in.";
            // 
            // labelNMUserID
            // 
            this.labelNMUserID.AutoSize = true;
            this.labelNMUserID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMUserID.Location = new System.Drawing.Point(296, 85);
            this.labelNMUserID.Name = "labelNMUserID";
            this.labelNMUserID.Size = new System.Drawing.Size(16, 13);
            this.labelNMUserID.TabIndex = 79;
            this.labelNMUserID.Text = "-1";
            // 
            // labelNMDescUserID
            // 
            this.labelNMDescUserID.AutoSize = true;
            this.labelNMDescUserID.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMDescUserID.Location = new System.Drawing.Point(173, 85);
            this.labelNMDescUserID.Name = "labelNMDescUserID";
            this.labelNMDescUserID.Size = new System.Drawing.Size(46, 13);
            this.labelNMDescUserID.TabIndex = 78;
            this.labelNMDescUserID.Text = "User-ID:";
            // 
            // labelNMHourlyRateLimit
            // 
            this.labelNMHourlyRateLimit.AutoSize = true;
            this.labelNMHourlyRateLimit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMHourlyRateLimit.Location = new System.Drawing.Point(585, 85);
            this.labelNMHourlyRateLimit.Name = "labelNMHourlyRateLimit";
            this.labelNMHourlyRateLimit.Size = new System.Drawing.Size(30, 13);
            this.labelNMHourlyRateLimit.TabIndex = 77;
            this.labelNMHourlyRateLimit.Text = "0 left";
            // 
            // labelNMDescHourlyRateLimit
            // 
            this.labelNMDescHourlyRateLimit.AutoSize = true;
            this.labelNMDescHourlyRateLimit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMDescHourlyRateLimit.Location = new System.Drawing.Point(457, 85);
            this.labelNMDescHourlyRateLimit.Name = "labelNMDescHourlyRateLimit";
            this.labelNMDescHourlyRateLimit.Size = new System.Drawing.Size(81, 13);
            this.labelNMDescHourlyRateLimit.TabIndex = 76;
            this.labelNMDescHourlyRateLimit.Text = "Hourly rate limit:";
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
            // labelNMRateLimitReset
            // 
            this.labelNMRateLimitReset.AutoSize = true;
            this.labelNMRateLimitReset.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMRateLimitReset.Location = new System.Drawing.Point(585, 107);
            this.labelNMRateLimitReset.Name = "labelNMRateLimitReset";
            this.labelNMRateLimitReset.Size = new System.Drawing.Size(36, 13);
            this.labelNMRateLimitReset.TabIndex = 72;
            this.labelNMRateLimitReset.Text = "Never";
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
            this.labelNMDescLimitReset.Location = new System.Drawing.Point(457, 107);
            this.labelNMDescLimitReset.Name = "labelNMDescLimitReset";
            this.labelNMDescLimitReset.Size = new System.Drawing.Size(79, 13);
            this.labelNMDescLimitReset.TabIndex = 71;
            this.labelNMDescLimitReset.Text = "Rate limit reset:";
            // 
            // labelNMDescDailyRateLimit
            // 
            this.labelNMDescDailyRateLimit.AutoSize = true;
            this.labelNMDescDailyRateLimit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMDescDailyRateLimit.Location = new System.Drawing.Point(457, 64);
            this.labelNMDescDailyRateLimit.Name = "labelNMDescDailyRateLimit";
            this.labelNMDescDailyRateLimit.Size = new System.Drawing.Size(74, 13);
            this.labelNMDescDailyRateLimit.TabIndex = 69;
            this.labelNMDescDailyRateLimit.Text = "Daily rate limit:";
            // 
            // labelNMDailyRateLimit
            // 
            this.labelNMDailyRateLimit.AutoSize = true;
            this.labelNMDailyRateLimit.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelNMDailyRateLimit.Location = new System.Drawing.Point(585, 64);
            this.labelNMDailyRateLimit.Name = "labelNMDailyRateLimit";
            this.labelNMDailyRateLimit.Size = new System.Drawing.Size(30, 13);
            this.labelNMDailyRateLimit.TabIndex = 70;
            this.labelNMDailyRateLimit.Text = "0 left";
            // 
            // UserControlNexusMods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.labelNexusDesc);
            this.Controls.Add(this.labelTitleNexus);
            this.Name = "UserControlNexusMods";
            this.Size = new System.Drawing.Size(700, 600);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAPIKeyHelp)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNMProfilePicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitleNexus;
        private System.Windows.Forms.Label labelNexusDesc;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel linkLabelEnableAPIKey;
        private System.Windows.Forms.PictureBox pictureBoxAPIKeyHelp;
        private System.Windows.Forms.LinkLabel linkLabelAPIKeyHelp;
        private System.Windows.Forms.Button buttonNMLoginManually;
        private System.Windows.Forms.Label labelAPIKey;
        private System.Windows.Forms.CheckBox checkBoxShowAPIKey;
        private System.Windows.Forms.TextBox textBoxAPIKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonNMLogin;
        private System.Windows.Forms.Button buttonNWDeleteCache;
        private System.Windows.Forms.Button buttonNWLogout;
        private System.Windows.Forms.CheckBox checkBoxNMDownloadThumbnails;
        private System.Windows.Forms.Label labelNMOptions;
        private System.Windows.Forms.CheckBox checkBoxNMUpdateProfile;
        private System.Windows.Forms.Button buttonNMUpdateProfile;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelNMNotLoggedIn;
        private System.Windows.Forms.Label labelNMUserID;
        private System.Windows.Forms.Label labelNMDescUserID;
        private System.Windows.Forms.Label labelNMHourlyRateLimit;
        private System.Windows.Forms.Label labelNMDescHourlyRateLimit;
        private System.Windows.Forms.PictureBox pictureBoxNMProfilePicture;
        private System.Windows.Forms.Label labelNMUserName;
        private System.Windows.Forms.Label labelNMDescMembership;
        private System.Windows.Forms.Label labelNMRateLimitReset;
        private System.Windows.Forms.Label labelNMMembership;
        private System.Windows.Forms.Label labelNMDescLimitReset;
        private System.Windows.Forms.Label labelNMDescDailyRateLimit;
        private System.Windows.Forms.Label labelNMDailyRateLimit;
    }
}
