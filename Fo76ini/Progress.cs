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

        /// <summary>
        /// Changes the progress object to be part of a "phase".
        /// 
        /// Example:
        /// "'some.jpg' - 58% copied"
        /// [******    ] 58%
        /// 
        /// turns into
        /// 
        /// "Copying 5 of 39 files - 'some.jpg' - 58% copied"
        /// [*         ] 12%
        /// </summary>
        /// <param name="formattedPhaseStr">Example: "Copying {0} of {1} files - {2}"</param>
        /// <param name="currentPhase"></param>
        /// <param name="phaseCount"></param>
        /// <returns></returns>
        public Progress AsPhase(string formattedPhaseStr, int currentPhase, int phaseCount)
        {
            return this.AsPhase(formattedPhaseStr, currentPhase, phaseCount, (float)(currentPhase - 1) / (float)phaseCount, 1f / (float)phaseCount);
        }

        public Progress AsPhase (string formattedPhaseStr, int currentPhase, int phaseCount, float progressSoFar, float phaseAmountsTo)
        {
            if (this.Percentage >= 0 && this.Percentage <= 100)
                this.Percentage = progressSoFar + this.Percentage * phaseAmountsTo;
            else
                this.Percentage = progressSoFar;
            this.Text = String.Format(formattedPhaseStr, currentPhase, phaseCount, this.Text);
            this.IsDone = false;
            return this;
        }

        public static Action<Progress> BuildPhasedProgressChanged(Action<Progress> originalProgressChanged, string formattedPhaseStr, int currentPhase, int phaseCount)
        {
            return (progress) => {
                originalProgressChanged(progress.AsPhase(formattedPhaseStr, currentPhase, phaseCount));
            };
        }
    }
}
