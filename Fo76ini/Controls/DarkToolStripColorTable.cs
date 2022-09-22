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
    public class DarkToolStripColorTable : ProfessionalColorTable
    {
        public override Color ToolStripBorder => Color.FromArgb(0, 0, 0);
        public override Color ToolStripDropDownBackground => Color.FromArgb(51, 51, 51);
        public override Color ToolStripGradientBegin => Color.FromArgb(51, 51, 51);
        public override Color ToolStripGradientEnd => Color.FromArgb(51, 51, 51);
        public override Color ToolStripGradientMiddle => Color.FromArgb(51, 51, 51);

        /* Menu strip (top) */
        public override Color MenuBorder => Color.FromArgb(0, 0, 0);
        public override Color MenuStripGradientBegin => Color.FromArgb(34, 34, 34);
        public override Color MenuStripGradientEnd => Color.FromArgb(34, 34, 34);

        /* Status strip (bottom) */
        public override Color StatusStripGradientBegin => Color.FromArgb(34, 34, 34);
        public override Color StatusStripGradientEnd => Color.FromArgb(34, 34, 34);

        /* Top-level menu strip items - press */
        public override Color MenuItemPressedGradientBegin => Color.FromArgb(51, 51, 51);
        public override Color MenuItemPressedGradientEnd => Color.FromArgb(51, 51, 51);
        public override Color MenuItemPressedGradientMiddle => Color.FromArgb(51, 51, 51);

        /* Top-level menu strip items - hover */
        public override Color MenuItemSelectedGradientBegin => Color.FromArgb(51, 51, 51);
        public override Color MenuItemSelectedGradientEnd => Color.FromArgb(51, 51, 51);

        /* Drop-down items */
        public override Color MenuItemBorder => Color.FromArgb(85, 85, 85);
        public override Color MenuItemSelected => Color.FromArgb(85, 85, 85);

        /* Drop-down items: the little square where the image is supposed to be */
        public override Color ImageMarginGradientBegin => Color.FromArgb(51, 51, 51);
        public override Color ImageMarginGradientEnd => Color.FromArgb(51, 51, 51);
        public override Color ImageMarginGradientMiddle => Color.FromArgb(51, 51, 51);

        /* Tool strip button hover */
        public override Color ButtonSelectedGradientBegin => Color.FromArgb(85, 85, 85);
        public override Color ButtonSelectedGradientEnd => Color.FromArgb(85, 85, 85);
        public override Color ButtonSelectedGradientMiddle => Color.FromArgb(85, 85, 85);
        public override Color ButtonSelectedBorder => Color.FromArgb(85, 85, 85);

        /* Tool strip button press */
        public override Color ButtonPressedGradientBegin => Color.FromArgb(102, 102, 102);
        public override Color ButtonPressedGradientEnd => Color.FromArgb(102, 102, 102);
        public override Color ButtonPressedGradientMiddle => Color.FromArgb(102, 102, 102);
        public override Color ButtonPressedBorder => Color.FromArgb(102, 102, 102);
    }
}
