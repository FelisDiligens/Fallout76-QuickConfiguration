﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Audio
{
    class VoicePushToTalkEnabledTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Voice]bVoicePushToTalkEnabled";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.GetBool("Voice", "bVoicePushToTalkEnabled", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Voice", "bVoicePushToTalkEnabled", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
