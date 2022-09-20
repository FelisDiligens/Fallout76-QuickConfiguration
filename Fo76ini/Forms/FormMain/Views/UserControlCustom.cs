using FastColoredTextBoxNS;
using Fo76ini.Profiles;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Fo76ini.Forms.FormMain.Tabs
{
    public partial class UserControlCustom : UserControl
    {
        // Game profile
        private GameInstance game;

        // Colors for syntax highlighting
        TextStyle comment = new TextStyle(Brushes.DarkGreen, null, FontStyle.Italic);
        TextStyle section = new TextStyle(Brushes.RoyalBlue, null, FontStyle.Bold);
        TextStyle key = new TextStyle(Brushes.RoyalBlue, null, FontStyle.Regular);
        TextStyle equalsSign = new TextStyle(Brushes.DarkGreen, null, FontStyle.Regular);
        TextStyle valueString = new TextStyle(Brushes.OrangeRed, null, FontStyle.Regular);
        TextStyle valueNumber = new TextStyle(Brushes.OrangeRed, null, FontStyle.Bold);
        Style[] styles;

        // Autocomplete
        AutocompleteMenu menu;

        public UserControlCustom()
        {
            InitializeComponent();

            if (this.DesignMode)
                return;

            // Handle translations:
            Translation.LanguageChanged += Translation_LanguageChanged;

            ProfileManager.ProfileChanged += OnProfileChanged;

            // Syntax highlighting
            styles = new Style[] { comment, section, key, equalsSign, valueString, valueNumber };

            /*
             * Autocomplete
             */

            // Load autocomplete.txt:
            List<string> autocompleteItems = new List<string>();
            string autocompleteTxtPath = Path.Combine(Shared.AppInstallationFolder, "autocomplete.txt");
            if (File.Exists(autocompleteTxtPath))
                autocompleteItems.AddRange(File.ReadAllText(autocompleteTxtPath).Split(','));

            // Setup autocomplete menu:
            menu = new AutocompleteMenu(this.textBoxCustom);
            menu.Items.SetAutocompleteItems(autocompleteItems);

            menu.MinFragmentLength = 2;
            menu.Items.MaximumSize = new Size(300, 300);
            menu.Items.Width = 300;
        }

        private void Translation_LanguageChanged(object sender, TranslationEventArgs e)
        {
            Translation translation = (Translation)sender;

            this.labelCustomTitle.Font = CustomFonts.GetHeaderFont();
        }

        #region Event handler

        private void OnProfileChanged(object sender, ProfileEventArgs e)
        {
            this.game = e.ActiveGameInstance;
            LoadFileNameEntries();
        }

        private void comboBoxCustomFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            OpenFile(GetFileName());
        }

        private void textBoxCustom_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!this.buttonCustomSave.Text.EndsWith("*"))
                this.buttonCustomSave.Text += "*";

            /*
             * Syntax highlighting:
             */

            e.ChangedRange.ClearStyle(styles);

            // ** Comment **
            // Begins with ";" or "#"
            e.ChangedRange.SetStyle(comment, IniFile.CommentRegex.ToString(), RegexOptions.Multiline);

            // ** Section **
            e.ChangedRange.SetStyle(section, @"^\s*\[.+\]\s*$", RegexOptions.Multiline);

            // ** = **
            e.ChangedRange.SetStyle(equalsSign, @"=", RegexOptions.Multiline);

            // ** Key **
            e.ChangedRange.SetStyle(key, @"^\s*.+=", RegexOptions.Multiline);

            // ** Value **
            e.ChangedRange.SetStyle(valueNumber, @"=[\d\.]+\s*$", RegexOptions.Multiline);
            e.ChangedRange.SetStyle(valueString, @"=.+\s*$", RegexOptions.Multiline);
        }

        private void textBoxCustom_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.K))
            {
                //forced show (MinFragmentLength will be ignored)
                menu.Show(true);
                e.Handled = true;
            }
            else if (e.KeyData == (Keys.Control | Keys.S))
            {
                SaveFile(GetFileName());
            }
        }

        private void buttonCustomSave_Click(object sender, EventArgs e)
        {
            SaveFile(GetFileName());
        }

        #endregion

        #region Save/load ini files

        private void LoadFileNameEntries()
        {
            this.comboBoxCustomFile.Items.Clear();
            this.comboBoxCustomFile.Items.AddRange(new string[] {
                $"{game.IniPrefix}.ini",
                $"{game.IniPrefix}Prefs.ini",
                $"{game.IniPrefix}Custom.ini"
            });
            this.comboBoxCustomFile.SelectedIndex = 0;
        }

        private String GetFileName()
        {
            switch (this.comboBoxCustomFile.SelectedIndex)
            {
                case 0:
                    return $"{game.IniPrefix}.add.ini";
                case 1:
                    return $"{game.IniPrefix}Prefs.add.ini";
                case 2:
                    return $"{game.IniPrefix}Custom.add.ini";
                default:
                    return null;
            }
        }

        private void OpenFile(string fileName)
        {
            String path = Path.Combine(IniFiles.ParentPath, fileName);

            if (File.Exists(path))
                this.textBoxCustom.Text = File.ReadAllText(path);
            else
                this.textBoxCustom.Text = "";

            this.buttonCustomSave.Text = this.buttonCustomSave.Text.TrimEnd('*');
        }

        private void SaveFile(string fileName)
        {
            String text = this.textBoxCustom.Text;
            String path = Path.Combine(IniFiles.ParentPath, fileName);

            if (text == "")
            {
                if (File.Exists(path))
                    File.Delete(path);
            }
            else
            {
                File.WriteAllText(path, text);
            }

            if (this.buttonCustomSave.Text.EndsWith("*"))
                this.buttonCustomSave.Text = this.buttonCustomSave.Text.TrimEnd('*');
        }

        #endregion
    }
}
