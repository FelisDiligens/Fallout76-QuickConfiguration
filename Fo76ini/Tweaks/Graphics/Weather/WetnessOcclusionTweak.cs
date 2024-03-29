﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class WetnessOcclusionTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Doesn't seem to do anything.";

        public WarnLevel WarnLevel => WarnLevel.Experimental;

        public string AffectedFiles => "Fallout76.ini";

        public string AffectedValues => "[Weather]bWetnessOcclusion";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;
        
        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.GetBool("Weather", "bWetnessOcclusion", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76.Set("Weather", "bWetnessOcclusion", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
