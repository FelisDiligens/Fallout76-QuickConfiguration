namespace Fo76ini
{
    partial class FormMods
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMods));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addModarchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.emptyModToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromba2ArchivefrozenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemModsImport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deployToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showConflictingFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadUIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archive2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openArchive2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreba2ArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detectFormatAndCompressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nexusModsAPIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateModInformationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.endorseModsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkForUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGuideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showModmanagerlogtxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showArchive2logtxtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDevToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialogMod = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialogBA2 = new System.Windows.Forms.OpenFileDialog();
            this.timerCheckForNXM = new System.Windows.Forms.Timer(this.components);
            this.toolTip = new Fo76ini.Controls.CustomToolTip(this.components);
            this.panel = new System.Windows.Forms.Panel();
            this.browserModManager = new CefSharp.WinForms.ChromiumWebBrowser();
            this.menuStrip1.SuspendLayout();
            this.panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(784, 24);
            this.menuStrip1.TabIndex = 49;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addModarchiveToolStripMenuItem,
            this.toolStripMenuItemModsImport,
            this.toolStripSeparator1,
            this.saveToolStripMenuItem,
            this.deployToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // addModarchiveToolStripMenuItem
            // 
            this.addModarchiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.emptyModToolStripMenuItem,
            this.fromArchiveToolStripMenuItem,
            this.fromba2ArchivefrozenToolStripMenuItem,
            this.fromFolderToolStripMenuItem});
            this.addModarchiveToolStripMenuItem.Image = global::Fo76ini.Properties.Resources.plus_24;
            this.addModarchiveToolStripMenuItem.Name = "addModarchiveToolStripMenuItem";
            this.addModarchiveToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.addModarchiveToolStripMenuItem.Text = "Add mod";
            // 
            // emptyModToolStripMenuItem
            // 
            this.emptyModToolStripMenuItem.Image = global::Fo76ini.Properties.Resources.plus_24;
            this.emptyModToolStripMenuItem.Name = "emptyModToolStripMenuItem";
            this.emptyModToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.emptyModToolStripMenuItem.Text = "Empty mod";
            this.emptyModToolStripMenuItem.Click += new System.EventHandler(this.emptyModToolStripMenuItem_Click);
            // 
            // fromArchiveToolStripMenuItem
            // 
            this.fromArchiveToolStripMenuItem.Image = global::Fo76ini.Properties.Resources.add_archive_3_24;
            this.fromArchiveToolStripMenuItem.Name = "fromArchiveToolStripMenuItem";
            this.fromArchiveToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.fromArchiveToolStripMenuItem.Text = "From archive";
            this.fromArchiveToolStripMenuItem.Click += new System.EventHandler(this.fromArchiveToolStripMenuItem_Click);
            // 
            // fromba2ArchivefrozenToolStripMenuItem
            // 
            this.fromba2ArchivefrozenToolStripMenuItem.Image = global::Fo76ini.Properties.Resources.add_snowflake_24;
            this.fromba2ArchivefrozenToolStripMenuItem.Name = "fromba2ArchivefrozenToolStripMenuItem";
            this.fromba2ArchivefrozenToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.fromba2ArchivefrozenToolStripMenuItem.Text = "From *.ba2 archive (frozen)";
            this.fromba2ArchivefrozenToolStripMenuItem.Click += new System.EventHandler(this.fromba2ArchivefrozenToolStripMenuItem_Click);
            // 
            // fromFolderToolStripMenuItem
            // 
            this.fromFolderToolStripMenuItem.Image = global::Fo76ini.Properties.Resources.add_folder_24;
            this.fromFolderToolStripMenuItem.Name = "fromFolderToolStripMenuItem";
            this.fromFolderToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.fromFolderToolStripMenuItem.Text = "From folder";
            this.fromFolderToolStripMenuItem.Click += new System.EventHandler(this.fromFolderToolStripMenuItem_Click);
            // 
            // toolStripMenuItemModsImport
            // 
            this.toolStripMenuItemModsImport.Name = "toolStripMenuItemModsImport";
            this.toolStripMenuItemModsImport.Size = new System.Drawing.Size(190, 22);
            this.toolStripMenuItemModsImport.Text = "Import installed mods";
            this.toolStripMenuItemModsImport.Click += new System.EventHandler(this.toolStripMenuItemModsImport_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(187, 6);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::Fo76ini.Properties.Resources.save_24;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveToolStripMenuItem.Text = "Save changes";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // deployToolStripMenuItem
            // 
            this.deployToolStripMenuItem.Name = "deployToolStripMenuItem";
            this.deployToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.deployToolStripMenuItem.Text = "Deploy mods";
            this.deployToolStripMenuItem.Click += new System.EventHandler(this.deployToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showConflictingFilesToolStripMenuItem,
            this.reloadUIToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.editToolStripMenuItem.Text = "View";
            // 
            // showConflictingFilesToolStripMenuItem
            // 
            this.showConflictingFilesToolStripMenuItem.Name = "showConflictingFilesToolStripMenuItem";
            this.showConflictingFilesToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.showConflictingFilesToolStripMenuItem.Text = "Show conflicting files";
            this.showConflictingFilesToolStripMenuItem.Click += new System.EventHandler(this.showConflictingFilesToolStripMenuItem_Click);
            // 
            // reloadUIToolStripMenuItem
            // 
            this.reloadUIToolStripMenuItem.Image = global::Fo76ini.Properties.Resources.available_updates;
            this.reloadUIToolStripMenuItem.Name = "reloadUIToolStripMenuItem";
            this.reloadUIToolStripMenuItem.Size = new System.Drawing.Size(187, 22);
            this.reloadUIToolStripMenuItem.Text = "Reload UI";
            this.reloadUIToolStripMenuItem.Click += new System.EventHandler(this.reloadUIToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archive2ToolStripMenuItem,
            this.nexusModsAPIToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // archive2ToolStripMenuItem
            // 
            this.archive2ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openArchive2ToolStripMenuItem,
            this.exploreba2ArchiveToolStripMenuItem,
            this.detectFormatAndCompressionToolStripMenuItem});
            this.archive2ToolStripMenuItem.Name = "archive2ToolStripMenuItem";
            this.archive2ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.archive2ToolStripMenuItem.Text = "Archive2";
            // 
            // openArchive2ToolStripMenuItem
            // 
            this.openArchive2ToolStripMenuItem.Name = "openArchive2ToolStripMenuItem";
            this.openArchive2ToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.openArchive2ToolStripMenuItem.Text = "Open Archive2";
            this.openArchive2ToolStripMenuItem.Click += new System.EventHandler(this.openArchive2ToolStripMenuItem_Click);
            // 
            // exploreba2ArchiveToolStripMenuItem
            // 
            this.exploreba2ArchiveToolStripMenuItem.Name = "exploreba2ArchiveToolStripMenuItem";
            this.exploreba2ArchiveToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.exploreba2ArchiveToolStripMenuItem.Text = "Explore *.ba2 archive";
            this.exploreba2ArchiveToolStripMenuItem.Click += new System.EventHandler(this.exploreba2ArchiveToolStripMenuItem_Click);
            // 
            // detectFormatAndCompressionToolStripMenuItem
            // 
            this.detectFormatAndCompressionToolStripMenuItem.Name = "detectFormatAndCompressionToolStripMenuItem";
            this.detectFormatAndCompressionToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.detectFormatAndCompressionToolStripMenuItem.Text = "Display info about *.ba2 archive";
            this.detectFormatAndCompressionToolStripMenuItem.Click += new System.EventHandler(this.detectFormatAndCompressionToolStripMenuItem_Click);
            // 
            // nexusModsAPIToolStripMenuItem
            // 
            this.nexusModsAPIToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateModInformationToolStripMenuItem,
            this.endorseModsToolStripMenuItem,
            this.checkForUpdatesToolStripMenuItem});
            this.nexusModsAPIToolStripMenuItem.Name = "nexusModsAPIToolStripMenuItem";
            this.nexusModsAPIToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.nexusModsAPIToolStripMenuItem.Text = "NexusMods API";
            // 
            // updateModInformationToolStripMenuItem
            // 
            this.updateModInformationToolStripMenuItem.Name = "updateModInformationToolStripMenuItem";
            this.updateModInformationToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.updateModInformationToolStripMenuItem.Text = "Update mod information";
            this.updateModInformationToolStripMenuItem.Click += new System.EventHandler(this.updateModInformationToolStripMenuItem_Click);
            // 
            // endorseModsToolStripMenuItem
            // 
            this.endorseModsToolStripMenuItem.Name = "endorseModsToolStripMenuItem";
            this.endorseModsToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.endorseModsToolStripMenuItem.Text = "Endorse mods";
            this.endorseModsToolStripMenuItem.Click += new System.EventHandler(this.endorseModsToolStripMenuItem_Click);
            // 
            // checkForUpdatesToolStripMenuItem
            // 
            this.checkForUpdatesToolStripMenuItem.Name = "checkForUpdatesToolStripMenuItem";
            this.checkForUpdatesToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.checkForUpdatesToolStripMenuItem.Text = "Check for updates";
            this.checkForUpdatesToolStripMenuItem.Click += new System.EventHandler(this.checkForUpdatesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showGuideToolStripMenuItem,
            this.logFilesToolStripMenuItem,
            this.showDevToolsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // showGuideToolStripMenuItem
            // 
            this.showGuideToolStripMenuItem.Image = global::Fo76ini.Properties.Resources.help_24;
            this.showGuideToolStripMenuItem.Name = "showGuideToolStripMenuItem";
            this.showGuideToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.showGuideToolStripMenuItem.Text = "Show guide";
            this.showGuideToolStripMenuItem.Click += new System.EventHandler(this.showGuideToolStripMenuItem_Click);
            // 
            // logFilesToolStripMenuItem
            // 
            this.logFilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showModmanagerlogtxtToolStripMenuItem,
            this.showArchive2logtxtToolStripMenuItem});
            this.logFilesToolStripMenuItem.Name = "logFilesToolStripMenuItem";
            this.logFilesToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.logFilesToolStripMenuItem.Text = "Log files";
            // 
            // showModmanagerlogtxtToolStripMenuItem
            // 
            this.showModmanagerlogtxtToolStripMenuItem.Name = "showModmanagerlogtxtToolStripMenuItem";
            this.showModmanagerlogtxtToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.showModmanagerlogtxtToolStripMenuItem.Text = "Show modmanager.log.txt";
            this.showModmanagerlogtxtToolStripMenuItem.Click += new System.EventHandler(this.showModmanagerlogtxtToolStripMenuItem_Click);
            // 
            // showArchive2logtxtToolStripMenuItem
            // 
            this.showArchive2logtxtToolStripMenuItem.Name = "showArchive2logtxtToolStripMenuItem";
            this.showArchive2logtxtToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.showArchive2logtxtToolStripMenuItem.Text = "Show archive2.log.txt";
            this.showArchive2logtxtToolStripMenuItem.Click += new System.EventHandler(this.showArchive2logtxtToolStripMenuItem_Click);
            // 
            // showDevToolsToolStripMenuItem
            // 
            this.showDevToolsToolStripMenuItem.Image = global::Fo76ini.Properties.Resources.bug_3_16;
            this.showDevToolsToolStripMenuItem.Name = "showDevToolsToolStripMenuItem";
            this.showDevToolsToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.showDevToolsToolStripMenuItem.Text = "Show development tools";
            this.showDevToolsToolStripMenuItem.Click += new System.EventHandler(this.showDevToolsToolStripMenuItem_Click);
            // 
            // openFileDialogMod
            // 
            this.openFileDialogMod.Filter = "All Archives|*.zip;*.rar;*.7z;*.tar;*.ba2";
            this.openFileDialogMod.Title = "Add *.ba2 or any other archive.";
            // 
            // openFileDialogBA2
            // 
            this.openFileDialogBA2.DefaultExt = "ba2";
            this.openFileDialogBA2.Filter = "Archive2|*.ba2";
            this.openFileDialogBA2.Title = "Add *.ba2 archive.";
            // 
            // timerCheckForNXM
            // 
            this.timerCheckForNXM.Interval = 1000;
            this.timerCheckForNXM.Tick += new System.EventHandler(this.timerCheckForNXM_Tick);
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
            // panel
            // 
            this.panel.Controls.Add(this.browserModManager);
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Location = new System.Drawing.Point(0, 24);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(784, 577);
            this.panel.TabIndex = 50;
            // 
            // browserModManager
            // 
            this.browserModManager.ActivateBrowserOnCreation = false;
            this.browserModManager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browserModManager.Location = new System.Drawing.Point(0, 0);
            this.browserModManager.Name = "browserModManager";
            this.browserModManager.Size = new System.Drawing.Size(784, 577);
            this.browserModManager.TabIndex = 0;
            // 
            // FormMods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 601);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(800, 640);
            this.Name = "FormMods";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mod Manager";
            this.Load += new System.EventHandler(this.FormMods_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addModarchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemModsImport;
        private System.Windows.Forms.ToolStripMenuItem deployToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showGuideToolStripMenuItem;
        public Controls.CustomToolTip toolTip;
        private System.Windows.Forms.OpenFileDialog openFileDialogMod;
        private System.Windows.Forms.ToolStripMenuItem showConflictingFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadUIToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialogBA2;
        private System.Windows.Forms.ToolStripMenuItem fromba2ArchivefrozenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archive2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openArchive2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exploreba2ArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showModmanagerlogtxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showArchive2logtxtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nexusModsAPIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateModInformationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem endorseModsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkForUpdatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem emptyModToolStripMenuItem;
        private System.Windows.Forms.Timer timerCheckForNXM;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem detectFormatAndCompressionToolStripMenuItem;
        private System.Windows.Forms.Panel panel;
        private CefSharp.WinForms.ChromiumWebBrowser browserModManager;
        private System.Windows.Forms.ToolStripMenuItem showDevToolsToolStripMenuItem;
    }
}