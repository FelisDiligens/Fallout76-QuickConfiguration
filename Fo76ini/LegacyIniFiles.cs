using IniParser;
using IniParser.Model;
using IniParser.Model.Configuration;
using IniParser.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Fo76ini
{
    public enum LegacyIniFile
    {
        F76,
        F76Prefs,
        F76Custom,
        Config
    }

    public class LegacyIniFiles
    {
        protected FileIniDataParser iniParser = null;

        protected IniData fo76Data = null;
        protected IniData fo76PrefsData = null;
        protected IniData fo76CustomData = null;
        protected IniData configData = null;

        /*protected String fo76Path;
        protected String fo76PrefsPath;
        protected String fo76CustomPath;*/
        protected string configPath;

        protected DateTime fo76ModTime;
        protected DateTime fo76PrefsModTime;
        protected DateTime fo76CustomModTime;

        protected Encoding iniEncoding = new UTF8Encoding(false); // UTF-8 without BOM

        public string iniParentPath;

        protected System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");

        //public bool nuclearWinterMode = false;
        public bool renameF76Custom = false;
        public const string nwF76CustomEnding = ".nwmodebak";

        public bool fixCustomIniDuplicateValues = true;

        //public GameEdition GameEdition;

        private static LegacyIniFiles instance = null;
        private static readonly object padlock = new object();

        public static LegacyIniFiles Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new LegacyIniFiles();
                    }
                    return instance;
                }
            }
        }

        public string GetIniName(LegacyIniFile iniFile, GameEdition edition = GameEdition.Unknown)
        {
            if (edition == GameEdition.Unknown)
                edition = Shared.GameEdition;
            bool msstore = edition == GameEdition.MSStore;
            switch (iniFile)
            {
                case LegacyIniFile.F76:
                    return msstore ? "Project76.ini" : "Fallout76.ini";
                case LegacyIniFile.F76Prefs:
                    return msstore ? "Project76Prefs.ini" : "Fallout76Prefs.ini";
                case LegacyIniFile.F76Custom:
                    return msstore ? "Project76Custom.ini" : "Fallout76Custom.ini";
                default:
                    throw new NotSupportedException("Ini name unknown");
            }
        }

        public string GetIniPath(LegacyIniFile iniFile, GameEdition edition)
        {
            switch (iniFile)
            {
                case LegacyIniFile.F76:
                case LegacyIniFile.F76Prefs:
                case LegacyIniFile.F76Custom:
                    return Path.Combine(this.iniParentPath, GetIniName(iniFile, edition));
                case LegacyIniFile.Config:
                    return this.configPath;
            }
            return null;
        }

        public string GetIniPath(LegacyIniFile iniFile)
        {
            switch (iniFile)
            {
                case LegacyIniFile.F76:
                case LegacyIniFile.F76Prefs:
                case LegacyIniFile.F76Custom:
                    return Path.Combine(this.iniParentPath, GetIniName(iniFile));
                case LegacyIniFile.Config:
                    return this.configPath;
            }
            return null;
        }

        protected IniData GetIniData(LegacyIniFile iniFile)
        {
            switch (iniFile)
            {
                case LegacyIniFile.F76:
                    return this.fo76Data;
                case LegacyIniFile.F76Prefs:
                    return this.fo76PrefsData;
                case LegacyIniFile.F76Custom:
                    return this.fo76CustomData;
                case LegacyIniFile.Config:
                    return this.configData;
            }
            return null;
        }

        private LegacyIniFiles()
        {
            // Get the paths:
            this.iniParentPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                @"My Games\Fallout 76\"
            );

            this.configPath = Path.Combine(Shared.AppConfigFolder, "config.ini");

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

        public void LoadGameInis()
        {
            // Parse all INI files, if existing:

            // Do Fallout76.ini and Fallout76Prefs.ini exist?
            if (!File.Exists(GetIniPath(LegacyIniFile.F76)) || !File.Exists(GetIniPath(LegacyIniFile.F76Prefs)))
            {
                if (Shared.GameEdition == GameEdition.MSStore)
                {
                    // Do Fallout76.ini and Fallout76Prefs.ini exist?
                    if (File.Exists(GetIniPath(LegacyIniFile.F76, GameEdition.Steam)) && File.Exists(GetIniPath(LegacyIniFile.F76Prefs, GameEdition.Steam)))
                        //Shared.ChangeGameEdition(GameEdition.Steam);
                        Shared.GameEdition = GameEdition.Steam;
                    else
                        throw new FileNotFoundException($"{GetIniName(LegacyIniFile.F76)} and {GetIniName(LegacyIniFile.F76Prefs)} not found");
                }
                else
                {
                    // Do Project76.ini and Project76Prefs.ini exist?
                    if (File.Exists(GetIniPath(LegacyIniFile.F76, GameEdition.MSStore)) && File.Exists(GetIniPath(LegacyIniFile.F76Prefs, GameEdition.MSStore)))
                        //Shared.ChangeGameEdition(GameEdition.MSStore);
                        Shared.GameEdition = GameEdition.MSStore;
                    else
                        throw new FileNotFoundException($"{GetIniName(LegacyIniFile.F76)} and {GetIniName(LegacyIniFile.F76Prefs)} not found");
                }
            }

            // Does Fallout76Custom.ini exist? If not, create it.
            /*if (!File.Exists(this.GetIniPath(IniFile.F76Custom)))
                File.CreateText(this.GetIniPath(IniFile.F76Custom)).Close();*/

            // Parse *.ini files:
            this.fo76Data = LoadIni(GetIniPath(LegacyIniFile.F76), false);
            this.fo76ModTime = File.GetLastWriteTime(GetIniPath(LegacyIniFile.F76));
            this.fo76PrefsData = LoadIni(GetIniPath(LegacyIniFile.F76Prefs), false);
            this.fo76PrefsModTime = File.GetLastWriteTime(GetIniPath(LegacyIniFile.F76Prefs));
            if (File.Exists(GetIniPath(LegacyIniFile.F76Custom)))
                this.fo76CustomData = LoadIni(GetIniPath(LegacyIniFile.F76Custom), false);
            else if (File.Exists(GetIniPath(LegacyIniFile.F76Custom) + ".nwmodebak"))
                this.fo76CustomData = LoadIni(GetIniPath(LegacyIniFile.F76Custom) + ".nwmodebak", false);
            else
                this.fo76CustomData = new IniData();

            UpdateLastModifiedDates();

            // Fix stuff:
            FixDuplicateResourceLists();
        }

        public bool IsLoaded()
        {
            return this.fo76Data != null &&
                   this.fo76PrefsData != null &&
                   this.fo76CustomData != null &&
                   this.configData != null;
        }

        public void ChangeGameEdition(GameEdition edition)
        {
            //bool reloadRequired = (this.GameEdition == GameEdition.MSStore && edition != GameEdition.MSStore) || (this.GameEdition != GameEdition.MSStore && edition == GameEdition.MSStore);
            //this.GameEdition = edition;
            /*if (reloadRequired)
                LoadGameInis();*/
            LegacyIniFiles.Instance.Set(LegacyIniFile.Config, "Preferences", "uGameEdition", (int)edition);

            UpdateLastModifiedDates();
        }

        public void SaveGameInis(bool readOnly = false)
        {
            SaveIni(this.GetIniPath(LegacyIniFile.F76), this.fo76Data, readOnly);
            SaveIni(this.GetIniPath(LegacyIniFile.F76Prefs), this.fo76PrefsData, readOnly);
            if (this.renameF76Custom)
                SaveIni(this.GetIniPath(LegacyIniFile.F76Custom) + nwF76CustomEnding, this.fo76CustomData, readOnly);
            else
                SaveIni(this.GetIniPath(LegacyIniFile.F76Custom), this.fo76CustomData, readOnly);
            UpdateLastModifiedDates();
        }

        public void ResolveNWMode()
        {
            SetNTFSWritePermission(true);
            if (this.renameF76Custom)
            {
                foreach (GameEdition edition in Enum.GetValues(typeof(GameEdition)))
                {
                    if (!File.Exists(this.GetIniPath(LegacyIniFile.F76Custom, edition)))
                        return;
                    if (!File.Exists(this.GetIniPath(LegacyIniFile.F76Custom, edition) + nwF76CustomEnding))
                        File.Copy(this.GetIniPath(LegacyIniFile.F76Custom, edition), this.GetIniPath(LegacyIniFile.F76Custom, edition) + nwF76CustomEnding);
                    Utils.DeleteFile(this.GetIniPath(LegacyIniFile.F76Custom, edition));
                }
            }
            else
            {
                foreach (GameEdition edition in Enum.GetValues(typeof(GameEdition)))
                {
                    if (!File.Exists(this.GetIniPath(LegacyIniFile.F76Custom, edition) + nwF76CustomEnding))
                        return;
                    if (!File.Exists(this.GetIniPath(LegacyIniFile.F76Custom, edition)))
                        File.Copy(this.GetIniPath(LegacyIniFile.F76Custom, edition) + nwF76CustomEnding, this.GetIniPath(LegacyIniFile.F76Custom, edition));
                    Utils.DeleteFile(this.GetIniPath(LegacyIniFile.F76Custom, edition) + nwF76CustomEnding);
                }
            }
            UpdateLastModifiedDates();

            if (this.GetBool(LegacyIniFile.Config, "Preferences", "bDenyNTFSWritePermission", false))
                SetNTFSWritePermission(false);
        }

        public bool FilesHaveBeenModified()
        {
            if (this.fo76ModTime != File.GetLastWriteTime(this.GetIniPath(LegacyIniFile.F76)))
                return true;
            if (this.fo76PrefsModTime != File.GetLastWriteTime(this.GetIniPath(LegacyIniFile.F76Prefs)))
                return true;

            if (File.Exists(this.GetIniPath(LegacyIniFile.F76Custom)))
            {
                if (this.fo76CustomModTime != File.GetLastWriteTime(this.GetIniPath(LegacyIniFile.F76Custom)))
                    return true;
            }
            else if (File.Exists(this.GetIniPath(LegacyIniFile.F76Custom) + ".nwmodebak"))
            {
                if (this.fo76CustomModTime != File.GetLastWriteTime(this.GetIniPath(LegacyIniFile.F76Custom) + ".nwmodebak"))
                    return true;
            }
            return false;
        }

        public void UpdateLastModifiedDates()
        {
            this.fo76ModTime = File.GetLastWriteTime(this.GetIniPath(LegacyIniFile.F76));
            this.fo76PrefsModTime = File.GetLastWriteTime(this.GetIniPath(LegacyIniFile.F76Prefs));

            if (File.Exists(this.GetIniPath(LegacyIniFile.F76Custom)))
                this.fo76CustomModTime = File.GetLastWriteTime(this.GetIniPath(LegacyIniFile.F76Custom));
            else if (File.Exists(this.GetIniPath(LegacyIniFile.F76Custom) + ".nwmodebak"))
                this.fo76CustomModTime = File.GetLastWriteTime(this.GetIniPath(LegacyIniFile.F76Custom) + ".nwmodebak");
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
        public void BackupAll(string backupFolder = null)
        {
            if (backupFolder == null)
                backupFolder = DateTime.Now.ToString("Backup_yyyy-MM-dd_HH-mm-ss");
            string backupPath = Path.Combine(this.iniParentPath, backupFolder);
            string tempPath;

            if (Directory.Exists(backupPath))
                Utils.DeleteDirectory(backupPath);

            Directory.CreateDirectory(backupPath);

            if (File.Exists(this.GetIniPath(LegacyIniFile.F76)))
            {
                tempPath = Path.Combine(backupPath, "Fallout76.ini");
                File.Copy(this.GetIniPath(LegacyIniFile.F76), tempPath);
                SetFileReadOnlyAttribute(tempPath, false);
            }

            if (File.Exists(this.GetIniPath(LegacyIniFile.F76Prefs)))
            {
                tempPath = Path.Combine(backupPath, "Fallout76Prefs.ini");
                File.Copy(this.GetIniPath(LegacyIniFile.F76Prefs), tempPath);
                SetFileReadOnlyAttribute(tempPath, false);
            }

            if (File.Exists(this.GetIniPath(LegacyIniFile.F76Custom)))
            {
                tempPath = Path.Combine(backupPath, "Fallout76Custom.ini");
                File.Copy(this.GetIniPath(LegacyIniFile.F76Custom), tempPath);
                SetFileReadOnlyAttribute(tempPath, false);
            }

            if (File.Exists(this.GetIniPath(LegacyIniFile.F76Custom) + ".nwmodebak"))
            {
                tempPath = Path.Combine(backupPath, "Fallout76Custom.ini.nwmodebak");
                File.Copy(this.GetIniPath(LegacyIniFile.F76Custom) + ".nwmodebak", tempPath);
                SetFileReadOnlyAttribute(tempPath, false);
            }
        }

        protected void RemoveEmptySections(IniData data)
        {
            List<string> sectionNames = new List<string>();
            foreach (SectionData section in data.Sections)
                if (section.Keys.Count == 0)
                    sectionNames.Add(section.SectionName);
            foreach (string sectionName in sectionNames)
                data.Sections.RemoveSection(sectionName);
        }


        /*
         *********************************************************************************************************************************************
         * Save and load *.ini files
         ********************************************************************************************************************************************
         */

        public IniData LoadIni(string path, bool ignoreErrors)
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

        public IniData LoadIni(string path)
        {
            return LoadIni(path, true);
        }

        public void SaveIni(string path, IniData data, bool readOnly = false)
        {
            if (data == null)
                return;

            SetNTFSWritePermission(true);

            if (File.Exists(path))
                SetFileReadOnlyAttribute(path, false);

            RemoveEmptySections(data);
            this.iniParser.WriteFile(path, data, this.iniEncoding);

            if (readOnly)
                SetFileReadOnlyAttribute(path, readOnly);

            if (this.GetBool(LegacyIniFile.Config, "Preferences", "bDenyNTFSWritePermission", false))
                SetNTFSWritePermission(false);
        }


        /*
         *********************************************************************************************************************************************
         * ReadOnly
         ********************************************************************************************************************************************
         */

        protected void SetFileReadOnlyAttribute(string path, bool readOnly)
        {
            SetNTFSWritePermission(true);

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
            SetFileReadOnlyAttribute(this.GetIniPath(LegacyIniFile.F76), readOnly);
            SetFileReadOnlyAttribute(this.GetIniPath(LegacyIniFile.F76Prefs), readOnly);
            SetFileReadOnlyAttribute(this.GetIniPath(LegacyIniFile.F76Custom), readOnly);
        }

        public bool AreINIsReadOnly()
        {
            if (File.Exists(this.GetIniPath(LegacyIniFile.F76)) && File.Exists(this.GetIniPath(LegacyIniFile.F76Prefs)))
            {
                FileInfo fo76fi = new FileInfo(this.GetIniPath(LegacyIniFile.F76));
                FileInfo fo76Prefsfi = new FileInfo(this.GetIniPath(LegacyIniFile.F76Prefs));
                return fo76fi.IsReadOnly && fo76Prefsfi.IsReadOnly;
            }
            return false;
        }

        public void SetNTFSWritePermission(bool writePermission)
        {
            // https://stackoverflow.com/questions/7451861/setting-ntfs-permissions-in-c-net
            // https://stackoverflow.com/questions/11478917/programmatically-adding-permissions-to-a-folder/11479031

            // 'Allow' AND 'Deny' are ticked, wtf?
            // Explanation: https://answers.microsoft.com/en-us/windows/forum/all/permission-entry-neither-allow-nor-deny-is-checked/5d210777-b466-49e6-855a-6dc1e85563df

            DirectoryInfo dInfo = new DirectoryInfo(this.iniParentPath);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();

            FileSystemRights rights = FileSystemRights.Write;

            // SID: https://support.microsoft.com/en-in/help/243330/well-known-security-identifiers-in-windows-operating-systems
            // String account = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
            // SecurityIdentifier sidAll = new SecurityIdentifier("S-1-1-0");
            // SecurityIdentifier sidAdmins = new SecurityIdentifier("S-1-5-32-544");
            SecurityIdentifier sidUsers = new SecurityIdentifier("S-1-5-32-545");

            AccessControlType access = writePermission ? AccessControlType.Allow : AccessControlType.Deny;

            if (writePermission)
            {
                dSecurity.RemoveAccessRule(new FileSystemAccessRule(sidUsers, rights, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny));
                dSecurity.AddAccessRule(new FileSystemAccessRule(sidUsers, rights, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            }
            else
            {
                dSecurity.AddAccessRule(new FileSystemAccessRule(sidUsers, rights, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Deny));
                dSecurity.RemoveAccessRule(new FileSystemAccessRule(sidUsers, rights, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow));
            }
            dInfo.SetAccessControl(dSecurity);
        }



        /*
         *********************************************************************************************************************************************
         * GETTER AND SETTER
         ********************************************************************************************************************************************
         */

        public bool Exists(string section, string key)
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

        public bool Exists(LegacyIniFile f, string section, string key)
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
        public string GetString(string section, string key, string defaultValue)
        {
            string value = defaultValue;
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

        public string GetString(string section, string key)
        {
            string value = GetString(section, key, null);
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
        public string[] GetString(string[][] sectionKeyDefaultPairs)
        {
            string[] values = new string[sectionKeyDefaultPairs.Length];
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
                        string section = sectionKeyDefaultPairs[i][0];
                        string key = sectionKeyDefaultPairs[i][1];
                        if (data[section][key] != null)
                            values[i] = data[section][key];
                    }
                }
            }
            return values;
        }

        public string GetString(LegacyIniFile f, string section, string key)
        {
            string value = GetIniData(f)[section][key];
            if (value == null)
                throw new KeyNotFoundException($"Couldn't find [{section}] {key} in {GetIniName(f)}");
            return value;
        }

        public string GetString(LegacyIniFile f, string section, string key, string defaultValue)
        {
            string value = GetIniData(f)[section][key];
            return value != null ? value : defaultValue;
        }

        public bool GetBool(LegacyIniFile f, string section, string key)
        {
            return GetString(f, section, key) == "1";
        }

        public bool GetBool(LegacyIniFile f, string section, string key, bool defaultValue)
        {
            return GetString(f, section, key, defaultValue ? "1" : "0") == "1";
        }

        public bool GetBool(string section, string key)
        {
            return GetString(section, key) == "1";
        }

        public bool GetBool(string section, string key, bool defaultValue)
        {
            return GetString(section, key, defaultValue ? "1" : "0") == "1";
        }

        public float GetFloat(LegacyIniFile f, string section, string key)
        {
            return Utils.ToFloat(GetString(f, section, key));
        }

        public float GetFloat(LegacyIniFile f, string section, string key, float defaultValue)
        {
            return Utils.ToFloat(GetString(f, section, key, defaultValue.ToString(enUS)));
        }

        public float GetFloat(string section, string key)
        {
            return Utils.ToFloat(GetString(section, key));
        }

        public float GetFloat(string section, string key, float defaultValue)
        {
            return Utils.ToFloat(GetString(section, key, defaultValue.ToString(enUS)));
        }

        public uint GetUInt(LegacyIniFile f, string section, string key)
        {
            return Utils.ToUInt(GetString(f, section, key));
        }

        public uint GetUInt(LegacyIniFile f, string section, string key, uint defaultValue)
        {
            return Utils.ToUInt(GetString(f, section, key, defaultValue.ToString(enUS)));
        }

        public uint GetUInt(string section, string key)
        {
            return Utils.ToUInt(GetString(section, key));
        }

        public uint GetUInt(string section, string key, uint defaultValue)
        {
            return Utils.ToUInt(GetString(section, key, defaultValue.ToString(enUS)));
        }

        public int GetInt(LegacyIniFile f, string section, string key)
        {
            return Utils.ToInt(GetString(f, section, key));
        }

        public int GetInt(LegacyIniFile f, string section, string key, int defaultValue)
        {
            return Utils.ToInt(GetString(f, section, key, defaultValue.ToString(enUS)));
        }

        public int GetInt(string section, string key)
        {
            return Utils.ToInt(GetString(section, key));
        }

        public int GetInt(string section, string key, int defaultValue)
        {
            return Utils.ToInt(GetString(section, key, defaultValue.ToString(enUS)));
        }

        public long GetLong(LegacyIniFile f, string section, string key)
        {
            return Utils.ToLong(GetString(f, section, key));
        }

        public long GetLong(LegacyIniFile f, string section, string key, int defaultValue)
        {
            return Utils.ToLong(GetString(f, section, key, defaultValue.ToString(enUS)));
        }

        public long GetLong(string section, string key)
        {
            return Utils.ToLong(GetString(section, key));
        }

        public long GetLong(string section, string key, int defaultValue)
        {
            return Utils.ToLong(GetString(section, key, defaultValue.ToString(enUS)));
        }

        public void Set(LegacyIniFile f, string section, string key, string value)
        {
            GetIniData(f)[section][key] = value;

            // There's a nasty problem, that bugs me:
            // When you set some value ONLY in Prefs, but the value was also set in Custom by the user,
            // then the value in Custom will overshadow Prefs, when GetString is called.
            // Of course people start to report that their values are reset. Who can blame them?
            // Soooo, we are going to set the same value in Custom if IniFile f is something else but Custom. Great? Great.
            if (fixCustomIniDuplicateValues && (f == LegacyIniFile.F76 || f == LegacyIniFile.F76Prefs) && Exists(LegacyIniFile.F76Custom, section, key))
                this.fo76CustomData[section][key] = value;
        }

        public void Set(LegacyIniFile f, string section, string key, int value)
        {
            Set(f, section, key, Utils.ToString(value));
        }

        public void Set(LegacyIniFile f, string section, string key, uint value)
        {
            Set(f, section, key, Utils.ToString(value));
        }

        public void Set(LegacyIniFile f, string section, string key, long value)
        {
            Set(f, section, key, Utils.ToString(value));
        }

        public void Set(LegacyIniFile f, string section, string key, float value)
        {
            Set(f, section, key, Utils.ToString(value));
        }

        public void Set(LegacyIniFile f, string section, string key, double value)
        {
            Set(f, section, key, Utils.ToString(value));
        }

        public void Set(LegacyIniFile f, string section, string key, bool value)
        {
            Set(f, section, key, value ? "1" : "0");
        }

        public void Remove(LegacyIniFile f, string section, string key)
        {
            if (Exists(f, section, key))
                GetIniData(f)[section].RemoveKey(key);
        }

        public void RemoveAll(string section, string key)
        {
            Remove(LegacyIniFile.F76, section, key);
            Remove(LegacyIniFile.F76Prefs, section, key);
            Remove(LegacyIniFile.F76Custom, section, key);
        }





        public bool ExpectBool(string section, string key)
        {
            string value = this.GetString(section, key).Trim();
            return value == "1" || value == "0";
        }

        public bool ExpectInt(string section, string key)
        {
            string value = this.GetString(section, key).Trim();
            return Regex.IsMatch(value, @"^-?\d+$");
        }

        public bool ExpectUInt(string section, string key)
        {
            string value = this.GetString(section, key).Trim();
            return Regex.IsMatch(value, @"^\d+$");
        }

        public bool ExpectFloat(string section, string key)
        {
            string value = this.GetString(section, key).Trim();
            return Regex.IsMatch(value, @"-?[0-9\.]+");
        }



        /*
         *********************************************************************************************************************************************
         * Fixes for invalid *.ini files:
         ********************************************************************************************************************************************
         */

        protected void MergeLists(LegacyIniFile f, string section, string key)
        {
            string list = "";
            bool found = false;
            int i = -1;
            IEnumerable<string> lines = File.ReadLines(GetIniPath(f));
            foreach (string line in lines)
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
            list = string.Join<string>(",",
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
            if (!File.Exists(GetIniPath(LegacyIniFile.F76Custom)))
                return;
            MergeLists(LegacyIniFile.F76Custom, "Archive", "sResourceIndexFileList");
            MergeLists(LegacyIniFile.F76Custom, "Archive", "sResourceArchive2List");
            MergeLists(LegacyIniFile.F76Custom, "Archive", "sResourceDataDirsFinal");

            this.fo76CustomModTime = File.GetLastWriteTime(this.GetIniPath(LegacyIniFile.F76Custom));
        }







        /*
         *********************************************************************************************************************************************
         * Other stuff
         ********************************************************************************************************************************************
         */

        public void Merge(LegacyIniFile f, IniData d)
        {
            this.GetIniData(f).Merge(d);
        }

        // https://stackoverflow.com/questions/1873658/net-windows-forms-remember-windows-size-and-location
        public void SaveWindowState(string formName, Form form)
        {
            if (form.WindowState == FormWindowState.Maximized)
            {
                this.Set(LegacyIniFile.Config, formName, "iLocationX", form.RestoreBounds.Location.X);
                this.Set(LegacyIniFile.Config, formName, "iLocationY", form.RestoreBounds.Location.Y);
                this.Set(LegacyIniFile.Config, formName, "iWidth", form.RestoreBounds.Size.Width);
                this.Set(LegacyIniFile.Config, formName, "iHeight", form.RestoreBounds.Size.Height);
                this.Set(LegacyIniFile.Config, formName, "bMaximised", true);
            }
            else
            {
                this.Set(LegacyIniFile.Config, formName, "iLocationX", form.Location.X);
                this.Set(LegacyIniFile.Config, formName, "iLocationY", form.Location.Y);
                this.Set(LegacyIniFile.Config, formName, "iWidth", form.Size.Width);
                this.Set(LegacyIniFile.Config, formName, "iHeight", form.Size.Height);
                this.Set(LegacyIniFile.Config, formName, "bMaximised", false);
            }
            this.SaveConfig();
        }

        public void LoadWindowState(string formName, Form form)
        {
            int locX = this.GetInt(LegacyIniFile.Config, formName, "iLocationX", -1);
            int locY = this.GetInt(LegacyIniFile.Config, formName, "iLocationY", -1);
            if (locX >= 0 && locY >= 0)
                form.Location = new System.Drawing.Point(locX, locY);

            int width = this.GetInt(LegacyIniFile.Config, formName, "iWidth", form.Size.Width);
            int height = this.GetInt(LegacyIniFile.Config, formName, "iHeight", form.Size.Height);
            if (width >= form.MinimumSize.Width && height >= form.MinimumSize.Height)
                form.Size = new System.Drawing.Size(width, height);

            if (this.GetBool(LegacyIniFile.Config, formName, "bMaximised", false))
                form.WindowState = FormWindowState.Maximized;
        }

        public void SaveListViewState(string formName, ListView listView)
        {
            List<int> widths = new List<int>();
            foreach (ColumnHeader column in listView.Columns)
            {
                widths.Add(column.Width);
            }
            this.Set(LegacyIniFile.Config, formName, "sColumnWidths", string.Join(",", widths));
        }

        public void LoadListViewState(string formName, ListView listView)
        {
            List<int> lWidths = new List<int>();
            string[] sWidths = this.GetString(LegacyIniFile.Config, formName, "sColumnWidths", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string sWidth in sWidths)
                lWidths.Add(Convert.ToInt32(sWidth));

            int i = 0;
            foreach (ColumnHeader column in listView.Columns)
            {
                if (i < lWidths.Count)
                    column.Width = lWidths[i++];
            }
        }
    }
}
