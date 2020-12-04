using Fo76ini.Ini;
using Fo76ini.Utilities;
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
    public class IniFile
    {
        public readonly string FilePath;
        public readonly string FileName;
        public string DefaultPath; // Fallback to this path, if the actual path doesn't exist. (To load defaults)

        public bool IsReadOnly
        {
            get
            {
                if (File.Exists(FilePath))
                    return new FileInfo(FilePath).IsReadOnly;
                else
                    return false;
            }
            set
            {
                SetFileReadOnlyAttribute(value);
            }
        }

        private FileIniDataParser iniParser;
        private IniData data;

        private DateTime lastModified;
        private Encoding encoding = new UTF8Encoding(false); // UTF-8 without BOM
        //private static readonly System.Globalization.CultureInfo en_US = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

        public IniFile(String path, String defaultPath = null)
        {
            this.FilePath = path;
            this.FileName = Path.GetFileName(path);
            this.DefaultPath = defaultPath;

            // Configuring INI parser
            IniParserConfiguration iniParserConfig = new IniParserConfiguration();
            iniParserConfig.AllowCreateSectionsOnFly = true;
            iniParserConfig.AssigmentSpacer = "";
            iniParserConfig.CaseInsensitive = true;
            iniParserConfig.CommentRegex = new System.Text.RegularExpressions.Regex(@"^;.*");

            // Be very generous, allow everything:
            iniParserConfig.AllowDuplicateKeys = true;
            iniParserConfig.AllowDuplicateSections = true;
            iniParserConfig.AllowKeysWithoutSection = true;
            iniParserConfig.OverrideDuplicateKeys = true;

            // Initialize INI parser
            this.iniParser = new FileIniDataParser(new IniDataParser(iniParserConfig));
        }

        public void Save()
        {
            if (data == null)
                return;

            RemoveEmptySections();
            bool readOnly = this.IsReadOnly;
            SetFileReadOnlyAttribute(false);
            this.iniParser.WriteFile(FilePath, data, encoding);
            SetFileReadOnlyAttribute(readOnly);
            UpdateLastModifiedDate();
        }

        public void Load()
        {
            try
            {
                if (File.Exists(FilePath))
                    data = this.iniParser.ReadFile(FilePath, encoding);
                else if (DefaultPath != null && File.Exists(DefaultPath))
                    data = this.iniParser.ReadFile(DefaultPath, encoding);
                else
                    data = new IniData();
            }
            catch (IniParser.Exceptions.ParsingException exc)
            {
                // Add the path to the exception (since IniParser doesn't do this) and throw again:
                // throw new IniParser.Exceptions.ParsingException($"{Path} couldn't be parsed: {e.Message}", e);
                throw IniParsingException.CreateException(exc, FilePath);
            }
            UpdateLastModifiedDate();
        }

        public void LoadDefault()
        {
            try
            {
                if (DefaultPath != null && File.Exists(DefaultPath))
                    data = this.iniParser.ReadFile(DefaultPath, encoding);
                else
                    data = new IniData();
            }
            catch
            {
                data = new IniData();
            }
            UpdateLastModifiedDate();
        }

        public bool IsLoaded()
        {
            return data != null;
        }

        public void Merge(IniFile f)
        {
            this.data.Merge(f.data);
        }

        public void Merge(IniData d)
        {
            this.data.Merge(d);
        }

        public bool FileHasBeenModified()
        {
            return this.lastModified != File.GetLastWriteTime(FilePath);
        }

        public void UpdateLastModifiedDate()
        {
            this.lastModified = File.GetLastWriteTime(FilePath);
        }

        protected void RemoveEmptySections()
        {
            List<string> sectionNames = new List<string>();
            foreach (SectionData section in data.Sections)
                if (section.Keys.Count == 0)
                    sectionNames.Add(section.SectionName);
            foreach (string sectionName in sectionNames)
                data.Sections.RemoveSection(sectionName);
        }

        protected void SetFileReadOnlyAttribute(bool readOnly)
        {
            // https://stackoverflow.com/questions/8081242/c-sharp-make-file-read-write-from-readonly
            if (File.Exists(FilePath))
            {
                var attr = File.GetAttributes(FilePath);

                if (readOnly)
                    attr = attr | FileAttributes.ReadOnly;
                else
                    attr = attr & ~FileAttributes.ReadOnly;

                File.SetAttributes(FilePath, attr);
            }
        }

        /*
         *********************************************************************************************************************************************
         * GETTER AND SETTER
         ********************************************************************************************************************************************
         */

        public bool Exists(string section, string key)
        {
            return data != null && data[section][key] != null;
        }

        public string GetString(string section, string key, string defaultValue)
        {
            return Exists(section, key) ? data[section][key] : defaultValue;
        }

        public string GetString(string section, string key)
        {
            if (!Exists(section, key))
                throw new KeyNotFoundException($"Couldn't find [{section}] {key} in any *.ini file.");
            return data[section][key];
        }

        public static readonly string[] ValidBoolValues = new string[] { "1", "0", "" };

        public bool GetBool(string section, string key)
        {
            return GetString(section, key) == "1";
        }

        public bool GetBool(string section, string key, bool defaultValue)
        {
            string value = GetString(section, key, defaultValue ? "1" : "0");
            if (ValidBoolValues.Contains(value))
                return value == "1";
            else
                return defaultValue;
        }

        public float GetFloat(string section, string key)
        {
            return Utils.ToFloat(GetString(section, key));
        }

        public float GetFloat(string section, string key, float defaultValue)
        {
            try
            {
                return Utils.ToFloat(GetString(section, key, defaultValue.ToString(Shared.en_US)));
            }
            catch
            {
                return defaultValue;
            }
        }

        public uint GetUInt(string section, string key)
        {
            return Utils.ToUInt(GetString(section, key));
        }

        public uint GetUInt(string section, string key, uint defaultValue)
        {
            try
            {
                return Utils.ToUInt(GetString(section, key, defaultValue.ToString(Shared.en_US)));
            }
            catch
            {
                return defaultValue;
            }
        }

        public int GetInt(string section, string key)
        {
            return Utils.ToInt(GetString(section, key));
        }

        public int GetInt(string section, string key, int defaultValue)
        {
            try
            {
                return Utils.ToInt(GetString(section, key, defaultValue.ToString(Shared.en_US)));
            }
            catch
            {
                return defaultValue;
            }
        }

        public long GetLong(string section, string key)
        {
            return Utils.ToLong(GetString(section, key));
        }

        public long GetLong(string section, string key, int defaultValue)
        {
            try
            {
                return Utils.ToLong(GetString(section, key, defaultValue.ToString(Shared.en_US)));
            }
            catch
            {
                return defaultValue;
            }
        }

        public void Set(string section, string key, string value)
        {
            data[section][key] = value;
        }

        public void Set(string section, string key, int value)
        {
            Set(section, key, Utils.ToString(value));
        }

        public void Set(string section, string key, uint value)
        {
            Set(section, key, Utils.ToString(value));
        }

        public void Set(string section, string key, long value)
        {
            Set(section, key, Utils.ToString(value));
        }

        public void Set(string section, string key, float value)
        {
            Set(section, key, Utils.ToString(value));
        }

        public void Set(string section, string key, double value)
        {
            Set(section, key, Utils.ToString(value));
        }

        public void Set(string section, string key, bool value)
        {
            Set(section, key, value ? "1" : "0");
        }

        public void Remove(string section, string key)
        {
            if (Exists(section, key))
                data[section].RemoveKey(key);
        }
    }
}
