using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.General
{
    class SkipStartupSplash : ITweak<bool>, ITweakInfo
    {
        public string Description => "If enabled, the game won't bother you with news on startup.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[General]bSkipSplash";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.GetBool("General", "bSkipSplash", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Custom.Set("General", "bSkipSplash", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
