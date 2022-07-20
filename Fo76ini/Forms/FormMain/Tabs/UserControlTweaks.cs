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
                    "4096 = Ultra",
                    "8192 = Insane"
                }
            ));

            DropDown.Add("ShadowBlurriness", new DropDown(
                this.comboBoxShadowBlurriness,
                new string[] {
                    "1x (crisper, pixels noticeable)",
                    "2x (less blurry)",
                    "3x (blurry, default)"
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

            #region Info

            this.webBrowserTweaksInfo.DocumentText = @"
<style>
* { font-family: ""Microsoft Sans Serif"" }
h1 { font-size: 14pt; }
h2 { font-size: 12pt; }
p, td, th { font-size: 10pt; }
table, tr, td, th { border-collapse: collapse; border: 1px solid gray; }
td, th { padding: 10px; }
.no-warn { color: black; font-weight: bold; }
.experimental { color: #FF00FF; font-weight: bold; }
.notice { color: blue; font-weight: bold; }
.warn { color: rgb(181, 124, 11); font-weight: bold; }
.unsafe { color: red; font-weight: bold; }
</style>
<h1>Information about tweaks</h1>
<h2>Tool tips</h2>
<img src="" data:image/png;base64,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""/>
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
<td class=""experimental"">Magenta</td>
<td>Experimental/Untested: This tweak might not do anything.</td>
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
<h2>About the slider range</h2>
<img src="" data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAXoAAAA2CAIAAABGL8VkAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAJcEhZcwAADsMAAA7DAcdvqGQAAAQ4SURBVHhe7d1PjpswFMfx5FrJfdIrdNcjNPfodFU1m96jlSbrttL07wk6tf2ejbGBkExwTPh+ZE3h5UGYhX8CipgVAJTzDAATI24AFELcACiEuAFQCHEDoJCuuDnuN1q2Nvuj1juZ5hMdkbOaAdwXzRRdE9MliDR3bkISAffuFnGjK23EDXDvxsXNYecvrza7g6sc91LabDZ6ueUrpiWNjaTZ79/86zc4+EW3afJ1tn/X7F0PIDSZivu+gQMAUAE3P4fu3ejsVpoUtkMmuZn1LiP0g6gnyJq1way4nevnyVaOFG2DzxQTMrbNbSPt7Z26il18/OeWAVRDQ0XXRDRzlT1xCCcc7Zsvsmx+6sci2r6z2VbcNva85XA0H7fbTn9dqAi3s8jmLXkDVEZnp66JdDK70wd/wZLO9lBJzoOCzuamcnCXQPHZzbivCxVhKn0HAKAOI+PGX7jsw6WTTQhXkXs3ruKb2ptnzdogF0FSNvkStsq+Lt6hLts9ZRdTrQPg5AaozZi4sdNeLlXiG8NaMZc9WvH3brtuFbea/f6b3do1uVtsz1DSr4uPJyyHrwu3dQYOAEAF3PxM4gYAJkDcACiEuAFQCHEDoBDiBkAhxA2AQogbAIUQNwAKIW5Qzur1l+GhfbhTxA3KScIlH9q3DO/ef7jjob9kG3GDcpJwyYf2LUPfnKzQ3zMRN7i9JFzyoX3LMK+4eXh4kCgZJm3EDW4vCZd8aN8ynB03R0MX1WWV80mO/BmBuEEtknDJh/YtQ2tO2pethBc2HV6t1zoz9Q0Mz+51B/alc/7tuV2VV9uTPZeRuPnVZg5OlyJXi5vPwMsk4ZIP7ZsznS0j+Dnp38/Sipt2PDTvYGne3pJXtttTPZeSuPkZWftA1HXvmnHz/emJwbh4JOGSj6R/duOiuBH2rXIaMU1weNGHuthVCRnV23MpiZsnT1PD06pD3DBqGUm45CPpn924Wtys7avlDDkniU9OZLmzst0/JpWkR5YvIHHzbYRrxg3wEkm45EP75kxnywjDZzf2FZXuBZWmmgdHZ2XquPk6wtXiBnihJFzyoX3L0Bs3kb7g6KxMHTcjETeoQhIu+dC+ZRgfN/GHuthVmfrezUjEDaqQhEs+tG8Z+uLGRMx699GeiuhfGYlPTvxSV2Xq/5kyP08iblCLJFzyoX3L0H92c3RP0BjNHxWp4bmb3547toZWHeIGtXjz6UeSL/Ewn2rfMvTNyV5jnhgeUzmfxI0+yeeE52503SNuUJG+xFla1hhnx83tSNzok3yeyQ1dihA3qEueOKaywD96Oru40Sf5BhE3qE6cOAs8rxGzixt9tGYQcYMaSeIsNmuM2cXNSMQNUJ15xc1ZiBugLmZO3vHQX7KNuAFQCHEDoBDiBkAhxA2AQogbAIUQNwAKIW4AFELcACiEuAFQiMYNAExutfoPWIcMkDpVXYIAAAAASUVORK5CYII=""/>
<p>
Sliders have a range (minimum / maximum) but for most of them you can exceed the range by manually typing a value into the number fields next to them.
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
