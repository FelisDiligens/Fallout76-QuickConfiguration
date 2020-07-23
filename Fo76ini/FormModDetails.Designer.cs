namespace Fo76ini
{
    partial class FormModDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModDetails));
            this.textBoxModArchiveName = new System.Windows.Forms.TextBox();
            this.labelModArchiveName = new System.Windows.Forms.Label();
            this.buttonModPickRootDir = new System.Windows.Forms.Button();
            this.textBoxModRootDir = new System.Windows.Forms.TextBox();
            this.labelModInstallInto = new System.Windows.Forms.Label();
            this.labelModName = new System.Windows.Forms.Label();
            this.textBoxModName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxModDetailsEnabled = new System.Windows.Forms.CheckBox();
            this.labelModDetailsBulkFrozenModsWarning = new System.Windows.Forms.Label();
            this.labelModUnfreeze = new System.Windows.Forms.Label();
            this.buttonModUnfreeze = new System.Windows.Forms.Button();
            this.checkBoxFreezeArchive = new System.Windows.Forms.CheckBox();
            this.buttonModRepairDDS = new System.Windows.Forms.Button();
            this.comboBoxModArchivePreset = new System.Windows.Forms.ComboBox();
            this.buttonModOpenFolder = new System.Windows.Forms.Button();
            this.labelModFolderName = new System.Windows.Forms.Label();
            this.labelModArchivePreset = new System.Windows.Forms.Label();
            this.textBoxModFolderName = new System.Windows.Forms.TextBox();
            this.comboBoxModInstallAs = new System.Windows.Forms.ComboBox();
            this.labelModInstallAs = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelModDetailsStatus = new System.Windows.Forms.Label();
            this.buttonModDetailsApply = new System.Windows.Forms.Button();
            this.buttonModDetailsOK = new System.Windows.Forms.Button();
            this.buttonModDetailsCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialogPickRootDir = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.groupBoxModDetailsDetails = new System.Windows.Forms.GroupBox();
            this.groupBoxModDetailsInstallationOptions = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            this.groupBoxModDetailsDetails.SuspendLayout();
            this.groupBoxModDetailsInstallationOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxModArchiveName
            // 
            this.textBoxModArchiveName.Location = new System.Drawing.Point(124, 70);
            this.textBoxModArchiveName.Name = "textBoxModArchiveName";
            this.textBoxModArchiveName.Size = new System.Drawing.Size(206, 20);
            this.textBoxModArchiveName.TabIndex = 7;
            this.textBoxModArchiveName.TextChanged += new System.EventHandler(this.textBoxModArchiveName_TextChanged);
            // 
            // labelModArchiveName
            // 
            this.labelModArchiveName.AutoSize = true;
            this.labelModArchiveName.Location = new System.Drawing.Point(7, 73);
            this.labelModArchiveName.Name = "labelModArchiveName";
            this.labelModArchiveName.Size = new System.Drawing.Size(75, 13);
            this.labelModArchiveName.TabIndex = 41;
            this.labelModArchiveName.Text = "Archive name:";
            // 
            // buttonModPickRootDir
            // 
            this.buttonModPickRootDir.Location = new System.Drawing.Point(304, 44);
            this.buttonModPickRootDir.Name = "buttonModPickRootDir";
            this.buttonModPickRootDir.Size = new System.Drawing.Size(26, 23);
            this.buttonModPickRootDir.TabIndex = 5;
            this.buttonModPickRootDir.Text = "...";
            this.buttonModPickRootDir.UseVisualStyleBackColor = true;
            this.buttonModPickRootDir.Click += new System.EventHandler(this.buttonModPickRootDir_Click);
            // 
            // textBoxModRootDir
            // 
            this.textBoxModRootDir.Location = new System.Drawing.Point(124, 46);
            this.textBoxModRootDir.Name = "textBoxModRootDir";
            this.textBoxModRootDir.Size = new System.Drawing.Size(174, 20);
            this.textBoxModRootDir.TabIndex = 4;
            this.textBoxModRootDir.TextChanged += new System.EventHandler(this.textBoxModRootDir_TextChanged);
            // 
            // labelModInstallInto
            // 
            this.labelModInstallInto.AutoSize = true;
            this.labelModInstallInto.Location = new System.Drawing.Point(6, 49);
            this.labelModInstallInto.Name = "labelModInstallInto";
            this.labelModInstallInto.Size = new System.Drawing.Size(57, 13);
            this.labelModInstallInto.TabIndex = 38;
            this.labelModInstallInto.Text = "Install into:";
            // 
            // labelModName
            // 
            this.labelModName.AutoSize = true;
            this.labelModName.Location = new System.Drawing.Point(7, 22);
            this.labelModName.Name = "labelModName";
            this.labelModName.Size = new System.Drawing.Size(60, 13);
            this.labelModName.TabIndex = 25;
            this.labelModName.Text = "Mod name:";
            // 
            // textBoxModName
            // 
            this.textBoxModName.Location = new System.Drawing.Point(124, 19);
            this.textBoxModName.Name = "textBoxModName";
            this.textBoxModName.Size = new System.Drawing.Size(206, 20);
            this.textBoxModName.TabIndex = 1;
            this.textBoxModName.TextChanged += new System.EventHandler(this.textBoxModName_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.groupBoxModDetailsInstallationOptions);
            this.panel1.Controls.Add(this.labelModUnfreeze);
            this.panel1.Controls.Add(this.groupBoxModDetailsDetails);
            this.panel1.Controls.Add(this.buttonModUnfreeze);
            this.panel1.Controls.Add(this.buttonModRepairDDS);
            this.panel1.Controls.Add(this.buttonModOpenFolder);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(6, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(352, 365);
            this.panel1.TabIndex = 44;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // checkBoxModDetailsEnabled
            // 
            this.checkBoxModDetailsEnabled.AutoSize = true;
            this.checkBoxModDetailsEnabled.Location = new System.Drawing.Point(12, 12);
            this.checkBoxModDetailsEnabled.Name = "checkBoxModDetailsEnabled";
            this.checkBoxModDetailsEnabled.Size = new System.Drawing.Size(101, 17);
            this.checkBoxModDetailsEnabled.TabIndex = 0;
            this.checkBoxModDetailsEnabled.Text = "Enable this mod";
            this.checkBoxModDetailsEnabled.UseVisualStyleBackColor = true;
            this.checkBoxModDetailsEnabled.CheckedChanged += new System.EventHandler(this.checkBoxModDetailsEnabled_CheckedChanged);
            // 
            // labelModDetailsBulkFrozenModsWarning
            // 
            this.labelModDetailsBulkFrozenModsWarning.AutoSize = true;
            this.labelModDetailsBulkFrozenModsWarning.ForeColor = System.Drawing.Color.Red;
            this.labelModDetailsBulkFrozenModsWarning.Location = new System.Drawing.Point(12, 13);
            this.labelModDetailsBulkFrozenModsWarning.Name = "labelModDetailsBulkFrozenModsWarning";
            this.labelModDetailsBulkFrozenModsWarning.Size = new System.Drawing.Size(176, 13);
            this.labelModDetailsBulkFrozenModsWarning.TabIndex = 59;
            this.labelModDetailsBulkFrozenModsWarning.Text = "NOTE: Frozen mods will be ignored.";
            // 
            // labelModUnfreeze
            // 
            this.labelModUnfreeze.AutoSize = true;
            this.labelModUnfreeze.ForeColor = System.Drawing.Color.Red;
            this.labelModUnfreeze.Location = new System.Drawing.Point(7, 267);
            this.labelModUnfreeze.Name = "labelModUnfreeze";
            this.labelModUnfreeze.Size = new System.Drawing.Size(287, 13);
            this.labelModUnfreeze.TabIndex = 57;
            this.labelModUnfreeze.Text = "Installation options are disabled, because the mod is frozen.";
            // 
            // buttonModUnfreeze
            // 
            this.buttonModUnfreeze.Location = new System.Drawing.Point(7, 283);
            this.buttonModUnfreeze.Name = "buttonModUnfreeze";
            this.buttonModUnfreeze.Size = new System.Drawing.Size(336, 23);
            this.buttonModUnfreeze.TabIndex = 56;
            this.buttonModUnfreeze.TabStop = false;
            this.buttonModUnfreeze.Text = "Unfreeze";
            this.buttonModUnfreeze.UseVisualStyleBackColor = true;
            this.buttonModUnfreeze.Click += new System.EventHandler(this.buttonModUnfreeze_Click);
            // 
            // checkBoxFreezeArchive
            // 
            this.checkBoxFreezeArchive.AutoSize = true;
            this.checkBoxFreezeArchive.Location = new System.Drawing.Point(9, 100);
            this.checkBoxFreezeArchive.Name = "checkBoxFreezeArchive";
            this.checkBoxFreezeArchive.Size = new System.Drawing.Size(58, 17);
            this.checkBoxFreezeArchive.TabIndex = 9;
            this.checkBoxFreezeArchive.Text = "Freeze";
            this.toolTip.SetToolTip(this.checkBoxFreezeArchive, "If you \'freeze\' an archive, it does not get recreated when deploying.\r\nThis will " +
        "speed up deployment.\r\n\r\nThis is especially useful, if the archive is HUGE (1GiB " +
        "or more) and the files aren\'t changing.");
            this.checkBoxFreezeArchive.UseVisualStyleBackColor = true;
            this.checkBoxFreezeArchive.CheckedChanged += new System.EventHandler(this.checkBoxFreezeArchive_CheckedChanged);
            // 
            // buttonModRepairDDS
            // 
            this.buttonModRepairDDS.Location = new System.Drawing.Point(7, 328);
            this.buttonModRepairDDS.Name = "buttonModRepairDDS";
            this.buttonModRepairDDS.Size = new System.Drawing.Size(202, 23);
            this.buttonModRepairDDS.TabIndex = 52;
            this.buttonModRepairDDS.TabStop = false;
            this.buttonModRepairDDS.Text = "Repair *.dds files";
            this.buttonModRepairDDS.UseVisualStyleBackColor = true;
            this.buttonModRepairDDS.Click += new System.EventHandler(this.buttonModRepairDDS_Click);
            // 
            // comboBoxModArchivePreset
            // 
            this.comboBoxModArchivePreset.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModArchivePreset.FormattingEnabled = true;
            this.comboBoxModArchivePreset.Location = new System.Drawing.Point(124, 72);
            this.comboBoxModArchivePreset.Name = "comboBoxModArchivePreset";
            this.comboBoxModArchivePreset.Size = new System.Drawing.Size(206, 21);
            this.comboBoxModArchivePreset.TabIndex = 6;
            this.comboBoxModArchivePreset.SelectedIndexChanged += new System.EventHandler(this.comboBoxModArchiveFormat_SelectedIndexChanged);
            // 
            // buttonModOpenFolder
            // 
            this.buttonModOpenFolder.Location = new System.Drawing.Point(218, 328);
            this.buttonModOpenFolder.Name = "buttonModOpenFolder";
            this.buttonModOpenFolder.Size = new System.Drawing.Size(125, 23);
            this.buttonModOpenFolder.TabIndex = 48;
            this.buttonModOpenFolder.TabStop = false;
            this.buttonModOpenFolder.Text = "Open folder";
            this.buttonModOpenFolder.UseVisualStyleBackColor = true;
            this.buttonModOpenFolder.Click += new System.EventHandler(this.buttonModOpenFolder_Click);
            // 
            // labelModFolderName
            // 
            this.labelModFolderName.AutoSize = true;
            this.labelModFolderName.Location = new System.Drawing.Point(7, 47);
            this.labelModFolderName.Name = "labelModFolderName";
            this.labelModFolderName.Size = new System.Drawing.Size(89, 13);
            this.labelModFolderName.TabIndex = 47;
            this.labelModFolderName.Text = "Mod folder name:";
            // 
            // labelModArchivePreset
            // 
            this.labelModArchivePreset.AutoSize = true;
            this.labelModArchivePreset.Location = new System.Drawing.Point(6, 75);
            this.labelModArchivePreset.Name = "labelModArchivePreset";
            this.labelModArchivePreset.Size = new System.Drawing.Size(40, 13);
            this.labelModArchivePreset.TabIndex = 43;
            this.labelModArchivePreset.Text = "Preset:";
            // 
            // textBoxModFolderName
            // 
            this.textBoxModFolderName.Location = new System.Drawing.Point(124, 44);
            this.textBoxModFolderName.Name = "textBoxModFolderName";
            this.textBoxModFolderName.Size = new System.Drawing.Size(206, 20);
            this.textBoxModFolderName.TabIndex = 2;
            this.textBoxModFolderName.TextChanged += new System.EventHandler(this.textBoxModFolderName_TextChanged);
            // 
            // comboBoxModInstallAs
            // 
            this.comboBoxModInstallAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModInstallAs.FormattingEnabled = true;
            this.comboBoxModInstallAs.Location = new System.Drawing.Point(124, 19);
            this.comboBoxModInstallAs.Name = "comboBoxModInstallAs";
            this.comboBoxModInstallAs.Size = new System.Drawing.Size(206, 21);
            this.comboBoxModInstallAs.TabIndex = 3;
            this.comboBoxModInstallAs.SelectedIndexChanged += new System.EventHandler(this.comboBoxModInstallAs_SelectedIndexChanged);
            // 
            // labelModInstallAs
            // 
            this.labelModInstallAs.AutoSize = true;
            this.labelModInstallAs.Location = new System.Drawing.Point(6, 22);
            this.labelModInstallAs.Name = "labelModInstallAs";
            this.labelModInstallAs.Size = new System.Drawing.Size(51, 13);
            this.labelModInstallAs.TabIndex = 41;
            this.labelModInstallAs.Text = "Install as:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(6, 419);
            this.progressBar1.MarqueeAnimationSpeed = 15;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(349, 23);
            this.progressBar1.TabIndex = 58;
            // 
            // labelModDetailsStatus
            // 
            this.labelModDetailsStatus.AutoSize = true;
            this.labelModDetailsStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelModDetailsStatus.Location = new System.Drawing.Point(3, 403);
            this.labelModDetailsStatus.Name = "labelModDetailsStatus";
            this.labelModDetailsStatus.Size = new System.Drawing.Size(16, 13);
            this.labelModDetailsStatus.TabIndex = 53;
            this.labelModDetailsStatus.Text = "...";
            this.labelModDetailsStatus.Visible = false;
            // 
            // buttonModDetailsApply
            // 
            this.buttonModDetailsApply.Location = new System.Drawing.Point(280, 448);
            this.buttonModDetailsApply.Name = "buttonModDetailsApply";
            this.buttonModDetailsApply.Size = new System.Drawing.Size(75, 23);
            this.buttonModDetailsApply.TabIndex = 12;
            this.buttonModDetailsApply.TabStop = false;
            this.buttonModDetailsApply.Text = "Apply";
            this.buttonModDetailsApply.UseVisualStyleBackColor = true;
            this.buttonModDetailsApply.Click += new System.EventHandler(this.buttonModDetailsApply_Click);
            // 
            // buttonModDetailsOK
            // 
            this.buttonModDetailsOK.Location = new System.Drawing.Point(118, 448);
            this.buttonModDetailsOK.Name = "buttonModDetailsOK";
            this.buttonModDetailsOK.Size = new System.Drawing.Size(75, 23);
            this.buttonModDetailsOK.TabIndex = 10;
            this.buttonModDetailsOK.TabStop = false;
            this.buttonModDetailsOK.Text = "OK";
            this.buttonModDetailsOK.UseVisualStyleBackColor = true;
            this.buttonModDetailsOK.Click += new System.EventHandler(this.buttonModDetailsOK_Click);
            // 
            // buttonModDetailsCancel
            // 
            this.buttonModDetailsCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonModDetailsCancel.Location = new System.Drawing.Point(199, 448);
            this.buttonModDetailsCancel.Name = "buttonModDetailsCancel";
            this.buttonModDetailsCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonModDetailsCancel.TabIndex = 11;
            this.buttonModDetailsCancel.TabStop = false;
            this.buttonModDetailsCancel.Text = "Cancel";
            this.buttonModDetailsCancel.UseVisualStyleBackColor = true;
            this.buttonModDetailsCancel.Click += new System.EventHandler(this.buttonModDetailsCancel_Click);
            // 
            // groupBoxModDetailsDetails
            // 
            this.groupBoxModDetailsDetails.Controls.Add(this.textBoxModName);
            this.groupBoxModDetailsDetails.Controls.Add(this.labelModName);
            this.groupBoxModDetailsDetails.Controls.Add(this.textBoxModFolderName);
            this.groupBoxModDetailsDetails.Controls.Add(this.labelModFolderName);
            this.groupBoxModDetailsDetails.Controls.Add(this.textBoxModArchiveName);
            this.groupBoxModDetailsDetails.Controls.Add(this.labelModArchiveName);
            this.groupBoxModDetailsDetails.Location = new System.Drawing.Point(7, 9);
            this.groupBoxModDetailsDetails.Name = "groupBoxModDetailsDetails";
            this.groupBoxModDetailsDetails.Size = new System.Drawing.Size(336, 109);
            this.groupBoxModDetailsDetails.TabIndex = 59;
            this.groupBoxModDetailsDetails.TabStop = false;
            this.groupBoxModDetailsDetails.Text = "Details";
            // 
            // groupBoxModDetailsInstallationOptions
            // 
            this.groupBoxModDetailsInstallationOptions.Controls.Add(this.labelModInstallAs);
            this.groupBoxModDetailsInstallationOptions.Controls.Add(this.labelModInstallInto);
            this.groupBoxModDetailsInstallationOptions.Controls.Add(this.textBoxModRootDir);
            this.groupBoxModDetailsInstallationOptions.Controls.Add(this.checkBoxFreezeArchive);
            this.groupBoxModDetailsInstallationOptions.Controls.Add(this.comboBoxModInstallAs);
            this.groupBoxModDetailsInstallationOptions.Controls.Add(this.labelModArchivePreset);
            this.groupBoxModDetailsInstallationOptions.Controls.Add(this.buttonModPickRootDir);
            this.groupBoxModDetailsInstallationOptions.Controls.Add(this.comboBoxModArchivePreset);
            this.groupBoxModDetailsInstallationOptions.Location = new System.Drawing.Point(7, 124);
            this.groupBoxModDetailsInstallationOptions.Name = "groupBoxModDetailsInstallationOptions";
            this.groupBoxModDetailsInstallationOptions.Size = new System.Drawing.Size(336, 126);
            this.groupBoxModDetailsInstallationOptions.TabIndex = 60;
            this.groupBoxModDetailsInstallationOptions.TabStop = false;
            this.groupBoxModDetailsInstallationOptions.Text = "Installation options";
            // 
            // FormModDetails
            // 
            this.AcceptButton = this.buttonModDetailsOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonModDetailsCancel;
            this.ClientSize = new System.Drawing.Size(361, 477);
            this.Controls.Add(this.checkBoxModDetailsEnabled);
            this.Controls.Add(this.labelModDetailsBulkFrozenModsWarning);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonModDetailsCancel);
            this.Controls.Add(this.buttonModDetailsOK);
            this.Controls.Add(this.labelModDetailsStatus);
            this.Controls.Add(this.buttonModDetailsApply);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(377, 516);
            this.Name = "FormModDetails";
            this.ShowInTaskbar = false;
            this.Text = "Edit mod details";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxModDetailsDetails.ResumeLayout(false);
            this.groupBoxModDetailsDetails.PerformLayout();
            this.groupBoxModDetailsInstallationOptions.ResumeLayout(false);
            this.groupBoxModDetailsInstallationOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxModArchiveName;
        private System.Windows.Forms.Label labelModArchiveName;
        private System.Windows.Forms.Button buttonModPickRootDir;
        private System.Windows.Forms.TextBox textBoxModRootDir;
        private System.Windows.Forms.Label labelModInstallInto;
        private System.Windows.Forms.Label labelModName;
        private System.Windows.Forms.TextBox textBoxModName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonModDetailsApply;
        private System.Windows.Forms.Button buttonModDetailsOK;
        private System.Windows.Forms.Button buttonModDetailsCancel;
        private System.Windows.Forms.Label labelModInstallAs;
        private System.Windows.Forms.ComboBox comboBoxModArchivePreset;
        private System.Windows.Forms.Label labelModArchivePreset;
        private System.Windows.Forms.ComboBox comboBoxModInstallAs;
        private System.Windows.Forms.Label labelModFolderName;
        private System.Windows.Forms.TextBox textBoxModFolderName;
        private System.Windows.Forms.Button buttonModOpenFolder;
        private System.Windows.Forms.CheckBox checkBoxModDetailsEnabled;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogPickRootDir;
        public System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonModRepairDDS;
        private System.Windows.Forms.Label labelModDetailsStatus;
        private System.Windows.Forms.CheckBox checkBoxFreezeArchive;
        private System.Windows.Forms.Label labelModUnfreeze;
        private System.Windows.Forms.Button buttonModUnfreeze;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelModDetailsBulkFrozenModsWarning;
        private System.Windows.Forms.GroupBox groupBoxModDetailsInstallationOptions;
        private System.Windows.Forms.GroupBox groupBoxModDetailsDetails;
    }
}