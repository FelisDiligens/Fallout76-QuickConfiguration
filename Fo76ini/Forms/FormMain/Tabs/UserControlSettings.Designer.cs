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
            this.groupBoxUI = new System.Windows.Forms.GroupBox();
            this.checkBoxShowWhatsNew = new System.Windows.Forms.CheckBox();
            this.groupBoxPaths = new System.Windows.Forms.GroupBox();
            this.textBoxDownloadsPath = new System.Windows.Forms.TextBox();
            this.labelDownloadsPath = new System.Windows.Forms.Label();
            this.buttonPickDownloadsPath = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPickSevenZipPath = new System.Windows.Forms.Button();
            this.textBoxArchiveTwoPath = new System.Windows.Forms.TextBox();
            this.textBoxSevenZipPath = new System.Windows.Forms.TextBox();
            this.labelArchiveTwoPath = new System.Windows.Forms.Label();
            this.buttonPickArchiveTwoPath = new System.Windows.Forms.Button();
            this.labelSevenZipPath = new System.Windows.Forms.Label();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.checkBoxHandleNXMLinks = new System.Windows.Forms.CheckBox();
            this.checkBoxReadOnly = new System.Windows.Forms.CheckBox();
            this.groupBoxNuclearWinterMode = new System.Windows.Forms.GroupBox();
            this.labelToggleNW = new System.Windows.Forms.Label();
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
            this.labelSettingsDesc = new System.Windows.Forms.Label();
            this.labelSettingsTitle = new System.Windows.Forms.Label();
            this.backgroundWorkerDownloadLanguages = new System.ComponentModel.BackgroundWorker();
            this.buttonNWMode = new Fo76ini.Controls.StyledButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.openFileDialogArchiveTwoPath = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogSevenZipPath = new System.Windows.Forms.OpenFileDialog();
            this.groupBoxUI.SuspendLayout();
            this.groupBoxPaths.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            this.groupBoxNuclearWinterMode.SuspendLayout();
            this.groupBoxBehavior.SuspendLayout();
            this.groupBoxLocalization.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerDownloadLanguages)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxUI
            // 
            this.groupBoxUI.Controls.Add(this.checkBoxShowWhatsNew);
            this.groupBoxUI.Location = new System.Drawing.Point(7, 283);
            this.groupBoxUI.Name = "groupBoxUI";
            this.groupBoxUI.Size = new System.Drawing.Size(390, 73);
            this.groupBoxUI.TabIndex = 51;
            this.groupBoxUI.TabStop = false;
            this.groupBoxUI.Text = "User Interface";
            // 
            // checkBoxShowWhatsNew
            // 
            this.checkBoxShowWhatsNew.AutoSize = true;
            this.checkBoxShowWhatsNew.Location = new System.Drawing.Point(6, 19);
            this.checkBoxShowWhatsNew.Name = "checkBoxShowWhatsNew";
            this.checkBoxShowWhatsNew.Size = new System.Drawing.Size(190, 17);
            this.checkBoxShowWhatsNew.TabIndex = 26;
            this.checkBoxShowWhatsNew.Text = "Show \"What\'s new\" in the Info tab";
            this.checkBoxShowWhatsNew.UseVisualStyleBackColor = true;
            // 
            // groupBoxPaths
            // 
            this.groupBoxPaths.Controls.Add(this.textBoxDownloadsPath);
            this.groupBoxPaths.Controls.Add(this.labelDownloadsPath);
            this.groupBoxPaths.Controls.Add(this.buttonPickDownloadsPath);
            this.groupBoxPaths.Controls.Add(this.label3);
            this.groupBoxPaths.Controls.Add(this.label2);
            this.groupBoxPaths.Controls.Add(this.buttonPickSevenZipPath);
            this.groupBoxPaths.Controls.Add(this.textBoxArchiveTwoPath);
            this.groupBoxPaths.Controls.Add(this.textBoxSevenZipPath);
            this.groupBoxPaths.Controls.Add(this.labelArchiveTwoPath);
            this.groupBoxPaths.Controls.Add(this.buttonPickArchiveTwoPath);
            this.groupBoxPaths.Controls.Add(this.labelSevenZipPath);
            this.groupBoxPaths.Location = new System.Drawing.Point(7, 448);
            this.groupBoxPaths.Name = "groupBoxPaths";
            this.groupBoxPaths.Size = new System.Drawing.Size(390, 167);
            this.groupBoxPaths.TabIndex = 50;
            this.groupBoxPaths.TabStop = false;
            this.groupBoxPaths.Text = "Paths";
            // 
            // textBoxDownloadsPath
            // 
            this.textBoxDownloadsPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDownloadsPath.Location = new System.Drawing.Point(113, 47);
            this.textBoxDownloadsPath.Name = "textBoxDownloadsPath";
            this.textBoxDownloadsPath.Size = new System.Drawing.Size(234, 20);
            this.textBoxDownloadsPath.TabIndex = 49;
            this.textBoxDownloadsPath.TextChanged += new System.EventHandler(this.textBoxDownloadsPath_TextChanged);
            // 
            // labelDownloadsPath
            // 
            this.labelDownloadsPath.AutoSize = true;
            this.labelDownloadsPath.Location = new System.Drawing.Point(7, 50);
            this.labelDownloadsPath.Name = "labelDownloadsPath";
            this.labelDownloadsPath.Size = new System.Drawing.Size(92, 13);
            this.labelDownloadsPath.TabIndex = 48;
            this.labelDownloadsPath.Text = "Downloads folder:";
            // 
            // buttonPickDownloadsPath
            // 
            this.buttonPickDownloadsPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPickDownloadsPath.Location = new System.Drawing.Point(353, 45);
            this.buttonPickDownloadsPath.Name = "buttonPickDownloadsPath";
            this.buttonPickDownloadsPath.Size = new System.Drawing.Size(28, 23);
            this.buttonPickDownloadsPath.TabIndex = 50;
            this.buttonPickDownloadsPath.Text = "...";
            this.buttonPickDownloadsPath.UseVisualStyleBackColor = true;
            this.buttonPickDownloadsPath.Click += new System.EventHandler(this.buttonPickDownloadsPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 13);
            this.label3.TabIndex = 47;
            this.label3.Text = "Mod manager:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Programs:";
            // 
            // buttonPickSevenZipPath
            // 
            this.buttonPickSevenZipPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPickSevenZipPath.Location = new System.Drawing.Point(353, 129);
            this.buttonPickSevenZipPath.Name = "buttonPickSevenZipPath";
            this.buttonPickSevenZipPath.Size = new System.Drawing.Size(28, 23);
            this.buttonPickSevenZipPath.TabIndex = 46;
            this.buttonPickSevenZipPath.Text = "...";
            this.buttonPickSevenZipPath.UseVisualStyleBackColor = true;
            this.buttonPickSevenZipPath.Click += new System.EventHandler(this.buttonPickSevenZipPath_Click);
            // 
            // textBoxArchiveTwoPath
            // 
            this.textBoxArchiveTwoPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxArchiveTwoPath.Location = new System.Drawing.Point(113, 102);
            this.textBoxArchiveTwoPath.Name = "textBoxArchiveTwoPath";
            this.textBoxArchiveTwoPath.Size = new System.Drawing.Size(234, 20);
            this.textBoxArchiveTwoPath.TabIndex = 43;
            this.textBoxArchiveTwoPath.TextChanged += new System.EventHandler(this.textBoxArchiveTwoPath_TextChanged);
            // 
            // textBoxSevenZipPath
            // 
            this.textBoxSevenZipPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSevenZipPath.Location = new System.Drawing.Point(113, 131);
            this.textBoxSevenZipPath.Name = "textBoxSevenZipPath";
            this.textBoxSevenZipPath.Size = new System.Drawing.Size(234, 20);
            this.textBoxSevenZipPath.TabIndex = 45;
            this.textBoxSevenZipPath.TextChanged += new System.EventHandler(this.textBoxSevenZipPath_TextChanged);
            // 
            // labelArchiveTwoPath
            // 
            this.labelArchiveTwoPath.AutoSize = true;
            this.labelArchiveTwoPath.Location = new System.Drawing.Point(7, 105);
            this.labelArchiveTwoPath.Name = "labelArchiveTwoPath";
            this.labelArchiveTwoPath.Size = new System.Drawing.Size(96, 13);
            this.labelArchiveTwoPath.TabIndex = 41;
            this.labelArchiveTwoPath.Text = "Archive2.exe path:";
            // 
            // buttonPickArchiveTwoPath
            // 
            this.buttonPickArchiveTwoPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPickArchiveTwoPath.Location = new System.Drawing.Point(353, 100);
            this.buttonPickArchiveTwoPath.Name = "buttonPickArchiveTwoPath";
            this.buttonPickArchiveTwoPath.Size = new System.Drawing.Size(28, 23);
            this.buttonPickArchiveTwoPath.TabIndex = 44;
            this.buttonPickArchiveTwoPath.Text = "...";
            this.buttonPickArchiveTwoPath.UseVisualStyleBackColor = true;
            this.buttonPickArchiveTwoPath.Click += new System.EventHandler(this.buttonPickArchiveTwoPath_Click);
            // 
            // labelSevenZipPath
            // 
            this.labelSevenZipPath.AutoSize = true;
            this.labelSevenZipPath.Location = new System.Drawing.Point(7, 134);
            this.labelSevenZipPath.Name = "labelSevenZipPath";
            this.labelSevenZipPath.Size = new System.Drawing.Size(65, 13);
            this.labelSevenZipPath.TabIndex = 42;
            this.labelSevenZipPath.Text = "7z.exe path:";
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.Controls.Add(this.checkBoxHandleNXMLinks);
            this.groupBoxOptions.Controls.Add(this.checkBoxReadOnly);
            this.groupBoxOptions.Location = new System.Drawing.Point(7, 362);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(390, 80);
            this.groupBoxOptions.TabIndex = 49;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Options";
            // 
            // checkBoxHandleNXMLinks
            // 
            this.checkBoxHandleNXMLinks.AutoSize = true;
            this.checkBoxHandleNXMLinks.Location = new System.Drawing.Point(9, 42);
            this.checkBoxHandleNXMLinks.Name = "checkBoxHandleNXMLinks";
            this.checkBoxHandleNXMLinks.Size = new System.Drawing.Size(248, 17);
            this.checkBoxHandleNXMLinks.TabIndex = 7;
            this.checkBoxHandleNXMLinks.Text = "Associate with \"Mod Manager Download\" links";
            this.checkBoxHandleNXMLinks.UseVisualStyleBackColor = true;
            // 
            // checkBoxReadOnly
            // 
            this.checkBoxReadOnly.AutoSize = true;
            this.checkBoxReadOnly.Location = new System.Drawing.Point(9, 19);
            this.checkBoxReadOnly.Name = "checkBoxReadOnly";
            this.checkBoxReadOnly.Size = new System.Drawing.Size(140, 17);
            this.checkBoxReadOnly.TabIndex = 4;
            this.checkBoxReadOnly.Text = "Make *.ini files read-only";
            this.checkBoxReadOnly.UseVisualStyleBackColor = true;
            // 
            // groupBoxNuclearWinterMode
            // 
            this.groupBoxNuclearWinterMode.Controls.Add(this.labelToggleNW);
            this.groupBoxNuclearWinterMode.Controls.Add(this.buttonNWMode);
            this.groupBoxNuclearWinterMode.Controls.Add(this.checkBoxNWAutoDeployMods);
            this.groupBoxNuclearWinterMode.Controls.Add(this.labelNWmodoptions);
            this.groupBoxNuclearWinterMode.Controls.Add(this.labelNWdlloptions);
            this.groupBoxNuclearWinterMode.Controls.Add(this.checkBoxNWAutoDisableMods);
            this.groupBoxNuclearWinterMode.Controls.Add(this.checkBoxNWRenameDLL);
            this.groupBoxNuclearWinterMode.Location = new System.Drawing.Point(7, 621);
            this.groupBoxNuclearWinterMode.Name = "groupBoxNuclearWinterMode";
            this.groupBoxNuclearWinterMode.Size = new System.Drawing.Size(390, 215);
            this.groupBoxNuclearWinterMode.TabIndex = 48;
            this.groupBoxNuclearWinterMode.TabStop = false;
            this.groupBoxNuclearWinterMode.Text = "Nuclear Winter options (deprecated)";
            // 
            // labelToggleNW
            // 
            this.labelToggleNW.AutoSize = true;
            this.labelToggleNW.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelToggleNW.Location = new System.Drawing.Point(6, 19);
            this.labelToggleNW.Name = "labelToggleNW";
            this.labelToggleNW.Size = new System.Drawing.Size(84, 13);
            this.labelToggleNW.TabIndex = 27;
            this.labelToggleNW.Text = "Toggle mode:";
            // 
            // checkBoxNWAutoDeployMods
            // 
            this.checkBoxNWAutoDeployMods.AutoSize = true;
            this.checkBoxNWAutoDeployMods.Location = new System.Drawing.Point(10, 187);
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
            this.labelNWmodoptions.Location = new System.Drawing.Point(7, 146);
            this.labelNWmodoptions.Name = "labelNWmodoptions";
            this.labelNWmodoptions.Size = new System.Drawing.Size(80, 13);
            this.labelNWmodoptions.TabIndex = 24;
            this.labelNWmodoptions.Text = "Mod options:";
            // 
            // labelNWdlloptions
            // 
            this.labelNWdlloptions.AutoSize = true;
            this.labelNWdlloptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNWdlloptions.Location = new System.Drawing.Point(7, 93);
            this.labelNWdlloptions.Name = "labelNWdlloptions";
            this.labelNWdlloptions.Size = new System.Drawing.Size(78, 13);
            this.labelNWdlloptions.TabIndex = 23;
            this.labelNWdlloptions.Text = "*.dll options:";
            // 
            // checkBoxNWAutoDisableMods
            // 
            this.checkBoxNWAutoDisableMods.AutoSize = true;
            this.checkBoxNWAutoDisableMods.Location = new System.Drawing.Point(10, 164);
            this.checkBoxNWAutoDisableMods.Name = "checkBoxNWAutoDisableMods";
            this.checkBoxNWAutoDisableMods.Size = new System.Drawing.Size(224, 17);
            this.checkBoxNWAutoDisableMods.TabIndex = 19;
            this.checkBoxNWAutoDisableMods.Text = "Automatically remove mods upon enabling";
            this.checkBoxNWAutoDisableMods.UseVisualStyleBackColor = true;
            // 
            // checkBoxNWRenameDLL
            // 
            this.checkBoxNWRenameDLL.AutoSize = true;
            this.checkBoxNWRenameDLL.Location = new System.Drawing.Point(10, 111);
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
            this.groupBoxBehavior.Location = new System.Drawing.Point(7, 155);
            this.groupBoxBehavior.Name = "groupBoxBehavior";
            this.groupBoxBehavior.Size = new System.Drawing.Size(390, 122);
            this.groupBoxBehavior.TabIndex = 47;
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
            this.checkBoxIgnoreUpdates.Size = new System.Drawing.Size(140, 17);
            this.checkBoxIgnoreUpdates.TabIndex = 24;
            this.checkBoxIgnoreUpdates.Text = "Don\'t check for updates";
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
            this.checkBoxAutoApply.Size = new System.Drawing.Size(351, 17);
            this.checkBoxAutoApply.TabIndex = 21;
            this.checkBoxAutoApply.Text = "Automatically apply changes when tool is closed or game is launched";
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
            this.groupBoxLocalization.Location = new System.Drawing.Point(7, 58);
            this.groupBoxLocalization.Name = "groupBoxLocalization";
            this.groupBoxLocalization.Size = new System.Drawing.Size(390, 91);
            this.groupBoxLocalization.TabIndex = 46;
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
            // labelSettingsDesc
            // 
            this.labelSettingsDesc.AutoSize = true;
            this.labelSettingsDesc.Location = new System.Drawing.Point(7, 30);
            this.labelSettingsDesc.Name = "labelSettingsDesc";
            this.labelSettingsDesc.Size = new System.Drawing.Size(230, 13);
            this.labelSettingsDesc.TabIndex = 74;
            this.labelSettingsDesc.Text = "These settings change the behavior of the tool.";
            // 
            // labelSettingsTitle
            // 
            this.labelSettingsTitle.AutoSize = true;
            this.labelSettingsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSettingsTitle.Location = new System.Drawing.Point(6, 6);
            this.labelSettingsTitle.Name = "labelSettingsTitle";
            this.labelSettingsTitle.Size = new System.Drawing.Size(76, 24);
            this.labelSettingsTitle.TabIndex = 73;
            this.labelSettingsTitle.Text = "Settings";
            // 
            // backgroundWorkerDownloadLanguages
            // 
            this.backgroundWorkerDownloadLanguages.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerDownloadLanguages_DoWork);
            this.backgroundWorkerDownloadLanguages.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerDownloadLanguages_RunWorkerCompleted);
            // 
            // buttonNWMode
            // 
            this.buttonNWMode.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonNWMode.BorderColor = System.Drawing.SystemColors.ButtonShadow;
            this.buttonNWMode.BorderWidth = 1;
            this.buttonNWMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonNWMode.Image = global::Fo76ini.Properties.Resources.fire;
            this.buttonNWMode.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNWMode.Location = new System.Drawing.Point(10, 35);
            this.buttonNWMode.MouseDownBackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonNWMode.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonNWMode.Name = "buttonNWMode";
            this.buttonNWMode.Padding = 10;
            this.buttonNWMode.Size = new System.Drawing.Size(187, 36);
            this.buttonNWMode.TabIndex = 26;
            this.buttonNWMode.Text = "Nuclear Winter";
            this.buttonNWMode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonNWMode.UseVisualStyleBackColor = true;
            this.buttonNWMode.Click += new System.EventHandler(this.buttonNWMode_Click);
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 20000;
            this.toolTip.InitialDelay = 500;
            this.toolTip.IsBalloon = true;
            this.toolTip.ReshowDelay = 100;
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
            // UserControlSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.labelSettingsDesc);
            this.Controls.Add(this.labelSettingsTitle);
            this.Controls.Add(this.groupBoxUI);
            this.Controls.Add(this.groupBoxPaths);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.groupBoxNuclearWinterMode);
            this.Controls.Add(this.groupBoxBehavior);
            this.Controls.Add(this.groupBoxLocalization);
            this.Name = "UserControlSettings";
            this.Size = new System.Drawing.Size(632, 600);
            this.Load += new System.EventHandler(this.UserControlSettings_Load);
            this.groupBoxUI.ResumeLayout(false);
            this.groupBoxUI.PerformLayout();
            this.groupBoxPaths.ResumeLayout(false);
            this.groupBoxPaths.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            this.groupBoxNuclearWinterMode.ResumeLayout(false);
            this.groupBoxNuclearWinterMode.PerformLayout();
            this.groupBoxBehavior.ResumeLayout(false);
            this.groupBoxBehavior.PerformLayout();
            this.groupBoxLocalization.ResumeLayout(false);
            this.groupBoxLocalization.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpinnerDownloadLanguages)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxUI;
        private System.Windows.Forms.CheckBox checkBoxShowWhatsNew;
        private System.Windows.Forms.GroupBox groupBoxPaths;
        private System.Windows.Forms.TextBox textBoxDownloadsPath;
        private System.Windows.Forms.Label labelDownloadsPath;
        private System.Windows.Forms.Button buttonPickDownloadsPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPickSevenZipPath;
        private System.Windows.Forms.TextBox textBoxArchiveTwoPath;
        private System.Windows.Forms.TextBox textBoxSevenZipPath;
        private System.Windows.Forms.Label labelArchiveTwoPath;
        private System.Windows.Forms.Button buttonPickArchiveTwoPath;
        private System.Windows.Forms.Label labelSevenZipPath;
        private System.Windows.Forms.GroupBox groupBoxOptions;
        private System.Windows.Forms.CheckBox checkBoxHandleNXMLinks;
        private System.Windows.Forms.CheckBox checkBoxReadOnly;
        private System.Windows.Forms.GroupBox groupBoxNuclearWinterMode;
        private System.Windows.Forms.CheckBox checkBoxNWAutoDeployMods;
        private System.Windows.Forms.Label labelNWmodoptions;
        private System.Windows.Forms.Label labelNWdlloptions;
        private System.Windows.Forms.CheckBox checkBoxNWAutoDisableMods;
        private System.Windows.Forms.CheckBox checkBoxNWRenameDLL;
        private System.Windows.Forms.GroupBox groupBoxBehavior;
        private System.Windows.Forms.CheckBox checkBoxPlayNotificationSound;
        private System.Windows.Forms.CheckBox checkBoxIgnoreUpdates;
        private System.Windows.Forms.CheckBox checkBoxQuitOnGameLaunch;
        private System.Windows.Forms.CheckBox checkBoxAutoApply;
        private System.Windows.Forms.GroupBox groupBoxLocalization;
        private System.Windows.Forms.Button buttonRefreshLanguage;
        private System.Windows.Forms.PictureBox pictureBoxSpinnerDownloadLanguages;
        public System.Windows.Forms.Label labelOutdatedLanguage;
        private System.Windows.Forms.Label labelLanguage;
        private System.Windows.Forms.Button buttonDownloadLanguages;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label labelSettingsDesc;
        private System.Windows.Forms.Label labelSettingsTitle;
        private Controls.StyledButton buttonNWMode;
        private System.Windows.Forms.Label labelToggleNW;
        private System.ComponentModel.BackgroundWorker backgroundWorkerDownloadLanguages;
        public System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.OpenFileDialog openFileDialogArchiveTwoPath;
        private System.Windows.Forms.OpenFileDialog openFileDialogSevenZipPath;
    }
}
