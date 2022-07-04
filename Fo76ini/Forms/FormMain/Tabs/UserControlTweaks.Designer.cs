namespace Fo76ini.Forms.FormMain
{
    partial class UserControlTweaks
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
            this.tabControlTweaks = new System.Windows.Forms.TabControl();
            this.tabPageGeneral = new System.Windows.Forms.TabPage();
            this.tabPageVideo = new System.Windows.Forms.TabPage();
            this.tabPageAudio = new System.Windows.Forms.TabPage();
            this.tabPageControls = new System.Windows.Forms.TabPage();
            this.tabPageCamera = new System.Windows.Forms.TabPage();
            this.tabControlTweaks.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlTweaks
            // 
            this.tabControlTweaks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlTweaks.Controls.Add(this.tabPageGeneral);
            this.tabControlTweaks.Controls.Add(this.tabPageVideo);
            this.tabControlTweaks.Controls.Add(this.tabPageAudio);
            this.tabControlTweaks.Controls.Add(this.tabPageControls);
            this.tabControlTweaks.Controls.Add(this.tabPageCamera);
            this.tabControlTweaks.Location = new System.Drawing.Point(3, 3);
            this.tabControlTweaks.Name = "tabControlTweaks";
            this.tabControlTweaks.SelectedIndex = 0;
            this.tabControlTweaks.Size = new System.Drawing.Size(844, 454);
            this.tabControlTweaks.TabIndex = 0;
            // 
            // tabPageGeneral
            // 
            this.tabPageGeneral.Location = new System.Drawing.Point(4, 22);
            this.tabPageGeneral.Name = "tabPageGeneral";
            this.tabPageGeneral.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageGeneral.Size = new System.Drawing.Size(836, 428);
            this.tabPageGeneral.TabIndex = 0;
            this.tabPageGeneral.Text = "General";
            this.tabPageGeneral.UseVisualStyleBackColor = true;
            // 
            // tabPageVideo
            // 
            this.tabPageVideo.Location = new System.Drawing.Point(4, 22);
            this.tabPageVideo.Name = "tabPageVideo";
            this.tabPageVideo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageVideo.Size = new System.Drawing.Size(783, 428);
            this.tabPageVideo.TabIndex = 1;
            this.tabPageVideo.Text = "Video";
            this.tabPageVideo.UseVisualStyleBackColor = true;
            // 
            // tabPageAudio
            // 
            this.tabPageAudio.Location = new System.Drawing.Point(4, 22);
            this.tabPageAudio.Name = "tabPageAudio";
            this.tabPageAudio.Size = new System.Drawing.Size(783, 428);
            this.tabPageAudio.TabIndex = 2;
            this.tabPageAudio.Text = "Audio";
            this.tabPageAudio.UseVisualStyleBackColor = true;
            // 
            // tabPageControls
            // 
            this.tabPageControls.Location = new System.Drawing.Point(4, 22);
            this.tabPageControls.Name = "tabPageControls";
            this.tabPageControls.Size = new System.Drawing.Size(783, 428);
            this.tabPageControls.TabIndex = 3;
            this.tabPageControls.Text = "Controls";
            this.tabPageControls.UseVisualStyleBackColor = true;
            // 
            // tabPageCamera
            // 
            this.tabPageCamera.Location = new System.Drawing.Point(4, 22);
            this.tabPageCamera.Name = "tabPageCamera";
            this.tabPageCamera.Size = new System.Drawing.Size(783, 428);
            this.tabPageCamera.TabIndex = 4;
            this.tabPageCamera.Text = "Camera";
            this.tabPageCamera.UseVisualStyleBackColor = true;
            // 
            // UserControlTweaks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlTweaks);
            this.Name = "UserControlTweaks";
            this.Size = new System.Drawing.Size(850, 460);
            this.tabControlTweaks.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlTweaks;
        private System.Windows.Forms.TabPage tabPageGeneral;
        private System.Windows.Forms.TabPage tabPageVideo;
        private System.Windows.Forms.TabPage tabPageAudio;
        private System.Windows.Forms.TabPage tabPageControls;
        private System.Windows.Forms.TabPage tabPageCamera;
    }
}
