namespace Fo76ini
{
    partial class FormStartup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStartup));
            this.pictureBoxBanner = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxBanner
            // 
            this.pictureBoxBanner.BackColor = System.Drawing.Color.Black;
            this.pictureBoxBanner.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxBanner.Image")));
            this.pictureBoxBanner.InitialImage = null;
            this.pictureBoxBanner.Location = new System.Drawing.Point(-1, -1);
            this.pictureBoxBanner.Name = "pictureBoxBanner";
            this.pictureBoxBanner.Size = new System.Drawing.Size(342, 36);
            this.pictureBoxBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxBanner.TabIndex = 5;
            this.pictureBoxBanner.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(317, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Configurate *.ini files";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(185, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "What do you want to do?";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 112);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(317, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Manage mods";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // FormStartup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 147);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBoxBanner);
            this.Name = "FormStartup";
            this.Text = "Fallout 76 Quick Configuration";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxBanner;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
    }
}