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
            this.pictureBoxLoading = new System.Windows.Forms.PictureBox();
            this.buttonShowLogFile = new System.Windows.Forms.Button();
            this.backgroundWorkerGatherInfo = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorkerInstall = new System.ComponentModel.BackgroundWorker();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStartTool
            // 
            this.buttonStartTool.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonStartTool.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonStartTool.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartTool.ForeColor = System.Drawing.Color.White;
            this.buttonStartTool.Location = new System.Drawing.Point(12, 83);
            this.buttonStartTool.Name = "buttonStartTool";
            this.buttonStartTool.Size = new System.Drawing.Size(260, 36);
            this.buttonStartTool.TabIndex = 0;
            this.buttonStartTool.Text = "Start tool";
            this.buttonStartTool.UseVisualStyleBackColor = false;
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
            this.buttonTryAgainAdmin.Location = new System.Drawing.Point(12, 125);
            this.buttonTryAgainAdmin.Name = "buttonTryAgainAdmin";
            this.buttonTryAgainAdmin.Size = new System.Drawing.Size(260, 23);
            this.buttonTryAgainAdmin.TabIndex = 2;
            this.buttonTryAgainAdmin.Text = "Try again (Run as admin)";
            this.buttonTryAgainAdmin.UseVisualStyleBackColor = true;
            this.buttonTryAgainAdmin.Click += new System.EventHandler(this.buttonTryAgainAdmin_Click);
            // 
            // pictureBoxLoading
            // 
            this.pictureBoxLoading.Image = global::Fo76ini_Updater.Properties.Resources.Spinner_1_4s_24px;
            this.pictureBoxLoading.Location = new System.Drawing.Point(12, 30);
            this.pictureBoxLoading.Name = "pictureBoxLoading";
            this.pictureBoxLoading.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxLoading.TabIndex = 3;
            this.pictureBoxLoading.TabStop = false;
            // 
            // buttonShowLogFile
            // 
            this.buttonShowLogFile.Location = new System.Drawing.Point(12, 154);
            this.buttonShowLogFile.Name = "buttonShowLogFile";
            this.buttonShowLogFile.Size = new System.Drawing.Size(260, 23);
            this.buttonShowLogFile.TabIndex = 4;
            this.buttonShowLogFile.Text = "Show updater.log.txt";
            this.buttonShowLogFile.UseVisualStyleBackColor = true;
            this.buttonShowLogFile.Click += new System.EventHandler(this.buttonShowLogFile_Click);
            // 
            // backgroundWorkerGatherInfo
            // 
            this.backgroundWorkerGatherInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerGatherInfo_DoWork);
            // 
            // backgroundWorkerInstall
            // 
            this.backgroundWorkerInstall.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerInstall_DoWork);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(12, 83);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(260, 12);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 5;
            // 
            // Updater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 194);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonShowLogFile);
            this.Controls.Add(this.pictureBoxLoading);
            this.Controls.Add(this.buttonTryAgainAdmin);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonStartTool);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Updater";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Updater v4";
            this.Load += new System.EventHandler(this.Updater_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoading)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStartTool;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Button buttonTryAgainAdmin;
        private System.Windows.Forms.PictureBox pictureBoxLoading;
        private System.Windows.Forms.Button buttonShowLogFile;
        private System.ComponentModel.BackgroundWorker backgroundWorkerGatherInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorkerInstall;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

