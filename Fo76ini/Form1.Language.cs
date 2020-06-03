using IniParser.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
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
        private String languageFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Fallout 76 Quick Configuration", "languages");
        private List<String> languageISOs;
        private List<String> languageNames;
        private bool englishXMLFileGenerated = false;

        private void LookupLanguages()
        {
            if (!Directory.Exists(languageFolder))
                Directory.CreateDirectory(languageFolder);

            // Generate a English XML file, if that wasn't done already:
            if (!englishXMLFileGenerated)
            {
                GenerateEnglishXMLFile();
                englishXMLFileGenerated = true;
            }

            this.languageISOs = new List<String> { "en-US" };
            this.languageNames = new List<String> { "English (USA)" };

            // Look into the folder and add all language files to the dropdown menu.
            foreach (string filePath in Directory.GetFiles(languageFolder))
            {
                if (filePath.EndsWith(".xml") && !filePath.EndsWith(".template.xml"))
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
                                if (lang.Attribute("iso").Value != "en-US" && !languageISOs.Contains(lang.Attribute("iso").Value))
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
            this.comboBoxLanguage.Items.Clear();
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
                    subControl.Name != "groupBoxWIP" &&
                    subControl.Name != "labelNewVersion" &&
                    subControl.Name != "labelModsDeploy")
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
                    else if (subControl.Name.StartsWith("toolStrip"))
                        type = "Tool";
                    else if (subControl.Name.StartsWith("listView"))
                        type = "ListView";

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
                        !subControl.Name.StartsWith("menuStrip") &&
                        !subControl.Name.StartsWith("toolStrip") &&
                        !subControl.Name.StartsWith("listView"))
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
                            XElement xmlMenuStripItem = new XElement("Item",
                                new XAttribute("text", menuItem.Text),
                                new XAttribute("id", menuItem.Name));
                            subCount += SerializeMenuStripItems(xmlMenuStripItem, menuItem.DropDownItems);
                            subElement.Add(xmlMenuStripItem);
                        }
                    }
                    if (subControl.Name.StartsWith("toolStrip"))
                    {
                        foreach (ToolStripItem toolItem in ((ToolStrip)subControl).Items)
                        {
                            if (toolItem.Name.StartsWith("toolStripButton"))
                            {
                                XElement xmlToolStripItem = new XElement("Button",
                                    new XAttribute("text", toolItem.Text),
                                    new XAttribute("id", toolItem.Name));
                                subElement.Add(xmlToolStripItem);
                                subCount++;
                            }
                        }
                    }
                    if (subControl.Name.StartsWith("listView"))
                    {
                        foreach (ColumnHeader col in this.formMods.listViewMods.Columns)
                        {
                            subElement.Add(new XElement("Column", col.Text));
                            subCount++;
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

        private void SerializeXMLFile(String name = null, String iso = null, String author = null, String fileName = null)
        {
            int index = this.comboBoxLanguage.SelectedIndex;
            if (name == null)
                name = this.languageNames[index];
            if (iso == null)
                iso = this.languageISOs[index];
            if (author == null)
                author = this.labelAuthorName.Text.Trim();
            if (fileName == null)
                fileName = iso + ".template.xml";

            // Create document and root:
            XDocument xmlDoc = new XDocument();
            XElement xmlRoot = new XElement("Language");
            xmlRoot.Add(new XAttribute("name", name));
            xmlRoot.Add(new XAttribute("iso", iso));
            if (iso != "en-US" && author.Length > 0)
                xmlRoot.Add(new XAttribute("author", author));
            if (iso == "en-US")
                xmlDoc.AddFirst(new XComment("\n     This file is auto-generated on program start.\n     Therefore any changes made to this file will be overriden.\n     You can use this as a template for your own translation, though.\n"));
            xmlRoot.Add(new XAttribute("version", VERSION));
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
            foreach (KeyValuePair<String, ComboBoxContainer> pair in ComboBoxContainer.Dict)
                SerializeDropDownOptions(xmlDropDowns, pair.Key, pair.Value.Items);
            xmlRoot.Add(xmlDropDowns);

            // Create messageboxes:
            xmlRoot.Add(MsgBox.Serialize());

            // Serialize all control elements:
            XElement xmlForm1 = new XElement("Form1", new XAttribute("title", this.Text));
            XElement xmlFormMods = new XElement("FormMods", new XAttribute("title", this.formMods.Text));
            XElement xmlFormModDetails = new XElement("FormModDetails");
            SerializeControlText(xmlForm1, this.toolTip, this);
            SerializeControlText(xmlFormMods, this.formMods.toolTip, this.formMods);
            SerializeControlText(xmlFormModDetails, this.formMods.formModDetails.toolTip, this.formMods.formModDetails);
            xmlRoot.Add(xmlForm1);
            xmlRoot.Add(xmlFormMods);
            xmlRoot.Add(xmlFormModDetails);

            // Save it:
            xmlDoc.Save(Path.Combine(languageFolder, fileName));
            //using (XmlTextWriter writer = new XmlTextWriter(Path.Combine(languageFolder, "en-US.xml"), new UTF8Encoding(false))) 
            //    xmlDoc.Save(writer); 
        }

        private void GenerateEnglishXMLFile()
        {
            SerializeXMLFile("English (USA)", "en-US", "", "en-US.xml");
            /*// Create document and root:
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
            //    xmlDoc.Save(writer); */
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

            // Check version
            String languageVersion = "1.0.0";
            if (xmlDoc.Element("Language").Attribute("version") != null)
            {
                languageVersion = xmlDoc.Element("Language").Attribute("version").Value;
            }
            int cmp = Utils.CompareVersions(VERSION, languageVersion);
            if (cmp > 0)
                this.labelOutdatedLanguage.Visible = true;
            else
                this.labelOutdatedLanguage.Visible = false;

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
                    if (ComboBoxContainer.ContainsKey(id))
                    {
                        String[] items = DeserializeDropDownOptions(xmlDropDown);
                        int i = ComboBoxContainer.Get(id).comboBox.SelectedIndex;
                        ComboBoxContainer.Get(id).SetRange(items);
                        //comboBox.Items.Clear();
                        //comboBox.Items.AddRange(elements);
                        ComboBoxContainer.Get(id).comboBox.SelectedIndex = i;
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

            // Deserialize ToolStrip
            // quick&dirty, again:
            try
            {
                XElement xmlFormMods = xmlDoc.Root.Element("FormMods");
                if (xmlFormMods != null)
                {
                    XElement xmlToolStrip = xmlFormMods.Descendants("Tool").FirstOrDefault();
                    if (xmlToolStrip != null)
                    {
                        foreach (ToolStripItem toolItem in this.formMods.toolStrip1.Items)
                        {
                            if (toolItem.Name.StartsWith("toolStripButton") && dictText.ContainsKey(toolItem.Name))
                            {
                                toolItem.Text = dictText[toolItem.Name];
                            }
                        }
                    }
                }
            }
            catch
            {
                // Well shit again
            }

            // Deserialize ListView
            // quick&dirty, once again:
            XElement xmlListViewColumns = xmlDoc.Root.Descendants("ListView").FirstOrDefault();
            if (xmlListViewColumns != null)
            {
                int i = 0;
                foreach (XElement xmlColumn in xmlListViewColumns.Descendants("Column"))
                {
                    this.formMods.listViewMods.Columns[i].Text = xmlColumn.Value;
                    i++;
                }
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
            DeserializeControlText(dictText, dictTooltip, this.formMods.formModDetails, this.formMods.formModDetails.toolTip);


            CheckVersion();
            this.formMods.UpdateUI();
            if (xmlDoc.Element("Language").Attribute("iso").Value != "en-US")
                SerializeXMLFile();
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

        private void buttonDownloadLanguages_Click(object sender, EventArgs e)
        {
            this.buttonDownloadLanguages.Enabled = false;
            // Download / update languages:
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.CachePolicy = new System.Net.Cache.RequestCachePolicy(System.Net.Cache.RequestCacheLevel.BypassCache);

                byte[] raw = wc.DownloadData("https://raw.githubusercontent.com/FelisDiligens/Fallout76-QuickConfiguration/master/Fo76ini/languages/list.txt");
                String encoded = Encoding.UTF8.GetString(raw).Trim();

                String[] list = encoded.Split('\n', ',');

                foreach (String file in list)
                {
                    wc.DownloadFile("https://raw.githubusercontent.com/FelisDiligens/Fallout76-QuickConfiguration/master/Fo76ini/languages/" + file, Path.Combine(languageFolder, file));
                }

                MsgBox.Get("downloadLanguagesFinished").FormatText(String.Join(", ", list)).Popup(MessageBoxIcon.Information);
            }
            catch (WebException ex)
            {
                MsgBox.Get("downloadLanguagesFailed").FormatText(ex.ToString()).Popup(MessageBoxIcon.Error);
            }
            catch
            {
                MsgBox.Get("downloadLanguagesFailed").FormatText("Unknown error").Popup(MessageBoxIcon.Error);
            }
            this.buttonDownloadLanguages.Enabled = true;
            LookupLanguages();
        }
    }
}
