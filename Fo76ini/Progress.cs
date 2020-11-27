using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini
{
    /// <summary>
    /// A simple class that holds a percentage, a progress text, and other information + some utility methods.
    /// </summary>
    public class Progress
    {
        /// <summary>
        /// Percentage between 0.0f and 1.0f.
        /// </summary>
        public float Percentage = 0.0f;
        public string Text = "";
        public Color? TextColor = null;
        public bool IsDone = false;
        public bool Success = true;
        public Exception Exc = null;

        /// <summary>
        /// Rounded percentage between 0 and 100.
        /// </summary>
        public int RoundedPercentage
        {
            get
            {
                return Utils.Clamp((int)Math.Round(Percentage * 100f, 0), 0, 100);
            }
        }

        /// <summary>
        /// Progress is ongoing and we now the exact percentage.
        /// </summary>
        public static Progress Ongoing(string text, float percentage)
        {
            Progress progress = new Progress();
            progress.Percentage = percentage;
            progress.Text = text;
            return progress;
        }

        /// <summary>
        /// Progress is ongoing, but we don't know the exact percentage.
        /// </summary>
        public static Progress Indetermined(string text)
        {
            Progress progress = new Progress();
            progress.Percentage = -1;
            progress.Text = text;
            return progress;
        }

        /// <summary>
        /// The operation was successful.
        /// </summary>
        public static Progress Done(string text = null)
        {
            Progress progress = new Progress();
            progress.Text = text != null ? text : "Done";
            progress.IsDone = true;
            progress.Success = true;
            progress.Percentage = 100;
            return progress;
        }

        /// <summary>
        /// The operation was aborted due to an error.
        /// </summary>
        public static Progress Aborted(string text, Exception exc = null)
        {
            Progress progress = new Progress();
            progress.IsDone = true;
            progress.Success = false;
            progress.Exc = exc;
            progress.Text = text;
            progress.Percentage = 0;
            return progress;
        }

        public void Update (Label label, ProgressBar progressbar)
        {
            /*
             * Progress bar
             */

            if (Percentage < 0)
            {
                progressbar.Style = ProgressBarStyle.Marquee;
                //this.progressBarMods.MarqueeAnimationSpeed = 15;
            }
            else
            {
                progressbar.Style = ProgressBarStyle.Continuous;
                progressbar.Value = RoundedPercentage;
            }


            /*
             * Label
             */

            if (TextColor != null)
                label.ForeColor = (Color)TextColor;
            else if (IsDone && Success)
                label.ForeColor = Color.DarkGreen;
            else if (IsDone && !Success)
                label.ForeColor = Color.Red;
            else
                label.ForeColor = Color.Black;

            label.Text = Text;
        }

        public Progress AsPhase (int currentPhase, int phaseCount, float progressSoFar, float phaseAmountsTo)
        {
            this.Percentage = progressSoFar + this.Percentage * phaseAmountsTo;
            this.Text = $"[{currentPhase}/{phaseCount}] {this.Text}";
            return this;
        }
    }
}
