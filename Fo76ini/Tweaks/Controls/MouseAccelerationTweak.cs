using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Controls
{
    class MouseAccelerationTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "ℹ️ This option might not have any effect.";

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Controls]bMouseAcceleration";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("Controls", "bMouseAcceleration", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Custom.Set("Controls", "bMouseAcceleration", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
