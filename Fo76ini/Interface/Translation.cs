using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Fo76ini
{
    public partial class Localization
    {
        public static Dictionary<String, String> localizedStrings = new Dictionary<String, String>();
        public static String languageFolder = Path.Combine(Shared.AppConfigFolder, "languages");
        private static List<Translation> translations = new List<Translation>();
        private static DropDown comboBoxTranslations;

        public static List<LocalizedForm> LocalizedForms = new List<LocalizedForm>();

        public static String locale = "en-US";

        static Localization()
        {
            AddSharedStrings();
            AddSharedMessageBoxes();
        }

        public static String GetString(String str)
        {
            return Localization.localizedStrings[str];
        }

        public static void AssignDropBox(ComboBox comboBoxLanguage)
        {
            Localization.comboBoxTranslations = new DropDown(comboBoxLanguage);
        }

        public static void LookupLanguages()
        {
            Form1.logFile.WriteLine("[Localization]\tLooking up languages...");

            // Create 'languages' folder:
            if (!Directory.Exists(languageFolder))
                Directory.CreateDirectory(languageFolder);

            // Look into the folder and add all language files to the dropdown menu:
            Localization.translations.Clear();
            Localization.comboBoxTranslations.Clear();
            foreach (string filePath in Directory.GetFiles(languageFolder))
            {
                if (filePath.EndsWith(".xml") && !filePath.EndsWith(".template.xml"))
                {
                    Translation translation = new Translation();
                    translation.Load(filePath);
                    Localization.translations.Add(translation);
                    Localization.comboBoxTranslations.Add(translation.Name);
                    Form1.logFile.WriteLine($"[Localization]\tAdded language to list: {translation.Name} ({filePath})");
                    //Localization.comboBoxTranslations.Add($"{translation.Name} [{translation.Version}]");
                }
            }

            // Set language:
            String selectedLanguageISO = IniFiles.Instance.GetString(IniFile.Config, "Preferences", "sLanguage", CultureInfo.CurrentUICulture.Name);
            int languageIndex = GetTranslationIndex(selectedLanguageISO);
            int enUSIndex = GetTranslationIndex("en-US");
            Localization.comboBoxTranslations.SelectedIndex = languageIndex > -1 ? languageIndex : enUSIndex;
            Localization.locale = selectedLanguageISO;
        }

        public static void GenerateTemplate(Translation translation)
        {
            translation.Save(translation.ISO + ".template.xml", Shared.VERSION);
        }

        public static void GenerateTemplate()
        {
            Translation english = new Translation();
            english.Name = "English (USA)";
            english.ISO = "en-US";
            english.Author = "datasnake";
            english.Version = Shared.VERSION;
            english.Save("en-US.xml", Shared.VERSION);
        }

        public static Translation GetTranslation()
        {
            return translations[comboBoxTranslations.SelectedIndex];
        }

        public static Translation GetTranslation(String iso)
        {
            foreach (Translation translation in Localization.translations)
                if (translation.ISO == iso)
                    return translation;
            return null;
        }

        public static int GetTranslationIndex(String iso)
        {
            int index = 0;
            foreach (Translation translation in Localization.translations)
            {
                if (translation.ISO == iso)
                    return index;
                index++;
            }
            return -1;
        }

        public static XElement SerializeStrings()
        {
            XElement xmlStrings = new XElement("Strings");
            foreach (KeyValuePair<String, String> pair in Localization.localizedStrings)
                xmlStrings.Add(new XElement("String",
                    new XAttribute("text", pair.Value),
                    new XAttribute("id", pair.Key)));
            return xmlStrings;
        }

        public static void DeserializeStrings(XElement strings)
        {
            foreach (XElement str in strings.Descendants("String"))
            {
                if (str.Attribute("id") != null && str.Attribute("text") != null)
                    Localization.localizedStrings[str.Attribute("id").Value] = str.Attribute("text").Value;
            }
        }
    }

    public class Translation
    {
        public String Name;
        public String ISO;
        public String Version;
        public String Author;
        private String fileName;
        private String filePath;

        private Dictionary<String, String> dictText = new Dictionary<String, String>();
        private Dictionary<String, String> dictTooltip = new Dictionary<String, String>();

        private static List<String> blackList = new List<String>
        {
            "labelConfigVersion",
            "labelAuthorName",
            "labelTranslationAuthor",
            "groupBoxWIP",
            "labelNewVersion",
            "labelModsDeploy",
            "labelGameEdition"
        };

        public Translation()
        {
        }

        /*
         * Public stuff:
         */

        public void Load(String fileName)
        {
            Form1.logFile.WriteLine($"[Translation]\tReading {fileName}");

            this.fileName = fileName;
            this.filePath = Path.Combine(Localization.languageFolder, this.fileName);

            /*
             *  Read *.xml file:
             */

            // Get <Language> root:
            XDocument xmlDoc = XDocument.Load(filePath);
            if (xmlDoc.Element("Language") == null)
                throw new InvalidXmlException("Root has to be <Language>");
            XElement lang = xmlDoc.Element("Language");

            // Get name, iso, and version attribute:
            if (lang.Attribute("name") == null ||
                    lang.Attribute("iso") == null ||
                    lang.Attribute("version") == null)
                throw new InvalidXmlException($"'{fileName}': Root element does not have 'name', 'iso', or 'version' attribute.");

            // Fill information:
            this.ISO = lang.Attribute("iso").Value;
            this.Name = lang.Attribute("name").Value;
            this.Version = lang.Attribute("version").Value;
            if (lang.Attribute("author") != null)
                this.Author = lang.Attribute("author").Value;
            else
                this.Author = "";
        }

        public bool IsOutdated()
        {
            int cmp = Utils.CompareVersions(Shared.VERSION, this.Version);
            return cmp > 0;
        }



        /*
         * Deserialization:
         */

        public void Apply()
        {
            Form1.logFile.WriteLine($"[Translation]\tApplying {this.Name}");

            // Read *.xml file:
            XDocument xmlDoc = XDocument.Load(this.filePath);
            XElement xmlRoot = xmlDoc.Element("Language");

            foreach (LocalizedForm form in Localization.LocalizedForms)
            {
                XElement xmlForm = xmlRoot.Element(form.Form.Name);
                if (xmlForm == null)
                    throw new InvalidXmlException($"Couldn't find <{form.Form.Name}>");

                // Set title, if it exists:
                if (xmlForm.Attribute("title") != null)
                    form.Form.Text = xmlForm.Attribute("title").Value;

                // Forms:
                DeserializeDictionaries(xmlRoot);
                DeserializeControls(xmlForm, form.Form, form.ToolTip);
                foreach (Control subControl in form.SpecialControls)
                    DeserializeControl(xmlForm, subControl, form.ToolTip);

                // Message boxes:
                XElement xmlMsgBox = xmlRoot.Element("Messageboxes");
                if (xmlMsgBox != null)
                    MsgBox.Deserialize(xmlMsgBox);

                // Strings:
                XElement xmlStrings = xmlRoot.Element("Strings");
                if (xmlStrings != null)
                    Localization.DeserializeStrings(xmlStrings);

                // Drop downs:
                XElement xmlDropDowns = xmlRoot.Element("Dropdowns");
                if (xmlDropDowns != null)
                    DropDown.DeserializeAll(xmlDropDowns);
            }
        }

        private void DeserializeControl(XElement xmlRoot, Control subControl, ToolTip toolTip)
        {
            if (subControl.Name != null &&
                subControl.Name.Length > 0)
            {
                // Set text:
                if (dictText.ContainsKey(subControl.Name))
                    subControl.Text = FromSafeString(dictText[subControl.Name]);

                // Set tooltip:
                if (dictTooltip.ContainsKey(subControl.Name))
                    toolTip.SetToolTip(subControl, dictTooltip[subControl.Name]);


                /*
                 * Set stuff depending on the type of the control:
                 */

                // Search through the *.xml file and find the right item:
                foreach (XElement xmlControl in xmlRoot.Descendants())
                {
                    if (xmlControl.Attribute("id") != null && xmlControl.Attribute("id").Value == subControl.Name)
                    {
                        // Set stuff:
                        if (subControl is MenuStrip ||
                            subControl is ToolStrip ||
                            subControl is ContextMenuStrip)
                            DeserializeStrip(subControl, GetXMLDescendantsDict(xmlControl));
                        else if (subControl is ListView)
                            DeserializeListView((ListView)subControl, xmlControl);
                        break;
                    }
                }
            }
        }

        private void DeserializeControls(XElement xmlRoot, Control control, ToolTip toolTip)
        {
            // Go through every control:
            foreach (Control subControl in control.Controls)
            {
                DeserializeControl(xmlRoot, subControl, toolTip);

                // Recursive, yay!
                DeserializeControls(xmlRoot, subControl, toolTip);
            }
        }

        private void DeserializeStrip(Component item, Dictionary<String, String> dict)
        {
            if (item is MenuStrip)
                DeserializeStripItems(((MenuStrip)item).Items, dict);
            else if (item is ToolStrip)
                DeserializeStripItems(((ToolStrip)item).Items, dict);
            else if (item is ContextMenuStrip)
                DeserializeStripItems(((ContextMenuStrip)item).Items, dict);
            else if (item is ToolStripSplitButton)
                DeserializeStripItems(((ToolStripSplitButton)item).DropDownItems, dict);
            else if (item is ToolStripDropDownButton)
                DeserializeStripItems(((ToolStripDropDownButton)item).DropDownItems, dict);
        }

        private void DeserializeStripItems(ToolStripItemCollection items, Dictionary<String, String> dict)
        {
            foreach (ToolStripItem item in items)
            {
                if (dict.ContainsKey(item.Name))
                    item.Text = dict[item.Name];

                if (item is ToolStripMenuItem)
                    DeserializeStripItems(((ToolStripMenuItem)item).DropDownItems, dict);
                else if (item is ToolStripSplitButton)
                    DeserializeStrip((ToolStripSplitButton)item, dict);
                else if (item is ToolStripDropDownButton)
                    DeserializeStrip((ToolStripDropDownButton)item, dict);
            }
        }

        private void DeserializeListView(ListView listView, XElement xmlListView)
        {
            var columns = xmlListView.Descendants("Column");

            if (listView.Columns.Count != columns.Count())
            {
                Console.WriteLine($"Invalid column count of '{listView.Name}'. Expected {listView.Columns.Count}, got {columns.Count()}.");
                return;
                //throw new InvalidXmlException($"Invalid column count of '{listView.Name}'. Expected {listView.Columns.Count}, got {columns.Count()}.");
            }

            int i = 0;
            foreach (XElement xmlColumn in columns)
            {
                listView.Columns[i].Text = xmlColumn.Value;
                i++;
            }
        }

        private void DeserializeDictionaries(XElement xmlRoot)
        {
            dictText.Clear();
            dictTooltip.Clear();

            // Iterate the XML file and add elements to dictionaries:
            /* e.g.:
               <Button id="buttonApply" text="Apply">
                  <Tooltip>Applies something, duh.</Tooltip>
               </Button>
             */
            foreach (XElement element in xmlRoot.Descendants())
            {
                if (element.Attribute("id") != null)
                {
                    if (element.Attribute("text") != null)
                        dictText[element.Attribute("id").Value] = element.Attribute("text").Value;
                    if (element.Element("Tooltip") != null)
                        dictTooltip[element.Attribute("id").Value] = element.Element("Tooltip").Value;
                }
            }
        }



        /*
         * Serialization:
         */

        public void Save(String fileName, String version)
        {
            String newFileName = fileName;
            String newFilePath = Path.Combine(Localization.languageFolder, newFileName);

            // Create document and root:
            XDocument xmlDoc = new XDocument();
            XElement xmlRoot = new XElement("Language");
            xmlRoot.Add(new XAttribute("name", this.Name));
            xmlRoot.Add(new XAttribute("iso", this.ISO));
            if (this.ISO != "en-US" && this.Author.Length > 0)
                xmlRoot.Add(new XAttribute("author", this.Author));
            if (this.ISO == "en-US")
                xmlDoc.AddFirst(new XComment("\n     This file is auto-generated on program start.\n     Therefore any changes made to this file will be overriden.\n     You can use this as a template for your own translation, though.\n"));
            xmlRoot.Add(new XAttribute("version", version));
            xmlDoc.Add(xmlRoot);

            // Serialize external stuff:
            xmlRoot.Add(Localization.SerializeStrings());
            xmlRoot.Add(DropDown.SerializeAll());
            xmlRoot.Add(MsgBox.SerializeAll());

            // Serialize all control elements:
            foreach (LocalizedForm form in Localization.LocalizedForms)
            {
                XElement xmlForm = new XElement(form.Form.Name, new XAttribute("title", form.Form.Text));
                SerializeControls(xmlForm, form.Form, form.ToolTip);
                foreach (Control control in form.SpecialControls)
                    SerializeControl(xmlForm, control, form.ToolTip);
                xmlRoot.Add(xmlForm);
            }

            // Save it:
            if (!Directory.Exists(Localization.languageFolder))
                Directory.CreateDirectory(Localization.languageFolder);

            xmlDoc.Save(newFilePath);
        }

        private int SerializeControl(XElement xmlElement, Control subControl, ToolTip toolTip)
        {
            int count = 0;
            if (subControl.Name != null &&
                subControl.Name.Length > 0 &&
                !blackList.Contains(subControl.Name) &&
                !subControl.Name.ToLower().Contains("separator"))
            {
                XElement subElement = new XElement(subControl.GetType().Name);
                bool addSubElement = false;

                // Add text:
                if (subControl.Text != null &&
                    subControl.Text.Length > 0 &&
                    !(subControl is NumericUpDown) &&
                    !(subControl is ComboBox) &&
                    !(subControl is CheckedListBox) &&
                    !(subControl is ProgressBar) &&
                    !(subControl is TrackBar) &&
                    !(subControl is PictureBox) &&
                    !(subControl is TextBox) &&
                    !(subControl is MenuStrip) &&
                    !(subControl is ToolStrip) &&
                    !(subControl is ContextMenuStrip) &&
                    !(subControl is ListView))
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
                int subCount = SerializeControls(subElement, subControl, toolTip);

                if (subControl is MenuStrip ||
                    subControl is ToolStrip ||
                    subControl is ContextMenuStrip)
                {
                    subCount += SerializeStripItems(subElement, subControl);
                }

                if (subControl is ListView)
                {
                    foreach (ColumnHeader col in ((ListView)subControl).Columns)
                    {
                        subElement.Add(new XElement("Column", col.Text));
                        subCount++;
                    }
                }

                // Add XElement to parent:
                if (addSubElement || subCount > 0)
                {
                    subElement.Add(new XAttribute("id", subControl.Name));
                    xmlElement.Add(subElement);
                    count++;
                }
            }
            return count;
        }

        private int SerializeControls(XElement xmlElement, Control control, ToolTip toolTip)
        {
            // Recursively add control elements to the XML file:
            int count = 0;
            foreach (Control subControl in control.Controls)
            {
                count += SerializeControl(xmlElement, subControl, toolTip);
            }
            return count;
        }

        private int SerializeStripItems(XElement parent, Component stripItem)
        {
            ToolStripItemCollection items = null;
            if (stripItem is ToolStripMenuItem)
                items = ((ToolStripMenuItem)stripItem).DropDownItems;
            else if (stripItem is ToolStripSplitButton)
                items = ((ToolStripSplitButton)stripItem).DropDownItems;
            else if (stripItem is ToolStripDropDownButton)
                items = ((ToolStripDropDownButton)stripItem).DropDownItems;
            else if (stripItem is ToolStrip)
                items = ((ToolStrip)stripItem).Items;
            else if (stripItem is MenuStrip)
                items = ((ToolStrip)stripItem).Items;
            else if (stripItem is ContextMenuStrip)
                items = ((ContextMenuStrip)stripItem).Items;
            else
                return 0;

            int count = 0;
            foreach (ToolStripItem item in items)
            {
                if (item is ToolStripSeparator)
                    continue;

                XElement xmlToolStripItem = new XElement(item.GetType().Name,
                    new XAttribute("text", item.Text),
                    new XAttribute("id", item.Name));
                
                count += SerializeStripItems(xmlToolStripItem, item);
                count++;
                parent.Add(xmlToolStripItem);
            }
            return count;
        }



        /*
         * Other stuff:
         */

        private String ToSafeString(String s)
        {
            return Regex.Replace(s, @"\r\n?|\n", "\\n").Replace("\t", "\\t").Replace("\\", "\\\\").Replace("\\\\n", "\\n").Replace("\\\\t", "\\t");
        }

        private String FromSafeString(String s)
        {
            return s.Replace("\\n", "\n").Replace("\\t", "\t").Replace("\\\\", "\\");
        }

        private Dictionary<String, String> GetXMLDescendantsDict(XElement xmlItems)
        {
            Dictionary<String, String> dict = new Dictionary<String, String>();
            foreach (XElement item in xmlItems.Descendants())
            {
                dict[item.Attribute("id").Value] = item.Attribute("text").Value;
            }
            return dict;
        }

        // https://stackoverflow.com/questions/17171914/find-components-on-a-windows-form-c-sharp-not-controls
        private IEnumerable<Component> EnumerateComponents()
        {
            return from field in GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                   where typeof(Component).IsAssignableFrom(field.FieldType)
                   let component = (Component)field.GetValue(this)
                   where component != null
                   select component;
        }
    }

    public class LocalizedForm
    {
        public Form Form;
        public ToolTip ToolTip;
        public List<Control> SpecialControls = new List<Control>();

        public LocalizedForm(Form form, ToolTip toolTip)
        {
            this.Form = form;
            this.ToolTip = toolTip;
        }
    }
}
