namespace Fo76ini_Updater
{
    partial class Updater
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Updater));
            this.buttonStartTool = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonTryAgainAdmin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStartTool
            // 
            this.buttonStartTool.Location = new System.Drawing.Point(12, 104);
            this.buttonStartTool.Name = "buttonStartTool";
            this.buttonStartTool.Size = new System.Drawing.Size(260, 23);
            this.buttonStartTool.TabIndex = 0;
            this.buttonStartTool.Text = "Start tool";
            this.buttonStartTool.UseVisualStyleBackColor = true;
            this.buttonStartTool.Click += new System.EventHandler(this.buttonStartTool_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.ForeColor = System.Drawing.Color.DimGray;
            this.labelStatus.Location = new System.Drawing.Point(12, 16);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(260, 52);
            this.labelStatus.TabIndex = 1;
            this.labelStatus.Text = "Initializing...";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonTryAgainAdmin
            // 
            this.buttonTryAgainAdmin.Location = new System.Drawing.Point(12, 75);
            this.buttonTryAgainAdmin.Name = "buttonTryAgainAdmin";
            this.buttonTryAgainAdmin.Size = new System.Drawing.Size(260, 23);
            this.buttonTryAgainAdmin.TabIndex = 2;
            this.buttonTryAgainAdmin.Text = "Try again, run as admin";
            this.buttonTryAgainAdmin.UseVisualStyleBackColor = true;
            this.buttonTryAgainAdmin.Click += new System.EventHandler(this.buttonTryAgainAdmin_Click);
            // 
            // Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 141);
            this.Controls.Add(this.buttonTryAgainAdmin);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonStartTool);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 130);
            this.Name = "Updater";
            this.Text = "Updater";
            this.Load += new System.EventHandler(this.Updater_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStartTool;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonTryAgainAdmin;
    }
}

