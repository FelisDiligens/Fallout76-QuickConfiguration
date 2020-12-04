﻿using Fo76ini.Profiles;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Fo76ini
{
    public static class IniFiles
    {
        public static IniFile F76;
        public static IniFile F76Prefs;
        public static IniFile F76Custom;
        public static IniFile Config;

        public static readonly string ParentPath;
        public static readonly string ConfigPath;
        public static readonly string DefaultsPath;

        public static readonly string DefaultF76Path;
        public static readonly string DefaultF76PrefsPath;

        static IniFiles()
        {
            ParentPath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                @"My Games\Fallout 76\"
            );

            ConfigPath = Path.Combine(Shared.AppConfigFolder, "config.ini");

            DefaultsPath = Path.Combine(Shared.AppInstallationFolder, "DefaultINI");
            DefaultF76Path = Path.Combine(DefaultsPath, "Fallout76.ini");
            DefaultF76PrefsPath = Path.Combine(DefaultsPath, "Medium.ini");
        }

        public static void LoadConfig()
        {
            Config = new IniFile(ConfigPath);
            Config.Load();
        }

        public static void Load(GameInstance game)
        {
            F76 = new IniFile(
                Path.Combine(ParentPath, $"{game.IniPrefix}.ini"),
                DefaultF76Path
            );
            F76Prefs = new IniFile(
                Path.Combine(ParentPath, $"{game.IniPrefix}Prefs.ini"),
                DefaultF76PrefsPath
            );
            F76Custom = new IniFile(
                Path.Combine(ParentPath, $"{game.IniPrefix}Custom.ini")
           );

            F76.Load();
            F76Prefs.Load();
            F76Custom.Load();

            FixDuplicateResourceLists();
        }

        public static bool IsLoaded()
        {
            return
                F76 != null &&
                F76Prefs != null &&
                F76Custom != null &&
                F76.IsLoaded() &&
                F76Prefs.IsLoaded() &&
                F76Custom.IsLoaded();
        }

        public static void SetINIsReadOnly(bool readOnly)
        {
            F76.IsReadOnly = readOnly;
            F76Prefs.IsReadOnly = readOnly;
            F76Custom.IsReadOnly = readOnly;
        }

        public static bool AreINIsReadOnly()
        {
            return F76.IsReadOnly && F76Prefs.IsReadOnly;
        }

        public static void Save()
        {
            Backup();
            F76.Save();
            F76Prefs.Save();
            F76Custom.Save();
            Config.Save();
        }

        public static void Backup()
        {
            string backupDir = Path.Combine(ParentPath, "Backups", DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
            Directory.CreateDirectory(backupDir);
            File.Copy(F76.FilePath, Path.Combine(backupDir, F76.FileName), true);
            File.Copy(F76Prefs.FilePath, Path.Combine(backupDir, F76Prefs.FileName), true);
            File.Copy(F76Custom.FilePath, Path.Combine(backupDir, F76Custom.FileName), true);
        }

        public static bool FilesHaveBeenModified()
        {
            return F76.FileHasBeenModified() || F76Prefs.FileHasBeenModified() || F76Custom.FileHasBeenModified();
        }

        public static void UpdateLastModifiedDates()
        {
            F76.UpdateLastModifiedDate();
            F76Prefs.UpdateLastModifiedDate();
            F76Custom.UpdateLastModifiedDate();
        }


        /*
         *********************************************************************************************************************************************
         * GETTER AND SETTER
         ********************************************************************************************************************************************
         */

        public static bool Exists(string section, string key)
        {
            foreach (IniFile ini in new IniFile[] { F76, F76Prefs, F76Custom })
                if (ini.Exists(section, key))
                    return true;
            return false;
        }

        public static string GetString(string section, string key, string defaultValue)
        {
            string value = defaultValue;
            foreach (IniFile ini in new IniFile[] { F76, F76Prefs, F76Custom })
                if (ini.Exists(section, key))
                    value = ini.GetString(section, key);
            return value;
        }

        public static string GetString(string section, string key)
        {
            string value = GetString(section, key, null);
            if (value == null)
                throw new KeyNotFoundException($"Couldn't find [{section}] {key} in any *.ini file.");
            return value;
        }

        public static bool GetBool(string section, string key)
        {
            return GetString(section, key) == "1";
        }

        public static bool GetBool(string section, string key, bool defaultValue)
        {
            string value = GetString(section, key, defaultValue ? "1" : "0");
            if (IniFile.ValidBoolValues.Contains(value))
                return value == "1";
            else
                return defaultValue;
        }

        public static float GetFloat(string section, string key)
        {
            return Utils.ToFloat(GetString(section, key));
        }

        public static float GetFloat(string section, string key, float defaultValue)
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

        public static uint GetUInt(string section, string key)
        {
            return Utils.ToUInt(GetString(section, key));
        }

        public static uint GetUInt(string section, string key, uint defaultValue)
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

        public static int GetInt(string section, string key)
        {
            return Utils.ToInt(GetString(section, key));
        }

        public static int GetInt(string section, string key, int defaultValue)
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

        public static long GetLong(string section, string key)
        {
            return Utils.ToLong(GetString(section, key));
        }

        public static long GetLong(string section, string key, int defaultValue)
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

        /*
         *********************************************************************************************************************************************
         * Fixes for invalid *.ini files:
         ********************************************************************************************************************************************
         */

        private static void MergeLists(IniFile ini, string section, string key)
        {
            string list = "";
            bool found = false;
            int i = -1;
            IEnumerable<string> lines = File.ReadLines(ini.FilePath);
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
                ini.Set(section, key, list);
        }

        private static void FixDuplicateResourceLists()
        {
            // People seem to have duplicate key=value pairs of sResourceIndexFileList and sResourceArchive2List
            // Merge them. Default behaviour of the Parser is overriding and this is probably not what the user wants.
            // sResourceDataDirsFinal added in v.1.3.1
            // Case insensitive, and whitespace around '=' ignored as of v1.4

            if (!File.Exists(F76Custom.FilePath))
                return;

            MergeLists(F76Custom, "Archive", "sResourceIndexFileList");
            MergeLists(F76Custom, "Archive", "sResourceArchive2List");
            MergeLists(F76Custom, "Archive", "sResourceDataDirsFinal");
        }

        /*
         *********************************************************************************************************************************************
         * Backwards-compatibility:
         ********************************************************************************************************************************************
         */

        /// <summary>
        /// Allows or denies write permission to the *.ini parent path (%USERPROFILE%\Documents\My Games\Fallout 76).
        /// </summary>
        /// <param name="writePermission">true to allow, false to deny</param>
        /// <returns>true if successful, false otherwise</returns>
        public static bool SetNTFSWritePermission(bool writePermission)
        {
            try
            {
                // https://stackoverflow.com/questions/7451861/setting-ntfs-permissions-in-c-net
                // https://stackoverflow.com/questions/11478917/programmatically-adding-permissions-to-a-folder/11479031

                // 'Allow' AND 'Deny' are ticked, wtf?
                // Explanation: https://answers.microsoft.com/en-us/windows/forum/all/permission-entry-neither-allow-nor-deny-is-checked/5d210777-b466-49e6-855a-6dc1e85563df

                DirectoryInfo dInfo = new DirectoryInfo(ParentPath);
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
            catch
            {
                return false;
            }

            return true;
        }
    }
}
