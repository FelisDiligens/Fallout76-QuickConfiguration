
namespace Fo76ini.Forms.FormWelcome
{
    partial class FormWelcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWelcome));
            this.label1 = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBoxGameLocation = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonAutoDetect = new System.Windows.Forms.Button();
            this.textBoxGamePath = new System.Windows.Forms.TextBox();
            this.buttonPickGamePath = new System.Windows.Forms.Button();
            this.groupBoxGameEdition = new System.Windows.Forms.GroupBox();
            this.pictureBoxSteamPTS = new System.Windows.Forms.PictureBox();
            this.radioButtonEditionSteamPTS = new System.Windows.Forms.RadioButton();
            this.radioButtonEditionUnknown = new System.Windows.Forms.RadioButton();
            this.pictureBoxUnknown = new System.Windows.Forms.PictureBox();
            this.pictureBoxMSStore = new System.Windows.Forms.PictureBox();
            this.pictureBoxSteam = new System.Windows.Forms.PictureBox();
            this.radioButtonEditionMSStore = new System.Windows.Forms.RadioButton();
            this.radioButtonEditionSteam = new System.Windows.Forms.RadioButton();
            this.buttonOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBoxGameLocation.SuspendLayout();
            this.groupBoxGameEdition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSteamPTS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUnknown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMSStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSteam)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(14, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Hi, it seems like you started the tool for the first time!\r\n";
            // 
            // labelTitle
            // 
            this.labelTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(422, 34);
            this.labelTitle.TabIndex = 7;
            this.labelTitle.Text = "Welcome!";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBoxGameLocation);
            this.panel1.Controls.Add(this.groupBoxGameEdition);
            this.panel1.Location = new System.Drawing.Point(12, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(422, 397);
            this.panel1.TabIndex = 40;
            // 
            // groupBoxGameLocation
            // 
            this.groupBoxGameLocation.Controls.Add(this.label3);
            this.groupBoxGameLocation.Controls.Add(this.label2);
            this.groupBoxGameLocation.Controls.Add(this.buttonAutoDetect);
            this.groupBoxGameLocation.Controls.Add(this.textBoxGamePath);
            this.groupBoxGameLocation.Controls.Add(this.buttonPickGamePath);
            this.groupBoxGameLocation.Location = new System.Drawing.Point(11, 160);
            this.groupBoxGameLocation.Name = "groupBoxGameLocation";
            this.groupBoxGameLocation.Size = new System.Drawing.Size(400, 227);
            this.groupBoxGameLocation.TabIndex = 41;
            this.groupBoxGameLocation.TabStop = false;
            this.groupBoxGameLocation.Text = "Game location";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(386, 34);
            this.label3.TabIndex = 34;
            this.label3.Text = "You can skip the game location, if you don\'t want to install mods.";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(8, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(386, 106);
            this.label2.TabIndex = 33;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // buttonAutoDetect
            // 
            this.buttonAutoDetect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAutoDetect.Location = new System.Drawing.Point(6, 48);
            this.buttonAutoDetect.Name = "buttonAutoDetect";
            this.buttonAutoDetect.Size = new System.Drawing.Size(388, 23);
            this.buttonAutoDetect.TabIndex = 32;
            this.buttonAutoDetect.Text = "Attempt auto-detect";
            this.buttonAutoDetect.UseVisualStyleBackColor = true;
            this.buttonAutoDetect.Click += new System.EventHandler(this.buttonAutoDetect_Click);
            // 
            // textBoxGamePath
            // 
            this.textBoxGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxGamePath.Location = new System.Drawing.Point(6, 21);
            this.textBoxGamePath.Name = "textBoxGamePath";
            this.textBoxGamePath.Size = new System.Drawing.Size(354, 20);
            this.textBoxGamePath.TabIndex = 30;
            this.textBoxGamePath.TextChanged += new System.EventHandler(this.textBoxGamePath_TextChanged);
            // 
            // buttonPickGamePath
            // 
            this.buttonPickGamePath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPickGamePath.Location = new System.Drawing.Point(366, 19);
            this.buttonPickGamePath.Name = "buttonPickGamePath";
            this.buttonPickGamePath.Size = new System.Drawing.Size(28, 23);
            this.buttonPickGamePath.TabIndex = 31;
            this.buttonPickGamePath.Text = "...";
            this.buttonPickGamePath.UseVisualStyleBackColor = true;
            this.buttonPickGamePath.Click += new System.EventHandler(this.buttonPickGamePath_Click);
            // 
            // groupBoxGameEdition
            // 
            this.groupBoxGameEdition.Controls.Add(this.pictureBoxSteamPTS);
            this.groupBoxGameEdition.Controls.Add(this.radioButtonEditionSteamPTS);
            this.groupBoxGameEdition.Controls.Add(this.radioButtonEditionUnknown);
            this.groupBoxGameEdition.Controls.Add(this.pictureBoxUnknown);
            this.groupBoxGameEdition.Controls.Add(this.pictureBoxMSStore);
            this.groupBoxGameEdition.Controls.Add(this.pictureBoxSteam);
            this.groupBoxGameEdition.Controls.Add(this.radioButtonEditionMSStore);
            this.groupBoxGameEdition.Controls.Add(this.radioButtonEditionSteam);
            this.groupBoxGameEdition.Location = new System.Drawing.Point(11, 9);
            this.groupBoxGameEdition.Name = "groupBoxGameEdition";
            this.groupBoxGameEdition.Size = new System.Drawing.Size(400, 145);
            this.groupBoxGameEdition.TabIndex = 40;
            this.groupBoxGameEdition.TabStop = false;
            this.groupBoxGameEdition.Text = "Game edition";
            // 
            // pictureBoxSteamPTS
            // 
            this.pictureBoxSteamPTS.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSteamPTS.Image = global::Fo76ini.Properties.Resources.steam_24px;
            this.pictureBoxSteamPTS.Location = new System.Drawing.Point(11, 49);
            this.pictureBoxSteamPTS.Name = "pictureBoxSteamPTS";
            this.pictureBoxSteamPTS.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxSteamPTS.TabIndex = 33;
            this.pictureBoxSteamPTS.TabStop = false;
            // 
            // radioButtonEditionSteamPTS
            // 
            this.radioButtonEditionSteamPTS.AutoSize = true;
            this.radioButtonEditionSteamPTS.Location = new System.Drawing.Point(43, 52);
            this.radioButtonEditionSteamPTS.Name = "radioButtonEditionSteamPTS";
            this.radioButtonEditionSteamPTS.Size = new System.Drawing.Size(85, 17);
            this.radioButtonEditionSteamPTS.TabIndex = 32;
            this.radioButtonEditionSteamPTS.Text = "Steam (PTS)";
            this.radioButtonEditionSteamPTS.UseVisualStyleBackColor = true;
            this.radioButtonEditionSteamPTS.CheckedChanged += new System.EventHandler(this.radioButtonEditionSteamPTS_CheckedChanged);
            // 
            // radioButtonEditionUnknown
            // 
            this.radioButtonEditionUnknown.AutoSize = true;
            this.radioButtonEditionUnknown.Location = new System.Drawing.Point(43, 112);
            this.radioButtonEditionUnknown.Name = "radioButtonEditionUnknown";
            this.radioButtonEditionUnknown.Size = new System.Drawing.Size(51, 17);
            this.radioButtonEditionUnknown.TabIndex = 31;
            this.radioButtonEditionUnknown.Text = "Other";
            this.radioButtonEditionUnknown.UseVisualStyleBackColor = true;
            this.radioButtonEditionUnknown.CheckedChanged += new System.EventHandler(this.radioButtonEditionUnknown_CheckedChanged);
            // 
            // pictureBoxUnknown
            // 
            this.pictureBoxUnknown.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxUnknown.Image = global::Fo76ini.Properties.Resources.help_24;
            this.pictureBoxUnknown.Location = new System.Drawing.Point(11, 109);
            this.pictureBoxUnknown.Name = "pictureBoxUnknown";
            this.pictureBoxUnknown.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxUnknown.TabIndex = 30;
            this.pictureBoxUnknown.TabStop = false;
            // 
            // pictureBoxMSStore
            // 
            this.pictureBoxMSStore.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMSStore.Image = global::Fo76ini.Properties.Resources.xbox_24;
            this.pictureBoxMSStore.Location = new System.Drawing.Point(11, 79);
            this.pictureBoxMSStore.Name = "pictureBoxMSStore";
            this.pictureBoxMSStore.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxMSStore.TabIndex = 29;
            this.pictureBoxMSStore.TabStop = false;
            // 
            // pictureBoxSteam
            // 
            this.pictureBoxSteam.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSteam.Image = global::Fo76ini.Properties.Resources.steam_24px;
            this.pictureBoxSteam.Location = new System.Drawing.Point(11, 19);
            this.pictureBoxSteam.Name = "pictureBoxSteam";
            this.pictureBoxSteam.Size = new System.Drawing.Size(24, 24);
            this.pictureBoxSteam.TabIndex = 28;
            this.pictureBoxSteam.TabStop = false;
            // 
            // radioButtonEditionMSStore
            // 
            this.radioButtonEditionMSStore.AutoSize = true;
            this.radioButtonEditionMSStore.Location = new System.Drawing.Point(43, 82);
            this.radioButtonEditionMSStore.Name = "radioButtonEditionMSStore";
            this.radioButtonEditionMSStore.Size = new System.Drawing.Size(194, 17);
            this.radioButtonEditionMSStore.TabIndex = 3;
            this.radioButtonEditionMSStore.Text = "Xbox (Game Pass) / Microsoft Store";
            this.radioButtonEditionMSStore.UseVisualStyleBackColor = true;
            this.radioButtonEditionMSStore.CheckedChanged += new System.EventHandler(this.radioButtonEditionMSStore_CheckedChanged);
            // 
            // radioButtonEditionSteam
            // 
            this.radioButtonEditionSteam.AutoSize = true;
            this.radioButtonEditionSteam.Location = new System.Drawing.Point(43, 22);
            this.radioButtonEditionSteam.Name = "radioButtonEditionSteam";
            this.radioButtonEditionSteam.Size = new System.Drawing.Size(55, 17);
            this.radioButtonEditionSteam.TabIndex = 1;
            this.radioButtonEditionSteam.Text = "Steam";
            this.radioButtonEditionSteam.UseVisualStyleBackColor = true;
            this.radioButtonEditionSteam.CheckedChanged += new System.EventHandler(this.radioButtonEditionSteam_CheckedChanged);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(300, 517);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(134, 27);
            this.buttonOK.TabIndex = 41;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(112)))), ((int)(((byte)(112)))));
            this.label4.Location = new System.Drawing.Point(12, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(422, 46);
            this.label4.TabIndex = 42;
            this.label4.Text = "» Now, I know you\'re a busy fellow, so I won\'t take up much of your time.\r\n   I j" +
    "ust need to verify some information, that\'s all! «\r\n       – Vault-Tec rep, Oct." +
    " 2077";
            // 
            // FormWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 550);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormWelcome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Welcome";
            this.panel1.ResumeLayout(false);
            this.groupBoxGameLocation.ResumeLayout(false);
            this.groupBoxGameLocation.PerformLayout();
            this.groupBoxGameEdition.ResumeLayout(false);
            this.groupBoxGameEdition.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSteamPTS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUnknown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMSStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSteam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBoxGameLocation;
        private System.Windows.Forms.Button buttonAutoDetect;
        private System.Windows.Forms.TextBox textBoxGamePath;
        private System.Windows.Forms.Button buttonPickGamePath;
        private System.Windows.Forms.GroupBox groupBoxGameEdition;
        private System.Windows.Forms.RadioButton radioButtonEditionUnknown;
        private System.Windows.Forms.PictureBox pictureBoxUnknown;
        private System.Windows.Forms.PictureBox pictureBoxMSStore;
        private System.Windows.Forms.PictureBox pictureBoxSteam;
        private System.Windows.Forms.RadioButton radioButtonEditionMSStore;
        private System.Windows.Forms.RadioButton radioButtonEditionSteam;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBoxSteamPTS;
        private System.Windows.Forms.RadioButton radioButtonEditionSteamPTS;
    }
}