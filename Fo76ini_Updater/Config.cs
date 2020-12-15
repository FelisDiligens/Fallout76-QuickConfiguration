using Fo76ini;
using IniParser;
using IniParser.Model;
using IniParser.Model.Configuration;
using IniParser.Parser;
using System;
using System.IO;
using System.Text;

namespace Fo76ini_Updater
{
    public class Config
    {
        IniFile config;

        public Config()
        {
            config = new IniFile(IniFiles.ConfigPath);
            config.Load();
        }

        public void LoadIni()
        {
            config.Load();
        }

        public void SaveIni()
        {
            config.Save();
        }


        /*
         * Convienient getter & setter
         */

        public String InstalledVersion
        {
            get { return config.GetString("General", "sVersion", "1.0.0"); }
            set { config.Set("General", "sVersion", value); }
        }

        public String LatestVersion
        {
            get { return config.GetString("Updater", "sTagName"); }
            set { config.Set("Updater", "sTagName", value); }
        }

        public bool HasVersionStrings()
        {
            return config.Exists("Updater", "sTagName") && config.Exists("General", "sVersion");
        }

        public String DownloadURL
        {
            get { return config.GetString("Updater", "sLastDownloadURL"); }
            set { config.Set("Updater", "sLastDownloadURL", value); }
        }

        public String DownloadFileName
        {
            get { return config.GetString("Updater", "sLastDownloadFileName"); }
            set { config.Set("Updater", "sLastDownloadFileName", value); }
        }

        public bool HasCachedDownloadURL()
        {
            return config.Exists("Updater", "sLastDownloadURL") && config.Exists("Updater", "sLastDownloadFileName");
        }

        public String ETag
        {
            get { return config.GetString("Updater", "sAPI_ETag"); }
            set { config.Set("Updater", "sAPI_ETag", value); }
        }

        public bool HasETag()
        {
            return config.Exists("Updater", "sAPI_ETag");
        }

        public String LastModified
        {
            get { return config.GetString("Updater", "sAPI_Last-Modified"); }
            set { config.Set("Updater", "sAPI_Last-Modified", value); }
        }

        public bool HasLastModified()
        {
            return config.Exists("Updater", "sAPI_Last-Modified");
        }

        public String InstallationPath
        {
            get { return config.GetString("Updater", "sInstallationPath"); }
            set { config.Set("Updater", "sInstallationPath", value); }
        }

        public bool HasInstallationPath()
        {
            return config.Exists("Updater", "sInstallationPath");
        }
    }
}
