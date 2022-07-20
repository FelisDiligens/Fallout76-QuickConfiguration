using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class FirstThirdPerspectiveSwitchDelayTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "ℹ️ Doesn't work.";

        public WarnLevel WarnLevel => WarnLevel.Experimental;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Camera]f1st3rdSwitchDelay";

        public float DefaultValue => 0.25f;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("Camera", "f1st3rdSwitchDelay", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Camera", "f1st3rdSwitchDelay", value);
        }

        public void ResetValue()
        {
            IniFiles.F76Custom.Remove("Camera", "f1st3rdSwitchDelay");
            //SetValue(DefaultValue);
        }
    }
}
