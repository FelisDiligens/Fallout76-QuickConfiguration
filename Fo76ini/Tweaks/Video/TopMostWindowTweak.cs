using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Video
{
    class TopMostWindowTweak : ITweak<bool>, ITweakInfo
    {
        public string Description =>
            "Enabling this, will keep the game's window in the foreground.\n" +
            "⚠️ This will prevent you from being able to Alt+Tab on single monitors.";

        public WarnLevel WarnLevel => WarnLevel.Warning;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]bTopMostWindow";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;
        
        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.GetBool("Display", "bTopMostWindow", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Display", "bTopMostWindow", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
