using Fo76ini.Utilities;
using IniParser;
using IniParser.Model;
using IniParser.Model.Configuration;
using IniParser.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Fo76ini
{
    public class IniFile
    {
        public readonly string Path;

        public bool IsReadOnly
        {
            get
            {
                if (File.Exists(Path))
                    return new FileInfo(Path).IsReadOnly;
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

        public IniFile(String path)
        {
            this.Path = path;

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
            this.iniParser.WriteFile(Path, data, encoding);
            SetFileReadOnlyAttribute(readOnly);
        }

        public void Load()
        {
            try
            {
                if (File.Exists(Path))
                    data = this.iniParser.ReadFile(Path, encoding);
                else
                    data = new IniData();
            }
            catch (IniParser.Exceptions.ParsingException e)
            {
                // Add the path to the exception (since IniParser doesn't do this) and throw again:
                throw new IniParser.Exceptions.ParsingException($"{Path} couldn't be parsed: {e.Message}", e);
            }
            UpdateLastModifiedDate();
        }

        public bool FileHasBeenModified()
        {
            return this.lastModified != File.GetLastWriteTime(Path);
        }

        private void UpdateLastModifiedDate()
        {
            this.lastModified = File.GetLastWriteTime(Path);
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
            if (File.Exists(Path))
            {
                var attr = File.GetAttributes(Path);

                if (readOnly)
                    attr = attr | FileAttributes.ReadOnly;
                else
                    attr = attr & ~FileAttributes.ReadOnly;

                File.SetAttributes(Path, attr);
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

        public bool GetBool(string section, string key)
        {
            return GetString(section, key) == "1";
        }

        public bool GetBool(string section, string key, bool defaultValue)
        {
            return GetString(section, key, defaultValue ? "1" : "0") == "1";
        }

        public float GetFloat(string section, string key)
        {
            return Utils.ToFloat(GetString(section, key));
        }

        public float GetFloat(string section, string key, float defaultValue)
        {
            return Utils.ToFloat(GetString(section, key, defaultValue.ToString(Shared.en_US)));
        }

        public uint GetUInt(string section, string key)
        {
            return Utils.ToUInt(GetString(section, key));
        }

        public uint GetUInt(string section, string key, uint defaultValue)
        {
            return Utils.ToUInt(GetString(section, key, defaultValue.ToString(Shared.en_US)));
        }

        public int GetInt(string section, string key)
        {
            return Utils.ToInt(GetString(section, key));
        }

        public int GetInt(string section, string key, int defaultValue)
        {
            return Utils.ToInt(GetString(section, key, defaultValue.ToString(Shared.en_US)));
        }

        public long GetLong(string section, string key)
        {
            return Utils.ToLong(GetString(section, key));
        }

        public long GetLong(string section, string key, int defaultValue)
        {
            return Utils.ToLong(GetString(section, key, defaultValue.ToString(Shared.en_US)));
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
