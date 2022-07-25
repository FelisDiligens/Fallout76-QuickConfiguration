using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class ScreenSpaceReflectionsTweak : ITweak<bool>, ITweakInfo
    {
        public string Description =>
            "Enables reflections on shiny surfaces like water, puddles, and metals.\n" +
            "⚠️ If disabled, may result in pitch black, milk white, or invisible water.\n" +
            "     If you experience this, try enabling the fix under the Water section.";

        public WarnLevel WarnLevel => WarnLevel.Warning;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[LightingShader]bScreenSpaceReflections";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName + "Rev1";

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.GetBool("LightingShader", "bScreenSpaceReflections", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("LightingShader", "bScreenSpaceReflections", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
