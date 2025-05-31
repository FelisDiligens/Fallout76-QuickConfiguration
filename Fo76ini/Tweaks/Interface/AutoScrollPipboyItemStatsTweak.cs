using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Interface
{
    class AutoScrollPipboyItemStatsTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]bAutoScrollPipboyItemStats";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.F76Prefs.GetBool("Display", "bAutoScrollPipboyItemStats", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Display", "bAutoScrollPipboyItemStats", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}