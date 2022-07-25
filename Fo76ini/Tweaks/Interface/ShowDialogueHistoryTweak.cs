using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Interface
{
    class ShowDialogueHistoryTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[MAIN]bShowDialogueHistory";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;
        
        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.GetBool("MAIN", "bShowDialogueHistory", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("MAIN", "bShowDialogueHistory", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}