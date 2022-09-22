using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Controls
{
    public class CustomToolStripProfessionalRenderer : ToolStripProfessionalRenderer
    {
        public CustomToolStripProfessionalRenderer(ProfessionalColorTable table) : base(table) { }

        protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
        {
            if (!(e.ToolStrip is StatusStrip||
                  e.ToolStrip is ToolStrip))
                base.OnRenderToolStripBorder(e);
        }
    }
}
