using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;
using Fo76ini.Interface;
using Fo76ini.Tweaks;
using Fo76ini.Utilities;

namespace Fo76ini
{
    public partial class Localization
    {
        public static Dictionary<string, string> localizedStrings = new Dictionary<string, string>();
        public static readonly string LanguageFolder = Path.Combine(Shared.AppConfigFolder, "languages");

        /// <summary>
        /// Current locale
        /// </summary>
        public static string Locale = "en-US";

        /// <summary>
        /// Add your form to this list if you want it to get translated.
        /// </summary>
        public static List<LocalizedForm> LocalizedForms = new List<LocalizedForm>();

        private static List<Translation> translations = new List<Translation>();
        private static DropDown comboBoxTranslations;

        static Localization()
        {
            AddSharedStrings();
            AddSharedMessageBoxes();
        }

        /// <summary>
        /// Returns a localized string identified by 'str'.
        /// </summary>
        /// <param name="str">String identifier</param>
        /// <returns>Localized string</returns>
        public static string GetString(string str)
        {
            if (Localization.localizedStrings.ContainsKey(str))
                return Localization.localizedStrings[str];
            else
                return $"\"{str}\" NOT FOUND";
        }

        /// <summary>
        /// Assigns a dropdown menu to hold all languages.
        /// Also assigns an event handler 'SelectedIndexChanged' to automatically translate forms.
        /// </summary>
        /// <param name="comboBoxLanguage"></param>
        public static void AssignDropDown(ComboBox comboBoxLanguage)
        {
            Localization.comboBoxTranslations = new DropDown(comboBoxLanguage);
            comboBoxLanguage.SelectedIndexChanged += (object sender, EventArgs e) =>
            {
                Translation translation = Localization.GetTranslation();
                translation.Apply();

                IniFiles.Config.Set("Preferences", "sLanguage", translation.ISO);
                Localization.Locale = translation.ISO;

                if (translation.ISO != "en-US")
                    Localization.GenerateTemplate(translation);
            };
        }

        public static void LookupLanguages()
        {
            // Create 'languages' folder if not existing:
            Directory.CreateDirectory(LanguageFolder);

            // Look into the folder and add all language files to the dropdown menu:
            Localization.translations.Clear();
            Localization.comboBoxTranslations.Clear();
            foreach (string filePath in Directory.GetFiles(LanguageFolder))
            {
                try
                {
                    if (filePath.EndsWith(".xml") && !filePath.EndsWith(".template.xml"))
                    {
                        Translation translation = new Translation();
                        translation.Load(filePath);
                        Localization.translations.Add(translation);
                        Localization.comboBoxTranslations.Add(translation.Name);
                        //Localization.comboBoxTranslations.Add($"{translation.Name} [{translation.Version}]");
                    }
                }
                catch { } // TODO: Loading language failed...
            }

            // Set language:
            string selectedLanguageISO = IniFiles.Config.GetString("Preferences", "sLanguage", CultureInfo.CurrentUICulture.Name);
            int languageIndex = GetTranslationIndex(selectedLanguageISO);
            int enUSIndex = GetTranslationIndex("en-US");
            Localization.comboBoxTranslations.SelectedIndex = languageIndex > -1 ? languageIndex : enUSIndex;
            Localization.Locale = selectedLanguageISO;
        }

        public static void GenerateTemplate(Translation translation)
        {
            translation.Save(translation.ISO + ".template.xml", Shared.VERSION);
        }

        public static void GenerateDefaultTemplate()
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

        public static Translation GetTranslation(string iso)
        {
            foreach (Translation translation in Localization.translations)
                if (translation.ISO == iso)
                    return translation;
            return null;
        }

        public static int GetTranslationIndex(string iso)
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
            foreach (KeyValuePair<string, string> pair in Localization.localizedStrings)
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
        public string Name;
        public string ISO;
        public string Version;
        public string Author;
        private string fileName;
        private string filePath;

        /// <summary>
        /// Add event handler to reload UI elements after the program has been translated to another language.
        /// </summary>
        public static event TranslationEventHandler LanguageChanged;

        /// <summary>
        /// Add control elements to this list if you want them to not be translated.
        /// </summary>
        public static List<string> BlackList = new List<string>{};

