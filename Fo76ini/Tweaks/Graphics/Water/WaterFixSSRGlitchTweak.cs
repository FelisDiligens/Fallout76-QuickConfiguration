using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class WaterFixSSRGlitchTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Sometimes, disabling Screen Space Reflections results in pitch black, milk white, or even invisible water.\n" +
                                     "This option attempts to fix that.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => String.Join(
            Environment.NewLine,
            "",
            "[Water]",
            "bUseWaterHiRes (= 1)",
            "bUseWaterReflections (= 1)",
            "",
            "[Display]",
            "fBlendSplitDirShadow (>= 1)",
            "iMaxFocusShadows (>= 1)",
            "uWaterShadowFilter (= 3)"
            );

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => true;

        public bool GetValue()
        {
            // Since it's a tweak that doesn't correspond to any particular ini value,
            // it could annoy the user if it's enabled by default:
            if (!IniFiles.Config.GetBool("Tweaks", "bFixSSRBlackWaterGlitch", false))
                return false;

            /*
             * Check, if the values are set correctly:
             */

            if (IniFiles.GetBool("Water", "bUseWaterHiRes", false)          != true)
                return false;

            if (IniFiles.GetBool("Water", "bUseWaterReflections", true)     != true)
                return false;

            if (IniFiles.GetFloat("Display", "fBlendSplitDirShadow", 48f)   < 1)
                return false;

            if (IniFiles.GetInt("Display", "iMaxFocusShadows", 4)           < 1)
                return false;

            if (IniFiles.GetUInt("Display", "uWaterShadowFilter", 4)        != 3)
                return false;

            return true;
        }

        public void SetValue(bool value)
        {
            IniFiles.Config.Set("Tweaks", "bFixSSRBlackWaterGlitch", value);

            if (value)
            {
                // Fixes black water:
                IniFiles.F76Prefs.Set("Water", "bUseWaterHiRes", true);

                // Fixes (distant) invisible water:
                IniFiles.F76Prefs.Set("Water", "bUseWaterReflections", true);

                /*
                 * Fixes invisible water:
                 */

                if (IniFiles.GetFloat("Display", "fBlendSplitDirShadow", 48f) < 1)
                    IniFiles.F76Prefs.Set("Display", "fBlendSplitDirShadow", 48f);

                if (IniFiles.GetInt("Display", "iMaxFocusShadows", 4) < 1)
                    IniFiles.F76Prefs.Set("Display", "iMaxFocusShadows", 4);

                if (IniFiles.GetUInt("Display", "uWaterShadowFilter", 4) != 3)
                    IniFiles.F76Prefs.Set("Display", "uWaterShadowFilter", 3);
            }
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
