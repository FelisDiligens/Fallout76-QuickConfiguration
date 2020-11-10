using Fo76ini.Tweaks;
using Fo76ini.Tweaks.Colors;

namespace Fo76ini
{
    partial class Form1
    {
        public void LinkControlsToTweaks()
        {
            // Pipboy color
            LinkedTweaks.LinkColor(
                buttonColorPickPipboy,
                buttonColorResetPipboy,
                colorDialog,
                colorPreviewPipboy,
                new PipboyColorTweak());

            // Quickboy color
            LinkedTweaks.LinkColor(
                buttonColorPickQuickboy,
                buttonColorResetQuickboy,
                colorDialog,
                colorPreviewQuickboy,
                new QuickboyColorTweak());

            // Power Armore Pipboy color
            LinkedTweaks.LinkColor(
                buttonColorPickPAPipboy,
                buttonColorResetPAPipboy,
                colorDialog,
                colorPreviewPAPipboy,
                new PowerArmorPipboyColorTweak());
        }
    }
}
