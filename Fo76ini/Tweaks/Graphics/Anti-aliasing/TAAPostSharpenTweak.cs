using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class TAAPostSharpenTweak : ITweak<float>, ITweakInfo
    {
        public string Description => String.Join(
            Environment.NewLine,
            "Sharpening amount post-TAA.\n" +
            "ℹ️ Increasing this value too much causes flickering on screen.",
            "Default: 0.21",
            "Recommended: 0.4");

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Display]fTAAPostSharpen";

        public float DefaultValue => 0.21f;

        public string Identifier => this.GetType().FullName + "Rev1";

        public float GetValue()
        {
            return IniFiles.GetFloat("Display", "fTAAPostSharpen", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Display", "fTAAPostSharpen", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
