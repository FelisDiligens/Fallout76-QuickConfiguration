using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class LensFlareTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini, Fallout76Custom.ini";

        public string AffectedValues => "[ImageSpace]bLensFlare, [Display]fIBLensFlaresGlobalIntensity";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("ImageSpace", "bLensFlare", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("ImageSpace", "bLensFlare", value);
            if (value)
                IniFiles.F76Custom.Remove("Display", "fIBLensFlaresGlobalIntensity"); // Default is 0.25
            else
                IniFiles.F76Custom.Set("Display", "fIBLensFlaresGlobalIntensity", 0);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
