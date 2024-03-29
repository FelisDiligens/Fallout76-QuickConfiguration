﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class DisableAllGoreTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "No more blood particle effects when shooting enemies";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[General]bDisableAllGore";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName + "Rev1";

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.GetBool("General", "bDisableAllGore", DefaultValue);
        }

        public void SetValue(bool value)
        {
            if (value)
                IniFiles.F76Custom.Set("General", "bDisableAllGore", true);
            else
                IniFiles.F76Custom.Remove("General", "bDisableAllGore");
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
