namespace Fo76ini.Tweaks.Config
{
    class ToolQuitOnLaunchTweak : ITweak<bool>, ITweakInfo
    {
        public string Description => "When enabled, closes the tool when the game is launched.\nOnly works if launched through the tool.";

        public string AffectedFiles => "config.ini";

        public string AffectedValues => "bQuitOnLaunch";

        public bool DefaultValue => false;

        public string Identifier => this.GetType().FullName;

        public bool GetValue()
        {
            return IniFiles.Config.GetBool("Preferences", "bQuitOnLaunch", DefaultValue);
        }

        public void SetValue(bool value)
        {
            IniFiles.Config.Set("Preferences", "bQuitOnLaunch", value);
        }

        public void ResetValue()
        {
            SetValue(DefaultValue);
        }
    }
}
