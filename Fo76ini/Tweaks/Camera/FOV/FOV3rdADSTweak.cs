using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class FOV3rdADSTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "Changes the field of view of the 3rd person perspective while aiming.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Camera]f3rdPersonAimFOV";

        public float DefaultValue => 50;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("Camera", "f3rdPersonAimFOV", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Camera", "f3rdPersonAimFOV", value);
        }

        public void ResetValue()
        {
            IniFiles.F76Custom.Remove("Camera", "f3rdPersonAimFOV");
            //SetValue(DefaultValue);
        }
    }
}
