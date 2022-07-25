using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Graphics
{
    class ShadowMapResolutionTweak : ITweak<int>, ITweakInfo
    {
        public string Description => "Resolution of shadows. Higher settings will make shadows more detailed.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]iShadowMapResolution";

        public int DefaultValue => 2048;

        public string Identifier => this.GetType().FullName;
        
        public bool UIReloadNecessary => false;

        public int GetValue()
        {
            return IniFiles.GetInt("Display", "iShadowMapResolution", DefaultValue);
        }

        public void SetValue(int value)
        {
            IniFiles.F76Prefs.Set("Display", "iShadowMapResolution", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
