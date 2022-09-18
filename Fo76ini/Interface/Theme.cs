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
        public List<VisualStyle> Styles = new List<VisualStyle>();

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
                int dotIndex = key.IndexOf(".");

                VisualStyle vs = new VisualStyle
                {
                    ControlType = key.Contains(".") ? key.Substring(0, dotIndex) : key,
                    StyleName = key.Contains(".") ? key.Substring(dotIndex + 1) : "Default"
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

    public class VisualStyle
    {
        public string ControlType = "";
        public string StyleName = "Default";
        public Dictionary<String, object> Rules = new Dictionary<String, object>();
    }
}
