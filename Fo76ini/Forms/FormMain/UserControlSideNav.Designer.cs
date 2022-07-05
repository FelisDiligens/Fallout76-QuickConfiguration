﻿namespace Fo76ini.Forms.FormMain
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
            this.gameFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.buttonBrowse = new Fo76ini.Controls.StyledButton();
            this.buttonSettings = new Fo76ini.Controls.StyledButton();
            this.buttonMods = new Fo76ini.Controls.StyledButton();
            this.buttonUpdate = new Fo76ini.Controls.StyledButton();
            this.buttonApply = new Fo76ini.Controls.StyledButton();
            this.buttonPlay = new Fo76ini.Controls.StyledButton();
            this.pictureBoxSpacer = new System.Windows.Forms.PictureBox();
            this.buttonTweaks = new Fo76ini.Controls.StyledButton();
            this.buttonPipboy = new Fo76ini.Controls.StyledButton();
            this.buttonGallery = new Fo76ini.Controls.StyledButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonHome = new Fo76ini.Controls.StyledButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.contextMenuStripBrowse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpacer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelLogo
            // 
            this.labelLogo.BackColor = System.Drawing.Color.Transparent;
            this.labelLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLogo.ForeColor = System.Drawing.Color.White;
            this.labelLogo.Location = new System.Drawing.Point(3, 64);
            this.labelLogo.Name = "labelLogo";
            this.labelLogo.Size = new System.Drawing.Size(194, 30);
            this.labelLogo.TabIndex = 1;
            this.labelLogo.Text = "Quick Configuration";
            this.labelLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = global::Fo76ini.Properties.Resources.fallout76_logo_white;
            this.pictureBoxLogo.Location = new System.Drawing.Point(0, 8);
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
            this.gameFolderToolStripMenuItem,
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
            this.contextMenuStripBrowse.Size = new System.Drawing.Size(215, 242);
            // 
            // gameFolderToolStripMenuItem
            // 
            this.gameFolderToolStripMenuItem.Name = "gameFolderToolStripMenuItem";
            this.gameFolderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.gameFolderToolStripMenuItem.Text = "Game installation folder";
            this.gameFolderToolStripMenuItem.Click += new System.EventHandler(this.gameFolderToolStripMenuItem_Click);
            // 
            // gamesConfigurationFolderToolStripMenuItem
            // 
            this.gamesConfigurationFolderToolStripMenuItem.Name = "gamesConfigurationFolderToolStripMenuItem";
            this.gamesConfigurationFolderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.gamesConfigurationFolderToolStripMenuItem.Text = "Game configuration folder";
            this.gamesConfigurationFolderToolStripMenuItem.Click += new System.EventHandler(this.gamesConfigurationFolderToolStripMenuItem_Click);
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
            this.toolConfigurationFolderToolStripMenuItem.Click += new System.EventHandler(this.toolConfigurationFolderToolStripMenuItem_Click);
            // 
            // toolLanguagesFolderToolStripMenuItem
            // 
            this.toolLanguagesFolderToolStripMenuItem.Name = "toolLanguagesFolderToolStripMenuItem";
            this.toolLanguagesFolderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.toolLanguagesFolderToolStripMenuItem.Text = "Tool languages folder";
            this.toolLanguagesFolderToolStripMenuItem.Click += new System.EventHandler(this.toolLanguagesFolderToolStripMenuItem_Click);
            // 
            // toolInstallationFolderToolStripMenuItem
            // 
            this.toolInstallationFolderToolStripMenuItem.Name = "toolInstallationFolderToolStripMenuItem";
            this.toolInstallationFolderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.toolInstallationFolderToolStripMenuItem.Text = "Tool installation folder";
            this.toolInstallationFolderToolStripMenuItem.Click += new System.EventHandler(this.toolInstallationFolderToolStripMenuItem_Click);
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
            this.steamScreenshotFolderToolStripMenuItem.Click += new System.EventHandler(this.steamScreenshotFolderToolStripMenuItem_Click);
            // 
            // gamePhotosFolderToolStripMenuItem
            // 
            this.gamePhotosFolderToolStripMenuItem.Name = "gamePhotosFolderToolStripMenuItem";
            this.gamePhotosFolderToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.gamePhotosFolderToolStripMenuItem.Text = "Game photos folder";
            this.gamePhotosFolderToolStripMenuItem.Click += new System.EventHandler(this.gamePhotosFolderToolStripMenuItem_Click);
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
            this.editFallout76iniToolStripMenuItem.Click += new System.EventHandler(this.editFallout76iniToolStripMenuItem_Click);
            // 
            // editFallout76PrefsiniToolStripMenuItem
            // 
            this.editFallout76PrefsiniToolStripMenuItem.Name = "editFallout76PrefsiniToolStripMenuItem";
            this.editFallout76PrefsiniToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.editFallout76PrefsiniToolStripMenuItem.Text = "Edit Fallout76Prefs.ini";
            this.editFallout76PrefsiniToolStripMenuItem.Click += new System.EventHandler(this.editFallout76PrefsiniToolStripMenuItem_Click);
            // 
            // editFallout76CustominiToolStripMenuItem
            // 
            this.editFallout76CustominiToolStripMenuItem.Name = "editFallout76CustominiToolStripMenuItem";
            this.editFallout76CustominiToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.editFallout76CustominiToolStripMenuItem.Text = "Edit Fallout76Custom.ini";
            this.editFallout76CustominiToolStripMenuItem.Click += new System.EventHandler(this.editFallout76CustominiToolStripMenuItem_Click);
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonBrowse.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBrowse.ForeColor = System.Drawing.Color.White;
            this.buttonBrowse.Image = global::Fo76ini.Properties.Resources.folder_24;
            this.buttonBrowse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBrowse.Location = new System.Drawing.Point(3, 185);
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
            this.buttonSettings.Location = new System.Drawing.Point(3, 461);
            this.buttonSettings.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Padding = 10;
            this.buttonSettings.Size = new System.Drawing.Size(194, 36);
            this.buttonSettings.TabIndex = 10;
            this.buttonSettings.Text = "Settings";
            this.buttonSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // buttonMods
            // 
            this.buttonMods.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonMods.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMods.ForeColor = System.Drawing.Color.White;
            this.buttonMods.Image = global::Fo76ini.Properties.Resources.puzzle_4_24;
            this.buttonMods.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMods.Location = new System.Drawing.Point(3, 323);
            this.buttonMods.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonMods.Name = "buttonMods";
            this.buttonMods.Padding = 10;
            this.buttonMods.Size = new System.Drawing.Size(194, 36);
            this.buttonMods.TabIndex = 9;
            this.buttonMods.Text = "Mods";
            this.buttonMods.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonMods.UseVisualStyleBackColor = true;
            this.buttonMods.Click += new System.EventHandler(this.buttonMods_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonUpdate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonUpdate.Image = global::Fo76ini.Properties.Resources.available_updates;
            this.buttonUpdate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdate.Location = new System.Drawing.Point(3, 500);
            this.buttonUpdate.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Padding = 10;
            this.buttonUpdate.Size = new System.Drawing.Size(194, 36);
            this.buttonUpdate.TabIndex = 8;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonUpdate.UseVisualStyleBackColor = true;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonApply
            // 
            this.buttonApply.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonApply.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonApply.ForeColor = System.Drawing.Color.White;
            this.buttonApply.Image = global::Fo76ini.Properties.Resources.save_24;
            this.buttonApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonApply.Location = new System.Drawing.Point(3, 146);
            this.buttonApply.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonApply.Name = "buttonApply";
            this.buttonApply.Padding = 10;
            this.buttonApply.Size = new System.Drawing.Size(194, 36);
            this.buttonApply.TabIndex = 7;
            this.buttonApply.Text = "Save";
            this.buttonApply.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonApply.UseVisualStyleBackColor = true;
            this.buttonApply.Click += new System.EventHandler(this.buttonApply_Click);
            // 
            // buttonPlay
            // 
            this.buttonPlay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonPlay.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPlay.ForeColor = System.Drawing.Color.White;
            this.buttonPlay.Image = global::Fo76ini.Properties.Resources.play;
            this.buttonPlay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPlay.Location = new System.Drawing.Point(3, 107);
            this.buttonPlay.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonPlay.Name = "buttonPlay";
            this.buttonPlay.Padding = 10;
            this.buttonPlay.Size = new System.Drawing.Size(194, 36);
            this.buttonPlay.TabIndex = 6;
            this.buttonPlay.Text = "Play";
            this.buttonPlay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPlay.UseVisualStyleBackColor = true;
            this.buttonPlay.Click += new System.EventHandler(this.buttonPlay_Click);
            // 
            // pictureBoxSpacer
            // 
            this.pictureBoxSpacer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBoxSpacer.Location = new System.Drawing.Point(0, 231);
            this.pictureBoxSpacer.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBoxSpacer.Name = "pictureBoxSpacer";
            this.pictureBoxSpacer.Size = new System.Drawing.Size(200, 1);
            this.pictureBoxSpacer.TabIndex = 12;
            this.pictureBoxSpacer.TabStop = false;
            // 
            // buttonTweaks
            // 
            this.buttonTweaks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonTweaks.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonTweaks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTweaks.ForeColor = System.Drawing.Color.White;
            this.buttonTweaks.Image = global::Fo76ini.Properties.Resources.plus_24;
            this.buttonTweaks.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTweaks.Location = new System.Drawing.Point(3, 284);
            this.buttonTweaks.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonTweaks.Name = "buttonTweaks";
            this.buttonTweaks.Padding = 10;
            this.buttonTweaks.Size = new System.Drawing.Size(194, 36);
            this.buttonTweaks.TabIndex = 13;
            this.buttonTweaks.Text = "Tweaks";
            this.buttonTweaks.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonTweaks.UseVisualStyleBackColor = true;
            // 
            // buttonPipboy
            // 
            this.buttonPipboy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonPipboy.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonPipboy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPipboy.ForeColor = System.Drawing.Color.White;
            this.buttonPipboy.Image = global::Fo76ini.Properties.Resources.plus_24;
            this.buttonPipboy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPipboy.Location = new System.Drawing.Point(3, 362);
            this.buttonPipboy.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonPipboy.Name = "buttonPipboy";
            this.buttonPipboy.Padding = 10;
            this.buttonPipboy.Size = new System.Drawing.Size(194, 36);
            this.buttonPipboy.TabIndex = 14;
            this.buttonPipboy.Text = "Pip-Boy";
            this.buttonPipboy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonPipboy.UseVisualStyleBackColor = true;
            // 
            // buttonGallery
            // 
            this.buttonGallery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonGallery.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonGallery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGallery.ForeColor = System.Drawing.Color.White;
            this.buttonGallery.Image = global::Fo76ini.Properties.Resources.plus_24;
            this.buttonGallery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGallery.Location = new System.Drawing.Point(3, 401);
            this.buttonGallery.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonGallery.Name = "buttonGallery";
            this.buttonGallery.Padding = 10;
            this.buttonGallery.Size = new System.Drawing.Size(194, 36);
            this.buttonGallery.TabIndex = 15;
            this.buttonGallery.Text = "Gallery";
            this.buttonGallery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonGallery.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pictureBox1.Location = new System.Drawing.Point(0, 447);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 1);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // buttonHome
            // 
            this.buttonHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(24)))));
            this.buttonHome.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHome.ForeColor = System.Drawing.Color.White;
            this.buttonHome.Image = global::Fo76ini.Properties.Resources.plus_24;
            this.buttonHome.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHome.Location = new System.Drawing.Point(3, 245);
            this.buttonHome.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.buttonHome.Name = "buttonHome";
            this.buttonHome.Padding = 10;
            this.buttonHome.Size = new System.Drawing.Size(194, 36);
            this.buttonHome.TabIndex = 17;
            this.buttonHome.Text = "Home";
            this.buttonHome.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonHome.UseVisualStyleBackColor = true;
            // 
            // UserControlSideNav
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.Controls.Add(this.buttonHome);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonGallery);
            this.Controls.Add(this.buttonPipboy);
            this.Controls.Add(this.buttonTweaks);
            this.Controls.Add(this.pictureBoxSpacer);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSpacer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem gameFolderToolStripMenuItem;
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
        private System.Windows.Forms.PictureBox pictureBoxSpacer;
        private Controls.StyledButton buttonTweaks;
        private Controls.StyledButton buttonPipboy;
        private Controls.StyledButton buttonGallery;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Controls.StyledButton buttonHome;
    }
}
