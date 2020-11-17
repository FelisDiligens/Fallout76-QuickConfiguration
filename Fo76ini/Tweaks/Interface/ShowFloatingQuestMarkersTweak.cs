using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Interface
{
    class ShowFloatingQuestMarkersTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[GamePlay]bShowFloatingQuestMarkers";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("GamePlay", "bShowFloatingQuestMarkers", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("GamePlay", "bShowFloatingQuestMarkers", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
