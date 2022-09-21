using FastColoredTextBoxNS;
using Fo76ini.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using YamlDotNet.Core.Tokens;
using YamlDotNet.Serialization;

namespace Fo76ini.Interface
{
    public class Theme
    {
        public ThemeType Type = ThemeType.Light;
        public List<VisualStyle> Styles = new List<VisualStyle>();
        public Dictionary<string, string> Vars = new Dictionary<string, string>();

        public IEnumerable<VisualStyle> GetDefaultStylesForControl(String controlType)
        {
            foreach (VisualStyle style in Styles)
            {
                string controlRegex = Utils.WildCardToRegular(style.ControlType);
                if (Regex.IsMatch(controlType, controlRegex))
                    if (style.StyleName == "Default" ||
                        style.StyleName == "" ||
                        style.StyleName == null)
                        yield return style;
            }
        }

        public IEnumerable<VisualStyle> GetSpecializedStylesForControl(String controlType, string controlName, string controlTag)
        {
            foreach (VisualStyle style in Styles)
            {
                string controlRegex = Utils.WildCardToRegular(style.ControlType);
                if (Regex.IsMatch(controlType, controlRegex))
                {
                    string styleRegex = Utils.WildCardToRegular(style.StyleName);

                    if (style.StyleName == "Default" ||
                        style.StyleName == "" ||
                        style.StyleName == null)
                        continue;

                    else if (controlTag != controlName &&
                        controlTag != "Default" &&
                        controlTag != null &&
                        Regex.IsMatch(controlTag, styleRegex))
                        yield return style;

                    else if (Regex.IsMatch(controlName, styleRegex))
                        yield return style;
                }
            }
        }

        public static Theme ReadThemeFromFile(String path)
        {
            Theme t = new Theme();
            t.ReadTheme(new StreamReader(path));
            return t;
        }

        public static Theme ReadThemeFromString(String yml)
        {
            Theme t = new Theme();
            t.ReadTheme(new StringReader(yml));
            return t;
        }

        private void ReadTheme(TextReader stream)
        {
            var deserializer = new Deserializer();
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
