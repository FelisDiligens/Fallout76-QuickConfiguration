using ComboxExtended;
using Fo76ini.Interface;
using Fo76ini.Profiles;
using Fo76ini.Properties;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Fo76ini;
using Fo76ini.Ini;
using Fo76ini.Forms.FormIniError;
using Fo76ini.Forms.FormWelcome;
using Fo76ini.Tweaks;

namespace Fo76ini.Forms.FormProfiles
{
    public partial class FormProfiles : Form
    {
        PrivateFontCollection pfc = new PrivateFontCollection();

        FormWelcome.FormWelcome formWelcome = new FormWelcome.FormWelcome();

        bool UpdatingUI = false;

        public FormProfiles()
        {
            InitializeComponent();

            InitCustomLabelFont();
            labelLogo.Font = new Font(pfc.Families[0], labelLogo.Font.Size);

            HideTabHeader();

            this.comboBoxGameEdition.Items.Add(new ComboBoxItem("Steam", Resources.steam_24px));
            this.comboBoxGameEdition.Items.Add(new ComboBoxItem("Steam (PTS)", Resources.steam_24px));
            this.comboBoxGameEdition.Items.Add(new ComboBoxItem("Xbox", Resources.xbox_24));
            this.comboBoxGameEdition.Items.Add(new ComboBoxItem("Other", Resources.help_24));
            this.comboBoxGameEdition.Items.Add(new ComboBoxItem("---"));
            this.comboBoxGameEdition.Items.Add(new ComboBoxItem("Bethesda.net Launcher (deprecated)", Resources.bethesda_24));
            this.comboBoxGameEdition.Items.Add(new ComboBoxItem("Bethesda.net Launcher - PTS (deprecated)", Resources.bethesda_24));

            this.Size = new Size(800, 600);

            this.listViewGameInstances.HeaderStyle = ColumnHeaderStyle.None;

            // Make this form translatable:
            LocalizedForm form = new LocalizedForm(this, null);
            Localization.LocalizedForms.Add(form);
        }

        public DialogResult OpenDialog(bool ignoreSkip = false)
        {
            if (Initialization.FirstStart)
            {
                formWelcome.Closed += (s, args) => LoadApp();
                return formWelcome.OpenDialog();
            }
            else if (Configuration.SkipProfileManager && !ignoreSkip)
            {
                // TODO: Sanity checking!
                LoadApp();
                return DialogResult.OK;
            }
            else
            {
                return this.ShowDialog();
            }
        }


        // https://stackoverflow.com/a/23520042
        private void InitCustomLabelFont()
        {
            // Select your font from the resources.
            // My font here is "Digireu.ttf"
            int fontLength = Properties.Resources.overseer.Length;

            // create a buffer to read in to
            byte[] fontdata = Properties.Resources.overseer;

            // create an unsafe memory block for the font data
            IntPtr data = Marshal.AllocCoTaskMem(fontLength);

            // copy the bytes to the unsafe memory block
            Marshal.Copy(fontdata, 0, data, fontLength);

            // pass the font to the font collection
            pfc.AddMemoryFont(data, fontLength);
        }

