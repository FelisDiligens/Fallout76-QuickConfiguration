namespace Fo76ini.Controls
{
    partial class UserControlHero
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
            this.pictureBoxHero = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHero)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxHero
            // 
            this.pictureBoxHero.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxHero.BackColor = System.Drawing.Color.Black;
            this.pictureBoxHero.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBoxHero.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxHero.Name = "pictureBoxHero";
            this.pictureBoxHero.Size = new System.Drawing.Size(700, 250);
            this.pictureBoxHero.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxHero.TabIndex = 0;
            this.pictureBoxHero.TabStop = false;
            this.pictureBoxHero.Resize += new System.EventHandler(this.pictureBoxHero_Resize);
            // 
            // UserControlHero
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBoxHero);
            this.Name = "UserControlHero";
            this.Size = new System.Drawing.Size(700, 250);
            this.Load += new System.EventHandler(this.UserControlHero_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHero)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxHero;
    }
}
