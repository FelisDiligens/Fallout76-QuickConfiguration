using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Fo76ini.Utilities
{
    public class TextboxWriter : TextWriter
    {
        public TextBox TextBox { get; set; }

        public override Encoding Encoding => Encoding.Default;
        public override string NewLine => "\r\n";

        public TextboxWriter(TextBox textBox)
        {
            TextBox = textBox;
        }

        // https://stackoverflow.com/a/17712686
        public override void Write(char value)
        {
            TextBox.Invoke(new Action(() => {
                TextBox.AppendText(value.ToString());
            }));
        }

        public override void Write(string value)
        {
            TextBox.Invoke(new Action(() => {
                TextBox.AppendText(value);
            }));
        }

        public override void WriteLine(string value)
        {
            TextBox.Invoke(new Action(() => {
                TextBox.AppendText(value + NewLine);
            }));
        }
    }
}
