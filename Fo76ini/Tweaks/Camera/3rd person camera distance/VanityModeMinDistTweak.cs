using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class VanityModeMinDistTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "By how much you can zoom in in 3rd person view\n" +
                                     "Default: 0";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Camera]fVanityModeMinDist";

        public float DefaultValue => 0;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("Camera", "fVanityModeMinDist", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Camera", "fVanityModeMinDist", value);
        }

        public void ResetValue()
        {
            IniFiles.F76Custom.Remove("Camera", "fVanityModeMinDist");
            //SetValue(DefaultValue);
        }
    }
}
