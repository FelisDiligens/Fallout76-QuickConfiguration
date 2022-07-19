using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class FogTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Doesn't work.";

        public WarnLevel WarnLevel => WarnLevel.Experimental;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Weather]bFogEnabled";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("Weather", "bFogEnabled", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Weather", "bFogEnabled", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