        private void HideTabHeader()
        {
            // https://stackoverflow.com/a/10346520
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        private void UpdateList()
        {
            UpdatingUI = true;

            // For each managed game instance...
            this.listViewGameInstances.Items.Clear();
            foreach (GameInstance game in ProfileManager.Games)
            {
                bool isSelected = ProfileManager.IsSelected(game);

                // ... add it to the list.
                ListViewItem gameItem = new ListViewItem(
                    game.Title + (isSelected ? $" [{Localization.GetString("selected")}]" : ""),
                    GetImageIndex(game.Edition)
                );
                this.listViewGameInstances.Items.Add(gameItem);

                // If it is the currently selected game, then...
                if (isSelected)
                {
                    // ... select it in the list ...
                    gameItem.Selected = true;
                }
            }

            UpdatingUI = false;
        }

        private void UpdateEditingScreen()
        {
            UpdatingUI = true;

            GameInstance game = ProfileManager.SelectedGame;

            this.textBoxProfileName.Text = game.Title;

            switch (game.Edition)
            {
                case GameEdition.Steam:
                    this.comboBoxGameEdition.SelectedIndex = 0;
                    break;
                case GameEdition.SteamPTS:
                    this.comboBoxGameEdition.SelectedIndex = 1;
                    break;
                case GameEdition.Xbox:
                    this.comboBoxGameEdition.SelectedIndex = 2;
                    break;
                case GameEdition.BethesdaNet:
                    this.comboBoxGameEdition.SelectedIndex = 5;
                    break;
                case GameEdition.BethesdaNetPTS:
                    this.comboBoxGameEdition.SelectedIndex = 6;
                    break;
                default:
                    this.comboBoxGameEdition.SelectedIndex = 3;
                    break;
            }

            this.radioButtonLaunchViaLink.Checked = game.PreferredLaunchOption == LaunchOption.OpenURL;
            this.radioButtonLaunchViaExecutable.Checked = game.PreferredLaunchOption == LaunchOption.RunExec;

            this.textBoxGamePath.Text = game.GamePath;
            this.textBoxExecutable.Text = game.ExecutableName;
            this.textBoxIniPrefix.Text = game.IniPrefix;
            this.textBoxParameters.Text = game.ExecParameters;
            this.textBoxLaunchURL.Text = game.LauncherURL;

            this.labelLaunchOptionMSStoreNotice.Visible =
                game.Edition == GameEdition.Xbox &&
                game.PreferredLaunchOption == LaunchOption.RunExec;

            UpdatingUI = false;
        }

        private int GetImageIndex(GameEdition edition)
        {
            switch (edition)
            {
                case GameEdition.BethesdaNet:
                case GameEdition.BethesdaNetPTS:
                    return 1;
                case GameEdition.Steam:
                case GameEdition.SteamPTS:
                    return 2;
                case GameEdition.Xbox:
                    return 3;
                default:
                    return 0;
            }
        }


        /*
         * Bootstrap
         */

        /// <summary>
        /// Hide FormProfiles, save the profile, and open FormMain.
        /// </summary>
        private void LoadApp()
        {
            ProfileManager.Save();
            Initialization.LoadINIFiles();
            //Initialization.LoadMods();
            LinkedTweaks.LoadValues();
            ProfileManager.Feedback();

            this.Hide();
        }


        /*
         * General event handler
         */

        private void FormProfiles_Load(object sender, EventArgs e)
        {
            UpdateList();
            this.panelAdvancedOptions.Visible = false;
            this.checkBoxShowProfileManager.Checked = !Configuration.SkipProfileManager;
            this.tabControl.SelectedTab = this.tabPageSelect;
        }

        private void FormProfiles_Shown(object sender, EventArgs e)
        {

        }

        private void buttonLoadProfile_Click(object sender, EventArgs e)
        {
            LoadApp();
        }

        private void FormProfiles_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                LoadApp();
            }
        }


        /*
         * Event handler for the selection screen
         */

        private void buttonEditProfile_Click(object sender, EventArgs e)
        {
            UpdateEditingScreen();
            this.tabControl.SelectedTab = this.tabPageEdit;
        }

        private void listViewGameInstances_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;

