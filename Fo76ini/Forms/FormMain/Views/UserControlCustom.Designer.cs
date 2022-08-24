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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlCustom));
            this.buttonCustomSave = new System.Windows.Forms.Button();
            this.comboBoxCustomFile = new System.Windows.Forms.ComboBox();
            this.labelCustomFile = new System.Windows.Forms.Label();
            this.labelCustomTitle = new System.Windows.Forms.Label();
            this.labelCustomDesc = new System.Windows.Forms.Label();
            this.textBoxCustom = new FastColoredTextBoxNS.FastColoredTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.textBoxCustom)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCustomSave
            // 
            this.buttonCustomSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCustomSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCustomSave.Location = new System.Drawing.Point(235, 425);
            this.buttonCustomSave.Margin = new System.Windows.Forms.Padding(5, 10, 5, 10);
            this.buttonCustomSave.Name = "buttonCustomSave";
            this.buttonCustomSave.Size = new System.Drawing.Size(94, 26);
            this.buttonCustomSave.TabIndex = 7;
            this.buttonCustomSave.Text = "Save";
            this.buttonCustomSave.UseVisualStyleBackColor = true;
            this.buttonCustomSave.Click += new System.EventHandler(this.buttonCustomSave_Click);
            // 
            // comboBoxCustomFile
            // 
            this.comboBoxCustomFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxCustomFile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCustomFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxCustomFile.FormattingEnabled = true;
            this.comboBoxCustomFile.Location = new System.Drawing.Point(15, 426);
            this.comboBoxCustomFile.Margin = new System.Windows.Forms.Padding(10);
            this.comboBoxCustomFile.Name = "comboBoxCustomFile";
            this.comboBoxCustomFile.Size = new System.Drawing.Size(205, 24);
            this.comboBoxCustomFile.TabIndex = 6;
            this.comboBoxCustomFile.SelectedIndexChanged += new System.EventHandler(this.comboBoxCustomFile_SelectedIndexChanged);
            // 
            // labelCustomFile
            // 
            this.labelCustomFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelCustomFile.AutoSize = true;
            this.labelCustomFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomFile.Location = new System.Drawing.Point(12, 406);
            this.labelCustomFile.Name = "labelCustomFile";
            this.labelCustomFile.Size = new System.Drawing.Size(130, 16);
            this.labelCustomFile.TabIndex = 5;
            this.labelCustomFile.Text = "Overwrite lines in file:";
            // 
            // labelCustomTitle
            // 
            this.labelCustomTitle.AutoSize = true;
            this.labelCustomTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomTitle.Location = new System.Drawing.Point(10, 15);
            this.labelCustomTitle.Name = "labelCustomTitle";
            this.labelCustomTitle.Size = new System.Drawing.Size(210, 30);
            this.labelCustomTitle.TabIndex = 69;
            this.labelCustomTitle.Text = "Custom *.ini settings";
            // 
            // labelCustomDesc
            // 
            this.labelCustomDesc.AutoSize = true;
            this.labelCustomDesc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCustomDesc.Location = new System.Drawing.Point(12, 45);
            this.labelCustomDesc.Name = "labelCustomDesc";
            this.labelCustomDesc.Size = new System.Drawing.Size(375, 17);
            this.labelCustomDesc.TabIndex = 70;
            this.labelCustomDesc.Text = "Everything written in here will overwrite settings in the *.ini files.";
            // 
            // textBoxCustom
            // 
            this.textBoxCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCustom.AutoCompleteBrackets = true;
            this.textBoxCustom.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.textBoxCustom.AutoScrollMinSize = new System.Drawing.Size(0, 15);
            this.textBoxCustom.BackBrush = null;
            this.textBoxCustom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxCustom.CharHeight = 15;
            this.textBoxCustom.CharWidth = 8;
            this.textBoxCustom.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxCustom.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.textBoxCustom.Font = new System.Drawing.Font("Cascadia Code", 9.75F);
            this.textBoxCustom.IsReplaceMode = false;
            this.textBoxCustom.LeftBracket = '[';
            this.textBoxCustom.Location = new System.Drawing.Point(15, 75);
            this.textBoxCustom.Margin = new System.Windows.Forms.Padding(15);
            this.textBoxCustom.Name = "textBoxCustom";
            this.textBoxCustom.Paddings = new System.Windows.Forms.Padding(0);
            this.textBoxCustom.RightBracket = ']';
            this.textBoxCustom.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.textBoxCustom.ServiceColors = ((FastColoredTextBoxNS.ServiceColors)(resources.GetObject("textBoxCustom.ServiceColors")));
            this.textBoxCustom.Size = new System.Drawing.Size(820, 325);
            this.textBoxCustom.TabIndex = 71;
            this.textBoxCustom.WordWrap = true;
            this.textBoxCustom.Zoom = 100;
            this.textBoxCustom.TextChanged += new System.EventHandler<FastColoredTextBoxNS.TextChangedEventArgs>(this.textBoxCustom_TextChanged);
            this.textBoxCustom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxCustom_KeyDown);
            // 
            // UserControlCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBoxCustom);
            this.Controls.Add(this.labelCustomDesc);
            this.Controls.Add(this.labelCustomTitle);
            this.Controls.Add(this.buttonCustomSave);
            this.Controls.Add(this.comboBoxCustomFile);
            this.Controls.Add(this.labelCustomFile);
            this.Name = "UserControlCustom";
            this.Size = new System.Drawing.Size(850, 460);
            ((System.ComponentModel.ISupportInitialize)(this.textBoxCustom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCustomSave;
        private System.Windows.Forms.ComboBox comboBoxCustomFile;
        private System.Windows.Forms.Label labelCustomFile;
        private System.Windows.Forms.Label labelCustomTitle;
        private System.Windows.Forms.Label labelCustomDesc;
        private FastColoredTextBoxNS.FastColoredTextBox textBoxCustom;
    }
}
