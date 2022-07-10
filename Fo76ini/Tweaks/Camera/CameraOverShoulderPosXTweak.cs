using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class CameraOverShoulderPosXTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.Experimental;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Camera]fOverShoulderPosX";

        public float DefaultValue => 0;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("Camera", "fOverShoulderPosX", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Camera", "fOverShoulderPosX", value);
        }

        public void ResetValue()
        {
            IniFiles.F76Custom.Remove("Camera", "fOverShoulderPosX");
            //SetValue(DefaultValue);
        }
    }
}
