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
        #region Pipboy

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
                colorPreviewPipboy,     // The little, colored square that is left to the label.
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
            this.pipboyPreview.PreviewColor = this.colorPreviewPipboy.BackColor;
        }

        private void colorPreviewQuickboy_BackColorChanged(object sender, EventArgs e)
        {
            this.quickboyPreview.PreviewColor = this.colorPreviewQuickboy.BackColor;
        }

        private void colorPreviewPAPipboy_BackColorChanged(object sender, EventArgs e)
        {
            this.pipboyPAPreview.PreviewColor = this.colorPreviewPAPipboy.BackColor;
        }

        private void buttonPipboyTargetReset_Click(object sender, EventArgs e)
        {
        }

        private void buttonPipboyTargetSetRecommended_Click(object sender, EventArgs e)
        {
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


        #endregion
    }
}
