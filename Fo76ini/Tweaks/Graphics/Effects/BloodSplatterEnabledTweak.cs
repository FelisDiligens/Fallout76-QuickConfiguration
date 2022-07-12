using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics.Effects
{
    class BloodSplatterEnabledTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Enables blood splatters on the HUD.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[ScreenSplatter]bBloodSplatterEnabled";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("ScreenSplatter", "bBloodSplatterEnabled", DefaultValue);
        }

        public void SetValue(bool value)
        {
            if (value)
                IniFiles.F76Custom.Remove("ScreenSplatter", "bBloodSplatterEnabled");
            else
                IniFiles.F76Custom.Set("ScreenSplatter", "bBloodSplatterEnabled", false);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
