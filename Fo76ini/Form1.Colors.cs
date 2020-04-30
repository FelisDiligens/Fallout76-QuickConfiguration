using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini
{
    partial class Form1
    {
        bool colorQuickboyIsDefault = true; // Depending on this value, the Quickboy values will be set or unset.
        bool colorPAPipboyIsDefault = true;

        /// <summary>
        /// This will set all values for the "Color" tab.
        /// </summary>
        private void ColorIni2Ui()
        {
            // Pip-Boy Color
            this.colorPreviewPipboy.BackColor = this.PipboyColor;

            // Quick-Boy Color
            this.colorPreviewQuickboy.BackColor = this.QuickboyColor;
            this.colorQuickboyIsDefault = !IniFiles.Instance.Exists("Pipboy", "fQuickBoyEffectColorR");

            // Power Armor Pip-Boy Color
            this.colorPreviewPAPipboy.BackColor = this.PowerArmorPipboyColor;
            this.colorPAPipboyIsDefault = !IniFiles.Instance.Exists("Pipboy", "fPAEffectColorR");
        }

        /// <summary>
        /// This will write all changes made in the "Color" tab to the INI.
        /// </summary>
        private void ColorUi2Ini()
        {
            // Pip-Boy Color
            this.PipboyColor = this.colorPreviewPipboy.BackColor;

            // Quick-Boy Color
            if (!this.colorQuickboyIsDefault)
            {
                this.QuickboyColor = this.colorPreviewQuickboy.BackColor;
            }
            else
            {
                IniFiles.Instance.Remove(IniFile.F76Custom, "Pipboy", "fQuickBoyEffectColorR");
                IniFiles.Instance.Remove(IniFile.F76Custom, "Pipboy", "fQuickBoyEffectColorG");
                IniFiles.Instance.Remove(IniFile.F76Custom, "Pipboy", "fQuickBoyEffectColorB");
            }

            // Power Armor Pip-Boy Color
            if (!this.colorPAPipboyIsDefault)
            {
                this.PowerArmorPipboyColor = this.colorPreviewPAPipboy.BackColor;
            }
            else
            {
                IniFiles.Instance.Remove(IniFile.F76Custom, "Pipboy", "fPAEffectColorR");
                IniFiles.Instance.Remove(IniFile.F76Custom, "Pipboy", "fPAEffectColorG");
                IniFiles.Instance.Remove(IniFile.F76Custom, "Pipboy", "fPAEffectColorB");
            }
        }



        /*
         *  Getter & Setter
         */

        public Color PipboyColor
        {
            get
            {
                float r = IniFiles.Instance.GetFloat("Pipboy", "fPipboyEffectColorR", 1.0f);
                float g = IniFiles.Instance.GetFloat("Pipboy", "fPipboyEffectColorG", 1.0f);
                float b = IniFiles.Instance.GetFloat("Pipboy", "fPipboyEffectColorB", 0.5f);
                return Color.FromArgb(
                    Convert.ToInt32(r * 255),
                    Convert.ToInt32(g * 255),
                    Convert.ToInt32(b * 255)
                );
            }
            set
            {
                float r = Convert.ToSingle(value.R) / 255f;
                float g = Convert.ToSingle(value.G) / 255f;
                float b = Convert.ToSingle(value.B) / 255f;
                IniFiles.Instance.Set(IniFile.F76Prefs, "Pipboy", "fPipboyEffectColorR", r);
                IniFiles.Instance.Set(IniFile.F76Prefs, "Pipboy", "fPipboyEffectColorG", g);
                IniFiles.Instance.Set(IniFile.F76Prefs, "Pipboy", "fPipboyEffectColorB", b);
            }
        }


        public Color QuickboyColor
        {
            get
            {
                float r = IniFiles.Instance.GetFloat("Pipboy", "fQuickBoyEffectColorR", 1.0f);
                float g = IniFiles.Instance.GetFloat("Pipboy", "fQuickBoyEffectColorG", 0.78f);
                float b = IniFiles.Instance.GetFloat("Pipboy", "fQuickBoyEffectColorB", 0.0f);
                return Color.FromArgb(
                    Convert.ToInt32(r * 255),
                    Convert.ToInt32(g * 255),
                    Convert.ToInt32(b * 255)
                );
            }
            set
            {
                float r = Convert.ToSingle(value.R) / 255f;
                float g = Convert.ToSingle(value.G) / 255f;
                float b = Convert.ToSingle(value.B) / 255f;
                IniFiles.Instance.Set(IniFile.F76Custom, "Pipboy", "fQuickBoyEffectColorR", r);
                IniFiles.Instance.Set(IniFile.F76Custom, "Pipboy", "fQuickBoyEffectColorG", g);
                IniFiles.Instance.Set(IniFile.F76Custom, "Pipboy", "fQuickBoyEffectColorB", b);
            }
        }


        public Color PowerArmorPipboyColor
        {
            get
            {
                float r = IniFiles.Instance.GetFloat("Pipboy", "fPAEffectColorR", 1.0f);
                float g = IniFiles.Instance.GetFloat("Pipboy", "fPAEffectColorG", 0.78f);
                float b = IniFiles.Instance.GetFloat("Pipboy", "fPAEffectColorB", 0.0f);
                return Color.FromArgb(
                    Convert.ToInt32(r * 255),
                    Convert.ToInt32(g * 255),
                    Convert.ToInt32(b * 255)
                );
            }
            set
            {
                float r = Convert.ToSingle(value.R) / 255f;
                float g = Convert.ToSingle(value.G) / 255f;
                float b = Convert.ToSingle(value.B) / 255f;
                IniFiles.Instance.Set(IniFile.F76Custom, "Pipboy", "fPAEffectColorR", r);
                IniFiles.Instance.Set(IniFile.F76Custom, "Pipboy", "fPAEffectColorG", g);
                IniFiles.Instance.Set(IniFile.F76Custom, "Pipboy", "fPAEffectColorB", b);
            }
        }




        /*
         *  Event handler
         */

        private void buttonColorPickPipboy_Click(object sender, EventArgs e)
        {
            // Pip-Boy Color
            if (this.colorDialog.ShowDialog() == DialogResult.OK)
                this.colorPreviewPipboy.BackColor = this.colorDialog.Color;
        }

        private void buttonColorResetPipboy_Click(object sender, EventArgs e)
        {
            // Pip-Boy Color
            this.colorPreviewPipboy.BackColor = Color.FromArgb(26, 255, 128);
        }

        private void buttonColorPickQuickboy_Click(object sender, EventArgs e)
        {
            // Quick-Boy Color
            if (this.colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.colorPreviewQuickboy.BackColor = this.colorDialog.Color;
                this.colorQuickboyIsDefault = false;
            }
        }

        private void buttonColorResetQuickboy_Click(object sender, EventArgs e)
        {
            // Quick-Boy Color
            this.colorPreviewQuickboy.BackColor = Color.FromArgb(255, 200, 0); // These are guessed
            this.colorQuickboyIsDefault = true;
        }

        private void buttonColorPickPAPipboy_Click(object sender, EventArgs e)
        {
            // Power armor color
            if (this.colorDialog.ShowDialog() == DialogResult.OK)
            {
                this.colorPreviewPAPipboy.BackColor = this.colorDialog.Color;
                this.colorPAPipboyIsDefault = false;
            }
        }

        private void buttonColorResetPAPipboy_Click(object sender, EventArgs e)
        {
            // Power armor color
            this.colorPreviewPAPipboy.BackColor = Color.FromArgb(255, 200, 0); // These are guessed
            this.colorPAPipboyIsDefault = true;
        }
    }
}
