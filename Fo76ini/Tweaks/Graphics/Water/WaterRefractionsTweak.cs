using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class WaterRefractionsTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Not sure if it does anything.";

        public WarnLevel WarnLevel => WarnLevel.Experimental;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Water]bUseWaterRefractions";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("Water", "bUseWaterRefractions", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Water", "bUseWaterRefractions", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
