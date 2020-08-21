using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini
{
    public class UILoader
    {
        public delegate void OnLoadUIFunction();
        private List<OnLoadUIFunction> OnLoadUI = new List<OnLoadUIFunction>();

        public void Update()
        {
            List<Exception> exceptions = new List<Exception>();
            foreach (OnLoadUIFunction func in OnLoadUI)
            {
                try
                {
                    func();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }
            if (exceptions.Count > 0)
                MsgBox.Get("onLoadFuncException").FormatText(exceptions.Count.ToString(), exceptions[0].ToString()).Show(MessageBoxIcon.Error);
        }

        public void Add(OnLoadUIFunction func)
        {
            OnLoadUI.Add(func);
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
         * Link *.ini states to control elements
         **************************************************************
         */

        // comboBox.SelectedIndexChanged => comboBox.SelectionChangeCommitted
        // checkBox.CheckedChanged       => checkBox.MouseClick
        // radioButton.CheckedChanged    => radioButton.MouseClick

        public void LinkCustom(CheckBox checkBox, Func<bool> getState, Action<bool> setState)
        {
            OnLoadUI.Add(() => checkBox.Checked = getState());
            checkBox.MouseClick += (object sender, MouseEventArgs e) => setState(checkBox.Checked);
        }

        public void LinkCustom(ComboBox comboBox, Func<int> getState, Action<int> setState)
        {
            OnLoadUI.Add(() => comboBox.SelectedIndex = getState());
            comboBox.SelectionChangeCommitted += (object sender, EventArgs e) => setState(comboBox.SelectedIndex);
        }

        public void LinkCustom(NumericUpDown num, Func<int> getState, Action<int> setState)
        {
            OnLoadUI.Add(() => num.Value = Utils.Clamp(getState(), Convert.ToInt32(num.Minimum), Convert.ToInt32(num.Maximum)));
            num.ValueChanged += (object sender, EventArgs e) => setState(Convert.ToInt32(num.Value));
        }

        public void LinkCustom(NumericUpDown num, Func<float> getState, Action<float> setState)
        {
            OnLoadUI.Add(() => num.Value = Convert.ToDecimal(Utils.Clamp(getState(), Convert.ToSingle(num.Minimum), Convert.ToSingle(num.Maximum))));
            num.ValueChanged += (object sender, EventArgs e) => setState(Convert.ToSingle(num.Value));
        }

        public void LinkBoolNegated(CheckBox checkBox, IniFile f, String section, String key, bool defaultValue)
        {
            LinkBool(checkBox, f, section, key, defaultValue, true);
        }

        public void LinkBool(CheckBox checkBox, IniFile f, String section, String key, bool defaultValue, bool negated = false)
        {
            OnLoadUI.Add(() => {
                bool val = IniFiles.Instance.GetBool(f, section, key, defaultValue);
                checkBox.Checked = negated ? !val : val;
            });
            checkBox.MouseClick += (object sender, MouseEventArgs e) => {
                if (f == IniFile.F76Custom && (negated ? !checkBox.Checked : checkBox.Checked) == defaultValue)
                    IniFiles.Instance.Remove(f, section, key);
                else
                    IniFiles.Instance.Set(f, section, key, negated ? !checkBox.Checked : checkBox.Checked);
            };
        }

        public void LinkBool(RadioButton radioButtonTrue, RadioButton radioButtonFalse, IniFile f, String section, String key, bool defaultValue)
        {
            OnLoadUI.Add(() => {
                bool val = IniFiles.Instance.GetBool(f, section, key, defaultValue);
                if (val)
                    radioButtonTrue.Checked = true;
                else
                    radioButtonFalse.Checked = true;
            });
            radioButtonTrue.MouseClick += (object sender, MouseEventArgs e) => {
                if (radioButtonTrue.Checked)
                    IniFiles.Instance.Set(f, section, key, true);
            };
            radioButtonFalse.MouseClick += (object sender, MouseEventArgs e) => {
                if (radioButtonFalse.Checked)
                    IniFiles.Instance.Set(f, section, key, false);
            };
        }

        public void LinkInt(NumericUpDown num, IniFile f, String section, String key, int defaultValue)
        {
            OnLoadUI.Add(() => {
                num.Value = Utils.Clamp(IniFiles.Instance.GetInt(f, section, key, defaultValue), Convert.ToInt32(num.Minimum), Convert.ToInt32(num.Maximum));
            });
            num.ValueChanged += (object sender, EventArgs e) => {
                if (f == IniFile.F76Custom && num.Value == defaultValue)
                    IniFiles.Instance.Remove(f, section, key);
                else
                    IniFiles.Instance.Set(f, section, key, Convert.ToInt32(num.Value));
            };
        }

        public void LinkInt(TrackBar slider, IniFile f, String section, String key, int defaultValue)
        {
            OnLoadUI.Add(() => {
                slider.Value = Utils.Clamp(IniFiles.Instance.GetInt(f, section, key, defaultValue), Convert.ToInt32(slider.Minimum), Convert.ToInt32(slider.Maximum));
            });
            slider.ValueChanged += (object sender, EventArgs e) => {
                if (f == IniFile.F76Custom && slider.Value == defaultValue)
                    IniFiles.Instance.Remove(f, section, key);
                else
                    IniFiles.Instance.Set(f, section, key, Convert.ToInt32(slider.Value));
            };
        }

        public void LinkFloat(NumericUpDown num, IniFile f, String section, String key, float defaultValue)
        {
            OnLoadUI.Add(() => {
                num.Value = Convert.ToDecimal(Utils.Clamp(IniFiles.Instance.GetFloat(f, section, key, defaultValue), Convert.ToSingle(num.Minimum), Convert.ToSingle(num.Maximum)));
            });
            num.ValueChanged += (object sender, EventArgs e) => {
                if (f == IniFile.F76Custom && Convert.ToSingle(num.Value) == defaultValue)
                    IniFiles.Instance.Remove(f, section, key);
                else
                    IniFiles.Instance.Set(f, section, key, Convert.ToSingle(num.Value));
            };
        }

        public void LinkString(TextBox textBox, IniFile f, String section, String key, String defaultValue)
        {
            OnLoadUI.Add(() => textBox.Text = IniFiles.Instance.GetString(section, key, defaultValue));
            textBox.TextChanged += (object sender, EventArgs e) => {
                if (f == IniFile.F76Custom && textBox.Text == defaultValue)
                    IniFiles.Instance.Remove(f, section, key);
                else
                    IniFiles.Instance.Set(f, section, key, textBox.Text);
            };
        }

        public void LinkList(RadioButton[] radioButtons, String[] associatedValues, IniFile f, String section, String key, String defaultValue)
        {
            if (radioButtons.Length != associatedValues.Length)
                throw new ArgumentException("LinkList: radioButtons and associatedValues have to have the same length!");

            OnLoadUI.Add(() => {
                String value = IniFiles.Instance.GetString(f, section, key, defaultValue);
                int index = Array.IndexOf(associatedValues, value);
                if (index > -1)
                {
                    radioButtons[index].Checked = true;
                }
            });

            // I have a really bad feeling about this:
            for (int i = 0; i < radioButtons.Length; i++)
            {
                RadioButton radioButton = radioButtons[i];
                String associatedValue = associatedValues[i];
                radioButton.MouseClick += (object sender, MouseEventArgs e) => {
                    if (radioButton.Checked)
                        IniFiles.Instance.Set(f, section, key, associatedValue);
                };
            }
        }

        public void LinkList(ComboBox comboBox, String[] associatedValues, IniFile f, String section, String key, String defaultValue, int defaultComboBoxIndex)
        {
            if (comboBox.Items.Count != associatedValues.Length)
                throw new ArgumentException("LinkList: comboBox has to have as many items as associatedValues has!");

            OnLoadUI.Add(() => {
                String value = IniFiles.Instance.GetString(f, section, key, defaultValue);
                int index = Array.IndexOf(associatedValues, value);
                if (index > -1)
                    comboBox.SelectedIndex = index;
                else
                    comboBox.SelectedIndex = defaultComboBoxIndex;
            });
            comboBox.SelectionChangeCommitted += (object sender, EventArgs e) => {
                IniFiles.Instance.Set(f, section, key, associatedValues[comboBox.SelectedIndex]);
            };
        }
    }
}
