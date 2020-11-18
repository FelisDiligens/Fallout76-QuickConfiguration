﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class CameraOverShoulderMeleeCombatAddYTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "";

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Camera]fOverShoulderMeleeCombatAddY";

        public float DefaultValue => 0;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("Camera", "fOverShoulderMeleeCombatAddY", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Camera", "fOverShoulderMeleeCombatAddY", value);
        }

        public void ResetValue()
        {
            IniFiles.F76Custom.Remove("Camera", "fOverShoulderMeleeCombatAddY");
            //SetValue(DefaultValue);
        }
    }
}
