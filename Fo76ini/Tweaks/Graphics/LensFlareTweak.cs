﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class LensFlareTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.Experimental;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[ImageSpace]bLensFlare";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("ImageSpace", "bLensFlare", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("ImageSpace", "bLensFlare", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
