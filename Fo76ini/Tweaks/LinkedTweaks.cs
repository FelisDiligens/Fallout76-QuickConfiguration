using Fo76ini.Forms.Form1;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Fo76ini.Tweaks
{
    public static class LinkedTweaks
    {
        private static Dictionary<Control, ITweakInfo> LinkedTweakInfos = new Dictionary<Control, ITweakInfo>();
        private static List<Action> SetValueActions = new List<Action>();

        public static void LoadValues()
        {
            foreach (Action action in SetValueActions)
                action();
        }

        public static void SetToolTip(ITweakInfo info, Control control, ToolTip tip)
        {
            tip.SetToolTip(control, $"{info.Description}\n\n{Localization.GetString("affectedFiles")}: {info.AffectedFiles}\n{Localization.GetString("affectedValues")}: {info.AffectedValues}");
        }

        public static void SetToolTips(ToolTip tip)
        {
            foreach (var pair in LinkedTweakInfos)
                SetToolTip(pair.Value, pair.Key, tip);
        }

        /*
         **************************************************************
         * Link control elements together
         **************************************************************
         */

        // Link slider to num and vice-versa

        public static void LinkSlider(TrackBar slider, NumericUpDown num, double numToSliderRatio)
        {
            LinkSlider(slider, num, numToSliderRatio, false);
        }

        /// <summary>
        /// Links the value of a TrackBar to a value of NumericUpDown and vice-versa.
        /// Whenever the value of one changes, the other gets changed too.
        /// </summary>
        /// <param name="slider"></param>
        /// <param name="num"></param>
        /// <param name="numToSliderRatio">Because Trackbar can only have integers, you can use numToSliderRatio to work around it. slider.Value gets multiplied by numToSliderRatio and num.Value gets divided by numToSliderRatio.</param>
        /// <param name="reversed">Whether slider.Maximum should correlate with the minimum and vice-versa.</param>
        public static void LinkSlider(TrackBar slider, NumericUpDown num, double numToSliderRatio, bool reversed)
        {
            if (!reversed)
            {
                slider.ValueChanged += (object sender, EventArgs e) => num.Value = Convert.ToDecimal(slider.Value / numToSliderRatio);
                num.ValueChanged += (object sender, EventArgs e) => slider.Value = Utils.Clamp(Convert.ToInt32(Convert.ToDouble(num.Value) * numToSliderRatio), slider.Minimum, slider.Maximum);
            }
            else
            {
                slider.ValueChanged += (object sender, EventArgs e) => num.Value = Convert.ToDecimal((slider.Maximum - slider.Value) / numToSliderRatio);
                num.ValueChanged += (object sender, EventArgs e) => slider.Value = Utils.Clamp(Convert.ToInt32(slider.Maximum - Convert.ToDouble(num.Value) * numToSliderRatio), slider.Minimum, slider.Maximum);
            }
        }


        /*
         **************************************************************
         * Link *.ini tweaks to control elements
         **************************************************************
         */

        public static void LinkInfo(Control control, ITweakInfo tweakInfo)
        {
            LinkedTweakInfos.Add(control, tweakInfo);
        }

        public static void LinkTweak(CheckBox checkBox, ITweak<bool> tweak)
        {
            SetValueActions.Add(() => checkBox.Checked = tweak.GetValue());
            checkBox.MouseClick += (object sender, MouseEventArgs e) => tweak.SetValue(checkBox.Checked);
        }

        public static void LinkTweakNegated(CheckBox checkBox, ITweak<bool> tweak)
        {
            SetValueActions.Add(() => checkBox.Checked = !tweak.GetValue());
            checkBox.MouseClick += (object sender, MouseEventArgs e) => tweak.SetValue(!checkBox.Checked);
        }

        public static void LinkTweak(ComboBox comboBox, ITweak<int> tweak)
        {
            SetValueActions.Add(() => comboBox.SelectedIndex = tweak.GetValue());
            comboBox.SelectionChangeCommitted += (object sender, EventArgs e) => tweak.SetValue(comboBox.SelectedIndex);
        }

        public static void LinkTweak(RadioButton radioButtonTrue, RadioButton radioButtonFalse, ITweak<bool> tweak)
        {
            SetValueActions.Add(() =>
            {
                if (tweak.GetValue())
                    radioButtonTrue.Checked = true;
                else
                    radioButtonFalse.Checked = true;
            });
            radioButtonTrue.MouseClick += (object sender, MouseEventArgs e) =>
            {
                if (radioButtonTrue.Checked)
                    tweak.SetValue(true);
            };
            radioButtonFalse.MouseClick += (object sender, MouseEventArgs e) =>
            {
                if (radioButtonFalse.Checked)
                    tweak.SetValue(false);
            };
        }

        // TODO: This needs to be refined:
        public static void LinkTweak(Dictionary<string, RadioButton> radioButtons, ITweak<string> tweak)
        {
            SetValueActions.Add(() =>
            {
                RadioButton radioButton;
                if (radioButtons.TryGetValue(tweak.GetValue(), out radioButton))
                    radioButton.Checked = true;
            });

            // I have a really bad feeling about this:
            foreach (var pair in radioButtons)
            {
                pair.Value.MouseClick += (object sender, MouseEventArgs e) =>
                {
                    if (pair.Value.Checked)
                        tweak.SetValue(pair.Key);
                };
            }
        }

        // TODO: This needs to be refined:
        public static void LinkTweak(ComboBox comboBox, string[] associatedValues, ITweak<string> tweak)
        {
            // This could potentially crash the tool on load:
            if (comboBox.Items.Count != associatedValues.Length)
                throw new ArgumentException("LinkTweak: comboBox has to have as many items as associatedValues has!");

            SetValueActions.Add(() =>
            {
                int index = Array.IndexOf(associatedValues, tweak.GetValue());
                int defaultIndex = Array.IndexOf(associatedValues, tweak.DefaultValue);
                if (index > -1)
                    comboBox.SelectedIndex = index;
                else if (defaultIndex > -1)
                    comboBox.SelectedIndex = defaultIndex;
                else
                    throw new ArgumentException("LinkTweak: Couldn't assign a value to comboBox.");
            });

            comboBox.SelectionChangeCommitted += (object sender, EventArgs e) =>
            {
                tweak.SetValue(associatedValues[comboBox.SelectedIndex]);
            };
        }

        public static void LinkTweak(NumericUpDown num, ITweak<int> tweak)
        {
            SetValueActions.Add(() => num.Value = Utils.Clamp(tweak.GetValue(), Convert.ToInt32(num.Minimum), Convert.ToInt32(num.Maximum)));
            num.ValueChanged += (object sender, EventArgs e) => tweak.SetValue(Convert.ToInt32(num.Value));
        }

        public static void LinkTweak(NumericUpDown num, ITweak<float> tweak)
        {
            SetValueActions.Add(() => num.Value = Convert.ToDecimal(Utils.Clamp(tweak.GetValue(), Convert.ToSingle(num.Minimum), Convert.ToSingle(num.Maximum))));
            num.ValueChanged += (object sender, EventArgs e) => tweak.SetValue(Convert.ToSingle(num.Value));
        }

        public static void LinkTweak(TrackBar slider, ITweak<int> tweak)
        {
            SetValueActions.Add(() => slider.Value = Utils.Clamp(tweak.GetValue(), Convert.ToInt32(slider.Minimum), Convert.ToInt32(slider.Maximum)));
            slider.ValueChanged += (object sender, EventArgs e) => tweak.SetValue(slider.Value);
        }

        public static void LinkTweak(TextBox textBox, ITweak<string> tweak)
        {
            SetValueActions.Add(() => textBox.Text = tweak.GetValue());
            textBox.TextChanged += (object sender, EventArgs e) => tweak.SetValue(textBox.Text);
        }

        /// <summary>
        /// This is specific code for the Pipboy/Quickboy/Power armor color picker.
        /// </summary>
        /// <param name="colorDialog">This dialog opens when "Pick color" button has been clicked.</param>
        /// <param name="preview">A picture box whose BackColor property gets set.</param>
        public static void LinkColor(Button pickColor, Button resetColor, ColorDialog colorDialog, ColorPreview preview, ITweak<Color> tweak)
        {
            SetValueActions.Add(() => preview.BackColor = tweak.GetValue());

            pickColor.Click += (object sender, EventArgs e) =>
            {
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    preview.BackColor = colorDialog.Color;
                    tweak.SetValue(colorDialog.Color);
                }
            };

            resetColor.Click += (object sender, EventArgs e) =>
            {
                tweak.ResetValue();
                preview.BackColor = tweak.GetValue();
            };
        }
    }
}
