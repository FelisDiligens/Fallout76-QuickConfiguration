namespace Fo76ini.Forms.FormMain
{
    partial class UserControlGallery
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
            this.panelGalleryOptions = new System.Windows.Forms.Panel();
            this.groupBoxScreenshotOptions = new System.Windows.Forms.GroupBox();
            this.buttonGalleryDeleteThumbnails = new System.Windows.Forms.Button();
            this.checkBoxGallerySearchRecursively = new System.Windows.Forms.CheckBox();
            this.textBoxGalleryPaths = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numScreenshotIndex = new System.Windows.Forms.NumericUpDown();
            this.labelScreenshotIndex = new System.Windows.Forms.Label();
            this.labelGallery = new System.Windows.Forms.Label();
            this.panelGallery = new System.Windows.Forms.Panel();
            this.pictureBoxGalleryLoadingGIF = new System.Windows.Forms.PictureBox();
            this.labelGalleryTip = new System.Windows.Forms.Label();
            this.listViewScreenshots = new System.Windows.Forms.ListView();
            this.sliderGalleryThumbnailSize = new System.Windows.Forms.TrackBar();
            this.buttonGalleryShowOptions = new System.Windows.Forms.Button();
            this.buttonRefreshGallery = new System.Windows.Forms.Button();
            this.backgroundWorkerLoadGallery = new System.ComponentModel.BackgroundWorker();
            this.contextMenuStripGallery = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panelGalleryOptions.SuspendLayout();
            this.groupBoxScreenshotOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScreenshotIndex)).BeginInit();
            this.panelGallery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGalleryLoadingGIF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderGalleryThumbnailSize)).BeginInit();
            this.contextMenuStripGallery.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGalleryOptions
            // 
            this.panelGalleryOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGalleryOptions.Controls.Add(this.groupBoxScreenshotOptions);
            this.panelGalleryOptions.Location = new System.Drawing.Point(579, 42);
            this.panelGalleryOptions.Name = "panelGalleryOptions";
            this.panelGalleryOptions.Size = new System.Drawing.Size(221, 408);
            this.panelGalleryOptions.TabIndex = 66;
            // 
            // groupBoxScreenshotOptions
            // 
            this.groupBoxScreenshotOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxScreenshotOptions.Controls.Add(this.buttonGalleryDeleteThumbnails);
            this.groupBoxScreenshotOptions.Controls.Add(this.checkBoxGallerySearchRecursively);
            this.groupBoxScreenshotOptions.Controls.Add(this.textBoxGalleryPaths);
            this.groupBoxScreenshotOptions.Controls.Add(this.label3);
            this.groupBoxScreenshotOptions.Controls.Add(this.numScreenshotIndex);
            this.groupBoxScreenshotOptions.Controls.Add(this.labelScreenshotIndex);
            this.groupBoxScreenshotOptions.Location = new System.Drawing.Point(4, 4);
            this.groupBoxScreenshotOptions.Name = "groupBoxScreenshotOptions";
            this.groupBoxScreenshotOptions.Size = new System.Drawing.Size(214, 401);
            this.groupBoxScreenshotOptions.TabIndex = 0;
            this.groupBoxScreenshotOptions.TabStop = false;
            this.groupBoxScreenshotOptions.Text = "Options";
            // 
            // buttonGalleryDeleteThumbnails
            // 
            this.buttonGalleryDeleteThumbnails.Location = new System.Drawing.Point(10, 109);
            this.buttonGalleryDeleteThumbnails.Name = "buttonGalleryDeleteThumbnails";
            this.buttonGalleryDeleteThumbnails.Size = new System.Drawing.Size(196, 23);
            this.buttonGalleryDeleteThumbnails.TabIndex = 66;
            this.buttonGalleryDeleteThumbnails.Text = "Delete thumbnails";
            this.buttonGalleryDeleteThumbnails.UseVisualStyleBackColor = true;
            this.buttonGalleryDeleteThumbnails.Click += new System.EventHandler(this.buttonGalleryDeleteThumbnails_Click);
            // 
            // checkBoxGallerySearchRecursively
            // 
            this.checkBoxGallerySearchRecursively.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxGallerySearchRecursively.AutoSize = true;
            this.checkBoxGallerySearchRecursively.Location = new System.Drawing.Point(10, 371);
            this.checkBoxGallerySearchRecursively.Name = "checkBoxGallerySearchRecursively";
            this.checkBoxGallerySearchRecursively.Size = new System.Drawing.Size(164, 17);
            this.checkBoxGallerySearchRecursively.TabIndex = 65;
            this.checkBoxGallerySearchRecursively.Text = "Search subfolders recursively";
            this.checkBoxGallerySearchRecursively.UseVisualStyleBackColor = true;
            this.checkBoxGallerySearchRecursively.CheckedChanged += new System.EventHandler(this.checkBoxGallerySearchRecursively_CheckedChanged);
            // 
            // textBoxGalleryPaths
            // 
            this.textBoxGalleryPaths.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGalleryPaths.Location = new System.Drawing.Point(10, 170);
            this.textBoxGalleryPaths.Multiline = true;
            this.textBoxGalleryPaths.Name = "textBoxGalleryPaths";
            this.textBoxGalleryPaths.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxGalleryPaths.Size = new System.Drawing.Size(198, 195);
            this.textBoxGalleryPaths.TabIndex = 64;
            this.textBoxGalleryPaths.WordWrap = false;
            this.textBoxGalleryPaths.TextChanged += new System.EventHandler(this.textBoxGalleryPaths_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 13);
            this.label3.TabIndex = 63;
            this.label3.Text = "Additonal paths (newline separated):";
            // 
            // numScreenshotIndex
            // 
            this.numScreenshotIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numScreenshotIndex.Location = new System.Drawing.Point(12, 36);
            this.numScreenshotIndex.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.numScreenshotIndex.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.numScreenshotIndex.Name = "numScreenshotIndex";
            this.numScreenshotIndex.Size = new System.Drawing.Size(196, 20);
            this.numScreenshotIndex.TabIndex = 3;
            // 
            // labelScreenshotIndex
            // 
            this.labelScreenshotIndex.AutoSize = true;
            this.labelScreenshotIndex.Location = new System.Drawing.Point(7, 20);
            this.labelScreenshotIndex.Name = "labelScreenshotIndex";
            this.labelScreenshotIndex.Size = new System.Drawing.Size(92, 13);
            this.labelScreenshotIndex.TabIndex = 0;
            this.labelScreenshotIndex.Text = "Screenshot index:";
            // 
            // labelGallery
            // 
            this.labelGallery.AutoSize = true;
            this.labelGallery.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGallery.Location = new System.Drawing.Point(6, 6);
            this.labelGallery.Name = "labelGallery";
            this.labelGallery.Size = new System.Drawing.Size(68, 24);
            this.labelGallery.TabIndex = 68;
            this.labelGallery.Text = "Gallery";
            // 
            // panelGallery
            // 
            this.panelGallery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGallery.AutoScroll = true;
            this.panelGallery.Controls.Add(this.pictureBoxGalleryLoadingGIF);
            this.panelGallery.Controls.Add(this.labelGalleryTip);
            this.panelGallery.Controls.Add(this.listViewScreenshots);
            this.panelGallery.Location = new System.Drawing.Point(3, 42);
            this.panelGallery.Name = "panelGallery";
            this.panelGallery.Size = new System.Drawing.Size(574, 405);
            this.panelGallery.TabIndex = 64;
            // 
            // pictureBoxGalleryLoadingGIF
            // 
            this.pictureBoxGalleryLoadingGIF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxGalleryLoadingGIF.BackColor = System.Drawing.Color.White;
            this.pictureBoxGalleryLoadingGIF.Image = global::Fo76ini.Properties.Resources.Spinner_200;
            this.pictureBoxGalleryLoadingGIF.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxGalleryLoadingGIF.Name = "pictureBoxGalleryLoadingGIF";
            this.pictureBoxGalleryLoadingGIF.Size = new System.Drawing.Size(574, 408);
            this.pictureBoxGalleryLoadingGIF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBoxGalleryLoadingGIF.TabIndex = 3;
            this.pictureBoxGalleryLoadingGIF.TabStop = false;
            this.pictureBoxGalleryLoadingGIF.Visible = false;
            // 
            // labelGalleryTip
            // 
            this.labelGalleryTip.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelGalleryTip.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGalleryTip.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelGalleryTip.Location = new System.Drawing.Point(0, 0);
            this.labelGalleryTip.Margin = new System.Windows.Forms.Padding(20);
            this.labelGalleryTip.Name = "labelGalleryTip";
            this.labelGalleryTip.Size = new System.Drawing.Size(574, 405);
            this.labelGalleryTip.TabIndex = 4;
            this.labelGalleryTip.Text = "Click \"Refresh gallery\" to display screenshots and photos.";
            this.labelGalleryTip.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listViewScreenshots
            // 
            this.listViewScreenshots.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewScreenshots.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewScreenshots.HideSelection = false;
            this.listViewScreenshots.Location = new System.Drawing.Point(0, 0);
            this.listViewScreenshots.Name = "listViewScreenshots";
            this.listViewScreenshots.Size = new System.Drawing.Size(574, 405);
            this.listViewScreenshots.TabIndex = 1;
            this.listViewScreenshots.UseCompatibleStateImageBehavior = false;
            // 
            // sliderGalleryThumbnailSize
            // 
            this.sliderGalleryThumbnailSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderGalleryThumbnailSize.BackColor = System.Drawing.SystemColors.Window;
            this.sliderGalleryThumbnailSize.LargeChange = 1;
            this.sliderGalleryThumbnailSize.Location = new System.Drawing.Point(539, 3);
            this.sliderGalleryThumbnailSize.Maximum = 5;
            this.sliderGalleryThumbnailSize.Minimum = 1;
            this.sliderGalleryThumbnailSize.Name = "sliderGalleryThumbnailSize";
            this.sliderGalleryThumbnailSize.Size = new System.Drawing.Size(175, 45);
            this.sliderGalleryThumbnailSize.TabIndex = 67;
            this.sliderGalleryThumbnailSize.Value = 1;
            this.sliderGalleryThumbnailSize.Scroll += new System.EventHandler(this.sliderGalleryThumbnailSize_Scroll);
            // 
            // buttonGalleryShowOptions
            // 
            this.buttonGalleryShowOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGalleryShowOptions.BackColor = System.Drawing.Color.Transparent;
            this.buttonGalleryShowOptions.FlatAppearance.BorderSize = 0;
            this.buttonGalleryShowOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGalleryShowOptions.Image = global::Fo76ini.Properties.Resources.cog_24;
            this.buttonGalleryShowOptions.Location = new System.Drawing.Point(762, 3);
            this.buttonGalleryShowOptions.Name = "buttonGalleryShowOptions";
            this.buttonGalleryShowOptions.Size = new System.Drawing.Size(36, 36);
            this.buttonGalleryShowOptions.TabIndex = 69;
            this.buttonGalleryShowOptions.UseVisualStyleBackColor = false;
            this.buttonGalleryShowOptions.Click += new System.EventHandler(this.buttonGalleryShowOptions_Click);
            // 
            // buttonRefreshGallery
            // 
            this.buttonRefreshGallery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRefreshGallery.BackColor = System.Drawing.Color.Transparent;
            this.buttonRefreshGallery.FlatAppearance.BorderSize = 0;
            this.buttonRefreshGallery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefreshGallery.Image = global::Fo76ini.Properties.Resources.available_updates;
            this.buttonRefreshGallery.Location = new System.Drawing.Point(720, 3);
            this.buttonRefreshGallery.Name = "buttonRefreshGallery";
            this.buttonRefreshGallery.Size = new System.Drawing.Size(36, 36);
            this.buttonRefreshGallery.TabIndex = 65;
            this.buttonRefreshGallery.UseVisualStyleBackColor = false;
            this.buttonRefreshGallery.Click += new System.EventHandler(this.buttonRefreshGallery_Click);
            // 
            // contextMenuStripGallery
            // 
            this.contextMenuStripGallery.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.openFolderToolStripMenuItem,
            this.toolStripSeparator7,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.toolStripSeparator8,
            this.deleteToolStripMenuItem});
            this.contextMenuStripGallery.Name = "contextMenuStrip1";
            this.contextMenuStripGallery.Size = new System.Drawing.Size(138, 126);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // openFolderToolStripMenuItem
            // 
            this.openFolderToolStripMenuItem.Name = "openFolderToolStripMenuItem";
            this.openFolderToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.openFolderToolStripMenuItem.Text = "Open folder";
            this.openFolderToolStripMenuItem.Click += new System.EventHandler(this.openFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(134, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(134, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(137, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // UserControlGallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelGalleryOptions);
            this.Controls.Add(this.labelGallery);
            this.Controls.Add(this.panelGallery);
            this.Controls.Add(this.sliderGalleryThumbnailSize);
            this.Controls.Add(this.buttonGalleryShowOptions);
            this.Controls.Add(this.buttonRefreshGallery);
            this.Name = "UserControlGallery";
            this.Size = new System.Drawing.Size(800, 450);
            this.panelGalleryOptions.ResumeLayout(false);
            this.groupBoxScreenshotOptions.ResumeLayout(false);
            this.groupBoxScreenshotOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScreenshotIndex)).EndInit();
            this.panelGallery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGalleryLoadingGIF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sliderGalleryThumbnailSize)).EndInit();
            this.contextMenuStripGallery.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelGalleryOptions;
        private System.Windows.Forms.GroupBox groupBoxScreenshotOptions;
        private System.Windows.Forms.Button buttonGalleryDeleteThumbnails;
        private System.Windows.Forms.CheckBox checkBoxGallerySearchRecursively;
        private System.Windows.Forms.TextBox textBoxGalleryPaths;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numScreenshotIndex;
        private System.Windows.Forms.Label labelScreenshotIndex;
        private System.Windows.Forms.Label labelGallery;
        private System.Windows.Forms.Panel panelGallery;
        private System.Windows.Forms.PictureBox pictureBoxGalleryLoadingGIF;
        private System.Windows.Forms.Label labelGalleryTip;
        private System.Windows.Forms.ListView listViewScreenshots;
        private System.Windows.Forms.TrackBar sliderGalleryThumbnailSize;
        private System.Windows.Forms.Button buttonGalleryShowOptions;
        private System.Windows.Forms.Button buttonRefreshGallery;
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoadGallery;
        public System.Windows.Forms.ContextMenuStrip contextMenuStripGallery;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
