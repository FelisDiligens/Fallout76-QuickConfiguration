using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.NuclearWinterMode
{
    class ShowNWModeButtonTweak : ITweak<bool>, ITweakInfo
    {
        public string Identifier => this.GetType().FullName;

        public string Description => "If checked, it will show the Nuclear Winter / Adventure mode button in the main window, so you can still toggle the deprecated NW mode.";

        public string AffectedFiles => "config.ini";

        public string AffectedValues => "[NuclearWinter]bShowNWModeBtn";

        public bool DefaultValue => false;

        public bool GetValue()
        {
            return IniFiles.Config.GetBool("NuclearWinter", "bShowNWModeBtn", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.Config.Set("NuclearWinter", "bShowNWModeBtn", value);
        }

        public void ResetValue()
        {
            IniFiles.Config.Set("NuclearWinter", "bShowNWModeBtn", DefaultValue);
        }
    }
}
