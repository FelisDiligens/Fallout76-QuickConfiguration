
namespace Fo76ini.Forms.FormIniError
{
    partial class FormIniError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIniError));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonResetFile = new System.Windows.Forms.Button();
            this.buttonTryAgain = new System.Windows.Forms.Button();
            this.linkLabelShowHelp = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonOpenEditor = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.labelErrorMessage = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonCloseProgram = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.labelFileName = new System.Windows.Forms.Label();
            this.labelLineNumber = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Couldn\'t parse *.ini file";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Fo76ini.Properties.Resources.error_64;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(85, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 42);
            this.label2.TabIndex = 6;
            this.label2.Text = "An *.ini file couldn\'t be parsed, because it is either corrupted or contains a sy" +
    "ntax error.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 298);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Couldn\'t parse the highlighted line:";
            // 
            // richTextBox
            // 
            this.richTextBox.BackColor = System.Drawing.Color.White;
            this.richTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.richTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox.HideSelection = false;
            this.richTextBox.Location = new System.Drawing.Point(2, 2);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ReadOnly = true;
            this.richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBox.Size = new System.Drawing.Size(383, 115);
            this.richTextBox.TabIndex = 0;
            this.richTextBox.Text = "";
            this.richTextBox.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.richTextBox);
            this.panel1.Location = new System.Drawing.Point(12, 314);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 122);
            this.panel1.TabIndex = 9;
            // 
            // buttonResetFile
            // 
            this.buttonResetFile.Location = new System.Drawing.Point(12, 504);
            this.buttonResetFile.Name = "buttonResetFile";
            this.buttonResetFile.Size = new System.Drawing.Size(221, 23);
            this.buttonResetFile.TabIndex = 900;
            this.buttonResetFile.Text = "Reset *.ini file";
            this.buttonResetFile.UseVisualStyleBackColor = true;
            this.buttonResetFile.Click += new System.EventHandler(this.buttonResetFile_Click);
            // 
            // buttonTryAgain
            // 
            this.buttonTryAgain.Location = new System.Drawing.Point(239, 475);
            this.buttonTryAgain.Name = "buttonTryAgain";
            this.buttonTryAgain.Size = new System.Drawing.Size(163, 24);
            this.buttonTryAgain.TabIndex = 1;
            this.buttonTryAgain.Text = "Try again";
            this.buttonTryAgain.UseVisualStyleBackColor = true;
            this.buttonTryAgain.Click += new System.EventHandler(this.buttonTryAgain_Click);
            // 
            // linkLabelShowHelp
            // 
            this.linkLabelShowHelp.AutoSize = true;
            this.linkLabelShowHelp.Location = new System.Drawing.Point(42, 155);
            this.linkLabelShowHelp.Name = "linkLabelShowHelp";
            this.linkLabelShowHelp.Size = new System.Drawing.Size(117, 13);
            this.linkLabelShowHelp.TabIndex = 2;
            this.linkLabelShowHelp.TabStop = true;
            this.linkLabelShowHelp.Text = "Help! Show me a guide";
            this.linkLabelShowHelp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelShowHelp_LinkClicked);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(389, 41);
            this.label4.TabIndex = 10;
            this.label4.Text = "        • read the error message and fix the error or\r\n        • reset the *.ini " +
    "file to default.";
            // 
            // buttonOpenEditor
            // 
            this.buttonOpenEditor.Location = new System.Drawing.Point(12, 475);
            this.buttonOpenEditor.Name = "buttonOpenEditor";
            this.buttonOpenEditor.Size = new System.Drawing.Size(221, 23);
            this.buttonOpenEditor.TabIndex = 11;
            this.buttonOpenEditor.Text = "Open *.ini file in text editor";
            this.buttonOpenEditor.UseVisualStyleBackColor = true;
            this.buttonOpenEditor.Click += new System.EventHandler(this.buttonOpenEditor_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(9, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "You may:";
            // 
            // labelErrorMessage
            // 
            this.labelErrorMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(80)))), ((int)(((byte)(80)))));
            this.labelErrorMessage.Location = new System.Drawing.Point(12, 216);
            this.labelErrorMessage.Name = "labelErrorMessage";
            this.labelErrorMessage.Size = new System.Drawing.Size(390, 30);
            this.labelErrorMessage.TabIndex = 16;
            this.labelErrorMessage.Text = "< Error message goes here >";
            this.labelErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(9, 197);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Error details";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Fo76ini.Properties.Resources.help_24;
            this.pictureBox2.Location = new System.Drawing.Point(12, 150);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // buttonCloseProgram
            // 
            this.buttonCloseProgram.Location = new System.Drawing.Point(239, 503);
            this.buttonCloseProgram.Name = "buttonCloseProgram";
            this.buttonCloseProgram.Size = new System.Drawing.Size(163, 24);
            this.buttonCloseProgram.TabIndex = 18;
            this.buttonCloseProgram.Text = "Close program";
            this.buttonCloseProgram.UseVisualStyleBackColor = true;
            this.buttonCloseProgram.Click += new System.EventHandler(this.buttonCloseProgram_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(9, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Affected file:";
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileName.Location = new System.Drawing.Point(111, 253);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(94, 13);
            this.labelFileName.TabIndex = 20;
            this.labelFileName.Text = "< File name here >";
            // 
            // labelLineNumber
            // 
            this.labelLineNumber.AutoSize = true;
            this.labelLineNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLineNumber.Location = new System.Drawing.Point(111, 270);
            this.labelLineNumber.Name = "labelLineNumber";
            this.labelLineNumber.Size = new System.Drawing.Size(107, 13);
            this.labelLineNumber.TabIndex = 22;
            this.labelLineNumber.Text = "< Line number here >";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(9, 270);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Line number:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(9, 452);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 15);
            this.label8.TabIndex = 901;
            this.label8.Text = "Options";
            // 
            // FormIniError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 541);
            this.ControlBox = false;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelLineNumber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonCloseProgram);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.labelErrorMessage);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonOpenEditor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonResetFile);
            this.Controls.Add(this.buttonTryAgain);
            this.Controls.Add(this.linkLabelShowHelp);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIniError";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "*.ini parsing error";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonResetFile;
        private System.Windows.Forms.Button buttonTryAgain;
        private System.Windows.Forms.LinkLabel linkLabelShowHelp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonOpenEditor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelErrorMessage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button buttonCloseProgram;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Label labelLineNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}