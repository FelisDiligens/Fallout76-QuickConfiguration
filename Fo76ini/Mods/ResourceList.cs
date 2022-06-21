using Fo76ini.Tweaks;
using Fo76ini.Tweaks.ResourceLists;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Fo76ini.Mods
{
    /// <summary>
    /// Wrapper around the resource lists to function as a regular List.
    /// Implements ways to read and write to *.ini file.
    /// </summary>
    public class ResourceList : ICollection<string>
    {
        public static List<string> KnownLists = new List<string>() {
            "sResourceIndexFileList",      // <- mod manager uses this
            "sResourceArchive2List",       // <- a lot of people use this
            "sResourceArchiveMisc",        // <- haven't seen this before
            "sResourceStartUpArchiveList",
            "SResourceArchiveList",
            "SResourceArchiveList2",
            "SResourceArchiveMemoryCacheList"
        };

        private List<string> resourceList = new List<string>();

        private ITweak<string> tweak;

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
        public static ResourceList FromTXT(String path)
        {
            ResourceList list = new ResourceList();
            list.LoadTXT(path);
            return list;
        }

        /// <summary>
        /// Loads the resource list from the *.ini file.
        /// </summary>
        /// <param name="iniFile"></param>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static ResourceList FromTweak(ITweak<string> tweak)
        {
            return new ResourceList(tweak);
        }

        public static ResourceList GetDefaultList()
        {
            return ResourceList.FromTweak(
                ResourceListTweak.GetDefaultList()
            );
        }

        public static ResourceList GetResourceArchive2List()
        {
            return ResourceList.FromTweak(
                ResourceListTweak.GetSResourceArchive2List()
            );
        }

        public static ResourceList GetResourceIndexFileList()
        {
            return ResourceList.FromTweak(
                ResourceListTweak.GetSResourceIndexFileList()
            );
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
        private ResourceList(ITweak<string> tweak)
        {
            AssociateTweak(tweak);
            LoadFromINI();
        }

        /*
         * Converting from and to string:
         */

        private static List<string> ToList(string sResourceList)
        {
            return (new List<string>(sResourceList.Split(new char[] { ',', '\n' }, StringSplitOptions.RemoveEmptyEntries))).Distinct().Select(x => x.Trim()).ToList();
        }

        private static string ToString(List<string> resourceList, string separator = ",")
        {
            return string.Join(separator, resourceList.Distinct());
        }

        public override string ToString()
        {
            return ResourceList.ToString(this.resourceList);
        }

        public string ToString(string separator)
        {
            return ResourceList.ToString(this.resourceList, separator);
        }

        /// <summary>
        /// Loads the resource list from the associated *.ini file.
        /// </summary>
        public void LoadFromINI()
        {
            this.resourceList = ResourceList.ToList(tweak.GetValue());
        }

        /// <summary>
        /// Commits changes to the resource list for the associated *.ini file.
        /// Use IniFiles.Save() to write *.ini file to disk.
        /// </summary>
        public void CommitToINI()
        {
            if (this.resourceList.Count > 0)
                tweak.SetValue(ToString());
            else
                tweak.ResetValue();
        }

        /// <summary>
        /// Associate a value in an *.ini file to save to and load from.
        /// </summary>
        /// <param name="tweak"></param>
        public void AssociateTweak(ITweak<string> tweak)
        {
            this.tweak = tweak;
        }


        /*
         * Writting to and reading from resources.txt:
         */

        /// <summary>
        /// Writes list to the Mods\resources.txt file.
        /// </summary>
        public void SaveTXT(String path)
        {
            File.WriteAllText(
                path,
                this.ToString()
            );
        }

        public void LoadTXT(String path)
        {
            if (File.Exists(path))
            {
                string text = File.ReadAllText(path);
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
        public void CleanUp(string gamePath)
        {
            string[] temp = new string[this.Count()];
            this.CopyTo(temp, 0);
            foreach (string ba2file in temp)
                if (!File.Exists(Path.Combine(gamePath, "Data", ba2file)))
                    this.Remove(ba2file);
        }

        public void ReplaceRange(ResourceList other)
        {
            this.resourceList.Clear();
            this.resourceList.AddRange(other);
        }
    }
}
