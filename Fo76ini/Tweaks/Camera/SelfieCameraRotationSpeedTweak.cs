using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class SelfieCameraRotationSpeedTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Camera]fSelfieCameraRotationSpeed";

        public float DefaultValue => 1.5f;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("Camera", "fSelfieCameraRotationSpeed", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Camera", "fSelfieCameraRotationSpeed", value);
        }

        public void ResetValue()
        {
            IniFiles.F76Custom.Remove("Camera", "fSelfieCameraRotationSpeed");
            //SetValue(DefaultValue);
        }
    }
}