            if (this.listViewGameInstances.SelectedItems != null && this.listViewGameInstances.SelectedItems.Count > 0)
            {
                int index = this.listViewGameInstances.SelectedItems[0].Index;
                if (ProfileManager.SelectedGameIndex != index)
                {
                    ProfileManager.SelectedGameIndex = index;
                    UpdateList();
                }
            }
        }

        private void buttonAddProfile_Click(object sender, EventArgs e)
        {
            GameInstance game = new GameInstance();
            ProfileManager.AddGame(game);
            ProfileManager.SelectGame(game);
            UpdateList();
        }

        private void buttonDeleteProfile_Click(object sender, EventArgs e)
        {
            // At least one profile:
            if (ProfileManager.Count == 1)
            {
                MsgBox.Get("errorAtLeastOneGameOrProfile").Show(MessageBoxIcon.Error);
                return;
            }

            // "You sure?"
            if (MsgBox.Get("deleteQuestion")
                .FormatTitle(ProfileManager.SelectedGame.Title)
                .FormatText(ProfileManager.SelectedGame.Title)
                .Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProfileManager.RemoveGame(ProfileManager.SelectedGame);
                ProfileManager.SelectedGameIndex -= 1;
                UpdateList();
            }
        }


        /*
         * Event handler for the editing screen
         */

        private void linkLabelNavigationBack_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ProfileManager.Save();
            this.tabControl.SelectedTab = this.tabPageSelect;
            UpdateList();
        }

        /* Profile */
        private void textBoxProfileName_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            string newName = this.textBoxProfileName.Text;
            if (newName.Trim() == "")
                ProfileManager.SelectedGame.Title = "Untitled";
            else
                ProfileManager.SelectedGame.Title = newName;
            UpdateList();
        }

        /* Game edition */
        #region Game edition

        private void comboBoxGameEdition_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;

            GameEdition edition = GameEdition.Unknown;

            switch (this.comboBoxGameEdition.SelectedIndex)
            {
                case 0:
                    edition = GameEdition.Steam;
                    break;
                case 1:
                    edition = GameEdition.SteamPTS;
                    break;
                case 2:
                    edition = GameEdition.Xbox;
                    break;
                case 5:
                    edition = GameEdition.BethesdaNet;
                    break;
                case 6:
                    edition = GameEdition.BethesdaNetPTS;
                    break;
            }
            ProfileManager.SelectedGame.Edition = edition;
            ProfileManager.SelectedGame.SetDefaultSettings(edition);

            UpdateEditingScreen();
        }

        #endregion


        /* Game location */
        #region Game location

        private void textBoxGamePath_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.GamePath = this.textBoxGamePath.Text;
            this.textBoxGamePath.ForeColor = ProfileManager.SelectedGame.ValidateGamePath() ? Color.Black : Color.Maroon;
        }

        private void buttonPickGamePath_Click(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;

            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                string path = dialog.FileName; // We want the path where Fallout76.exe resides.
                if (GameInstance.ValidateGamePath(path))
                {
                    this.textBoxGamePath.Text = path;
                    ProfileManager.SelectedGame.GamePath = path;
                    UpdateEditingScreen();
                }
                else
                    MsgBox.ShowID("modsGamePathInvalid");
            }
            this.Focus();
        }

        private void linkLabelAutoDetect_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string foundPath = AutoDetectGamePath();
            if (foundPath != null)
                this.textBoxGamePath.Text = foundPath;
            else
                MsgBox.ShowID("gamePathAutoDetectFailed", MessageBoxIcon.Information);
        }

        #endregion


        /* Launch options */
        #region Launch options

        private void radioButtonLaunchViaLink_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.PreferredLaunchOption = LaunchOption.OpenURL;

            this.labelLaunchOptionMSStoreNotice.Visible = false;
        }

        private void radioButtonLaunchViaExecutable_CheckedChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.PreferredLaunchOption = LaunchOption.RunExec;

            this.labelLaunchOptionMSStoreNotice.Visible =
                ProfileManager.SelectedGame.Edition == GameEdition.Xbox &&
                ProfileManager.SelectedGame.PreferredLaunchOption == LaunchOption.RunExec;
        }

        #endregion


        /* Advanced options */
        #region Advanced options

        private void textBoxIniPrefix_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.IniPrefix = this.textBoxIniPrefix.Text;
        }

        private void textBoxExecutable_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.ExecutableName = this.textBoxExecutable.Text;
        }

        private void textBoxParameters_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.ExecParameters = this.textBoxParameters.Text;
        }

        private void textBoxLaunchURL_TextChanged(object sender, EventArgs e)
        {
            if (UpdatingUI)
                return;
            ProfileManager.SelectedGame.LauncherURL = this.textBoxLaunchURL.Text;
        }

        #endregion


        private void checkBoxMoreOptions_CheckedChanged(object sender, EventArgs e)
        {
            this.panelAdvancedOptions.Visible = checkBoxMoreOptions.Checked;
        }

        /*
         * Miscellaneous
         */

        public static string AutoDetectGamePath()
        {
            /*
             * I could totally search through every single folder on a user's computer, but that would take way too long. So, I'll take shortcuts.
             * This is not about to find a path for every user 100% of the time, but an attempt to find a path for MOST users in the shortest amount of time.
             * If it can't find the path, the user likely knows enough about their computer to find it themselves. Even if it's a bit inconvenient.
             */

            // Search every drive:
            foreach (DriveInfo d in DriveInfo.GetDrives())
            {
                // Only search fixed drives:
                if (d.DriveType != DriveType.Fixed)
                    continue;

                // Search for "default" paths that are the most common:
                string steamDefaultPath = Path.Combine(d.Name, @"Program Files (x86)\Steam\steamapps\common\Fallout76");
                if (GameInstance.ValidateGamePath(steamDefaultPath))
                {
                    switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(steamDefaultPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            return steamDefaultPath;
                        case DialogResult.Cancel:
                            return null;
                    }
                }

                // Bethesda.net launcher - no longer in use
                /*
                string bethNetDefaultPath = Path.Combine(d.Name, @"Program Files (x86)\Bethesda.net Launcher\games\Fallout76");
                if (GameInstance.ValidateGamePath(bethNetDefaultPath))
                {
                    switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(bethNetDefaultPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            return bethNetDefaultPath;
                        case DialogResult.Cancel:
                            return null;
                    }
                }
                */

                // Old Xbox default path
                string xboxModifiablePath = Path.Combine(d.Name, @"Program Files\ModifiableWindowsApps\Fallout 76");
                if (GameInstance.ValidateGamePath(xboxModifiablePath))
                {
                    switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(xboxModifiablePath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            return xboxModifiablePath;
                        case DialogResult.Cancel:
                            return null;
                    }
                }

                // New Xbox default path
                string xboxDefaultPath = Path.Combine(d.Name, @"XboxGames\Fallout 76\Content");
                if (GameInstance.ValidateGamePath(xboxDefaultPath))
                {
                    switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(xboxDefaultPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            return xboxDefaultPath;
                        case DialogResult.Cancel:
                            return null;
                    }
                }

                // When you create a library on a drive through Steam's 
                string steamLibraryPath = Path.Combine(d.Name, @"SteamLibrary\steamapps\common\Fallout76");
                if (GameInstance.ValidateGamePath(steamLibraryPath))
                {
                    switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(steamLibraryPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            return steamLibraryPath;
                        case DialogResult.Cancel:
                            return null;
                    }
                }

                // Search every top-level folder on the drive:
                foreach (string path in Directory.EnumerateDirectories(d.Name))
                {
                    if (GameInstance.ValidateGamePath(path))
                    {
                        switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(path).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            case DialogResult.Yes:
                                return path;
                            case DialogResult.Cancel:
                                return null;
                        }
                    }

                    // Search for a steamapps folder:
                    string steamSubDirPath = Path.Combine(path, @"steamapps\common\Fallout76");
                    if (GameInstance.ValidateGamePath(steamSubDirPath))
                    {
                        switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(steamSubDirPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            case DialogResult.Yes:
                                return steamSubDirPath;
                            case DialogResult.Cancel:
                                return null;
                        }
                    }

                    // New Xbox path:
                    string xboxSubDirPath = Path.Combine(d.Name, @"Fallout 76\Content");
                    if (GameInstance.ValidateGamePath(xboxSubDirPath))
                    {
                        switch (MsgBox.Get("gamePathAutoDetectPathFound").FormatText(xboxSubDirPath).Show(MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            case DialogResult.Yes:
                                return xboxSubDirPath;
                            case DialogResult.Cancel:
                                return null;
                        }
                    }
                }
            }

            return null;
        }

        private void checkBoxSkipProfileManager_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.SkipProfileManager = !checkBoxShowProfileManager.Checked;
        }
    }
}
