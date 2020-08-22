using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Fo76ini
{
    public struct DropDown
    {
        public ComboBox comboBox;
        private List<String> items;

        public static Dictionary<String, DropDown> Dict = new Dictionary<String, DropDown>();

        public static void Add(String key, DropDown comboBox)
        {
            Dict.Add(key, comboBox);
        }

        public static DropDown Get(String key)
        {
            return Dict[key];
        }

        public static bool ContainsKey(String key)
        {
            return Dict.ContainsKey(key);
        }

        public DropDown(ComboBox comboBox)
        {
            this.comboBox = comboBox;
            this.items = new List<String>();
            foreach (object item in comboBox.Items)
                this.items.Add((String)item);
        }

        public DropDown(ComboBox comboBox, List<String> items)
        {
            this.comboBox = comboBox;
            this.items = items;
            this.comboBox.Items.Clear();
            this.comboBox.Items.AddRange(this.items.ToArray());
        }

        public DropDown(ComboBox comboBox, String[] items)
        {
            this.comboBox = comboBox;
            this.items = new List<String>();
            foreach (String item in items)
                this.items.Add(item);
            this.comboBox.Items.Clear();
            this.comboBox.Items.AddRange(this.items.ToArray());
        }

        public void Add(String item)
        {
            this.comboBox.Items.Add(item);
            this.items.Add(item);
        }

        public void AddRange(String[] items)
        {
            this.comboBox.Items.AddRange(items);
            foreach (String item in items)
                this.items.Add(item);
        }

        public bool Contains(String item)
        {
            return this.items.Contains(item);
        }

        public int FindIndex(String match)
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

        public void SetRange(String[] items)
        {
            this.Clear();
            this.comboBox.Items.AddRange(items);
            foreach (String item in items)
                this.items.Add(item);
        }

        public void ReplaceRange(String[] items)
        {
            int selectedIndex = this.comboBox.SelectedIndex;
            this.SetRange(items);
            this.comboBox.SelectedIndex = selectedIndex;
        }

        public static XElement SerializeAll()
        {
            XElement xmlDropDowns = new XElement("Dropdowns");
            foreach (KeyValuePair<String, DropDown> pair in DropDown.Dict)
                xmlDropDowns.Add(pair.Value.Serialize(pair.Key));
            return xmlDropDowns;
        }

        public XElement Serialize(String id)
        {
            XElement xmlDropDown = new XElement("Dropdown");
            xmlDropDown.Add(new XAttribute("id", id));
            foreach (String option in this.Items)
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
                String id = xmlDropDown.Attribute("id").Value;

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
            List<String> options = new List<String>();
            foreach (XElement element in xmlDropDown.Descendants("Option"))
                options.Add(element.Value);

            if (options.Count() != this.Items.Count())
            {
                Console.WriteLine($"Invalid dropdown option count of '{xmlDropDown.Attribute("id").Value}'. Expected {this.Items.Count()}, got {options.Count()}.");
                return;
            }

            this.ReplaceRange(options.ToArray<String>());
        }

        public List<String> Items
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

        public String SelectedItem
        {
            get { return this.items[this.comboBox.SelectedIndex]; }
        }
    }
}
