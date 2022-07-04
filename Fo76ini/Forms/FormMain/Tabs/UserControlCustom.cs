using Fo76ini.Profiles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Forms.FormMain.Tabs
{
    public partial class UserControlCustom : UserControl
    {
        private GameInstance game;

        public UserControlCustom()
        {
            InitializeComponent();

            ProfileManager.ProfileChanged += OnProfileChanged;
        }

        private void OnProfileChanged(object sender, ProfileEventArgs e)
        {
            this.game = e.ActiveGameInstance;
            LoadCustomTab();
        }

        private void LoadCustomTab()
        {
            this.comboBoxCustomFile.Items.Clear();
            this.comboBoxCustomFile.Items.AddRange(new string[] {
                $"{game.IniPrefix}.ini",
                $"{game.IniPrefix}Prefs.ini",
                $"{game.IniPrefix}Custom.ini"
            });
            this.comboBoxCustomFile.SelectedIndex = 0;
        }

        private string customAddFilePath = null;

        private void comboBoxCustomFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fileName;
            switch (this.comboBoxCustomFile.SelectedIndex)
            {
                case 0:
                    fileName = $"{game.IniPrefix}.add.ini";
                    break;
                case 1:
                    fileName = $"{game.IniPrefix}Prefs.add.ini";
                    break;
                case 2:
                    fileName = $"{game.IniPrefix}Custom.add.ini";
                    break;
                default:
                    return;
            }
            this.customAddFilePath = Path.Combine(IniFiles.ParentPath, fileName);

            if (File.Exists(this.customAddFilePath))
                this.textBoxCustom.Text = File.ReadAllText(this.customAddFilePath);
            else
                this.textBoxCustom.Text = "";

            this.buttonCustomSave.Text = this.buttonCustomSave.Text.TrimEnd('*');
        }

        private void textBoxCustom_TextChanged(object sender, EventArgs e)
        {
            if (!this.buttonCustomSave.Text.EndsWith("*"))
                this.buttonCustomSave.Text += "*";
        }

        private void buttonCustomSave_Click(object sender, EventArgs e)
        {
            if (this.textBoxCustom.Text == "")
            {
                if (File.Exists(this.customAddFilePath))
                    File.Delete(this.customAddFilePath);
            }
            else
            {
                File.WriteAllText(this.customAddFilePath, this.textBoxCustom.Text);
            }

            if (this.buttonCustomSave.Text.EndsWith("*"))
                this.buttonCustomSave.Text = this.buttonCustomSave.Text.TrimEnd('*');
        }
    }
}
