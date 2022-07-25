using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class WaterHiResTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Might fix black water issue if enabled.";

        public WarnLevel WarnLevel => WarnLevel.Experimental;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Water]bUseWaterHiRes";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;
        
        public bool UIReloadNecessary => true; // effects SSR fix

        public bool GetValue()
        {
            return IniFiles.GetBool("Water", "bUseWaterHiRes", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Water", "bUseWaterHiRes", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
