using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Controls
{
    class EnableGamepadRumbleTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Controls]bGamePadRumble";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("Controls", "bGamePadRumble", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Custom.Set("Controls", "bGamePadRumble", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
