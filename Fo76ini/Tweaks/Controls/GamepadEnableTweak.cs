using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Controls
{
    class GamepadEnableTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Disable this, if you have a gamepad plugged in, but want to use your keyboard and mouse instead.";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[General]bGamepadEnable";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("General", "bGamepadEnable", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("General", "bGamepadEnable", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
