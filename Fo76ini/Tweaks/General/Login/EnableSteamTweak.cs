namespace Fo76ini.Tweaks.General
{
    class EnableSteamTweak : ITweak<bool>, ITweakInfo
    {
        public bool DefaultValue => true;

        public string Description => "Enables/Disables Steam integration. Disable it to use your Bethesda.net account.";

        public WarnLevel WarnLevel => WarnLevel.None;

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => "[General]bSteamEnabled";

        public string Identifier => this.GetType().FullName;

        public bool UIReloadNecessary => false;

        public bool GetValue()
        {
            return IniFiles.F76Custom.GetBool("General", "bSteamEnabled", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.F76Custom.Set("General", "bSteamEnabled", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
