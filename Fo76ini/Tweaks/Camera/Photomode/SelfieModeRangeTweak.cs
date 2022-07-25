using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Camera
{
    class SelfieModeRangeTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "At which distance the game will stop you from moving away from your character in photo mode.\n" +
                                     "Default: 500";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Camera]fSelfieModeRange";

        public float DefaultValue => 500;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public float GetValue()
        {
            return IniFiles.GetFloat("Camera", "fSelfieModeRange", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Custom.Set("Camera", "fSelfieModeRange", value);
        }

        public void ResetValue()
        {
            IniFiles.F76Custom.Remove("Camera", "fSelfieModeRange");
            //SetValue(DefaultValue);
        }
    }
}