        private Dictionary<string, string> dictText = new Dictionary<string, string>();
        private Dictionary<string, string> dictTooltip = new Dictionary<string, string>();

        /// <summary>
        /// Names of controls to ignore when setting tooltips
        /// </summary>
        private List<string> ignoreTooltipsOfTheseControls = new List<string>();

        public Translation()
        {
        }

        /*
         * Public stuff:
         */

        public void Load(string fileName)
        {
            this.fileName = fileName;
            this.filePath = Path.Combine(Localization.LanguageFolder, this.fileName);

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
            // Read *.xml file:
            XDocument xmlDoc = XDocument.Load(this.filePath);
            XElement xmlRoot = xmlDoc.Element("Language");

            ignoreTooltipsOfTheseControls = LinkedTweaks.GetListOfLinkedControlNames();

            // Translate each form individually:
            foreach (LocalizedForm form in Localization.LocalizedForms)
            {
                XElement xmlForm = xmlRoot.Element(form.Form.Name);

                // Ignore non-existing forms
                if (xmlForm == null)
                    continue; // throw new InvalidXmlException($"Couldn't find <{form.Form.Name}>");

                // Set title, if it exists:
                if (xmlForm.Attribute("title") != null)
                    form.Form.Text = xmlForm.Attribute("title").Value;

                // Forms:
                DeserializeDictionaries(xmlForm); // TODO: xmlRoot replaced with xmlForm. Good idea?
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

                // TODO: Generalize this. No outside references, plz:

                // TODO: Doesn't make sense to deserialize them multiple times:

                // Drop downs:
                XElement xmlDropDowns = xmlRoot.Element("Dropdowns");
                if (xmlDropDowns != null)
                    DropDown.DeserializeAll(xmlDropDowns);

                // Tweak descriptions:
                XElement xmlTweakDescriptions = xmlRoot.Element("TweakDescriptions");
                if (xmlTweakDescriptions != null)
                    LinkedTweaks.DeserializeTweakDescriptionList(xmlTweakDescriptions);
                if (form.ToolTip != null)
                    LinkedTweaks.SetToolTips(); // TODO: No need to call it per form anymore
            }

            // Call event handler:
            if (LanguageChanged != null)
            {
                TranslationEventArgs e = new TranslationEventArgs();
                e.HasAuthor = this.Author != "";
                //e.ActiveTranslation = this;
                LanguageChanged(this, e);
            }
        }

