using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Fo76ini.Interface
{
    public struct DropDown
    {
        public ComboBox comboBox;
        private List<string> items;

        public static Dictionary<string, DropDown> Dict = new Dictionary<string, DropDown>();

        public static void Add(string key, DropDown comboBox)
        {
            Dict.Add(key, comboBox);
        }

        public static DropDown Get(string key)
        {
            return Dict[key];
        }

        public static bool ContainsKey(string key)
        {
            return Dict.ContainsKey(key);
        }

        public DropDown(ComboBox comboBox)
        {
            this.comboBox = comboBox;
            this.items = new List<string>();
            foreach (object item in comboBox.Items)
                this.items.Add((string)item);
        }

        public DropDown(ComboBox comboBox, List<string> items)
        {
            this.comboBox = comboBox;
            this.items = items;
            this.comboBox.Items.Clear();
            this.comboBox.Items.AddRange(this.items.ToArray());
        }

        public DropDown(ComboBox comboBox, string[] items)
        {
            this.comboBox = comboBox;
            this.items = new List<string>();
            foreach (string item in items)
                this.items.Add(item);
            this.comboBox.Items.Clear();
            this.comboBox.Items.AddRange(this.items.ToArray());
        }

        public void Add(string item)
        {
            this.comboBox.Items.Add(item);
            this.items.Add(item);
        }

        public void AddRange(string[] items)
        {
            this.comboBox.Items.AddRange(items);
            foreach (string item in items)
                this.items.Add(item);
        }

        public bool Contains(string item)
        {
            return this.items.Contains(item);
        }

        public int FindIndex(string match)
        {
            return this.items.FindIndex(x => x == match);
        }

        public int FindIndex(Predicate<string> match)
        {
            return this.items.FindIndex(match);
        }

        public void Clear()
        {
            this.comboBox.Items.Clear();
            this.items.Clear();
        }

        public void SetRange(string[] items)
        {
            this.Clear();
            this.comboBox.Items.AddRange(items);
            foreach (string item in items)
                this.items.Add(item);
        }

        public void ReplaceRange(string[] items)
        {
            int selectedIndex = this.comboBox.SelectedIndex;
            this.SetRange(items);
            this.comboBox.SelectedIndex = selectedIndex;
        }

        public static XElement SerializeAll()
        {
            XElement xmlDropDowns = new XElement("Dropdowns");
            foreach (KeyValuePair<string, DropDown> pair in DropDown.Dict)
                xmlDropDowns.Add(pair.Value.Serialize(pair.Key));
            return xmlDropDowns;
        }

        public XElement Serialize(string id)
        {
            XElement xmlDropDown = new XElement("Dropdown");
            xmlDropDown.Add(new XAttribute("id", id));
            foreach (string option in this.Items)
                xmlDropDown.Add(new XElement("Option", option));
            return xmlDropDown;
        }

        public static void DeserializeAll(XElement xmlDropDowns)
        {
            /*
             <Dropdowns>
                 ...
             </Dropdowns>
             */

            // Go through every dropdown
            foreach (XElement xmlDropDown in xmlDropDowns.Descendants("Dropdown"))
            {
                // Get id:
                string id = xmlDropDown.Attribute("id").Value;

                // If such a combobox exists, deserialize:
                if (DropDown.ContainsKey(id))
                    DropDown.Get(id).Deserialize(xmlDropDown);
            }
        }

        public void Deserialize(XElement xmlDropDown)
        {
            /*
               <Dropdown id="Foobar">
                  <Option>Foo</Option>
                  <Option>Bar</Option>
                  <Option>Baz</Option>
                  ...
               </Dropdown>
             */
            List<string> options = new List<string>();
            foreach (XElement element in xmlDropDown.Descendants("Option"))
                options.Add(element.Value);

            if (options.Count() != this.Items.Count())
            {
                Console.WriteLine($"Invalid dropdown option count of '{xmlDropDown.Attribute("id").Value}'. Expected {this.Items.Count()}, got {options.Count()}.");
                return;
            }

            this.ReplaceRange(options.ToArray<string>());
        }

        public List<string> Items
        {
            get { return this.items; }
            set
            {
                this.items = value;
                this.comboBox.Items.Clear();
                this.comboBox.Items.AddRange(value.ToArray());
            }
        }

        public int SelectedIndex
        {
            get { return this.comboBox.SelectedIndex; }
            set { this.comboBox.SelectedIndex = value; }
        }

        public string SelectedItem
        {
            get { return this.items[this.comboBox.SelectedIndex]; }
        }
    }
}
