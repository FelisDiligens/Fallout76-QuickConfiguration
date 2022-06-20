using Fo76ini.Mods;
using Fo76ini.NexusAPI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini
{
    partial class FormMods
    {
        private int old_selectedIndex = -1;
        private List<int> old_selectedIndices = new List<int>();

        public void InitializeOldListView()
        {
            this.listViewMods.ItemCheck += this.listViewMods_ItemCheck;

            /*
             * Drag&Drop
             */
            this.listViewMods.AllowDrop = true;
            this.listViewMods.DragEnter += new DragEventHandler(listViewMods_DragEnter);
            this.listViewMods.DragDrop += new DragEventHandler(listViewMods_DragDrop);
        }

        public void UpdateOldListView()
        {
            /*
             * Iterate one row at a time...
             */

            //UpdateSelectedIndices();
            this.listViewMods.Items.Clear();
            for (int i = 0; i < Mods.Count; i++)
            {
                /*
                 * Define sub-items
                 */

                var type = new ListViewItem.ListViewSubItem();
                var version = new ListViewItem.ListViewSubItem();
                var archiveName = new ListViewItem.ListViewSubItem();
                var rootDir = new ListViewItem.ListViewSubItem();
                var frozen = new ListViewItem.ListViewSubItem();
                var archivePreset = new ListViewItem.ListViewSubItem();


                /*
                 * Define styles
                 */

                Font notApplicable = new Font(
                    archivePreset.Font.Name,
                    archivePreset.Font.Size - 1,
                    FontStyle.Italic,
                    archivePreset.Font.Unit
                );


                /*
                 * Get some info
                 */

                ManagedMod mod = Mods[i];
                NMMod nmMod = mod.RemoteInfo;

                bool enabled = mod.Enabled;


                /*
                 * Fill sub-items
                 */

                // Version:
                if (mod.Version != "")
                {
                    if (nmMod != null)
                    {
                        if (nmMod.LatestVersion != mod.Version)
                        {
                            // Update available:
                            version.Text = $"{mod.Version} ({nmMod.LatestVersion})";
                            version.ForeColor = Color.DarkRed;
                        }
                        else
                        {
                            // Latest version:
                            version.Text = $"{mod.Version}";
                            version.ForeColor = Color.DarkGreen;
                        }
                    }
                    else
                    {
                        version.Text = $"{mod.Version}";
                        version.ForeColor = Color.Gray;
                    }
                }

                // Frozen?
                if (mod.Frozen)
                {
                    frozen.Text = Localization.GetString("yes"); // "Frozen"
                    frozen.ForeColor = Color.DarkCyan;
                }
                else if (mod.Freeze)
                {
                    frozen.Text = Localization.GetString("modTableFrozenPending"); // "Pending"
                    frozen.ForeColor = Color.DarkBlue;
                }
                else
                    frozen.Text = Localization.GetString("no"); // "Thawed"

                // Archive preset
                if (mod.Method == ManagedMod.DeploymentMethod.SeparateBA2)
                {
                    bool isCompressed = mod.Compression == ManagedMod.ArchiveCompression.Compressed;
                    switch (mod.Format)
                    {
                        case ManagedMod.ArchiveFormat.General:
                            if (isCompressed)
                            {
                                archivePreset.Text = Localization.GetString("modsTablePresetGeneral"); // General
                                archivePreset.ForeColor = Color.OrangeRed;
                            }
                            else
                            {
                                archivePreset.Text = Localization.GetString("modsTablePresetSoundFX"); // Sound FX
                                archivePreset.ForeColor = Color.RoyalBlue;
                            }
                            break;
                        case ManagedMod.ArchiveFormat.Textures:
                            archivePreset.Text = Localization.GetString("modsTablePresetTextures");    // Textures
                            archivePreset.ForeColor = Color.DarkGreen;
                            break;
                        case ManagedMod.ArchiveFormat.Auto:
                            archivePreset.Text = Localization.GetString("auto");                       // Auto-detect
                            archivePreset.ForeColor = Color.DimGray;
                            break;
                        default:
                            archivePreset.Text = Localization.GetString("unknown");                    // Please select
                            archivePreset.ForeColor = Color.Red;
                            break;
                    }
                    if (mod.Compression == ManagedMod.ArchiveCompression.Auto)
                    {
                        archivePreset.Text = Localization.GetString("auto");                           // Auto-detect
                        archivePreset.ForeColor = Color.DimGray;
                    }
                }

                // Fill stuff depending on installation type
                switch (mod.Method)
                {
                    /*
                     * Bundled *.ba2 archive
                     */
                    case ManagedMod.DeploymentMethod.BundledBA2:
                        // Installation type
                        type.Text = Localization.GetString("modsTableTypeBundled");
                        type.ForeColor = Color.OrangeRed;

                        // Archive preset
                        archivePreset.Text = Localization.GetString("notApplicable");
                        archivePreset.Font = notApplicable;
                        archivePreset.ForeColor = Color.Silver;

                        // Archive name
                        archiveName.Text = "Bundled*.ba2";
                        archiveName.Font = notApplicable;
                        archiveName.ForeColor = Color.Silver;

                        // Frozen?
                        frozen.Text = Localization.GetString("notApplicable");
                        frozen.Font = notApplicable;
                        frozen.ForeColor = Color.Silver;

                        // Root dir
                        rootDir.Text = "Data";
                        rootDir.Font = notApplicable;
                        rootDir.ForeColor = Color.Silver;
                        break;

                    /*
                     * Separate *.ba2 archive
                     */
                    case ManagedMod.DeploymentMethod.SeparateBA2:
                        // Installation type
                        if (mod.Freeze)
                        {
                            type.Text = Localization.GetString("modsTableTypeSeparateFrozen");
                            type.ForeColor = Color.Teal;
                        }
                        else
                        {
                            type.Text = Localization.GetString("modsTableTypeSeparate");
                            type.ForeColor = Color.Indigo;
                        }

                        // Archive name
                        archiveName.Text = mod.ArchiveName;

                        // Root dir
                        rootDir.Text = "Data";
                        rootDir.Font = notApplicable;
                        rootDir.ForeColor = Color.Silver;
                        break;

                    /*
                     * Loose files
                     */
                    case ManagedMod.DeploymentMethod.LooseFiles:
                        // Installation type
                        type.Text = Localization.GetString("modsTableTypeLoose");
                        type.ForeColor = Color.MediumVioletRed;

                        // Archive preset
                        archivePreset.Text = Localization.GetString("notApplicable");
                        archivePreset.Font = notApplicable;
                        archivePreset.ForeColor = Color.Silver;

                        // Archive name
                        archiveName.Text = Localization.GetString("notApplicable");
                        archiveName.Font = notApplicable;
                        archiveName.ForeColor = Color.Silver;

                        // Frozen?
                        frozen.Text = Localization.GetString("notApplicable");
                        frozen.Font = notApplicable;
                        frozen.ForeColor = Color.Silver;

                        // Root dir
                        rootDir.Text = mod.RootFolder;
                        break;
                }


                /*
                 * Add row with our sub-items
                 */

                ListViewItem modItem = new ListViewItem(mod.Title, i);
                modItem.UseItemStyleForSubItems = false;
                modItem.ForeColor = enabled ? Color.DarkGreen : Color.DarkRed;
                modItem.SubItems.Add(version);
                modItem.SubItems.Add(type);
                //modItem.SubItems.Add(size);
                modItem.SubItems.Add(rootDir);
                modItem.SubItems.Add(archiveName);
                modItem.SubItems.Add(archivePreset);
                modItem.SubItems.Add(frozen);
                modItem.Checked = enabled;
                if (old_selectedIndex == i)
                    modItem.Selected = true;
                if (old_selectedIndices.Contains(i))
                    modItem.Selected = true;

                this.listViewMods.Items.Add(modItem);
            }
        }

        private void UpdateSelectedIndices()
        {
            this.old_selectedIndices.Clear();
            foreach (ListViewItem item in this.listViewMods.SelectedItems)
                this.old_selectedIndices.Add(item.Index);
        }

        private void RestoreSelectedIndices()
        {
            // Doesn't work.
            foreach (ListViewItem item in this.listViewMods.Items)
                if (old_selectedIndices.Contains(item.Index))
                    item.Selected = true;
                else
                    item.Selected = false;
        }


        /*
         * Event handler
         */

        private void listViewMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isUpdating)
                return;

            if (this.listViewMods.SelectedItems.Count > 0)
                old_selectedIndex = this.listViewMods.SelectedItems[0].Index;
            else
                old_selectedIndex = -1;

            // Edit mod:
            UpdateSelectedIndices();
            if (old_selectedIndices.Count() > 0)
                old_EditMods(old_selectedIndices);
        }

        // Drag & Drop
        void listViewMods_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        void listViewMods_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            InstallBulkThreaded(files);
        }

        // Mod enabled/disabled
        private void listViewMods_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (isUpdating)
                return;

            if (e.NewValue == CheckState.Checked)
            {
                Mods.EnableMod(e.Index);
                listViewMods.Items[e.Index].ForeColor = Color.DarkGreen;
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                Mods.DisableMod(e.Index);
                listViewMods.Items[e.Index].ForeColor = Color.DarkRed;
            }

            UpdateStatusStrip();
            if (sidePanelStatus != SidePanelStatus.Closed)
                UpdateSidePanel();
        }
    }
}
