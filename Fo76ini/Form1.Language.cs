using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

namespace Fo76ini
{
    partial class Form1
    {
        private String languageFolder = ".\\languages";
        private List<String> languageISOs;
        private List<String> languageNames;

        private void LookupLanguages()
        {
            // First of all, generate a English XML file.
            if (!Directory.Exists(languageFolder))
                Directory.CreateDirectory(languageFolder);
            GenerateEnglishXMLFile();

            this.languageISOs = new List<String> { "en-US" };
            this.languageNames = new List<String> { "English (USA)" };

            // Look into the folder and add all language files to the dropdown menu.
            foreach (string filePath in Directory.GetFiles(languageFolder))
            {
                if (filePath.EndsWith(".xml"))
                {
                    // <Language name="English (USA)" iso="en-US"> ... </Language>
                    try
                    {
                        XDocument xmlDoc = XDocument.Load(filePath);
                        if (xmlDoc.Element("Language") != null)
                        {
                            XElement lang = xmlDoc.Element("Language");
                            if (lang.Attribute("name") != null &&
                                lang.Attribute("iso") != null)
                            {
                                if (lang.Attribute("iso").Value != "en-US")
                                {
                                    this.languageISOs.Add(lang.Attribute("iso").Value);
                                    this.languageNames.Add(lang.Attribute("name").Value);
                                }
                            }
                            else
                            {
                                MessageBox.Show($"{filePath} couldn't be loaded.\n<Language name=\"name goes here\" iso=\"iso string goes here\"> is missing.\nPlease add iso and name attribute to Language.", $"{filePath} couldn't be loaded.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                    }
                    catch (System.Xml.XmlException e)
                    {
                        MessageBox.Show($"{filePath} couldn't be loaded.\nSystem.Xml.XmlException: {e.Message}", $"{filePath} couldn't be loaded.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            this.comboBoxLanguage.Items.AddRange(languageNames.ToArray<String>());

            // Change the language, if "sLanguage=..." is set:
            String selectedLanguage = IniFiles.Instance.GetString(IniFile.Config, "Preferences", "sLanguage", CultureInfo.CurrentUICulture.Name);
            int languageIndex = Array.IndexOf(this.languageISOs.ToArray<String>(), selectedLanguage);
            this.comboBoxLanguage.SelectedIndex = languageIndex > -1 ? languageIndex : 0;
        }

        private String ToSafeString(String s)
        {
            return Regex.Replace(s, @"\r\n?|\n", "\\n").Replace("\t", "\\t").Replace("\\", "\\\\").Replace("\\\\n", "\\n").Replace("\\\\t", "\\t");
        }

        private String FromSafeString(String s)
        {
            return s.Replace("\\n", "\n").Replace("\\t", "\t").Replace("\\\\", "\\");
        }

        private int SerializeControlText(XElement element, ToolTip toolTip, Control control)
        {
            // Recursively add control elements to the XML file:
            int count = 0;
            foreach(Control subControl in control.Controls)
            {
                if (subControl.Name != null &&
                    subControl.Name.Length > 0 &&
                    subControl.Name != "labelConfigVersion" &&
                    subControl.Name != "labelAuthorName" &&
                    subControl.Name != "labelTranslationAuthor" &&
                    subControl.Name != "groupBoxWIP")
                {
                    // Get XElement name:
                    String type = "Element";
                    if (subControl.Name.StartsWith("label"))
                        type = "Label";
                    else if (subControl.Name.StartsWith("linkLabel"))
                        type = "Link";
                    else if (subControl.Name.StartsWith("num"))
                        type = "Number";
                    else if (subControl.Name.StartsWith("slider"))
                        type = "Slider";
                    else if (subControl.Name.StartsWith("checkBox"))
                        type = "Checkbox";
                    else if (subControl.Name.StartsWith("groupBox"))
                        type = "Group";
                    else if (subControl.Name.StartsWith("tabControl"))
                        type = "TabContainer";
                    else if (subControl.Name.StartsWith("tabPage"))
                        type = "Tab";
                    else if (subControl.Name.StartsWith("color"))
                        type = "ColorSquare";
                    else if (subControl.Name.StartsWith("radioButton"))
                        type = "Radiobutton";
                    else if (subControl.Name.StartsWith("button"))
                        type = "Button";
                    else if (subControl.Name.StartsWith("comboBox"))
                        type = "DropDownMenu";
                    else if (subControl.Name.StartsWith("progressBar"))
                        type = "ProgressBar";
                    else if (subControl.Name.StartsWith("menuStrip"))
                        type = "Menu";

                    XElement subElement = new XElement(type);
                    bool addSubElement = false;

                    // Add text:
                    if (subControl.Text != null &&
                        subControl.Text.Length > 0 &&
                        !subControl.Name.StartsWith("num") &&
                        !subControl.Name.StartsWith("comboBox") &&
                        !subControl.Name.StartsWith("checkedListBox") &&
                        !subControl.Name.StartsWith("progressBar") &&
                        !subControl.Name.StartsWith("slider") &&
                        !subControl.Name.StartsWith("color") &&
                        !subControl.Name.StartsWith("textBox") &&
                        !subControl.Name.StartsWith("menuStrip"))
                    {
                        subElement.Add(new XAttribute("text", ToSafeString(subControl.Text)));
                        addSubElement = true;
                    }

                    // Add tooltip text:
                    if (toolTip.GetToolTip(subControl) != null &&
                        toolTip.GetToolTip(subControl).Length > 0)
                    {
                        subElement.Add(new XElement("Tooltip", toolTip.GetToolTip(subControl)));
                        addSubElement = true;
                    }

                    // Add sub-elements:
                    int subCount = SerializeControlText(subElement, toolTip, subControl);
                    if (subControl.Name.StartsWith("menuStrip"))
                    {
                        foreach (ToolStripMenuItem menuItem in ((MenuStrip)subControl).Items)
                        {
                            XElement xmlToolStripItem = new XElement("Item",
                                new XAttribute("text", menuItem.Text),
                                new XAttribute("id", menuItem.Name));
                            subCount += SerializeMenuStripItems(xmlToolStripItem, menuItem.DropDownItems);
                            subElement.Add(xmlToolStripItem);
                        }
                    }
                    count += subCount;

                    // Add XElement to parent:
                    if (addSubElement || subCount > 0)
                    {
                        subElement.Add(new XAttribute("id", subControl.Name));
                        element.Add(subElement);
                        count++;
                    }
                }
            }
            return count;
        }

        private void DeserializeControlText(Dictionary<String, String> dictText, Dictionary<String, String> dictTooltip, Control control, ToolTip toolTip)
        {
            foreach (Control subControl in control.Controls)
            {
                if (subControl.Name != null &&
                    subControl.Name.Length > 0)
                {
                    if (dictText.ContainsKey(subControl.Name))
                        subControl.Text = FromSafeString(dictText[subControl.Name]);
                    if (dictTooltip.ContainsKey(subControl.Name))
                        toolTip.SetToolTip(subControl, dictTooltip[subControl.Name]);
                }
                DeserializeControlText(dictText, dictTooltip, subControl, toolTip);
            }
        }

        private void SerializeDropDownOptions(XElement parent, String id, IEnumerable<String> options)
        {
            XElement xmlDropDown = new XElement("Dropdown");
            xmlDropDown.Add(new XAttribute("id", id));
            foreach (String option in options)
                xmlDropDown.Add(new XElement("Option", option));
            parent.Add(xmlDropDown);
        }

        private int SerializeMenuStripItems(XElement parent, ToolStripItemCollection items)
        {
            int count = 0;
            foreach (ToolStripItem item in items)
            {
                XElement xmlToolStripItem = new XElement("Item",
                    new XAttribute("text", item.Text),
                    new XAttribute("id", item.Name));
                try
                {
                    if (((ToolStripMenuItem)item).DropDownItems.Count > 0)
                        count += SerializeMenuStripItems(xmlToolStripItem, ((ToolStripMenuItem)item).DropDownItems);
                }
                catch
                {
                    // Well shit
                }
                parent.Add(xmlToolStripItem);
                count++;
            }
            return count;
        }

        private Dictionary<String, String> DeserializeXMLDescendants(XElement xmlItems, Dictionary<String, String> dict)
        {
            foreach (XElement item in xmlItems.Descendants())
            {
                dict[item.Attribute("id").Value] = item.Attribute("text").Value;
            }
            return dict;
        }

        private void DeserializeMenuStrip(XElement xmlStrip, MenuStrip strip)
        {
            Dictionary<String, String> dict = DeserializeXMLDescendants(xmlStrip, new Dictionary<String, String>());
            DeserializeMenuStripItem(strip.Items, dict);
        }

        private void DeserializeMenuStripItem(ToolStripItemCollection items, Dictionary<String, String> dict)
        {
            List<ToolStripMenuItem> safeItems = new List<ToolStripMenuItem>();
            for (int i = 0; i < items.Count; i++)
                if (!items[i].Name.ToLower().Contains("separator"))
                    safeItems.Add((ToolStripMenuItem)items[i]);

            foreach (ToolStripMenuItem menuItem in safeItems)
            {
                if (dict.ContainsKey(menuItem.Name))
                    menuItem.Text = dict[menuItem.Name];

                DeserializeMenuStripItem(menuItem.DropDownItems, dict);
            }
        }

        private String[] DeserializeDropDownOptions(XElement dropdown)
        {
            List<String> options = new List<String>();
            foreach (XElement element in dropdown.Descendants("Option"))
            {
                options.Add(element.Value);
            }
            return options.ToArray<String>();
        }

        private void SetDropDownOptions(ComboBox comboBox, String[] elements)
        {
            int i = comboBox.SelectedIndex;
            comboBox.Items.Clear();
            comboBox.Items.AddRange(elements);
            comboBox.SelectedIndex = i;
        }

        private void GenerateEnglishXMLFile()
        {
            // Create document and root:
            XDocument xmlDoc = new XDocument();
            XElement xmlRoot = new XElement("Language");
            xmlRoot.Add(new XAttribute("name", "English (USA)"));
            xmlRoot.Add(new XAttribute("iso", "en-US"));
            xmlDoc.AddFirst(new XComment("\n     This file is auto-generated on program start.\n     Therefore any changes made to this file will be overriden.\n     You can use this as a template for your own translation, though.\n"));
            xmlDoc.Add(xmlRoot);

            // Serialize miscellaneous strings:
            XElement xmlStrings = new XElement("Strings");
            foreach (KeyValuePair<String, String> pair in Translation.localizedStrings)
                xmlStrings.Add(new XElement("String",
                    new XAttribute("text", pair.Value),
                    new XAttribute("id", pair.Key)));
            xmlRoot.Add(xmlStrings);

            // Create dropdowns:
            XElement xmlDropDowns = new XElement("Dropdowns");
            foreach (KeyValuePair<String, ComboBoxContainer> pair in this.comboBoxes)
                SerializeDropDownOptions(xmlDropDowns, pair.Key, pair.Value.Items);
            xmlRoot.Add(xmlDropDowns);

            // Create messageboxes:
            xmlRoot.Add(MsgBox.Serialize());

            // Serialize all control elements:
            XElement xmlForm1 = new XElement("Form1", new XAttribute("title", this.Text));
            XElement xmlFormMods = new XElement("FormMods", new XAttribute("title", this.formMods.Text));
            SerializeControlText(xmlForm1, this.toolTip, this);
            SerializeControlText(xmlFormMods, this.formMods.toolTip, this.formMods);
            xmlRoot.Add(xmlForm1);
            xmlRoot.Add(xmlFormMods);

            // Save it:
            xmlDoc.Save(Path.Combine(languageFolder, "en-US.xml"));
            //using (XmlTextWriter writer = new XmlTextWriter(Path.Combine(languageFolder, "en-US.xml"), new UTF8Encoding(false))) 
            //    xmlDoc.Save(writer); 
        }

        private void ChangeLanguage(string langFile)
        {
            // Load the XML:
            XDocument xmlDoc = XDocument.Load(langFile);
            if (xmlDoc.Element("Language") != null && xmlDoc.Element("Language").Attribute("iso") != null)
            {
                IniFiles.Instance.Set(IniFile.Config, "Preferences", "sLanguage", xmlDoc.Element("Language").Attribute("iso").Value);
            }
            else
            {
                MessageBox.Show("No 'iso' attribute found.", "Invalid XML language file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Change title
            XElement xmlForm1 = xmlDoc.Root.Element("Form1");
            if (xmlForm1 != null && xmlForm1.Attribute("title") != null)
                this.Text = xmlForm1.Attribute("title").Value;

            // Credit the author
            if (xmlDoc.Element("Language").Attribute("author") != null && xmlDoc.Element("Language").Attribute("author").Value.Length > 0)
            {
                this.labelTranslationBy.Visible = true;
                this.labelTranslationAuthor.Visible = true;
                this.labelTranslationAuthor.Text = xmlDoc.Element("Language").Attribute("author").Value;
            } else
            {
                this.labelTranslationAuthor.Text = "";
                this.labelTranslationAuthor.Visible = false;
                this.labelTranslationBy.Visible = false;
            }

            // Set options of dropdowns:
            XElement xmlDropDowns = xmlDoc.Root.Element("Dropdowns");
            if (xmlDropDowns != null)
            {
                foreach (XElement xmlDropDown in xmlDropDowns.Descendants("Dropdown"))
                {
                    String id = xmlDropDown.Attribute("id").Value;
                    if (this.comboBoxes.ContainsKey(id))
                    {
                        String[] items = DeserializeDropDownOptions(xmlDropDown);
                        SetDropDownOptions(this.comboBoxes[id].comboBox, items);
                    }
                }
            }

            // Messageboxes:
            MsgBox.Deserialize(xmlDoc.Root.Element("Messageboxes"));

            // Iterate the XML file and add elements to dictionaries:
            Dictionary<String, String> dictText = new Dictionary<String, String>();
            Dictionary<String, String> dictTooltip = new Dictionary<String, String>();
            foreach (XElement element in xmlDoc.Descendants())
            {
                if (element.Attribute("id") != null)
                {
                    if (element.Attribute("text") != null)
                        dictText[element.Attribute("id").Value] = element.Attribute("text").Value;
                    if (element.Element("Tooltip") != null)
                        dictTooltip[element.Attribute("id").Value] = element.Element("Tooltip").Value;
                }
            }

            // Deserialize MenuStrip
            // really quick&dirty, needs reworking:
            try
            {
                XElement xmlFormMods = xmlDoc.Root.Element("FormMods");
                if (xmlFormMods.Attribute("title") != null)
                    this.formMods.Text = xmlFormMods.Attribute("title").Value;
                if (xmlFormMods != null)
                {
                    XElement xmlMenu = xmlFormMods.Element("Menu");
                    if (xmlMenu != null)
                        DeserializeMenuStrip(xmlMenu, this.formMods.menuStrip1);
                }
            }
            catch
            {
                // Well shit
            }

            // Deserialize strings
            XElement strings = xmlDoc.Root.Element("Strings");
            if (strings != null)
            {
                foreach (XElement str in strings.Descendants())
                {
                    if (str.Attribute("id") != null && str.Attribute("text") != null)
                        Translation.localizedStrings[str.Attribute("id").Value] = str.Attribute("text").Value;
                }
            }

            // Use the dictionaries to set all elements:
            DeserializeControlText(dictText, dictTooltip, this, this.toolTip);
            DeserializeControlText(dictText, dictTooltip, this.formMods, this.formMods.toolTip);
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            String path = Path.Combine(
                this.languageFolder,
                this.languageISOs[this.comboBoxLanguage.SelectedIndex] + ".xml"
            );
            try
            {
                if (File.Exists(path))
                    ChangeLanguage(path);
                else
                    MessageBox.Show($"{path} does not exist.", $"Couldn't switch to {this.languageNames[this.comboBoxLanguage.SelectedIndex]}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (System.Xml.XmlException ex)
            {
                MessageBox.Show($"{path} couldn't be loaded.\nSystem.Xml.XmlException: {ex.Message}", $"Couldn't switch to {this.languageNames[this.comboBoxLanguage.SelectedIndex]}", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
