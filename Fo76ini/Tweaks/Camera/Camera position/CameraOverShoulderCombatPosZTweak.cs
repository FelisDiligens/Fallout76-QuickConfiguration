using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class CameraOverShoulderCombatPosZTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.Experimental;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Camera]fOverShoulderCombatPosZ";

        public float DefaultValue => 0;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public float GetValue()
        {
            return IniFiles.GetFloat("Camera", "fOverShoulderCombatPosZ", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Camera", "fOverShoulderCombatPosZ", value);
        }

        public void ResetValue()
        {
            IniFiles.F76Custom.Remove("Camera", "fOverShoulderCombatPosZ");
            //SetValue(DefaultValue);
        }
    }
}
