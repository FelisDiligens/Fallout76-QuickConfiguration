using System;
using System.Drawing;
using System.Windows.Forms;

namespace Fo76ini.Utilities
{
    public static class RichTextBoxExtensions
    {
        public static void AppendRichText(this RichTextBox box, string text, bool appendNewLine = false, Color? foreColor = null, Color? backColor = null, Font font = null)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            Font originalFont = box.SelectionFont;
            if (foreColor != null)
                box.SelectionColor = (Color)foreColor;
            if (backColor != null)
                box.SelectionBackColor = (Color)backColor;
            if (font != null)
                box.SelectionFont = font;
            box.AppendText(
                appendNewLine
                    ? $"{text}{Environment.NewLine}"
                    : text);
            box.SelectionColor = box.ForeColor;
            box.SelectionBackColor = box.BackColor;
            box.SelectionFont = originalFont;
        }
    }
}