        private void DeserializeControl(XElement xmlRoot, Control subControl, ToolTip toolTip)
        {
            if (subControl.Name != null &&
                subControl.Name.Length > 0 &&
                !BlackList.Contains(subControl.Name))
            {
                // Set text:
                if (dictText.ContainsKey(subControl.Name))
                    subControl.Text = FromSafeString(dictText[subControl.Name]);

                // Set tooltip:
                if (dictTooltip.ContainsKey(subControl.Name) &&
                    !ignoreTooltipsOfTheseControls.Contains(subControl.Name))
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

        private void DeserializeStrip(Component item, Dictionary<string, string> dict)
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

        private void DeserializeStripItems(ToolStripItemCollection items, Dictionary<string, string> dict)
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

        public void Save(string fileName, string version)
        {
            string newFileName = fileName;
            string newFilePath = Path.Combine(Localization.LanguageFolder, newFileName);

            // Create document and root:
            XDocument xmlDoc = new XDocument();
            XElement xmlRoot = new XElement("Language");
            xmlRoot.Add(new XAttribute("name", this.Name));
            xmlRoot.Add(new XAttribute("iso", this.ISO));
            if (this.ISO != "en-US" && this.Author.Length > 0)
                xmlRoot.Add(new XAttribute("author", this.Author));

            if (this.ISO == "en-US")
                xmlDoc.AddFirst(
                    new XComment("\n" +
                    "     This file is auto-generated on program start.\n" +
                    "     Therefore any changes made to this file will be overwritten.\n" +
                    "     You can use this as a template for your own translation, though.\n" +
                    "\n" +
                    "     If you need help with translating, you can find a guide here:\n" +
                    "     https://github.com/FelisDiligens/Fallout76-QuickConfiguration/wiki/Translations\n"));
            else
                xmlDoc.AddFirst(
                    new XComment("\n" +
                    "     This is a template that contains some of the already translated elements.\n" +
                    "     You can rename it from \"*.template.xml\" to \"*.xml\" and translate the added elements.\n" +
                    "\n" +
                    "     If you need help with translating, you can find a guide here:\n" +
                    "     https://github.com/FelisDiligens/Fallout76-QuickConfiguration/wiki/Translations\n"));

            xmlRoot.Add(new XAttribute("version", version));
            xmlDoc.Add(xmlRoot);

            // Serialize external stuff:
            // TODO: Find a way to remove the references, plz:
            XElement xmlStrings = Localization.SerializeStrings();
            XElement xmlDropDowns = DropDown.SerializeAll();
            XElement xmlMsgBoxes = MsgBox.SerializeAll();
            XElement xmlDescriptions = LinkedTweaks.SerializeTweakDescriptionList();
            string separator = "".PadLeft(150, '*');
            xmlStrings.AddFirst(new XComment($"\n        Strings\n        {separator}\n        Basically little text snippets that can be used everywhere.\n    "));
            xmlDropDowns.AddFirst(new XComment($"\n        Dropdowns\n        {separator}\n        Make sure that the amount of options stays the same.\n    "));
            xmlMsgBoxes.AddFirst(new XComment($"\n        Message boxes\n        {separator}\n        The {"{0}"} is a placeholder, btw.\n    "));
            xmlDescriptions.AddFirst(new XComment($"\n        Descriptions\n        {separator}\n        These are the descriptions of almost all tweaks.\n        They appear in tool tips, when the user hovers over a tweak with the mouse cursor.\n    "));
            xmlRoot.Add(xmlStrings);
            xmlRoot.Add(xmlDropDowns);
            xmlRoot.Add(xmlMsgBoxes);
            xmlRoot.Add(xmlDescriptions);

            ignoreTooltipsOfTheseControls = LinkedTweaks.GetListOfLinkedControlNames();

            // Serialize all control elements:
            foreach (LocalizedForm form in Localization.LocalizedForms)
            {
                XElement xmlForm = new XElement(form.Form.Name, new XAttribute("title", form.Form.Text));
                xmlForm.AddFirst(new XComment($"\n        {form.Form.Name}\n        {separator}\n        {form.Form.Text}\n    "));
                SerializeControls(xmlForm, form.Form, form.ToolTip);
                foreach (Control control in form.SpecialControls)
                    SerializeControl(xmlForm, control, form.ToolTip);
                xmlRoot.Add(xmlForm);
            }

            // Save it:
            Directory.CreateDirectory(Localization.LanguageFolder);
            xmlDoc.Save(newFilePath);
        }

        private int SerializeControl(XElement xmlElement, Control subControl, ToolTip toolTip)
        {
            int count = 0;
            if (subControl.Name != null &&
                subControl.Name.Length > 0 &&
                !BlackList.Contains(subControl.Name) &&
                !subControl.Name.ToLower().Contains("separator"))
            {
                XElement subElement = new XElement(subControl.GetType().Name);
                bool addSubElement = false;

                // Add (hopefully) helpful comment?
                if (subControl is TabPage)
                    subElement.Add(new XComment($" ********** Tab \"{subControl.Text}\" ********** "));
                else if (subControl is GroupBox)
                    subElement.Add(new XComment($" Group \"{subControl.Text}\" "));
                else if (subControl is MenuStrip)
                    subElement.Add(new XComment($" Menu "));

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
                if (toolTip != null &&
                    toolTip.GetToolTip(subControl) != null &&
                    toolTip.GetToolTip(subControl).Length > 0 &&
                    !ignoreTooltipsOfTheseControls.Contains(subControl.Name))
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

        private string ToSafeString(string s)
        {
            return Regex.Replace(s, @"\r\n?|\n", "\\n").Replace("\t", "\\t").Replace("\\", "\\\\").Replace("\\\\n", "\\n").Replace("\\\\t", "\\t");
        }

        private string FromSafeString(string s)
        {
            return s.Replace("\\n", "\n").Replace("\\t", "\t").Replace("\\\\", "\\");
        }

        private Dictionary<string, string> GetXMLDescendantsDict(XElement xmlItems)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
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

    public delegate void TranslationEventHandler(object sender, TranslationEventArgs e);

    public class TranslationEventArgs : EventArgs
    {
        //public Translation ActiveTranslation;
        public bool HasAuthor;
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
