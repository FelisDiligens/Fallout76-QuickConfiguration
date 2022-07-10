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
            this.toolTip = new Controls.CustomToolTip(this.components);
            this.openFileDialogArchiveTwoPath = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogSevenZipPath = new System.Windows.Forms.OpenFileDialog();
            this.panelPadding = new System.Windows.Forms.Panel();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.labelLanguage = new System.Windows.Forms.Label();
            this.labelSettingsTitle = new System.Windows.Forms.Label();
            this.labelSettingsDesc = new System.Windows.Forms.Label();
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
            this.buttonNWMode = new Fo76ini.Controls.StyledButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerDownloadLanguages)).BeginInit();
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
            // panelPadding
            // 
            this.panelPadding.Location = new System.Drawing.Point(17, 892);
            this.panelPadding.Name = "panelPadding";
            this.panelPadding.Size = new System.Drawing.Size(289, 40);
            this.panelPadding.TabIndex = 81;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Location = new System.Drawing.Point(15, 122);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(317, 21);
            this.comboBoxLanguage.TabIndex = 17;
            this.comboBoxLanguage.TabStop = false;
            // 
            // labelLanguage
            // 
            this.labelLanguage.AutoSize = true;
            this.labelLanguage.Location = new System.Drawing.Point(12, 106);
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
            this.labelSettingsTitle.Size = new System.Drawing.Size(90, 30);
            this.labelSettingsTitle.TabIndex = 73;
            this.labelSettingsTitle.Text = "Settings";
            // 
            // labelSettingsDesc
            // 
            this.labelSettingsDesc.AutoSize = true;
            this.labelSettingsDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsDesc.Location = new System.Drawing.Point(12, 45);
            this.labelSettingsDesc.Name = "labelSettingsDesc";
            this.labelSettingsDesc.Size = new System.Drawing.Size(282, 17);
            this.labelSettingsDesc.TabIndex = 74;
            this.labelSettingsDesc.Text = "These settings change the behavior of the tool.";
            // 
            // buttonDownloadLanguages
            // 
            this.buttonDownloadLanguages.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.buttonDownloadLanguages.FlatAppearance.BorderSize = 0;
            this.buttonDownloadLanguages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDownloadLanguages.Image = global::Fo76ini.Properties.Resources.download_2_24;
            this.buttonDownloadLanguages.Location = new System.Drawing.Point(262, 149);
            this.buttonDownloadLanguages.Name = "buttonDownloadLanguages";
            this.buttonDownloadLanguages.Size = new System.Drawing.Size(32, 32);
            this.buttonDownloadLanguages.TabIndex = 16;
            this.buttonDownloadLanguages.UseVisualStyleBackColor = true;
            this.buttonDownloadLanguages.Click += new System.EventHandler(this.buttonDownloadLanguages_Click);
            // 
            // pictureBoxSpinnerDownloadLanguages
            // 
            this.pictureBoxSpinnerDownloadLanguages.Image = global::Fo76ini.Properties.Resources.Spinner_24;
            this.pictureBoxSpinnerDownloadLanguages.Location = new System.Drawing.Point(231, 153);
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
            this.labelSettingsLocalization.Location = new System.Drawing.Point(12, 84);
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
            this.buttonRefreshLanguage.Location = new System.Drawing.Point(300, 149);
            this.buttonRefreshLanguage.Name = "buttonRefreshLanguage";
            this.buttonRefreshLanguage.Size = new System.Drawing.Size(32, 32);
            this.buttonRefreshLanguage.TabIndex = 40;
            this.buttonRefreshLanguage.UseVisualStyleBackColor = false;
            this.buttonRefreshLanguage.Click += new System.EventHandler(this.buttonRefreshLanguage_Click);
            // 
            // checkBoxAutoApply
            // 
            this.checkBoxAutoApply.AutoSize = true;
            this.checkBoxAutoApply.Location = new System.Drawing.Point(15, 248);
            this.checkBoxAutoApply.Name = "checkBoxAutoApply";
            this.checkBoxAutoApply.Size = new System.Drawing.Size(351, 17);
            this.checkBoxAutoApply.TabIndex = 21;
            this.checkBoxAutoApply.Text = "Automatically apply changes when tool is closed or game is launched";
            this.checkBoxAutoApply.UseVisualStyleBackColor = true;
            // 
            // checkBoxQuitOnGameLaunch
            // 
            this.checkBoxQuitOnGameLaunch.AutoSize = true;
            this.checkBoxQuitOnGameLaunch.Location = new System.Drawing.Point(15, 225);
            this.checkBoxQuitOnGameLaunch.Name = "checkBoxQuitOnGameLaunch";
            this.checkBoxQuitOnGameLaunch.Size = new System.Drawing.Size(223, 17);
            this.checkBoxQuitOnGameLaunch.TabIndex = 20;
            this.checkBoxQuitOnGameLaunch.Text = "Close the tool when the game is launched";
            this.checkBoxQuitOnGameLaunch.UseVisualStyleBackColor = true;
            // 
            // labelOutdatedLanguage
            // 
            this.labelOutdatedLanguage.ForeColor = System.Drawing.Color.Firebrick;
            this.labelOutdatedLanguage.Location = new System.Drawing.Point(13, 149);
            this.labelOutdatedLanguage.Name = "labelOutdatedLanguage";
            this.labelOutdatedLanguage.Size = new System.Drawing.Size(212, 51);
            this.labelOutdatedLanguage.TabIndex = 21;
            this.labelOutdatedLanguage.Text = "This translation is out-dated.\r\nSome elements might not be translated yet.";
            // 
            // labelSevenZipPath
            // 
            this.labelSevenZipPath.AutoSize = true;
            this.labelSevenZipPath.Location = new System.Drawing.Point(13, 634);
            this.labelSevenZipPath.Name = "labelSevenZipPath";
            this.labelSevenZipPath.Size = new System.Drawing.Size(65, 13);
            this.labelSevenZipPath.TabIndex = 42;
            this.labelSevenZipPath.Text = "7z.exe path:";
            // 
            // checkBoxIgnoreUpdates
            // 
            this.checkBoxIgnoreUpdates.AutoSize = true;
            this.checkBoxIgnoreUpdates.Location = new System.Drawing.Point(15, 272);
            this.checkBoxIgnoreUpdates.Name = "checkBoxIgnoreUpdates";
            this.checkBoxIgnoreUpdates.Size = new System.Drawing.Size(140, 17);
            this.checkBoxIgnoreUpdates.TabIndex = 24;
            this.checkBoxIgnoreUpdates.Text = "Don\'t check for updates";
            this.checkBoxIgnoreUpdates.UseVisualStyleBackColor = true;
            this.checkBoxIgnoreUpdates.CheckedChanged += new System.EventHandler(this.checkBoxIgnoreUpdates_CheckedChanged);
            // 
            // buttonPickArchiveTwoPath
            // 
            this.buttonPickArchiveTwoPath.Location = new System.Drawing.Point(359, 600);
            this.buttonPickArchiveTwoPath.Name = "buttonPickArchiveTwoPath";
            this.buttonPickArchiveTwoPath.Size = new System.Drawing.Size(28, 23);
            this.buttonPickArchiveTwoPath.TabIndex = 44;
            this.buttonPickArchiveTwoPath.Text = "...";
            this.buttonPickArchiveTwoPath.UseVisualStyleBackColor = true;
            this.buttonPickArchiveTwoPath.Click += new System.EventHandler(this.buttonPickArchiveTwoPath_Click);
            // 
            // labelSettingsBehavior
            // 
            this.labelSettingsBehavior.AutoSize = true;
            this.labelSettingsBehavior.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsBehavior.Location = new System.Drawing.Point(12, 200);
            this.labelSettingsBehavior.Margin = new System.Windows.Forms.Padding(3, 25, 3, 5);
            this.labelSettingsBehavior.Name = "labelSettingsBehavior";
            this.labelSettingsBehavior.Size = new System.Drawing.Size(61, 17);
            this.labelSettingsBehavior.TabIndex = 76;
            this.labelSettingsBehavior.Text = "Behavior";
            // 
            // labelArchiveTwoPath
            // 
            this.labelArchiveTwoPath.AutoSize = true;
            this.labelArchiveTwoPath.Location = new System.Drawing.Point(13, 605);
            this.labelArchiveTwoPath.Name = "labelArchiveTwoPath";
            this.labelArchiveTwoPath.Size = new System.Drawing.Size(96, 13);
            this.labelArchiveTwoPath.TabIndex = 41;
            this.labelArchiveTwoPath.Text = "Archive2.exe path:";
            // 
            // checkBoxPlayNotificationSound
            // 
            this.checkBoxPlayNotificationSound.AutoSize = true;
            this.checkBoxPlayNotificationSound.Location = new System.Drawing.Point(15, 295);
            this.checkBoxPlayNotificationSound.Name = "checkBoxPlayNotificationSound";
            this.checkBoxPlayNotificationSound.Size = new System.Drawing.Size(132, 17);
            this.checkBoxPlayNotificationSound.TabIndex = 25;
            this.checkBoxPlayNotificationSound.Text = "Play notification sound";
            this.checkBoxPlayNotificationSound.UseVisualStyleBackColor = true;
            // 
            // textBoxSevenZipPath
            // 
            this.textBoxSevenZipPath.Location = new System.Drawing.Point(119, 631);
            this.textBoxSevenZipPath.Name = "textBoxSevenZipPath";
            this.textBoxSevenZipPath.Size = new System.Drawing.Size(234, 20);
            this.textBoxSevenZipPath.TabIndex = 45;
            this.textBoxSevenZipPath.TextChanged += new System.EventHandler(this.textBoxSevenZipPath_TextChanged);
            // 
            // labelSettingsUI
            // 
            this.labelSettingsUI.AutoSize = true;
            this.labelSettingsUI.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsUI.Location = new System.Drawing.Point(12, 340);
            this.labelSettingsUI.Margin = new System.Windows.Forms.Padding(3, 25, 3, 5);
            this.labelSettingsUI.Name = "labelSettingsUI";
            this.labelSettingsUI.Size = new System.Drawing.Size(92, 17);
            this.labelSettingsUI.TabIndex = 77;
            this.labelSettingsUI.Text = "User Interface";
            // 
            // textBoxArchiveTwoPath
            // 
            this.textBoxArchiveTwoPath.Location = new System.Drawing.Point(119, 602);
            this.textBoxArchiveTwoPath.Name = "textBoxArchiveTwoPath";
            this.textBoxArchiveTwoPath.Size = new System.Drawing.Size(234, 20);
            this.textBoxArchiveTwoPath.TabIndex = 43;
            this.textBoxArchiveTwoPath.TextChanged += new System.EventHandler(this.textBoxArchiveTwoPath_TextChanged);
            // 
            // checkBoxShowWhatsNew
            // 
            this.checkBoxShowWhatsNew.AutoSize = true;
            this.checkBoxShowWhatsNew.Location = new System.Drawing.Point(15, 365);
            this.checkBoxShowWhatsNew.Name = "checkBoxShowWhatsNew";
            this.checkBoxShowWhatsNew.Size = new System.Drawing.Size(214, 17);
            this.checkBoxShowWhatsNew.TabIndex = 26;
            this.checkBoxShowWhatsNew.Text = "Show \"What\'s new\" on the home page.";
            this.checkBoxShowWhatsNew.UseVisualStyleBackColor = true;
            // 
            // buttonPickSevenZipPath
            // 
            this.buttonPickSevenZipPath.Location = new System.Drawing.Point(359, 629);
            this.buttonPickSevenZipPath.Name = "buttonPickSevenZipPath";
            this.buttonPickSevenZipPath.Size = new System.Drawing.Size(28, 23);
            this.buttonPickSevenZipPath.TabIndex = 46;
            this.buttonPickSevenZipPath.Text = "...";
            this.buttonPickSevenZipPath.UseVisualStyleBackColor = true;
            this.buttonPickSevenZipPath.Click += new System.EventHandler(this.buttonPickSevenZipPath_Click);
            // 
            // checkBoxReadOnly
            // 
            this.checkBoxReadOnly.AutoSize = true;
            this.checkBoxReadOnly.Location = new System.Drawing.Point(15, 435);
            this.checkBoxReadOnly.Name = "checkBoxReadOnly";
            this.checkBoxReadOnly.Size = new System.Drawing.Size(140, 17);
            this.checkBoxReadOnly.TabIndex = 4;
            this.checkBoxReadOnly.Text = "Make *.ini files read-only";
            this.checkBoxReadOnly.UseVisualStyleBackColor = true;
            // 
            // labelSettingsPrograms
            // 
            this.labelSettingsPrograms.AutoSize = true;
            this.labelSettingsPrograms.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsPrograms.Location = new System.Drawing.Point(13, 582);
            this.labelSettingsPrograms.Name = "labelSettingsPrograms";
            this.labelSettingsPrograms.Size = new System.Drawing.Size(58, 15);
            this.labelSettingsPrograms.TabIndex = 26;
            this.labelSettingsPrograms.Text = "Programs";
            // 
            // labelSettingsModManager
            // 
            this.labelSettingsModManager.AutoSize = true;
            this.labelSettingsModManager.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsModManager.Location = new System.Drawing.Point(13, 525);
            this.labelSettingsModManager.Name = "labelSettingsModManager";
            this.labelSettingsModManager.Size = new System.Drawing.Size(82, 15);
            this.labelSettingsModManager.TabIndex = 47;
            this.labelSettingsModManager.Text = "Mod manager";
            // 
            // labelSettingsOptions
            // 
            this.labelSettingsOptions.AutoSize = true;
            this.labelSettingsOptions.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsOptions.Location = new System.Drawing.Point(12, 410);
            this.labelSettingsOptions.Margin = new System.Windows.Forms.Padding(3, 25, 3, 5);
            this.labelSettingsOptions.Name = "labelSettingsOptions";
            this.labelSettingsOptions.Size = new System.Drawing.Size(56, 17);
            this.labelSettingsOptions.TabIndex = 78;
            this.labelSettingsOptions.Text = "Options";
            // 
            // buttonPickDownloadsPath
            // 
            this.buttonPickDownloadsPath.Location = new System.Drawing.Point(359, 545);
            this.buttonPickDownloadsPath.Name = "buttonPickDownloadsPath";
            this.buttonPickDownloadsPath.Size = new System.Drawing.Size(28, 23);
            this.buttonPickDownloadsPath.TabIndex = 50;
            this.buttonPickDownloadsPath.Text = "...";
            this.buttonPickDownloadsPath.UseVisualStyleBackColor = true;
            this.buttonPickDownloadsPath.Click += new System.EventHandler(this.buttonPickDownloadsPath_Click);
            // 
            // checkBoxNWRenameDLL
            // 
            this.checkBoxNWRenameDLL.AutoSize = true;
            this.checkBoxNWRenameDLL.Location = new System.Drawing.Point(17, 793);
            this.checkBoxNWRenameDLL.Name = "checkBoxNWRenameDLL";
            this.checkBoxNWRenameDLL.Size = new System.Drawing.Size(140, 17);
            this.checkBoxNWRenameDLL.TabIndex = 18;
            this.checkBoxNWRenameDLL.Text = "Rename added *.dll files";
            this.checkBoxNWRenameDLL.UseVisualStyleBackColor = true;
            // 
            // checkBoxHandleNXMLinks
            // 
            this.checkBoxHandleNXMLinks.AutoSize = true;
            this.checkBoxHandleNXMLinks.Location = new System.Drawing.Point(15, 458);
            this.checkBoxHandleNXMLinks.Name = "checkBoxHandleNXMLinks";
            this.checkBoxHandleNXMLinks.Size = new System.Drawing.Size(248, 17);
            this.checkBoxHandleNXMLinks.TabIndex = 7;
            this.checkBoxHandleNXMLinks.Text = "Associate with \"Mod Manager Download\" links";
            this.checkBoxHandleNXMLinks.UseVisualStyleBackColor = true;
            this.checkBoxHandleNXMLinks.CheckedChanged += new System.EventHandler(this.checkBoxHandleNXMLinks_CheckedChanged);
            // 
            // checkBoxNWAutoDisableMods
            // 
            this.checkBoxNWAutoDisableMods.AutoSize = true;
            this.checkBoxNWAutoDisableMods.Location = new System.Drawing.Point(17, 846);
            this.checkBoxNWAutoDisableMods.Name = "checkBoxNWAutoDisableMods";
            this.checkBoxNWAutoDisableMods.Size = new System.Drawing.Size(224, 17);
            this.checkBoxNWAutoDisableMods.TabIndex = 19;
            this.checkBoxNWAutoDisableMods.Text = "Automatically remove mods upon enabling";
            this.checkBoxNWAutoDisableMods.UseVisualStyleBackColor = true;
            // 
            // labelDownloadsPath
            // 
            this.labelDownloadsPath.AutoSize = true;
            this.labelDownloadsPath.Location = new System.Drawing.Point(13, 550);
            this.labelDownloadsPath.Name = "labelDownloadsPath";
            this.labelDownloadsPath.Size = new System.Drawing.Size(92, 13);
            this.labelDownloadsPath.TabIndex = 48;
            this.labelDownloadsPath.Text = "Downloads folder:";
            // 
            // labelNWdlloptions
            // 
            this.labelNWdlloptions.AutoSize = true;
            this.labelNWdlloptions.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNWdlloptions.Location = new System.Drawing.Point(14, 775);
            this.labelNWdlloptions.Name = "labelNWdlloptions";
            this.labelNWdlloptions.Size = new System.Drawing.Size(74, 15);
            this.labelNWdlloptions.TabIndex = 23;
            this.labelNWdlloptions.Text = "*.dll options:";
            // 
            // labelSettingsPaths
            // 
            this.labelSettingsPaths.AutoSize = true;
            this.labelSettingsPaths.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsPaths.Location = new System.Drawing.Point(13, 503);
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
            this.labelNWmodoptions.Location = new System.Drawing.Point(14, 828);
            this.labelNWmodoptions.Name = "labelNWmodoptions";
            this.labelNWmodoptions.Size = new System.Drawing.Size(78, 15);
            this.labelNWmodoptions.TabIndex = 24;
            this.labelNWmodoptions.Text = "Mod options:";
            // 
            // textBoxDownloadsPath
            // 
            this.textBoxDownloadsPath.Location = new System.Drawing.Point(119, 547);
            this.textBoxDownloadsPath.Name = "textBoxDownloadsPath";
            this.textBoxDownloadsPath.Size = new System.Drawing.Size(234, 20);
            this.textBoxDownloadsPath.TabIndex = 49;
            this.textBoxDownloadsPath.TextChanged += new System.EventHandler(this.textBoxDownloadsPath_TextChanged);
            // 
            // checkBoxNWAutoDeployMods
            // 
            this.checkBoxNWAutoDeployMods.AutoSize = true;
            this.checkBoxNWAutoDeployMods.Location = new System.Drawing.Point(17, 869);
            this.checkBoxNWAutoDeployMods.Name = "checkBoxNWAutoDeployMods";
            this.checkBoxNWAutoDeployMods.Size = new System.Drawing.Size(221, 17);
            this.checkBoxNWAutoDeployMods.TabIndex = 25;
            this.checkBoxNWAutoDeployMods.Text = "Automatically deploy mods upon disabling";
            this.checkBoxNWAutoDeployMods.UseVisualStyleBackColor = true;
            // 
            // labelSettingsNuclearWinterOptions
            // 
            this.labelSettingsNuclearWinterOptions.AutoSize = true;
            this.labelSettingsNuclearWinterOptions.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsNuclearWinterOptions.Location = new System.Drawing.Point(13, 679);
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
            this.labelToggleNW.Location = new System.Drawing.Point(13, 701);
            this.labelToggleNW.Name = "labelToggleNW";
            this.labelToggleNW.Size = new System.Drawing.Size(80, 15);
            this.labelToggleNW.TabIndex = 27;
            this.labelToggleNW.Text = "Toggle mode:";
            // 
            // buttonNWMode
            // 
            this.buttonNWMode.BorderWidth = ((uint)(1u));
            this.buttonNWMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonNWMode.Highlight = false;
            this.buttonNWMode.Image = global::Fo76ini.Properties.Resources.fire;
            this.buttonNWMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNWMode.Location = new System.Drawing.Point(17, 719);
            this.buttonNWMode.Name = "buttonNWMode";
            this.buttonNWMode.Padding = 10;
            this.buttonNWMode.Size = new System.Drawing.Size(187, 36);
            this.buttonNWMode.TabIndex = 26;
            this.buttonNWMode.Text = "Nuclear Winter";
            this.buttonNWMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNWMode.UseVisualStyleBackColor = true;
            this.buttonNWMode.Click += new System.EventHandler(this.buttonNWMode_Click);
            // 
            // UserControlSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.panelPadding);
            this.Controls.Add(this.labelToggleNW);
            this.Controls.Add(this.buttonNWMode);
            this.Controls.Add(this.labelSettingsNuclearWinterOptions);
            this.Controls.Add(this.checkBoxNWAutoDeployMods);
            this.Controls.Add(this.textBoxDownloadsPath);
            this.Controls.Add(this.labelNWmodoptions);
            this.Controls.Add(this.labelSettingsPaths);
            this.Controls.Add(this.labelNWdlloptions);
            this.Controls.Add(this.labelDownloadsPath);
            this.Controls.Add(this.checkBoxNWAutoDisableMods);
            this.Controls.Add(this.checkBoxHandleNXMLinks);
            this.Controls.Add(this.checkBoxNWRenameDLL);
            this.Controls.Add(this.buttonPickDownloadsPath);
            this.Controls.Add(this.labelSettingsOptions);
            this.Controls.Add(this.labelSettingsModManager);
            this.Controls.Add(this.labelSettingsPrograms);
            this.Controls.Add(this.checkBoxReadOnly);
            this.Controls.Add(this.buttonPickSevenZipPath);
            this.Controls.Add(this.checkBoxShowWhatsNew);
            this.Controls.Add(this.textBoxArchiveTwoPath);
            this.Controls.Add(this.labelSettingsUI);
            this.Controls.Add(this.textBoxSevenZipPath);
            this.Controls.Add(this.checkBoxPlayNotificationSound);
            this.Controls.Add(this.labelArchiveTwoPath);
            this.Controls.Add(this.labelSettingsBehavior);
            this.Controls.Add(this.buttonPickArchiveTwoPath);
            this.Controls.Add(this.checkBoxIgnoreUpdates);
            this.Controls.Add(this.labelSevenZipPath);
            this.Controls.Add(this.labelOutdatedLanguage);
            this.Controls.Add(this.checkBoxQuitOnGameLaunch);
            this.Controls.Add(this.checkBoxAutoApply);
            this.Controls.Add(this.buttonRefreshLanguage);
            this.Controls.Add(this.labelSettingsLocalization);
            this.Controls.Add(this.pictureBoxSpinnerDownloadLanguages);
            this.Controls.Add(this.buttonDownloadLanguages);
            this.Controls.Add(this.labelSettingsDesc);
            this.Controls.Add(this.labelSettingsTitle);
            this.Controls.Add(this.labelLanguage);
            this.Controls.Add(this.comboBoxLanguage);
            this.Name = "UserControlSettings";
            this.Size = new System.Drawing.Size(513, 600);
            this.Load += new System.EventHandler(this.UserControlSettings_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerDownloadLanguages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorkerDownloadLanguages;
        public Controls.CustomToolTip toolTip;
        private System.Windows.Forms.OpenFileDialog openFileDialogArchiveTwoPath;
        private System.Windows.Forms.OpenFileDialog openFileDialogSevenZipPath;
        private System.Windows.Forms.Panel panelPadding;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.Label labelSettingsTitle;
        private System.Windows.Forms.Label labelSettingsDesc;
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
    }
}
