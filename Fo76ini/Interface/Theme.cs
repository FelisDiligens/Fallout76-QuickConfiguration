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

        public IEnumerable<VisualStyle> GetDefaultStylesForControl(Control control)
        {
            // Iterate over each style...
            foreach (VisualStyle style in Styles)
            {
                // Does the control type match?
                string controlRegex = Utils.WildCardToRegular(style.ControlType);
                if (Regex.IsMatch(control.GetType().Name, controlRegex))
                {
                    // Does it not have the given parents?
                    if (!CheckParent(style, control))
                        continue; // Skip...

                    // Is a default style?
                    if (style.StyleName == "Default" ||
                        style.StyleName == "" ||
                        style.StyleName == null)
                        yield return style;
                }
            }
        }

        public IEnumerable<VisualStyle> GetSpecializedStylesForControl(Control control)
        {
            // Iterate over each style...
            foreach (VisualStyle style in Styles)
            {
                // Does the control type match?
                string controlRegex = Utils.WildCardToRegular(style.ControlType);
                if (Regex.IsMatch(control.GetType().Name, controlRegex))
                {
                    // Is a default style?
                    if (style.StyleName == "Default" ||
                        style.StyleName == "" ||
                        style.StyleName == null)
                        continue; // Skip...

                    // Does it not have the given parents?
                    if (!CheckParent(style, control))
                        continue; // Skip...

                    // Does the control tag/name match?
                    string styleRegex = Utils.WildCardToRegular(style.StyleName);

                    string controlTag = "Default";
                    if (control.Tag != null)
                        controlTag = control.Tag.ToString();

                    if (controlTag != control.Name &&
                        controlTag != "Default" &&
                        controlTag != null &&
                        Regex.IsMatch(controlTag, styleRegex))
                        yield return style;

                    else if (Regex.IsMatch(control.Name, styleRegex))
                        yield return style;
                }
            }
        }

        private bool CheckParent(VisualStyle style, Control control)
        {
            // Does it have parents?
            if (style.ParentType != null && style.ParentStyleName != null)
            {
                string parentTypeRegex = Utils.WildCardToRegular(style.ParentType);
                string parentNameRegex = Utils.WildCardToRegular(style.ParentStyleName);

                // Iterate over all parents:
                Control parentControl = control.Parent;
                while (parentControl != null)
                {
                    // Does the type match?
                    if (Regex.IsMatch(parentControl.GetType().Name, parentTypeRegex) &&
                        // Does tha tag/name match?
                        (style.ParentStyleName == "Default" ||
                         Regex.IsMatch(parentControl.Name, parentNameRegex) ||
                         (parentControl.Tag != null && Regex.IsMatch(parentControl.Tag.ToString(), parentNameRegex))))
                        return true;

                    parentControl = parentControl.Parent;
                }

                return false;
            }
            else
            {
                return true;
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
                    // selector, selector2, selector3, ...
                    foreach (string selector in key.Split(','))
                    {
                        // parent > control[.name/.tag]
                        int gtIndex = selector.IndexOf('>');
                        string controlSelector = selector;
                        string parentType = null;
                        string parentStyle = null;
                        if (gtIndex != -1)
                        {
                            controlSelector = selector.Substring(gtIndex + 1).Trim();
                            string parent = selector.Substring(0, gtIndex).Trim();
                            parentType = parent;
                            parentStyle = "Default";

                            // parentControl[.parentName/.parentTag]
                            int parentDotIndex = parent.IndexOf(".");
                            if (parentDotIndex != -1)
                            {
                                parentType = parent.Substring(0, parentDotIndex).Trim();
                                parentStyle = parent.Substring(parentDotIndex + 1).Trim();
                            }
                        }

                        // control[.name/.tag]
                        int dotIndex = controlSelector.IndexOf(".");
                        string controlType = controlSelector.Trim();
                        string controlNameOrTag = "Default";
                        if (dotIndex != -1)
                        {
                            controlType = controlSelector.Substring(0, dotIndex).Trim();
                            controlNameOrTag = controlSelector.Substring(dotIndex + 1).Trim();
                        }

                        VisualStyle vs = new VisualStyle
                        {
                            ParentType = parentType,
                            ParentStyleName = parentStyle,
                            ControlType = controlType,
                            StyleName = controlNameOrTag
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
        public string ParentType = null;
        public string ParentStyleName = null;
        public string ControlType = "*";
        public string StyleName = "Default";
        public Dictionary<String, object> Rules = new Dictionary<String, object>();
    }
}
