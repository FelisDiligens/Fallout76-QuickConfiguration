using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class DisableAutoVanityModeTweak : ITweak<bool>, ITweakInfo
    {
        public string Description =>
            "When enabled, the camera will spin around the character after no input was given for a certain amount of time.\n" +
            "⚠️ Not sure if it does anything. I stood around for 5 minutes and the camera didn't spin. Needs more testing.";

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Camera]bDisableAutoVanityMode";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("Camera", "bDisableAutoVanityMode", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Custom.Set("Camera", "bDisableAutoVanityMode", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
