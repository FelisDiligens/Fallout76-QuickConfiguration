using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class TAAPostOverlayTweak : ITweak<float>, ITweakInfo
    {
        public string Description => String.Join(
            Environment.NewLine,
            "Sharpens the image.",
            "Default: 0.21");

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Display]fTAAPostOverlay";

        public float DefaultValue => 0.21f;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("Display", "fTAAPostOverlay", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Display", "fTAAPostOverlay", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
