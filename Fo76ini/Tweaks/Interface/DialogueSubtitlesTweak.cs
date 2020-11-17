﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Interface
{
    class DialogueSubtitlesTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "";

        public string AffectedFiles => "Fallout76Prefs.ini";

        public string AffectedValues => "[Interface]bDialogueSubtitles";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.GetBool("Interface", "bDialogueSubtitles", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Prefs.Set("Interface", "bDialogueSubtitles", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}