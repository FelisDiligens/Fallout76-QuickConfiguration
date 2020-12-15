using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class PitchZoomOutMaxDistTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "By how much the camera gets zoomed out when you look at the ground in 3rd person.";

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Camera]fPitchZoomOutMaxDist";

        public float DefaultValue => 100;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("Camera", "fPitchZoomOutMaxDist", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Camera", "fPitchZoomOutMaxDist", value);
        }

        public void ResetValue()
        {
            IniFiles.F76Custom.Remove("Camera", "fPitchZoomOutMaxDist");
            //SetValue(DefaultValue);
        }
    }
}
