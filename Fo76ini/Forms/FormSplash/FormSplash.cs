using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Forms.FormSplash
{
    // https://stackoverflow.com/questions/15836027/c-sharp-winform-loading-screen/15836105#15836105
    public partial class FormSplash : Form
    {
        // Delegate for cross thread call to close
        private delegate void CloseDelegate();

        // The type of form to be displayed as the splash screen.
        private static FormSplash splashForm;

        public FormSplash()
        {
            InitializeComponent();
        }

        public static void ShowSplashScreen()
        {
            // Make sure it is only launched once.    
            if (splashForm != null) return;
            splashForm = new FormSplash();
            Thread thread = new Thread(new ThreadStart(FormSplash.ShowForm));
            thread.IsBackground = true;
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private static void ShowForm()
        {
            if (splashForm != null) Application.Run(splashForm);
        }

        public static void CloseForm()
        {
            splashForm?.Invoke(new CloseDelegate(FormSplash.CloseFormInternal));
        }

        private static void CloseFormInternal()
        {
            if (splashForm != null)
            {
                splashForm.Close();
                splashForm = null;
            };
        }
    }
}
