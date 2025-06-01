using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows.Forms;
using System.Xml.Linq;
using Fo76ini.Utilities;

namespace Fo76ini.Interface
{
    public class MsgBox
    {
        public string Title;
        public string Text;
        private string id;

        public static readonly string NotificationSoundFile = Path.Combine(Shared.AppInstallationFolder, @"notify.wav");
        public static readonly string ErrorSoundFile = Path.Combine(Shared.AppInstallationFolder, @"error.wav");
        private static SoundPlayer NotifySoundPlayer = new SoundPlayer(NotificationSoundFile);
        private static SoundPlayer ErrorSoundPlayer = new SoundPlayer(ErrorSoundFile);

        public static void PlayNotificationSound()
        {
            // Don't play sound, if disabled:
            if (!Configuration.PlayNotificationSounds)
                return;

            // Play alert.wav if available:
            if (File.Exists(NotificationSoundFile))
                NotifySoundPlayer.Play();

            // Fallback to system sound if alert.wav is not available:
            else
                SystemSounds.Asterisk.Play();
        }

        public static void PlayErrorSound()
        {
            // Don't play sound, if disabled:
            if (!Configuration.PlayNotificationSounds)
                return;

            // Play alert.wav if available:
            if (File.Exists(ErrorSoundFile))
                ErrorSoundPlayer.Play();

            // Fallback to system sound if alert.wav is not available:
            else
                SystemSounds.Hand.Play();
        }

        public string ID
        {
            get { return id; }
        }

        public MsgBox(string id, string title, string text)
        {
            this.Title = title;
            this.Text = text;
            this.id = id;
        }

        private static Dictionary<string, MsgBox> msgBoxes = new Dictionary<string, MsgBox>();
        public static void Add(MsgBox msgBox)
        {
            MsgBox.msgBoxes[msgBox.id] = msgBox;
        }
        public static void Add(string id, string title, string text)
        {
            MsgBox.msgBoxes[id] = new MsgBox(id, title, text);
        }
        public static MsgBox Get(string key)
        {
            if (MsgBox.msgBoxes.ContainsKey(key))
                return MsgBox.msgBoxes[key];
            else
                return new MsgBox("notfound", $"-- Messagebox \"{key}\" not found --", $"Couldn't find the messagebox with the id \"{key}\".\nIf you read this, the programmer forgot to add it."); // $"\nAvailable messageboxes:\n{string.Join("\n", MsgBox.msgBoxes.Keys.ToArray())}"
        }

        public MsgBox FormatTitle(params string[] values)
        {
            try
            {
                return new MsgBox(this.ID, string.Format(this.Title, values), this.Text);
            }
            catch (FormatException)
            {
                return this;
            }
        }

        public MsgBox FormatText(params string[] values)
        {
            try
            {
                return new MsgBox(this.ID, this.Title, string.Format(this.Text, values));
            }
            catch (FormatException)
            {
                return this;
            }
        }

        public MsgBox SetText(string text)
        {
            this.Text = text;
            return this;
        }



        public static DialogResult ShowID(string id)
        {
            return MsgBox.Get(id).Show();
        }

        public static DialogResult ShowID(string id, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MsgBox.Get(id).Show(buttons, icon);
        }

        public static DialogResult ShowID(string id, MessageBoxButtons buttons)
        {
            return MsgBox.Get(id).Show(buttons);
        }

        public static DialogResult ShowID(string id, MessageBoxIcon icon)
        {
            return MsgBox.Get(id).Show(icon);
        }

        public DialogResult Show()
        {
            //SystemSounds.Asterisk.Play();
            return MessageBox.Show(this.Text, this.Title);
        }

        public DialogResult Show(MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            //SystemSounds.Asterisk.Play();
            return MessageBox.Show(this.Text, this.Title, buttons, icon);
        }

        public DialogResult Show(MessageBoxButtons buttons)
        {
            //SystemSounds.Asterisk.Play();
            return MessageBox.Show(this.Text, this.Title, buttons);
        }

        public DialogResult Show(MessageBoxIcon icon)
        {
            //SystemSounds.Asterisk.Play();
            return MessageBox.Show(this.Text, this.Title, MessageBoxButtons.OK, icon);
        }

        public static DialogResult Show(string title, string text, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(text, title, buttons, icon);
        }

        public static DialogResult Show(string title, string text, MessageBoxButtons buttons)
        {
            return MessageBox.Show(text, title, buttons);
        }

        public static DialogResult Show(string title, string text, MessageBoxIcon icon)
        {
            return MessageBox.Show(text, title, MessageBoxButtons.OK, icon);
        }

        public static DialogResult Show(string title, string text)
        {
            return MessageBox.Show(text, title);
        }

        public static void Popup(string title, string text)
        {
            if (!Configuration.ShowNotifications)
                return;
            Utils.CreatePopup(title, text).Popup();
            PlayNotificationSound();
        }

        public static void Popup(string title, string text, MessageBoxIcon icon)
        {
            if (!Configuration.ShowNotifications)
                return;
            Utils.CreatePopup(title, text, icon).Popup();
            if (icon == MessageBoxIcon.Warning || icon == MessageBoxIcon.Error)
                PlayErrorSound();
            else
                PlayNotificationSound();
        }

        public void Popup()
        {
            MsgBox.Popup(this.Title, this.Text);
        }

        public void Popup(MessageBoxIcon icon)
        {
            MsgBox.Popup(this.Title, this.Text, icon);
        }

        public static XElement SerializeAll()
        {
            XElement xmlMessageBoxes = new XElement("Messageboxes");
            foreach (KeyValuePair<string, MsgBox> entry in MsgBox.msgBoxes)
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
