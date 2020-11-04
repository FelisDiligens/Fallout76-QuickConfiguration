using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Fo76ini
{
    public static class NexusMods
    {
        private static readonly object padlock = new object();
        private static NMProfile _nmprofile = null;

        public static Dictionary<int, NMMod> Mods = new Dictionary<int, NMMod>();

        public static NMProfile Profile
        {
            get
            {
                lock (padlock)
                {
                    if (_nmprofile == null)
                        _nmprofile = new NMProfile();
                    return _nmprofile;
                }
            }
        }

        public static void Save()
        {
            if (Shared.GamePath == null)
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(Path.Combine(Shared.GamePath, "Mods")))
                Directory.CreateDirectory(Path.Combine(Shared.GamePath, "Mods"));

            Serialize().Save(Path.Combine(Shared.GamePath, "Mods", "remote.xml"));

            NexusMods.Profile.Save();
        }

        public static XDocument Serialize()
        {
            /*
             Fallout76\Mods\remote.xml
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

        public static void Load()
        {
            Form1.logFile.WriteLine("[NexusMods]\tLoading...");

            Mods.Clear();

            NexusMods.Profile.Load();

            if (Shared.GamePath == null)
                return;

            String path = Path.Combine(Shared.GamePath, "Mods", "remote.xml");

            if (!File.Exists(path))
                return;

            XDocument xmlDoc = XDocument.Load(path);
            foreach (XElement xmlMod in xmlDoc.Descendants("Mod"))
            {
                try
                {
                    NMMod mod = NMMod.Deserialize(xmlMod);
                    Mods[mod.ID] = mod;
                }
                catch (Exception ex)
                {
                    /* InvalidDataException, ArgumentException */
                    //MsgBox.Get("modsInvalidManifestEntry").FormatText(ex.Message).Show(MessageBoxIcon.Warning);
                    // TODO: Handle invalid entries.
                }
            }
        }

        public static void RefreshModInfo(String url)
        {
            NMMod mod = new NMMod(url);
            mod.RequestInformation();
            Mods[mod.ID] = mod;
        }

        public static void ClearRemoteInfo()
        {
            Mods.Clear();

            String path = Path.Combine(Shared.GamePath, "Mods", "remote.xml");
            if (!File.Exists(path))
                File.Delete(path);
        }

        public static int GetIDFromURL(String url)
        {
            // "https://www.nexusmods.com/fallout76/mods/419?tab=files"
            if (url == "" || !url.Contains("www.nexusmods.com/fallout76/mods"))
                return -1;

            String modId = url.Substring(url.IndexOf("fallout76/mods/") + 15);
            if (modId.Contains("?"))
                modId = modId.Substring(0, modId.IndexOf("?"));

            return Convert.ToInt32(modId);
        }
    }

    public class NMMod
    {
        public int ID = -1;
        public String URL = "";
        public String LatestVersion = "";
        public String ThumbnailURL = "";
        public String Thumbnail = "";
        public String Title = "";

        public NMMod (String url)
        {
            this.URL = url;
            this.ID = NexusMods.GetIDFromURL(url);
        }

        public NMMod (int id)
        {
            this.ID = id;
            this.URL = $"https://www.nexusmods.com/fallout76/mods/{id}";
        }

        public void RequestInformation()
        {
            // Make API request:
            APIRequest request = new APIRequest("https://api.nexusmods.com/v1/games/fallout76/mods/" + this.ID + ".json");
            request.Headers["apikey"] = NexusMods.Profile.APIKey;
            request.Execute();
            if (request.Success && request.StatusCode == 200)
            {
                // Get data:
                JObject json = request.GetJSON();
                this.Title = json["name"].ToString();
                this.ThumbnailURL = json["picture_url"].ToString();
                this.LatestVersion = json["version"].ToString();

                // Download thumbnail:
                String folderPath = Path.Combine(Shared.GamePath, "Mods", "_thumbs");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                try
                {
                    //Uri uri = new Uri(this.ThumbnailURL);
                    String thumbName = $"thumb_{this.ID}.jpg"; //Path.GetExtension(Path.GetFileName(uri.LocalPath));
                    String thumbPath = Path.Combine(folderPath, thumbName);

                    this.Thumbnail = "_thumbs\\" + thumbName;

                    // "https://staticdelivery.nexusmods.com/mods/2590/images/84/84-1542823522-262308780.png"

                    // Download if non-existent:
                    /*if (!File.Exists(thumbPath))
                        using (var client = new WebClient())
                            client.DownloadFile(this.ThumbnailURL, thumbPath);*/

                    if (!File.Exists(thumbPath))
                    {
                        var thumbRequest = WebRequest.Create(this.ThumbnailURL);
                        using (var thumbResponse = thumbRequest.GetResponse())
                        using (var stream = thumbResponse.GetResponseStream())
                        {
                            Image image = Image.FromStream(stream);
                            Utils.MakeThumbnail(image, thumbPath, 360, 190, 90L);
                            //Image thumb = image.GetThumbnailImage(360, 190, () => false, IntPtr.Zero);
                            //thumb.Save(thumbPath);
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Failed.
                    // TODO: Handle: Thumbnail couldn't be downloaded.
                    Console.WriteLine($"Couldn't download thumbnail.\n{ex.GetType().Name}: {ex.Message}");
                }
            }
            else
            {
                // TODO: Handle: Couldn't retrieve info.
                Console.WriteLine($"Couldn't retrieve info.\n{request.Exception.GetType().Name}: {request.Exception.Message}\n{request.GetText()}");
            }
        }

        public XElement Serialize()
        {
            XElement xmlMod = new XElement("Mod");

            xmlMod.Add(new XAttribute("url", this.URL));

            if (this.Title != "")
                xmlMod.Add(new XAttribute("title", this.Title));

            if (this.LatestVersion != "")
                xmlMod.Add(new XAttribute("latestVersion", this.LatestVersion));

            if (this.Thumbnail != "")
                xmlMod.Add(new XAttribute("thumbnail", this.Thumbnail));

            if (this.ThumbnailURL != "")
                xmlMod.Add(new XAttribute("thumbnailUrl", this.ThumbnailURL));

            return xmlMod;
        }

        public static NMMod Deserialize(XElement xmlMod)
        {
            if (xmlMod.Attribute("url") == null)
                throw new InvalidDataException("'url' attribute wasn't provided.");

            NMMod mod = new NMMod(xmlMod.Attribute("url").Value);

            if (xmlMod.Attribute("latestVersion") != null)
                mod.LatestVersion = xmlMod.Attribute("latestVersion").Value;

            if (xmlMod.Attribute("thumbnailUrl") != null)
                mod.ThumbnailURL = xmlMod.Attribute("thumbnailUrl").Value;

            if (xmlMod.Attribute("thumbnail") != null)
                mod.Thumbnail = xmlMod.Attribute("thumbnail").Value;

            if (xmlMod.Attribute("title") != null)
                mod.Title = xmlMod.Attribute("title").Value;

            return mod;
        }
    }

    public class NMProfile
    {
        public enum Membership
        {
            Basic,
            Supporter,
            Premium
        }

        public String APIKey;
        public String UserName = "Anonymous";
        public String ProfilePictureURL;
        public String ProfilePicture;
        public Membership Status;
        public int DailyRateLimit;
        public String DailyRateLimitResetString;
        public DateTime DailyRateLimitReset;
        public bool ValidKey;

        public NMProfile() { }

        public void Update()
        {
            Form1.logFile.WriteLine("[NMProfile]\tUpdating...");

            // Make API request:
            APIRequest request = new APIRequest("https://api.nexusmods.com/v1/users/validate.json");
            request.Headers["apikey"] = this.APIKey;
            request.Execute();
            if (request.Success && request.StatusCode == 200)
            {
                JObject json = request.GetJSON();

                this.UserName = json["name"].ToString();
                this.ProfilePictureURL = json["profile_url"].ToString();

                if (json["is_premium"].Value<bool>() || json["is_premium?"].Value<bool>())
                    this.Status = Membership.Premium;
                else if (json["is_supporter"].Value<bool>() || json["is_supporter?"].Value<bool>())
                    this.Status = Membership.Supporter;
                else
                    this.Status = Membership.Basic;

                this.DailyRateLimit = Convert.ToInt32(request.ResponseHeaders["x-rl-daily-remaining"]);
                this.DailyRateLimitResetString = request.ResponseHeaders["x-rl-daily-reset"];
                ParseDailyRateLimitReset();

                DownloadProfilePicture();

                /*
                 Unused values:
                  - "user_id"
                  - "key"
                  - "email"
                 */
                
                ValidKey = true;
            }
            else
            {
                if (request.Success)
                    MsgBox.Get("nexusModsProfileRefreshFailed").FormatText($"Server returned: HTTP {request.StatusCode}\n{request.GetJSON()["message"].ToString()}").Show(MessageBoxIcon.Error);
                else
                    MsgBox.Get("nexusModsProfileRefreshFailed").FormatText($"WebException: {request.Exception.Message}").Show(MessageBoxIcon.Error);

                ValidKey = false;
            }
        }

        private void DownloadProfilePicture()
        {
            try
            {
                Uri uri = new Uri(this.ProfilePictureURL);
                this.ProfilePicture = "profile" + Path.GetExtension(Path.GetFileName(uri.LocalPath));
                String path = Path.Combine(Shared.AppConfigFolder, this.ProfilePicture);

                // Download if non-existent:
                if (!File.Exists(path))
                    using (var client = new WebClient())
                        client.DownloadFile(this.ProfilePictureURL, path);
            }
            catch (System.UriFormatException exc)
            {
                Console.WriteLine($"Not a valid URL: '{this.ProfilePictureURL}'\nSystem.UriFormatException: {exc.Message}");
                this.ProfilePicture = "";
            }
        }

        public void Save()
        {
            Form1.logFile.WriteLine("[NMProfile]\tSaving...");

            IniFiles.Instance.Set(IniFile.Config, "NexusMods", "sAPIKey", this.APIKey);
            IniFiles.Instance.Set(IniFile.Config, "NexusMods", "bAPIKeyValid", this.ValidKey);
            IniFiles.Instance.Set(IniFile.Config, "NexusMods", "sUserName", this.UserName);
            IniFiles.Instance.Set(IniFile.Config, "NexusMods", "sProfileURL", this.ProfilePictureURL);
            IniFiles.Instance.Set(IniFile.Config, "NexusMods", "sProfile", this.ProfilePicture);
            IniFiles.Instance.Set(IniFile.Config, "NexusMods", "iDailyRateLimit", this.DailyRateLimit);
            IniFiles.Instance.Set(IniFile.Config, "NexusMods", "sDailyRateLimitReset", this.DailyRateLimitResetString);
            switch (this.Status)
            {
                case Membership.Supporter:
                    IniFiles.Instance.Set(IniFile.Config, "NexusMods", "uStatus", 1);
                    break;
                case Membership.Premium:
                    IniFiles.Instance.Set(IniFile.Config, "NexusMods", "uStatus", 2);
                    break;
                default:
                    IniFiles.Instance.Set(IniFile.Config, "NexusMods", "uStatus", 0);
                    break;
            }
            IniFiles.Instance.SaveConfig();
        }

        public void Load()
        {
            Form1.logFile.WriteLine("[NMProfile]\tLoading...");

            this.APIKey = IniFiles.Instance.GetString(IniFile.Config, "NexusMods", "sAPIKey", "");
            this.ValidKey = IniFiles.Instance.GetBool(IniFile.Config, "NexusMods", "bAPIKeyValid", false);
            this.UserName = IniFiles.Instance.GetString(IniFile.Config, "NexusMods", "sUserName", "Anonymous");
            this.ProfilePictureURL = IniFiles.Instance.GetString(IniFile.Config, "NexusMods", "sPicURL", "");
            this.ProfilePicture = IniFiles.Instance.GetString(IniFile.Config, "NexusMods", "sProfile", "");
            this.DailyRateLimit = IniFiles.Instance.GetInt(IniFile.Config, "NexusMods", "iDailyRateLimit", 0);
            this.DailyRateLimitResetString = IniFiles.Instance.GetString(IniFile.Config, "NexusMods", "sDailyRateLimitReset", "");
            int status = IniFiles.Instance.GetInt(IniFile.Config, "NexusMods", "uStatus", 0);
            switch (status)
            {
                case 1:
                    this.Status = Membership.Supporter;
                    break;
                case 2:
                    this.Status = Membership.Premium;
                    break;
                default:
                    this.Status = Membership.Basic;
                    break;
            }
            ParseDailyRateLimitReset();
        }

        private void ParseDailyRateLimitReset()
        {
            try
            {
                this.DailyRateLimitReset = DateTime.ParseExact(this.DailyRateLimitResetString, "yyyy-MM-dd HH:mm:ss zzz", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (System.FormatException e)
            {
                // TODO: Handle this.
            }
        }

        public void Remove()
        {
            this.APIKey = "";
            this.ValidKey = false;
            this.UserName = "Anonymous";
            this.ProfilePicture = "";
            this.ProfilePictureURL = "";
            this.Status = Membership.Basic;
            this.DailyRateLimit = 0;
            this.DailyRateLimitResetString = "";

            IniFiles.Instance.Remove(IniFile.Config, "NexusMods", "sAPIKey");
            IniFiles.Instance.Remove(IniFile.Config, "NexusMods", "bAPIKeyValid");
            IniFiles.Instance.Remove(IniFile.Config, "NexusMods", "sUserName");
            IniFiles.Instance.Remove(IniFile.Config, "NexusMods", "sProfileURL");
            IniFiles.Instance.Remove(IniFile.Config, "NexusMods", "sProfile");
            IniFiles.Instance.Remove(IniFile.Config, "NexusMods", "iDailyRateLimit");
            IniFiles.Instance.Remove(IniFile.Config, "NexusMods", "sDailyRateLimitReset");
            IniFiles.Instance.Remove(IniFile.Config, "NexusMods", "uStatus");

            IniFiles.Instance.SaveConfig();

            try
            {
                if (File.Exists(this.ProfilePicture))
                    File.Delete(this.ProfilePicture);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Couldn't remove profile picture: {ex.Message}");
            }
        }
    }

    public class APIRequest
    {
        public String url;

        private HttpWebRequest request;
        private HttpWebResponse response;

        public WebException Exception;
        private bool success;

        public APIRequest(String url)
        {
            this.url = url;
            this.request = (HttpWebRequest)WebRequest.Create(this.url);
        }

        public void Execute()
        {
            this.success = false;
            try
            {
                this.response = (HttpWebResponse)request.GetResponse();
                this.success = true;
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    this.response = (HttpWebResponse)ex.Response;
                    this.success = true;
                }
                this.Exception = ex;
            }
        }

        public String GetText()
        {
            String resp;
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                resp = reader.ReadToEnd();
            }
            return resp;
        }

        public JObject GetJSON()
        {
            return JObject.Parse(this.GetText());
        }

        public WebHeaderCollection ResponseHeaders
        {
            get => response.Headers;
        }

        public WebHeaderCollection Headers
        {
            get => request.Headers;
        }

        public int StatusCode
        {
            get => (int)response.StatusCode;
        }

        public bool Success
        {
            get => this.success;
        }

        public String UserAgent
        {
            get => this.request.UserAgent;
            set => this.request.UserAgent = value;
        }

        public String Accept
        {
            get => this.request.Accept;
            set => this.request.Accept = value;
        }
    }
}
