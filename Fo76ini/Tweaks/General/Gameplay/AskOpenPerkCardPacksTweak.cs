using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.General
{
    class AskOpenPerkCardPacksTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[MAIN]bAskOpenPerkCardPacks";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.F76Prefs.GetBool("MAIN", "bAskOpenPerkCardPacks", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("MAIN", "bAskOpenPerkCardPacks", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}