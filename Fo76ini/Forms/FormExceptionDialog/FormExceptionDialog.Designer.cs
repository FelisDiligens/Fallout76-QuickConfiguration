namespace Fo76ini.Forms.ExceptionDialog
{
    partial class FormExceptionDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExceptionDialog));
            this.buttonCloseProgram = new System.Windows.Forms.Button();
            this.buttonCopyText = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDebugText = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCloseProgram
            // 
            this.buttonCloseProgram.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCloseProgram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCloseProgram.Location = new System.Drawing.Point(358, 371);
            this.buttonCloseProgram.Name = "buttonCloseProgram";
            this.buttonCloseProgram.Size = new System.Drawing.Size(133, 32);
            this.buttonCloseProgram.TabIndex = 0;
            this.buttonCloseProgram.Text = "Close program";
            this.buttonCloseProgram.UseVisualStyleBackColor = true;
            this.buttonCloseProgram.Click += new System.EventHandler(this.buttonCloseProgram_Click);
            // 
            // buttonCopyText
            // 
            this.buttonCopyText.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCopyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCopyText.Location = new System.Drawing.Point(219, 371);
            this.buttonCopyText.Name = "buttonCopyText";
            this.buttonCopyText.Size = new System.Drawing.Size(133, 32);
            this.buttonCopyText.TabIndex = 1;
            this.buttonCopyText.Text = "Copy text";
            this.buttonCopyText.UseVisualStyleBackColor = true;
            this.buttonCopyText.Click += new System.EventHandler(this.buttonCopyText_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(94, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 45);
            this.label1.TabIndex = 2;
            this.label1.Text = "An unhandled exception has occurred and the tool must be closed now.\r\nYou can pos" +
    "t a bug report on NexusMods for support.\r\nPlease provide the following text:";
            // 
            // textBoxDebugText
            // 
            this.textBoxDebugText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDebugText.BackColor = System.Drawing.SystemColors.Window;
            this.textBoxDebugText.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDebugText.Location = new System.Drawing.Point(13, 82);
            this.textBoxDebugText.Multiline = true;
            this.textBoxDebugText.Name = "textBoxDebugText";
            this.textBoxDebugText.ReadOnly = true;
            this.textBoxDebugText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxDebugText.Size = new System.Drawing.Size(478, 282);
            this.textBoxDebugText.TabIndex = 3;
            this.textBoxDebugText.WordWrap = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Fo76ini.Properties.Resources.error_64;
            this.pictureBox1.Location = new System.Drawing.Point(12, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // FormExceptionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(504, 411);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBoxDebugText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCopyText);
            this.Controls.Add(this.buttonCloseProgram);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(520, 450);
            this.Name = "FormExceptionDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unhandled exception occurred";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCloseProgram;
        private System.Windows.Forms.Button buttonCopyText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDebugText;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}