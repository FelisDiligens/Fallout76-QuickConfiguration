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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProfiles));
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem("Default", 0);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Steam"}, 2, System.Drawing.Color.Empty, System.Drawing.SystemColors.Window, null);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Bethesda.net", 1);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Bethesda.net PTS", 1);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Microsoft Store", 3);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddGame = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAddProfile = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTip = new System.Windows.Forms.Label();
            this.labelSettings = new System.Windows.Forms.Label();
            this.labelProfile = new System.Windows.Forms.Label();
            this.labelGame = new System.Windows.Forms.Label();
            this.listBoxProfile = new System.Windows.Forms.ListBox();
            this.contextMenuStripProfile = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.profileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.renameProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelSettings = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBoxLaunchURL = new System.Windows.Forms.TextBox();
            this.labelLaunchURL = new System.Windows.Forms.Label();
            this.textBoxParameters = new System.Windows.Forms.TextBox();
            this.labelParameters = new System.Windows.Forms.Label();
            this.textBoxExecutable = new System.Windows.Forms.TextBox();
            this.labelExecutable = new System.Windows.Forms.Label();
            this.textBoxIniPrefix = new System.Windows.Forms.TextBox();
            this.labelIniPrefix = new System.Windows.Forms.Label();
            this.groupBoxLaunchOptions = new System.Windows.Forms.GroupBox();
            this.labelLaunchOptionMSStoreNotice = new System.Windows.Forms.Label();
            this.radioButtonLaunchViaExecutable = new System.Windows.Forms.RadioButton();
            this.radioButtonLaunchViaLink = new System.Windows.Forms.RadioButton();
            this.groupBoxGameLocation = new System.Windows.Forms.GroupBox();
            this.textBoxGamePath = new System.Windows.Forms.TextBox();
            this.buttonPickGamePath = new System.Windows.Forms.Button();
            this.groupBoxGameEdition = new System.Windows.Forms.GroupBox();
            this.pictureBoxMSStore = new System.Windows.Forms.PictureBox();
            this.pictureBoxSteam = new System.Windows.Forms.PictureBox();
            this.pictureBoxBethesdaNetPTS = new System.Windows.Forms.PictureBox();
            this.pictureBoxBethesdaNet = new System.Windows.Forms.PictureBox();
            this.radioButtonEditionMSStore = new System.Windows.Forms.RadioButton();
            this.radioButtonEditionBethesdaNetPTS = new System.Windows.Forms.RadioButton();
            this.radioButtonEditionSteam = new System.Windows.Forms.RadioButton();
            this.radioButtonEditionBethesdaNet = new System.Windows.Forms.RadioButton();
            this.listViewGameInstances = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripGame = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.renameGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogGamePath = new System.Windows.Forms.OpenFileDialog();
            this.buttonAutoDetect = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStripProfile.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxLaunchOptions.SuspendLayout();
            this.groupBoxGameLocation.SuspendLayout();
            this.groupBoxGameEdition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMSStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSteam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBethesdaNetPTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBethesdaNet)).BeginInit();
            this.contextMenuStripGame.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "help-24.png");
            this.imageList1.Images.SetKeyName(1, "bethesda_24px.png");
            this.imageList1.Images.SetKeyName(2, "steam_24px.png");
            this.imageList1.Images.SetKeyName(3, "msstore_24px.png");
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddGame,
            this.toolStripSeparator1,
            this.toolStripButtonAddProfile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip1.Size = new System.Drawing.Size(664, 36);
            this.toolStrip1.TabIndex = 15;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAddGame
            // 
            this.toolStripButtonAddGame.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAddGame.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddGame.Image")));
            this.toolStripButtonAddGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddGame.Name = "toolStripButtonAddGame";
            this.toolStripButtonAddGame.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.toolStripButtonAddGame.Size = new System.Drawing.Size(74, 23);
            this.toolStripButtonAddGame.Text = "Add game";
            this.toolStripButtonAddGame.Click += new System.EventHandler(this.toolStripButtonAddGame_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripButtonAddProfile
            // 
            this.toolStripButtonAddProfile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonAddProfile.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAddProfile.Image")));
            this.toolStripButtonAddProfile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddProfile.Name = "toolStripButtonAddProfile";
            this.toolStripButtonAddProfile.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.toolStripButtonAddProfile.Size = new System.Drawing.Size(78, 23);
            this.toolStripButtonAddProfile.Text = "Add profile";
            this.toolStripButtonAddProfile.Click += new System.EventHandler(this.toolStripButtonAddProfile_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.labelTip);
            this.panel1.Controls.Add(this.labelSettings);
            this.panel1.Controls.Add(this.labelProfile);
            this.panel1.Controls.Add(this.labelGame);
            this.panel1.Controls.Add(this.listBoxProfile);
            this.panel1.Controls.Add(this.panelSettings);
            this.panel1.Controls.Add(this.listViewGameInstances);
            this.panel1.Location = new System.Drawing.Point(0, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(664, 428);
            this.panel1.TabIndex = 18;
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTip.ForeColor = System.Drawing.Color.DimGray;
            this.labelTip.Location = new System.Drawing.Point(12, 407);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(255, 13);
            this.labelTip.TabIndex = 43;
            this.labelTip.Text = "Tip: Right-click on a game or profile for more options.";
            // 
            // labelSettings
            // 
            this.labelSettings.AutoSize = true;
            this.labelSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettings.Location = new System.Drawing.Point(311, 8);
            this.labelSettings.Name = "labelSettings";
            this.labelSettings.Size = new System.Drawing.Size(59, 16);
            this.labelSettings.TabIndex = 42;
            this.labelSettings.Text = "Settings:";
            // 
            // labelProfile
            // 
            this.labelProfile.AutoSize = true;
            this.labelProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProfile.Location = new System.Drawing.Point(8, 202);
            this.labelProfile.Name = "labelProfile";
            this.labelProfile.Size = new System.Drawing.Size(49, 16);
            this.labelProfile.TabIndex = 41;
            this.labelProfile.Text = "Profile:";
            // 
            // labelGame
            // 
            this.labelGame.AutoSize = true;
            this.labelGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGame.Location = new System.Drawing.Point(8, 8);
            this.labelGame.Name = "labelGame";
            this.labelGame.Size = new System.Drawing.Size(48, 16);
            this.labelGame.TabIndex = 40;
            this.labelGame.Text = "Game:";
            // 
            // listBoxProfile
            // 
            this.listBoxProfile.ContextMenuStrip = this.contextMenuStripProfile;
            this.listBoxProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxProfile.FormattingEnabled = true;
            this.listBoxProfile.ItemHeight = 16;
            this.listBoxProfile.Items.AddRange(new object[] {
            "Default",
            "Profile 1",
            "Profile 2"});
            this.listBoxProfile.Location = new System.Drawing.Point(11, 221);
            this.listBoxProfile.Name = "listBoxProfile";
            this.listBoxProfile.Size = new System.Drawing.Size(297, 180);
            this.listBoxProfile.TabIndex = 22;
            this.listBoxProfile.SelectedIndexChanged += new System.EventHandler(this.listBoxProfile_SelectedIndexChanged);
            // 
            // contextMenuStripProfile
            // 
            this.contextMenuStripProfile.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profileToolStripMenuItem,
            this.openFolderProfileToolStripMenuItem,
            this.toolStripSeparator3,
            this.renameProfileToolStripMenuItem,
            this.deleteProfileToolStripMenuItem});
            this.contextMenuStripProfile.Name = "contextMenuStripProfile";
            this.contextMenuStripProfile.Size = new System.Drawing.Size(138, 98);
            this.contextMenuStripProfile.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripProfile_Opening);
            // 
            // profileToolStripMenuItem
            // 
            this.profileToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.profileToolStripMenuItem.Enabled = false;
            this.profileToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.profileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.profileToolStripMenuItem.Name = "profileToolStripMenuItem";
            this.profileToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.profileToolStripMenuItem.Text = "Default";
            // 
            // openFolderProfileToolStripMenuItem
            // 
            this.openFolderProfileToolStripMenuItem.Image = global::Fo76ini.Properties.Resources.folder_24;
            this.openFolderProfileToolStripMenuItem.Name = "openFolderProfileToolStripMenuItem";
            this.openFolderProfileToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.openFolderProfileToolStripMenuItem.Text = "Open folder";
            this.openFolderProfileToolStripMenuItem.Click += new System.EventHandler(this.openFolderProfileToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(134, 6);
            // 
            // renameProfileToolStripMenuItem
            // 
            this.renameProfileToolStripMenuItem.Image = global::Fo76ini.Properties.Resources.text_24;
            this.renameProfileToolStripMenuItem.Name = "renameProfileToolStripMenuItem";
            this.renameProfileToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.renameProfileToolStripMenuItem.Text = "Rename";
            this.renameProfileToolStripMenuItem.Click += new System.EventHandler(this.renameProfileToolStripMenuItem_Click);
            // 
            // deleteProfileToolStripMenuItem
            // 
            this.deleteProfileToolStripMenuItem.Image = global::Fo76ini.Properties.Resources.delete_24;
            this.deleteProfileToolStripMenuItem.Name = "deleteProfileToolStripMenuItem";
            this.deleteProfileToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.deleteProfileToolStripMenuItem.Text = "Delete";
            this.deleteProfileToolStripMenuItem.Click += new System.EventHandler(this.deleteProfileToolStripMenuItem_Click);
            // 
            // panelSettings
            // 
            this.panelSettings.AutoScroll = true;
            this.panelSettings.AutoScrollMargin = new System.Drawing.Size(0, 8);
            this.panelSettings.BackColor = System.Drawing.SystemColors.Window;
            this.panelSettings.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSettings.Controls.Add(this.groupBox2);
            this.panelSettings.Controls.Add(this.groupBoxLaunchOptions);
            this.panelSettings.Controls.Add(this.groupBoxGameLocation);
            this.panelSettings.Controls.Add(this.groupBoxGameEdition);
            this.panelSettings.Location = new System.Drawing.Point(314, 27);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(338, 388);
            this.panelSettings.TabIndex = 39;
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
            this.groupBox2.Location = new System.Drawing.Point(7, 362);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(306, 128);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Advanced";
            // 
            // textBoxLaunchURL
            // 
            this.textBoxLaunchURL.Location = new System.Drawing.Point(112, 95);
            this.textBoxLaunchURL.Name = "textBoxLaunchURL";
            this.textBoxLaunchURL.Size = new System.Drawing.Size(188, 20);
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
            this.textBoxParameters.Size = new System.Drawing.Size(188, 20);
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
            this.textBoxExecutable.Size = new System.Drawing.Size(188, 20);
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
            this.textBoxIniPrefix.Size = new System.Drawing.Size(188, 20);
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
            // groupBoxLaunchOptions
            // 
            this.groupBoxLaunchOptions.Controls.Add(this.labelLaunchOptionMSStoreNotice);
            this.groupBoxLaunchOptions.Controls.Add(this.radioButtonLaunchViaExecutable);
            this.groupBoxLaunchOptions.Controls.Add(this.radioButtonLaunchViaLink);
            this.groupBoxLaunchOptions.Location = new System.Drawing.Point(7, 248);
            this.groupBoxLaunchOptions.Name = "groupBoxLaunchOptions";
            this.groupBoxLaunchOptions.Size = new System.Drawing.Size(306, 108);
            this.groupBoxLaunchOptions.TabIndex = 36;
            this.groupBoxLaunchOptions.TabStop = false;
            this.groupBoxLaunchOptions.Text = "Launch options";
            // 
            // labelLaunchOptionMSStoreNotice
            // 
            this.labelLaunchOptionMSStoreNotice.ForeColor = System.Drawing.Color.Red;
            this.labelLaunchOptionMSStoreNotice.Location = new System.Drawing.Point(7, 68);
            this.labelLaunchOptionMSStoreNotice.Name = "labelLaunchOptionMSStoreNotice";
            this.labelLaunchOptionMSStoreNotice.Size = new System.Drawing.Size(290, 29);
            this.labelLaunchOptionMSStoreNotice.TabIndex = 4;
            this.labelLaunchOptionMSStoreNotice.Text = "Fallout 76 cannot be run directly, if installed through the Microsoft Store.";
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
            this.radioButtonLaunchViaLink.Size = new System.Drawing.Size(261, 17);
            this.radioButtonLaunchViaLink.TabIndex = 0;
            this.radioButtonLaunchViaLink.TabStop = true;
            this.radioButtonLaunchViaLink.Text = "Launch via Steam / Bethesda.net (recommended)";
            this.radioButtonLaunchViaLink.UseVisualStyleBackColor = true;
            this.radioButtonLaunchViaLink.CheckedChanged += new System.EventHandler(this.radioButtonLaunchViaLink_CheckedChanged);
            // 
            // groupBoxGameLocation
            // 
            this.groupBoxGameLocation.Controls.Add(this.buttonAutoDetect);
            this.groupBoxGameLocation.Controls.Add(this.textBoxGamePath);
            this.groupBoxGameLocation.Controls.Add(this.buttonPickGamePath);
            this.groupBoxGameLocation.Location = new System.Drawing.Point(7, 155);
            this.groupBoxGameLocation.Name = "groupBoxGameLocation";
            this.groupBoxGameLocation.Size = new System.Drawing.Size(306, 87);
            this.groupBoxGameLocation.TabIndex = 37;
            this.groupBoxGameLocation.TabStop = false;
            this.groupBoxGameLocation.Text = "Game location";
            // 
            // textBoxGamePath
            // 
            this.textBoxGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGamePath.Location = new System.Drawing.Point(6, 21);
            this.textBoxGamePath.Name = "textBoxGamePath";
            this.textBoxGamePath.Size = new System.Drawing.Size(260, 20);
            this.textBoxGamePath.TabIndex = 30;
            this.textBoxGamePath.TextChanged += new System.EventHandler(this.textBoxGamePath_TextChanged);
            // 
            // buttonPickGamePath
            // 
            this.buttonPickGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPickGamePath.Location = new System.Drawing.Point(272, 19);
            this.buttonPickGamePath.Name = "buttonPickGamePath";
            this.buttonPickGamePath.Size = new System.Drawing.Size(28, 23);
            this.buttonPickGamePath.TabIndex = 31;
            this.buttonPickGamePath.Text = "...";
            this.buttonPickGamePath.UseVisualStyleBackColor = true;
            this.buttonPickGamePath.Click += new System.EventHandler(this.buttonPickGamePath_Click);
            // 
            // groupBoxGameEdition
            // 
            this.groupBoxGameEdition.Controls.Add(this.pictureBoxMSStore);
            this.groupBoxGameEdition.Controls.Add(this.pictureBoxSteam);
            this.groupBoxGameEdition.Controls.Add(this.pictureBoxBethesdaNetPTS);
            this.groupBoxGameEdition.Controls.Add(this.pictureBoxBethesdaNet);
            this.groupBoxGameEdition.Controls.Add(this.radioButtonEditionMSStore);
            this.groupBoxGameEdition.Controls.Add(this.radioButtonEditionBethesdaNetPTS);
            this.groupBoxGameEdition.Controls.Add(this.radioButtonEditionSteam);
            this.groupBoxGameEdition.Controls.Add(this.radioButtonEditionBethesdaNet);
            this.groupBoxGameEdition.Location = new System.Drawing.Point(7, 5);
            this.groupBoxGameEdition.Name = "groupBoxGameEdition";
            this.groupBoxGameEdition.Size = new System.Drawing.Size(306, 144);
            this.groupBoxGameEdition.TabIndex = 35;
            this.groupBoxGameEdition.TabStop = false;
            this.groupBoxGameEdition.Text = "Game edition";
            // 
            // pictureBoxMSStore
            // 
            this.pictureBoxMSStore.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMSStore.Image = global::Fo76ini.Properties.Resources.msstore_24;
            this.pictureBoxMSStore.Location = new System.Drawing.Point(11, 109);
            this.pictureBoxMSStore.Name = "pictureBoxMSStore";
            this.pictureBoxMSStore.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxMSStore.TabIndex = 29;
            this.pictureBoxMSStore.TabStop = false;
            // 
            // pictureBoxSteam
            // 
            this.pictureBoxSteam.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSteam.Image = global::Fo76ini.Properties.Resources.steam_24px;
            this.pictureBoxSteam.Location = new System.Drawing.Point(11, 79);
            this.pictureBoxSteam.Name = "pictureBoxSteam";
            this.pictureBoxSteam.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxSteam.TabIndex = 28;
            this.pictureBoxSteam.TabStop = false;
            // 
            // pictureBoxBethesdaNetPTS
            // 
            this.pictureBoxBethesdaNetPTS.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBethesdaNetPTS.Image = global::Fo76ini.Properties.Resources.bethesda_24;
            this.pictureBoxBethesdaNetPTS.Location = new System.Drawing.Point(11, 49);
            this.pictureBoxBethesdaNetPTS.Name = "pictureBoxBethesdaNetPTS";
            this.pictureBoxBethesdaNetPTS.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxBethesdaNetPTS.TabIndex = 27;
            this.pictureBoxBethesdaNetPTS.TabStop = false;
            // 
            // pictureBoxBethesdaNet
            // 
            this.pictureBoxBethesdaNet.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxBethesdaNet.Image = global::Fo76ini.Properties.Resources.bethesda_24;
            this.pictureBoxBethesdaNet.Location = new System.Drawing.Point(11, 19);
            this.pictureBoxBethesdaNet.Name = "pictureBoxBethesdaNet";
            this.pictureBoxBethesdaNet.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxBethesdaNet.TabIndex = 26;
            this.pictureBoxBethesdaNet.TabStop = false;
            // 
            // radioButtonEditionMSStore
            // 
            this.radioButtonEditionMSStore.AutoSize = true;
            this.radioButtonEditionMSStore.Location = new System.Drawing.Point(43, 112);
            this.radioButtonEditionMSStore.Name = "radioButtonEditionMSStore";
            this.radioButtonEditionMSStore.Size = new System.Drawing.Size(188, 17);
            this.radioButtonEditionMSStore.TabIndex = 3;
            this.radioButtonEditionMSStore.Text = "Microsoft Store / Xbox Game Pass";
            this.radioButtonEditionMSStore.UseVisualStyleBackColor = true;
            this.radioButtonEditionMSStore.CheckedChanged += new System.EventHandler(this.radioButtonEditionMSStore_CheckedChanged);
            // 
            // radioButtonEditionBethesdaNetPTS
            // 
            this.radioButtonEditionBethesdaNetPTS.AutoSize = true;
            this.radioButtonEditionBethesdaNetPTS.Location = new System.Drawing.Point(43, 52);
            this.radioButtonEditionBethesdaNetPTS.Name = "radioButtonEditionBethesdaNetPTS";
            this.radioButtonEditionBethesdaNetPTS.Size = new System.Drawing.Size(118, 17);
            this.radioButtonEditionBethesdaNetPTS.TabIndex = 2;
            this.radioButtonEditionBethesdaNetPTS.Text = "Bethesda.net (PTS)";
            this.radioButtonEditionBethesdaNetPTS.UseVisualStyleBackColor = true;
            this.radioButtonEditionBethesdaNetPTS.CheckedChanged += new System.EventHandler(this.radioButtonEditionBethesdaNetPTS_CheckedChanged);
            // 
            // radioButtonEditionSteam
            // 
            this.radioButtonEditionSteam.AutoSize = true;
            this.radioButtonEditionSteam.Location = new System.Drawing.Point(43, 82);
            this.radioButtonEditionSteam.Name = "radioButtonEditionSteam";
            this.radioButtonEditionSteam.Size = new System.Drawing.Size(55, 17);
            this.radioButtonEditionSteam.TabIndex = 1;
            this.radioButtonEditionSteam.Text = "Steam";
            this.radioButtonEditionSteam.UseVisualStyleBackColor = true;
            this.radioButtonEditionSteam.CheckedChanged += new System.EventHandler(this.radioButtonEditionSteam_CheckedChanged);
            // 
            // radioButtonEditionBethesdaNet
            // 
            this.radioButtonEditionBethesdaNet.AutoSize = true;
            this.radioButtonEditionBethesdaNet.Location = new System.Drawing.Point(43, 22);
            this.radioButtonEditionBethesdaNet.Name = "radioButtonEditionBethesdaNet";
            this.radioButtonEditionBethesdaNet.Size = new System.Drawing.Size(88, 17);
            this.radioButtonEditionBethesdaNet.TabIndex = 0;
            this.radioButtonEditionBethesdaNet.Text = "Bethesda.net";
            this.radioButtonEditionBethesdaNet.UseVisualStyleBackColor = true;
            this.radioButtonEditionBethesdaNet.CheckedChanged += new System.EventHandler(this.radioButtonEditionBethesdaNet_CheckedChanged);
            // 
            // listViewGameInstances
            // 
            this.listViewGameInstances.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewGameInstances.ContextMenuStrip = this.contextMenuStripGame;
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
            this.listViewGameInstances.LargeImageList = this.imageList1;
            this.listViewGameInstances.Location = new System.Drawing.Point(11, 27);
            this.listViewGameInstances.MultiSelect = false;
            this.listViewGameInstances.Name = "listViewGameInstances";
            this.listViewGameInstances.Size = new System.Drawing.Size(297, 163);
            this.listViewGameInstances.SmallImageList = this.imageList1;
            this.listViewGameInstances.TabIndex = 21;
            this.listViewGameInstances.UseCompatibleStateImageBehavior = false;
            this.listViewGameInstances.View = System.Windows.Forms.View.Details;
            this.listViewGameInstances.SelectedIndexChanged += new System.EventHandler(this.listViewGameInstances_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Game";
            this.columnHeader1.Width = 274;
            // 
            // contextMenuStripGame
            // 
            this.contextMenuStripGame.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem,
            this.launchGameToolStripMenuItem,
            this.toolStripSeparator2,
            this.renameGameToolStripMenuItem,
            this.removeGameToolStripMenuItem});
            this.contextMenuStripGame.Name = "contextMenuStripGame";
            this.contextMenuStripGame.Size = new System.Drawing.Size(118, 98);
            this.contextMenuStripGame.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripGame_Opening);
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.Enabled = false;
            this.gameToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // launchGameToolStripMenuItem
            // 
            this.launchGameToolStripMenuItem.Image = global::Fo76ini.Properties.Resources.play;
            this.launchGameToolStripMenuItem.Name = "launchGameToolStripMenuItem";
            this.launchGameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.launchGameToolStripMenuItem.Text = "Launch";
            this.launchGameToolStripMenuItem.Click += new System.EventHandler(this.launchGameToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(114, 6);
            // 
            // renameGameToolStripMenuItem
            // 
            this.renameGameToolStripMenuItem.Image = global::Fo76ini.Properties.Resources.text_24;
            this.renameGameToolStripMenuItem.Name = "renameGameToolStripMenuItem";
            this.renameGameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.renameGameToolStripMenuItem.Text = "Rename";
            this.renameGameToolStripMenuItem.Click += new System.EventHandler(this.renameGameToolStripMenuItem_Click);
            // 
            // removeGameToolStripMenuItem
            // 
            this.removeGameToolStripMenuItem.Image = global::Fo76ini.Properties.Resources.delete_24;
            this.removeGameToolStripMenuItem.Name = "removeGameToolStripMenuItem";
            this.removeGameToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.removeGameToolStripMenuItem.Text = "Remove";
            this.removeGameToolStripMenuItem.Click += new System.EventHandler(this.removeGameToolStripMenuItem_Click);
            // 
            // openFileDialogGamePath
            // 
            this.openFileDialogGamePath.FileName = "Fallout76.exe";
            this.openFileDialogGamePath.Filter = "Executable|*.exe";
            this.openFileDialogGamePath.FilterIndex = 2;
            // 
            // buttonAutoDetect
            // 
            this.buttonAutoDetect.Location = new System.Drawing.Point(6, 48);
            this.buttonAutoDetect.Name = "buttonAutoDetect";
            this.buttonAutoDetect.Size = new System.Drawing.Size(294, 23);
            this.buttonAutoDetect.TabIndex = 32;
            this.buttonAutoDetect.Text = "Attempt auto-detect";
            this.buttonAutoDetect.UseVisualStyleBackColor = true;
            this.buttonAutoDetect.Click += new System.EventHandler(this.buttonAutoDetect_Click);
            // 
            // FormProfiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 461);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormProfiles";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Profiles";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contextMenuStripProfile.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxLaunchOptions.ResumeLayout(false);
            this.groupBoxLaunchOptions.PerformLayout();
            this.groupBoxGameLocation.ResumeLayout(false);
            this.groupBoxGameLocation.PerformLayout();
            this.groupBoxGameEdition.ResumeLayout(false);
            this.groupBoxGameEdition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMSStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSteam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBethesdaNetPTS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBethesdaNet)).EndInit();
            this.contextMenuStripGame.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listViewGameInstances;
        private System.Windows.Forms.ListBox listBoxProfile;
        private System.Windows.Forms.TextBox textBoxGamePath;
        private System.Windows.Forms.Button buttonPickGamePath;
        private System.Windows.Forms.GroupBox groupBoxGameLocation;
        private System.Windows.Forms.GroupBox groupBoxGameEdition;
        private System.Windows.Forms.PictureBox pictureBoxMSStore;
        private System.Windows.Forms.PictureBox pictureBoxSteam;
        private System.Windows.Forms.PictureBox pictureBoxBethesdaNetPTS;
        private System.Windows.Forms.PictureBox pictureBoxBethesdaNet;
        private System.Windows.Forms.RadioButton radioButtonEditionMSStore;
        private System.Windows.Forms.RadioButton radioButtonEditionBethesdaNetPTS;
        private System.Windows.Forms.RadioButton radioButtonEditionSteam;
        private System.Windows.Forms.RadioButton radioButtonEditionBethesdaNet;
        private System.Windows.Forms.GroupBox groupBoxLaunchOptions;
        private System.Windows.Forms.RadioButton radioButtonLaunchViaExecutable;
        private System.Windows.Forms.RadioButton radioButtonLaunchViaLink;
        private System.Windows.Forms.Panel panelSettings;
        private System.Windows.Forms.Label labelSettings;
        private System.Windows.Forms.Label labelProfile;
        private System.Windows.Forms.Label labelGame;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxExecutable;
        private System.Windows.Forms.Label labelExecutable;
        private System.Windows.Forms.TextBox textBoxIniPrefix;
        private System.Windows.Forms.Label labelIniPrefix;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddGame;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddProfile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGame;
        private System.Windows.Forms.ToolStripMenuItem launchGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem renameGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeGameToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripProfile;
        private System.Windows.Forms.ToolStripMenuItem renameProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteProfileToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogGamePath;
        private System.Windows.Forms.Label labelLaunchOptionMSStoreNotice;
        private System.Windows.Forms.TextBox textBoxLaunchURL;
        private System.Windows.Forms.Label labelLaunchURL;
        private System.Windows.Forms.TextBox textBoxParameters;
        private System.Windows.Forms.Label labelParameters;
        private System.Windows.Forms.ToolStripMenuItem openFolderProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profileToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.Label labelTip;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button buttonAutoDetect;
    }
}