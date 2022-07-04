namespace Fo76ini.Forms.FormProfiles
{
    partial class FormProfiles
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Default", 0);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Steam"}, 2, System.Drawing.Color.Empty, System.Drawing.SystemColors.Window, null);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Bethesda.net", 1);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Bethesda.net PTS", 1);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Xbox", 3);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProfiles));
            this.labelLogo = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.buttonAddProfile = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSelect = new System.Windows.Forms.TabPage();
            this.labelSelectTitle = new System.Windows.Forms.Label();
            this.buttonEditProfile = new System.Windows.Forms.Button();
            this.buttonDeleteProfile = new System.Windows.Forms.Button();
            this.listViewGameInstances = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.tabPageEdit = new System.Windows.Forms.TabPage();
            this.labelEditTitle = new System.Windows.Forms.Label();
            this.linkLabelNavigationBack = new System.Windows.Forms.LinkLabel();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.checkBoxMoreOptions = new System.Windows.Forms.CheckBox();
            this.panelAdvancedOptions = new System.Windows.Forms.Panel();
            this.groupBoxLaunchOptions = new System.Windows.Forms.GroupBox();
            this.labelLaunchOptionMSStoreNotice = new System.Windows.Forms.Label();
            this.radioButtonLaunchViaExecutable = new System.Windows.Forms.RadioButton();
            this.radioButtonLaunchViaLink = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxLaunchURL = new System.Windows.Forms.TextBox();
            this.labelLaunchURL = new System.Windows.Forms.Label();
            this.textBoxParameters = new System.Windows.Forms.TextBox();
            this.labelParameters = new System.Windows.Forms.Label();
            this.textBoxExecutable = new System.Windows.Forms.TextBox();
            this.labelExecutable = new System.Windows.Forms.Label();
            this.textBoxIniPrefix = new System.Windows.Forms.TextBox();
            this.labelIniPrefix = new System.Windows.Forms.Label();
            this.groupBoxProfile = new System.Windows.Forms.GroupBox();
            this.linkLabelAutoDetect = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxGameEdition = new ComboxExtended.ImagedComboBox();
            this.buttonPickGamePath = new System.Windows.Forms.Button();
            this.textBoxGamePath = new System.Windows.Forms.TextBox();
            this.textBoxProfileName = new System.Windows.Forms.TextBox();
            this.labelProfileName = new System.Windows.Forms.Label();
            this.buttonLoadProfile = new System.Windows.Forms.Button();
            this.checkBoxSkipProfileManager = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panel.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageSelect.SuspendLayout();
            this.tabPageEdit.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.panelAdvancedOptions.SuspendLayout();
            this.groupBoxLaunchOptions.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxProfile.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLogo
            // 
            this.labelLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelLogo.BackColor = System.Drawing.Color.Transparent;
            this.labelLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelLogo.Location = new System.Drawing.Point(0, 92);
            this.labelLogo.Margin = new System.Windows.Forms.Padding(0);
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(487, 41);
            this.labelLogo.TabIndex = 1;
            this.labelLogo.Text = "Quick Configuration";
            this.labelLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.Image = global::Fo76ini.Properties.Resources.fallout76_logo_black;
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 10);
            this.pictureBoxLogo.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(487, 92);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // buttonAddProfile
            // 
            this.buttonAddProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddProfile.Location = new System.Drawing.Point(351, 46);
            this.buttonAddProfile.Name = "buttonAddProfile";
            this.buttonAddProfile.Size = new System.Drawing.Size(115, 23);
            this.buttonAddProfile.TabIndex = 3;
            this.buttonAddProfile.Text = "Add profile";
            this.buttonAddProfile.UseVisualStyleBackColor = true;
            this.buttonAddProfile.Click += new System.EventHandler(this.buttonAddProfile_Click);
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.panel.BackColor = System.Drawing.Color.Transparent;
            this.panel.Controls.Add(this.checkBoxSkipProfileManager);
            this.panel.Controls.Add(this.tabControl);
            this.panel.Controls.Add(this.buttonLoadProfile);
            this.panel.Location = new System.Drawing.Point(0, 146);
            this.panel.Margin = new System.Windows.Forms.Padding(0);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(487, 416);
            this.panel.TabIndex = 21;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageSelect);
            this.tabControl.Controls.Add(this.tabPageEdit);
            this.tabControl.Location = new System.Drawing.Point(4, 3);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(480, 351);
            this.tabControl.TabIndex = 22;
            // 
            // tabPageSelect
            // 
            this.tabPageSelect.BackColor = System.Drawing.Color.Transparent;
            this.tabPageSelect.Controls.Add(this.labelSelectTitle);
            this.tabPageSelect.Controls.Add(this.buttonEditProfile);
            this.tabPageSelect.Controls.Add(this.buttonDeleteProfile);
            this.tabPageSelect.Controls.Add(this.listViewGameInstances);
            this.tabPageSelect.Controls.Add(this.buttonAddProfile);
            this.tabPageSelect.Location = new System.Drawing.Point(4, 22);
            this.tabPageSelect.Name = "tabPageSelect";
            this.tabPageSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSelect.Size = new System.Drawing.Size(472, 325);
            this.tabPageSelect.TabIndex = 0;
            this.tabPageSelect.Text = "Select";
            // 
            // labelSelectTitle
            // 
            this.labelSelectTitle.AutoSize = true;
            this.labelSelectTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSelectTitle.Location = new System.Drawing.Point(2, 3);
            this.labelSelectTitle.Name = "labelSelectTitle";
            this.labelSelectTitle.Size = new System.Drawing.Size(165, 30);
            this.labelSelectTitle.TabIndex = 44;
            this.labelSelectTitle.Text = "Profile manager";
            // 
            // buttonEditProfile
            // 
            this.buttonEditProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEditProfile.Location = new System.Drawing.Point(351, 75);
            this.buttonEditProfile.Name = "buttonEditProfile";
            this.buttonEditProfile.Size = new System.Drawing.Size(115, 23);
            this.buttonEditProfile.TabIndex = 43;
            this.buttonEditProfile.Text = "Edit profile";
            this.buttonEditProfile.UseVisualStyleBackColor = true;
            this.buttonEditProfile.Click += new System.EventHandler(this.buttonEditProfile_Click);
            // 
            // buttonDeleteProfile
            // 
            this.buttonDeleteProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteProfile.Location = new System.Drawing.Point(351, 104);
            this.buttonDeleteProfile.Name = "buttonDeleteProfile";
            this.buttonDeleteProfile.Size = new System.Drawing.Size(115, 23);
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
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10});
            this.listViewGameInstances.LabelWrap = false;
            this.listViewGameInstances.Location = new System.Drawing.Point(6, 46);
            this.listViewGameInstances.MultiSelect = false;
            this.listViewGameInstances.Name = "listViewGameInstances";
            this.listViewGameInstances.Size = new System.Drawing.Size(339, 273);
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
            // tabPageEdit
            // 
            this.tabPageEdit.BackColor = System.Drawing.Color.Transparent;
            this.tabPageEdit.Controls.Add(this.labelEditTitle);
            this.tabPageEdit.Controls.Add(this.linkLabelNavigationBack);
            this.tabPageEdit.Controls.Add(this.panelSettings);
            this.tabPageEdit.Location = new System.Drawing.Point(4, 22);
            this.tabPageEdit.Name = "tabPageEdit";
            this.tabPageEdit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEdit.Size = new System.Drawing.Size(472, 317);
            this.tabPageEdit.TabIndex = 1;
            this.tabPageEdit.Text = "Edit";
            // 
            // labelEditTitle
            // 
            this.labelEditTitle.AutoSize = true;
            this.labelEditTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEditTitle.Location = new System.Drawing.Point(6, 25);
            this.labelEditTitle.Name = "labelEditTitle";
            this.labelEditTitle.Size = new System.Drawing.Size(118, 30);
            this.labelEditTitle.TabIndex = 42;
            this.labelEditTitle.Text = "Edit profile";
            // 
            // linkLabelNavigationBack
            // 
            this.linkLabelNavigationBack.AutoSize = true;
            this.linkLabelNavigationBack.Location = new System.Drawing.Point(8, 8);
            this.linkLabelNavigationBack.Name = "linkLabelNavigationBack";
            this.linkLabelNavigationBack.Size = new System.Drawing.Size(103, 13);
            this.linkLabelNavigationBack.TabIndex = 41;
            this.linkLabelNavigationBack.TabStop = true;
            this.linkLabelNavigationBack.Text = "← Back to selection";
            this.linkLabelNavigationBack.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelNavigationBack_LinkClicked);
            // 
            // panelSettings
            // 
            this.panelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelSettings.AutoScroll = true;
            this.panelSettings.AutoScrollMargin = new System.Drawing.Size(0, 8);
            this.panelSettings.BackColor = System.Drawing.SystemColors.Window;
            this.panelSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSettings.Controls.Add(this.checkBoxMoreOptions);
            this.panelSettings.Controls.Add(this.panelAdvancedOptions);
            this.panelSettings.Controls.Add(this.groupBoxProfile);
            this.panelSettings.Location = new System.Drawing.Point(0, 65);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(472, 252);
            this.panelSettings.TabIndex = 39;
            // 
            // checkBoxMoreOptions
            // 
            this.checkBoxMoreOptions.AutoSize = true;
            this.checkBoxMoreOptions.Location = new System.Drawing.Point(7, 140);
            this.checkBoxMoreOptions.Name = "checkBoxMoreOptions";
            this.checkBoxMoreOptions.Size = new System.Drawing.Size(116, 17);
            this.checkBoxMoreOptions.TabIndex = 41;
            this.checkBoxMoreOptions.Text = "Show more options";
            this.checkBoxMoreOptions.UseVisualStyleBackColor = true;
            this.checkBoxMoreOptions.CheckedChanged += new System.EventHandler(this.checkBoxMoreOptions_CheckedChanged);
            // 
            // panelAdvancedOptions
            // 
            this.panelAdvancedOptions.Controls.Add(this.groupBoxLaunchOptions);
            this.panelAdvancedOptions.Controls.Add(this.groupBox2);
            this.panelAdvancedOptions.Location = new System.Drawing.Point(-1, 163);
            this.panelAdvancedOptions.Name = "panelAdvancedOptions";
            this.panelAdvancedOptions.Size = new System.Drawing.Size(417, 255);
            this.panelAdvancedOptions.TabIndex = 40;
            // 
            // groupBoxLaunchOptions
            // 
            this.groupBoxLaunchOptions.Controls.Add(this.labelLaunchOptionMSStoreNotice);
            this.groupBoxLaunchOptions.Controls.Add(this.radioButtonLaunchViaExecutable);
            this.groupBoxLaunchOptions.Controls.Add(this.radioButtonLaunchViaLink);
            this.groupBoxLaunchOptions.Location = new System.Drawing.Point(6, 6);
            this.groupBoxLaunchOptions.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxLaunchOptions.Name = "groupBoxLaunchOptions";
            this.groupBoxLaunchOptions.Size = new System.Drawing.Size(402, 108);
            this.groupBoxLaunchOptions.TabIndex = 36;
            this.groupBoxLaunchOptions.TabStop = false;
            this.groupBoxLaunchOptions.Text = "Launch options";
            // 
            // labelLaunchOptionMSStoreNotice
            // 
            this.labelLaunchOptionMSStoreNotice.ForeColor = System.Drawing.Color.Red;
            this.labelLaunchOptionMSStoreNotice.Location = new System.Drawing.Point(7, 68);
            this.labelLaunchOptionMSStoreNotice.Name = "labelLaunchOptionMSStoreNotice";
            this.labelLaunchOptionMSStoreNotice.Size = new System.Drawing.Size(384, 29);
            this.labelLaunchOptionMSStoreNotice.TabIndex = 4;
            this.labelLaunchOptionMSStoreNotice.Text = "Fallout 76 cannot be run directly, if installed through the Microsoft Store.";
            this.labelLaunchOptionMSStoreNotice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelLaunchOptionMSStoreNotice.Visible = false;
            // 
            // radioButtonLaunchViaExecutable
            // 
            this.radioButtonLaunchViaExecutable.AutoSize = true;
            this.radioButtonLaunchViaExecutable.Location = new System.Drawing.Point(10, 43);
            this.radioButtonLaunchViaExecutable.Name = "radioButtonLaunchViaExecutable";
            this.radioButtonLaunchViaExecutable.Size = new System.Drawing.Size(157, 17);
            this.radioButtonLaunchViaExecutable.TabIndex = 1;
            this.radioButtonLaunchViaExecutable.TabStop = true;
            this.radioButtonLaunchViaExecutable.Text = "Run \"Fallout76.exe\" directly";
            this.radioButtonLaunchViaExecutable.UseVisualStyleBackColor = true;
            this.radioButtonLaunchViaExecutable.CheckedChanged += new System.EventHandler(this.radioButtonLaunchViaExecutable_CheckedChanged);
            // 
            // radioButtonLaunchViaLink
            // 
            this.radioButtonLaunchViaLink.AutoSize = true;
            this.radioButtonLaunchViaLink.Location = new System.Drawing.Point(10, 20);
            this.radioButtonLaunchViaLink.Name = "radioButtonLaunchViaLink";
            this.radioButtonLaunchViaLink.Size = new System.Drawing.Size(222, 17);
            this.radioButtonLaunchViaLink.TabIndex = 0;
            this.radioButtonLaunchViaLink.TabStop = true;
            this.radioButtonLaunchViaLink.Text = "Launch via Steam / Xbox (recommended)";
            this.radioButtonLaunchViaLink.UseVisualStyleBackColor = true;
            this.radioButtonLaunchViaLink.CheckedChanged += new System.EventHandler(this.radioButtonLaunchViaLink_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBoxLaunchURL);
            this.groupBox2.Controls.Add(this.labelLaunchURL);
            this.groupBox2.Controls.Add(this.textBoxParameters);
            this.groupBox2.Controls.Add(this.labelParameters);
            this.groupBox2.Controls.Add(this.textBoxExecutable);
            this.groupBox2.Controls.Add(this.labelExecutable);
            this.groupBox2.Controls.Add(this.textBoxIniPrefix);
            this.groupBox2.Controls.Add(this.labelIniPrefix);
            this.groupBox2.Location = new System.Drawing.Point(6, 121);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(402, 128);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Advanced options";
            // 
            // textBoxLaunchURL
            // 
            this.textBoxLaunchURL.Location = new System.Drawing.Point(112, 95);
            this.textBoxLaunchURL.Name = "textBoxLaunchURL";
            this.textBoxLaunchURL.Size = new System.Drawing.Size(279, 20);
            this.textBoxLaunchURL.TabIndex = 7;
            this.textBoxLaunchURL.TextChanged += new System.EventHandler(this.textBoxLaunchURL_TextChanged);
            // 
            // labelLaunchURL
            // 
            this.labelLaunchURL.AutoSize = true;
            this.labelLaunchURL.Location = new System.Drawing.Point(8, 98);
            this.labelLaunchURL.Name = "labelLaunchURL";
            this.labelLaunchURL.Size = new System.Drawing.Size(71, 13);
            this.labelLaunchURL.TabIndex = 6;
            this.labelLaunchURL.Text = "Launch URL:";
            // 
            // textBoxParameters
            // 
            this.textBoxParameters.Location = new System.Drawing.Point(112, 69);
            this.textBoxParameters.Name = "textBoxParameters";
            this.textBoxParameters.Size = new System.Drawing.Size(279, 20);
            this.textBoxParameters.TabIndex = 5;
            this.textBoxParameters.TextChanged += new System.EventHandler(this.textBoxParameters_TextChanged);
            // 
            // labelParameters
            // 
            this.labelParameters.AutoSize = true;
            this.labelParameters.Location = new System.Drawing.Point(8, 72);
            this.labelParameters.Name = "labelParameters";
            this.labelParameters.Size = new System.Drawing.Size(63, 13);
            this.labelParameters.TabIndex = 4;
            this.labelParameters.Text = "Parameters:";
            // 
            // textBoxExecutable
            // 
            this.textBoxExecutable.Location = new System.Drawing.Point(112, 43);
            this.textBoxExecutable.Name = "textBoxExecutable";
            this.textBoxExecutable.Size = new System.Drawing.Size(279, 20);
            this.textBoxExecutable.TabIndex = 3;
            this.textBoxExecutable.Text = "Fallout76.exe";
            this.textBoxExecutable.TextChanged += new System.EventHandler(this.textBoxExecutable_TextChanged);
            // 
            // labelExecutable
            // 
            this.labelExecutable.AutoSize = true;
            this.labelExecutable.Location = new System.Drawing.Point(7, 46);
            this.labelExecutable.Name = "labelExecutable";
            this.labelExecutable.Size = new System.Drawing.Size(63, 13);
            this.labelExecutable.TabIndex = 2;
            this.labelExecutable.Text = "Executable:";
            // 
            // textBoxIniPrefix
            // 
            this.textBoxIniPrefix.Location = new System.Drawing.Point(112, 17);
            this.textBoxIniPrefix.Name = "textBoxIniPrefix";
            this.textBoxIniPrefix.Size = new System.Drawing.Size(279, 20);
            this.textBoxIniPrefix.TabIndex = 1;
            this.textBoxIniPrefix.Text = "Fallout76";
            this.textBoxIniPrefix.TextChanged += new System.EventHandler(this.textBoxIniPrefix_TextChanged);
            // 
            // labelIniPrefix
            // 
            this.labelIniPrefix.AutoSize = true;
            this.labelIniPrefix.Location = new System.Drawing.Point(7, 20);
            this.labelIniPrefix.Name = "labelIniPrefix";
            this.labelIniPrefix.Size = new System.Drawing.Size(56, 13);
            this.labelIniPrefix.TabIndex = 0;
            this.labelIniPrefix.Text = "*.ini Prefix:";
            // 
            // groupBoxProfile
            // 
            this.groupBoxProfile.Controls.Add(this.linkLabelAutoDetect);
            this.groupBoxProfile.Controls.Add(this.label4);
            this.groupBoxProfile.Controls.Add(this.label1);
            this.groupBoxProfile.Controls.Add(this.comboBoxGameEdition);
            this.groupBoxProfile.Controls.Add(this.buttonPickGamePath);
            this.groupBoxProfile.Controls.Add(this.textBoxGamePath);
            this.groupBoxProfile.Controls.Add(this.textBoxProfileName);
            this.groupBoxProfile.Controls.Add(this.labelProfileName);
            this.groupBoxProfile.Location = new System.Drawing.Point(5, 6);
            this.groupBoxProfile.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.groupBoxProfile.Name = "groupBoxProfile";
            this.groupBoxProfile.Size = new System.Drawing.Size(402, 126);
            this.groupBoxProfile.TabIndex = 39;
            this.groupBoxProfile.TabStop = false;
            this.groupBoxProfile.Text = "Profile";
            // 
            // linkLabelAutoDetect
            // 
            this.linkLabelAutoDetect.AutoSize = true;
            this.linkLabelAutoDetect.Location = new System.Drawing.Point(109, 96);
            this.linkLabelAutoDetect.Name = "linkLabelAutoDetect";
            this.linkLabelAutoDetect.Size = new System.Drawing.Size(100, 13);
            this.linkLabelAutoDetect.TabIndex = 38;
            this.linkLabelAutoDetect.TabStop = true;
            this.linkLabelAutoDetect.Text = "Attempt auto-detect";
            this.linkLabelAutoDetect.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAutoDetect_LinkClicked);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 21);
            this.label4.TabIndex = 37;
            this.label4.Text = "Game path:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "Game edition:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBoxGameEdition
            // 
            this.comboBoxGameEdition.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.comboBoxGameEdition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGameEdition.FormattingEnabled = true;
            this.comboBoxGameEdition.Location = new System.Drawing.Point(112, 45);
            this.comboBoxGameEdition.Name = "comboBoxGameEdition";
            this.comboBoxGameEdition.Size = new System.Drawing.Size(279, 21);
            this.comboBoxGameEdition.TabIndex = 35;
            this.comboBoxGameEdition.SelectedIndexChanged += new System.EventHandler(this.comboBoxGameEdition_SelectedIndexChanged);
            // 
            // buttonPickGamePath
            // 
            this.buttonPickGamePath.Location = new System.Drawing.Point(361, 71);
            this.buttonPickGamePath.Name = "buttonPickGamePath";
            this.buttonPickGamePath.Size = new System.Drawing.Size(30, 22);
            this.buttonPickGamePath.TabIndex = 31;
            this.buttonPickGamePath.Text = "...";
            this.buttonPickGamePath.UseVisualStyleBackColor = true;
            this.buttonPickGamePath.Click += new System.EventHandler(this.buttonPickGamePath_Click);
            // 
            // textBoxGamePath
            // 
            this.textBoxGamePath.Location = new System.Drawing.Point(112, 72);
            this.textBoxGamePath.Name = "textBoxGamePath";
            this.textBoxGamePath.Size = new System.Drawing.Size(245, 20);
            this.textBoxGamePath.TabIndex = 30;
            this.textBoxGamePath.TextChanged += new System.EventHandler(this.textBoxGamePath_TextChanged);
            // 
            // textBoxProfileName
            // 
            this.textBoxProfileName.Location = new System.Drawing.Point(112, 19);
            this.textBoxProfileName.Name = "textBoxProfileName";
            this.textBoxProfileName.Size = new System.Drawing.Size(279, 20);
            this.textBoxProfileName.TabIndex = 3;
            this.textBoxProfileName.Text = "Default";
            this.textBoxProfileName.TextChanged += new System.EventHandler(this.textBoxProfileName_TextChanged);
            // 
            // labelProfileName
            // 
            this.labelProfileName.Location = new System.Drawing.Point(7, 19);
            this.labelProfileName.Name = "labelProfileName";
            this.labelProfileName.Size = new System.Drawing.Size(99, 20);
            this.labelProfileName.TabIndex = 2;
            this.labelProfileName.Text = "Profile name:";
            this.labelProfileName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buttonLoadProfile
            // 
            this.buttonLoadProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLoadProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLoadProfile.Location = new System.Drawing.Point(13, 356);
            this.buttonLoadProfile.Name = "buttonLoadProfile";
            this.buttonLoadProfile.Size = new System.Drawing.Size(461, 29);
            this.buttonLoadProfile.TabIndex = 41;
            this.buttonLoadProfile.Text = "Load profile";
            this.buttonLoadProfile.UseVisualStyleBackColor = true;
            this.buttonLoadProfile.Click += new System.EventHandler(this.buttonLoadProfile_Click);
            // 
            // checkBoxSkipProfileManager
            // 
            this.checkBoxSkipProfileManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxSkipProfileManager.AutoSize = true;
            this.checkBoxSkipProfileManager.Location = new System.Drawing.Point(14, 391);
            this.checkBoxSkipProfileManager.Name = "checkBoxSkipProfileManager";
            this.checkBoxSkipProfileManager.Size = new System.Drawing.Size(303, 17);
            this.checkBoxSkipProfileManager.TabIndex = 42;
            this.checkBoxSkipProfileManager.Text = "Load selected profile and skip profile manager on next start";
            this.checkBoxSkipProfileManager.UseVisualStyleBackColor = true;
            // 
            // FormProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(484, 561);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.labelLogo);
            this.Controls.Add(this.pictureBoxLogo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 600);
            this.Name = "FormProfiles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fallout 76 Quick Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPageSelect.ResumeLayout(false);
            this.tabPageSelect.PerformLayout();
            this.tabPageEdit.ResumeLayout(false);
            this.tabPageEdit.PerformLayout();
            this.panelSettings.ResumeLayout(false);
            this.panelSettings.PerformLayout();
            this.panelAdvancedOptions.ResumeLayout(false);
            this.groupBoxLaunchOptions.ResumeLayout(false);
            this.groupBoxLaunchOptions.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxProfile.ResumeLayout(false);
            this.groupBoxProfile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.Button buttonAddProfile;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxLaunchURL;
        private System.Windows.Forms.Label labelLaunchURL;
        private System.Windows.Forms.TextBox textBoxParameters;
        private System.Windows.Forms.Label labelParameters;
        private System.Windows.Forms.TextBox textBoxExecutable;
        private System.Windows.Forms.Label labelExecutable;
        private System.Windows.Forms.TextBox textBoxIniPrefix;
        private System.Windows.Forms.Label labelIniPrefix;
        private System.Windows.Forms.GroupBox groupBoxLaunchOptions;
        private System.Windows.Forms.Label labelLaunchOptionMSStoreNotice;
        private System.Windows.Forms.RadioButton radioButtonLaunchViaExecutable;
        private System.Windows.Forms.RadioButton radioButtonLaunchViaLink;
        private System.Windows.Forms.TextBox textBoxGamePath;
        private System.Windows.Forms.Button buttonPickGamePath;
        private System.Windows.Forms.ListView listViewGameInstances;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageSelect;
        private System.Windows.Forms.TabPage tabPageEdit;
        private System.Windows.Forms.LinkLabel linkLabelNavigationBack;
        private System.Windows.Forms.Button buttonEditProfile;
        private System.Windows.Forms.Button buttonDeleteProfile;
        private System.Windows.Forms.Button buttonLoadProfile;
        private System.Windows.Forms.GroupBox groupBoxProfile;
        private System.Windows.Forms.TextBox textBoxProfileName;
        private System.Windows.Forms.Label labelProfileName;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Label labelSelectTitle;
        private System.Windows.Forms.Label labelEditTitle;
        private ComboxExtended.ImagedComboBox comboBoxGameEdition;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabelAutoDetect;
        private System.Windows.Forms.Panel panelAdvancedOptions;
        private System.Windows.Forms.CheckBox checkBoxMoreOptions;
        private System.Windows.Forms.CheckBox checkBoxSkipProfileManager;
    }
}