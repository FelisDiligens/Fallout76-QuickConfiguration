using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class DirShadowSplitsTweak : ITweak<int>, ITweakInfo
    {
        public string Description =>
            "Amount of \"segments\" of lower-res shadows at a distance.\n" +
            "A value of 1 forces the game to render only the lowest resolution shadows.";

        public WarnLevel WarnLevel => WarnLevel.Dangerous;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]iDirShadowSplits";

        public int DefaultValue => 3;

        public string Identifier => this.GetType().FullName;

        public int GetValue()
        {
            return IniFiles.GetInt("Display", "iDirShadowSplits", DefaultValue);
        }

        public void SetValue(int value)
        {
            IniFiles.F76Prefs.Set("Display", "iDirShadowSplits", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
