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
            this.groupBoxScreenshotOptions = new Fo76ini.Controls.StyledGroupBox();
            this.buttonGalleryDeleteThumbnails = new System.Windows.Forms.Button();
            this.checkBoxGallerySearchRecursively = new System.Windows.Forms.CheckBox();
            this.textBoxGalleryPaths = new System.Windows.Forms.TextBox();
            this.labelGalleryAdditionalPaths = new System.Windows.Forms.Label();
            this.numScreenshotIndex = new System.Windows.Forms.NumericUpDown();
            this.labelScreenshotIndex = new System.Windows.Forms.Label();
            this.labelGalleryTitle = new System.Windows.Forms.Label();
            this.panelGallery = new System.Windows.Forms.Panel();
            this.pictureBoxGalleryLoadingGIF = new System.Windows.Forms.PictureBox();
            this.labelGalleryTip = new System.Windows.Forms.Label();
            this.listViewScreenshots = new System.Windows.Forms.ListView();
            this.sliderGalleryThumbnailSize = new ColorSlider.ColorSlider();
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
            this.toolTip = new Fo76ini.Controls.CustomToolTip(this.components);
            this.panelGalleryOptions.SuspendLayout();
            this.groupBoxScreenshotOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numScreenshotIndex)).BeginInit();
            this.panelGallery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGalleryLoadingGIF)).BeginInit();
            this.contextMenuStripGallery.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelGalleryOptions
            // 
            this.panelGalleryOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGalleryOptions.Controls.Add(this.groupBoxScreenshotOptions);
            this.panelGalleryOptions.Location = new System.Drawing.Point(579, 54);
            this.panelGalleryOptions.Name = "panelGalleryOptions";
            this.panelGalleryOptions.Size = new System.Drawing.Size(221, 396);
            this.panelGalleryOptions.TabIndex = 66;
            // 
            // groupBoxScreenshotOptions
            // 
            this.groupBoxScreenshotOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxScreenshotOptions.BackColor = System.Drawing.Color.White;
            this.groupBoxScreenshotOptions.BorderColor = System.Drawing.Color.Silver;
            this.groupBoxScreenshotOptions.BorderWidth = 1;
            this.groupBoxScreenshotOptions.Controls.Add(this.buttonGalleryDeleteThumbnails);
            this.groupBoxScreenshotOptions.Controls.Add(this.checkBoxGallerySearchRecursively);
            this.groupBoxScreenshotOptions.Controls.Add(this.textBoxGalleryPaths);
            this.groupBoxScreenshotOptions.Controls.Add(this.labelGalleryAdditionalPaths);
            this.groupBoxScreenshotOptions.Controls.Add(this.numScreenshotIndex);
            this.groupBoxScreenshotOptions.Controls.Add(this.labelScreenshotIndex);
            this.groupBoxScreenshotOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxScreenshotOptions.Location = new System.Drawing.Point(4, 4);
            this.groupBoxScreenshotOptions.Name = "groupBoxScreenshotOptions";
            this.groupBoxScreenshotOptions.Size = new System.Drawing.Size(214, 389);
            this.groupBoxScreenshotOptions.TabIndex = 0;
            this.groupBoxScreenshotOptions.TabStop = false;
            this.groupBoxScreenshotOptions.Text = "Options";
            this.groupBoxScreenshotOptions.TitleAlignment = Fo76ini.Controls.TextAlignment.Left;
            this.groupBoxScreenshotOptions.TitleBorderMargin = 6;
            this.groupBoxScreenshotOptions.TitleBorderPadding = 4;
            this.groupBoxScreenshotOptions.TitleForeColor = System.Drawing.Color.Black;
            // 
            // buttonGalleryDeleteThumbnails
            // 
            this.buttonGalleryDeleteThumbnails.Location = new System.Drawing.Point(10, 77);
            this.buttonGalleryDeleteThumbnails.Name = "buttonGalleryDeleteThumbnails";
            this.buttonGalleryDeleteThumbnails.Size = new System.Drawing.Size(198, 23);
            this.buttonGalleryDeleteThumbnails.TabIndex = 66;
            this.buttonGalleryDeleteThumbnails.Text = "Delete thumbnails";
            this.buttonGalleryDeleteThumbnails.UseVisualStyleBackColor = true;
            this.buttonGalleryDeleteThumbnails.Click += new System.EventHandler(this.buttonGalleryDeleteThumbnails_Click);
            // 
            // checkBoxGallerySearchRecursively
            // 
            this.checkBoxGallerySearchRecursively.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxGallerySearchRecursively.Location = new System.Drawing.Point(10, 337);
            this.checkBoxGallerySearchRecursively.Name = "checkBoxGallerySearchRecursively";
            this.checkBoxGallerySearchRecursively.Size = new System.Drawing.Size(198, 46);
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
            this.textBoxGalleryPaths.Location = new System.Drawing.Point(10, 148);
            this.textBoxGalleryPaths.Multiline = true;
            this.textBoxGalleryPaths.Name = "textBoxGalleryPaths";
            this.textBoxGalleryPaths.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxGalleryPaths.Size = new System.Drawing.Size(198, 183);
            this.textBoxGalleryPaths.TabIndex = 64;
            this.textBoxGalleryPaths.WordWrap = false;
            this.textBoxGalleryPaths.TextChanged += new System.EventHandler(this.textBoxGalleryPaths_TextChanged);
            // 
            // labelGalleryAdditionalPaths
            // 
            this.labelGalleryAdditionalPaths.Location = new System.Drawing.Point(7, 113);
            this.labelGalleryAdditionalPaths.Name = "labelGalleryAdditionalPaths";
            this.labelGalleryAdditionalPaths.Size = new System.Drawing.Size(201, 32);
            this.labelGalleryAdditionalPaths.TabIndex = 63;
            this.labelGalleryAdditionalPaths.Text = "Additonal paths (newline separated):";
            // 
            // numScreenshotIndex
            // 
            this.numScreenshotIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numScreenshotIndex.Location = new System.Drawing.Point(10, 39);
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
            this.numScreenshotIndex.Size = new System.Drawing.Size(198, 22);
            this.numScreenshotIndex.TabIndex = 3;
            // 
            // labelScreenshotIndex
            // 
            this.labelScreenshotIndex.AutoSize = true;
            this.labelScreenshotIndex.Location = new System.Drawing.Point(7, 20);
            this.labelScreenshotIndex.Name = "labelScreenshotIndex";
            this.labelScreenshotIndex.Size = new System.Drawing.Size(113, 16);
            this.labelScreenshotIndex.TabIndex = 0;
            this.labelScreenshotIndex.Text = "Screenshot index:";
            // 
            // labelGalleryTitle
            // 
            this.labelGalleryTitle.AutoSize = true;
            this.labelGalleryTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGalleryTitle.Location = new System.Drawing.Point(10, 15);
            this.labelGalleryTitle.Name = "labelGalleryTitle";
            this.labelGalleryTitle.Size = new System.Drawing.Size(80, 30);
            this.labelGalleryTitle.TabIndex = 68;
            this.labelGalleryTitle.Text = "Gallery";
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
            this.panelGallery.Location = new System.Drawing.Point(3, 54);
            this.panelGallery.Name = "panelGallery";
            this.panelGallery.Size = new System.Drawing.Size(574, 393);
            this.panelGallery.TabIndex = 64;
            // 
            // pictureBoxGalleryLoadingGIF
            // 
            this.pictureBoxGalleryLoadingGIF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxGalleryLoadingGIF.BackColor = System.Drawing.Color.White;
            this.pictureBoxGalleryLoadingGIF.Image = global::Fo76ini.Properties.Resources.Spinner_200;
            this.pictureBoxGalleryLoadingGIF.Location = new System.Drawing.Point(-4, 0);
            this.pictureBoxGalleryLoadingGIF.Name = "pictureBoxGalleryLoadingGIF";
            this.pictureBoxGalleryLoadingGIF.Size = new System.Drawing.Size(574, 396);
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
            this.labelGalleryTip.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelGalleryTip.ForeColor = System.Drawing.Color.Gray;
            this.labelGalleryTip.Location = new System.Drawing.Point(0, 0);
            this.labelGalleryTip.Margin = new System.Windows.Forms.Padding(20);
            this.labelGalleryTip.Name = "labelGalleryTip";
            this.labelGalleryTip.Size = new System.Drawing.Size(574, 393);
            this.labelGalleryTip.TabIndex = 4;
            this.labelGalleryTip.Text = "Click \"Refresh gallery\" in the top right corner to display screenshots and photos" +
    ".";
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
            this.listViewScreenshots.Size = new System.Drawing.Size(574, 393);
            this.listViewScreenshots.TabIndex = 1;
            this.listViewScreenshots.UseCompatibleStateImageBehavior = false;
            // 
            // sliderGalleryThumbnailSize
            // 
            this.sliderGalleryThumbnailSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sliderGalleryThumbnailSize.BackColor = System.Drawing.Color.Transparent;
            this.sliderGalleryThumbnailSize.BarPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(94)))), ((int)(((byte)(110)))));
            this.sliderGalleryThumbnailSize.BarPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(60)))), ((int)(((byte)(74)))));
            this.sliderGalleryThumbnailSize.BorderRoundRectSize = new System.Drawing.Size(8, 8);
            this.sliderGalleryThumbnailSize.ElapsedInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderGalleryThumbnailSize.ElapsedPenColorBottom = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(130)))), ((int)(((byte)(208)))));
            this.sliderGalleryThumbnailSize.ElapsedPenColorTop = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(140)))), ((int)(((byte)(180)))));
            this.sliderGalleryThumbnailSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.sliderGalleryThumbnailSize.ForeColor = System.Drawing.Color.White;
            this.sliderGalleryThumbnailSize.LargeChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderGalleryThumbnailSize.Location = new System.Drawing.Point(534, 15);
            this.sliderGalleryThumbnailSize.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderGalleryThumbnailSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderGalleryThumbnailSize.Name = "sliderGalleryThumbnailSize";
            this.sliderGalleryThumbnailSize.ScaleDivisions = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.sliderGalleryThumbnailSize.ScaleSubDivisions = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.sliderGalleryThumbnailSize.ShowDivisionsText = false;
            this.sliderGalleryThumbnailSize.ShowSmallScale = false;
            this.sliderGalleryThumbnailSize.Size = new System.Drawing.Size(175, 36);
            this.sliderGalleryThumbnailSize.SmallChange = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderGalleryThumbnailSize.TabIndex = 67;
            this.sliderGalleryThumbnailSize.ThumbInnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderGalleryThumbnailSize.ThumbPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(56)))), ((int)(((byte)(152)))));
            this.sliderGalleryThumbnailSize.ThumbRoundRectSize = new System.Drawing.Size(16, 16);
            this.sliderGalleryThumbnailSize.ThumbSize = new System.Drawing.Size(16, 16);
            this.sliderGalleryThumbnailSize.TickAdd = 0F;
            this.sliderGalleryThumbnailSize.TickColor = System.Drawing.Color.White;
            this.sliderGalleryThumbnailSize.TickDivide = 0F;
            this.sliderGalleryThumbnailSize.TickStyle = System.Windows.Forms.TickStyle.None;
            this.sliderGalleryThumbnailSize.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sliderGalleryThumbnailSize.Scroll += new System.Windows.Forms.ScrollEventHandler(this.sliderGalleryThumbnailSize_Scroll);
            // 
            // buttonGalleryShowOptions
            // 
            this.buttonGalleryShowOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGalleryShowOptions.BackColor = System.Drawing.Color.Transparent;
            this.buttonGalleryShowOptions.FlatAppearance.BorderSize = 0;
            this.buttonGalleryShowOptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonGalleryShowOptions.Image = global::Fo76ini.Properties.Resources.cog_24;
            this.buttonGalleryShowOptions.Location = new System.Drawing.Point(757, 15);
            this.buttonGalleryShowOptions.Name = "buttonGalleryShowOptions";
            this.buttonGalleryShowOptions.Size = new System.Drawing.Size(36, 36);
            this.buttonGalleryShowOptions.TabIndex = 69;
            this.buttonGalleryShowOptions.Tag = "SmallButton";
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
            this.buttonRefreshGallery.Location = new System.Drawing.Point(715, 15);
            this.buttonRefreshGallery.Name = "buttonRefreshGallery";
            this.buttonRefreshGallery.Size = new System.Drawing.Size(36, 36);
            this.buttonRefreshGallery.TabIndex = 65;
            this.buttonRefreshGallery.Tag = "SmallButton";
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
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 20000;
            this.toolTip.BackColor = System.Drawing.Color.White;
            this.toolTip.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolTip.ForeColor = System.Drawing.Color.Black;
            this.toolTip.InitialDelay = 500;
            this.toolTip.OwnerDraw = true;
            this.toolTip.Padding = new System.Drawing.Size(6, 6);
            this.toolTip.ReshowDelay = 100;
            this.toolTip.ShowAlways = true;
            // 
            // UserControlGallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelGalleryOptions);
            this.Controls.Add(this.labelGalleryTitle);
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
            this.contextMenuStripGallery.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelGalleryOptions;
        private Fo76ini.Controls.StyledGroupBox groupBoxScreenshotOptions;
        private System.Windows.Forms.Button buttonGalleryDeleteThumbnails;
        private System.Windows.Forms.CheckBox checkBoxGallerySearchRecursively;
        private System.Windows.Forms.TextBox textBoxGalleryPaths;
        private System.Windows.Forms.Label labelGalleryAdditionalPaths;
        private System.Windows.Forms.NumericUpDown numScreenshotIndex;
        private System.Windows.Forms.Label labelScreenshotIndex;
        private System.Windows.Forms.Label labelGalleryTitle;
        private System.Windows.Forms.Panel panelGallery;
        private System.Windows.Forms.PictureBox pictureBoxGalleryLoadingGIF;
        private System.Windows.Forms.Label labelGalleryTip;
        private System.Windows.Forms.ListView listViewScreenshots;
        private ColorSlider.ColorSlider sliderGalleryThumbnailSize;
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
        private Controls.CustomToolTip toolTip;
    }
}
