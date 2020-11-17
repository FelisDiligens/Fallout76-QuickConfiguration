﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    // fShadowDistance was replaced by fDirShadowDistance in Fallout 4
    class ShadowDistanceTweak : ITweak<float>, ITweakInfo
    {
        public string Description => String.Join(
            Environment.NewLine,
            "Sets the distance that shadows are rendered.",
            "  ⇨ Ultra is 150000",
            "  ⇨ High is 120000",
            "  ⇨ Medium is 90000",
            "  ⇨ Low is 60000");

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]fDirShadowDistance";

        public float DefaultValue => 90000f;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("Display", "fDirShadowDistance", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Prefs.Set("Display", "fDirShadowDistance", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
