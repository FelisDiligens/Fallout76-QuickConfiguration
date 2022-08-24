using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Fo76ini.Controls
{
    /// <summary>
    /// This control holds multiple UserControls (Views).
    /// Only one view can be active at a time.
    /// </summary>
    public partial class ViewControl : UserControl
    {
        public List<UserControl> Views = new List<UserControl>();
        private UserControl selectedView = null;

        public event EventHandler SelectedIndexChanged;


        [DefaultValue(null)]
        public UserControl SelectedView
        {
            get
            {
                return selectedView;
            }
            set
            {
                if (!Views.Contains(value))
                    throw new ArgumentException("Cannot set SelectedView. List does not contain the given UserControl. Please add it with ViewControl.AddView before setting SelectedView.");
                
                OpenView(value);
            }
        }

        [DefaultValue(-1)]
        public int SelectedIndex
        {
            get
            {
                if (selectedView == null)
                    return -1;
                return Views.IndexOf(selectedView);
            }
            set
            {
                if (value < 0 || value >= Views.Count)
                    throw new IndexOutOfRangeException($"Cannot set SelectedIndex to {value}. Index out of range.");

                OpenView(Views[value]);
            }
        }

        public ViewControl()
        {
            InitializeComponent();
        }

        public void AddViews(IEnumerable<UserControl> views)
        {
            foreach (UserControl view in views)
                this.AddView(view);
        }

        public void AddView(UserControl view)
        {
            // Skip if already added:
            if (Views.Contains(view))
                return;

            // Add view to control:
            this.Controls.Add(view);
            view.Top = 0;
            view.Left = 0;
            view.Width = this.Width;
            view.Height = this.Height;
            view.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            view.Visible = false;

            // Add view to list:
            this.Views.Add(view);
        }

        private void CloseCurrentView()
        {
            if (selectedView != null)
            {
                this.selectedView.Visible = false;
                //this.Controls.Remove(selectedView);
                //selectedView.Dispose();
                selectedView = null;
            }
        }

        private void OpenView(UserControl view)
        {
            CloseCurrentView();

            // Make view visible:
            view.Visible = true;
            view.Enabled = true;

            // Set current view:
            this.selectedView = view;

            // Trigger event:
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(this, null);
        }
    }
}
