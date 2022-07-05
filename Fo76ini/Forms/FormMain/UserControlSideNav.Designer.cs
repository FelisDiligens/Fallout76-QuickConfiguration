namespace Fo76ini.Forms.FormMain
{
    partial class UserControlSideNav
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
            this.labelLogo = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelProfile = new System.Windows.Forms.Label();
            this.contextMenuStripBrowse = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.buttonBrowse = new Fo76ini.Controls.StyledButton();
            this.buttonSettings = new Fo76ini.Controls.StyledButton();
            this.buttonMods = new Fo76ini.Controls.StyledButton();
            this.buttonUpdate = new Fo76ini.Controls.StyledButton();
            this.buttonApply = new Fo76ini.Controls.StyledButton();
            this.buttonPlay = new Fo76ini.Controls.StyledButton();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.gamesConfigurationFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolConfigurationFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolLanguagesFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolInstallationFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.steamScreenshotFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gamePhotosFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.editFallout76iniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editFallout76PrefsiniToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editFallout76CustominiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.contextMenuStripBrowse.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelLogo
            // 
            this.labelLogo.BackColor = System.Drawing.Color.Transparent;
            this.labelLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogo.ForeColor = System.Drawing.Color.White;
            this.labelLogo.Location = new System.Drawing.Point(3, 56);
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(194, 30);
            this.labelLogo.TabIndex = 1;
            this.labelLogo.Text = "Quick Configuration";
            this.labelLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::Fo76ini.Properties.Resources.fallout76_logo_white;
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(200, 63);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelProfile
            // 
            this.labelProfile.AutoSize = true;
            this.labelProfile.Location = new System.Drawing.Point(34, 298);
            this.labelProfile.Name = "labelProfile";
            this.labelProfile.Size = new System.Drawing.Size(36, 13);
            this.labelProfile.TabIndex = 5;
            this.labelProfile.Text = "Profile";
            // 
            // contextMenuStripBrowse
            // 
            this.contextMenuStripBrowse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.gamesConfigurationFolderToolStripMenuItem,
            this.toolStripSeparator4,
            this.toolConfigurationFolderToolStripMenuItem,
            this.toolLanguagesFolderToolStripMenuItem,
            this.toolInstallationFolderToolStripMenuItem,
            this.toolStripSeparator5,
            this.steamScreenshotFolderToolStripMenuItem,
            this.gamePhotosFolderToolStripMenuItem,
            this.toolStripSeparator6,
            this.editFallout76iniToolStripMenuItem,
            this.editFallout76PrefsiniToolStripMenuItem,
            this.editFallout76CustominiToolStripMenuItem});
            this.contextMenuStripBrowse.Name = "contextMenuStripBrowse";
            this.contextMenuStripBrowse.Size = new System.Drawing.Size(215, 264);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonBrowse.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowse.ForeColor = System.Drawing.Color.White;
            this.buttonBrowse.Image = global::Fo76ini.Properties.Resources.folder_24;
            this.buttonBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBrowse.Location = new System.Drawing.Point(3, 294);
            this.buttonBrowse.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Padding = 10;
            this.buttonBrowse.Size = new System.Drawing.Size(194, 36);
            this.buttonBrowse.TabIndex = 11;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonSettings.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.ForeColor = System.Drawing.Color.White;
            this.buttonSettings.Image = global::Fo76ini.Properties.Resources.cog_24;
            this.buttonSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.Location = new System.Drawing.Point(3, 216);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Padding = 10;
            this.buttonSettings.Size = new System.Drawing.Size(194, 36);
            this.buttonSettings.TabIndex = 10;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.UseVisualStyleBackColor = true;
            // 
            // buttonMods
            // 
            this.buttonMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonMods.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMods.ForeColor = System.Drawing.Color.White;
            this.buttonMods.Image = global::Fo76ini.Properties.Resources.puzzle_4_24;
            this.buttonMods.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMods.Location = new System.Drawing.Point(3, 177);
            this.buttonMods.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonMods.Name = "buttonMods";
            this.buttonMods.Padding = 10;
            this.buttonMods.Size = new System.Drawing.Size(194, 36);
            this.buttonMods.TabIndex = 9;
            this.buttonMods.Text = "Mods";
            this.buttonMods.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMods.UseVisualStyleBackColor = true;
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonUpdate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonUpdate.Image = global::Fo76ini.Properties.Resources.available_updates;
            this.buttonUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdate.Location = new System.Drawing.Point(3, 255);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Padding = 10;
            this.buttonUpdate.Size = new System.Drawing.Size(194, 36);
            this.buttonUpdate.TabIndex = 8;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdate.UseVisualStyleBackColor = true;
            // 
            // buttonApply
            // 
            this.buttonApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonApply.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApply.ForeColor = System.Drawing.Color.White;
            this.buttonApply.Image = global::Fo76ini.Properties.Resources.save_24;
            this.buttonApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonApply.Location = new System.Drawing.Point(3, 138);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Padding = 10;
            this.buttonApply.Size = new System.Drawing.Size(194, 36);
            this.buttonApply.TabIndex = 7;
            this.buttonApply.Text = "Apply";
            this.buttonApply.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonApply.UseVisualStyleBackColor = true;
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonPlay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.ForeColor = System.Drawing.Color.White;
            this.buttonPlay.Image = global::Fo76ini.Properties.Resources.play;
            this.buttonPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPlay.Location = new System.Drawing.Point(3, 99);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Padding = 10;
            this.buttonPlay.Size = new System.Drawing.Size(194, 36);
            this.buttonPlay.TabIndex = 6;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPlay.UseVisualStyleBackColor = true;
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(214, 22);
            this.toolStripMenuItem1.Text = "Game installation folder";
            // 
            // gamesConfigurationFolderToolStripMenuItem
            // 
            this.gamesConfigurationFolderToolStripMenuItem.Name = "gamesConfigurationFolderToolStripMenuItem";
            this.gamesConfigurationFolderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.gamesConfigurationFolderToolStripMenuItem.Text = "Game configuration folder";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(211, 6);
            // 
            // toolConfigurationFolderToolStripMenuItem
            // 
            this.toolConfigurationFolderToolStripMenuItem.Name = "toolConfigurationFolderToolStripMenuItem";
            this.toolConfigurationFolderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.toolConfigurationFolderToolStripMenuItem.Text = "Tool configuration folder";
            // 
            // toolLanguagesFolderToolStripMenuItem
            // 
            this.toolLanguagesFolderToolStripMenuItem.Name = "toolLanguagesFolderToolStripMenuItem";
            this.toolLanguagesFolderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.toolLanguagesFolderToolStripMenuItem.Text = "Tool languages folder";
            // 
            // toolInstallationFolderToolStripMenuItem
            // 
            this.toolInstallationFolderToolStripMenuItem.Name = "toolInstallationFolderToolStripMenuItem";
            this.toolInstallationFolderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.toolInstallationFolderToolStripMenuItem.Text = "Tool installation folder";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(211, 6);
            // 
            // steamScreenshotFolderToolStripMenuItem
            // 
            this.steamScreenshotFolderToolStripMenuItem.Name = "steamScreenshotFolderToolStripMenuItem";
            this.steamScreenshotFolderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.steamScreenshotFolderToolStripMenuItem.Text = "Steam screenshot folder";
            // 
            // gamePhotosFolderToolStripMenuItem
            // 
            this.gamePhotosFolderToolStripMenuItem.Name = "gamePhotosFolderToolStripMenuItem";
            this.gamePhotosFolderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.gamePhotosFolderToolStripMenuItem.Text = "Game photos folder";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(211, 6);
            // 
            // editFallout76iniToolStripMenuItem
            // 
            this.editFallout76iniToolStripMenuItem.Name = "editFallout76iniToolStripMenuItem";
            this.editFallout76iniToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.editFallout76iniToolStripMenuItem.Text = "Edit Fallout76.ini";
            // 
            // editFallout76PrefsiniToolStripMenuItem
            // 
            this.editFallout76PrefsiniToolStripMenuItem.Name = "editFallout76PrefsiniToolStripMenuItem";
            this.editFallout76PrefsiniToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.editFallout76PrefsiniToolStripMenuItem.Text = "Edit Fallout76Prefs.ini";
            // 
            // editFallout76CustominiToolStripMenuItem
            // 
            this.editFallout76CustominiToolStripMenuItem.Name = "editFallout76CustominiToolStripMenuItem";
            this.editFallout76CustominiToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.editFallout76CustominiToolStripMenuItem.Text = "Edit Fallout76Custom.ini";
            // 
            // UserControlSideNav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonMods);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.buttonApply);
            this.Controls.Add(this.buttonPlay);
            this.Controls.Add(this.labelProfile);
            this.Controls.Add(this.labelLogo);
            this.Controls.Add(this.pictureBoxLogo);
            this.Name = "UserControlSideNav";
            this.Size = new System.Drawing.Size(200, 600);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.contextMenuStripBrowse.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelLogo;
        private System.Windows.Forms.Label labelProfile;
        private Controls.StyledButton buttonPlay;
        private Controls.StyledButton buttonApply;
        private Controls.StyledButton buttonUpdate;
        private Controls.StyledButton buttonMods;
        private Controls.StyledButton buttonSettings;
        private Controls.StyledButton buttonBrowse;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripBrowse;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gamesConfigurationFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolConfigurationFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolLanguagesFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolInstallationFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem steamScreenshotFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gamePhotosFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem editFallout76iniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editFallout76PrefsiniToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editFallout76CustominiToolStripMenuItem;
    }
}
