namespace Fo76ini.Tweaks.ResourceLists
{
    public class ResourceListTweak : ITweak<string>, ITweakInfo
    {
        private string key;

        public ResourceListTweak(string key)
        {
            this.key = key;
        }

        public static ResourceListTweak GetDefaultList()
        {
            return new ResourceListTweak("sResourceIndexFileList");
        }

        public static ResourceListTweak GetSResourceIndexFileList()
        {
            return new ResourceListTweak("sResourceIndexFileList");
        }

        public static ResourceListTweak GetSResourceArchive2List()
        {
            return new ResourceListTweak("sResourceArchive2List");
        }

        public string DefaultValue => "";

        public string Description => "A string that contains resources, delimited by commas.";

        public string AffectedFiles => "Fallout76Custom.ini";

        public string AffectedValues => key;

        public string Identifier => this.GetType().FullName;

        public string GetValue()
        {
            return IniFiles.F76Custom.GetString("Archive", key, DefaultValue);
        }

        public void SetValue(string value)
        {
            IniFiles.F76Custom.Set("Archive", key, value);
        }

        public void ResetValue()
        {
            IniFiles.F76Custom.Remove("Archive", key);
        }
    }
}
