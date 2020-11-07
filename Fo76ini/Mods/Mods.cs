using Fo76ini.Mods;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Fo76ini
{
    public class ManagedMods
    {
        private static ManagedMods instance = null;
        private static readonly object padlock = new object();

        public static ManagedMods Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new ManagedMods();
                    }
                    return instance;
                }
            }
        }

        private ManagedMods()
        {
            Shared.LoadGameEdition();
            Shared.LoadGamePath();

            //bool nwMode = IniFiles.Instance.GetBool(IniFile.Config, "Mods", "bDisableMods", false);
            //this.ModsDisabled = nwMode;
            //this.WriteDataDirs = IniFiles.Instance.GetBool(IniFile.Config, "Mods", "bWriteSResourceDataDirsFinal", false);
            this.logFile = new Log(Log.GetFilePath("modmanager.log.txt"));
        }

        public List<ManagedMod> Mods = new List<ManagedMod>();
        public ResourceList Resources = new ResourceList();
        //public bool ModsDisabled = false;
        //public bool WriteToF76Custom = true;
        //public bool WriteDataDirs = false;
        public Log logFile;

        /// <summary>
        /// Returns the path where mods get stored. ("Fallout76\Mods")
        /// </summary>
        /// <returns></returns>
        public string GetModsPath()
        {
            return Path.Combine(Shared.GamePath, "Mods");
        }

        /// <summary>
        /// Returns the path to the "Fallout76\Mods\managed.xml"
        /// </summary>
        /// <returns></returns>
        public string GetXMLPath()
        {
            return Path.Combine(GetModsPath(), "managed.xml");
        }

        /// <summary>
        /// Returns the path to the "Fallout76\Mods\resources.txt"
        /// </summary>
        /// <returns></returns>
        public string GetResourcesPath()
        {
            return Path.Combine(GetModsPath(), "resources.txt");
        }

        /// <summary>
        /// Deletes all files of the mod and removes it from the list.
        /// Saves the xml file afterwards.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="done"></param>
        public void DeleteMod(int index, Action done = null)
        {
            ModActions.Delete(this.Mods[index]);
            this.Mods.RemoveAt(index);
            this.Save();
            if (done != null)
                done();
        }

        /// <summary>
        /// Deletes multiple mods and removes them from the list.
        /// Saves the xml file afterwards.
        /// </summary>
        /// <param name="indices"></param>
        /// <param name="done"></param>
        public void DeleteMods(List<int> indices, Action done = null)
        {
            indices = indices.OrderByDescending(i => i).ToList();
            foreach (int index in indices)
            {
                ModActions.Delete(this.Mods[index]);
                this.Mods.RemoveAt(index);
            }
            this.Save();
            if (done != null)
                done();
        }

        /// <summary>
        /// Bulk unfreezes mods.
        /// </summary>
        /// <param name="indices"></param>
        /// <param name="updateProgress"></param>
        /// <param name="done"></param>
        public void UnfreezeMods(List<int> indices, Action<string, int> updateProgress = null, Action done = null)
        {
            foreach (int index in indices)
            {
                ManagedMod mod = this.Mods[index];
                if (updateProgress != null)
                    updateProgress($"Unfreezing {mod.Title}...", (index + 1) / indices.Count() * 100);
                ModActions.Unfreeze(mod);
            }
            if (done != null)
                done();
        }

        /// <summary>
        /// Extracts the archive, copies the original ba2 file, and adds the mod to the list.
        /// Saves the xml file afterwards.
        /// </summary>
        /// <param name="filePath">Path to archive</param>
        /// <param name="updateProgress"></param>
        /// <param name="done"></param>
        public void InstallModArchiveFrozen(string filePath, Action<string, int> updateProgress = null, Action<bool> done = null)
        {
            try
            {
                ManagedMod newMod = ModInstallations.FromArchive(filePath, true);
                this.Mods.Add(newMod);
                this.Save();

                if (done != null)
                    done(true);
            }
            catch (UnauthorizedAccessException ex)
            {
                MsgBox.Get("modsAccessDenied").FormatText("UnauthorizedAccessException: " + ex.Message).Show(MessageBoxIcon.Error);
                this.logFile.WriteLine($"UnauthorizedAccessException occured while importing a folder: {ex.Message}\n{ex.StackTrace}\n");
                if (done != null)
                    done(false);
            }
            catch (Exception ex)
            {
                this.logFile.WriteLine($"Unhandled exception occured while importing a *.ba2 file: {ex.Message}\n{ex.StackTrace}\n");
                if (done != null)
                    done(false);
            }
        }

        /// <summary>
        /// Extracts the archive and adds the mod to the list.
        /// Saves the xml file afterwards.
        /// </summary>
        /// <param name="filePath">Path to archive</param>
        /// <param name="updateProgress"></param>
        /// <param name="done"></param>
        public void InstallModArchive(string filePath, Action<string, int> updateProgress = null, Action<bool> done = null)
        {
            try
            {
                ManagedMod newMod = ModInstallations.FromArchive(filePath, false);
                this.Mods.Add(newMod);
                this.Save();

                if (done != null)
                    done(true);
            }
            catch (Archive2Exception ex)
            {
                ManagedMods.Instance.logFile.WriteLine($"Archive2Exception occured while importing an archive: {ex.Message}\n{ex.StackTrace}\n");
                MsgBox.Get("archive2Error").Show(MessageBoxIcon.Error);
                if (done != null)
                    done(false);
            }
            catch (UnauthorizedAccessException ex)
            {
                this.logFile.WriteLine($"UnauthorizedAccessException occured while importing an archive: {ex.Message}\n{ex.StackTrace}\n");
                MsgBox.Get("modsAccessDenied").FormatText("UnauthorizedAccessException: " + ex.Message).Show(MessageBoxIcon.Error);
                if (done != null)
                    done(false);
            }
            catch (Exception ex)
            {
                this.logFile.WriteLine($"Unhandled exception occured while importing an archive: {ex.Message}\n{ex.StackTrace}\n");
                if (done != null)
                    done(false);
            }
        }

        /// <summary>
        /// Copies the folder and adds the mod to the list.
        /// Saves the xml file afterwards.
        /// </summary>
        /// <param name="folderPath">Path to folder</param>
        /// <param name="updateProgress"></param>
        /// <param name="done"></param>
        public void InstallModFolder(string folderPath, Action<string, int> updateProgress = null, Action<bool> done = null)
        {
            try
            {
                ManagedMod newMod = ModInstallations.FromFolder(folderPath);
                this.Mods.Add(newMod);
                this.Save();

                if (done != null)
                    done(true);
            }
            catch (Archive2Exception ex)
            {
                ManagedMods.Instance.logFile.WriteLine($"Archive2Exception occured while importing a folder: {ex.Message}\n{ex.StackTrace}\n");
                MsgBox.Get("archive2Error").Show(MessageBoxIcon.Error);
                if (done != null)
                    done(false);
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                MsgBox.Get("modsAccessDenied").FormatText("UnauthorizedAccessException: " + ex.Message).Show(MessageBoxIcon.Error);
                this.logFile.WriteLine($"UnauthorizedAccessException occured while importing a folder: {ex.Message}\n{ex.StackTrace}\n");
                if (done != null)
                    done(false);
                return;
            }
            catch (Exception ex)
            {
                this.logFile.WriteLine($"Unhandled exception occured while importing a folder: {ex.Message}\n{ex.StackTrace}\n");
                if (done != null)
                    done(false);
                return;
            }
        }


        public void EnableMod(int index)
        {
            ToggleMod(index, true);
        }

        public void DisableMod(int index)
        {
            ToggleMod(index, false);
        }

        public void ToggleMod(int index, bool enabled)
        {
            if (this.Mods[index].PendingDiskState.Enabled == enabled)
                return;
            this.Mods[index].PendingDiskState.Enabled = enabled;
        }

        public bool isModEnabled(int index)
        {
            return this.Mods[index].isEnabled();
        }

        /// <summary>
        /// Move a mod from one index to another.
        /// </summary>
        /// <param name="oldIndex"></param>
        /// <param name="newIndex"></param>
        /// <returns></returns>
        private int MoveMod(int oldIndex, int newIndex)
        {
            // https://stackoverflow.com/questions/450233/generic-list-moving-an-item-within-the-list
            ManagedMod mod = this.Mods[oldIndex];

            this.Mods.RemoveAt(oldIndex);

            // TODO: Do we need to change the index? (MoveMod)
            // the actual index could have shifted due to the removal
            // if (newIndex > oldIndex) newIndex--;

            this.Mods.Insert(newIndex, mod);

            return newIndex;
        }

        /// <summary>
        /// Moves the mod one up in the list.
        /// </summary>
        /// <param name="index">Index of the mod that should be moved</param>
        /// <returns>New index of the mod after it got moved</returns>
        public int MoveModUp(int index)
        {
            if (index > 0)
                return MoveMod(index, index - 1);
            return index;
        }

        /// <summary>
        /// Moves the mod one down in the list.
        /// </summary>
        /// <param name="index">Index of the mod that should be moved</param>
        /// <returns>New index of the mod after it got moved</returns>
        public int MoveModDown(int index)
        {
            if (index < this.Mods.Count - 1)
                return MoveMod(index, index + 1);
            return index;
        }

        /// <summary>
        /// Compares CurrentDiskState with PendingDiskState and returns true, if they're different.
        /// </summary>
        /// <returns></returns>
        public bool isDeploymentNecessary()
        {
            foreach (ManagedMod mod in Mods)
                if (mod.isDeploymentNecessary())
                    return true;
            return false;
        }

        /// <summary>
        /// Looks through the resource lists in the *.ini and imports *.ba2 archives.
        /// </summary>
        public void ImportInstalledMods()
        {
            // Get all archives:
            ResourceList IndexFileList = ResourceList.GetResourceIndexFileList();
            ResourceList Archive2List = ResourceList.GetResourceArchive2List();

            /*
             * Prepare list:
             */

            // Add all archives:
            List<string> installedMods = new List<string>();
            installedMods.AddRange(IndexFileList);
            installedMods.AddRange(Archive2List);

            // Remove bundled archives:
            installedMods.Remove("bundled.ba2");
            installedMods.Remove("bundled_textures.ba2");

            // Remove currently managed archives:
            foreach (ManagedMod mod in this.Mods)
                if (mod.CurrentDiskState.Method == ManagedMod.DiskState.DeploymentMethod.SeparateBA2)
                    installedMods.Remove(mod.CurrentDiskState.ArchiveName);

            // Ignore any game files ("SeventySix - *.ba2"):
            foreach (string archiveName in IndexFileList)
                if (archiveName.StartsWith("SeventySix"))
                    installedMods.Remove(archiveName);
            foreach (string archiveName in Archive2List)
                if (archiveName.StartsWith("SeventySix"))
                    installedMods.Remove(archiveName);

            /*
             * Import installed mods:
             */

            foreach (string archiveName in installedMods)
            {
                string path = Path.Combine(Shared.GamePath, "Data", archiveName);
                Console.WriteLine(path);
                if (File.Exists(path))
                {
                    // Import archive:
                    this.InstallModArchiveFrozen(path);
                    File.Delete(path);

                    // Remove from lists:
                    IndexFileList.Remove(archiveName);
                    Archive2List.Remove(archiveName);
                }
            }

            // Save *.ini files:
            IndexFileList.CommitToINI();
            Archive2List.CommitToINI();
            IniFiles.Instance.SaveAll();
        }

        /// <summary>
        /// Serializes a list of mods into a *.xml document.
        /// </summary>
        /// <param name="mods">A list of mods</param>
        /// <returns>A *.xml document that can be saved to disk.</returns>
        public XDocument Serialize(List<ManagedMod> mods)
        {
            /*
             Fallout76\Mods\managed.xml
             <ManagedMods>
                <Mod ... />
                <Mod ... />
                <Mod ... />
             </ManagedMods>
             */

            XDocument xmlDoc = new XDocument();
            XElement xmlRoot = new XElement("ManagedMods");
            xmlDoc.Add(xmlRoot);

            foreach (ManagedMod mod in mods)
            {
                if (Directory.Exists(mod.GetManagedFolderPath()))
                    xmlRoot.Add(mod.Serialize());
            }

            return xmlDoc;
        }

        /// <summary>
        /// Deserializes every mod and returns them as a list.
        /// </summary>
        /// <param name="xmlDoc">The document that contains all Mod elements.</param>
        /// <returns></returns>
        public List<ManagedMod> Deserialize(XDocument xmlDoc)
        {
            List<ManagedMod> mods = new List<ManagedMod>();
            foreach (XElement xmlMod in xmlDoc.Descendants("Mod"))
            {
                try
                {
                    ManagedMod mod = ManagedMod.Deserialize(xmlMod);
                    /*if (!Directory.Exists(mod.GetManagedPath()))
                        continue;*/
                    mods.Add(mod);
                }
                catch (Exception ex)
                {
                    /* InvalidDataException, ArgumentException */
                    MsgBox.Get("modsInvalidManifestEntry").FormatText(ex.Message).Show(MessageBoxIcon.Warning);
                }
            }
            return mods;
        }

        /// <summary>
        /// Loads the XML file, deserializes every mod, and adds it to the list.
        /// </summary>
        public void Load()
        {
            this.Mods.Clear();
            this.Resources.Clear();

            if (!Shared.ValidateGamePath())
                return;

            // TODO: Wtf does that do? (LoadINILists)
            //if (!IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bMultipleGameEditionsUsed", false))
            //    this.LoadINILists();

            string xmlPath = GetXMLPath();

            if (!File.Exists(xmlPath))
                return;

            XDocument xmlDoc = XDocument.Load(xmlPath);
            this.Mods = Deserialize(xmlDoc);
            this.Resources = ResourceList.FromTXT();
        }

        /// <summary>
        /// Serializes the list of mods and saves it to managed.xml
        /// </summary>
        public void Save()
        {
            if (Shared.GamePath == null)
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(Path.Combine(Shared.GamePath, "Mods")))
                Directory.CreateDirectory(Path.Combine(Shared.GamePath, "Mods"));

            // TODO: Wtf does that do? (CopyINILists)
            //this.CopyINILists();
            this.Serialize(this.Mods).Save(this.GetXMLPath());
            this.Resources.SaveTXT();

            IniFiles.Instance.SaveAll();
        }

        /// <summary>
        /// Deploys every enabled mod, then saves managed.xml and resources.txt.
        /// </summary>
        public void Deploy(Action<string, int> updateProgress = null, Action<bool> done = null)
        {
            ModDeployment.DeployAll(this.Mods, this.Resources);
            this.Save();
        }
    }
}
