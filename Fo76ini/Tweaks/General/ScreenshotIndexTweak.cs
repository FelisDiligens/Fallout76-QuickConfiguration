using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.General
{
    class ScreenshotIndexTweak : ITweak<int>, ITweakInfo
    {
        public string Description =>
            "When you take screenshots ingame with the print screen button,\n" +
            "it saves them in the game directory as \"ScreenShotX.png\".\n" + 
            "The \"X\" being the screenshot index.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]iScreenShotIndex";

        public int DefaultValue => 0;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public int GetValue()
        {
            return IniFiles.GetInt("Display", "iScreenShotIndex", DefaultValue);
        }

        public void SetValue(int value)
        {
            IniFiles.F76Prefs.Set("Display", "iScreenShotIndex", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
