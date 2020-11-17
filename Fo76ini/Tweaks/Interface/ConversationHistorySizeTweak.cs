using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Interface
{
    class ConversationHistorySizeTweak : ITweak<float>, ITweakInfo
    {
        public string Description => "";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Display]fConversationHistorySize";

        public float DefaultValue => 4.0f;

        public string Identifier => this.GetType().FullName;

        public float GetValue()
        {
            return IniFiles.GetFloat("Display", "fConversationHistorySize", DefaultValue);
        }

        public void SetValue(float value)
        {
            IniFiles.F76Prefs.Set("Display", "fConversationHistorySize", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
