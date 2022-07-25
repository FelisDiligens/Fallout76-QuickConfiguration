using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Tweaks.Audio
{
    class PlayMainMenuMusicTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "If unchecked, the game won't play background music in the main menu.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[General]bPlayMainMenuMusic";

        public bool DefaultValue => true;

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.GetBool("General", "bPlayMainMenuMusic", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Custom.Set("General", "bPlayMainMenuMusic", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
