using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Video
{
    class DisplaySizeTweak : ITweak<Size>, ITweakInfo
    {
        public string Description => "Display resolution";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]iSize W, [Display]iSize H";

        public Size DefaultValue => new Size(1920, 1080);

        public string Identifier => this.GetType().FullName;

        public Size GetValue()
        {
            int w = IniFiles.GetInt("Display", "iSize W", DefaultValue.Width);
            int h = IniFiles.GetInt("Display", "iSize H", DefaultValue.Height);
            return new Size(w, h);
        }

        public void SetValue(Size value)
        {
            IniFiles.F76Prefs.Set("Display", "iSize W", value.Width);
            IniFiles.F76Prefs.Set("Display", "iSize H", value.Height);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
