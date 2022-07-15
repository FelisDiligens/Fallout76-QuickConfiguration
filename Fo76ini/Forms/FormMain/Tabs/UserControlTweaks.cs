using Fo76ini.Interface;
using Fo76ini.Profiles;
using Fo76ini.Properties;
using Fo76ini.Tweaks;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Forms.FormMain
{
    public partial class UserControlTweaks : UserControl
    {
        public UserControlTweaks()
        {
            InitializeComponent();

            if (this.DesignMode)
                return;

            ProfileManager.ProfileChanged += OnProfileChanged;

            /*
             * Dropdowns
             */

            #region Dropdowns

            // Let's add options to the drop-down menus:

            // Display resolution usage statistics (and lists):
            // https://store.steampowered.com/hwsurvey/Steam-Hardware-Software-Survey-Welcome-to-Steam
            // https://www.rapidtables.com/web/dev/screen-resolution-statistics.html
            // https://w3codemasters.in/most-common-screen-resolutions/
            // https://www.reneelab.com/video-with-4-3-format.html
            // https://www.overclock.net/threads/list-of-display-resolutions-aspect-ratios.539967/
            // https://en.wikipedia.org/wiki/List_of_common_resolutions
            DropDown.Add("Resolution", new DropDown(
                this.comboBoxResolution,
                new string[] {
                    "Custom",
                    "",
                    "┌───────────────────────────────┐",
                    "│  4:3                          │",
                    "├───────────────────────────────┤",
                    "│ [4:3]    640 x  480 (VGA)     │",
                    "│ [4:3]    800 x  600 (SVGA)    │",
                    "│ [4:3]    960 x  720           │",
                    "│ [4:3]   1024 x  768 (XGA)     │",
                    "│ [4:3]   1152 x  864           │",
                    "│ [4:3]   1280 x  960           │",
                    "│ [4:3]   1400 x 1050           │",
                    "│ [4:3]   1440 x 1080           │",
                    "│ [4:3]   1600 x 1200           │",
                    "│ [4:3]   1920 x 1440           │",
                    "│ [4:3]   2048 x 1536           │",
                    "│ [4:3]   2880 x 2160           │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  5:3                          │",
                    "├───────────────────────────────┤",
                    "│ [5:3]    800 x  480           │",
                    "│ [5:3]   1280 x  768 (WXGA)    │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  5:4                          │",
                    "├───────────────────────────────┤",
                    "│ [5:4]   1152 x  960           │",
                    "│ [5:4]   1280 x 1024           │",
                    "│ [5:4]   2560 x 2048           │",
                    "│ [5:4]   5120 x 4096           │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  8:5                          │",
                    "├───────────────────────────────┤",
                    "│ [8:5]   1280 x  800           │",
                    "│ [8:5]   1440 x  900           │",
                    "│ [8:5]   1680 x 1050           │",
                    "│ [8:5]   1920 x 1200           │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  16:9                         │",
                    "├───────────────────────────────┤",
                    "│ [16:9]  1024 x  576           │",
                    "│ [16:9]  1152 x  648           │",
                    "│ [16:9]  1280 x  720 (HD)      │",
                    "│ [16:9]  1360 x  768           │",
                    "│ [16:9]  1365 x  768           │",
                    "│ [16:9]  1366 x  768           │",
                    "│ [16:9]  1536 x  864           │",
                    "│ [16:9]  1600 x  900           │",
                    "│ [16:9]  1920 x 1080 (Full HD) │",
                    "│ [16:9]  2560 x 1440 (WQHD)    │",
                    "│ [16:9]  3200 x 1800           │",
                    "│ [16:9]  3840 x 2160 (4K UHD1) │",
                    "│ [16:9]  5120 x 2880 (5K)      │",
                    "│ [16:9]  7680 x 4320 (8K UHD2) │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  16:10                        │",
                    "├───────────────────────────────┤",
                    "│ [16:10]  640 x  400           │",
                    "│ [16:10] 1280 x  800           │",
                    "│ [16:10] 1440 x  900           │",
                    "│ [16:10] 1680 x 1050           │",
                    "│ [16:10] 1920 x 1200           │",
                    "│ [16:10] 2560 x 1600           │",
                    "│ [16:10] 3840 x 2400           │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  17:9                         │",
                    "├───────────────────────────────┤",
                    "│ [17:9]  2048 x 1080           │",
                    "│                               │",
                    "│                               │",
                    "├───────────────────────────────┤",
                    "│  21:9                         │",
                    "├───────────────────────────────┤",
                    "│ [21:9]  1920 x  800           │",
                    "│ [21:9]  2560 x 1080           │",
                    "│ [21:9]  3440 x 1440           │",
                    "│ [21:9]  3840 x 1600           │",
                    "│ [21:9]  5120 x 2160           │",
                    "│                               │",
                    "│                               │",
                    "└───────────────────────────────┘",
                    ""
                }
            ));

            DropDown.Add("DisplayMode", new DropDown(
                this.comboBoxDisplayMode,
                new string[] {
                    "Fullscreen",
                    "Windowed",
                    "Borderless windowed",
                    "Borderless windowed (Fullscreen)"
                }
            ));

            DropDown.Add("AntiAliasing", new DropDown(
                this.comboBoxAntiAliasing,
                new string[] {
                    "Enabled, TAA (default)",
                    "Disabled"
                }
            ));

            DropDown.Add("AnisotropicFiltering", new DropDown(
                this.comboBoxAnisotropicFiltering,
                new string[] {
                    "None",
                    "2x",
                    "4x",
                    "8x (default)",
                    "16x"
                }
            ));

            DropDown.Add("ShadowTextureResolution", new DropDown(
                this.comboBoxShadowTextureResolution,
                new string[] {
                    "512 = Potato",
                    "1024 = Low",
                    "2048 = High (default)",
                    "4096 = Ultra"
                }
            ));

            DropDown.Add("ShadowBlurriness", new DropDown(
                this.comboBoxShadowBlurriness,
                new string[] {
                    "1x",
                    "2x",
                    "3x = Default, recommended"
                }
            ));

            DropDown.Add("VoiceChatMode", new DropDown(
                this.comboBoxVoiceChatMode,
                new string[] {
                    "Auto",
                    "Area",
                    "Team",
                    "None"
                }
            ));

            DropDown.Add("ShowActiveEffectsOnHUD", new DropDown(
                this.comboBoxShowActiveEffectsOnHUD,
                new string[] {
                    "Disabled",
                    "Detrimental",
                    "All"
                }
            ));

            /*DropDown.Add("iDirShadowSplits", new DropDown(
                this.comboBoxiDirShadowSplits,
                new string[] {
                    "1 - Low",
                    "2 - High / Medium",
                    "3 - Ultra"
                }
            ));*/

            DropDown.Add("CorpseHighlighting", new DropDown(
                this.comboBoxHighlightCorpses,
                new string[] {
                    "Disabled",
                    "Clear On Inspect",
                    "Clear On Remove"
                }
            ));

            #endregion

            /*
             * HTML info
             */

            #region

            this.webBrowserTweaksInfo.DocumentText = @"
<style>
* { font-family: ""Microsoft Sans Serif"" }
h1 { font-size: 14pt; }
h2 { font-size: 12pt; }
p, td, th { font-size: 10pt; }
table, tr, td, th { border-collapse: collapse; border: 1px solid gray; }
td, th { padding: 10px; }
.no-warn { color: black; font-weight: bold; }
.notice { color: blue; font-weight: bold; }
.warn { color: rgb(181, 124, 11); font-weight: bold; }
.unsafe { color: red; font-weight: bold; }
</style>
<h1>Information about tweaks</h1>
<h2>Tool tips</h2>
<p>
All tweaks have a tool tip which shows what it does and which *.ini values it changes.<br>
You can hover your cursor over an option to display said tool tip.
</p>
<h2>Color-code</h2>
<p>
Some tweaks might be problematic or have side effects which is why I color-coded them:
</p>
<p>
<table>
<tr>
<th>Color</th>
<th>Meaning</th>
</tr>
<tr>
<td class=""no-warn"">Black</td>
<td>Nothing to inform about really. Tweak works as it should.</td>
</tr>
<tr>
<td class=""notice"">Blue</td>
<td>There is a notice that might be worth reading about.</td>
</tr>
<tr>
<td class=""warn"">Yellow</td>
<td>Generally usuable but might have side effects. Please read the warning.</td>
</tr>
<tr>
<td class=""unsafe"">Red</td>
<td>Unsafe: Has severe side effects such as crashing or severe graphical glitches.</td>
</tr>
<!--
Black:   Nothing to inform about. Tweak works as it should.
Blue:    There is a notice that might be worth reading about.
Yellow:  Generally usuable but might have side effects.
Red:     Has severe side effects such as crashing or severe graphical glitches.
-->
</table>
</p>
";

            #endregion

            // Link tweaks
            LinkInfo();
            LinkSliders();
            LinkControlsToTweaks();

            InitAccountProfileRadiobuttons();

            this.labelTweaksTitle.Font = new Font(CustomFonts.Overseer, 20, FontStyle.Regular);
        }

        private void OnProfileChanged(object sender, ProfileEventArgs e)
        {
            // For some reason, it won't update the resolution combobox, unless I add this workaround:
            numCustomRes_ValueChanged(null, null);

            LoadAccountProfile();
        }

        #region Credentials
        /*
         * Credentials
         */

        List<RadioButton> accountProfileRadioButtons
        {
            get
            {
                return new List<RadioButton> {
                    radioButtonAccount1,
                    radioButtonAccount2,
                    radioButtonAccount3,
                    radioButtonAccount4,
                    radioButtonAccount5,
                    radioButtonAccount6,
                    radioButtonAccount7,
                    radioButtonAccount8,
                    radioButtonAccount9,
                    radioButtonAccount10,
                    radioButtonAccount11,
                    radioButtonAccount12,
                    radioButtonAccount13,
                    radioButtonAccount14,
                    radioButtonAccount15,
                    radioButtonAccount16
                };
            }
        }

        // Show password:
        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            // https://stackoverflow.com/questions/8185747/how-can-i-unmask-password-text-box-and-mask-it-back-to-password
            this.textBoxPassword.UseSystemPasswordChar = !this.checkBoxShowPassword.Checked;
            this.textBoxPassword.PasswordChar = !this.checkBoxShowPassword.Checked ? '\u2022' : '\0';
        }

        private void textBoxUserName_TextChanged(object sender, EventArgs e)
        {
            int index = GetSelectedAccountProfileRadiobuttonIndex();
            if (this.textBoxUserName.Text == "")
            {
                IniFiles.Config.Remove("Login", $"s76UserName{index}");
                IniFiles.F76Custom.Remove("Login", "s76UserName");
            }
            else
            {
                IniFiles.Config.Set("Login", $"s76UserName{index}", this.textBoxUserName.Text);
                IniFiles.F76Custom.Set("Login", "s76UserName", this.textBoxUserName.Text);
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            int index = GetSelectedAccountProfileRadiobuttonIndex();
            if (this.textBoxPassword.Text == "")
            {
                IniFiles.Config.Remove("Login", $"s76Password{index}");
                IniFiles.F76Custom.Remove("Login", "s76Password");
            }
            else
            {
                IniFiles.Config.Set("Login", $"s76Password{index}", this.textBoxPassword.Text);
                IniFiles.F76Custom.Set("Login", "s76Password", this.textBoxPassword.Text);
            }
        }

        // If a radiobuttons gets checked, load username and password of a profile.
        private void radioButtonAccount_CheckedChanged(object sender, EventArgs e)
        {
            int index = GetSelectedAccountProfileRadiobuttonIndex();
            IniFiles.Config.Set("Login", "uActiveAccountProfile", index);
            if (index == 0)
            {
                this.textBoxUserName.Text = IniFiles.GetString("Login", "s76UserName", "");
                this.textBoxPassword.Text = IniFiles.GetString("Login", "s76Password", "");
            }
            else
            {
                this.textBoxUserName.Text = IniFiles.Config.GetString("Login", $"s76UserName{index}", "");
                this.textBoxPassword.Text = IniFiles.Config.GetString("Login", $"s76Password{index}", "");
            }
        }

        private void radioButtonAccountNone_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxUserName.Text = IniFiles.GetString("Login", "s76UserName", "");
            this.textBoxPassword.Text = IniFiles.GetString("Login", "s76Password", "");
        }

        private int GetSelectedAccountProfileRadiobuttonIndex()
        {
            int index = 1;
            foreach (RadioButton rbutton in accountProfileRadioButtons)
            {
                if (rbutton.Checked)
                    break;
                index++;
            }
            if (index > accountProfileRadioButtons.Count)
                index = 0;
            return index;
        }

        private void SetSelectedAccountProfileRadiobuttonIndex(int index)
        {
            if (index <= 0)
            {
                this.radioButtonAccountNone.Checked = true;
                return;
            }
            accountProfileRadioButtons[index - 1].Checked = true;
        }

        // Assigns event handler to radiobuttons (Account #1, Account #2, ...):
        private void InitAccountProfileRadiobuttons()
        {
            foreach (RadioButton rbutton in accountProfileRadioButtons)
                rbutton.CheckedChanged += radioButtonAccount_CheckedChanged;
        }

        // Gets current account profile and sets the according radiobutton
        private void LoadAccountProfile()
        {
            //int index = IniFiles.Config.GetInt("Login", "uActiveAccountProfile", 0);
            int index = 0;
            string username = IniFiles.GetString("Login", "s76UserName", "");
            string password = IniFiles.GetString("Login", "s76Password", "");
            if (username != "" && password != "")
            {
                for (int i = 1; i <= accountProfileRadioButtons.Count(); i++)
                {
                    if (username == IniFiles.Config.GetString("Login", $"s76UserName{i}", "") &&
                        password == IniFiles.Config.GetString("Login", $"s76Password{i}", ""))
                    {
                        index = i;
                        break;
                    }
                }
            }
            SetSelectedAccountProfileRadiobuttonIndex(index);
        }
        #endregion

        #region Resolution combobox

        // Detect resolution:
        private void buttonDetectResolution_Click(object sender, EventArgs e)
        {
            Size res = Utils.GetDisplayResolution();
            this.numCustomResW.Value = res.Width;
            this.numCustomResH.Value = res.Height;
        }

        private void comboBoxResolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If "Custom" selected, skip:
            if (this.comboBoxResolution.SelectedIndex == 0)
                return;

            // If an invalid option has been selected, set to "Custom" and skip:
            string res = this.comboBoxResolution.SelectedItem.ToString();
            Size? displaySize = GetResolutionFromString(res);
            if (!displaySize.HasValue)
            {
                this.comboBoxResolution.SelectedIndex = 0;
                return;
            }

            int width = displaySize.Value.Width;
            int height = displaySize.Value.Height;

            // Set the values of the NumericUpDowns (which in turn will trigger the event handlers which set the values in the *.ini files)
            if (this.numCustomResW.Value != width)
                this.numCustomResW.Value = width;

            if (this.numCustomResH.Value != height)
                this.numCustomResH.Value = height;
        }

        /// <summary>
        /// Extracts width and height from a string that looks like this: "[16:9] 1920 x 1080 (Full HD)"
        /// </summary>
        /// <returns>Width and height if a valid option has been selected. Otherwise null.</returns>
        private Size? GetResolutionFromString(String res)
        {
            if (!res.Contains("x"))
                return null;
            string[] split = res.Split('x').Select(x => x.Trim()).ToArray();
            int width = Convert.ToInt32(Regex.Match(split[0], @"[0-9]+$").Groups[0].Value);
            int height = Convert.ToInt32(Regex.Match(split[1], @"^[0-9]+").Groups[0].Value);
            return new Size(width, height);
        }

        /// <summary>
        /// Searches through the resolution combobox for an option that matches the given size.
        /// </summary>
        /// <param name="size"></param>
        /// <returns>The first occurence if a match was found. Otherwise -1.</returns>
        private int FindIndexInResolutionComboBox(Size size)
        {
            for (int i = 0; i < this.comboBoxResolution.Items.Count; i++)
            {
                string res = this.comboBoxResolution.Items[i].ToString();
                Size? s = GetResolutionFromString(res);
                if (s?.Width == size.Width && s?.Height == size.Height)
                    return i;
            }
            return -1;
        }

        private void numCustomRes_ValueChanged(object sender, EventArgs e)
        {
            Size size = new Size(
                Convert.ToInt32(numCustomResW.Value),
                Convert.ToInt32(numCustomResH.Value)
            );
            int i = FindIndexInResolutionComboBox(size);
            if (i > -1)
                this.comboBoxResolution.SelectedIndex = i;
            else
                this.comboBoxResolution.SelectedIndex = 0;
        }

        #endregion

        #region Camera

        private void buttonCameraPositionReset_Click(object sender, EventArgs e)
        {
            this.applyCameraNodeAnimationsTweak.ResetValue();
            this.cameraOverShoulderPosXTweak.ResetValue();
            this.cameraOverShoulderPosZTweak.ResetValue();
            this.cameraOverShoulderCombatPosXTweak.ResetValue();
            this.cameraOverShoulderCombatPosZTweak.ResetValue();
            this.cameraOverShoulderCombatAddYTweak.ResetValue();
            this.cameraOverShoulderMeleeCombatPosXTweak.ResetValue();
            this.cameraOverShoulderMeleeCombatPosZTweak.ResetValue();
            this.cameraOverShoulderMeleeCombatAddYTweak.ResetValue();
            LinkedTweaks.LoadValues();
        }

        private Bitmap getFOVPreviewImage(int fov)
        {
            fov = (int)(Math.Round((float)fov / 5f) * 5);
            fov = Utils.Clamp(fov, 70, 120);
            switch (fov)
            {
                case 70:
                    return Resources.fov_70;
                case 75:
                    return Resources.fov_75;
                case 80:
                    return Resources.fov_80;
                case 85:
                    return Resources.fov_85;
                case 90:
                    return Resources.fov_90;
                case 95:
                    return Resources.fov_95;
                case 100:
                    return Resources.fov_100;
                case 105:
                    return Resources.fov_105;
                case 110:
                    return Resources.fov_110;
                case 115:
                    return Resources.fov_115;
                case 120:
                    return Resources.fov_120;
                default:
                    return Resources.fov_70;
            }
        }

        private void numFOV_ValueChanged(object sender, EventArgs e)
        {
            this.pictureBoxFOVPreview.Image = getFOVPreviewImage((int)this.numFOV.Value);
        }

        #endregion
    }
}
