using IniParser;
using IniParser.Model;
using IniParser.Model.Configuration;
using IniParser.Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini_Updater
{
    public class Config
    {
        FileIniDataParser iniParser;
        IniData config;
        String iniPath;

        public Config ()
        {
            iniPath = Path.Combine(Updater.AppConfigFolder, "config.ini");
            LoadIni();
        }

        public void LoadIni()
        {
            IniParserConfiguration iniParserConfig = new IniParserConfiguration();
            iniParserConfig.AllowCreateSectionsOnFly = true;
            iniParserConfig.AssigmentSpacer = "";
            iniParserConfig.CaseInsensitive = true;
            iniParserConfig.CommentRegex = new System.Text.RegularExpressions.Regex(@";.*");

            this.iniParser = new FileIniDataParser(new IniDataParser(iniParserConfig));
            config = this.iniParser.ReadFile(iniPath, new UTF8Encoding(false));
        }

        public void SaveIni()
        {
            this.iniParser.WriteFile(this.iniPath, this.config, new UTF8Encoding(false));
        }

        /*
         * Getter & Setter
         */

        public bool Has(String section, String key)
        {
            return config[section][key] != null;
        }

        public String GetString(String section, String key)
        {
            return config[section][key];
        }

        public void Set(String section, String key, String value)
        {
            config[section][key] = value;
        }


        /*
         * Convienient getter & setter
         */

        public String InstalledVersion
        {
            get { return this.GetString("General", "sVersion"); }
            set { this.Set("General", "sVersion", value); }
        }

        public String LatestVersion
        {
            get { return this.GetString("Updater", "sTagName"); }
            set { this.Set("Updater", "sTagName", value); }
        }

        public bool HasVersionStrings()
        {
            return this.Has("Updater", "sTagName") && this.Has("General", "sVersion");
        }

        public String DownloadURL
        {
            get { return this.GetString("Updater", "sLastDownloadURL"); }
            set { this.Set("Updater", "sLastDownloadURL", value); }
        }

        public String DownloadFileName
        {
            get { return this.GetString("Updater", "sLastDownloadFileName"); }
            set { this.Set("Updater", "sLastDownloadFileName", value); }
        }

        public bool HasCachedDownloadURL()
        {
            return this.Has("Updater", "sLastDownloadURL") && this.Has("Updater", "sLastDownloadFileName");
        }

        public String ETag
        {
            get { return this.GetString("Updater", "sAPI_ETag"); }
            set { this.Set("Updater", "sAPI_ETag", value); }
        }

        public bool HasETag()
        {
            return this.Has("Updater", "sAPI_ETag");
        }

        public String LastModified
        {
            get { return this.GetString("Updater", "sAPI_Last-Modified"); }
            set { this.Set("Updater", "sAPI_Last-Modified", value); }
        }

        public bool HasLastModified()
        {
            return this.Has("Updater", "sAPI_Last-Modified");
        }

        public String InstallationPath
        {
            get { return this.GetString("Updater", "sInstallationPath"); }
            set { this.Set("Updater", "sInstallationPath", value); }
        }

        public bool HasInstallationPath()
        {
            return this.Has("Updater", "sInstallationPath");
        }
    }
}
