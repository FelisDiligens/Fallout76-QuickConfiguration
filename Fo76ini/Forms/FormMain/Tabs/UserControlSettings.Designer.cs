namespace Fo76ini.Forms.FormMain.Tabs
{
    partial class UserControlSettings
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
            this.backgroundWorkerDownloadLanguages = new System.ComponentModel.BackgroundWorker();
            this.openFileDialogArchiveTwoPath = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogSevenZipPath = new System.Windows.Forms.OpenFileDialog();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.labelSettingsTitle = new System.Windows.Forms.Label();
            this.buttonDownloadLanguages = new System.Windows.Forms.Button();
            this.pictureBoxSpinnerDownloadLanguages = new System.Windows.Forms.PictureBox();
            this.labelSettingsLocalization = new System.Windows.Forms.Label();
            this.buttonRefreshLanguage = new System.Windows.Forms.Button();
            this.checkBoxAutoApply = new System.Windows.Forms.CheckBox();
            this.checkBoxQuitOnGameLaunch = new System.Windows.Forms.CheckBox();
            this.labelOutdatedLanguage = new System.Windows.Forms.Label();
            this.labelSevenZipPath = new System.Windows.Forms.Label();
            this.checkBoxIgnoreUpdates = new System.Windows.Forms.CheckBox();
            this.buttonPickArchiveTwoPath = new System.Windows.Forms.Button();
            this.labelSettingsBehavior = new System.Windows.Forms.Label();
            this.labelArchiveTwoPath = new System.Windows.Forms.Label();
            this.checkBoxPlayNotificationSound = new System.Windows.Forms.CheckBox();
            this.textBoxSevenZipPath = new System.Windows.Forms.TextBox();
            this.labelSettingsUI = new System.Windows.Forms.Label();
            this.textBoxArchiveTwoPath = new System.Windows.Forms.TextBox();
            this.checkBoxShowWhatsNew = new System.Windows.Forms.CheckBox();
            this.buttonPickSevenZipPath = new System.Windows.Forms.Button();
            this.checkBoxReadOnly = new System.Windows.Forms.CheckBox();
            this.labelSettingsPrograms = new System.Windows.Forms.Label();
            this.labelSettingsModManager = new System.Windows.Forms.Label();
            this.labelSettingsOptions = new System.Windows.Forms.Label();
            this.buttonPickDownloadsPath = new System.Windows.Forms.Button();
            this.checkBoxNWRenameDLL = new System.Windows.Forms.CheckBox();
            this.checkBoxHandleNXMLinks = new System.Windows.Forms.CheckBox();
            this.checkBoxNWAutoDisableMods = new System.Windows.Forms.CheckBox();
            this.labelDownloadsPath = new System.Windows.Forms.Label();
            this.labelNWdlloptions = new System.Windows.Forms.Label();
            this.labelSettingsPaths = new System.Windows.Forms.Label();
            this.labelNWmodoptions = new System.Windows.Forms.Label();
            this.textBoxDownloadsPath = new System.Windows.Forms.TextBox();
            this.checkBoxNWAutoDeployMods = new System.Windows.Forms.CheckBox();
            this.labelSettingsNuclearWinterOptions = new System.Windows.Forms.Label();
            this.labelToggleNW = new System.Windows.Forms.Label();
            this.panelSettingsLocalization = new System.Windows.Forms.Panel();
            this.panelSettingsBehavior = new System.Windows.Forms.Panel();
            this.panelSettingsUI = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelSettingsProfiles = new System.Windows.Forms.Label();
            this.labelSettingsProfileNotice = new System.Windows.Forms.Label();
            this.linkLabelOpenProfileEditor = new System.Windows.Forms.LinkLabel();
            this.buttonNWMode = new Fo76ini.Controls.StyledButton();
            this.toolTip = new Fo76ini.Controls.CustomToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerDownloadLanguages)).BeginInit();
            this.panelSettingsLocalization.SuspendLayout();
            this.panelSettingsBehavior.SuspendLayout();
            this.panelSettingsUI.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // backgroundWorkerDownloadLanguages
            // 
            this.backgroundWorkerDownloadLanguages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDownloadLanguages_DoWork);
            this.backgroundWorkerDownloadLanguages.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDownloadLanguages_RunWorkerCompleted);
            // 
            // openFileDialogArchiveTwoPath
            // 
            this.openFileDialogArchiveTwoPath.FileName = "Archive2.exe";
            this.openFileDialogArchiveTwoPath.Filter = "Executable|*.exe";
            this.openFileDialogArchiveTwoPath.FilterIndex = 2;
            // 
            // openFileDialogSevenZipPath
            // 
            this.openFileDialogSevenZipPath.FileName = "7z.exe";
            this.openFileDialogSevenZipPath.Filter = "Executable|*.exe";
            this.openFileDialogSevenZipPath.FilterIndex = 2;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(15, 38);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(317, 21);
            this.comboBoxLanguage.TabIndex = 0;
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(12, 22);
            this.labelLanguage.Name = "labelLanguage";
            this.labelLanguage.Size = new System.Drawing.Size(58, 13);
            this.labelLanguage.TabIndex = 16;
            this.labelLanguage.Text = "Language:";
            // 
            // labelSettingsTitle
            // 
            this.labelSettingsTitle.AutoSize = true;
            this.labelSettingsTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsTitle.Location = new System.Drawing.Point(10, 15);
            this.labelSettingsTitle.Name = "labelSettingsTitle";
            this.labelSettingsTitle.Size = new System.Drawing.Size(136, 30);
            this.labelSettingsTitle.TabIndex = 73;
            this.labelSettingsTitle.Text = "App Settings";
            // 
            // buttonDownloadLanguages
            // 
            this.buttonDownloadLanguages.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonDownloadLanguages.FlatAppearance.BorderSize = 0;
            this.buttonDownloadLanguages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDownloadLanguages.Image = global::Fo76ini.Properties.Resources.download_2_24;
            this.buttonDownloadLanguages.Location = new System.Drawing.Point(262, 65);
            this.buttonDownloadLanguages.Name = "buttonDownloadLanguages";
            this.buttonDownloadLanguages.Size = new System.Drawing.Size(32, 32);
            this.buttonDownloadLanguages.TabIndex = 1;
            this.buttonDownloadLanguages.UseVisualStyleBackColor = true;
            this.buttonDownloadLanguages.Click += new System.EventHandler(this.buttonDownloadLanguages_Click);
            // 
            // pictureBoxSpinnerDownloadLanguages
            // 
            this.pictureBoxSpinnerDownloadLanguages.Image = global::Fo76ini.Properties.Resources.Spinner_24;
            this.pictureBoxSpinnerDownloadLanguages.Location = new System.Drawing.Point(231, 69);
            this.pictureBoxSpinnerDownloadLanguages.Name = "pictureBoxSpinnerDownloadLanguages";
            this.pictureBoxSpinnerDownloadLanguages.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxSpinnerDownloadLanguages.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSpinnerDownloadLanguages.TabIndex = 40;
            this.pictureBoxSpinnerDownloadLanguages.TabStop = false;
            this.pictureBoxSpinnerDownloadLanguages.Visible = false;
            // 
            // labelSettingsLocalization
            // 
            this.labelSettingsLocalization.AutoSize = true;
            this.labelSettingsLocalization.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsLocalization.Location = new System.Drawing.Point(12, 0);
            this.labelSettingsLocalization.Margin = new System.Windows.Forms.Padding(3, 25, 3, 5);
            this.labelSettingsLocalization.Name = "labelSettingsLocalization";
            this.labelSettingsLocalization.Size = new System.Drawing.Size(78, 17);
            this.labelSettingsLocalization.TabIndex = 75;
            this.labelSettingsLocalization.Text = "Localization";
            // 
            // buttonRefreshLanguage
            // 
            this.buttonRefreshLanguage.BackColor = System.Drawing.Color.Transparent;
            this.buttonRefreshLanguage.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonRefreshLanguage.FlatAppearance.BorderSize = 0;
            this.buttonRefreshLanguage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefreshLanguage.Image = global::Fo76ini.Properties.Resources.available_updates;
            this.buttonRefreshLanguage.Location = new System.Drawing.Point(300, 65);
            this.buttonRefreshLanguage.Name = "buttonRefreshLanguage";
            this.buttonRefreshLanguage.Size = new System.Drawing.Size(32, 32);
            this.buttonRefreshLanguage.TabIndex = 2;
            this.buttonRefreshLanguage.UseVisualStyleBackColor = false;
            this.buttonRefreshLanguage.Click += new System.EventHandler(this.buttonRefreshLanguage_Click);
            // 
            // checkBoxAutoApply
            // 
            this.checkBoxAutoApply.AutoSize = true;
            this.checkBoxAutoApply.Location = new System.Drawing.Point(15, 60);
            this.checkBoxAutoApply.Name = "checkBoxAutoApply";
            this.checkBoxAutoApply.Size = new System.Drawing.Size(351, 17);
            this.checkBoxAutoApply.TabIndex = 11;
            this.checkBoxAutoApply.Text = "Automatically apply changes when tool is closed or game is launched";
            this.checkBoxAutoApply.UseVisualStyleBackColor = true;
            // 
            // checkBoxQuitOnGameLaunch
            // 
            this.checkBoxQuitOnGameLaunch.AutoSize = true;
            this.checkBoxQuitOnGameLaunch.Location = new System.Drawing.Point(15, 37);
            this.checkBoxQuitOnGameLaunch.Name = "checkBoxQuitOnGameLaunch";
            this.checkBoxQuitOnGameLaunch.Size = new System.Drawing.Size(223, 17);
            this.checkBoxQuitOnGameLaunch.TabIndex = 10;
            this.checkBoxQuitOnGameLaunch.Text = "Close the tool when the game is launched";
            this.checkBoxQuitOnGameLaunch.UseVisualStyleBackColor = true;
            // 
            // labelOutdatedLanguage
            // 
            this.labelOutdatedLanguage.ForeColor = System.Drawing.Color.Firebrick;
            this.labelOutdatedLanguage.Location = new System.Drawing.Point(13, 65);
            this.labelOutdatedLanguage.Name = "labelOutdatedLanguage";
            this.labelOutdatedLanguage.Size = new System.Drawing.Size(212, 51);
            this.labelOutdatedLanguage.TabIndex = 21;
            this.labelOutdatedLanguage.Text = "This translation is out-dated.\r\nSome elements might not be translated yet.";
            // 
            // labelSevenZipPath
            // 
            this.labelSevenZipPath.AutoSize = true;
            this.labelSevenZipPath.Location = new System.Drawing.Point(12, 151);
            this.labelSevenZipPath.Name = "labelSevenZipPath";
            this.labelSevenZipPath.Size = new System.Drawing.Size(65, 13);
            this.labelSevenZipPath.TabIndex = 42;
            this.labelSevenZipPath.Text = "7z.exe path:";
            // 
            // checkBoxIgnoreUpdates
            // 
            this.checkBoxIgnoreUpdates.AutoSize = true;
            this.checkBoxIgnoreUpdates.Location = new System.Drawing.Point(15, 84);
            this.checkBoxIgnoreUpdates.Name = "checkBoxIgnoreUpdates";
            this.checkBoxIgnoreUpdates.Size = new System.Drawing.Size(140, 17);
            this.checkBoxIgnoreUpdates.TabIndex = 12;
            this.checkBoxIgnoreUpdates.Text = "Don\'t check for updates";
            this.checkBoxIgnoreUpdates.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreUpdates.CheckedChanged += new System.EventHandler(this.checkBoxIgnoreUpdates_CheckedChanged);
            // 
            // buttonPickArchiveTwoPath
            // 
            this.buttonPickArchiveTwoPath.Location = new System.Drawing.Point(358, 117);
            this.buttonPickArchiveTwoPath.Name = "buttonPickArchiveTwoPath";
            this.buttonPickArchiveTwoPath.Size = new System.Drawing.Size(28, 23);
            this.buttonPickArchiveTwoPath.TabIndex = 43;
            this.buttonPickArchiveTwoPath.Text = "...";
            this.buttonPickArchiveTwoPath.UseVisualStyleBackColor = true;
            this.buttonPickArchiveTwoPath.Click += new System.EventHandler(this.buttonPickArchiveTwoPath_Click);
            // 
            // labelSettingsBehavior
            // 
            this.labelSettingsBehavior.AutoSize = true;
            this.labelSettingsBehavior.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsBehavior.Location = new System.Drawing.Point(12, 12);
            this.labelSettingsBehavior.Margin = new System.Windows.Forms.Padding(3, 25, 3, 5);
            this.labelSettingsBehavior.Name = "labelSettingsBehavior";
            this.labelSettingsBehavior.Size = new System.Drawing.Size(61, 17);
            this.labelSettingsBehavior.TabIndex = 76;
            this.labelSettingsBehavior.Text = "Behavior";
            // 
            // labelArchiveTwoPath
            // 
            this.labelArchiveTwoPath.AutoSize = true;
            this.labelArchiveTwoPath.Location = new System.Drawing.Point(12, 122);
            this.labelArchiveTwoPath.Name = "labelArchiveTwoPath";
            this.labelArchiveTwoPath.Size = new System.Drawing.Size(96, 13);
            this.labelArchiveTwoPath.TabIndex = 41;
            this.labelArchiveTwoPath.Text = "Archive2.exe path:";
            // 
            // checkBoxPlayNotificationSound
            // 
            this.checkBoxPlayNotificationSound.AutoSize = true;
            this.checkBoxPlayNotificationSound.Location = new System.Drawing.Point(15, 107);
            this.checkBoxPlayNotificationSound.Name = "checkBoxPlayNotificationSound";
            this.checkBoxPlayNotificationSound.Size = new System.Drawing.Size(132, 17);
            this.checkBoxPlayNotificationSound.TabIndex = 13;
            this.checkBoxPlayNotificationSound.Text = "Play notification sound";
            this.checkBoxPlayNotificationSound.UseVisualStyleBackColor = true;
            // 
            // textBoxSevenZipPath
            // 
            this.textBoxSevenZipPath.Location = new System.Drawing.Point(118, 148);
            this.textBoxSevenZipPath.Name = "textBoxSevenZipPath";
            this.textBoxSevenZipPath.Size = new System.Drawing.Size(234, 20);
            this.textBoxSevenZipPath.TabIndex = 44;
            this.textBoxSevenZipPath.TextChanged += new System.EventHandler(this.textBoxSevenZipPath_TextChanged);
            // 
            // labelSettingsUI
            // 
            this.labelSettingsUI.AutoSize = true;
            this.labelSettingsUI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsUI.Location = new System.Drawing.Point(12, 12);
            this.labelSettingsUI.Margin = new System.Windows.Forms.Padding(3, 25, 3, 5);
            this.labelSettingsUI.Name = "labelSettingsUI";
            this.labelSettingsUI.Size = new System.Drawing.Size(92, 17);
            this.labelSettingsUI.TabIndex = 77;
            this.labelSettingsUI.Text = "User Interface";
            // 
            // textBoxArchiveTwoPath
            // 
            this.textBoxArchiveTwoPath.Location = new System.Drawing.Point(118, 119);
            this.textBoxArchiveTwoPath.Name = "textBoxArchiveTwoPath";
            this.textBoxArchiveTwoPath.Size = new System.Drawing.Size(234, 20);
            this.textBoxArchiveTwoPath.TabIndex = 42;
            this.textBoxArchiveTwoPath.TextChanged += new System.EventHandler(this.textBoxArchiveTwoPath_TextChanged);
            // 
            // checkBoxShowWhatsNew
            // 
            this.checkBoxShowWhatsNew.AutoSize = true;
            this.checkBoxShowWhatsNew.Location = new System.Drawing.Point(15, 37);
            this.checkBoxShowWhatsNew.Name = "checkBoxShowWhatsNew";
            this.checkBoxShowWhatsNew.Size = new System.Drawing.Size(214, 17);
            this.checkBoxShowWhatsNew.TabIndex = 20;
            this.checkBoxShowWhatsNew.Text = "Show \"What\'s new\" on the home page.";
            this.checkBoxShowWhatsNew.UseVisualStyleBackColor = true;
            // 
            // buttonPickSevenZipPath
            // 
            this.buttonPickSevenZipPath.Location = new System.Drawing.Point(358, 146);
            this.buttonPickSevenZipPath.Name = "buttonPickSevenZipPath";
            this.buttonPickSevenZipPath.Size = new System.Drawing.Size(28, 23);
            this.buttonPickSevenZipPath.TabIndex = 45;
            this.buttonPickSevenZipPath.Text = "...";
            this.buttonPickSevenZipPath.UseVisualStyleBackColor = true;
            this.buttonPickSevenZipPath.Click += new System.EventHandler(this.buttonPickSevenZipPath_Click);
            // 
            // checkBoxReadOnly
            // 
            this.checkBoxReadOnly.AutoSize = true;
            this.checkBoxReadOnly.Location = new System.Drawing.Point(15, 44);
            this.checkBoxReadOnly.Name = "checkBoxReadOnly";
            this.checkBoxReadOnly.Size = new System.Drawing.Size(140, 17);
            this.checkBoxReadOnly.TabIndex = 30;
            this.checkBoxReadOnly.Text = "Make *.ini files read-only";
            this.checkBoxReadOnly.UseVisualStyleBackColor = true;
            // 
            // labelSettingsPrograms
            // 
            this.labelSettingsPrograms.AutoSize = true;
            this.labelSettingsPrograms.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsPrograms.Location = new System.Drawing.Point(12, 99);
            this.labelSettingsPrograms.Name = "labelSettingsPrograms";
            this.labelSettingsPrograms.Size = new System.Drawing.Size(58, 15);
            this.labelSettingsPrograms.TabIndex = 26;
            this.labelSettingsPrograms.Text = "Programs";
            // 
            // labelSettingsModManager
            // 
            this.labelSettingsModManager.AutoSize = true;
            this.labelSettingsModManager.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsModManager.Location = new System.Drawing.Point(12, 42);
            this.labelSettingsModManager.Name = "labelSettingsModManager";
            this.labelSettingsModManager.Size = new System.Drawing.Size(82, 15);
            this.labelSettingsModManager.TabIndex = 47;
            this.labelSettingsModManager.Text = "Mod manager";
            // 
            // labelSettingsOptions
            // 
            this.labelSettingsOptions.AutoSize = true;
            this.labelSettingsOptions.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsOptions.Location = new System.Drawing.Point(12, 19);
            this.labelSettingsOptions.Margin = new System.Windows.Forms.Padding(3, 25, 3, 5);
            this.labelSettingsOptions.Name = "labelSettingsOptions";
            this.labelSettingsOptions.Size = new System.Drawing.Size(56, 17);
            this.labelSettingsOptions.TabIndex = 78;
            this.labelSettingsOptions.Text = "Options";
            // 
            // buttonPickDownloadsPath
            // 
            this.buttonPickDownloadsPath.Location = new System.Drawing.Point(358, 62);
            this.buttonPickDownloadsPath.Name = "buttonPickDownloadsPath";
            this.buttonPickDownloadsPath.Size = new System.Drawing.Size(28, 23);
            this.buttonPickDownloadsPath.TabIndex = 41;
            this.buttonPickDownloadsPath.Text = "...";
            this.buttonPickDownloadsPath.UseVisualStyleBackColor = true;
            this.buttonPickDownloadsPath.Click += new System.EventHandler(this.buttonPickDownloadsPath_Click);
            // 
            // checkBoxNWRenameDLL
            // 
            this.checkBoxNWRenameDLL.AutoSize = true;
            this.checkBoxNWRenameDLL.Location = new System.Drawing.Point(17, 127);
            this.checkBoxNWRenameDLL.Name = "checkBoxNWRenameDLL";
            this.checkBoxNWRenameDLL.Size = new System.Drawing.Size(140, 17);
            this.checkBoxNWRenameDLL.TabIndex = 51;
            this.checkBoxNWRenameDLL.Text = "Rename added *.dll files";
            this.checkBoxNWRenameDLL.UseVisualStyleBackColor = true;
            // 
            // checkBoxHandleNXMLinks
            // 
            this.checkBoxHandleNXMLinks.AutoSize = true;
            this.checkBoxHandleNXMLinks.Location = new System.Drawing.Point(15, 67);
            this.checkBoxHandleNXMLinks.Name = "checkBoxHandleNXMLinks";
            this.checkBoxHandleNXMLinks.Size = new System.Drawing.Size(248, 17);
            this.checkBoxHandleNXMLinks.TabIndex = 31;
            this.checkBoxHandleNXMLinks.Text = "Associate with \"Mod Manager Download\" links";
            this.checkBoxHandleNXMLinks.UseVisualStyleBackColor = true;
            this.checkBoxHandleNXMLinks.CheckedChanged += new System.EventHandler(this.checkBoxHandleNXMLinks_CheckedChanged);
            // 
            // checkBoxNWAutoDisableMods
            // 
            this.checkBoxNWAutoDisableMods.AutoSize = true;
            this.checkBoxNWAutoDisableMods.Location = new System.Drawing.Point(17, 180);
            this.checkBoxNWAutoDisableMods.Name = "checkBoxNWAutoDisableMods";
            this.checkBoxNWAutoDisableMods.Size = new System.Drawing.Size(224, 17);
            this.checkBoxNWAutoDisableMods.TabIndex = 52;
            this.checkBoxNWAutoDisableMods.Text = "Automatically remove mods upon enabling";
            this.checkBoxNWAutoDisableMods.UseVisualStyleBackColor = true;
            // 
            // labelDownloadsPath
            // 
            this.labelDownloadsPath.AutoSize = true;
            this.labelDownloadsPath.Location = new System.Drawing.Point(12, 67);
            this.labelDownloadsPath.Name = "labelDownloadsPath";
            this.labelDownloadsPath.Size = new System.Drawing.Size(92, 13);
            this.labelDownloadsPath.TabIndex = 48;
            this.labelDownloadsPath.Text = "Downloads folder:";
            // 
            // labelNWdlloptions
            // 
            this.labelNWdlloptions.AutoSize = true;
            this.labelNWdlloptions.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNWdlloptions.Location = new System.Drawing.Point(14, 109);
            this.labelNWdlloptions.Name = "labelNWdlloptions";
            this.labelNWdlloptions.Size = new System.Drawing.Size(74, 15);
            this.labelNWdlloptions.TabIndex = 23;
            this.labelNWdlloptions.Text = "*.dll options:";
            // 
            // labelSettingsPaths
            // 
            this.labelSettingsPaths.AutoSize = true;
            this.labelSettingsPaths.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsPaths.Location = new System.Drawing.Point(12, 20);
            this.labelSettingsPaths.Margin = new System.Windows.Forms.Padding(3, 25, 3, 5);
            this.labelSettingsPaths.Name = "labelSettingsPaths";
            this.labelSettingsPaths.Size = new System.Drawing.Size(42, 17);
            this.labelSettingsPaths.TabIndex = 79;
            this.labelSettingsPaths.Text = "Paths";
            // 
            // labelNWmodoptions
            // 
            this.labelNWmodoptions.AutoSize = true;
            this.labelNWmodoptions.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNWmodoptions.Location = new System.Drawing.Point(14, 162);
            this.labelNWmodoptions.Name = "labelNWmodoptions";
            this.labelNWmodoptions.Size = new System.Drawing.Size(78, 15);
            this.labelNWmodoptions.TabIndex = 24;
            this.labelNWmodoptions.Text = "Mod options:";
            // 
            // textBoxDownloadsPath
            // 
            this.textBoxDownloadsPath.Location = new System.Drawing.Point(118, 64);
            this.textBoxDownloadsPath.Name = "textBoxDownloadsPath";
            this.textBoxDownloadsPath.Size = new System.Drawing.Size(234, 20);
            this.textBoxDownloadsPath.TabIndex = 40;
            this.textBoxDownloadsPath.TextChanged += new System.EventHandler(this.textBoxDownloadsPath_TextChanged);
            // 
            // checkBoxNWAutoDeployMods
            // 
            this.checkBoxNWAutoDeployMods.AutoSize = true;
            this.checkBoxNWAutoDeployMods.Location = new System.Drawing.Point(17, 203);
            this.checkBoxNWAutoDeployMods.Name = "checkBoxNWAutoDeployMods";
            this.checkBoxNWAutoDeployMods.Size = new System.Drawing.Size(221, 17);
            this.checkBoxNWAutoDeployMods.TabIndex = 53;
            this.checkBoxNWAutoDeployMods.Text = "Automatically deploy mods upon disabling";
            this.checkBoxNWAutoDeployMods.UseVisualStyleBackColor = true;
            // 
            // labelSettingsNuclearWinterOptions
            // 
            this.labelSettingsNuclearWinterOptions.AutoSize = true;
            this.labelSettingsNuclearWinterOptions.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsNuclearWinterOptions.Location = new System.Drawing.Point(13, 13);
            this.labelSettingsNuclearWinterOptions.Margin = new System.Windows.Forms.Padding(3, 25, 3, 5);
            this.labelSettingsNuclearWinterOptions.Name = "labelSettingsNuclearWinterOptions";
            this.labelSettingsNuclearWinterOptions.Size = new System.Drawing.Size(229, 17);
            this.labelSettingsNuclearWinterOptions.TabIndex = 80;
            this.labelSettingsNuclearWinterOptions.Text = "Nuclear Winter options (deprecated)";
            // 
            // labelToggleNW
            // 
            this.labelToggleNW.AutoSize = true;
            this.labelToggleNW.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelToggleNW.Location = new System.Drawing.Point(13, 35);
            this.labelToggleNW.Name = "labelToggleNW";
            this.labelToggleNW.Size = new System.Drawing.Size(80, 15);
            this.labelToggleNW.TabIndex = 27;
            this.labelToggleNW.Text = "Toggle mode:";
            // 
            // panelSettingsLocalization
            // 
            this.panelSettingsLocalization.Controls.Add(this.labelSettingsLocalization);
            this.panelSettingsLocalization.Controls.Add(this.comboBoxLanguage);
            this.panelSettingsLocalization.Controls.Add(this.labelLanguage);
            this.panelSettingsLocalization.Controls.Add(this.buttonDownloadLanguages);
            this.panelSettingsLocalization.Controls.Add(this.pictureBoxSpinnerDownloadLanguages);
            this.panelSettingsLocalization.Controls.Add(this.buttonRefreshLanguage);
            this.panelSettingsLocalization.Controls.Add(this.labelOutdatedLanguage);
            this.panelSettingsLocalization.Location = new System.Drawing.Point(0, 56);
            this.panelSettingsLocalization.Name = "panelSettingsLocalization";
            this.panelSettingsLocalization.Size = new System.Drawing.Size(403, 103);
            this.panelSettingsLocalization.TabIndex = 82;
            // 
            // panelSettingsBehavior
            // 
            this.panelSettingsBehavior.Controls.Add(this.labelSettingsBehavior);
            this.panelSettingsBehavior.Controls.Add(this.checkBoxAutoApply);
            this.panelSettingsBehavior.Controls.Add(this.checkBoxQuitOnGameLaunch);
            this.panelSettingsBehavior.Controls.Add(this.checkBoxIgnoreUpdates);
            this.panelSettingsBehavior.Controls.Add(this.checkBoxPlayNotificationSound);
            this.panelSettingsBehavior.Location = new System.Drawing.Point(0, 165);
            this.panelSettingsBehavior.Name = "panelSettingsBehavior";
            this.panelSettingsBehavior.Size = new System.Drawing.Size(403, 134);
            this.panelSettingsBehavior.TabIndex = 83;
            // 
            // panelSettingsUI
            // 
            this.panelSettingsUI.Controls.Add(this.labelSettingsUI);
            this.panelSettingsUI.Controls.Add(this.checkBoxShowWhatsNew);
            this.panelSettingsUI.Location = new System.Drawing.Point(0, 305);
            this.panelSettingsUI.Name = "panelSettingsUI";
            this.panelSettingsUI.Size = new System.Drawing.Size(403, 57);
            this.panelSettingsUI.TabIndex = 84;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelSettingsOptions);
            this.panel1.Controls.Add(this.checkBoxReadOnly);
            this.panel1.Controls.Add(this.checkBoxHandleNXMLinks);
            this.panel1.Location = new System.Drawing.Point(0, 368);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(403, 86);
            this.panel1.TabIndex = 85;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelSettingsNuclearWinterOptions);
            this.panel2.Controls.Add(this.checkBoxNWRenameDLL);
            this.panel2.Controls.Add(this.checkBoxNWAutoDisableMods);
            this.panel2.Controls.Add(this.labelNWdlloptions);
            this.panel2.Controls.Add(this.labelNWmodoptions);
            this.panel2.Controls.Add(this.checkBoxNWAutoDeployMods);
            this.panel2.Controls.Add(this.labelToggleNW);
            this.panel2.Controls.Add(this.buttonNWMode);
            this.panel2.Location = new System.Drawing.Point(0, 736);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(403, 279);
            this.panel2.TabIndex = 86;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelSettingsPaths);
            this.panel3.Controls.Add(this.labelSevenZipPath);
            this.panel3.Controls.Add(this.buttonPickArchiveTwoPath);
            this.panel3.Controls.Add(this.labelArchiveTwoPath);
            this.panel3.Controls.Add(this.textBoxSevenZipPath);
            this.panel3.Controls.Add(this.textBoxArchiveTwoPath);
            this.panel3.Controls.Add(this.buttonPickSevenZipPath);
            this.panel3.Controls.Add(this.textBoxDownloadsPath);
            this.panel3.Controls.Add(this.labelSettingsPrograms);
            this.panel3.Controls.Add(this.labelSettingsModManager);
            this.panel3.Controls.Add(this.labelDownloadsPath);
            this.panel3.Controls.Add(this.buttonPickDownloadsPath);
            this.panel3.Location = new System.Drawing.Point(0, 460);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(403, 177);
            this.panel3.TabIndex = 87;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.linkLabelOpenProfileEditor);
            this.panel4.Controls.Add(this.labelSettingsProfileNotice);
            this.panel4.Controls.Add(this.labelSettingsProfiles);
            this.panel4.Location = new System.Drawing.Point(0, 643);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(403, 87);
            this.panel4.TabIndex = 88;
            // 
            // labelSettingsProfiles
            // 
            this.labelSettingsProfiles.AutoSize = true;
            this.labelSettingsProfiles.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsProfiles.Location = new System.Drawing.Point(13, 6);
            this.labelSettingsProfiles.Margin = new System.Windows.Forms.Padding(3, 25, 3, 5);
            this.labelSettingsProfiles.Name = "labelSettingsProfiles";
            this.labelSettingsProfiles.Size = new System.Drawing.Size(46, 17);
            this.labelSettingsProfiles.TabIndex = 80;
            this.labelSettingsProfiles.Text = "Profile";
            // 
            // labelSettingsProfileNotice
            // 
            this.labelSettingsProfileNotice.Location = new System.Drawing.Point(13, 28);
            this.labelSettingsProfileNotice.Name = "labelSettingsProfileNotice";
            this.labelSettingsProfileNotice.Size = new System.Drawing.Size(371, 32);
            this.labelSettingsProfileNotice.TabIndex = 81;
            this.labelSettingsProfileNotice.Text = "Looking for the profile settings (game path, game edition, etc.)?";
            // 
            // linkLabelOpenProfileEditor
            // 
            this.linkLabelOpenProfileEditor.AutoSize = true;
            this.linkLabelOpenProfileEditor.Location = new System.Drawing.Point(15, 64);
            this.linkLabelOpenProfileEditor.Name = "linkLabelOpenProfileEditor";
            this.linkLabelOpenProfileEditor.Size = new System.Drawing.Size(83, 13);
            this.linkLabelOpenProfileEditor.TabIndex = 82;
            this.linkLabelOpenProfileEditor.TabStop = true;
            this.linkLabelOpenProfileEditor.Text = "Go to profiles →";
            this.linkLabelOpenProfileEditor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelOpenProfileEditor_LinkClicked);
            // 
            // buttonNWMode
            // 
            this.buttonNWMode.BorderWidth = ((uint)(1u));
            this.buttonNWMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonNWMode.Highlight = false;
            this.buttonNWMode.Image = global::Fo76ini.Properties.Resources.fire;
            this.buttonNWMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNWMode.Location = new System.Drawing.Point(17, 53);
            this.buttonNWMode.Name = "buttonNWMode";
            this.buttonNWMode.Padding = 10;
            this.buttonNWMode.Size = new System.Drawing.Size(187, 36);
            this.buttonNWMode.TabIndex = 50;
            this.buttonNWMode.Text = "Nuclear Winter";
            this.buttonNWMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNWMode.UseVisualStyleBackColor = true;
            this.buttonNWMode.Click += new System.EventHandler(this.buttonNWMode_Click);
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
            // UserControlSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelSettingsUI);
            this.Controls.Add(this.panelSettingsBehavior);
            this.Controls.Add(this.panelSettingsLocalization);
            this.Controls.Add(this.labelSettingsTitle);
            this.Name = "UserControlSettings";
            this.Size = new System.Drawing.Size(411, 600);
            this.Load += new System.EventHandler(this.UserControlSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerDownloadLanguages)).EndInit();
            this.panelSettingsLocalization.ResumeLayout(false);
            this.panelSettingsLocalization.PerformLayout();
            this.panelSettingsBehavior.ResumeLayout(false);
            this.panelSettingsBehavior.PerformLayout();
            this.panelSettingsUI.ResumeLayout(false);
            this.panelSettingsUI.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorkerDownloadLanguages;
        public Controls.CustomToolTip toolTip;
        private System.Windows.Forms.OpenFileDialog openFileDialogArchiveTwoPath;
        private System.Windows.Forms.OpenFileDialog openFileDialogSevenZipPath;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.Label labelSettingsTitle;
        private System.Windows.Forms.Button buttonDownloadLanguages;
        private System.Windows.Forms.PictureBox pictureBoxSpinnerDownloadLanguages;
        private System.Windows.Forms.Label labelSettingsLocalization;
        private System.Windows.Forms.Button buttonRefreshLanguage;
        private System.Windows.Forms.CheckBox checkBoxAutoApply;
        private System.Windows.Forms.CheckBox checkBoxQuitOnGameLaunch;
        public System.Windows.Forms.Label labelOutdatedLanguage;
        private System.Windows.Forms.Label labelSevenZipPath;
        private System.Windows.Forms.CheckBox checkBoxIgnoreUpdates;
        private System.Windows.Forms.Button buttonPickArchiveTwoPath;
        private System.Windows.Forms.Label labelSettingsBehavior;
        private System.Windows.Forms.Label labelArchiveTwoPath;
        private System.Windows.Forms.CheckBox checkBoxPlayNotificationSound;
        private System.Windows.Forms.TextBox textBoxSevenZipPath;
        private System.Windows.Forms.Label labelSettingsUI;
        private System.Windows.Forms.TextBox textBoxArchiveTwoPath;
        private System.Windows.Forms.CheckBox checkBoxShowWhatsNew;
        private System.Windows.Forms.Button buttonPickSevenZipPath;
        private System.Windows.Forms.CheckBox checkBoxReadOnly;
        private System.Windows.Forms.Label labelSettingsPrograms;
        private System.Windows.Forms.Label labelSettingsModManager;
        private System.Windows.Forms.Label labelSettingsOptions;
        private System.Windows.Forms.Button buttonPickDownloadsPath;
        private System.Windows.Forms.CheckBox checkBoxNWRenameDLL;
        private System.Windows.Forms.CheckBox checkBoxHandleNXMLinks;
        private System.Windows.Forms.CheckBox checkBoxNWAutoDisableMods;
        private System.Windows.Forms.Label labelDownloadsPath;
        private System.Windows.Forms.Label labelNWdlloptions;
        private System.Windows.Forms.Label labelSettingsPaths;
        private System.Windows.Forms.Label labelNWmodoptions;
        private System.Windows.Forms.TextBox textBoxDownloadsPath;
        private System.Windows.Forms.CheckBox checkBoxNWAutoDeployMods;
        private System.Windows.Forms.Label labelSettingsNuclearWinterOptions;
        private Controls.StyledButton buttonNWMode;
        private System.Windows.Forms.Label labelToggleNW;
        private System.Windows.Forms.Panel panelSettingsLocalization;
        private System.Windows.Forms.Panel panelSettingsBehavior;
        private System.Windows.Forms.Panel panelSettingsUI;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel linkLabelOpenProfileEditor;
        private System.Windows.Forms.Label labelSettingsProfileNotice;
        private System.Windows.Forms.Label labelSettingsProfiles;
    }
}
