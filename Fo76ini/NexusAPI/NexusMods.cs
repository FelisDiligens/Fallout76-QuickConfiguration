using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;
using Fo76ini.Interface;
using Fo76ini.Utilities;

namespace Fo76ini.NexusAPI
{
    public static class NexusMods
    {
        private static readonly object padlock = new object();
        private static NMProfile _nmprofile = null;

        public static Dictionary<int, NMMod> Mods = new Dictionary<int, NMMod>();

        public static string FolderPath = Path.Combine(Shared.AppConfigFolder, "nexusmods");
        public static string ThumbnailsPath = Path.Combine(Shared.AppConfigFolder, "thumbnails", "nexusmods");
        public static string RemoteXMLPath = Path.Combine(NexusMods.FolderPath, "remote.xml"); // Path.Combine(Shared.GamePath, "Mods", "remote.xml")

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

        public static bool IsLoggedIn
        {
            get { return NexusMods.Profile.ValidKey || NexusMods.Profile.UserID > 0; }
        }

        public static void Save()
        {
            /*if (Shared.GamePath == null)
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Error);
                return;
            }*/

            if (!Directory.Exists(NexusMods.FolderPath))
                Directory.CreateDirectory(NexusMods.FolderPath);

            Serialize().Save(NexusMods.RemoteXMLPath);

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
            Mods.Clear();

            NexusMods.Profile.Load();

            /*if (Shared.GamePath == null)
                return;*/

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
                catch// (Exception ex)
                {
                    /* InvalidDataException, ArgumentException */
                    //MsgBox.Get("modsInvalidManifestEntry").FormatText(ex.Message).Show(MessageBoxIcon.Warning);
                    // TODO: Handle invalid entries.
                }
            }
        }

        public static void RefreshModInfo(string url)
        {
            NMMod mod = new NMMod(url);
            mod.RequestInformation();
            Mods[mod.ID] = mod;
        }

        public static void ClearRemoteInfo()
        {
            Mods.Clear();

            if (File.Exists(NexusMods.RemoteXMLPath))
                File.Delete(NexusMods.RemoteXMLPath);
        }

