using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class VanityModeMaxDistTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "";

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Camera]fVanityModeMaxDist";

        public float DefaultValue => 150;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("Camera", "fVanityModeMaxDist", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Camera", "fVanityModeMaxDist", value);
        }

        public void ResetValue()
        {
            IniFiles.F76Custom.Remove("Camera", "fVanityModeMaxDist");
            //SetValue(DefaultValue);
        }
    }
}
