namespace Fo76ini.Forms.FormMain.Tabs
{
    partial class UserControlProfiles
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("Default", 0);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Steam"}, 2, System.Drawing.Color.Empty, System.Drawing.SystemColors.Window, null);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem("Bethesda.net", 1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem("Bethesda.net PTS", 1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem("Xbox", 3);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlProfiles));
            this.tabControl = new Fo76ini.Controls.TabControlWithoutHeader();
            this.tabPageSelect = new System.Windows.Forms.TabPage();
            this.labelSelectTitle = new System.Windows.Forms.Label();
            this.buttonEditProfile = new System.Windows.Forms.Button();
            this.buttonDeleteProfile = new System.Windows.Forms.Button();
            this.listViewGameInstances = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.buttonAddProfile = new System.Windows.Forms.Button();
            this.tabPageEdit = new System.Windows.Forms.TabPage();
            this.labelEditTitle = new System.Windows.Forms.Label();
            this.linkLabelNavigationBack = new System.Windows.Forms.LinkLabel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.linkLabelAutoDetect = new System.Windows.Forms.LinkLabel();
            this.checkBoxMoreOptions = new System.Windows.Forms.CheckBox();
            this.labelGamePath = new System.Windows.Forms.Label();
            this.panelAdvancedOptions = new System.Windows.Forms.Panel();
            this.pictureBoxAPIKeyHelp = new System.Windows.Forms.PictureBox();
            this.linkLabelProfilesHelp = new System.Windows.Forms.LinkLabel();
            this.labelIniPath = new System.Windows.Forms.Label();
            this.buttonPickIniPath = new System.Windows.Forms.Button();
            this.textBoxIniPath = new System.Windows.Forms.TextBox();
            this.textBoxLaunchURL = new System.Windows.Forms.TextBox();
            this.labelProfileAdvancedOptions = new System.Windows.Forms.Label();
            this.labelLaunchURL = new System.Windows.Forms.Label();
            this.labelLaunchOptionMSStoreNotice = new System.Windows.Forms.Label();
            this.textBoxParameters = new System.Windows.Forms.TextBox();
            this.labelProfileLaunchOptions = new System.Windows.Forms.Label();
            this.labelParameters = new System.Windows.Forms.Label();
            this.radioButtonLaunchViaExecutable = new System.Windows.Forms.RadioButton();
            this.textBoxExecutable = new System.Windows.Forms.TextBox();
            this.radioButtonLaunchViaLink = new System.Windows.Forms.RadioButton();
            this.labelExecutable = new System.Windows.Forms.Label();
            this.textBoxIniPrefix = new System.Windows.Forms.TextBox();
            this.labelIniPrefix = new System.Windows.Forms.Label();
            this.labelGameEdition = new System.Windows.Forms.Label();
            this.comboBoxGameEdition = new ComboxExtended.ImagedComboBox();
            this.labelProfileName = new System.Windows.Forms.Label();
            this.buttonPickGamePath = new System.Windows.Forms.Button();
            this.textBoxProfileName = new System.Windows.Forms.TextBox();
            this.textBoxGamePath = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPageSelect.SuspendLayout();
            this.tabPageEdit.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.panelAdvancedOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAPIKeyHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageSelect);
            this.tabControl.Controls.Add(this.tabPageEdit);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(480, 400);
            this.tabControl.TabIndex = 23;
            // 
            // tabPageSelect
            // 
            this.tabPageSelect.BackColor = System.Drawing.Color.White;
            this.tabPageSelect.Controls.Add(this.labelSelectTitle);
            this.tabPageSelect.Controls.Add(this.buttonEditProfile);
            this.tabPageSelect.Controls.Add(this.buttonDeleteProfile);
            this.tabPageSelect.Controls.Add(this.listViewGameInstances);
            this.tabPageSelect.Controls.Add(this.buttonAddProfile);
            this.tabPageSelect.Location = new System.Drawing.Point(4, 22);
            this.tabPageSelect.Name = "tabPageSelect";
            this.tabPageSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSelect.Size = new System.Drawing.Size(472, 374);
            this.tabPageSelect.TabIndex = 0;
            this.tabPageSelect.Text = "Select";
            // 
            // labelSelectTitle
            // 
            this.labelSelectTitle.AutoSize = true;
            this.labelSelectTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectTitle.Location = new System.Drawing.Point(10, 15);
            this.labelSelectTitle.Name = "labelSelectTitle";
            this.labelSelectTitle.Size = new System.Drawing.Size(83, 30);
            this.labelSelectTitle.TabIndex = 44;
            this.labelSelectTitle.Text = "Profiles";
            // 
            // buttonEditProfile
            // 
            this.buttonEditProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditProfile.Location = new System.Drawing.Point(351, 94);
            this.buttonEditProfile.Name = "buttonEditProfile";
            this.buttonEditProfile.Size = new System.Drawing.Size(115, 28);
            this.buttonEditProfile.TabIndex = 43;
            this.buttonEditProfile.Text = "Edit profile";
            this.buttonEditProfile.UseVisualStyleBackColor = true;
            this.buttonEditProfile.Click += new System.EventHandler(this.buttonEditProfile_Click);
            // 
            // buttonDeleteProfile
            // 
            this.buttonDeleteProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteProfile.Location = new System.Drawing.Point(351, 128);
            this.buttonDeleteProfile.Name = "buttonDeleteProfile";
            this.buttonDeleteProfile.Size = new System.Drawing.Size(115, 28);
            this.buttonDeleteProfile.TabIndex = 42;
            this.buttonDeleteProfile.Text = "Delete profile";
            this.buttonDeleteProfile.UseVisualStyleBackColor = true;
            this.buttonDeleteProfile.Click += new System.EventHandler(this.buttonDeleteProfile_Click);
            // 
            // listViewGameInstances
            // 
            this.listViewGameInstances.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewGameInstances.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listViewGameInstances.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewGameInstances.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listViewGameInstances.FullRowSelect = true;
            this.listViewGameInstances.HideSelection = false;
            this.listViewGameInstances.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5});
            this.listViewGameInstances.LabelWrap = false;
            this.listViewGameInstances.Location = new System.Drawing.Point(15, 60);
            this.listViewGameInstances.MultiSelect = false;
            this.listViewGameInstances.Name = "listViewGameInstances";
            this.listViewGameInstances.Size = new System.Drawing.Size(330, 301);
            this.listViewGameInstances.SmallImageList = this.imageList;
            this.listViewGameInstances.TabIndex = 21;
            this.listViewGameInstances.UseCompatibleStateImageBehavior = false;
            this.listViewGameInstances.View = System.Windows.Forms.View.Details;
            this.listViewGameInstances.SelectedIndexChanged += new System.EventHandler(this.listViewGameInstances_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Game";
            this.columnHeader1.Width = 286;
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "help-24.png");
            this.imageList.Images.SetKeyName(1, "bethesda_24px.png");
            this.imageList.Images.SetKeyName(2, "steam_24px.png");
            this.imageList.Images.SetKeyName(3, "xbox_24px.png");
            // 
            // buttonAddProfile
            // 
            this.buttonAddProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddProfile.Location = new System.Drawing.Point(351, 60);
            this.buttonAddProfile.Name = "buttonAddProfile";
            this.buttonAddProfile.Size = new System.Drawing.Size(115, 28);
            this.buttonAddProfile.TabIndex = 3;
            this.buttonAddProfile.Text = "Add profile";
            this.buttonAddProfile.UseVisualStyleBackColor = true;
            this.buttonAddProfile.Click += new System.EventHandler(this.buttonAddProfile_Click);
            // 
            // tabPageEdit
            // 
            this.tabPageEdit.BackColor = System.Drawing.Color.White;
            this.tabPageEdit.Controls.Add(this.labelEditTitle);
            this.tabPageEdit.Controls.Add(this.linkLabelNavigationBack);
            this.tabPageEdit.Controls.Add(this.panelSettings);
            this.tabPageEdit.Location = new System.Drawing.Point(4, 22);
            this.tabPageEdit.Name = "tabPageEdit";
            this.tabPageEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEdit.Size = new System.Drawing.Size(472, 374);
            this.tabPageEdit.TabIndex = 1;
            this.tabPageEdit.Text = "Edit";
            // 
            // labelEditTitle
            // 
            this.labelEditTitle.AutoSize = true;
            this.labelEditTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditTitle.Location = new System.Drawing.Point(10, 15);
            this.labelEditTitle.Name = "labelEditTitle";
            this.labelEditTitle.Size = new System.Drawing.Size(118, 30);
            this.labelEditTitle.TabIndex = 42;
            this.labelEditTitle.Text = "Edit profile";
            // 
            // linkLabelNavigationBack
            // 
            this.linkLabelNavigationBack.AutoSize = true;
            this.linkLabelNavigationBack.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelNavigationBack.Location = new System.Drawing.Point(12, 45);
            this.linkLabelNavigationBack.Name = "linkLabelNavigationBack";
            this.linkLabelNavigationBack.Size = new System.Drawing.Size(220, 17);
            this.linkLabelNavigationBack.TabIndex = 41;
            this.linkLabelNavigationBack.TabStop = true;
            this.linkLabelNavigationBack.Text = "← Save profile and back to selection";
            this.linkLabelNavigationBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNavigationBack_LinkClicked);
            // 
            // panelSettings
            // 
            this.panelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelSettings.AutoScroll = true;
            this.panelSettings.AutoScrollMargin = new System.Drawing.Size(0, 8);
            this.panelSettings.BackColor = System.Drawing.SystemColors.Window;
            this.panelSettings.Controls.Add(this.linkLabelAutoDetect);
            this.panelSettings.Controls.Add(this.checkBoxMoreOptions);
            this.panelSettings.Controls.Add(this.labelGamePath);
            this.panelSettings.Controls.Add(this.panelAdvancedOptions);
            this.panelSettings.Controls.Add(this.labelGameEdition);
            this.panelSettings.Controls.Add(this.comboBoxGameEdition);
            this.panelSettings.Controls.Add(this.labelProfileName);
            this.panelSettings.Controls.Add(this.buttonPickGamePath);
            this.panelSettings.Controls.Add(this.textBoxProfileName);
            this.panelSettings.Controls.Add(this.textBoxGamePath);
            this.panelSettings.Location = new System.Drawing.Point(6, 72);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(466, 302);
            this.panelSettings.TabIndex = 39;
            // 
            // linkLabelAutoDetect
            // 
            this.linkLabelAutoDetect.AutoSize = true;
            this.linkLabelAutoDetect.Location = new System.Drawing.Point(110, 85);
            this.linkLabelAutoDetect.Name = "linkLabelAutoDetect";
            this.linkLabelAutoDetect.Size = new System.Drawing.Size(100, 13);
            this.linkLabelAutoDetect.TabIndex = 38;
            this.linkLabelAutoDetect.TabStop = true;
            this.linkLabelAutoDetect.Text = "Attempt auto-detect";
            this.linkLabelAutoDetect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAutoDetect_LinkClicked);
            // 
            // checkBoxMoreOptions
            // 
            this.checkBoxMoreOptions.AutoSize = true;
            this.checkBoxMoreOptions.Location = new System.Drawing.Point(9, 110);
            this.checkBoxMoreOptions.Name = "checkBoxMoreOptions";
            this.checkBoxMoreOptions.Size = new System.Drawing.Size(116, 17);
            this.checkBoxMoreOptions.TabIndex = 41;
            this.checkBoxMoreOptions.Text = "Show more options";
            this.checkBoxMoreOptions.UseVisualStyleBackColor = true;
            this.checkBoxMoreOptions.CheckedChanged += new System.EventHandler(this.checkBoxMoreOptions_CheckedChanged);
            // 
            // labelGamePath
            // 
            this.labelGamePath.Location = new System.Drawing.Point(7, 62);
            this.labelGamePath.Name = "labelGamePath";
            this.labelGamePath.Size = new System.Drawing.Size(100, 20);
            this.labelGamePath.TabIndex = 37;
            this.labelGamePath.Text = "Game path:";
            this.labelGamePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelAdvancedOptions
            // 
            this.panelAdvancedOptions.Controls.Add(this.pictureBoxAPIKeyHelp);
            this.panelAdvancedOptions.Controls.Add(this.linkLabelProfilesHelp);
            this.panelAdvancedOptions.Controls.Add(this.labelIniPath);
            this.panelAdvancedOptions.Controls.Add(this.buttonPickIniPath);
            this.panelAdvancedOptions.Controls.Add(this.textBoxIniPath);
            this.panelAdvancedOptions.Controls.Add(this.textBoxLaunchURL);
            this.panelAdvancedOptions.Controls.Add(this.labelProfileAdvancedOptions);
            this.panelAdvancedOptions.Controls.Add(this.labelLaunchURL);
            this.panelAdvancedOptions.Controls.Add(this.labelLaunchOptionMSStoreNotice);
            this.panelAdvancedOptions.Controls.Add(this.textBoxParameters);
            this.panelAdvancedOptions.Controls.Add(this.labelProfileLaunchOptions);
            this.panelAdvancedOptions.Controls.Add(this.labelParameters);
            this.panelAdvancedOptions.Controls.Add(this.radioButtonLaunchViaExecutable);
            this.panelAdvancedOptions.Controls.Add(this.textBoxExecutable);
            this.panelAdvancedOptions.Controls.Add(this.radioButtonLaunchViaLink);
            this.panelAdvancedOptions.Controls.Add(this.labelExecutable);
            this.panelAdvancedOptions.Controls.Add(this.textBoxIniPrefix);
            this.panelAdvancedOptions.Controls.Add(this.labelIniPrefix);
            this.panelAdvancedOptions.Location = new System.Drawing.Point(0, 133);
            this.panelAdvancedOptions.Name = "panelAdvancedOptions";
            this.panelAdvancedOptions.Size = new System.Drawing.Size(411, 334);
            this.panelAdvancedOptions.TabIndex = 40;
            // 
            // pictureBoxAPIKeyHelp
            // 
            this.pictureBoxAPIKeyHelp.Image = global::Fo76ini.Properties.Resources.help_24;
            this.pictureBoxAPIKeyHelp.Location = new System.Drawing.Point(9, 304);
            this.pictureBoxAPIKeyHelp.Name = "pictureBoxAPIKeyHelp";
            this.pictureBoxAPIKeyHelp.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxAPIKeyHelp.TabIndex = 113;
            this.pictureBoxAPIKeyHelp.TabStop = false;
            // 
            // linkLabelProfilesHelp
            // 
            this.linkLabelProfilesHelp.AutoSize = true;
            this.linkLabelProfilesHelp.Location = new System.Drawing.Point(39, 310);
            this.linkLabelProfilesHelp.Name = "linkLabelProfilesHelp";
            this.linkLabelProfilesHelp.Size = new System.Drawing.Size(86, 13);
            this.linkLabelProfilesHelp.TabIndex = 44;
            this.linkLabelProfilesHelp.TabStop = true;
            this.linkLabelProfilesHelp.Text = "Show wiki article";
            this.linkLabelProfilesHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelProfilesHelp_LinkClicked);
            // 
            // labelIniPath
            // 
            this.labelIniPath.AutoSize = true;
            this.labelIniPath.Location = new System.Drawing.Point(10, 167);
            this.labelIniPath.Name = "labelIniPath";
            this.labelIniPath.Size = new System.Drawing.Size(51, 13);
            this.labelIniPath.TabIndex = 43;
            this.labelIniPath.Text = "*.ini path:";
            // 
            // buttonPickIniPath
            // 
            this.buttonPickIniPath.Location = new System.Drawing.Point(363, 163);
            this.buttonPickIniPath.Name = "buttonPickIniPath";
            this.buttonPickIniPath.Size = new System.Drawing.Size(30, 22);
            this.buttonPickIniPath.TabIndex = 42;
            this.buttonPickIniPath.Text = "...";
            this.buttonPickIniPath.UseVisualStyleBackColor = true;
            this.buttonPickIniPath.Click += new System.EventHandler(this.buttonPickIniPath_Click);
            // 
            // textBoxIniPath
            // 
            this.textBoxIniPath.Location = new System.Drawing.Point(113, 164);
            this.textBoxIniPath.Name = "textBoxIniPath";
            this.textBoxIniPath.Size = new System.Drawing.Size(245, 20);
            this.textBoxIniPath.TabIndex = 41;
            this.textBoxIniPath.TextChanged += new System.EventHandler(this.textBoxIniPath_TextChanged);
            // 
            // textBoxLaunchURL
            // 
            this.textBoxLaunchURL.Location = new System.Drawing.Point(113, 263);
            this.textBoxLaunchURL.Name = "textBoxLaunchURL";
            this.textBoxLaunchURL.Size = new System.Drawing.Size(280, 20);
            this.textBoxLaunchURL.TabIndex = 7;
            this.textBoxLaunchURL.TextChanged += new System.EventHandler(this.textBoxLaunchURL_TextChanged);
            // 
            // labelProfileAdvancedOptions
            // 
            this.labelProfileAdvancedOptions.AutoSize = true;
            this.labelProfileAdvancedOptions.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProfileAdvancedOptions.Location = new System.Drawing.Point(7, 113);
            this.labelProfileAdvancedOptions.Margin = new System.Windows.Forms.Padding(3, 25, 3, 5);
            this.labelProfileAdvancedOptions.Name = "labelProfileAdvancedOptions";
            this.labelProfileAdvancedOptions.Size = new System.Drawing.Size(118, 17);
            this.labelProfileAdvancedOptions.TabIndex = 40;
            this.labelProfileAdvancedOptions.Text = "Advanced options";
            // 
            // labelLaunchURL
            // 
            this.labelLaunchURL.AutoSize = true;
            this.labelLaunchURL.Location = new System.Drawing.Point(10, 266);
            this.labelLaunchURL.Name = "labelLaunchURL";
            this.labelLaunchURL.Size = new System.Drawing.Size(71, 13);
            this.labelLaunchURL.TabIndex = 6;
            this.labelLaunchURL.Text = "Launch URL:";
            // 
            // labelLaunchOptionMSStoreNotice
            // 
            this.labelLaunchOptionMSStoreNotice.ForeColor = System.Drawing.Color.Red;
            this.labelLaunchOptionMSStoreNotice.Location = new System.Drawing.Point(9, 73);
            this.labelLaunchOptionMSStoreNotice.Name = "labelLaunchOptionMSStoreNotice";
            this.labelLaunchOptionMSStoreNotice.Size = new System.Drawing.Size(399, 35);
            this.labelLaunchOptionMSStoreNotice.TabIndex = 4;
            this.labelLaunchOptionMSStoreNotice.Text = "Fallout 76 cannot be run directly, if installed through the Xbox app.";
            this.labelLaunchOptionMSStoreNotice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLaunchOptionMSStoreNotice.Visible = false;
            // 
            // textBoxParameters
            // 
            this.textBoxParameters.Location = new System.Drawing.Point(113, 227);
            this.textBoxParameters.Name = "textBoxParameters";
            this.textBoxParameters.Size = new System.Drawing.Size(280, 20);
            this.textBoxParameters.TabIndex = 5;
            this.textBoxParameters.TextChanged += new System.EventHandler(this.textBoxParameters_TextChanged);
            // 
            // labelProfileLaunchOptions
            // 
            this.labelProfileLaunchOptions.AutoSize = true;
            this.labelProfileLaunchOptions.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProfileLaunchOptions.Location = new System.Drawing.Point(7, 5);
            this.labelProfileLaunchOptions.Margin = new System.Windows.Forms.Padding(3, 25, 3, 5);
            this.labelProfileLaunchOptions.Name = "labelProfileLaunchOptions";
            this.labelProfileLaunchOptions.Size = new System.Drawing.Size(101, 17);
            this.labelProfileLaunchOptions.TabIndex = 39;
            this.labelProfileLaunchOptions.Text = "Launch options";
            // 
            // labelParameters
            // 
            this.labelParameters.AutoSize = true;
            this.labelParameters.Location = new System.Drawing.Point(10, 230);
            this.labelParameters.Name = "labelParameters";
            this.labelParameters.Size = new System.Drawing.Size(63, 13);
            this.labelParameters.TabIndex = 4;
            this.labelParameters.Text = "Parameters:";
            // 
            // radioButtonLaunchViaExecutable
            // 
            this.radioButtonLaunchViaExecutable.AutoSize = true;
            this.radioButtonLaunchViaExecutable.Location = new System.Drawing.Point(10, 53);
            this.radioButtonLaunchViaExecutable.Name = "radioButtonLaunchViaExecutable";
            this.radioButtonLaunchViaExecutable.Size = new System.Drawing.Size(157, 17);
            this.radioButtonLaunchViaExecutable.TabIndex = 1;
            this.radioButtonLaunchViaExecutable.TabStop = true;
            this.radioButtonLaunchViaExecutable.Text = "Run \"Fallout76.exe\" directly";
            this.radioButtonLaunchViaExecutable.UseVisualStyleBackColor = true;
            this.radioButtonLaunchViaExecutable.CheckedChanged += new System.EventHandler(this.radioButtonLaunchViaExecutable_CheckedChanged);
            // 
            // textBoxExecutable
            // 
            this.textBoxExecutable.Location = new System.Drawing.Point(113, 201);
            this.textBoxExecutable.Name = "textBoxExecutable";
            this.textBoxExecutable.Size = new System.Drawing.Size(280, 20);
            this.textBoxExecutable.TabIndex = 3;
            this.textBoxExecutable.Text = "Fallout76.exe";
            this.textBoxExecutable.TextChanged += new System.EventHandler(this.textBoxExecutable_TextChanged);
            // 
            // radioButtonLaunchViaLink
            // 
            this.radioButtonLaunchViaLink.AutoSize = true;
            this.radioButtonLaunchViaLink.Location = new System.Drawing.Point(10, 30);
            this.radioButtonLaunchViaLink.Name = "radioButtonLaunchViaLink";
            this.radioButtonLaunchViaLink.Size = new System.Drawing.Size(222, 17);
            this.radioButtonLaunchViaLink.TabIndex = 0;
            this.radioButtonLaunchViaLink.TabStop = true;
            this.radioButtonLaunchViaLink.Text = "Launch via Steam / Xbox (recommended)";
            this.radioButtonLaunchViaLink.UseVisualStyleBackColor = true;
            this.radioButtonLaunchViaLink.CheckedChanged += new System.EventHandler(this.radioButtonLaunchViaLink_CheckedChanged);
            // 
            // labelExecutable
            // 
            this.labelExecutable.AutoSize = true;
            this.labelExecutable.Location = new System.Drawing.Point(10, 204);
            this.labelExecutable.Name = "labelExecutable";
            this.labelExecutable.Size = new System.Drawing.Size(63, 13);
            this.labelExecutable.TabIndex = 2;
            this.labelExecutable.Text = "Executable:";
            // 
            // textBoxIniPrefix
            // 
            this.textBoxIniPrefix.Location = new System.Drawing.Point(113, 138);
            this.textBoxIniPrefix.Name = "textBoxIniPrefix";
            this.textBoxIniPrefix.Size = new System.Drawing.Size(280, 20);
            this.textBoxIniPrefix.TabIndex = 1;
            this.textBoxIniPrefix.Text = "Fallout76";
            this.textBoxIniPrefix.TextChanged += new System.EventHandler(this.textBoxIniPrefix_TextChanged);
            // 
            // labelIniPrefix
            // 
            this.labelIniPrefix.AutoSize = true;
            this.labelIniPrefix.Location = new System.Drawing.Point(10, 141);
            this.labelIniPrefix.Name = "labelIniPrefix";
            this.labelIniPrefix.Size = new System.Drawing.Size(55, 13);
            this.labelIniPrefix.TabIndex = 0;
            this.labelIniPrefix.Text = "*.ini prefix:";
            // 
            // labelGameEdition
            // 
            this.labelGameEdition.Location = new System.Drawing.Point(7, 35);
            this.labelGameEdition.Name = "labelGameEdition";
            this.labelGameEdition.Size = new System.Drawing.Size(100, 21);
            this.labelGameEdition.TabIndex = 36;
            this.labelGameEdition.Text = "Game edition:";
            this.labelGameEdition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxGameEdition
            // 
            this.comboBoxGameEdition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxGameEdition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGameEdition.FormattingEnabled = true;
            this.comboBoxGameEdition.Location = new System.Drawing.Point(113, 35);
            this.comboBoxGameEdition.Name = "comboBoxGameEdition";
            this.comboBoxGameEdition.Size = new System.Drawing.Size(279, 21);
            this.comboBoxGameEdition.TabIndex = 35;
            this.comboBoxGameEdition.SelectedIndexChanged += new System.EventHandler(this.comboBoxGameEdition_SelectedIndexChanged);
            // 
            // labelProfileName
            // 
            this.labelProfileName.Location = new System.Drawing.Point(7, 9);
            this.labelProfileName.Name = "labelProfileName";
            this.labelProfileName.Size = new System.Drawing.Size(100, 20);
            this.labelProfileName.TabIndex = 2;
            this.labelProfileName.Text = "Profile name:";
            this.labelProfileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonPickGamePath
            // 
            this.buttonPickGamePath.Location = new System.Drawing.Point(363, 61);
            this.buttonPickGamePath.Name = "buttonPickGamePath";
            this.buttonPickGamePath.Size = new System.Drawing.Size(30, 22);
            this.buttonPickGamePath.TabIndex = 31;
            this.buttonPickGamePath.Text = "...";
            this.buttonPickGamePath.UseVisualStyleBackColor = true;
            this.buttonPickGamePath.Click += new System.EventHandler(this.buttonPickGamePath_Click);
            // 
            // textBoxProfileName
            // 
            this.textBoxProfileName.Location = new System.Drawing.Point(113, 9);
            this.textBoxProfileName.Name = "textBoxProfileName";
            this.textBoxProfileName.Size = new System.Drawing.Size(279, 20);
            this.textBoxProfileName.TabIndex = 3;
            this.textBoxProfileName.Text = "Default";
            this.textBoxProfileName.TextChanged += new System.EventHandler(this.textBoxProfileName_TextChanged);
            // 
            // textBoxGamePath
            // 
            this.textBoxGamePath.Location = new System.Drawing.Point(113, 62);
            this.textBoxGamePath.Name = "textBoxGamePath";
            this.textBoxGamePath.Size = new System.Drawing.Size(245, 20);
            this.textBoxGamePath.TabIndex = 30;
            this.textBoxGamePath.TextChanged += new System.EventHandler(this.textBoxGamePath_TextChanged);
            // 
            // UserControlProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tabControl);
            this.Name = "UserControlProfiles";
            this.Size = new System.Drawing.Size(480, 400);
            this.tabControl.ResumeLayout(false);
            this.tabPageSelect.ResumeLayout(false);
            this.tabPageSelect.PerformLayout();
            this.tabPageEdit.ResumeLayout(false);
            this.tabPageEdit.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.panelAdvancedOptions.ResumeLayout(false);
            this.panelAdvancedOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAPIKeyHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TabControlWithoutHeader tabControl;
        private System.Windows.Forms.TabPage tabPageSelect;
        private System.Windows.Forms.Label labelSelectTitle;
        private System.Windows.Forms.Button buttonEditProfile;
        private System.Windows.Forms.Button buttonDeleteProfile;
        private System.Windows.Forms.ListView listViewGameInstances;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button buttonAddProfile;
        private System.Windows.Forms.TabPage tabPageEdit;
        private System.Windows.Forms.Label labelEditTitle;
        private System.Windows.Forms.LinkLabel linkLabelNavigationBack;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.CheckBox checkBoxMoreOptions;
        private System.Windows.Forms.Panel panelAdvancedOptions;
        private System.Windows.Forms.Label labelLaunchOptionMSStoreNotice;
        private System.Windows.Forms.RadioButton radioButtonLaunchViaExecutable;
        private System.Windows.Forms.RadioButton radioButtonLaunchViaLink;
        private System.Windows.Forms.TextBox textBoxLaunchURL;
        private System.Windows.Forms.Label labelLaunchURL;
        private System.Windows.Forms.TextBox textBoxParameters;
        private System.Windows.Forms.Label labelParameters;
        private System.Windows.Forms.TextBox textBoxExecutable;
        private System.Windows.Forms.Label labelExecutable;
        private System.Windows.Forms.TextBox textBoxIniPrefix;
        private System.Windows.Forms.Label labelIniPrefix;
        private System.Windows.Forms.LinkLabel linkLabelAutoDetect;
        private System.Windows.Forms.Label labelGamePath;
        private System.Windows.Forms.Label labelGameEdition;
        private ComboxExtended.ImagedComboBox comboBoxGameEdition;
        private System.Windows.Forms.Button buttonPickGamePath;
        private System.Windows.Forms.TextBox textBoxGamePath;
        private System.Windows.Forms.TextBox textBoxProfileName;
        private System.Windows.Forms.Label labelProfileName;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label labelProfileAdvancedOptions;
        private System.Windows.Forms.Label labelProfileLaunchOptions;
        private System.Windows.Forms.Label labelIniPath;
        private System.Windows.Forms.Button buttonPickIniPath;
        private System.Windows.Forms.TextBox textBoxIniPath;
        private System.Windows.Forms.LinkLabel linkLabelProfilesHelp;
        private System.Windows.Forms.PictureBox pictureBoxAPIKeyHelp;
    }
}
