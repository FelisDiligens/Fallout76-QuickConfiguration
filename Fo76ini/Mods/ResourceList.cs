using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Mods
{
    /// <summary>
    /// Wrapper around the resource lists to function as a regular List.
    /// Implements ways to read and write to *.ini file.
    /// </summary>
    public class ResourceList : ICollection<string>
    {
        public static List<string> KnownLists = new List<string>() {
            "sResourceIndexFileList",
            "sResourceArchive2List",
            "sResourceStartUpArchiveList",
            "SResourceArchiveList",
            "SResourceArchiveList2"
        };

        private List<string> resourceList = new List<string>();

        private IniFile iniFile;
        private string section;
        private string key;

        public int Count => this.resourceList.Count;

        public bool IsReadOnly => false;


        /*
         * Constructor:
         */

        /// <summary>
        /// Creates a new ResourceList from a string.
        /// </summary>
        /// <param name="s">Resources, separated by a ','</param>
        public static ResourceList FromString(String s)
        {
            ResourceList list = new ResourceList();
            list.resourceList = ResourceList.ToList(s);
            return list;
        }

        /// <summary>
        /// Reads the Mods\resources.txt file and loads it's contents.
        /// </summary>
        /// <returns></returns>
        public static ResourceList FromTXT()
        {
            ResourceList list = ResourceList.GetResourceIndexFileList();

            if (File.Exists(ManagedMods.Instance.GetResourcesPath()))
            {
                string text = File.ReadAllText(ManagedMods.Instance.GetResourcesPath());
                list.resourceList = ResourceList.ToList(text);
            }
            else
            {
                list.Clear();
            }

            return list;
        }

        /// <summary>
        /// Loads the resource list from the *.ini file.
        /// </summary>
        /// <param name="iniFile"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ResourceList FromINI (IniFile iniFile, string section, string key)
        {
            return new ResourceList(iniFile, section, key);
        }

        /// <summary>
        /// Loads the resource list from the [Archive] section of Fallout76Custom.ini.
        /// </summary>
        /// <param name="key">The *.ini key in the [Archive] section of Fallout76Custom.ini</param>
        /// <returns></returns>
        public static ResourceList FromINI(string key)
        {
            return new ResourceList(IniFile.F76Custom, "Archive", key);
        }

        /// <summary>
        /// Loads the following resource list from Fallout76Custom.ini: [Archive]sResourceIndexFileList=...
        /// </summary>
        /// <returns></returns>
        public static ResourceList GetResourceIndexFileList()
        {
            return new ResourceList(IniFile.F76Custom, "Archive", "sResourceIndexFileList");
        }

        /// <summary>
        /// Loads the following resource list from Fallout76Custom.ini: [Archive]sResourceArchive2List=...
        /// </summary>
        /// <returns></returns>
        public static ResourceList GetResourceArchive2List()
        {
            return new ResourceList(IniFile.F76Custom, "Archive", "sResourceArchive2List");
        }

        /// <summary>
        /// Creates an empty list.
        /// </summary>
        public ResourceList() { }

        /// <summary>
        /// Associates the *.ini value and loads the resource list.
        /// </summary>
        /// <param name="iniFile"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        private ResourceList (IniFile iniFile, string section, string key)
        {
            AssociateINI(iniFile, section, key);
            LoadFromINI();
        }

        /*
         * Converting from and to string:
         */

        private static List<string> ToList (string sResourceList)
        {
            return (new List<string>(sResourceList.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))).Distinct().Select(x => x.Trim()).ToList();
        }

        private static string ToString(List<string> resourceList)
        {
            return string.Join(",", resourceList.Distinct());
        }

        public override string ToString()
        {
            return ResourceList.ToString(this.resourceList);
        }


        /*
         * Writting to and reading from *.ini file:
         */

        private void SetINIString(string sResourceList)
        {
            IniFiles.Instance.Set(iniFile, section, key, sResourceList);
        }

        private void RemoveINIString()
        {
            IniFiles.Instance.Remove(iniFile, section, key);
        }

        private string GetINIString()
        {
            return IniFiles.Instance.GetString(iniFile, section, key, "");
        }

        /// <summary>
        /// Loads the resource list from the associated *.ini file.
        /// </summary>
        public void LoadFromINI()
        {
            this.resourceList = ResourceList.ToList(GetINIString());
        }

        /// <summary>
        /// Commits changes to the resource list for the associated *.ini file.
        /// Use IniFiles.Instance.SaveAll() to write *.ini file to disk.
        /// </summary>
        public void CommitToINI()
        {
            if (this.resourceList.Count > 0)
                SetINIString(ToString());
            else
                RemoveINIString();
        }

        /// <summary>
        /// Associate a value in an *.ini file to save to and load from.
        /// </summary>
        /// <param name="iniFile"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        public void AssociateINI (IniFile iniFile, string section, string key)
        {
            this.iniFile = iniFile;
            this.section = section;
            this.key = key;
        }


        /*
         * Writting to and reading from resources.txt:
         */

        /// <summary>
        /// Writes list to the Mods\resources.txt file.
        /// </summary>
        public void SaveTXT()
        {
            File.WriteAllText(
                ManagedMods.Instance.GetResourcesPath(),
                this.ToString()
            );
        }

        public void LoadTXT()
        {
            if (File.Exists(ManagedMods.Instance.GetResourcesPath()))
            {
                string text = File.ReadAllText(ManagedMods.Instance.GetResourcesPath());
                this.resourceList = ResourceList.ToList(text);
            }
            else
            {
                this.Clear();
            }
        }


        /*
         * Implementing ICollection interface:
         */

        public IEnumerator<string> GetEnumerator()
        {
            return this.resourceList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(string item)
        {
            this.resourceList.Add(item);
        }

        public void Clear()
        {
            this.resourceList.Clear();
        }

        public bool Contains(string item)
        {
            return this.resourceList.Contains(item);
        }

        public void CopyTo(string[] array, int arrayIndex)
        {
            this.resourceList.CopyTo(array, arrayIndex);
        }

        public bool Remove(string item)
        {
            return this.resourceList.Remove(item);
        }


        /*
         * Additional methods from List<T>:
         */

        /// <summary>
        /// Inserts an element into the list at the specified index.
        /// </summary>
        public void Insert(int index, string item)
        {
            this.resourceList.Insert(index, item);
        }


        /*
         * Utility methods:
         */

        /// <summary>
        /// Removes resources that aren't existing on disk.
        /// </summary>
        public void CleanUp()
        {
            string[] temp = new string[this.Count()];
            this.CopyTo(temp, this.Count());
            foreach (string ba2file in temp)
                if (!File.Exists(Path.Combine(Shared.GamePath, "Data", ba2file)))
                    this.Remove(ba2file);
        }
    }
}