        public static int GetIDFromURL(string url)
        {
            // "https://www.nexusmods.com/fallout76/mods/419?tab=files"
            if (url == "" || !url.Contains("www.nexusmods.com/fallout76/mods"))
                return -1;

            string modId = url.Substring(url.IndexOf("fallout76/mods/") + 15);
            if (modId.Contains("?"))
                modId = modId.Substring(0, modId.IndexOf("?"));

            return Convert.ToInt32(modId);
        }
    }

    public class NMMod
    {
        public int ID = -1;
        public string URL = "";
        public string Title = "";
        public string LatestVersion = "";
        public string Author = "";
        public string Uploader = "";
        public string Summary = "";
        public int EndorsementCount = 0;
        public string Thumbnail = "";
        public string ThumbnailURL = "";
        public long CreatedTimestamp = -1;
        public long UpdatedTimestamp = -1;
        public long LastAccessTimestamp = -1;
        public bool ContainsAdultContent = false;
        public EndorseStatus Endorsement = EndorseStatus.Undecided;

        public enum EndorseStatus
        {
            Undecided,
            Endorsed,
            Abstained
        }

        public NMMod(string url)
        {
            this.URL = url;
            this.ID = NexusMods.GetIDFromURL(url);
        }

        public NMMod(int id)
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
                this.Author = json["author"].ToString();
                this.Uploader = json["uploaded_by"].ToString();
                this.Summary = json["summary"].ToString();
                this.EndorsementCount = json["endorsement_count"].ToObject<int>();
                this.CreatedTimestamp = json["created_timestamp"].ToObject<long>();
                this.UpdatedTimestamp = json["updated_timestamp"].ToObject<long>();
                this.ContainsAdultContent = json["contains_adult_content"].ToObject<bool>();
                this.ThumbnailURL = json["picture_url"].ToString();
                this.LatestVersion = json["version"].ToString();

                JObject endorsement = (JObject)json["endorsement"];
                string endorseStatus = endorsement["endorse_status"].ToString();
                switch (endorseStatus)
                {
                    case "Endorsed":
                        this.Endorsement = EndorseStatus.Endorsed;
                        break;
                    case "Abstained":
                        this.Endorsement = EndorseStatus.Abstained;
                        break;
                    case "Undecided":
                    default:
                        this.Endorsement = EndorseStatus.Undecided;
                        break;
                }

                // Download thumbnail:
                if (!Directory.Exists(NexusMods.ThumbnailsPath))
                    Directory.CreateDirectory(NexusMods.ThumbnailsPath);

                if (IniFiles.Config.GetBool("NexusMods", "bDownloadThumbnailsOnUpdate", true))
                {
                    try
                    {
                        string thumbName = $"thumb_{this.ID}.jpg"; // Path.GetExtension(Path.GetFileName(uri.LocalPath));
                        string thumbPath = Path.Combine(NexusMods.ThumbnailsPath, thumbName);

                        this.Thumbnail = thumbName;

                        // "https://staticdelivery.nexusmods.com/mods/2590/images/84/84-1542823522-262308780.png"

                        // Download if non-existent:
                        if (!File.Exists(thumbPath))
                        {
                            var thumbRequest = WebRequest.Create(this.ThumbnailURL);
                            using (var thumbResponse = thumbRequest.GetResponse())
                            using (var stream = thumbResponse.GetResponseStream())
                            {
                                Image image = Image.FromStream(stream);
                                Utils.MakeThumbnail(image, thumbPath, 360, 190, 90L);
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
                    Console.WriteLine("Thumbnail download disabled. (bDownloadThumbnailsOnUpdate=0)");
                }
            }
            else
            {
                // TODO: Handle: Couldn't retrieve info.
                Console.WriteLine($"Couldn't retrieve info.\n{request.Exception.GetType().Name}: {request.Exception.Message}\n{request.GetText()}");
            }
            this.LastAccessTimestamp = Utils.GetUnixTimeStamp();
        }

        public XElement Serialize()
        {
            XElement xmlMod = new XElement("Mod",
                new XAttribute("id", this.ID),
                new XAttribute("nsfw", this.ContainsAdultContent));

            if (this.Title != "")
                xmlMod.Add(new XElement("Title", this.Title));

            if (this.LatestVersion != "")
                xmlMod.Add(new XElement("Version", this.LatestVersion));

            if (this.Author != "")
                xmlMod.Add(new XElement("CreatedBy", this.Author));

            if (this.Uploader != "")
                xmlMod.Add(new XElement("UploadedBy", this.Uploader));

            xmlMod.Add(new XElement("EndorsementCount", this.EndorsementCount));
            xmlMod.Add(new XElement("CreatedTimestamp", this.CreatedTimestamp));
            xmlMod.Add(new XElement("UpdatedTimestamp", this.UpdatedTimestamp));

            string endorseState = Enum.GetName(typeof(EndorseStatus), (int)this.Endorsement);
            xmlMod.Add(new XElement("EndorseState", endorseState));

            xmlMod.Add(new XElement("Summary", this.Summary));

            if (this.Thumbnail != "" && this.ThumbnailURL != "")
            {
                XElement thumbnail = new XElement("Thumbnail");
                thumbnail.Add(new XElement("URL", this.ThumbnailURL));
                thumbnail.Add(new XElement("File", this.Thumbnail));
                xmlMod.Add(thumbnail);
            }

            xmlMod.Add(new XElement("LastUpdated", this.LastAccessTimestamp));

            return xmlMod;
        }

        public static NMMod Deserialize(XElement xmlMod)
        {
            if (xmlMod.Attribute("id") == null)
                throw new InvalidDataException("'id' attribute wasn't provided.");

            NMMod mod = new NMMod(Convert.ToInt32(xmlMod.Attribute("id").Value));

            if (xmlMod.Element("Title") != null)
                mod.Title = xmlMod.Element("Title").Value;

            if (xmlMod.Element("Version") != null)
                mod.LatestVersion = xmlMod.Element("Version").Value;

            if (xmlMod.Element("CreatedBy") != null)
                mod.Author = xmlMod.Element("CreatedBy").Value;

            if (xmlMod.Element("UploadedBy") != null)
                mod.Uploader = xmlMod.Element("UploadedBy").Value;

            if (xmlMod.Element("Summary") != null)
                mod.Summary = xmlMod.Element("Summary").Value;

            if (xmlMod.Element("EndorsementCount") != null)
                mod.EndorsementCount = Convert.ToInt32(xmlMod.Element("EndorsementCount").Value);

            if (xmlMod.Element("CreatedTimestamp") != null)
                mod.CreatedTimestamp = Convert.ToInt64(xmlMod.Element("CreatedTimestamp").Value);

            if (xmlMod.Element("UpdatedTimestamp") != null)
                mod.UpdatedTimestamp = Convert.ToInt64(xmlMod.Element("UpdatedTimestamp").Value);

            if (xmlMod.Attribute("nsfw") != null)
                mod.ContainsAdultContent = Convert.ToBoolean(xmlMod.Attribute("nsfw").Value);

            XElement thumbnail = xmlMod.Element("Thumbnail");
            if (thumbnail != null)
            {
                mod.ThumbnailURL = thumbnail.Element("URL").Value;
                mod.Thumbnail = thumbnail.Element("File").Value;
            }

            if (xmlMod.Element("EndorseState") != null)
            {
                switch (xmlMod.Element("EndorseState").Value)
                {
                    case "Endorsed":
                        mod.Endorsement = EndorseStatus.Endorsed;
                        break;
                    case "Abstained":
                        mod.Endorsement = EndorseStatus.Abstained;
                        break;
                    case "Undecided":
                    default:
                        mod.Endorsement = EndorseStatus.Undecided;
                        break;
                }
            }

            if (xmlMod.Element("LastUpdated") != null)
                mod.LastAccessTimestamp = Convert.ToInt64(xmlMod.Element("LastUpdated").Value);

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

        public string APIKey;
        public long UserID;
        public string UserName = "Anonymous";
        public string ProfilePictureURL;
        public string ProfilePicture;
        public Membership Status;
        public int DailyRateLimit;
        public int HourlyRateLimit;
        public string DailyRateLimitResetString;
        public DateTime DailyRateLimitReset;
        public bool ValidKey;

        public NMProfile() { }

        public void Update()
        {
            // Make API request:
            APIRequest request = new APIRequest("https://api.nexusmods.com/v1/users/validate.json");
            request.Headers["apikey"] = this.APIKey;
            request.Execute();
            if (request.Success && request.StatusCode == 200)
            {
                try
                {
                    JObject json = request.GetJSON();

                    this.UserName = json["name"].ToString();
                    this.ProfilePictureURL = json["profile_url"].ToString();
                    this.UserID = Convert.ToInt64(json["user_id"].ToString());

                    if (json["is_premium"].Value<bool>() || json["is_premium?"].Value<bool>())
                        this.Status = Membership.Premium;
                    else if (json["is_supporter"].Value<bool>() || json["is_supporter?"].Value<bool>())
                        this.Status = Membership.Supporter;
                    else
                        this.Status = Membership.Basic;

                    this.DailyRateLimit = Convert.ToInt32(request.ResponseHeaders["x-rl-daily-remaining"]);
                    this.DailyRateLimitResetString = request.ResponseHeaders["x-rl-daily-reset"];
                    this.HourlyRateLimit = Convert.ToInt32(request.ResponseHeaders["X-RL-Hourly-Remaining"]);
                    ParseDailyRateLimitReset();

                    DownloadProfilePicture();

                    /*
                     Unused values:
                      - "key"
                      - "email"
                     */

                    ValidKey = true;
                }
                catch (Exception e)
                {
                    MsgBox.Get("failed").FormatText($"Unexpected exception: {e.Message}").Show(MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (request.Success)
                        MsgBox.Get("failed").FormatText($"Server returned: HTTP {request.StatusCode}\n{request.GetJSON()["message"].ToString()}").Show(MessageBoxIcon.Error);
                    else
                        MsgBox.Get("failed").FormatText($"WebException: {request.Exception.Message}").Show(MessageBoxIcon.Error);
                }
                catch (Exception e)
                {
                    MsgBox.Get("failed").FormatText($"Unexpected exception: {e.Message}").Show(MessageBoxIcon.Error);
                }

                ValidKey = false;
            }
        }

        private void DownloadProfilePicture()
        {
            try
            {
                Uri uri = new Uri(this.ProfilePictureURL);
                this.ProfilePicture = "profile" + Path.GetExtension(Path.GetFileName(uri.LocalPath));
                string path = Path.Combine(NexusMods.FolderPath, this.ProfilePicture);

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
            IniFiles.Config.Set("NexusMods", "sAPIKey", this.APIKey);
            IniFiles.Config.Set("NexusMods", "iUserID", this.UserID);
            IniFiles.Config.Set("NexusMods", "bAPIKeyValid", this.ValidKey);
            IniFiles.Config.Set("NexusMods", "sUserName", this.UserName);
            IniFiles.Config.Set("NexusMods", "sProfileURL", this.ProfilePictureURL);
            IniFiles.Config.Set("NexusMods", "sProfile", this.ProfilePicture);
            IniFiles.Config.Set("NexusMods", "iDailyRateLimit", this.DailyRateLimit);
            IniFiles.Config.Set("NexusMods", "iHourlyRateLimit", this.HourlyRateLimit);
            IniFiles.Config.Set("NexusMods", "sDailyRateLimitReset", this.DailyRateLimitResetString);
            switch (this.Status)
            {
                case Membership.Supporter:
                    IniFiles.Config.Set("NexusMods", "uStatus", 1);
                    break;
                case Membership.Premium:
                    IniFiles.Config.Set("NexusMods", "uStatus", 2);
                    break;
                default:
                    IniFiles.Config.Set("NexusMods", "uStatus", 0);
                    break;
            }
            IniFiles.Config.Save();
        }

        public void Load()
        {
            this.APIKey = IniFiles.Config.GetString("NexusMods", "sAPIKey", "");
            this.UserID = IniFiles.Config.GetLong("NexusMods", "iUserID", -1);
            this.ValidKey = IniFiles.Config.GetBool("NexusMods", "bAPIKeyValid", false);
            this.UserName = IniFiles.Config.GetString("NexusMods", "sUserName", "Anonymous");
            this.ProfilePictureURL = IniFiles.Config.GetString("NexusMods", "sPicURL", "");
            this.ProfilePicture = IniFiles.Config.GetString("NexusMods", "sProfile", "");
            this.DailyRateLimit = IniFiles.Config.GetInt("NexusMods", "iDailyRateLimit", 0);
            this.HourlyRateLimit = IniFiles.Config.GetInt("NexusMods", "iHourlyRateLimit", 0);
            this.DailyRateLimitResetString = IniFiles.Config.GetString("NexusMods", "sDailyRateLimitReset", "");
            int status = IniFiles.Config.GetInt("NexusMods", "uStatus", 0);
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
            catch// (System.FormatException e)
            {
                // TODO: Handle this.
            }
        }

        public void Remove()
        {
            this.APIKey = "";
            this.ValidKey = false;
            this.UserName = "Anonymous";
            this.UserID = -1;
            this.ProfilePicture = "";
            this.ProfilePictureURL = "";
            this.Status = Membership.Basic;
            this.DailyRateLimit = 0;
            this.HourlyRateLimit = 0;
            this.DailyRateLimitResetString = "";

            IniFiles.Config.Remove("NexusMods", "sAPIKey");
            IniFiles.Config.Remove("NexusMods", "bAPIKeyValid");
            IniFiles.Config.Remove("NexusMods", "sUserName");
            IniFiles.Config.Remove("NexusMods", "iUserID");
            IniFiles.Config.Remove("NexusMods", "sProfileURL");
            IniFiles.Config.Remove("NexusMods", "sProfile");
            IniFiles.Config.Remove("NexusMods", "iDailyRateLimit");
            IniFiles.Config.Remove("NexusMods", "iHourlyRateLimit");
            IniFiles.Config.Remove("NexusMods", "sDailyRateLimitReset");
            IniFiles.Config.Remove("NexusMods", "uStatus");

            IniFiles.Config.Save();

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
        public string url;

        private HttpWebRequest request;
        private HttpWebResponse response;

        public WebException Exception;
        private bool success;

        public APIRequest(string url)
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

        public string GetText()
        {
            string resp;
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

        public string UserAgent
        {
            get => this.request.UserAgent;
            set => this.request.UserAgent = value;
        }

        public string Accept
        {
            get => this.request.Accept;
            set => this.request.Accept = value;
        }
    }
}
