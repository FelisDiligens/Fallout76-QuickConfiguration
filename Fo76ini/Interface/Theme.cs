using FastColoredTextBoxNS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Fo76ini.Interface
{
    public class Theme
    {
        public ThemeType Type = ThemeType.Light;
        public List<VisualStyle> Styles = new List<VisualStyle>();
        public Dictionary<string, string> Vars = new Dictionary<string, string>();

        public List<VisualStyle> GetStylesForControl(String controlType)
        {
            return Styles.Where(x => x.ControlType == controlType).ToList();
        }

        public VisualStyle GetStyle(String controlType, String styleName)
        {
            return Styles.Where(x => x.ControlType == controlType && x.StyleName == styleName).FirstOrDefault();
        }

        public VisualStyle GetDefaultStyleForControl(String controlType)
        {
            return GetStyle(controlType, "Default");
        }

        public static Theme ReadTheme(String path)
        {
            Theme t = new Theme();
            t.readTheme(path);
            return t;
        }

        private void readTheme(String path)
        {
            var deserializer = new Deserializer();
            var stream = new StreamReader(path);
            var result = deserializer.Deserialize<Dictionary<object, object>>(stream);
            stream.Close();
            if (result == null)
                return;

            foreach (KeyValuePair<object, object> entry in result)
            {
                String key = entry.Key.ToString();
                if (key == "META")
                {
                    foreach (KeyValuePair<object, object> subEntry in (Dictionary<object, object>)entry.Value)
                    {
                        if (subEntry.Key.ToString() == "BaseTheme")
                            Enum.TryParse(subEntry.Value.ToString(), out this.Type);
                    }
                }
                else if (key == "VARS")
                {
                    foreach (KeyValuePair<object, object> subEntry in (Dictionary<object, object>)entry.Value)
                        this.Vars.Add(subEntry.Key.ToString(), subEntry.Value.ToString());
                }
                else
                {
                    foreach (string selector in key.Split(','))
                    {
                        int dotIndex = selector.IndexOf(".");

                        VisualStyle vs = new VisualStyle
                        {
                            ControlType = selector.Contains(".") ? selector.Substring(0, dotIndex).Trim() : selector.Trim(),
                            StyleName = selector.Contains(".") ? selector.Substring(dotIndex + 1).Trim() : "Default"
                        };

                        // Rules:
                        foreach (KeyValuePair<object, object> rule in (Dictionary<object, object>)entry.Value)
                        {
                            vs.Rules[rule.Key.ToString()] = rule.Value;
                        }

                        Styles.Add(vs);
                    }
                }
            }
        }
    }

    public class VisualStyle
    {
        public string ControlType = "";
        public string StyleName = "Default";
        public Dictionary<String, object> Rules = new Dictionary<String, object>();
    }
}
