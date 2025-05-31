using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Accessibility
{
    /** Min: 1f, Default: 3f, Max: 10f, Step: 1f */
    class MessageWindowFadeAmountTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "Opacity When Faded\nDefault: 3";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Accessibility]fMessageFadeAmountOption";

        public float DefaultValue => 3f;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public float GetValue()
        {
            return IniFiles.F76Prefs.GetFloat("Accessibility", "fMessageFadeAmountOption", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Prefs.Set("Accessibility", "fMessageFadeAmountOption", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
