using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Accessibility
{
    class ScreenNarrationEnabledTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Narrates emotes and reasons for declining trades. Transcribes into the Message Window if Speech To Text is enabled.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Accessibility]bScreenNarrationEnabled";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.F76Prefs.GetBool("Accessibility", "bScreenNarrationEnabled", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Accessibility", "bScreenNarrationEnabled", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}