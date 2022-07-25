using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class WaterDisplacementsTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Enables/disables water displacement (ripples, waves).";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Water]bUseWaterDisplacements";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;
        
        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.GetBool("Water", "bUseWaterDisplacements", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Water", "bUseWaterDisplacements", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
