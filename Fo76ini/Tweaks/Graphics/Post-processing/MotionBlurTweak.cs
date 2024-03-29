﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class MotionBlurTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Doesn't seem to do anything.";

        public WarnLevel WarnLevel => WarnLevel.Experimental;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[ImageSpace]bMBEnable";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName + "Rev1";

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.GetBool("ImageSpace", "bMBEnable", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Custom.Set("ImageSpace", "bMBEnable", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
