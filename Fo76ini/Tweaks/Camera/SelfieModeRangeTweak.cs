﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class SelfieModeRangeTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "";

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Camera]fSelfieModeRange";

        public float DefaultValue => 500;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("Camera", "fSelfieModeRange", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Camera", "fSelfieModeRange", value);
        }

        public void ResetValue()
        {
            IniFiles.F76Custom.Remove("Camera", "fSelfieModeRange");
            //SetValue(DefaultValue);
        }
    }
}
