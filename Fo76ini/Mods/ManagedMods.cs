using Fo76ini.Tweaks.ResourceLists;
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
        public ManagedMods(string gamePath)
        {
            this.GamePath = gamePath;
        }

        public List<ManagedMod> Mods = new List<ManagedMod>();
        public ResourceList Resources = ResourceList.GetDefaultList();
        public readonly string GamePath = "";
        public bool ModsDisabled = false;
        public bool NuclearWinterModeEnabled = false;

        /// <summary>
        /// Path where mods get stored. ("Fallout76\Mods")
        /// </summary>
        public string ModsPath
        {
            get { return Path.Combine(GamePath, "Mods"); }
        }

        /// <summary>
        /// Path to the "Fallout76\Mods\managed.xml"
        /// </summary>
        public string XMLPath
        {
            get { return Path.Combine(ModsPath, "managed.xml"); }
        }

        /// <summary>
        /// Path to the "Fallout76\Mods\resources.txt"
        /// </summary>
        public string ResourcesPath
        {
            get { return Path.Combine(ModsPath, "resources.txt"); }
        }

        public int Count => this.Mods.Count();

        public bool IsReadOnly => false;

        public void EnableMod(int index)
        {
            this.Mods[index].Enabled = true;
        }

        public void DisableMod(int index)
        {
            this.Mods[index].Enabled = false;
        }

        public bool isModEnabled(int index)
        {
            return this.Mods[index].Enabled;
        }

        /// <summary>
        /// Move a mod from one index to another.
        /// </summary>
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
        /// Compares current disk state and pending disk state and returns true, if they're different.
        /// </summary>
        /// <returns></returns>
        public bool isDeploymentNecessary()
        {
            foreach (ManagedMod mod in Mods)
            {
                if (mod.Deployed && this.ModsDisabled)
                    return true;

                if (mod.isDeploymentNecessary())
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
                if (Directory.Exists(mod.ManagedFolderPath))
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
                    ManagedMod mod = ManagedMod.Deserialize(xmlMod, GamePath);
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

            // TODO: Wtf does that do? (LoadINILists)
            //if (!IniFiles.Instance.GetBool(IniFile.Config, "Preferences", "bMultipleGameEditionsUsed", false))
            //    this.LoadINILists();

            if (!File.Exists(XMLPath))
                return;

            XDocument xmlDoc = XDocument.Load(XMLPath);
            this.Mods = Deserialize(xmlDoc);
            this.Resources = ResourceList.FromTXT(ResourcesPath);
            this.Resources.AssociateTweak(ResourceListTweak.GetDefaultList());
        }

        /// <summary>
        /// Serializes the list of mods and saves it to managed.xml
        /// </summary>
        public void Save()
        {
            if (!Directory.Exists(Path.Combine(this.GamePath, "Mods")))
                Directory.CreateDirectory(Path.Combine(this.GamePath, "Mods"));

            // TODO: Wtf does that do? (CopyINILists)
            //this.CopyINILists();

            this.Serialize(this.Mods).Save(XMLPath);
            this.Resources.SaveTXT(ResourcesPath);
            if (NuclearWinterModeEnabled)
                IniFiles.F76Custom.Remove("Archive", "sResourceIndexFileList");
            else
                this.Resources.CommitToINI(); // TODO: Where else do we have CommitToINI?
            IniFiles.Save();

            LegacyManagedMods.GenerateLegacyXML(this);
        }

        public void Add(ManagedMod item)
        {
            this.Mods.Add(item);
        }

        public void Clear()
        {
            this.Mods.Clear();
        }

        public bool Contains(ManagedMod item)
        {
            return this.Mods.Contains(item);
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
