using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Interface
{
    public interface IThemable
    {
        string VisualStyle { get; set; }

        /// <summary>
        /// Apply the theme to the control, if necessary.
        /// </summary>
        void ApplyTheme(ThemeType theme);
    }
}
