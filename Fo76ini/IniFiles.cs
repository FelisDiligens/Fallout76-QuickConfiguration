using IniParser;
using IniParser.Model;
using IniParser.Model.Configuration;
using IniParser.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Fo76ini
{
    public enum IniFile
    {
        F76,
        F76Prefs,
        F76Custom,
        Config
    }

    public class IniFiles
    {
        protected FileIniDataParser iniParser = null;

        protected IniData fo76Data = null;
        protected IniData fo76PrefsData = null;
        protected IniData fo76CustomData = null;
        protected IniData configData = null;

        protected String fo76Path;
        protected String fo76PrefsPath;
        protected String fo76CustomPath;
        protected String configPath;

        protected Encoding iniEncoding = new UTF8Encoding(false); // UTF-8 without BOM

        protected String iniParentPath;

        protected System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

        private static IniFiles instance = null;
        private static readonly object padlock = new object();

        public static IniFiles Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new IniFiles();
                    }
                    return instance;
                }
            }
        }

        private IniFiles()
        {
            // Get the paths:
            this.iniParentPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                @"My Games\Fallout 76\"
            );

            this.fo76Path = Path.Combine(this.iniParentPath, "Fallout76.ini");
            this.fo76PrefsPath = Path.Combine(this.iniParentPath, "Fallout76Prefs.ini");
            this.fo76CustomPath = Path.Combine(this.iniParentPath, "Fallout76Custom.ini");
            this.configPath = Path.Combine(this.iniParentPath, "QuickConfiguration.ini");

            // Configuring INI parser
            IniParserConfiguration iniParserConfig = new IniParserConfiguration();
            iniParserConfig.AllowCreateSectionsOnFly = true;
            iniParserConfig.AssigmentSpacer = "";
            iniParserConfig.CaseInsensitive = true;
            iniParserConfig.CommentRegex = new System.Text.RegularExpressions.Regex(@";.*");

            // Be very generous, allow everything:
            iniParserConfig.AllowDuplicateKeys = true;
            iniParserConfig.AllowDuplicateSections = true;
            iniParserConfig.AllowKeysWithoutSection = true;
            iniParserConfig.OverrideDuplicateKeys = true;

            // Initialize INI parser
            this.iniParser = new FileIniDataParser(new IniDataParser(iniParserConfig));
        }

        public void LoadGameInis()
        {
            // Parse all INI files, if existing:

            // Do Fallout76.ini and Fallout76Prefs.ini exist?
            if (!File.Exists(this.fo76Path) || !File.Exists(this.fo76PrefsPath))
                throw new FileNotFoundException("Fallout76.ini and Fallout76Prefs.ini not found");

            // Does Fallout76Custom.ini exist? If not, create it.
            if (!File.Exists(this.fo76CustomPath))
                File.CreateText(this.fo76CustomPath).Close();

            // Parse *.ini files:
            this.fo76Data = LoadIni(this.fo76Path, false);
            this.fo76PrefsData = LoadIni(this.fo76PrefsPath, false);
            this.fo76CustomData = LoadIni(this.fo76CustomPath, false);

            // Fix stuff:
            FixDuplicateResourceLists();
        }

        public void SaveGameInis(bool readOnly = false)
        {
            SaveIni(this.fo76Path, this.fo76Data, readOnly);
            SaveIni(this.fo76PrefsPath, this.fo76PrefsData, readOnly);
            SaveIni(this.fo76CustomPath, this.fo76CustomData, readOnly);
        }

        public void LoadConfig()
        {
            this.configData = LoadIni(this.configPath);
        }

        public void SaveConfig()
        {
            SaveIni(this.configPath, this.configData);
        }

        public void LoadAll()
        {
            LoadGameInis();
            LoadConfig();
        }

        public void SaveAll(bool readOnly = false)
        {
            SaveGameInis(readOnly);
            SaveConfig();
        }

        /// <summary>
        /// Create a backup folder and copy all *.ini files into it.
        /// </summary>
        public void BackupAll(String backupFolder = null)
        {
            if (backupFolder == null)
                backupFolder = DateTime.Now.ToString("Backup_yyyy-MM-dd_HH-mm-ss");
            String backupPath = Path.Combine(this.iniParentPath, backupFolder);

            if (Directory.Exists(backupPath))
                Directory.Delete(backupPath, true);

            Directory.CreateDirectory(backupPath);

            if (File.Exists(this.fo76Path))
                File.Copy(this.fo76Path, Path.Combine(backupPath, "Fallout76.ini"));

            if (File.Exists(this.fo76PrefsPath))
                File.Copy(this.fo76PrefsPath, Path.Combine(backupPath, "Fallout76Prefs.ini"));

            if (File.Exists(this.fo76CustomPath))
                File.Copy(this.fo76CustomPath, Path.Combine(backupPath, "Fallout76Custom.ini"));
        }


        protected String GetIniName(IniFile iniFile)
        {
            switch (iniFile)
            {
                case IniFile.F76:
                    return "Fallout76.ini";
                case IniFile.F76Prefs:
                    return "Fallout76Prefs.ini";
                case IniFile.F76Custom:
                    return "Fallout76Custom.ini";
                case IniFile.Config:
                    return "QuickConfiguration.ini";
            }
            return null;
        }

        protected String GetIniPath(IniFile iniFile)
        {
            switch (iniFile)
            {
                case IniFile.F76:
                    return this.fo76Path;
                case IniFile.F76Prefs:
                    return this.fo76PrefsPath;
                case IniFile.F76Custom:
                    return this.fo76CustomPath;
                case IniFile.Config:
                    return this.configPath;
            }
            return null;
        }

        protected IniData GetIniData(IniFile iniFile)
        {
            switch (iniFile)
            {
                case IniFile.F76:
                    return this.fo76Data;
                case IniFile.F76Prefs:
                    return this.fo76PrefsData;
                case IniFile.F76Custom:
                    return this.fo76CustomData;
                case IniFile.Config:
                    return this.configData;
            }
            return null;
        }

        protected void RemoveEmptySections(IniData data)
        {
            List<String> sectionNames = new List<String>();
            foreach (SectionData section in data.Sections)
                if (section.Keys.Count == 0)
                    sectionNames.Add(section.SectionName);
            foreach (String sectionName in sectionNames)
                data.Sections.RemoveSection(sectionName);
        }


        /*
         *********************************************************************************************************************************************
         * Save and load *.ini files
         ********************************************************************************************************************************************
         */

        public IniData LoadIni(String path, bool ignoreErrors)
        {
            if (!File.Exists(path))
                return new IniData();
            try
            {
                return this.iniParser.ReadFile(path, this.iniEncoding);
            }
            catch (IniParser.Exceptions.ParsingException e)
            {
                if (!ignoreErrors)
                    throw new IniParser.Exceptions.ParsingException($"{path} couldn't be parsed: {e.Message}", e); // Add the path to the exception, since IniParser doesn't do this.
                return new IniData();
            }
        }

        public IniData LoadIni(String path)
        {
            return LoadIni(path, true);
        }

        public void SaveIni(String path, IniData data, bool readOnly = false)
        {
            if (data == null)
                return;

            if (File.Exists(path))
                SetFileReadOnlyAttribute(path, false);

            RemoveEmptySections(data);
            this.iniParser.WriteFile(path, data, this.iniEncoding);

            if (readOnly)
                SetFileReadOnlyAttribute(path, readOnly);
        }


        /*
         *********************************************************************************************************************************************
         * ReadOnly
         ********************************************************************************************************************************************
         */

        protected void SetFileReadOnlyAttribute(String path, bool readOnly)
        {
            // https://stackoverflow.com/questions/8081242/c-sharp-make-file-read-write-from-readonly
            if (File.Exists(path))
            {
                var attr = File.GetAttributes(path);

                if (readOnly)
                    attr = attr | FileAttributes.ReadOnly;
                else
                    attr = attr & ~FileAttributes.ReadOnly;

                File.SetAttributes(path, attr);
            }
        }

        public void SetINIsReadOnly(bool readOnly)
        {
            SetFileReadOnlyAttribute(this.fo76Path, readOnly);
            SetFileReadOnlyAttribute(this.fo76PrefsPath, readOnly);
            SetFileReadOnlyAttribute(this.fo76CustomPath, readOnly);
        }

        public bool AreINIsReadOnly()
        {
            if (File.Exists(this.fo76Path) && File.Exists(this.fo76PrefsPath))
            {
                FileInfo fo76fi = new FileInfo(this.fo76Path);
                FileInfo fo76Prefsfi = new FileInfo(this.fo76PrefsPath);
                return fo76fi.IsReadOnly && fo76Prefsfi.IsReadOnly;
            }
            return false;
        }



        /*
         *********************************************************************************************************************************************
         * GETTER AND SETTER
         ********************************************************************************************************************************************
         */

        public bool Exists(String section, String key)
        {
            foreach (IniData data in new IniData[] { this.configData, this.fo76Data, this.fo76PrefsData, this.fo76CustomData })
            {
                if (data != null)
                {
                    if (data[section][key] != null)
                        return true;
                }
            }
            return false;
        }

        public bool Exists(IniFile f, String section, String key)
        {
            return GetIniData(f)[section][key] != null;
        }


        /// <summary>
        /// Reads all three INI files, if they exist, and returns the last value that was found.
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public String GetString(String section, String key, String defaultValue)
        {
            String value = defaultValue;
            foreach (IniData data in new IniData[] { this.configData, this.fo76Data, this.fo76PrefsData, this.fo76CustomData })
            {
                if (data != null)
                {
                    if (data[section][key] != null)
                        value = data[section][key];
                }
            }
            return value;
        }

        public String GetString(String section, String key)
        {
            String value = GetString(section, key, null);
            if (value == null)
                throw new KeyNotFoundException($"Couldn't find [{section}] {key} in any *.ini file.");
            return value;
        }

        /// <summary>
        /// Reads all three INI files, if they exist, and returns the last values that were found.
        /// defaultValue is optional.
        /// 
        /// Usage:
        /// String[] values = GetAny(new String[] {
        ///     new String[] { section, key, defaultValue },
        ///     new String[] { section, key }
        /// });
        /// </summary>
        /// <param name="sectionKeyDefaultPairs"></param>
        /// <returns></returns>
        public String[] GetString(String[][] sectionKeyDefaultPairs)
        {
            String[] values = new String[sectionKeyDefaultPairs.Length];
            for (int i = 0; i < sectionKeyDefaultPairs.Length; i++)
            {
                if (sectionKeyDefaultPairs[i].Length > 2)
                    values[i] = sectionKeyDefaultPairs[i][2];
                else
                    values[i] = null;
            }

            foreach (IniData data in new IniData[] { this.configData, this.fo76Data, this.fo76PrefsData, this.fo76CustomData })
            {
                for (int i = 0; i < sectionKeyDefaultPairs.Length; i++)
                {
                    if (data != null)
                    {
                        String section = sectionKeyDefaultPairs[i][0];
                        String key = sectionKeyDefaultPairs[i][1];
                        if (data[section][key] != null)
                            values[i] = data[section][key];
                    }
                }
            }
            return values;
        }

        public String GetString(IniFile f, String section, String key)
        {
            String value = GetIniData(f)[section][key];
            if (value == null)
                throw new KeyNotFoundException($"Couldn't find [{section}] {key} in {GetIniName(f)}");
            return value;
        }

        public String GetString(IniFile f, String section, String key, String defaultValue)
        {
            String value = GetIniData(f)[section][key];
            return value != null ? value : defaultValue;
        }

        public bool GetBool(IniFile f, String section, String key)
        {
            return GetString(f, section, key) == "1";
        }

        public bool GetBool(IniFile f, String section, String key, bool defaultValue)
        {
            return GetString(f, section, key, defaultValue ? "1" : "0") == "1";
        }

        public bool GetBool(String section, String key)
        {
            return GetString(section, key) == "1";
        }

        public bool GetBool(String section, String key, bool defaultValue)
        {
            return GetString(section, key, defaultValue ? "1" : "0") == "1";
        }

        public float GetFloat(IniFile f, String section, String key)
        {
            return Utils.ToFloat(GetString(f, section, key));
        }

        public float GetFloat(IniFile f, String section, String key, float defaultValue)
        {
            return Utils.ToFloat(GetString(f, section, key, defaultValue.ToString(enUS)));
        }

        public float GetFloat(String section, String key)
        {
            return Utils.ToFloat(GetString(section, key));
        }

        public float GetFloat(String section, String key, float defaultValue)
        {
            return Utils.ToFloat(GetString(section, key, defaultValue.ToString(enUS)));
        }

        public uint GetUInt(IniFile f, String section, String key)
        {
            return Utils.ToUInt(GetString(f, section, key));
        }

        public uint GetUInt(IniFile f, String section, String key, uint defaultValue)
        {
            return Utils.ToUInt(GetString(f, section, key, defaultValue.ToString(enUS)));
        }

        public uint GetUInt(String section, String key)
        {
            return Utils.ToUInt(GetString(section, key));
        }

        public uint GetUInt(String section, String key, uint defaultValue)
        {
            return Utils.ToUInt(GetString(section, key, defaultValue.ToString(enUS)));
        }

        public int GetInt(IniFile f, String section, String key)
        {
            return Utils.ToInt(GetString(f, section, key));
        }

        public int GetInt(IniFile f, String section, String key, int defaultValue)
        {
            return Utils.ToInt(GetString(f, section, key, defaultValue.ToString(enUS)));
        }

        public int GetInt(String section, String key)
        {
            return Utils.ToInt(GetString(section, key));
        }

        public int GetInt(String section, String key, int defaultValue)
        {
            return Utils.ToInt(GetString(section, key, defaultValue.ToString(enUS)));
        }

        public void Set(IniFile f, String section, String key, String value)
        {
            GetIniData(f)[section][key] = value;

            // There's a nasty problem, that bugs me:
            // When you set some value ONLY in Prefs, but the value was also set in Custom by the user,
            // then the value in Custom will overshadow Prefs, when GetString is called.
            // Of course people start to report that their values are reset. Who can blame them?
            // Soooo, we are going to set the same value in Custom if IniFile f is something else but Custom. Great? Great.
            if ((f == IniFile.F76 || f == IniFile.F76Prefs) && Exists(IniFile.F76Custom, section, key))
                this.fo76CustomData[section][key] = value;
        }

        public void Set(IniFile f, String section, String key, int value)
        {
            Set(f, section, key, Utils.ToString(value));
        }

        public void Set(IniFile f, String section, String key, float value)
        {
            Set(f, section, key, Utils.ToString(value));
        }

        public void Set(IniFile f, String section, String key, double value)
        {
            Set(f, section, key, Utils.ToString(value));
        }

        public void Set(IniFile f, String section, String key, uint value)
        {
            Set(f, section, key, Utils.ToString(value));
        }

        public void Set(IniFile f, String section, String key, bool value)
        {
            Set(f, section, key, value ? "1" : "0");
        }

        public void Remove(IniFile f, String section, String key)
        {
            if (Exists(f, section, key))
                GetIniData(f)[section].RemoveKey(key);
        }

        public void RemoveAll(String section, String key)
        {
            Remove(IniFile.F76, section, key);
            Remove(IniFile.F76Prefs, section, key);
            Remove(IniFile.F76Custom, section, key);
        }







        /*
         *********************************************************************************************************************************************
         * Fixes for invalid *.ini files:
         ********************************************************************************************************************************************
         */

        protected void MergeLists(IniFile f, String section, String key)
        {
            String list = "";
            bool found = false;
            int i = -1;
            IEnumerable<String> lines = File.ReadLines(GetIniPath(f));
            foreach (String line in lines)
            {
                if (line.TrimStart().ToLower().StartsWith(key.ToLower()))
                {
                    i = line.IndexOf("=");
                    if (i > -1)
                    {
                        found = true;
                        list += ", " + line.Substring(i + 1);
                    }
                }
            }
            list = String.Join<String>(",",
                    list.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(s => s.Trim()).Distinct().ToArray()
                            ).Trim(',').Replace(",,", ",");
            if (found)
                Set(f, section, key, list);
        }

        protected void FixDuplicateResourceLists()
        {
            // People seem to have duplicate key=value pairs of sResourceIndexFileList and sResourceArchive2List
            // Merge them. Default behaviour of the Parser is overriding and this is probably not what the user wants.
            // sResourceDataDirsFinal added in v.1.3.1
            // Case insensitive, and whitespace around '=' ignored as of v1.4
            MergeLists(IniFile.F76Custom, "Archive", "sResourceIndexFileList");
            MergeLists(IniFile.F76Custom, "Archive", "sResourceArchive2List");
            MergeLists(IniFile.F76Custom, "Archive", "sResourceDataDirsFinal");
        }
    }
}
