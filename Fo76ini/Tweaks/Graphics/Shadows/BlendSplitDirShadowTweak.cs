using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class BlendSplitDirShadowTweak : ITweak<int>, ITweakInfo
    {
        public string Description =>
            "Distance at which the game will transition to lower-res a shadow \"segment\".\n" +
            "MUST be a multiple of 12.";

        public WarnLevel WarnLevel => WarnLevel.Unsafe;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]fBlendSplitDirShadow";

        public int DefaultValue => 48;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false; // true (SSR fix)

        public int GetValue()
        {
            return IniFiles.GetInt("Display", "fBlendSplitDirShadow", DefaultValue);
        }

        public void SetValue(int value)
        {
            IniFiles.F76Prefs.Set("Display", "fBlendSplitDirShadow", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
