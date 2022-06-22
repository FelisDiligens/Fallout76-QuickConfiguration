using BrightIdeasSoftware;
using Fo76ini.Interface;
using Fo76ini.Mods;
using Fo76ini.NexusAPI;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            public string ModInfo = "";
            public string ModInfoDescription = "";
            public string InstallStatus = "";
            public string InstallInfo = "";
            public Color ModInfoFG = Color.Black;
            public Color InstallStatusFG = Color.Black;
            public Color InstallInfoFG = Color.Black;

            public ModListRow(ManagedMod mod)
            {
                this.mod = mod;
                NMMod remoteMod = mod.RemoteInfo;

                this.Enabled = mod.Enabled;

                bool showRemoteModNames = IniFiles.Config.GetBool("Mods", "bShowRemoteModNames", false);

                /*
                 * Mod name & info
                 */


                if (remoteMod != null)
                {
                    this.ModInfo = showRemoteModNames ? remoteMod.Title : mod.Title;

                    // Version
                    if (mod.Version != "")
                    {
                        this.ModInfoDescription += $"Version {mod.Version} by {mod.RemoteInfo.Author}";

                        if (remoteMod.LatestVersion != mod.Version)
                        {
                            // Update available:
                            this.ModInfoDescription = $"{Localization.GetString("updateAvailable")}: {remoteMod.LatestVersion}";
                            this.ModInfoFG = Color.Fuchsia;
                        }
                    }
                    else
                    {
                        // Author
                        this.ModInfoDescription = "by " + mod.RemoteInfo.Author;
                    }
                }
                else
                {
                    this.ModInfo = mod.Title;

                    if (mod.Version != "")
                        this.ModInfoDescription = $"Version {mod.Version} ";
                }


                /*
                 * Installation status:
                 */

                if (mod.isDeploymentNecessary())
                {
                    this.InstallStatusFG = Color.Blue;
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
                    this.InstallStatusFG = mod.Enabled ? Color.Green : Color.Red;
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
                            }
                            else
                            {
                                installPreset = Localization.GetString("modsTablePresetSoundFX"); // Sound FX
                            }
                            break;
                        case ManagedMod.ArchiveFormat.Textures:
                            installPreset = Localization.GetString("modsTablePresetTextures");    // Textures
                            break;
                        case ManagedMod.ArchiveFormat.Auto:
                            installPreset = Localization.GetString("auto");                       // Auto-detect
                            break;
                        default:
                            installPreset = Localization.GetString("unknown");                    // Please select
                            break;
                    }
                    if (mod.Compression == ManagedMod.ArchiveCompression.Auto)
                    {
                        installPreset = Localization.GetString("auto");                           // Auto-detect
                    }
                }

                // How is the mod (going to be) installed?
                switch (mod.Method)
                {
                    case ManagedMod.DeploymentMethod.BundledBA2:
                        this.InstallInfo = "Bundle into \"Data\\Bundled*.ba2\".";
                        this.InstallInfoFG = Color.OrangeRed;
                        break;
                    case ManagedMod.DeploymentMethod.SeparateBA2:
                        this.InstallInfo = String.Format("Pack into \"Data\\{0}\" with preset \"{1}\".", mod.ArchiveName, installPreset);
                        this.InstallInfoFG = Color.Indigo;
                        break;
                    case ManagedMod.DeploymentMethod.LooseFiles:
                        this.InstallInfo = String.Format("Copy files to \"{0}\".", mod.RootFolder);
                        this.InstallInfoFG = Color.MediumVioletRed;
                        break;
                }
            }
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
            this.objectListViewMods.RowHeight = 36;
            describedTaskRenderer.DescriptionAspectName = "ModInfoDescription";
            this.olvColumnModInfo.Renderer = describedTaskRenderer;

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

        private void objectListViewMods_FormatRow(object sender, FormatRowEventArgs e)
        {
            e.Item.Font = new Font(this.objectListViewMods.Font, FontStyle.Regular);
        }

        private void objectListViewMods_FormatCell(object sender, FormatCellEventArgs e)
        {
            ModListRow row = (ModListRow)e.Model;
            if (e.ColumnIndex == this.olvColumnModInfo.Index)
            {
                e.SubItem.ForeColor = row.ModInfoFG;
            }
            else if (e.ColumnIndex == this.olvColumnInstallStatus.Index)
            {
                e.SubItem.ForeColor = row.InstallStatusFG;
            }
            else if (e.ColumnIndex == this.olvColumnInstallInfo.Index)
            {
                e.SubItem.ForeColor = row.InstallInfoFG;
            }
            e.SubItem.Font = new Font(this.objectListViewMods.Font, FontStyle.Regular);
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
            // Determine drop index from mouse location:
            // (there literally isn't a predefined property, so we have to calculate it)
            int mouseY = e.MouseLocation.Y; // Origin (0 | 0) is the top left corner of the ListView
            int headerHeight = this.objectListViewMods.TopItem.Bounds.Top; // usually 22px
            int rowHeight = this.objectListViewMods.RowHeight + 1; // + 1px because of the grid border
            int scrollYOffset = this.objectListViewMods.LowLevelScrollPosition.Y * rowHeight; // For some reason, it uses rows instead of pixels in LowLevelScrollPosition.Y...
            int arbitraryOffset = 3; // I don't know where these arbitrary few pixels come from but I have to add them for accuracy.
            
            int dropIndex = (
                mouseY - headerHeight // Gets the y position relative to the end of the sticky header
                + scrollYOffset       // Add the out of view rows that we need to count in
                + arbitraryOffset     // Add some necessary but arbitrary offset
                ) / rowHeight;        // Divide it by the row height to get from pixels to an index (or row count)

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
                InstallBulkThreaded(files);
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
                row.mod.Freeze = false;
        }

        #endregion
    }
}
