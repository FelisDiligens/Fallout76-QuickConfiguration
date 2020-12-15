using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Config
{
    class PlayNotificationSoundsTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "When enabled, the tool will play custom notification sounds.";

        public string AffectedFiles => "config.ini";

        public string AffectedValues => "bPlayNotificationSound";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.Config.GetBool("Preferences", "bPlayNotificationSound", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.Config.Set("Preferences", "bPlayNotificationSound", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
