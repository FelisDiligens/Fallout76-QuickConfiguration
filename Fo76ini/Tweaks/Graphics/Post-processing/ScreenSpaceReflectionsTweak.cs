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
            "(Caused pitch black water in previous versions, but is safe now)";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[LightingShader]bScreenSpaceReflections";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

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
