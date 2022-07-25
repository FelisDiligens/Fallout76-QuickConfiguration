using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class AnisotropicFilteringTweak : ITweak<int>, ITweakInfo
    {
        public string Description => "Reduces aliasing of textures when viewed from oblique angles.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]iMaxAnisotropy";

        public int DefaultValue => 16;

        public string Identifier => this.GetType().FullName;
        
        public bool UIReloadNecessary => false;

        public int GetValue()
        {
            return IniFiles.GetInt("Display", "iMaxAnisotropy", DefaultValue);
        }

        public void SetValue(int value)
        {
            IniFiles.F76Prefs.Set("Display", "iMaxAnisotropy", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
