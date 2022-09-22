using Fo76ini.Interface;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Controls
{
    // https://stackoverflow.com/questions/28908182/change-colors-used-for-rendering-a-menustrip
    // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.professionalcolortable?view=windowsdesktop-6.0
    public class CustomToolStripColorTable : ProfessionalColorTable
    {
        public override Color ToolStripBorder => Theming.GetColor("ProfessionalColorTable.ToolStripBorder", Color.FromArgb(128, 128, 128));
        public override Color ToolStripGradientBegin => Theming.GetColor("ProfessionalColorTable.ToolStrip", Color.White);
        public override Color ToolStripGradientEnd => Theming.GetColor("ProfessionalColorTable.ToolStrip", Color.White);
        public override Color ToolStripGradientMiddle => Theming.GetColor("ProfessionalColorTable.ToolStrip", Color.White);

        /* Menu strip (top) */
        public override Color MenuBorder => Theming.GetColor("ProfessionalColorTable.MenuBorder", Color.FromArgb(128, 128, 128));
        public override Color MenuStripGradientBegin => Theming.GetColor("ProfessionalColorTable.MenuStrip", Color.FromArgb(243, 243, 243));
        public override Color MenuStripGradientEnd => Theming.GetColor("ProfessionalColorTable.MenuStrip", Color.FromArgb(243, 243, 243));

        /* Status strip (bottom) */
        public override Color StatusStripGradientBegin => Theming.GetColor("ProfessionalColorTable.StatusStrip", Color.FromArgb(240, 240, 240));
        public override Color StatusStripGradientEnd => Theming.GetColor("ProfessionalColorTable.StatusStrip", Color.FromArgb(240, 240, 240));

        /* Top-level menu strip items - hover */
        public override Color MenuItemSelectedGradientBegin => Theming.GetColor("ProfessionalColorTable.MenuTopItemSelected", Color.FromArgb(181, 215, 243));
        public override Color MenuItemSelectedGradientEnd => Theming.GetColor("ProfessionalColorTable.MenuTopItemSelected", Color.FromArgb(181, 215, 243));

        /* Top-level menu strip items - press */
        public override Color MenuItemPressedGradientBegin => Theming.GetColor("ProfessionalColorTable.MenuTopItemPressed", Color.FromArgb(250, 250, 250));
        public override Color MenuItemPressedGradientEnd => Theming.GetColor("ProfessionalColorTable.MenuTopItemPressed", Color.FromArgb(250, 250, 250));
        public override Color MenuItemPressedGradientMiddle => Theming.GetColor("ProfessionalColorTable.MenuTopItemPressed", Color.FromArgb(250, 250, 250));

        /* Drop-down items */
        public override Color MenuItemBorder => Theming.GetColor("ProfessionalColorTable.MenuItemBorder", Color.FromArgb(0, 120, 215));
        public override Color MenuItemSelected => Theming.GetColor("ProfessionalColorTable.MenuItemSelected", Color.FromArgb(181, 215, 243));
        public override Color ToolStripDropDownBackground => Theming.GetColor("ProfessionalColorTable.ToolStripDropDownBackground", Color.FromArgb(253, 253, 253));

        /* Drop-down items: the little square where the image is supposed to be */
        public override Color ImageMarginGradientBegin => Theming.GetColor("ProfessionalColorTable.ImageMargin", Color.FromArgb(248, 248, 248));
        public override Color ImageMarginGradientEnd => Theming.GetColor("ProfessionalColorTable.ImageMargin", Color.FromArgb(248, 248, 248));
        public override Color ImageMarginGradientMiddle => Theming.GetColor("ProfessionalColorTable.ImageMargin", Color.FromArgb(248, 248, 248));

        /* Tool strip button hover */
        public override Color ButtonSelectedGradientBegin => Theming.GetColor("ProfessionalColorTable.ButtonSelected", Color.FromArgb(216, 230, 242));
        public override Color ButtonSelectedGradientEnd => Theming.GetColor("ProfessionalColorTable.ButtonSelected", Color.FromArgb(216, 230, 242));
        public override Color ButtonSelectedGradientMiddle => Theming.GetColor("ProfessionalColorTable.ButtonSelected", Color.FromArgb(216, 230, 242));
        public override Color ButtonSelectedBorder => Theming.GetColor("ProfessionalColorTable.ButtonSelectedBorder", Color.FromArgb(216, 230, 242));

        /* Tool strip button press */
        public override Color ButtonPressedGradientBegin => Theming.GetColor("ProfessionalColorTable.ButtonPressed", Color.FromArgb(192, 220, 243));
        public override Color ButtonPressedGradientEnd => Theming.GetColor("ProfessionalColorTable.ButtonPressed", Color.FromArgb(192, 220, 243));
        public override Color ButtonPressedGradientMiddle => Theming.GetColor("ProfessionalColorTable.ButtonPressed", Color.FromArgb(192, 220, 243));
        public override Color ButtonPressedBorder => Theming.GetColor("ProfessionalColorTable.ButtonPressedBorder", Color.FromArgb(144, 200, 246));

        public override Color SeparatorDark => Theming.GetColor("ProfessionalColorTable.SeparatorDark", Color.FromArgb(132, 132, 132));
        public override Color SeparatorLight => Theming.GetColor("ProfessionalColorTable.SeparatorLight", Color.FromArgb(245, 245, 245));
    }
}
