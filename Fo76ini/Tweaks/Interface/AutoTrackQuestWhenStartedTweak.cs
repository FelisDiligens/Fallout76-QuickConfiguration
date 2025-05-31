using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Interface
{
    class AutoTrackQuestWhenStartedTweak : ITweak<bool>, ITweakInfo
    {
        public AutoTrackQuestWhenStartedTweak(string keyPrefix, string questType)
        {
            this.KeyPrefix = keyPrefix;
            this.QuestType = questType;

            // Determine default value:
            switch (this.KeyPrefix)
            {
                case "Main":
                case "Event":
                    this.DefaultValue = true;
                    break;
                case "Side":
                case "Misc":
                case "Other":
                default:
                    this.DefaultValue = false;
                    break;
            }
        }

        private string KeyPrefix;
        private string QuestType;

        public string Description => $"If enabled, automatically tracks newly added '{this.QuestType}' quests.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => $"[MAIN]bEnableQuestAutoTrack{this.KeyPrefix}";

        public bool DefaultValue { get; }

        public string Identifier => this.GetType().FullName + "+" + this.KeyPrefix;
        
        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.GetBool("MAIN", $"bEnableQuestAutoTrack{this.KeyPrefix}", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("MAIN", $"bEnableQuestAutoTrack{this.KeyPrefix}", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
