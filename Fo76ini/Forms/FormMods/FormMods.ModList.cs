using BrightIdeasSoftware;
using Fo76ini.Interface;
using Fo76ini.Mods;
using Fo76ini.NexusAPI;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Fo76ini
{
    partial class FormMods
    {
        /*
         * Rendering of the list
         */
        #region Rendering

        public DescribedTaskRenderer describedTaskRenderer;

        class ModListRow
        {
            public ManagedMod mod;

            public bool Enabled = false;
            public bool IsUpdateAvailable = false;

            /*
             * Standard style columns
             */
            public string ModTitle = "";
            public string ModDescription = "";
            public string InstallStatus = "";
            public string InstallInfo = "";

            /*
             * Alternative style columns
             */
            public string ModVersion = "";
            public string InstallMethod = "";
            public string InstallInto = "";
            public string ArchiveName = "";
            public string ArchivePreset = "";
            public string IsFrozen = "";

            /*
             * Colors
             */
            public Color InstallStatusColor = Color.Black;
            public Color InstallMethodColor = Color.Black;
            public Color ArchivePresetColor = Color.Black;
            public Color AltFrozenColor = Color.Black;

            public ModListRow(ManagedMod mod)
            {
                this.mod = mod;
                NMMod remoteMod = mod.RemoteInfo;

                this.Enabled = mod.Enabled;

                bool showRemoteModNames = Configuration.Mods.ShowRemoteModNames;


                /*
                 * Mod name & info
                 */

                this.ModVersion = mod.Version;

                if (remoteMod != null)
                {
                    this.ModTitle = showRemoteModNames ? remoteMod.Title : mod.Title;

                    // Version
                    if (mod.Version != "")
                    {
                        this.ModDescription += $"Version {mod.Version} by {mod.RemoteInfo.Author}";

                        if (ModHelpers.CompareVersion(mod.Version, remoteMod.LatestVersion) < 0)
                        {
                            // Update available:
                            this.ModDescription = $"{Localization.GetString("updateAvailable")}: {remoteMod.LatestVersion}";
                            this.ModVersion = $"{mod.Version} ({remoteMod.LatestVersion})";
                            this.IsUpdateAvailable = true;
                        }
                    }
                    else
                    {
                        // Author
                        this.ModDescription = "by " + mod.RemoteInfo.Author;
                    }
                }
                else
                {
                    this.ModTitle = mod.Title;

                    if (mod.Version != "")
                        this.ModDescription = $"Version {mod.Version} ";
                }


                /*
                 * Installation status:
                 */

                if (mod.IsDeploymentNecessary())
                {
                    this.InstallStatusColor = Color.Blue;
                    if (mod.Enabled && !mod.Deployed)
                    {
                        this.InstallStatus = Localization.GetString("modTablePendingInstallation");
                    }
                    else if (!mod.Enabled && mod.Deployed)
                    {
                        this.InstallStatus = Localization.GetString("modTablePendingRemoval");
                    }
                    else
                    {
                        this.InstallStatus = Localization.GetString("modTablePendingChanges");
                    }
                    if (!mod.Frozen && mod.Freeze)
                    {
                        this.InstallStatus += $" ({Localization.GetString("modTableFreeze")})";
                    }
                }
                else
                {
                    this.InstallStatus = mod.Enabled ? Localization.GetString("enabled") : Localization.GetString("disabled");
                    this.InstallStatusColor = mod.Enabled ? Color.Green : Color.Red;
                    if (mod.Freeze && mod.Frozen)
                    {
                        this.InstallStatus += $" ({Localization.GetString("modTableFrozen")})";
                    }
                }


                /*
                 * Installation information:
                 */

                // Which preset?
                string installPreset = "?";
                if (mod.Method == ManagedMod.DeploymentMethod.SeparateBA2)
                {
                    bool isCompressed = mod.Compression == ManagedMod.ArchiveCompression.Compressed;
                    switch (mod.Format)
                    {
                        case ManagedMod.ArchiveFormat.General:
                            if (isCompressed)
                            {
                                installPreset = Localization.GetString("modsTablePresetGeneral"); // General
                                this.ArchivePresetColor = Color.OrangeRed;
                            }
                            else
                            {
                                installPreset = Localization.GetString("modsTablePresetSoundFX"); // Sound FX
                                this.ArchivePresetColor = Color.RoyalBlue;
                            }
                            break;
                        case ManagedMod.ArchiveFormat.Textures:
                            installPreset = Localization.GetString("modsTablePresetTextures");    // Textures
                            this.ArchivePresetColor = Color.DarkGreen;
                            break;
                        case ManagedMod.ArchiveFormat.Auto:
                            installPreset = Localization.GetString("auto");                       // Auto-detect
                            this.ArchivePresetColor = Color.DimGray;
                            break;
                        default:
                            installPreset = Localization.GetString("unknown");                    // Please select
                            this.ArchivePresetColor = Color.Red;
                            break;
                    }
                    if (mod.Compression == ManagedMod.ArchiveCompression.Auto)
                    {
                        installPreset = Localization.GetString("auto");                           // Auto-detect
                        this.ArchivePresetColor = Color.DimGray;
                    }

                    this.ArchivePreset = installPreset;
                }

                // How is the mod (going to be) installed?
                switch (mod.Method)
                {
                    case ManagedMod.DeploymentMethod.BundledBA2:
                        this.InstallInfo = String.Format(Localization.GetString("modTableInstallInfoBundledBA2"), "\"Data\\Bundled*.ba2\"");
                        this.InstallMethod = Localization.GetString("modsTableTypeBundled");
                        this.InstallInto = "\"Data\"";
                        this.ArchiveName = "Bundled*.ba2";
                        this.InstallMethodColor = Color.OrangeRed;
                        break;
                    case ManagedMod.DeploymentMethod.SeparateBA2:
                        this.InstallInfo = String.Format(Localization.GetString("modTableInstallInfoSeparateBA2"), $"\"Data\\{mod.ArchiveName}\"", $"\"{installPreset}\"");
                        this.InstallMethod = Localization.GetString("modsTableTypeSeparate");
                        this.InstallInto = "\"Data\"";
                        this.ArchiveName = mod.ArchiveName;
                        if (mod.Frozen)
                        {
                            this.IsFrozen = Localization.GetString("yes");
                            this.InstallMethod = Localization.GetString("modsTableTypeSeparateFrozen");
                            this.AltFrozenColor = Color.DarkCyan;
                        }
                        else if (mod.Freeze)
                        {
                            this.IsFrozen = Localization.GetString("modTableFrozenPending");
                            this.AltFrozenColor = Color.Blue;
                        }
                        else
                        {
                            this.IsFrozen = Localization.GetString("no");
                        }
                        this.InstallMethodColor = Color.Indigo;
                        break;
                    case ManagedMod.DeploymentMethod.LooseFiles:
                        this.InstallInfo = String.Format(Localization.GetString("modTableInstallInfoLooseFiles"), $"\"{mod.RootFolder}\"");
                        this.InstallMethod = Localization.GetString("modsTableTypeLoose");
                        this.InstallInto = $"\"{mod.RootFolder}\"";
                        this.InstallMethodColor = Color.MediumVioletRed;
                        break;
                }
            }
        }

        /*
         * Format rows/cells with colors:
         */

        private void objectListViewMods_FormatRow(object sender, FormatRowEventArgs e)
        {
            e.Item.Font = new Font(this.objectListViewMods.Font, FontStyle.Regular);
        }

        private void objectListViewMods_FormatCell(object sender, FormatCellEventArgs e)
        {
            ModListRow row = (ModListRow)e.Model;

            e.SubItem.Font = new Font(this.objectListViewMods.Font, FontStyle.Regular);

            // "Mod info & description":
            if (e.ColumnIndex == this.olvColumnModInfo.Index)
            {
                if (row.IsUpdateAvailable && currentStyle == ModListStyle.Standard)
                    e.SubItem.ForeColor = Color.Fuchsia;
                else if (currentStyle == ModListStyle.Alternative)
                    e.SubItem.ForeColor = row.InstallStatusColor;
            }

            // "Status" (e.g. Enabled/Disabled/Pending):
            else if (e.ColumnIndex == this.olvColumnInstallStatus.Index)
            {
                e.SubItem.ForeColor = row.InstallStatusColor;
            }

            // "Installation" (e.g. Pack into ...):
            else if (e.ColumnIndex == this.olvColumnInstallInfo.Index)
            {
                e.SubItem.ForeColor = row.InstallMethodColor;
            }

            // "Version" (alternate style):
            else if (e.ColumnIndex == this.olvColumnAltModVersion.Index)
            {
                if (row.IsUpdateAvailable)
                {
                    e.SubItem.ForeColor = Color.Fuchsia;
                    e.SubItem.Font = new Font(this.objectListViewMods.Font, FontStyle.Bold);
                }
                else if (row.mod.RemoteInfo != null)
                {
                    e.SubItem.ForeColor = Color.Green;
                }
            }

            // "Method" (alternate style):
            else if (e.ColumnIndex == this.olvColumnAltInstallMethod.Index)
            {
                e.SubItem.ForeColor = row.InstallMethodColor;
            }

            // "Archive preset" (alternate style):
            else if (e.ColumnIndex == this.olvColumnAltArchivePreset.Index)
            {
                e.SubItem.ForeColor = row.ArchivePresetColor;
            }

            // "Install into" (alternate style):
            else if (e.ColumnIndex == this.olvColumnAltInstallInto.Index)
            {
                if (row.mod.Method != ManagedMod.DeploymentMethod.LooseFiles)
                {
                    e.SubItem.ForeColor = Color.Silver;
                    e.SubItem.Font = new Font(this.objectListViewMods.Font, FontStyle.Italic);
                }
            }

            // "Archive name" (alternate style):
            else if (e.ColumnIndex == this.olvColumnAltArchiveName.Index)
            {
                if (row.mod.Method != ManagedMod.DeploymentMethod.SeparateBA2)
                {
                    e.SubItem.ForeColor = Color.Silver;
                    e.SubItem.Font = new Font(this.objectListViewMods.Font, FontStyle.Italic);
                }
            }

            // "Frozen?" (alternate style):
            else if (e.ColumnIndex == this.olvColumnAltIsFrozen.Index)
            {
                e.SubItem.ForeColor = row.AltFrozenColor;
            }
        }

        public List<ColumnHeader> CommonHeaders = new List<ColumnHeader>();
        public List<ColumnHeader> StandardStyleHeaders = new List<ColumnHeader>();
        public List<ColumnHeader> AlternativeStyleHeaders = new List<ColumnHeader>();

        public enum ModListStyle
        {
            Standard = 0,
            Alternative = 1
        }

        public ModListStyle currentStyle = ModListStyle.Standard;

        public void SetOLVStyle(ModListStyle style)
        {
            this.objectListViewMods.Columns.Clear();
            this.objectListViewMods.Columns.AddRange(CommonHeaders.ToArray());

            switch (style)
            {
                case ModListStyle.Standard:
                    this.objectListViewMods.Columns.AddRange(StandardStyleHeaders.ToArray());
                    this.olvColumnModInfo.Renderer = this.describedTaskRenderer;
                    this.objectListViewMods.RowHeight = 36;
                    break;
                case ModListStyle.Alternative:
                    this.objectListViewMods.Columns.AddRange(AlternativeStyleHeaders.ToArray());
                    this.olvColumnModInfo.Renderer = this.olvColumnAltModVersion.Renderer;
                    this.objectListViewMods.RowHeight = 18;
                    break;
            }

            this.currentStyle = style;
        }

        private void radioButtonModsUseNewList_CheckedChanged(object sender, EventArgs e)
        {
            this.SetOLVStyle(ModListStyle.Standard);
            Configuration.Mods.ModListStyle = ModListStyle.Standard;
            this.UpdateModList();
        }

        private void radioButtonModsUseOldList_CheckedChanged(object sender, EventArgs e)
        {
            this.SetOLVStyle(ModListStyle.Alternative);
            Configuration.Mods.ModListStyle = ModListStyle.Alternative;
            this.UpdateModList();
        }

        public void InitializeObjectListView()
        {
            // Format cells, so we can use colors:
            this.objectListViewMods.FormatCell += objectListViewMods_FormatCell;
            this.objectListViewMods.FormatRow += objectListViewMods_FormatRow;
            this.objectListViewMods.UseCellFormatEvents = true;

            // Add a custom renderer, so we can have a mod title and description:
            describedTaskRenderer = new DescribedTaskRenderer();
            describedTaskRenderer.TitleFont = new Font("Tahoma", 10, FontStyle.Bold); // , FontStyle.Bold
            describedTaskRenderer.DescriptionFont = new Font("Tahoma", 9);
            describedTaskRenderer.UseGdiTextRendering = true;
            describedTaskRenderer.DescriptionAspectName = "ModDescription";

            // Mod list style
            CommonHeaders.Add(this.olvColumnCheckbox);
            CommonHeaders.Add(this.olvColumnModInfo);

            StandardStyleHeaders.Add(this.olvColumnInstallStatus);
            StandardStyleHeaders.Add(this.olvColumnInstallInfo);

            AlternativeStyleHeaders.Add(this.olvColumnAltModVersion);
            AlternativeStyleHeaders.Add(this.olvColumnAltInstallMethod);
            AlternativeStyleHeaders.Add(this.olvColumnAltInstallInto);
            AlternativeStyleHeaders.Add(this.olvColumnAltArchiveName);
            AlternativeStyleHeaders.Add(this.olvColumnAltArchivePreset);
            AlternativeStyleHeaders.Add(this.olvColumnAltIsFrozen);
            SetOLVStyle(ModListStyle.Standard);
            // SetOLVStyle(Configuration.Mods.ModListStyle);


            /*
             * Drag & drop:
             */

            // Enable drag and drop for rearrangment and for dropping files:
            //RearrangingDropSink dropSink = new RearrangingDropSink(false); // The false parameter says that this sink will not accept drags from other ObjectListViews.
            SimpleDropSink dropSink = new SimpleDropSink();
            dropSink.CanDropBetween = true;
            dropSink.CanDropOnBackground = true; // true?
            dropSink.CanDropOnItem = false;
            dropSink.CanDropOnSubItem = false;
            this.objectListViewMods.DragSource = new SimpleDragSource();
            this.objectListViewMods.DropSink = dropSink;

            // Listen to drag and drop events for rearrangment:
            this.objectListViewMods.MouseUp += FormMods_MouseUp;
            this.objectListViewMods.ItemDrag += objectListViewMods_ItemDrag;
            dropSink.ModelCanDrop += this.objectListViewMods_ModelCanDrop;
            dropSink.ModelDropped += this.objectListViewMods_ModelDropped;

            // Listen to drag and drop events for files:
            dropSink.CanDrop += this.objectListViewMods_CanDrop;
            dropSink.Dropped += this.objectListViewMods_Dropped;


            /*
             * Theme:
             */

            if (Theming.CurrentTheme == ThemeType.Dark)
            {
                var headerstyle = new HeaderFormatStyle();
                headerstyle.SetBackColor(Color.FromArgb(40, 40, 40));
                headerstyle.SetForeColor(Color.White);
                this.objectListViewMods.HeaderFormatStyle = headerstyle;
            }
        }

        public void UpdateObjectListView()
        {
            // Remember scroll position:
            Point point = this.objectListViewMods.LowLevelScrollPosition;

            // Remember selected rows:
            List<int> selectedIndices = GetSelectedIndices();

            // Generate a list of rows:
            List<ModListRow> list = new List<ModListRow>();
            foreach (ManagedMod mod in this.Mods)
            {
                list.Add(new ModListRow(mod));
            }

            // Populate list view:
            this.objectListViewMods.SetObjects(list);
            this.objectListViewMods.UpdateObjects(list);

            // Restore selected rows:
            if (selectedIndices.Count > 0)
                suppressSelectionChangedEventOnce = true;
            SetSelectedIndices(selectedIndices);

            // Restore scroll position:
            this.objectListViewMods.LowLevelScroll(
                point.X,
                point.Y * this.objectListViewMods.RowHeight // For some reason, it uses rows in LowLevelScrollPosition, but pixels in LowLevelScroll...
            );
        }
        #endregion


        /*
         * Manage the list
         * e.g. Getter/Setter
         */
        #region Managing

        private List<int> GetSelectedIndices()
        {
            List<int> selectedIndices = new List<int>();
            foreach (ListViewItem item in this.objectListViewMods.SelectedItems)
                selectedIndices.Add(item.Index);
            return selectedIndices;
        }

        private void SetSelectedIndices(List<int> selectedIndices)
        {
            foreach (ListViewItem item in this.objectListViewMods.Items)
                item.Selected = selectedIndices.Contains(item.Index);
        }

        private void SetSelectedIndex(int selectedIndex)
        {
            foreach (ListViewItem item in this.objectListViewMods.Items)
                item.Selected = item.Index == selectedIndex;
        }

        private void SelectAll()
        {
            foreach (ListViewItem item in this.objectListViewMods.Items)
                item.Selected = true;
        }

        private void DeselectAll()
        {
            foreach (ListViewItem item in this.objectListViewMods.Items)
                item.Selected = false;
        }

        private ModListRow GetSelectedRow()
        {
            if (this.objectListViewMods.SelectedObjects.Count == 1)
                return (ModListRow)this.objectListViewMods.SelectedObjects[0];
            return null;
        }

        private int GetSelectedRowsCount()
        {
            return this.objectListViewMods.SelectedObjects.Count;
        }

        private bool AreMultipleRowsSelected()
        {
            return GetSelectedRowsCount() > 1;
        }

        private bool IsOnlyOneRowSelected()
        {
            return GetSelectedRowsCount() == 1;
        }

        #endregion

        /*
         * Drag and drop event handler
         */
        #region Drag & drop

        /// <summary>
        /// Determine drop index from mouse location.
        /// </summary>
        private int DetermineDropIndex(Point mouseLocation)
        {
            // Determine drop index from mouse location:
            // (there literally isn't a predefined property, so we have to calculate it)
            int mouseY = mouseLocation.Y; // Origin (0 | 0) is the top left corner of the ListView
            int headerHeight = this.objectListViewMods.TopItem.Bounds.Top; // usually 22px
            int rowHeight = this.objectListViewMods.RowHeight + 1; // + 1px because of the grid border
            int scrollYOffset = this.objectListViewMods.LowLevelScrollPosition.Y * rowHeight; // For some reason, it uses rows instead of pixels in LowLevelScrollPosition.Y...
            int arbitraryOffset = 3; // I don't know where these arbitrary few pixels come from but I have to add them for accuracy.

            int dropIndex = (
                mouseY - headerHeight // Gets the y position relative to the end of the sticky header
                + scrollYOffset       // Add the out of view rows that we need to count in
                + arbitraryOffset     // Add some necessary but arbitrary offset
                ) / rowHeight;        // Divide it by the row height to get from pixels to an index (or row count)

            return dropIndex;
        }

        private List<ModListRow> _nonDraggedRows = new List<ModListRow>();
        private List<ModListRow> _draggedRows = new List<ModListRow>();
        private bool _rowsBeingDragged = false;

        // On drag start: determine mods which are dragged...
        private void objectListViewMods_ItemDrag(object sender, ItemDragEventArgs e)
        {
            _rowsBeingDragged = true;

            // Clear lists:
            _nonDraggedRows.Clear();
            _draggedRows.Clear();

            // Copy list:
            foreach (object row in this.objectListViewMods.Objects)
                _nonDraggedRows.Add((ModListRow)row);

            // Get all dragged rows and remove them from the list:
            foreach (object draggedRow in this.objectListViewMods.SelectedObjects)
            {
                _draggedRows.Add((ModListRow)draggedRow);
                _nonDraggedRows.Remove((ModListRow)draggedRow);
            }

            // Remove from list:
            this.objectListViewMods.RemoveObjects(_draggedRows);
        }

        // On drag over: Can a ListViewItem be dropped in between?
        private void objectListViewMods_ModelCanDrop(object sender, ModelDropEventArgs e)
        {
            if (e.DropTargetIndex != -1)
                e.Effect = DragDropEffects.Move;
            else
                e.Effect = DragDropEffects.None;
        }

        // On drop: Handle rearrangment of mod entries / rows:
        private void objectListViewMods_ModelDropped(object sender, ModelDropEventArgs e)
        {
            int dropIndex = DetermineDropIndex(e.MouseLocation);

            // Reverse list:
            _draggedRows.Reverse();

            // Rebuild mod list:
            List<ManagedMod> rebuiltList = new List<ManagedMod>();
            foreach (ModListRow row in _nonDraggedRows)
                rebuiltList.Add(row.mod);
            foreach (ModListRow row in _draggedRows)
                rebuiltList.Insert(dropIndex, row.mod);

            // Replace ManagedMods list:
            if (rebuiltList.Count == this.Mods.Mods.Count)
            {
                this.Mods.Clear();
                this.Mods.Mods.AddRange(rebuiltList);
            }

            // Refresh list:
            UpdateObjectListView();

            // Clear lists:
            _nonDraggedRows.Clear();
            _draggedRows.Clear();

            _rowsBeingDragged = false;
        }

        private void FormMods_MouseUp(object sender, MouseEventArgs e)
        {
            // Refresh list:
            if (_rowsBeingDragged)
                UpdateObjectListView();
            _rowsBeingDragged = false;
        }

        /*
         *********************************************************************************
         */

        // On drag over: Can the file(s) be dropped?
        private void objectListViewMods_CanDrop(object sender, OlvDropEventArgs e)
        {
            if (e.DragEventArgs.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        // On drop: Handle dropped file(s)...
        private void objectListViewMods_Dropped(object sender, OlvDropEventArgs e)
        {
            string[] files = (string[])e.DragEventArgs.Data.GetData(DataFormats.FileDrop);
            if (files != null && files.Length > 0)
            {
                int dropIndex = -1;
                if (Mods.Count > 0)
                    dropIndex = DetermineDropIndex(e.MouseLocation);
                InstallBulkThreaded(files, dropIndex);
            }
        }

        #endregion


        /*
         * When the list changes...
         */
        #region Event handler

        // Enable/Disable mod on checked changed:
        private void objectListViewMods_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (isUpdating)
                return;

            if (e.Item.Checked)
                Mods.EnableMod(e.Item.Index);
            else
                Mods.DisableMod(e.Item.Index);

            UpdateUI();
        }

        // Mod(s) selected
        bool suppressSelectionChangedEventOnce = false;
        private void objectListViewMods_SelectionChanged(object sender, EventArgs e)
        {
            if (isUpdating)
                return;

            /*
             * isUpdating workaround is no longer working...
             * We cannot detect whether the user or the program has changed the selection...
             * So the only thing we can do is to "suppress" this event, if the list gets updated.
             * Otherwise, the program will behave in weird ways.
             */
            if (suppressSelectionChangedEventOnce)
            {
                suppressSelectionChangedEventOnce = false;
                return;
            }

            List<ManagedMod> mods = new List<ManagedMod>();
            foreach (object obj in this.objectListViewMods.SelectedObjects)
            {
                ModListRow row = obj as ModListRow;
                mods.Add(row.mod);
            }
            this.EditMods(mods);
        }

        #endregion

        /*
         * Some actions
         */
        #region Actions

        private void OpenSelectedModsFolder()
        {
            // Open the folder if one mod is selected:
            if (IsOnlyOneRowSelected())
            {
                string path = GetSelectedRow().mod.ManagedFolderPath;
                if (Directory.Exists(path))
                    Utils.OpenExplorer(path);
                else
                    MsgBox.Get("modDirNotExist").FormatText(path).Show(MessageBoxIcon.Error);
            }
            // Otherwise open the parent folder (either if none or multiple rows are selected):
            else
            {
                string path = Path.Combine(this.game.GamePath, "Mods");
                if (Directory.Exists(path))
                    Utils.OpenExplorer(path);
            }
        }

        private void MoveSelectedModsUp()
        {
            List<int> selectedIndices = new List<int>();
            foreach (ModListRow row in this.objectListViewMods.SelectedObjects)
                selectedIndices.Add(Mods.MoveModUp(Mods.IndexOf(row.mod)));
            SetSelectedIndices(selectedIndices);
        }

        private void MoveSelectedModsDown()
        {
            List<int> selectedIndices = new List<int>();
            foreach (ModListRow row in this.objectListViewMods.SelectedObjects)
                selectedIndices.Add(Mods.MoveModDown(Mods.IndexOf(row.mod)));
            SetSelectedIndices(selectedIndices);
        }

        private void ToggleCheckboxes()
        {
            // Behavior:
            //  - If at least one mod is unchecked, check all boxes.
            //  - If ALL mods are checked, uncheck all boxes.

            bool state = true;
            foreach (ManagedMod mod in Mods)
                if (!mod.Enabled)
                    state = false;
            
            foreach (ManagedMod mod in Mods)
                mod.Enabled = !state;
        }

        private void DeleteSelectedMods()
        {
            if (IsOnlyOneRowSelected())
            {
                ManagedMod mod = GetSelectedRow().mod;
                DialogResult res = MsgBox.Get("deleteQuestion").FormatTitle(mod.Title).FormatText(mod.Title).Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    DeleteModThreaded(Mods.IndexOf(mod));
            }
            else if (AreMultipleRowsSelected())
            {
                string count = GetSelectedRowsCount().ToString();
                DialogResult res = MsgBox.Get("deleteMultipleQuestion").FormatTitle(count).FormatText(count).Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                    DeleteModsBulkThreaded(GetSelectedIndices());
            }
        }

        private void FreezeSelectedMods()
        {
            foreach (ModListRow row in this.objectListViewMods.SelectedObjects)
                row.mod.Freeze = true;
        }

        private void UnfreezeSelectedMods()
        {
            foreach (ModListRow row in this.objectListViewMods.SelectedObjects)
            {
                ModActions.Unfreeze(row.mod);
                row.mod.Freeze = false;
            }
        }

        #endregion
    }
}
