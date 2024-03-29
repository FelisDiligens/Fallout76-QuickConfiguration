﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class WaterReflectionsTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Doesn't work like you'd expect. Disable SSR instead.\n" +
                                     "⚠️ Might turn (distant) water invisible.";

        public WarnLevel WarnLevel => WarnLevel.Unsafe;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Water]bUseWaterReflections";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;
        
        public bool UIReloadNecessary => true; // effects SSR fix

        public bool GetValue()
        {
            return IniFiles.GetBool("Water", "bUseWaterReflections", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Water", "bUseWaterReflections", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
