﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class RadialBlurTweak : ITweak<bool>, ITweakInfo
    {
        public string Description =>
            "Blurs the screen when the player is hurt (e.g. hit by bullets) or under water.\n" +
            "⚠️ Disabling this might result in a clear view underwater.";

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[ImageSpace]bDoRadialBlur";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("ImageSpace", "bDoRadialBlur", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Custom.Set("ImageSpace", "bDoRadialBlur", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
