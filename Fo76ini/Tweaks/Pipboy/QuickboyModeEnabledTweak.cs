﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Pipboy
{
    class QuickboyModeEnabledTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Pipboy]bQuickboyMode";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("Pipboy", "bQuickboyMode", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Pipboy", "bQuickboyMode", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
