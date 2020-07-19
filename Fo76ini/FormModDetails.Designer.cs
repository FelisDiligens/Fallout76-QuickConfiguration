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
            this.checkBoxModBA2Compression = new System.Windows.Forms.CheckBox();
            this.buttonModPickRootDir = new System.Windows.Forms.Button();
            this.textBoxModRootDir = new System.Windows.Forms.TextBox();
            this.labelModInstallInto = new System.Windows.Forms.Label();
            this.labelModName = new System.Windows.Forms.Label();
            this.textBoxModName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxModDetailsEnabled = new System.Windows.Forms.CheckBox();
            this.labelModDetailsBulkFrozenModsWarning = new System.Windows.Forms.Label();
            this.groupBoxSeparateArchivePresets = new System.Windows.Forms.GroupBox();
            this.radioButtonSeparateArchiveCustom = new System.Windows.Forms.RadioButton();
            this.radioButtonSeparateArchiveSounds = new System.Windows.Forms.RadioButton();
            this.radioButtonSeparateArchiveTextures = new System.Windows.Forms.RadioButton();
            this.radioButtonSeparateArchiveGeneral = new System.Windows.Forms.RadioButton();
            this.labelModUnfreeze = new System.Windows.Forms.Label();
            this.buttonModUnfreeze = new System.Windows.Forms.Button();
            this.checkBoxFreezeArchive = new System.Windows.Forms.CheckBox();
            this.buttonModRepairDDS = new System.Windows.Forms.Button();
            this.separator2 = new System.Windows.Forms.Label();
            this.separator1 = new System.Windows.Forms.Label();
            this.comboBoxModArchiveFormat = new System.Windows.Forms.ComboBox();
            this.buttonModOpenFolder = new System.Windows.Forms.Button();
            this.labelModFolderName = new System.Windows.Forms.Label();
            this.labelModArchiveFormat = new System.Windows.Forms.Label();
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
            this.panel1.SuspendLayout();
            this.groupBoxSeparateArchivePresets.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxModArchiveName
            // 
            this.textBoxModArchiveName.Location = new System.Drawing.Point(125, 174);
            this.textBoxModArchiveName.Name = "textBoxModArchiveName";
            this.textBoxModArchiveName.Size = new System.Drawing.Size(218, 20);
            this.textBoxModArchiveName.TabIndex = 7;
            this.textBoxModArchiveName.TextChanged += new System.EventHandler(this.textBoxModArchiveName_TextChanged);
            // 
            // labelModArchiveName
            // 
            this.labelModArchiveName.AutoSize = true;
            this.labelModArchiveName.Location = new System.Drawing.Point(7, 177);
            this.labelModArchiveName.Name = "labelModArchiveName";
            this.labelModArchiveName.Size = new System.Drawing.Size(75, 13);
            this.labelModArchiveName.TabIndex = 41;
            this.labelModArchiveName.Text = "Archive name:";
            // 
            // checkBoxModBA2Compression
            // 
            this.checkBoxModBA2Compression.AutoSize = true;
            this.checkBoxModBA2Compression.Location = new System.Drawing.Point(10, 200);
            this.checkBoxModBA2Compression.Name = "checkBoxModBA2Compression";
            this.checkBoxModBA2Compression.Size = new System.Drawing.Size(110, 17);
            this.checkBoxModBA2Compression.TabIndex = 8;
            this.checkBoxModBA2Compression.Text = "Compress archive";
            this.checkBoxModBA2Compression.UseVisualStyleBackColor = true;
            this.checkBoxModBA2Compression.CheckedChanged += new System.EventHandler(this.checkBoxModBA2Compression_CheckedChanged);
            // 
            // buttonModPickRootDir
            // 
            this.buttonModPickRootDir.Location = new System.Drawing.Point(317, 119);
            this.buttonModPickRootDir.Name = "buttonModPickRootDir";
            this.buttonModPickRootDir.Size = new System.Drawing.Size(26, 23);
            this.buttonModPickRootDir.TabIndex = 5;
            this.buttonModPickRootDir.Text = "...";
            this.buttonModPickRootDir.UseVisualStyleBackColor = true;
            this.buttonModPickRootDir.Click += new System.EventHandler(this.buttonModPickRootDir_Click);
            // 
            // textBoxModRootDir
            // 
            this.textBoxModRootDir.Location = new System.Drawing.Point(125, 121);
            this.textBoxModRootDir.Name = "textBoxModRootDir";
            this.textBoxModRootDir.Size = new System.Drawing.Size(186, 20);
            this.textBoxModRootDir.TabIndex = 4;
            this.textBoxModRootDir.TextChanged += new System.EventHandler(this.textBoxModRootDir_TextChanged);
            // 
            // labelModInstallInto
            // 
            this.labelModInstallInto.AutoSize = true;
            this.labelModInstallInto.Location = new System.Drawing.Point(7, 124);
            this.labelModInstallInto.Name = "labelModInstallInto";
            this.labelModInstallInto.Size = new System.Drawing.Size(57, 13);
            this.labelModInstallInto.TabIndex = 38;
            this.labelModInstallInto.Text = "Install into:";
            // 
            // labelModName
            // 
            this.labelModName.AutoSize = true;
            this.labelModName.Location = new System.Drawing.Point(7, 32);
            this.labelModName.Name = "labelModName";
            this.labelModName.Size = new System.Drawing.Size(60, 13);
            this.labelModName.TabIndex = 25;
            this.labelModName.Text = "Mod name:";
            // 
            // textBoxModName
            // 
            this.textBoxModName.Location = new System.Drawing.Point(125, 29);
            this.textBoxModName.Name = "textBoxModName";
            this.textBoxModName.Size = new System.Drawing.Size(218, 20);
            this.textBoxModName.TabIndex = 1;
            this.textBoxModName.TextChanged += new System.EventHandler(this.textBoxModName_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.checkBoxModDetailsEnabled);
            this.panel1.Controls.Add(this.labelModDetailsBulkFrozenModsWarning);
            this.panel1.Controls.Add(this.groupBoxSeparateArchivePresets);
            this.panel1.Controls.Add(this.labelModUnfreeze);
            this.panel1.Controls.Add(this.buttonModUnfreeze);
            this.panel1.Controls.Add(this.checkBoxFreezeArchive);
            this.panel1.Controls.Add(this.buttonModRepairDDS);
            this.panel1.Controls.Add(this.separator2);
            this.panel1.Controls.Add(this.checkBoxModBA2Compression);
            this.panel1.Controls.Add(this.labelModArchiveName);
            this.panel1.Controls.Add(this.textBoxModArchiveName);
            this.panel1.Controls.Add(this.separator1);
            this.panel1.Controls.Add(this.comboBoxModArchiveFormat);
            this.panel1.Controls.Add(this.buttonModOpenFolder);
            this.panel1.Controls.Add(this.labelModFolderName);
            this.panel1.Controls.Add(this.labelModArchiveFormat);
            this.panel1.Controls.Add(this.textBoxModFolderName);
            this.panel1.Controls.Add(this.comboBoxModInstallAs);
            this.panel1.Controls.Add(this.labelModInstallAs);
            this.panel1.Controls.Add(this.labelModName);
            this.panel1.Controls.Add(this.buttonModPickRootDir);
            this.panel1.Controls.Add(this.textBoxModName);
            this.panel1.Controls.Add(this.textBoxModRootDir);
            this.panel1.Controls.Add(this.labelModInstallInto);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(5, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(349, 394);
            this.panel1.TabIndex = 44;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // checkBoxModDetailsEnabled
            // 
            this.checkBoxModDetailsEnabled.AutoSize = true;
            this.checkBoxModDetailsEnabled.Location = new System.Drawing.Point(10, 7);
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
            this.labelModDetailsBulkFrozenModsWarning.Location = new System.Drawing.Point(7, 8);
            this.labelModDetailsBulkFrozenModsWarning.Name = "labelModDetailsBulkFrozenModsWarning";
            this.labelModDetailsBulkFrozenModsWarning.Size = new System.Drawing.Size(176, 13);
            this.labelModDetailsBulkFrozenModsWarning.TabIndex = 59;
            this.labelModDetailsBulkFrozenModsWarning.Text = "NOTE: Frozen mods will be ignored.";
            // 
            // groupBoxSeparateArchivePresets
            // 
            this.groupBoxSeparateArchivePresets.Controls.Add(this.radioButtonSeparateArchiveCustom);
            this.groupBoxSeparateArchivePresets.Controls.Add(this.radioButtonSeparateArchiveSounds);
            this.groupBoxSeparateArchivePresets.Controls.Add(this.radioButtonSeparateArchiveTextures);
            this.groupBoxSeparateArchivePresets.Controls.Add(this.radioButtonSeparateArchiveGeneral);
            this.groupBoxSeparateArchivePresets.Location = new System.Drawing.Point(126, 200);
            this.groupBoxSeparateArchivePresets.Name = "groupBoxSeparateArchivePresets";
            this.groupBoxSeparateArchivePresets.Size = new System.Drawing.Size(217, 109);
            this.groupBoxSeparateArchivePresets.TabIndex = 58;
            this.groupBoxSeparateArchivePresets.TabStop = false;
            this.groupBoxSeparateArchivePresets.Text = "Presets";
            // 
            // radioButtonSeparateArchiveCustom
            // 
            this.radioButtonSeparateArchiveCustom.AutoSize = true;
            this.radioButtonSeparateArchiveCustom.Location = new System.Drawing.Point(6, 88);
            this.radioButtonSeparateArchiveCustom.Name = "radioButtonSeparateArchiveCustom";
            this.radioButtonSeparateArchiveCustom.Size = new System.Drawing.Size(60, 17);
            this.radioButtonSeparateArchiveCustom.TabIndex = 3;
            this.radioButtonSeparateArchiveCustom.Text = "Custom";
            this.radioButtonSeparateArchiveCustom.UseVisualStyleBackColor = true;
            // 
            // radioButtonSeparateArchiveSounds
            // 
            this.radioButtonSeparateArchiveSounds.AutoSize = true;
            this.radioButtonSeparateArchiveSounds.Location = new System.Drawing.Point(6, 65);
            this.radioButtonSeparateArchiveSounds.Name = "radioButtonSeparateArchiveSounds";
            this.radioButtonSeparateArchiveSounds.Size = new System.Drawing.Size(61, 17);
            this.radioButtonSeparateArchiveSounds.TabIndex = 2;
            this.radioButtonSeparateArchiveSounds.Text = "Sounds";
            this.radioButtonSeparateArchiveSounds.UseVisualStyleBackColor = true;
            this.radioButtonSeparateArchiveSounds.CheckedChanged += new System.EventHandler(this.radioButtonSeparateArchiveSounds_CheckedChanged);
            // 
            // radioButtonSeparateArchiveTextures
            // 
            this.radioButtonSeparateArchiveTextures.AutoSize = true;
            this.radioButtonSeparateArchiveTextures.Location = new System.Drawing.Point(6, 42);
            this.radioButtonSeparateArchiveTextures.Name = "radioButtonSeparateArchiveTextures";
            this.radioButtonSeparateArchiveTextures.Size = new System.Drawing.Size(120, 17);
            this.radioButtonSeparateArchiveTextures.TabIndex = 1;
            this.radioButtonSeparateArchiveTextures.Text = "Textures (*.dds files)";
            this.radioButtonSeparateArchiveTextures.UseVisualStyleBackColor = true;
            this.radioButtonSeparateArchiveTextures.CheckedChanged += new System.EventHandler(this.radioButtonSeparateArchiveTextures_CheckedChanged);
            // 
            // radioButtonSeparateArchiveGeneral
            // 
            this.radioButtonSeparateArchiveGeneral.AutoSize = true;
            this.radioButtonSeparateArchiveGeneral.Location = new System.Drawing.Point(6, 19);
            this.radioButtonSeparateArchiveGeneral.Name = "radioButtonSeparateArchiveGeneral";
            this.radioButtonSeparateArchiveGeneral.Size = new System.Drawing.Size(168, 17);
            this.radioButtonSeparateArchiveGeneral.TabIndex = 0;
            this.radioButtonSeparateArchiveGeneral.Text = "General / Interface / Materials";
            this.radioButtonSeparateArchiveGeneral.UseVisualStyleBackColor = true;
            this.radioButtonSeparateArchiveGeneral.CheckedChanged += new System.EventHandler(this.radioButtonSeparateArchiveGeneral_CheckedChanged);
            // 
            // labelModUnfreeze
            // 
            this.labelModUnfreeze.AutoSize = true;
            this.labelModUnfreeze.ForeColor = System.Drawing.Color.Red;
            this.labelModUnfreeze.Location = new System.Drawing.Point(7, 249);
            this.labelModUnfreeze.Name = "labelModUnfreeze";
            this.labelModUnfreeze.Size = new System.Drawing.Size(287, 13);
            this.labelModUnfreeze.TabIndex = 57;
            this.labelModUnfreeze.Text = "Installation options are disabled, because the mod is frozen.";
            // 
            // buttonModUnfreeze
            // 
            this.buttonModUnfreeze.Location = new System.Drawing.Point(7, 265);
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
            this.checkBoxFreezeArchive.Location = new System.Drawing.Point(10, 223);
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
            this.buttonModRepairDDS.Location = new System.Drawing.Point(7, 361);
            this.buttonModRepairDDS.Name = "buttonModRepairDDS";
            this.buttonModRepairDDS.Size = new System.Drawing.Size(202, 23);
            this.buttonModRepairDDS.TabIndex = 52;
            this.buttonModRepairDDS.TabStop = false;
            this.buttonModRepairDDS.Text = "Repair *.dds files";
            this.buttonModRepairDDS.UseVisualStyleBackColor = true;
            this.buttonModRepairDDS.Click += new System.EventHandler(this.buttonModRepairDDS_Click);
            // 
            // separator2
            // 
            this.separator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator2.Location = new System.Drawing.Point(7, 351);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(336, 2);
            this.separator2.TabIndex = 51;
            // 
            // separator1
            // 
            this.separator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator1.Location = new System.Drawing.Point(7, 84);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(336, 2);
            this.separator1.TabIndex = 50;
            // 
            // comboBoxModArchiveFormat
            // 
            this.comboBoxModArchiveFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModArchiveFormat.FormattingEnabled = true;
            this.comboBoxModArchiveFormat.Location = new System.Drawing.Point(125, 147);
            this.comboBoxModArchiveFormat.Name = "comboBoxModArchiveFormat";
            this.comboBoxModArchiveFormat.Size = new System.Drawing.Size(218, 21);
            this.comboBoxModArchiveFormat.TabIndex = 6;
            this.comboBoxModArchiveFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxModArchiveFormat_SelectedIndexChanged);
            // 
            // buttonModOpenFolder
            // 
            this.buttonModOpenFolder.Location = new System.Drawing.Point(218, 361);
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
            this.labelModFolderName.Location = new System.Drawing.Point(7, 57);
            this.labelModFolderName.Name = "labelModFolderName";
            this.labelModFolderName.Size = new System.Drawing.Size(89, 13);
            this.labelModFolderName.TabIndex = 47;
            this.labelModFolderName.Text = "Mod folder name:";
            // 
            // labelModArchiveFormat
            // 
            this.labelModArchiveFormat.AutoSize = true;
            this.labelModArchiveFormat.Location = new System.Drawing.Point(7, 150);
            this.labelModArchiveFormat.Name = "labelModArchiveFormat";
            this.labelModArchiveFormat.Size = new System.Drawing.Size(78, 13);
            this.labelModArchiveFormat.TabIndex = 43;
            this.labelModArchiveFormat.Text = "Archive format:";
            // 
            // textBoxModFolderName
            // 
            this.textBoxModFolderName.Location = new System.Drawing.Point(125, 54);
            this.textBoxModFolderName.Name = "textBoxModFolderName";
            this.textBoxModFolderName.Size = new System.Drawing.Size(218, 20);
            this.textBoxModFolderName.TabIndex = 2;
            this.textBoxModFolderName.TextChanged += new System.EventHandler(this.textBoxModFolderName_TextChanged);
            // 
            // comboBoxModInstallAs
            // 
            this.comboBoxModInstallAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModInstallAs.FormattingEnabled = true;
            this.comboBoxModInstallAs.Location = new System.Drawing.Point(125, 94);
            this.comboBoxModInstallAs.Name = "comboBoxModInstallAs";
            this.comboBoxModInstallAs.Size = new System.Drawing.Size(218, 21);
            this.comboBoxModInstallAs.TabIndex = 3;
            this.comboBoxModInstallAs.SelectedIndexChanged += new System.EventHandler(this.comboBoxModInstallAs_SelectedIndexChanged);
            // 
            // labelModInstallAs
            // 
            this.labelModInstallAs.AutoSize = true;
            this.labelModInstallAs.Location = new System.Drawing.Point(7, 97);
            this.labelModInstallAs.Name = "labelModInstallAs";
            this.labelModInstallAs.Size = new System.Drawing.Size(51, 13);
            this.labelModInstallAs.TabIndex = 41;
            this.labelModInstallAs.Text = "Install as:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(5, 418);
            this.progressBar1.MarqueeAnimationSpeed = 15;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(349, 23);
            this.progressBar1.TabIndex = 58;
            // 
            // labelModDetailsStatus
            // 
            this.labelModDetailsStatus.AutoSize = true;
            this.labelModDetailsStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelModDetailsStatus.Location = new System.Drawing.Point(6, 402);
            this.labelModDetailsStatus.Name = "labelModDetailsStatus";
            this.labelModDetailsStatus.Size = new System.Drawing.Size(16, 13);
            this.labelModDetailsStatus.TabIndex = 53;
            this.labelModDetailsStatus.Text = "...";
            this.labelModDetailsStatus.Visible = false;
            // 
            // buttonModDetailsApply
            // 
            this.buttonModDetailsApply.Location = new System.Drawing.Point(279, 447);
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
            this.buttonModDetailsOK.Location = new System.Drawing.Point(117, 447);
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
            this.buttonModDetailsCancel.Location = new System.Drawing.Point(198, 447);
            this.buttonModDetailsCancel.Name = "buttonModDetailsCancel";
            this.buttonModDetailsCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonModDetailsCancel.TabIndex = 11;
            this.buttonModDetailsCancel.TabStop = false;
            this.buttonModDetailsCancel.Text = "Cancel";
            this.buttonModDetailsCancel.UseVisualStyleBackColor = true;
            this.buttonModDetailsCancel.Click += new System.EventHandler(this.buttonModDetailsCancel_Click);
            // 
            // FormModDetails
            // 
            this.AcceptButton = this.buttonModDetailsOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonModDetailsCancel;
            this.ClientSize = new System.Drawing.Size(361, 477);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonModDetailsCancel);
            this.Controls.Add(this.buttonModDetailsOK);
            this.Controls.Add(this.labelModDetailsStatus);
            this.Controls.Add(this.buttonModDetailsApply);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(377, 516);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(377, 516);
            this.Name = "FormModDetails";
            this.ShowInTaskbar = false;
            this.Text = "Edit mod details";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBoxSeparateArchivePresets.ResumeLayout(false);
            this.groupBoxSeparateArchivePresets.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBoxModArchiveName;
        private System.Windows.Forms.Label labelModArchiveName;
        private System.Windows.Forms.CheckBox checkBoxModBA2Compression;
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
        private System.Windows.Forms.ComboBox comboBoxModArchiveFormat;
        private System.Windows.Forms.Label labelModArchiveFormat;
        private System.Windows.Forms.ComboBox comboBoxModInstallAs;
        private System.Windows.Forms.Label labelModFolderName;
        private System.Windows.Forms.TextBox textBoxModFolderName;
        private System.Windows.Forms.Button buttonModOpenFolder;
        private System.Windows.Forms.CheckBox checkBoxModDetailsEnabled;
        private System.Windows.Forms.Label separator1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogPickRootDir;
        public System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonModRepairDDS;
        private System.Windows.Forms.Label separator2;
        private System.Windows.Forms.Label labelModDetailsStatus;
        private System.Windows.Forms.CheckBox checkBoxFreezeArchive;
        private System.Windows.Forms.Label labelModUnfreeze;
        private System.Windows.Forms.Button buttonModUnfreeze;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBoxSeparateArchivePresets;
        private System.Windows.Forms.RadioButton radioButtonSeparateArchiveCustom;
        private System.Windows.Forms.RadioButton radioButtonSeparateArchiveSounds;
        private System.Windows.Forms.RadioButton radioButtonSeparateArchiveTextures;
        private System.Windows.Forms.RadioButton radioButtonSeparateArchiveGeneral;
        private System.Windows.Forms.Label labelModDetailsBulkFrozenModsWarning;
    }
}