namespace Fo76ini.Forms.FormSettings
{
    partial class FormSettings
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
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Microsoft Store", 3);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettings));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.groupBoxActions = new System.Windows.Forms.GroupBox();
            this.linkLabelEnableDangerZone = new System.Windows.Forms.LinkLabel();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.checkBoxReadOnly = new System.Windows.Forms.CheckBox();
            this.groupBoxNuclearWinterMode = new System.Windows.Forms.GroupBox();
            this.checkBoxNWAutoDeployMods = new System.Windows.Forms.CheckBox();
            this.labelNWmodoptions = new System.Windows.Forms.Label();
            this.labelNWdlloptions = new System.Windows.Forms.Label();
            this.checkBoxNWAutoDisableMods = new System.Windows.Forms.CheckBox();
            this.checkBoxNWRenameDLL = new System.Windows.Forms.CheckBox();
            this.groupBoxBehavior = new System.Windows.Forms.GroupBox();
            this.checkBoxPlayNotificationSound = new System.Windows.Forms.CheckBox();
            this.checkBoxIgnoreUpdates = new System.Windows.Forms.CheckBox();
            this.checkBoxQuitOnGameLaunch = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoApply = new System.Windows.Forms.CheckBox();
            this.groupBoxLocalization = new System.Windows.Forms.GroupBox();
            this.buttonRefreshLanguage = new System.Windows.Forms.Button();
            this.pictureBoxSpinnerDownloadLanguages = new System.Windows.Forms.PictureBox();
            this.labelOutdatedLanguage = new System.Windows.Forms.Label();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.buttonDownloadLanguages = new System.Windows.Forms.Button();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.tabPageGameProfiles = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxSettings = new System.Windows.Forms.GroupBox();
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
            this.buttonAutoDetect = new System.Windows.Forms.Button();
            this.textBoxGamePath = new System.Windows.Forms.TextBox();
            this.buttonPickGamePath = new System.Windows.Forms.Button();
            this.groupBoxGameEdition = new System.Windows.Forms.GroupBox();
            this.radioButtonEditionUnknown = new System.Windows.Forms.RadioButton();
            this.pictureBoxUnknown = new System.Windows.Forms.PictureBox();
            this.pictureBoxMSStore = new System.Windows.Forms.PictureBox();
            this.pictureBoxSteam = new System.Windows.Forms.PictureBox();
            this.pictureBoxBethesdaNetPTS = new System.Windows.Forms.PictureBox();
            this.pictureBoxBethesdaNet = new System.Windows.Forms.PictureBox();
            this.radioButtonEditionMSStore = new System.Windows.Forms.RadioButton();
            this.radioButtonEditionBethesdaNetPTS = new System.Windows.Forms.RadioButton();
            this.radioButtonEditionSteam = new System.Windows.Forms.RadioButton();
            this.radioButtonEditionBethesdaNet = new System.Windows.Forms.RadioButton();
            this.groupBoxGame = new System.Windows.Forms.GroupBox();
            this.listViewGameInstances = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripGame = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.launchGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.renameGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelTip = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonAddGame = new System.Windows.Forms.ToolStripButton();
            this.tabPageNexusMods = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelAPIKey = new System.Windows.Forms.Label();
            this.checkBoxShowAPIKey = new System.Windows.Forms.CheckBox();
            this.textBoxAPIKey = new System.Windows.Forms.TextBox();
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
            this.labelNMDailyRateLimitReset = new System.Windows.Forms.Label();
            this.labelNMMembership = new System.Windows.Forms.Label();
            this.labelNMDescLimitReset = new System.Windows.Forms.Label();
            this.labelNMDescDailyRateLimit = new System.Windows.Forms.Label();
            this.labelNMDailyRateLimit = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialogGamePath = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorkerDownloadLanguages = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerRetrieveProfileInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerSSOLogin = new System.ComponentModel.BackgroundWorker();
            this.buttonNMLoginManually = new System.Windows.Forms.Button();
            this.linkLabelAPIKeyHelp = new System.Windows.Forms.LinkLabel();
            this.pictureBoxAPIKeyHelp = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPageGeneral.SuspendLayout();
            this.groupBoxActions.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxNuclearWinterMode.SuspendLayout();
            this.groupBoxBehavior.SuspendLayout();
            this.groupBoxLocalization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerDownloadLanguages)).BeginInit();
            this.tabPageGameProfiles.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBoxSettings.SuspendLayout();
            this.panelSettings.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxLaunchOptions.SuspendLayout();
            this.groupBoxGameLocation.SuspendLayout();
            this.groupBoxGameEdition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUnknown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMSStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSteam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBethesdaNetPTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBethesdaNet)).BeginInit();
            this.groupBoxGame.SuspendLayout();
            this.contextMenuStripGame.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPageNexusMods.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNMProfilePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAPIKeyHelp)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageGeneral);
            this.tabControl1.Controls.Add(this.tabPageGameProfiles);
            this.tabControl1.Controls.Add(this.tabPageNexusMods);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(774, 534);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Controls.Add(this.groupBoxActions);
            this.tabPageGeneral.Controls.Add(this.groupBoxOptions);
            this.tabPageGeneral.Controls.Add(this.groupBoxNuclearWinterMode);
            this.tabPageGeneral.Controls.Add(this.groupBoxBehavior);
            this.tabPageGeneral.Controls.Add(this.groupBoxLocalization);
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(766, 508);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // groupBoxActions
            // 
            this.groupBoxActions.Controls.Add(this.linkLabelEnableDangerZone);
            this.groupBoxActions.Location = new System.Drawing.Point(6, 227);
            this.groupBoxActions.Name = "groupBoxActions";
            this.groupBoxActions.Size = new System.Drawing.Size(390, 78);
            this.groupBoxActions.TabIndex = 43;
            this.groupBoxActions.TabStop = false;
            this.groupBoxActions.Text = "Actions";
            // 
            // linkLabelEnableDangerZone
            // 
            this.linkLabelEnableDangerZone.AutoSize = true;
            this.linkLabelEnableDangerZone.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabelEnableDangerZone.LinkColor = System.Drawing.Color.Red;
            this.linkLabelEnableDangerZone.Location = new System.Drawing.Point(8, 18);
            this.linkLabelEnableDangerZone.Name = "linkLabelEnableDangerZone";
            this.linkLabelEnableDangerZone.Size = new System.Drawing.Size(121, 13);
            this.linkLabelEnableDangerZone.TabIndex = 44;
            this.linkLabelEnableDangerZone.TabStop = true;
            this.linkLabelEnableDangerZone.Text = "⚠️ Enable Danger Zone";
            this.linkLabelEnableDangerZone.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelEnableDangerZone_LinkClicked);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.checkBoxReadOnly);
            this.groupBoxOptions.Location = new System.Drawing.Point(402, 6);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(358, 47);
            this.groupBoxOptions.TabIndex = 42;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // checkBoxReadOnly
            // 
            this.checkBoxReadOnly.AutoSize = true;
            this.checkBoxReadOnly.Location = new System.Drawing.Point(11, 19);
            this.checkBoxReadOnly.Name = "checkBoxReadOnly";
            this.checkBoxReadOnly.Size = new System.Drawing.Size(140, 17);
            this.checkBoxReadOnly.TabIndex = 4;
            this.checkBoxReadOnly.Text = "Make *.ini files read-only";
            this.checkBoxReadOnly.UseVisualStyleBackColor = true;
            // 
            // groupBoxNuclearWinterMode
            // 
            this.groupBoxNuclearWinterMode.Controls.Add(this.checkBoxNWAutoDeployMods);
            this.groupBoxNuclearWinterMode.Controls.Add(this.labelNWmodoptions);
            this.groupBoxNuclearWinterMode.Controls.Add(this.labelNWdlloptions);
            this.groupBoxNuclearWinterMode.Controls.Add(this.checkBoxNWAutoDisableMods);
            this.groupBoxNuclearWinterMode.Controls.Add(this.checkBoxNWRenameDLL);
            this.groupBoxNuclearWinterMode.Location = new System.Drawing.Point(402, 59);
            this.groupBoxNuclearWinterMode.Name = "groupBoxNuclearWinterMode";
            this.groupBoxNuclearWinterMode.Size = new System.Drawing.Size(358, 162);
            this.groupBoxNuclearWinterMode.TabIndex = 41;
            this.groupBoxNuclearWinterMode.TabStop = false;
            this.groupBoxNuclearWinterMode.Text = "Nuclear Winter options";
            // 
            // checkBoxNWAutoDeployMods
            // 
            this.checkBoxNWAutoDeployMods.AutoSize = true;
            this.checkBoxNWAutoDeployMods.Location = new System.Drawing.Point(10, 117);
            this.checkBoxNWAutoDeployMods.Name = "checkBoxNWAutoDeployMods";
            this.checkBoxNWAutoDeployMods.Size = new System.Drawing.Size(221, 17);
            this.checkBoxNWAutoDeployMods.TabIndex = 25;
            this.checkBoxNWAutoDeployMods.Text = "Automatically deploy mods upon disabling";
            this.checkBoxNWAutoDeployMods.UseVisualStyleBackColor = true;
            // 
            // labelNWmodoptions
            // 
            this.labelNWmodoptions.AutoSize = true;
            this.labelNWmodoptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNWmodoptions.Location = new System.Drawing.Point(7, 76);
            this.labelNWmodoptions.Name = "labelNWmodoptions";
            this.labelNWmodoptions.Size = new System.Drawing.Size(80, 13);
            this.labelNWmodoptions.TabIndex = 24;
            this.labelNWmodoptions.Text = "Mod options:";
            // 
            // labelNWdlloptions
            // 
            this.labelNWdlloptions.AutoSize = true;
            this.labelNWdlloptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNWdlloptions.Location = new System.Drawing.Point(7, 23);
            this.labelNWdlloptions.Name = "labelNWdlloptions";
            this.labelNWdlloptions.Size = new System.Drawing.Size(78, 13);
            this.labelNWdlloptions.TabIndex = 23;
            this.labelNWdlloptions.Text = "*.dll options:";
            // 
            // checkBoxNWAutoDisableMods
            // 
            this.checkBoxNWAutoDisableMods.AutoSize = true;
            this.checkBoxNWAutoDisableMods.Location = new System.Drawing.Point(10, 94);
            this.checkBoxNWAutoDisableMods.Name = "checkBoxNWAutoDisableMods";
            this.checkBoxNWAutoDisableMods.Size = new System.Drawing.Size(224, 17);
            this.checkBoxNWAutoDisableMods.TabIndex = 19;
            this.checkBoxNWAutoDisableMods.Text = "Automatically remove mods upon enabling";
            this.checkBoxNWAutoDisableMods.UseVisualStyleBackColor = true;
            // 
            // checkBoxNWRenameDLL
            // 
            this.checkBoxNWRenameDLL.AutoSize = true;
            this.checkBoxNWRenameDLL.Location = new System.Drawing.Point(10, 41);
            this.checkBoxNWRenameDLL.Name = "checkBoxNWRenameDLL";
            this.checkBoxNWRenameDLL.Size = new System.Drawing.Size(140, 17);
            this.checkBoxNWRenameDLL.TabIndex = 18;
            this.checkBoxNWRenameDLL.Text = "Rename added *.dll files";
            this.checkBoxNWRenameDLL.UseVisualStyleBackColor = true;
            // 
            // groupBoxBehavior
            // 
            this.groupBoxBehavior.Controls.Add(this.checkBoxPlayNotificationSound);
            this.groupBoxBehavior.Controls.Add(this.checkBoxIgnoreUpdates);
            this.groupBoxBehavior.Controls.Add(this.checkBoxQuitOnGameLaunch);
            this.groupBoxBehavior.Controls.Add(this.checkBoxAutoApply);
            this.groupBoxBehavior.Location = new System.Drawing.Point(6, 103);
            this.groupBoxBehavior.Name = "groupBoxBehavior";
            this.groupBoxBehavior.Size = new System.Drawing.Size(390, 118);
            this.groupBoxBehavior.TabIndex = 32;
            this.groupBoxBehavior.TabStop = false;
            this.groupBoxBehavior.Text = "Behavior";
            // 
            // checkBoxPlayNotificationSound
            // 
            this.checkBoxPlayNotificationSound.AutoSize = true;
            this.checkBoxPlayNotificationSound.Location = new System.Drawing.Point(9, 89);
            this.checkBoxPlayNotificationSound.Name = "checkBoxPlayNotificationSound";
            this.checkBoxPlayNotificationSound.Size = new System.Drawing.Size(132, 17);
            this.checkBoxPlayNotificationSound.TabIndex = 25;
            this.checkBoxPlayNotificationSound.Text = "Play notification sound";
            this.checkBoxPlayNotificationSound.UseVisualStyleBackColor = true;
            // 
            // checkBoxIgnoreUpdates
            // 
            this.checkBoxIgnoreUpdates.AutoSize = true;
            this.checkBoxIgnoreUpdates.Location = new System.Drawing.Point(9, 66);
            this.checkBoxIgnoreUpdates.Name = "checkBoxIgnoreUpdates";
            this.checkBoxIgnoreUpdates.Size = new System.Drawing.Size(143, 17);
            this.checkBoxIgnoreUpdates.TabIndex = 24;
            this.checkBoxIgnoreUpdates.Text = "Don\'t check for updates.";
            this.checkBoxIgnoreUpdates.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreUpdates.CheckedChanged += new System.EventHandler(this.checkBoxIgnoreUpdates_CheckedChanged);
            // 
            // checkBoxQuitOnGameLaunch
            // 
            this.checkBoxQuitOnGameLaunch.AutoSize = true;
            this.checkBoxQuitOnGameLaunch.Location = new System.Drawing.Point(9, 19);
            this.checkBoxQuitOnGameLaunch.Name = "checkBoxQuitOnGameLaunch";
            this.checkBoxQuitOnGameLaunch.Size = new System.Drawing.Size(223, 17);
            this.checkBoxQuitOnGameLaunch.TabIndex = 20;
            this.checkBoxQuitOnGameLaunch.Text = "Close the tool when the game is launched";
            this.checkBoxQuitOnGameLaunch.UseVisualStyleBackColor = true;
            // 
            // checkBoxAutoApply
            // 
            this.checkBoxAutoApply.AutoSize = true;
            this.checkBoxAutoApply.Location = new System.Drawing.Point(9, 42);
            this.checkBoxAutoApply.Name = "checkBoxAutoApply";
            this.checkBoxAutoApply.Size = new System.Drawing.Size(354, 17);
            this.checkBoxAutoApply.TabIndex = 21;
            this.checkBoxAutoApply.Text = "Automatically apply changes when tool is closed or game is launched.";
            this.checkBoxAutoApply.UseVisualStyleBackColor = true;
            // 
            // groupBoxLocalization
            // 
            this.groupBoxLocalization.Controls.Add(this.buttonRefreshLanguage);
            this.groupBoxLocalization.Controls.Add(this.pictureBoxSpinnerDownloadLanguages);
            this.groupBoxLocalization.Controls.Add(this.labelOutdatedLanguage);
            this.groupBoxLocalization.Controls.Add(this.labelLanguage);
            this.groupBoxLocalization.Controls.Add(this.buttonDownloadLanguages);
            this.groupBoxLocalization.Controls.Add(this.comboBoxLanguage);
            this.groupBoxLocalization.Location = new System.Drawing.Point(6, 6);
            this.groupBoxLocalization.Name = "groupBoxLocalization";
            this.groupBoxLocalization.Size = new System.Drawing.Size(390, 91);
            this.groupBoxLocalization.TabIndex = 31;
            this.groupBoxLocalization.TabStop = false;
            this.groupBoxLocalization.Text = "Localization";
            // 
            // buttonRefreshLanguage
            // 
            this.buttonRefreshLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefreshLanguage.BackColor = System.Drawing.Color.Transparent;
            this.buttonRefreshLanguage.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonRefreshLanguage.FlatAppearance.BorderSize = 0;
            this.buttonRefreshLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefreshLanguage.Image = global::Fo76ini.Properties.Resources.available_updates;
            this.buttonRefreshLanguage.Location = new System.Drawing.Point(351, 49);
            this.buttonRefreshLanguage.Name = "buttonRefreshLanguage";
            this.buttonRefreshLanguage.Size = new System.Drawing.Size(32, 32);
            this.buttonRefreshLanguage.TabIndex = 40;
            this.toolTip.SetToolTip(this.buttonRefreshLanguage, "Refresh language list and reapply translation");
            this.buttonRefreshLanguage.UseVisualStyleBackColor = false;
            this.buttonRefreshLanguage.Click += new System.EventHandler(this.buttonRefreshLanguage_Click);
            // 
            // pictureBoxSpinnerDownloadLanguages
            // 
            this.pictureBoxSpinnerDownloadLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxSpinnerDownloadLanguages.Image = global::Fo76ini.Properties.Resources.Spinner_24;
            this.pictureBoxSpinnerDownloadLanguages.Location = new System.Drawing.Point(283, 53);
            this.pictureBoxSpinnerDownloadLanguages.Name = "pictureBoxSpinnerDownloadLanguages";
            this.pictureBoxSpinnerDownloadLanguages.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxSpinnerDownloadLanguages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSpinnerDownloadLanguages.TabIndex = 40;
            this.pictureBoxSpinnerDownloadLanguages.TabStop = false;
            this.pictureBoxSpinnerDownloadLanguages.Visible = false;
            // 
            // labelOutdatedLanguage
            // 
            this.labelOutdatedLanguage.AutoSize = true;
            this.labelOutdatedLanguage.ForeColor = System.Drawing.Color.Firebrick;
            this.labelOutdatedLanguage.Location = new System.Drawing.Point(8, 53);
            this.labelOutdatedLanguage.Name = "labelOutdatedLanguage";
            this.labelOutdatedLanguage.Size = new System.Drawing.Size(209, 26);
            this.labelOutdatedLanguage.TabIndex = 21;
            this.labelOutdatedLanguage.Text = "This translation is out-dated.\r\nSome elements might not be translated yet.";
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(7, 25);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(58, 13);
            this.labelLanguage.TabIndex = 16;
            this.labelLanguage.Text = "Language:";
            // 
            // buttonDownloadLanguages
            // 
            this.buttonDownloadLanguages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDownloadLanguages.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonDownloadLanguages.FlatAppearance.BorderSize = 0;
            this.buttonDownloadLanguages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDownloadLanguages.Image = global::Fo76ini.Properties.Resources.download_2_24;
            this.buttonDownloadLanguages.Location = new System.Drawing.Point(313, 49);
            this.buttonDownloadLanguages.Name = "buttonDownloadLanguages";
            this.buttonDownloadLanguages.Size = new System.Drawing.Size(32, 32);
            this.buttonDownloadLanguages.TabIndex = 20;
            this.toolTip.SetToolTip(this.buttonDownloadLanguages, "Download / update language files");
            this.buttonDownloadLanguages.UseVisualStyleBackColor = true;
            this.buttonDownloadLanguages.Click += new System.EventHandler(this.buttonDownloadLanguages_Click);
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(117, 22);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(266, 21);
            this.comboBoxLanguage.TabIndex = 17;
            // 
            // tabPageGameProfiles
            // 
            this.tabPageGameProfiles.Controls.Add(this.panel1);
            this.tabPageGameProfiles.Controls.Add(this.toolStrip1);
            this.tabPageGameProfiles.Location = new System.Drawing.Point(4, 22);
            this.tabPageGameProfiles.Name = "tabPageGameProfiles";
            this.tabPageGameProfiles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGameProfiles.Size = new System.Drawing.Size(766, 508);
            this.tabPageGameProfiles.TabIndex = 1;
            this.tabPageGameProfiles.Text = "Game profiles";
            this.tabPageGameProfiles.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.groupBoxSettings);
            this.panel1.Controls.Add(this.groupBoxGame);
            this.panel1.Controls.Add(this.labelTip);
            this.panel1.Location = new System.Drawing.Point(3, 39);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(760, 466);
            this.panel1.TabIndex = 20;
            // 
            // groupBoxSettings
            // 
            this.groupBoxSettings.Controls.Add(this.panelSettings);
            this.groupBoxSettings.Location = new System.Drawing.Point(348, 8);
            this.groupBoxSettings.Name = "groupBoxSettings";
            this.groupBoxSettings.Size = new System.Drawing.Size(404, 419);
            this.groupBoxSettings.TabIndex = 45;
            this.groupBoxSettings.TabStop = false;
            this.groupBoxSettings.Text = "Settings";
            // 
            // panelSettings
            // 
            this.panelSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelSettings.AutoScroll = true;
            this.panelSettings.AutoScrollMargin = new System.Drawing.Size(0, 8);
            this.panelSettings.BackColor = System.Drawing.SystemColors.Window;
            this.panelSettings.Controls.Add(this.groupBox2);
            this.panelSettings.Controls.Add(this.groupBoxLaunchOptions);
            this.panelSettings.Controls.Add(this.groupBoxGameLocation);
            this.panelSettings.Controls.Add(this.groupBoxGameEdition);
            this.panelSettings.Location = new System.Drawing.Point(2, 14);
            this.panelSettings.Name = "panelSettings";
            this.panelSettings.Size = new System.Drawing.Size(401, 402);
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
            this.groupBox2.Location = new System.Drawing.Point(7, 397);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(369, 128);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Advanced";
            // 
            // textBoxLaunchURL
            // 
            this.textBoxLaunchURL.Location = new System.Drawing.Point(112, 95);
            this.textBoxLaunchURL.Name = "textBoxLaunchURL";
            this.textBoxLaunchURL.Size = new System.Drawing.Size(251, 20);
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
            this.textBoxParameters.Size = new System.Drawing.Size(251, 20);
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
            this.textBoxExecutable.Size = new System.Drawing.Size(251, 20);
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
            this.textBoxIniPrefix.Size = new System.Drawing.Size(251, 20);
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
            this.groupBoxLaunchOptions.Location = new System.Drawing.Point(7, 283);
            this.groupBoxLaunchOptions.Name = "groupBoxLaunchOptions";
            this.groupBoxLaunchOptions.Size = new System.Drawing.Size(369, 108);
            this.groupBoxLaunchOptions.TabIndex = 36;
            this.groupBoxLaunchOptions.TabStop = false;
            this.groupBoxLaunchOptions.Text = "Launch options";
            // 
            // labelLaunchOptionMSStoreNotice
            // 
            this.labelLaunchOptionMSStoreNotice.ForeColor = System.Drawing.Color.Red;
            this.labelLaunchOptionMSStoreNotice.Location = new System.Drawing.Point(7, 68);
            this.labelLaunchOptionMSStoreNotice.Name = "labelLaunchOptionMSStoreNotice";
            this.labelLaunchOptionMSStoreNotice.Size = new System.Drawing.Size(356, 29);
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
            this.groupBoxGameLocation.Location = new System.Drawing.Point(7, 190);
            this.groupBoxGameLocation.Name = "groupBoxGameLocation";
            this.groupBoxGameLocation.Size = new System.Drawing.Size(369, 87);
            this.groupBoxGameLocation.TabIndex = 37;
            this.groupBoxGameLocation.TabStop = false;
            this.groupBoxGameLocation.Text = "Game location";
            // 
            // buttonAutoDetect
            // 
            this.buttonAutoDetect.Location = new System.Drawing.Point(6, 48);
            this.buttonAutoDetect.Name = "buttonAutoDetect";
            this.buttonAutoDetect.Size = new System.Drawing.Size(357, 23);
            this.buttonAutoDetect.TabIndex = 32;
            this.buttonAutoDetect.Text = "Attempt auto-detect";
            this.buttonAutoDetect.UseVisualStyleBackColor = true;
            this.buttonAutoDetect.Click += new System.EventHandler(this.buttonAutoDetect_Click);
            // 
            // textBoxGamePath
            // 
            this.textBoxGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGamePath.Location = new System.Drawing.Point(6, 21);
            this.textBoxGamePath.Name = "textBoxGamePath";
            this.textBoxGamePath.Size = new System.Drawing.Size(323, 20);
            this.textBoxGamePath.TabIndex = 30;
            this.textBoxGamePath.TextChanged += new System.EventHandler(this.textBoxGamePath_TextChanged);
            // 
            // buttonPickGamePath
            // 
            this.buttonPickGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPickGamePath.Location = new System.Drawing.Point(335, 19);
            this.buttonPickGamePath.Name = "buttonPickGamePath";
            this.buttonPickGamePath.Size = new System.Drawing.Size(28, 23);
            this.buttonPickGamePath.TabIndex = 31;
            this.buttonPickGamePath.Text = "...";
            this.buttonPickGamePath.UseVisualStyleBackColor = true;
            this.buttonPickGamePath.Click += new System.EventHandler(this.buttonPickGamePath_Click);
            // 
            // groupBoxGameEdition
            // 
            this.groupBoxGameEdition.Controls.Add(this.radioButtonEditionUnknown);
            this.groupBoxGameEdition.Controls.Add(this.pictureBoxUnknown);
            this.groupBoxGameEdition.Controls.Add(this.pictureBoxMSStore);
            this.groupBoxGameEdition.Controls.Add(this.pictureBoxSteam);
            this.groupBoxGameEdition.Controls.Add(this.pictureBoxBethesdaNetPTS);
            this.groupBoxGameEdition.Controls.Add(this.pictureBoxBethesdaNet);
            this.groupBoxGameEdition.Controls.Add(this.radioButtonEditionMSStore);
            this.groupBoxGameEdition.Controls.Add(this.radioButtonEditionBethesdaNetPTS);
            this.groupBoxGameEdition.Controls.Add(this.radioButtonEditionSteam);
            this.groupBoxGameEdition.Controls.Add(this.radioButtonEditionBethesdaNet);
            this.groupBoxGameEdition.Location = new System.Drawing.Point(7, 9);
            this.groupBoxGameEdition.Name = "groupBoxGameEdition";
            this.groupBoxGameEdition.Size = new System.Drawing.Size(369, 175);
            this.groupBoxGameEdition.TabIndex = 35;
            this.groupBoxGameEdition.TabStop = false;
            this.groupBoxGameEdition.Text = "Game edition";
            // 
            // radioButtonEditionUnknown
            // 
            this.radioButtonEditionUnknown.AutoSize = true;
            this.radioButtonEditionUnknown.Location = new System.Drawing.Point(43, 142);
            this.radioButtonEditionUnknown.Name = "radioButtonEditionUnknown";
            this.radioButtonEditionUnknown.Size = new System.Drawing.Size(51, 17);
            this.radioButtonEditionUnknown.TabIndex = 31;
            this.radioButtonEditionUnknown.Text = "Other";
            this.radioButtonEditionUnknown.UseVisualStyleBackColor = true;
            this.radioButtonEditionUnknown.CheckedChanged += new System.EventHandler(this.radioButtonEditionUnknown_CheckedChanged);
            // 
            // pictureBoxUnknown
            // 
            this.pictureBoxUnknown.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxUnknown.Image = global::Fo76ini.Properties.Resources.help_24;
            this.pictureBoxUnknown.Location = new System.Drawing.Point(11, 139);
            this.pictureBoxUnknown.Name = "pictureBoxUnknown";
            this.pictureBoxUnknown.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxUnknown.TabIndex = 30;
            this.pictureBoxUnknown.TabStop = false;
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
            // groupBoxGame
            // 
            this.groupBoxGame.Controls.Add(this.listViewGameInstances);
            this.groupBoxGame.Location = new System.Drawing.Point(3, 8);
            this.groupBoxGame.Name = "groupBoxGame";
            this.groupBoxGame.Size = new System.Drawing.Size(339, 419);
            this.groupBoxGame.TabIndex = 44;
            this.groupBoxGame.TabStop = false;
            this.groupBoxGame.Text = "Game";
            // 
            // listViewGameInstances
            // 
            this.listViewGameInstances.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewGameInstances.BorderStyle = System.Windows.Forms.BorderStyle.None;
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
            this.listViewGameInstances.Location = new System.Drawing.Point(3, 18);
            this.listViewGameInstances.MultiSelect = false;
            this.listViewGameInstances.Name = "listViewGameInstances";
            this.listViewGameInstances.Size = new System.Drawing.Size(333, 398);
            this.listViewGameInstances.SmallImageList = this.imageList1;
            this.listViewGameInstances.TabIndex = 21;
            this.listViewGameInstances.UseCompatibleStateImageBehavior = false;
            this.listViewGameInstances.View = System.Windows.Forms.View.Details;
            this.listViewGameInstances.SelectedIndexChanged += new System.EventHandler(this.listViewGameInstances_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Game";
            this.columnHeader1.Width = 312;
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "help-24.png");
            this.imageList1.Images.SetKeyName(1, "bethesda_24px.png");
            this.imageList1.Images.SetKeyName(2, "steam_24px.png");
            this.imageList1.Images.SetKeyName(3, "msstore_24px.png");
            // 
            // labelTip
            // 
            this.labelTip.AutoSize = true;
            this.labelTip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTip.ForeColor = System.Drawing.Color.DimGray;
            this.labelTip.Location = new System.Drawing.Point(8, 443);
            this.labelTip.Name = "labelTip";
            this.labelTip.Size = new System.Drawing.Size(243, 13);
            this.labelTip.TabIndex = 43;
            this.labelTip.Text = "Tip: Right-click on a game profile for more options.";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.White;
            this.toolStrip1.GripMargin = new System.Windows.Forms.Padding(0);
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonAddGame});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(760, 37);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonAddGame
            // 
            this.toolStripButtonAddGame.BackColor = System.Drawing.Color.White;
            this.toolStripButtonAddGame.Image = global::Fo76ini.Properties.Resources.plus_24;
            this.toolStripButtonAddGame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButtonAddGame.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAddGame.Name = "toolStripButtonAddGame";
            this.toolStripButtonAddGame.Padding = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.toolStripButtonAddGame.Size = new System.Drawing.Size(90, 24);
            this.toolStripButtonAddGame.Text = "Add game";
            this.toolStripButtonAddGame.Click += new System.EventHandler(this.toolStripButtonAddGame_Click);
            // 
            // tabPageNexusMods
            // 
            this.tabPageNexusMods.Controls.Add(this.panel2);
            this.tabPageNexusMods.Controls.Add(this.panel3);
            this.tabPageNexusMods.Location = new System.Drawing.Point(4, 22);
            this.tabPageNexusMods.Name = "tabPageNexusMods";
            this.tabPageNexusMods.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageNexusMods.Size = new System.Drawing.Size(766, 508);
            this.tabPageNexusMods.TabIndex = 2;
            this.tabPageNexusMods.Text = "NexusMods";
            this.tabPageNexusMods.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.SystemColors.Window;
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
            this.panel2.Location = new System.Drawing.Point(0, 169);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 339);
            this.panel2.TabIndex = 78;
            // 
            // labelAPIKey
            // 
            this.labelAPIKey.AutoSize = true;
            this.labelAPIKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAPIKey.Location = new System.Drawing.Point(6, 239);
            this.labelAPIKey.Name = "labelAPIKey";
            this.labelAPIKey.Size = new System.Drawing.Size(62, 16);
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
            this.checkBoxShowAPIKey.CheckedChanged += new System.EventHandler(this.checkBoxShowAPIKey_CheckedChanged);
            // 
            // textBoxAPIKey
            // 
            this.textBoxAPIKey.Location = new System.Drawing.Point(20, 288);
            this.textBoxAPIKey.Name = "textBoxAPIKey";
            this.textBoxAPIKey.Size = new System.Drawing.Size(726, 20);
            this.textBoxAPIKey.TabIndex = 107;
            this.textBoxAPIKey.UseSystemPasswordChar = true;
            this.textBoxAPIKey.TextChanged += new System.EventHandler(this.textBoxAPIKey_TextChanged);
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
            this.buttonNMLogin.Click += new System.EventHandler(this.buttonNMLogin_Click);
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
            this.buttonNWDeleteCache.Click += new System.EventHandler(this.buttonNWDeleteCache_Click);
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
            this.buttonNWLogout.Click += new System.EventHandler(this.buttonNWLogout_Click);
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
            this.checkBoxNMDownloadThumbnails.CheckedChanged += new System.EventHandler(this.checkBoxNMDownloadThumbnails_CheckedChanged);
            // 
            // labelNMOptions
            // 
            this.labelNMOptions.AutoSize = true;
            this.labelNMOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNMOptions.Location = new System.Drawing.Point(6, 155);
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
            this.checkBoxNMUpdateProfile.Location = new System.Drawing.Point(20, 177);
            this.checkBoxNMUpdateProfile.Name = "checkBoxNMUpdateProfile";
            this.checkBoxNMUpdateProfile.Size = new System.Drawing.Size(156, 17);
            this.checkBoxNMUpdateProfile.TabIndex = 100;
            this.checkBoxNMUpdateProfile.Text = "Update profile automatically";
            this.checkBoxNMUpdateProfile.UseVisualStyleBackColor = true;
            this.checkBoxNMUpdateProfile.CheckedChanged += new System.EventHandler(this.checkBoxNMUpdateProfile_CheckedChanged);
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
            this.buttonNMUpdateProfile.Click += new System.EventHandler(this.buttonNMUpdateProfile_Click);
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
            this.panel3.Controls.Add(this.labelNMDailyRateLimitReset);
            this.panel3.Controls.Add(this.labelNMMembership);
            this.panel3.Controls.Add(this.labelNMDescLimitReset);
            this.panel3.Controls.Add(this.labelNMDescDailyRateLimit);
            this.panel3.Controls.Add(this.labelNMDailyRateLimit);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(766, 170);
            this.panel3.TabIndex = 77;
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
            this.labelNMDailyRateLimitReset.Location = new System.Drawing.Point(585, 107);
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
            this.labelNMDescLimitReset.Location = new System.Drawing.Point(457, 107);
            this.labelNMDescLimitReset.Name = "labelNMDescLimitReset";
            this.labelNMDescLimitReset.Size = new System.Drawing.Size(57, 13);
            this.labelNMDescLimitReset.TabIndex = 71;
            this.labelNMDescLimitReset.Text = "Limit reset:";
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
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 20000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
            // 
            // openFileDialogGamePath
            // 
            this.openFileDialogGamePath.FileName = "Fallout76.exe";
            this.openFileDialogGamePath.Filter = "Executable|*.exe";
            this.openFileDialogGamePath.FilterIndex = 2;
            // 
            // backgroundWorkerDownloadLanguages
            // 
            this.backgroundWorkerDownloadLanguages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDownloadLanguages_DoWork);
            // 
            // backgroundWorkerRetrieveProfileInfo
            // 
            this.backgroundWorkerRetrieveProfileInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRetrieveProfileInfo_DoWork);
            // 
            // backgroundWorkerSSOLogin
            // 
            this.backgroundWorkerSSOLogin.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerSSOLogin_DoWork);
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
            this.buttonNMLoginManually.Click += new System.EventHandler(this.buttonNMLoginManually_Click);
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
            this.linkLabelAPIKeyHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAPIKeyHelp_LinkClicked);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 16);
            this.label1.TabIndex = 106;
            this.label1.Text = "Actions";
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 561);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPageGeneral.ResumeLayout(false);
            this.groupBoxActions.ResumeLayout(false);
            this.groupBoxActions.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxNuclearWinterMode.ResumeLayout(false);
            this.groupBoxNuclearWinterMode.PerformLayout();
            this.groupBoxBehavior.ResumeLayout(false);
            this.groupBoxBehavior.PerformLayout();
            this.groupBoxLocalization.ResumeLayout(false);
            this.groupBoxLocalization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerDownloadLanguages)).EndInit();
            this.tabPageGameProfiles.ResumeLayout(false);
            this.tabPageGameProfiles.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxSettings.ResumeLayout(false);
            this.panelSettings.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxLaunchOptions.ResumeLayout(false);
            this.groupBoxLaunchOptions.PerformLayout();
            this.groupBoxGameLocation.ResumeLayout(false);
            this.groupBoxGameLocation.PerformLayout();
            this.groupBoxGameEdition.ResumeLayout(false);
            this.groupBoxGameEdition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUnknown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMSStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSteam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBethesdaNetPTS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBethesdaNet)).EndInit();
            this.groupBoxGame.ResumeLayout(false);
            this.contextMenuStripGame.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPageNexusMods.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNMProfilePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAPIKeyHelp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageGameProfiles;
        private System.Windows.Forms.TabPage tabPageNexusMods;
        private System.Windows.Forms.GroupBox groupBoxLocalization;
        private System.Windows.Forms.Button buttonRefreshLanguage;
        private System.Windows.Forms.PictureBox pictureBoxSpinnerDownloadLanguages;
        public System.Windows.Forms.Label labelOutdatedLanguage;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.Button buttonDownloadLanguages;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.GroupBox groupBoxBehavior;
        private System.Windows.Forms.CheckBox checkBoxPlayNotificationSound;
        private System.Windows.Forms.CheckBox checkBoxIgnoreUpdates;
        private System.Windows.Forms.CheckBox checkBoxQuitOnGameLaunch;
        private System.Windows.Forms.CheckBox checkBoxAutoApply;
        private System.Windows.Forms.GroupBox groupBoxNuclearWinterMode;
        private System.Windows.Forms.CheckBox checkBoxNWAutoDeployMods;
        private System.Windows.Forms.Label labelNWmodoptions;
        private System.Windows.Forms.Label labelNWdlloptions;
        private System.Windows.Forms.CheckBox checkBoxNWAutoDisableMods;
        private System.Windows.Forms.CheckBox checkBoxNWRenameDLL;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTip;
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
        private System.Windows.Forms.GroupBox groupBoxGameLocation;
        private System.Windows.Forms.Button buttonAutoDetect;
        private System.Windows.Forms.TextBox textBoxGamePath;
        private System.Windows.Forms.Button buttonPickGamePath;
        private System.Windows.Forms.GroupBox groupBoxGameEdition;
        private System.Windows.Forms.PictureBox pictureBoxMSStore;
        private System.Windows.Forms.PictureBox pictureBoxSteam;
        private System.Windows.Forms.PictureBox pictureBoxBethesdaNetPTS;
        private System.Windows.Forms.PictureBox pictureBoxBethesdaNet;
        private System.Windows.Forms.RadioButton radioButtonEditionMSStore;
        private System.Windows.Forms.RadioButton radioButtonEditionBethesdaNetPTS;
        private System.Windows.Forms.RadioButton radioButtonEditionSteam;
        private System.Windows.Forms.RadioButton radioButtonEditionBethesdaNet;
        private System.Windows.Forms.ListView listViewGameInstances;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonAddGame;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelNMNotLoggedIn;
        private System.Windows.Forms.Label labelNMUserID;
        private System.Windows.Forms.Label labelNMDescUserID;
        private System.Windows.Forms.Label labelNMHourlyRateLimit;
        private System.Windows.Forms.Label labelNMDescHourlyRateLimit;
        private System.Windows.Forms.PictureBox pictureBoxNMProfilePicture;
        private System.Windows.Forms.Label labelNMUserName;
        private System.Windows.Forms.Label labelNMDescMembership;
        private System.Windows.Forms.Label labelNMDailyRateLimitReset;
        private System.Windows.Forms.Label labelNMMembership;
        private System.Windows.Forms.Label labelNMDescLimitReset;
        private System.Windows.Forms.Label labelNMDescDailyRateLimit;
        private System.Windows.Forms.Label labelNMDailyRateLimit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonNWDeleteCache;
        private System.Windows.Forms.Button buttonNWLogout;
        private System.Windows.Forms.CheckBox checkBoxNMDownloadThumbnails;
        private System.Windows.Forms.Label labelNMOptions;
        private System.Windows.Forms.CheckBox checkBoxNMUpdateProfile;
        private System.Windows.Forms.Button buttonNMUpdateProfile;
        public System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.OpenFileDialog openFileDialogGamePath;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripGame;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem launchGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem renameGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeGameToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDownloadLanguages;
        private System.Windows.Forms.GroupBox groupBoxSettings;
        private System.Windows.Forms.GroupBox groupBoxGame;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.CheckBox checkBoxReadOnly;
        private System.ComponentModel.BackgroundWorker backgroundWorkerRetrieveProfileInfo;
        private System.Windows.Forms.RadioButton radioButtonEditionUnknown;
        private System.Windows.Forms.PictureBox pictureBoxUnknown;
        private System.Windows.Forms.GroupBox groupBoxActions;
        private System.Windows.Forms.LinkLabel linkLabelEnableDangerZone;
        private System.Windows.Forms.Button buttonNMLogin;
        private System.ComponentModel.BackgroundWorker backgroundWorkerSSOLogin;
        private System.Windows.Forms.Label labelAPIKey;
        private System.Windows.Forms.CheckBox checkBoxShowAPIKey;
        private System.Windows.Forms.TextBox textBoxAPIKey;
        private System.Windows.Forms.Button buttonNMLoginManually;
        private System.Windows.Forms.PictureBox pictureBoxAPIKeyHelp;
        private System.Windows.Forms.LinkLabel linkLabelAPIKeyHelp;
        private System.Windows.Forms.Label label1;
    }
}