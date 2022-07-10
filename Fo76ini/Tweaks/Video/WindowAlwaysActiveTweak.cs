using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Video
{
    class WindowAlwaysActiveTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "Disable this, if you want the game to pause if another window is in front.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[Interface]bAlwaysActive";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("Interface", "bAlwaysActive", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Custom.Set("Interface", "bAlwaysActive", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
