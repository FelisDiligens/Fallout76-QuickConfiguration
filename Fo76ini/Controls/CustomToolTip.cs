using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Controls
{
    // https://cboard.cprogramming.com/csharp-programming/119414-custom-tooltip.html
    // https://docs.microsoft.com/de-de/dotnet/api/system.windows.forms.tooltip.draw?view=windowsdesktop-6.0
    public class CustomToolTip : ToolTip
    {
        #region Designer Properties

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Font Font { get; set; }

        [DefaultValue(typeof(Color), "118, 118, 118")]
        public Color BorderColor { get; set; }

        [DefaultValue(typeof(Size), "10, 10")]
        public Size Padding { get; set; }

        #endregion

        private void InitializeComponent()
        {
            this.OwnerDraw = true;
            this.IsBalloon = false;
            this.Popup += new PopupEventHandler(this.OnPopup);
            this.Draw += new DrawToolTipEventHandler(this.OnDraw);

            this.AutoPopDelay = 20000;
            this.InitialDelay = 500;
            this.ReshowDelay = 100;
            this.ShowAlways = true;

            this.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.BackColor = Color.White;
            this.ForeColor = Color.Black;
            this.BorderColor = Color.FromArgb(118, 118, 118);
            this.Padding = new Size(10, 10);
        }

        public CustomToolTip() : base()
        {
            InitializeComponent();
        }

        public CustomToolTip(IContainer component) : base(component)
        {
            InitializeComponent();
        }

        private void OnPopup(object sender, PopupEventArgs e) // use this event to set the size of the tool tip
        {
            e.ToolTipSize = TextRenderer.MeasureText(this.GetToolTip(e.AssociatedControl), Font) + Padding + Padding;
        }

        private void OnDraw(object sender, DrawToolTipEventArgs e) // use this event to customise the tool tip
        {
            // Draw background:
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), e.Bounds);

            // Draw border:
            e.Graphics.DrawRectangle(
                new Pen(new SolidBrush(this.BorderColor), 1),
                new Rectangle(e.Bounds.X, e.Bounds.Y,
                e.Bounds.Width - 1, e.Bounds.Height - 1));

            // e.Graphics.DrawString doesn't render ℹ️ and ⚠️ correctly and displays a box next to the symbol.
            // TextRenderer.DrawText however functions properly.
            TextRenderer.DrawText(e.Graphics, e.ToolTipText, Font, new Point(e.Bounds.X + Padding.Width, e.Bounds.Y + Padding.Height), this.ForeColor);
        }
    }
}
