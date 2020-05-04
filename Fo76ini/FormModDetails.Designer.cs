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
            this.separator1 = new System.Windows.Forms.Label();
            this.checkBoxModDetailsEnabled = new System.Windows.Forms.CheckBox();
            this.comboBoxModArchiveFormat = new System.Windows.Forms.ComboBox();
            this.buttonModOpenFolder = new System.Windows.Forms.Button();
            this.labelModFolderName = new System.Windows.Forms.Label();
            this.labelModArchiveFormat = new System.Windows.Forms.Label();
            this.textBoxModFolderName = new System.Windows.Forms.TextBox();
            this.comboBoxModInstallAs = new System.Windows.Forms.ComboBox();
            this.labelModInstallAs = new System.Windows.Forms.Label();
            this.buttonModDetailsApply = new System.Windows.Forms.Button();
            this.buttonModDetailsOK = new System.Windows.Forms.Button();
            this.buttonModDetailsCancel = new System.Windows.Forms.Button();
            this.folderBrowserDialogPickRootDir = new System.Windows.Forms.FolderBrowserDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.separator2 = new System.Windows.Forms.Label();
            this.buttonModRepairDDS = new System.Windows.Forms.Button();
            this.labelModDetailRepairStatus = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBoxModArchiveName
            // 
            this.textBoxModArchiveName.Location = new System.Drawing.Point(112, 185);
            this.textBoxModArchiveName.Name = "textBoxModArchiveName";
            this.textBoxModArchiveName.Size = new System.Drawing.Size(231, 20);
            this.textBoxModArchiveName.TabIndex = 41;
            this.textBoxModArchiveName.TextChanged += new System.EventHandler(this.textBoxModArchiveName_TextChanged);
            // 
            // labelModArchiveName
            // 
            this.labelModArchiveName.AutoSize = true;
            this.labelModArchiveName.Location = new System.Drawing.Point(7, 188);
            this.labelModArchiveName.Name = "labelModArchiveName";
            this.labelModArchiveName.Size = new System.Drawing.Size(75, 13);
            this.labelModArchiveName.TabIndex = 41;
            this.labelModArchiveName.Text = "Archive name:";
            // 
            // checkBoxModBA2Compression
            // 
            this.checkBoxModBA2Compression.AutoSize = true;
            this.checkBoxModBA2Compression.Location = new System.Drawing.Point(10, 211);
            this.checkBoxModBA2Compression.Name = "checkBoxModBA2Compression";
            this.checkBoxModBA2Compression.Size = new System.Drawing.Size(110, 17);
            this.checkBoxModBA2Compression.TabIndex = 0;
            this.checkBoxModBA2Compression.Text = "Compress archive";
            this.checkBoxModBA2Compression.UseVisualStyleBackColor = true;
            this.checkBoxModBA2Compression.CheckedChanged += new System.EventHandler(this.checkBoxModBA2Compression_CheckedChanged);
            // 
            // buttonModPickRootDir
            // 
            this.buttonModPickRootDir.Location = new System.Drawing.Point(317, 130);
            this.buttonModPickRootDir.Name = "buttonModPickRootDir";
            this.buttonModPickRootDir.Size = new System.Drawing.Size(26, 23);
            this.buttonModPickRootDir.TabIndex = 20;
            this.buttonModPickRootDir.Text = "...";
            this.buttonModPickRootDir.UseVisualStyleBackColor = true;
            this.buttonModPickRootDir.Click += new System.EventHandler(this.buttonModPickRootDir_Click);
            // 
            // textBoxModRootDir
            // 
            this.textBoxModRootDir.Location = new System.Drawing.Point(112, 132);
            this.textBoxModRootDir.Name = "textBoxModRootDir";
            this.textBoxModRootDir.Size = new System.Drawing.Size(199, 20);
            this.textBoxModRootDir.TabIndex = 39;
            this.textBoxModRootDir.TextChanged += new System.EventHandler(this.textBoxModRootDir_TextChanged);
            // 
            // labelModInstallInto
            // 
            this.labelModInstallInto.AutoSize = true;
            this.labelModInstallInto.Location = new System.Drawing.Point(7, 135);
            this.labelModInstallInto.Name = "labelModInstallInto";
            this.labelModInstallInto.Size = new System.Drawing.Size(57, 13);
            this.labelModInstallInto.TabIndex = 38;
            this.labelModInstallInto.Text = "Install into:";
            // 
            // labelModName
            // 
            this.labelModName.AutoSize = true;
            this.labelModName.Location = new System.Drawing.Point(7, 35);
            this.labelModName.Name = "labelModName";
            this.labelModName.Size = new System.Drawing.Size(60, 13);
            this.labelModName.TabIndex = 25;
            this.labelModName.Text = "Mod name:";
            // 
            // textBoxModName
            // 
            this.textBoxModName.Location = new System.Drawing.Point(112, 32);
            this.textBoxModName.Name = "textBoxModName";
            this.textBoxModName.Size = new System.Drawing.Size(231, 20);
            this.textBoxModName.TabIndex = 26;
            this.textBoxModName.TextChanged += new System.EventHandler(this.textBoxModName_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.labelModDetailRepairStatus);
            this.panel1.Controls.Add(this.buttonModRepairDDS);
            this.panel1.Controls.Add(this.separator2);
            this.panel1.Controls.Add(this.checkBoxModBA2Compression);
            this.panel1.Controls.Add(this.labelModArchiveName);
            this.panel1.Controls.Add(this.textBoxModArchiveName);
            this.panel1.Controls.Add(this.separator1);
            this.panel1.Controls.Add(this.checkBoxModDetailsEnabled);
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
            this.panel1.Size = new System.Drawing.Size(349, 435);
            this.panel1.TabIndex = 44;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // separator1
            // 
            this.separator1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator1.Location = new System.Drawing.Point(7, 94);
            this.separator1.Name = "separator1";
            this.separator1.Size = new System.Drawing.Size(336, 2);
            this.separator1.TabIndex = 50;
            // 
            // checkBoxModDetailsEnabled
            // 
            this.checkBoxModDetailsEnabled.AutoSize = true;
            this.checkBoxModDetailsEnabled.Location = new System.Drawing.Point(10, 7);
            this.checkBoxModDetailsEnabled.Name = "checkBoxModDetailsEnabled";
            this.checkBoxModDetailsEnabled.Size = new System.Drawing.Size(101, 17);
            this.checkBoxModDetailsEnabled.TabIndex = 49;
            this.checkBoxModDetailsEnabled.Text = "Enable this mod";
            this.checkBoxModDetailsEnabled.UseVisualStyleBackColor = true;
            this.checkBoxModDetailsEnabled.CheckedChanged += new System.EventHandler(this.checkBoxModDetailsEnabled_CheckedChanged);
            // 
            // comboBoxModArchiveFormat
            // 
            this.comboBoxModArchiveFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModArchiveFormat.FormattingEnabled = true;
            this.comboBoxModArchiveFormat.Location = new System.Drawing.Point(112, 158);
            this.comboBoxModArchiveFormat.Name = "comboBoxModArchiveFormat";
            this.comboBoxModArchiveFormat.Size = new System.Drawing.Size(231, 21);
            this.comboBoxModArchiveFormat.TabIndex = 44;
            this.comboBoxModArchiveFormat.SelectedIndexChanged += new System.EventHandler(this.comboBoxModArchiveFormat_SelectedIndexChanged);
            // 
            // buttonModOpenFolder
            // 
            this.buttonModOpenFolder.Location = new System.Drawing.Point(218, 398);
            this.buttonModOpenFolder.Name = "buttonModOpenFolder";
            this.buttonModOpenFolder.Size = new System.Drawing.Size(125, 23);
            this.buttonModOpenFolder.TabIndex = 48;
            this.buttonModOpenFolder.Text = "Open folder";
            this.buttonModOpenFolder.UseVisualStyleBackColor = true;
            this.buttonModOpenFolder.Click += new System.EventHandler(this.buttonModOpenFolder_Click);
            // 
            // labelModFolderName
            // 
            this.labelModFolderName.AutoSize = true;
            this.labelModFolderName.Location = new System.Drawing.Point(7, 60);
            this.labelModFolderName.Name = "labelModFolderName";
            this.labelModFolderName.Size = new System.Drawing.Size(89, 13);
            this.labelModFolderName.TabIndex = 47;
            this.labelModFolderName.Text = "Mod folder name:";
            // 
            // labelModArchiveFormat
            // 
            this.labelModArchiveFormat.AutoSize = true;
            this.labelModArchiveFormat.Location = new System.Drawing.Point(7, 161);
            this.labelModArchiveFormat.Name = "labelModArchiveFormat";
            this.labelModArchiveFormat.Size = new System.Drawing.Size(78, 13);
            this.labelModArchiveFormat.TabIndex = 43;
            this.labelModArchiveFormat.Text = "Archive format:";
            // 
            // textBoxModFolderName
            // 
            this.textBoxModFolderName.Location = new System.Drawing.Point(112, 57);
            this.textBoxModFolderName.Name = "textBoxModFolderName";
            this.textBoxModFolderName.Size = new System.Drawing.Size(231, 20);
            this.textBoxModFolderName.TabIndex = 46;
            this.textBoxModFolderName.TextChanged += new System.EventHandler(this.textBoxModFolderName_TextChanged);
            // 
            // comboBoxModInstallAs
            // 
            this.comboBoxModInstallAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxModInstallAs.FormattingEnabled = true;
            this.comboBoxModInstallAs.Location = new System.Drawing.Point(112, 105);
            this.comboBoxModInstallAs.Name = "comboBoxModInstallAs";
            this.comboBoxModInstallAs.Size = new System.Drawing.Size(231, 21);
            this.comboBoxModInstallAs.TabIndex = 42;
            this.comboBoxModInstallAs.SelectedIndexChanged += new System.EventHandler(this.comboBoxModInstallAs_SelectedIndexChanged);
            // 
            // labelModInstallAs
            // 
            this.labelModInstallAs.AutoSize = true;
            this.labelModInstallAs.Location = new System.Drawing.Point(7, 108);
            this.labelModInstallAs.Name = "labelModInstallAs";
            this.labelModInstallAs.Size = new System.Drawing.Size(51, 13);
            this.labelModInstallAs.TabIndex = 41;
            this.labelModInstallAs.Text = "Install as:";
            // 
            // buttonModDetailsApply
            // 
            this.buttonModDetailsApply.Location = new System.Drawing.Point(279, 447);
            this.buttonModDetailsApply.Name = "buttonModDetailsApply";
            this.buttonModDetailsApply.Size = new System.Drawing.Size(75, 23);
            this.buttonModDetailsApply.TabIndex = 45;
            this.buttonModDetailsApply.Text = "Apply";
            this.buttonModDetailsApply.UseVisualStyleBackColor = true;
            this.buttonModDetailsApply.Click += new System.EventHandler(this.buttonModDetailsApply_Click);
            // 
            // buttonModDetailsOK
            // 
            this.buttonModDetailsOK.Location = new System.Drawing.Point(117, 447);
            this.buttonModDetailsOK.Name = "buttonModDetailsOK";
            this.buttonModDetailsOK.Size = new System.Drawing.Size(75, 23);
            this.buttonModDetailsOK.TabIndex = 46;
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
            this.buttonModDetailsCancel.TabIndex = 47;
            this.buttonModDetailsCancel.Text = "Cancel";
            this.buttonModDetailsCancel.UseVisualStyleBackColor = true;
            this.buttonModDetailsCancel.Click += new System.EventHandler(this.buttonModDetailsCancel_Click);
            // 
            // separator2
            // 
            this.separator2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.separator2.Location = new System.Drawing.Point(7, 245);
            this.separator2.Name = "separator2";
            this.separator2.Size = new System.Drawing.Size(336, 2);
            this.separator2.TabIndex = 51;
            // 
            // buttonModRepairDDS
            // 
            this.buttonModRepairDDS.Location = new System.Drawing.Point(10, 398);
            this.buttonModRepairDDS.Name = "buttonModRepairDDS";
            this.buttonModRepairDDS.Size = new System.Drawing.Size(202, 23);
            this.buttonModRepairDDS.TabIndex = 52;
            this.buttonModRepairDDS.Text = "Repair *.dds files";
            this.buttonModRepairDDS.UseVisualStyleBackColor = true;
            this.buttonModRepairDDS.Click += new System.EventHandler(this.buttonModRepairDDS_Click);
            // 
            // labelModDetailRepairStatus
            // 
            this.labelModDetailRepairStatus.AutoSize = true;
            this.labelModDetailRepairStatus.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelModDetailRepairStatus.Location = new System.Drawing.Point(10, 382);
            this.labelModDetailRepairStatus.Name = "labelModDetailRepairStatus";
            this.labelModDetailRepairStatus.Size = new System.Drawing.Size(16, 13);
            this.labelModDetailRepairStatus.TabIndex = 53;
            this.labelModDetailRepairStatus.Text = "...";
            this.labelModDetailRepairStatus.Visible = false;
            // 
            // FormModDetails
            // 
            this.AcceptButton = this.buttonModDetailsApply;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonModDetailsCancel;
            this.ClientSize = new System.Drawing.Size(361, 477);
            this.Controls.Add(this.buttonModDetailsCancel);
            this.Controls.Add(this.buttonModDetailsOK);
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
            this.ResumeLayout(false);

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
        private System.Windows.Forms.Label labelModDetailRepairStatus;
    }
}