using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
using Fo76ini.Interface;
using Fo76ini.Profiles;

namespace Fo76ini.Mods
{
    /// <summary>
    /// This class is used to load, store, and save all data about installed mods and their current state.
    /// Pass an instance of this class to a method which works with the data.
    /// </summary>
    public class ManagedMods : ICollection<ManagedMod>
    {
        public ManagedMods(string gamePath, string modsPath)
        {
            this.GamePath = gamePath;
            this.ModsPath = modsPath;
        }

        public List<ManagedMod> Mods = new List<ManagedMod>();
        public ResourceList Resources = ResourceList.GetPreferredList();
        public readonly string GamePath = "";
        public bool ModsDisabled = false;
        public bool NuclearWinterModeEnabled = false;

        private string modsPath = string.Empty;

        /// <summary>
        /// Path where mods get stored.
        /// </summary>
        public string ModsPath
        {
            get
            {
                if (modsPath == string.Empty)
                    return GamePath;
                return modsPath;
            }
            set
            {
                modsPath = value;
            }
        }

        /// <summary>
        /// Path to the "Fallout76\Mods\managed.xml"
        /// </summary>
        public string XMLPath
        {
            get { return Path.Combine(ModsPath, "Mods", "managed.xml"); }
        }

        /// <summary>
        /// Path to the "Fallout76\Mods\resources.txt"
        /// </summary>
        public string ResourcesPath
        {
            get { return Path.Combine(ModsPath, "Mods", "resources.txt"); }
        }

        /// <summary>
        /// Returns the number of managed mods.
        /// </summary>
        public int Count => this.Mods.Count();

        /// <summary>
        /// How many managed mods are enabled?
        /// </summary>
        public int EnabledCount
        {
            get
            {
                int enabledCount = 0;
                foreach (ManagedMod mod in this.Mods)
                    if (mod.Enabled)
                        enabledCount++;
                return enabledCount;
            }
        }

        public bool IsReadOnly => false;

        public void EnableMod(int index)
        {
            this.Mods[index].Enabled = true;
        }

        public void DisableMod(int index)
        {
            this.Mods[index].Enabled = false;
        }

        public bool IsModEnabled(int index)
        {
            return this.Mods[index].Enabled;
        }

        /// <summary>
        /// Move a mod from one index to another.
        /// </summary>
        /// <returns>New index</returns>
        public int MoveMod(int oldIndex, int newIndex)
        {
            if (oldIndex >= this.Mods.Count ||
                oldIndex < 0 ||
                newIndex >= this.Mods.Count ||
                newIndex < 0)
                return oldIndex;

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
        /// Compares current disk state and pending disk state and returns true, if they're different.
        /// </summary>
        /// <returns></returns>
        public bool IsDeploymentNecessary()
        {
            foreach (ManagedMod mod in Mods)
            {
                if (mod.Deployed && this.ModsDisabled)
                    return true;

                if (mod.IsDeploymentNecessary())
                    return true;
            }
            return false;
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
            XElement xmlRoot = new XElement("ManagedMods",
                new XAttribute("enabled", !this.ModsDisabled),
                new XAttribute("nwmode", this.NuclearWinterModeEnabled)
            );
            xmlDoc.Add(xmlRoot);

            foreach (ManagedMod mod in mods)
            {
                if (Directory.Exists(mod.ManagedFolderPath) ||
                    File.Exists(mod.FrozenArchivePath))
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

            if (xmlDoc.Root.Attribute("enabled") != null)
                this.ModsDisabled = !Convert.ToBoolean(xmlDoc.Root.Attribute("enabled").Value);

            if (xmlDoc.Root.Attribute("nwmode") != null)
                this.NuclearWinterModeEnabled = Convert.ToBoolean(xmlDoc.Root.Attribute("nwmode").Value);

            foreach (XElement xmlMod in xmlDoc.Descendants("Mod"))
            {
                try
                {
                    ManagedMod mod = ManagedMod.Deserialize(xmlMod, GamePath, ModsPath);
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

            if (!GameInstance.ValidateGamePath(GamePath))
                return;

            if (!GameInstance.ValidateModsPath(ModsPath))
                return;

            if (!File.Exists(XMLPath))
                return;

            XDocument xmlDoc = XDocument.Load(XMLPath);
            this.Mods = Deserialize(xmlDoc);
            this.Resources = ResourceList.FromTXT(ResourcesPath);
        }

        /// <summary>
        /// Serializes the list of mods and saves it to *.xml. Also saves resource list.
        /// </summary>
        public void Save()
        {
            if (!Directory.Exists(Path.Combine(this.ModsPath, "Mods")))
                Directory.CreateDirectory(Path.Combine(this.ModsPath, "Mods"));

            this.Serialize(this.Mods).Save(XMLPath);
            SaveResources();
        }

        /// <summary>
        /// Saves the resource list
        /// </summary>
        public void SaveResources()
        {
            this.Resources.SaveTXT(ResourcesPath);
            if (NuclearWinterModeEnabled)
                IniFiles.F76Custom.Remove("Archive", this.Resources.ListName);
            else
                this.Resources.CommitToINI(); // TODO: Where else do we have CommitToINI?
            IniFiles.F76Custom.Save();
        }

        /// <summary>
        /// Inserts a mod to the end of the list.
        /// </summary>
        public void Add(ManagedMod item)
        {
            this.Mods.Add(item);
        }

        /// <summary>
        /// Inserts a mod into the list at the specified index.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Insert(int index, ManagedMod item)
        {
            this.Mods.Insert(index, item);
        }

        public void Clear()
        {
            this.Mods.Clear();
        }

        public bool Contains(ManagedMod item)
        {
            return this.Mods.Contains(item);
        }

        public int IndexOf(ManagedMod item)
        {
            return this.Mods.IndexOf(item);
        }

        public void CopyTo(ManagedMod[] array, int arrayIndex)
        {
            this.Mods.CopyTo(array, arrayIndex);
        }

        public bool Remove(ManagedMod item)
        {
            return this.Mods.Remove(item);
        }

        public void RemoveAt(int index)
        {
            this.Mods.RemoveAt(index);
        }

        public IEnumerator<ManagedMod> GetEnumerator()
        {
            return this.Mods.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ManagedMod this[int index]
        {
            get { return this.Mods[index]; }
            set { this.Mods[index] = value; }
        }
    }
}
