using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Pipboy
{
    class PipboyTargetResolutionTweak : ITweak<Size>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]uPipboyTargetWidth, uPipboyTargetHeight";

        public Size DefaultValue => new Size(876, 700);

        public string Identifier => this.GetType().FullName;

        public Size GetValue()
        {
            int width = IniFiles.GetInt("Display", "uPipboyTargetWidth", DefaultValue.Width);
            int height = IniFiles.GetInt("Display", "uPipboyTargetHeight", DefaultValue.Height);
            return new Size(width, height);
        }

        public void SetValue(Size value)
        {
            IniFiles.F76Prefs.Set("Display", "uPipboyTargetWidth", value.Width);
            IniFiles.F76Prefs.Set("Display", "uPipboyTargetHeight", value.Height);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
