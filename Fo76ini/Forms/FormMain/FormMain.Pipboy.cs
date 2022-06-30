using Fo76ini.Properties;
using Fo76ini.Tweaks;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini
{
    partial class FormMain
    {
        /*
         * Color presets
         */

        private void buttonPresetFo3Green_Click(object sender, EventArgs e)
        {
            Pipboy_SetColorOfActivePreview(Color.FromArgb(26, 255, 128));
        }

        private void buttonPresetFoNVAmber_Click(object sender, EventArgs e)
        {
            Pipboy_SetColorOfActivePreview(Color.FromArgb(255, 182, 66));
        }

        private void buttonPresetFo3Blue_Click(object sender, EventArgs e)
        {
            Pipboy_SetColorOfActivePreview(Color.FromArgb(46, 207, 255));
        }

        private void buttonPresetFo3White_Click(object sender, EventArgs e)
        {
            Pipboy_SetColorOfActivePreview(Color.FromArgb(192, 255, 255));
        }

        private void buttonPresetFo4Green_Click(object sender, EventArgs e)
        {
            Pipboy_SetColorOfActivePreview(Color.FromArgb(18, 255, 21));
        }

        private void buttonPresetFo76Green_Click(object sender, EventArgs e)
        {
            Pipboy_SetColorOfActivePreview(Color.FromArgb(26, 255, 128));
        }

        private void Pipboy_SetColorOfActivePreview(Color color)
        {
            // Pip-Boy
            if (this.tabControlPipboy.SelectedTab == this.tabPagePipboyColor)
            {
                this.colorPreviewPipboy.BackColor = color;
            }
            // Quick-Boy
            else if (this.tabControlPipboy.SelectedTab == this.tabPageQuickboyColor)
            {
                this.colorPreviewQuickboy.BackColor = color;
            }
            // Quick-Boy
            else if (this.tabControlPipboy.SelectedTab == this.tabPagePowerArmorColor)
            {
                this.colorPreviewPAPipboy.BackColor = color;
            }
        }


        /*
         * Init Pipboy tab
         */

        private void InitPipboy()
        {
            this.colorPreviewPipboy.BackColorChanged += colorPreviewPipboy_BackColorChanged;
            this.colorPreviewQuickboy.BackColorChanged += colorPreviewQuickboy_BackColorChanged;
            this.colorPreviewPAPipboy.BackColorChanged += colorPreviewPAPipboy_BackColorChanged;
        }

        private void LinkPipboyControls()
        {
            /*
             * Tweaks
             */

            // Pipboy color
            LinkedTweaks.LinkColor(
                buttonColorPickPipboy,  // "Pick color" button
                buttonColorResetPipboy, // "Reset" button
                colorDialog,            // The color picking dialog that should open when clicking on "Pick color"
                colorPreviewPipboy,     // The colored square that is left to the label.
                pipboyColorTweak);

            // Quickboy color
            LinkedTweaks.LinkColor(
                buttonColorPickQuickboy,
                buttonColorResetQuickboy,
                colorDialog,
                colorPreviewQuickboy,
                quickboyColorTweak);

            // Power Armor Pipboy color
            LinkedTweaks.LinkColor(
                buttonColorPickPAPipboy,
                buttonColorResetPAPipboy,
                colorDialog,
                colorPreviewPAPipboy,
                powerArmorPipboyColorTweak);

            // Radiobuttons, Quickboy or Pipboy mode
            LinkedTweaks.LinkTweak(this.radioButtonQuickboy, this.radioButtonPipboy, quickboyModeEnabledTweak);

            // Pipboy resolution
            LinkedTweaks.LinkSize(numPipboyTargetWidth, numPipboyTargetHeight, pipboyTargetResolutionTweak);


            /*
             * Infos
             */

            // Pipboy tab
            LinkedTweaks.LinkInfo(buttonColorPickPipboy, toolTip, pipboyColorTweak);
            LinkedTweaks.LinkInfo(buttonColorPickQuickboy, toolTip, quickboyColorTweak);
            LinkedTweaks.LinkInfo(buttonColorPickPAPipboy, toolTip, powerArmorPipboyColorTweak);
            LinkedTweaks.LinkInfo(labelPipboyColor, toolTip, pipboyColorTweak);
            LinkedTweaks.LinkInfo(labelQuickboyColor, toolTip, quickboyColorTweak);
            LinkedTweaks.LinkInfo(labelPowerArmorColor, toolTip, powerArmorPipboyColorTweak);
            LinkedTweaks.LinkInfo(numPipboyTargetHeight, toolTip, pipboyTargetResolutionTweak);
            LinkedTweaks.LinkInfo(numPipboyTargetWidth, toolTip, pipboyTargetResolutionTweak);
            LinkedTweaks.LinkInfo(radioButtonQuickboy, toolTip, quickboyModeEnabledTweak);
            LinkedTweaks.LinkInfo(radioButtonPipboy, toolTip, quickboyModeEnabledTweak);
        }


        /*
         * Event handler
         */

        private void colorPreviewPipboy_BackColorChanged(object sender, EventArgs e)
        {
            Color color = this.colorPreviewPipboy.BackColor;
            this.pipboyPreview.PreviewColor = color;
            this.textBoxPipboyHEX.Text = GetHEXFromColor(color);
        }

        private void colorPreviewQuickboy_BackColorChanged(object sender, EventArgs e)
        {
            Color color = this.colorPreviewQuickboy.BackColor;
            this.quickboyPreview.PreviewColor = color;
            this.textBoxQuickboyHEX.Text = GetHEXFromColor(color);
        }

        private void colorPreviewPAPipboy_BackColorChanged(object sender, EventArgs e)
        {
            Color color = this.colorPreviewPAPipboy.BackColor;
            this.pipboyPAPreview.PreviewColor = color;
            this.textBoxPAColorHEX.Text = GetHEXFromColor(color);
        }


        private void textBoxPipboyHEX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Color color = GetColorFromHEX(this.textBoxPipboyHEX.Text);
                this.textBoxPipboyHEX.ForeColor = Color.Black;
                Pipboy_SetColorOfActivePreview(color);
            }
            catch
            {
                this.textBoxPipboyHEX.ForeColor = Color.Red;
            }
        }

        private void textBoxQuickboyHEX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Color color = GetColorFromHEX(this.textBoxQuickboyHEX.Text);
                this.textBoxQuickboyHEX.ForeColor = Color.Black;
                Pipboy_SetColorOfActivePreview(color);
            }
            catch
            {
                this.textBoxQuickboyHEX.ForeColor = Color.Red;
            }
        }

        private void textBoxPAColorHEX_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Color color = GetColorFromHEX(this.textBoxPAColorHEX.Text);
                this.textBoxPAColorHEX.ForeColor = Color.Black;
                Pipboy_SetColorOfActivePreview(color);
            }
            catch
            {
                this.textBoxPAColorHEX.ForeColor = Color.Red;
            }
        }

        private void linkLabelPipboyTargetSetRecommended_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.numPipboyTargetWidth.Value = 1752;
            this.numPipboyTargetHeight.Value = 1400;
        }

        private void linkLabelPipboyTargetReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.numPipboyTargetWidth.Value = 876;
            this.numPipboyTargetHeight.Value = 700;
        }

        private Color GetColorFromHEX(string hex)
        {
            hex = hex.Replace("#", string.Empty);
            int r = Convert.ToInt32(hex.Substring(0, 2), 16);
            int g = Convert.ToInt32(hex.Substring(2, 2), 16);
            int b = Convert.ToInt32(hex.Substring(4, 2), 16);
            return Color.FromArgb(r, g, b);
        }

        private string GetHEXFromColor(Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }
    }
}
