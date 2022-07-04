namespace Fo76ini.Forms.FormMain.Tabs
{
    partial class UserControlCustom
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
            this.buttonCustomSave = new System.Windows.Forms.Button();
            this.comboBoxCustomFile = new System.Windows.Forms.ComboBox();
            this.labelCustomFile = new System.Windows.Forms.Label();
            this.textBoxCustom = new System.Windows.Forms.TextBox();
            this.labelCustomTitle = new System.Windows.Forms.Label();
            this.labelCustomDesc = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonCustomSave
            // 
            this.buttonCustomSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCustomSave.Location = new System.Drawing.Point(752, 22);
            this.buttonCustomSave.Name = "buttonCustomSave";
            this.buttonCustomSave.Size = new System.Drawing.Size(94, 23);
            this.buttonCustomSave.TabIndex = 7;
            this.buttonCustomSave.Text = "Save";
            this.buttonCustomSave.UseVisualStyleBackColor = true;
            this.buttonCustomSave.Click += new System.EventHandler(this.buttonCustomSave_Click);
            // 
            // comboBoxCustomFile
            // 
            this.comboBoxCustomFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxCustomFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomFile.FormattingEnabled = true;
            this.comboBoxCustomFile.Location = new System.Drawing.Point(540, 23);
            this.comboBoxCustomFile.Name = "comboBoxCustomFile";
            this.comboBoxCustomFile.Size = new System.Drawing.Size(205, 21);
            this.comboBoxCustomFile.TabIndex = 6;
            this.comboBoxCustomFile.SelectedIndexChanged += new System.EventHandler(this.comboBoxCustomFile_SelectedIndexChanged);
            // 
            // labelCustomFile
            // 
            this.labelCustomFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCustomFile.AutoSize = true;
            this.labelCustomFile.Location = new System.Drawing.Point(538, 7);
            this.labelCustomFile.Name = "labelCustomFile";
            this.labelCustomFile.Size = new System.Drawing.Size(106, 13);
            this.labelCustomFile.TabIndex = 5;
            this.labelCustomFile.Text = "Overwrite lines in file:";
            // 
            // textBoxCustom
            // 
            this.textBoxCustom.AcceptsTab = true;
            this.textBoxCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCustom.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxCustom.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.textBoxCustom.Location = new System.Drawing.Point(6, 50);
            this.textBoxCustom.Multiline = true;
            this.textBoxCustom.Name = "textBoxCustom";
            this.textBoxCustom.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxCustom.Size = new System.Drawing.Size(840, 405);
            this.textBoxCustom.TabIndex = 4;
            this.textBoxCustom.WordWrap = false;
            this.textBoxCustom.TextChanged += new System.EventHandler(this.textBoxCustom_TextChanged);
            // 
            // labelCustomTitle
            // 
            this.labelCustomTitle.AutoSize = true;
            this.labelCustomTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomTitle.Location = new System.Drawing.Point(6, 6);
            this.labelCustomTitle.Name = "labelCustomTitle";
            this.labelCustomTitle.Size = new System.Drawing.Size(178, 24);
            this.labelCustomTitle.TabIndex = 69;
            this.labelCustomTitle.Text = "Custom *.ini settings";
            // 
            // labelCustomDesc
            // 
            this.labelCustomDesc.AutoSize = true;
            this.labelCustomDesc.Location = new System.Drawing.Point(8, 30);
            this.labelCustomDesc.Name = "labelCustomDesc";
            this.labelCustomDesc.Size = new System.Drawing.Size(301, 13);
            this.labelCustomDesc.TabIndex = 70;
            this.labelCustomDesc.Text = "Everything written in here will overwrite settings in the *.ini files.";
            // 
            // UserControlCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelCustomDesc);
            this.Controls.Add(this.labelCustomTitle);
            this.Controls.Add(this.buttonCustomSave);
            this.Controls.Add(this.comboBoxCustomFile);
            this.Controls.Add(this.labelCustomFile);
            this.Controls.Add(this.textBoxCustom);
            this.Name = "UserControlCustom";
            this.Size = new System.Drawing.Size(850, 460);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCustomSave;
        private System.Windows.Forms.ComboBox comboBoxCustomFile;
        private System.Windows.Forms.Label labelCustomFile;
        private System.Windows.Forms.TextBox textBoxCustom;
        private System.Windows.Forms.Label labelCustomTitle;
        private System.Windows.Forms.Label labelCustomDesc;
    }
}
