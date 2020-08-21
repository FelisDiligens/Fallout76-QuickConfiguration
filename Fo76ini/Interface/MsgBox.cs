using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Fo76ini
{
    public class MsgBox
    {
        public String Title;
        public String Text;
        private String id;

        public String ID
        {
            get { return id; }
        }

        public MsgBox (String id, String title, String text)
        {
            this.Title = title;
            this.Text = text;
            this.id = id;
        }
        
        private static Dictionary<String, MsgBox> msgBoxes = new Dictionary<String, MsgBox>();
        public static void Add(MsgBox msgBox)
        {
            MsgBox.msgBoxes[msgBox.id] = msgBox;
        }
        public static void Add(String id, String title, String text)
        {
            MsgBox.msgBoxes[id] = new MsgBox(id, title, text);
        }
        public static MsgBox Get(String key)
        {
            if (MsgBox.msgBoxes.ContainsKey(key))
                return MsgBox.msgBoxes[key];
            else
                return new MsgBox("notfound", $"-- Messagebox \"{key}\" not found --", $"If you read this, the programmer screwed up, lol.\nAvailable messageboxes:\n{String.Join("\n", MsgBox.msgBoxes.Keys.ToArray())}");
        }

        public MsgBox FormatTitle(params String[] values)
        {
            try
            {
                return new MsgBox(this.ID, String.Format(this.Title, values), this.Text);
            }
            catch (FormatException ex)
            {
                return this;
            }
        }

        public MsgBox FormatText(params String[] values)
        {
            try
            {
                return new MsgBox(this.ID, this.Title, String.Format(this.Text, values));
            }
            catch (FormatException ex)
            {
                return this;
            }
        }



        public static DialogResult ShowID(String id)
        {
            return MsgBox.Get(id).Show();
        }

        public static DialogResult ShowID(String id, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MsgBox.Get(id).Show(buttons, icon);
        }

        public static DialogResult ShowID(String id, MessageBoxButtons buttons)
        {
            return MsgBox.Get(id).Show(buttons);
        }

        public static DialogResult ShowID(String id, MessageBoxIcon icon)
        {
            return MsgBox.Get(id).Show(icon);
        }

        public DialogResult Show()
        {
            SystemSounds.Asterisk.Play();
            return MessageBox.Show(this.Text, this.Title);
        }

        public DialogResult Show(MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            SystemSounds.Asterisk.Play();
            return MessageBox.Show(this.Text, this.Title, buttons, icon);
        }

        public DialogResult Show(MessageBoxButtons buttons)
        {
            SystemSounds.Asterisk.Play();
            return MessageBox.Show(this.Text, this.Title, buttons);
        }

        public DialogResult Show(MessageBoxIcon icon)
        {
            SystemSounds.Asterisk.Play();
            return MessageBox.Show(this.Text, this.Title, MessageBoxButtons.OK, icon);
        }

        public void Popup()
        {
            Utils.CreatePopup(this.Title, this.Text).Popup();
            SystemSounds.Asterisk.Play();
        }

        public void Popup(MessageBoxIcon icon)
        {
            Utils.CreatePopup(this.Title, this.Text, icon).Popup();
            SystemSounds.Asterisk.Play();
        }

        public static XElement SerializeAll()
        {
            XElement xmlMessageBoxes = new XElement("Messageboxes");
            foreach (KeyValuePair<String, MsgBox> entry in MsgBox.msgBoxes)
                xmlMessageBoxes.Add(entry.Value.Serialize());
            return xmlMessageBoxes;
        }

        public XElement Serialize()
        {
            return new XElement("Messagebox",
                new XAttribute("title", this.Title),
                new XAttribute("id", this.ID),
                this.Text
            );
        }

        public static void Deserialize(XElement xmlMessageBoxes)
        {
            if (xmlMessageBoxes != null)
            {
                foreach (XElement xmlMessageBox in xmlMessageBoxes.Descendants("Messagebox"))
                {
                    MsgBox.Add(new MsgBox(
                        xmlMessageBox.Attribute("id").Value,
                        xmlMessageBox.Attribute("title").Value,
                        xmlMessageBox.Value
                    ));
                }
            }
        }
    }
}
