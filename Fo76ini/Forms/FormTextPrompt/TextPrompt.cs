using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Forms.FormTextPrompt
{
    public partial class TextPrompt : Form
    {
        Action<string> CallbackOK = null;
        Action CallbackCancel = null;

        public TextPrompt()
        {
            InitializeComponent();
            this.textBox.KeyDown += textBox_KeyDown;
        }

        public static void Prompt(String text, Action<string> callbackOk, Action callbackCancel = null)
        {
            Prompt(text, "", callbackOk, callbackCancel);
        }

        public static void Prompt(String text, String value, Action<string> callbackOk, Action callbackCancel = null)
        {
            TextPrompt prompt = new TextPrompt();
            prompt.CallbackOK = callbackOk;
            prompt.CallbackCancel = callbackCancel;
            prompt.Text = text;
            prompt.label.Text = text;
            prompt.textBox.Text = value;
            prompt.ShowDialog();
            prompt.Focus();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            CallbackOK?.Invoke(this.textBox.Text);
            this.Close();
            this.Dispose();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            CallbackCancel?.Invoke();
            this.Close();
            this.Dispose();
        }

        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    buttonOK_Click(sender, e);
                    break;
                case Keys.Escape:
                    buttonCancel_Click(sender, e);
                    break;
            }
        }
    }
}
