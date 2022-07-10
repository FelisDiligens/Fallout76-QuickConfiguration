using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class VolumetricLightingTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Also called God rays / Light shafts";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]bVolumetricLightingEnable";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("Display", "bVolumetricLightingEnable", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Display", "bVolumetricLightingEnable", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
