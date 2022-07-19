using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class AmbientOcclusionTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Enables/Disables shadows in corners or where objects touch the ground.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]bSAOEnable";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("Display", "bSAOEnable", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Display", "bSAOEnable", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
