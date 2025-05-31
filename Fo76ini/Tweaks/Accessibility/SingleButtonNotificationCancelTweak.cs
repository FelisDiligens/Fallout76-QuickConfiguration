using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Accessibility
{
    class SingleButtonNotificationCancelTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Use a single button press to cancel pop-up notifications.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Accessibility]bAltFastTravelControl";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.F76Prefs.GetBool("Accessibility", "bAltFastTravelControl", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Accessibility", "bAltFastTravelControl", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}