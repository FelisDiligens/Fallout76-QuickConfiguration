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
        TextStyle section = new TextStyle(Brushes.Blue, null, FontStyle.Bold);
        TextStyle key = new TextStyle(Brushes.Blue, null, FontStyle.Regular);
        TextStyle equalsSign = new TextStyle(Brushes.DarkGreen, null, FontStyle.Regular);
        TextStyle valueString = new TextStyle(Brushes.Red, null, FontStyle.Regular);
        TextStyle valueNumber = new TextStyle(Brushes.Red, null, FontStyle.Bold);
        Style[] styles;

        // Autocomplete
        AutocompleteMenu menu;
        #region Autocomplete items
        List<string> autocompleteItems = new List<string>
        {
            // *.ini sections
            "AI",
            "ATX",
            "Actor",
            "Adventure",
            "Animation",
            "Archive",
            "ArchiveDebug",
            "Audio",
            "AudioMenu",
            "BIEvents",
            "BSPathing",
            "Babylon",
            "BackgroundLoad",
            "Bethesda.net",
            "Bnet",
            "Boolean",
            "Breakables",
            "Camera",
            "CameraPath",
            "Camp",
            "Chrome",
            "Client",
            "Cloth",
            "CollisionQuery",
            "Combat",
            "Controls",
            "CopyProtectionStrings",
            "Crafting",
            "Culling",
            "Debug",
            "Decals",
            "DeferredDeleter",
            "Dialogue",
            "Dismemberment",
            "Display",
            "Enlighten",
            "EnlightenAutoFlagging",
            "EnlightenDebug",
            "EnlightenExport",
            "Explosion",
            "FaceGen",
            "Fonts",
            "GamePlay",
            "GamepadLight",
            "Gameplay",
            "General",
            "GeneralWarnings",
            "Graphics",
            "Grass",
            "HAVOK",
            "HairLighting",
            "HeadTracking",
            "IOManager",
            "ImageSpace",
            "Interface",
            "Inventory",
            "LANGUAGE",
            "LOD",
            "LODGeneration",
            "LODGenerationDebugging",
            "LODTerrain",
            "Landscape",
            "LightingShader",
            "Logging",
            "Login",
            "MAIN",
            "MESSAGES",
            "MainRender",
            "MapMenu",
            "Menu",
            "Messages",
            "NavMesh",
            "NavMeshGeneration",
            "Network",
            "NetworkMotion",
            "NuclearWinter",
            "PBR",
            "PRT",
            "PSysLOD",
            "Papyrus",
            "Particles",
            "Pathfinding",
            "Pathing",
            "Performance",
            "Pipboy",
            "Platform",
            "Quest",
            "QuickPlay",
            "RagdollAnim",
            "SSLR",
            "SaveGame",
            "ScreenSplatter",
            "Section",
            "Server",
            "Spawning",
            "StatsD",
            "StreamInstall",
            "Survival",
            "TerrainManager",
            "TestAllCells",
            "Texture",
            "Textures",
            "Trees",
            "Umbra",
            "UserPlacedPackin",
            "VATS",
            "Voice",
            "Water",
            "Weather",
            "Workshop",
            "WorkshopSkipHitZForgiveness"
        };
        #endregion

        public UserControlCustom()
        {
            InitializeComponent();

            if (this.DesignMode)
                return;

            ProfileManager.ProfileChanged += OnProfileChanged;

            this.labelCustomTitle.Font = new Font(CustomFonts.Overseer, 20, FontStyle.Regular);

            // Syntax highlighting
            styles = new Style[] { comment, section, key, equalsSign, valueString, valueNumber };

            // Autocomplete
            menu = new AutocompleteMenu(this.textBoxCustom);
            menu.Items.SetAutocompleteItems(autocompleteItems);

            menu.MinFragmentLength = 2;
            menu.Items.MaximumSize = new Size(200, 300);
            menu.Items.Width = 200;
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
            // Line begins with ";"
            // Inline comments (@";.*") are ignored on purpose.
            e.ChangedRange.SetStyle(comment, @"^\s*;.*", RegexOptions.Multiline);

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
