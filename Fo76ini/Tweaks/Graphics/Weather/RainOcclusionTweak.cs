using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class RainOcclusionTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Doesn't work.";

        public WarnLevel WarnLevel => WarnLevel.Experimental;

        public string AffectedFiles => "Fallout76.ini";

        public string AffectedValues => "[Weather]bRainOcclusion";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("Weather", "bRainOcclusion", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76.Set("Weather", "bRainOcclusion", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
