using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Interface
{
    class ShowPublicTeamNotificationsTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[GamePlay]bShowPublicTeamNotifications";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("GamePlay", "bShowPublicTeamNotifications", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("GamePlay", "bShowPublicTeamNotifications", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
