using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Fo76ini.Utilities;

namespace Fo76ini.NexusAPI
{
    public static class NexusMods
    {
        public const string APIDomain = "https://api.nexusmods.com";
        public const string SSODomain = "wss://sso.nexusmods.com";
        public const string ApplicationSlug = "fo76quickconfiguration";
        public const string ApplicationName = "Fallout 76 Quick Configuration";

        public static string FolderPath = Path.Combine(Shared.AppConfigFolder, "nexusmods");
        public static string ThumbnailsPath = Path.Combine(Shared.AppConfigFolder, "thumbnails", "nexusmods");
        public static string RemoteXMLPath = Path.Combine(NexusMods.FolderPath, "mods.xml");
        public static string AccountXMLPath = Path.Combine(NexusMods.FolderPath, "account.xml");

        public static Dictionary<int, NMMod> Mods = new Dictionary<int, NMMod>();

        private static readonly object padlock = new object();
        private static NMUserProfile _nmprofile = null;

        static NexusMods ()
        {
            SingleSignOn.SSOFinished += OnSSOLogin;
        }

        public static NMUserProfile User
        {
            get
            {
                lock (padlock)
                {
                    if (_nmprofile == null)
                        _nmprofile = new NMUserProfile();
                    return _nmprofile;
                }
            }
        }

        /// <summary>
        /// Saves the user's profile and mods.
        /// </summary>
        public static void Save()
        {
            if (!Directory.Exists(NexusMods.FolderPath))
                Directory.CreateDirectory(NexusMods.FolderPath);

            Serialize().Save(NexusMods.RemoteXMLPath);

            NexusMods.User.Save();
        }

        /// <summary>
        /// Serializes all mods to an *.xml document.
        /// </summary>
        public static XDocument Serialize()
        {
            /*
             Fallout 76 Quick Configuration\nexusmods\remote.xml
             <Mods>
                <Mod ... />
                <Mod ... />
                <Mod ... />
             </Mods>
             */

            XDocument xmlDoc = new XDocument();
            XElement xmlRoot = new XElement("Mods");
            xmlDoc.Add(xmlRoot);
            foreach (NMMod mod in Mods.Values)
                xmlRoot.Add(mod.Serialize());
            return xmlDoc;
        }

        /// <summary>
        /// Loads the user's profile and mods.
        /// </summary>
        public static void Load()
        {
            Mods.Clear();

            NexusMods.User.Load();

            if (!File.Exists(NexusMods.RemoteXMLPath))
                return;

            XDocument xmlDoc = XDocument.Load(NexusMods.RemoteXMLPath);
            foreach (XElement xmlMod in xmlDoc.Descendants("Mod"))
            {
                try
                {
                    NMMod mod = NMMod.Deserialize(xmlMod);
                    Mods[mod.ID] = mod;
                }
                catch
                {
                    // TODO: Handle invalid entries.
                }
            }
        }

        private static void OnSSOLogin(object sender, SSOEventArgs e)
        {
            /*if (e.success)
            {
                User.APIKey = e.APIKey;
                User.Save();
            }*/
        }

        /// <summary>
        /// Requests remote information about a mod.
        /// </summary>
        /// <param name="url">The url to the mod page. Example: "https://www.nexusmods.com/fallout76/mods/419?tab=files"</param>
        public static NMMod RequestModInformation(string url)
        {
            NMMod mod = new NMMod(url);
            mod.RequestInformation();
            Mods[mod.ID] = mod;
            return mod;
        }

        /// <summary>
        /// Requests remote information about a mod.
        /// </summary>
        public static NMMod RequestModInformation(int modId)
        {
            NMMod mod = new NMMod(modId);
            mod.RequestInformation();
            Mods[mod.ID] = mod;
            return mod;
        }

        /// <summary>
        /// Deletes any downloaded information about mods and it's thumbnails.
        /// </summary>
        public static void DeleteCache()
        {
            // Remove remote info:
            Mods.Clear();

            if (File.Exists(NexusMods.RemoteXMLPath))
                File.Delete(NexusMods.RemoteXMLPath);

            // Delete thumbnails
            try
            {
                string path = Path.Combine(NexusMods.ThumbnailsPath);
                Utils.DeleteDirectory(path);
            }
            catch
            {
                // TODO: Handle exceptions.
            }
        }

        /// <summary>
        /// Extracts the mod ID from a URL.
        /// </summary>
        /// <param name="url">The url to the mod page. Example: "https://www.nexusmods.com/fallout76/mods/419?tab=files"</param>
        /// <returns>The mod ID. Example: 419</returns>
        public static int GetIDFromURL(string url)
        {
            if (url == "" || !url.Contains("www.nexusmods.com/") || !url.Contains("/mods/"))
                return -1;

            string modId = url.Substring(url.IndexOf("/mods/") + 6);
            if (modId.Contains("?"))
                modId = modId.Substring(0, modId.IndexOf("?"));

            if (Int32.TryParse(modId, out int result))
                return result;
            return -1;
        }

        /// <summary>
        /// Extracts the game from a URL.
        /// </summary>
        /// <param name="url">The url to the mod page. Example: "https://www.nexusmods.com/fallout76/mods/419?tab=files"</param>
        /// <returns>The game. Example: "fallout76"</returns>
        public static string GetGameFromURL(string url)
        {
            if (url == "" || !url.Contains("www.nexusmods.com/") || !url.Contains("/mods/"))
                return null;

            int start = url.IndexOf("nexusmods.com/") + 14;
            int end = url.IndexOf("/mods/");
            string game = url.Substring(start, end - start);

            return game;
        }
    }
}
