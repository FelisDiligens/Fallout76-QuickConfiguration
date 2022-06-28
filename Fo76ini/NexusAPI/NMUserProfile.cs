using System;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Xml.Linq;
using Fo76ini.Interface;
using Fo76ini.Utilities;

namespace Fo76ini.NexusAPI
{
    public class NMUserProfile
    {
        public enum Membership
        {
            Basic,
            Supporter,
            Premium
        }

        public string APIKey = "";

        public string UserName = "Anonymous";
        public long UserID = -1;
        public Membership Status = Membership.Basic;

        public string ProfilePictureURL = "";
        public string ProfilePictureFileName = "";

        public string ProfilePictureFilePath
        {
            get => Path.Combine(NexusMods.FolderPath, ProfilePictureFileName);
        }

        public int DailyRateLimit = 0;
        public int HourlyRateLimit = 0;
        public string DailyRateLimitResetString = "";

        /// <summary>
        /// Whether the user is currently logged in.
        /// </summary>
        public bool IsLoggedIn
        {
            get { return APIKey != null && APIKey != "" && UserID > 0; }
        }

        public NMUserProfile() { }

        /// <summary>
        /// Updates profile information.
        /// </summary>
        public void Update()
        {
            // Make API request:
            APIRequest request = new APIRequest($"{NexusMods.APIDomain}/v1/users/validate.json");
            request.Headers["apikey"] = APIKey;
            request.Execute();
            if (request.Success && request.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    JObject json = request.GetJObject();

                    UserName = json["name"].ToString();
                    ProfilePictureURL = json["profile_url"].ToString();
                    UserID = Convert.ToInt64(json["user_id"].ToString());

                    if (json["is_premium"].Value<bool>() || json["is_premium?"].Value<bool>())
                        Status = Membership.Premium;
                    else if (json["is_supporter"].Value<bool>() || json["is_supporter?"].Value<bool>())
                        Status = Membership.Supporter;
                    else
                        Status = Membership.Basic;

                    DailyRateLimit = Convert.ToInt32(request.ResponseHeaders["x-rl-daily-remaining"]);
                    DailyRateLimitResetString = request.ResponseHeaders["x-rl-daily-reset"];
                    HourlyRateLimit = Convert.ToInt32(request.ResponseHeaders["X-RL-Hourly-Remaining"]);

                    DownloadProfilePicture();

                    /*
                     Unused values:
                      - "key"
                      - "email"
                     */
                }
                catch (Exception e)
                {
                    MsgBox.Get("failed").FormatText($"Unexpected exception: {e.Message}\n{e.StackTrace}\n\n{e.InnerException}").Show(MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    if (request.Success)
                        MsgBox.Get("failed").FormatText($"Server returned: HTTP {request.StatusCode}\n{request.GetJObject()["message"]}").Show(MessageBoxIcon.Error);
                    else
                        MsgBox.Get("failed").FormatText($"WebException: {request.Exception.Message}").Show(MessageBoxIcon.Error);
                }
                catch (Exception e)
                {
                    MsgBox.Get("failed").FormatText($"Unexpected exception: {e.Message}").Show(MessageBoxIcon.Error);
                }
            }
        }

        private void DownloadProfilePicture()
        {
            try
            {
                Uri uri = new Uri(ProfilePictureURL);
                ProfilePictureFileName = "profile" + Path.GetExtension(Path.GetFileName(uri.LocalPath));

                // Download if non-existent:
                if (!File.Exists(ProfilePictureFilePath))
                {
                    Directory.CreateDirectory(NexusMods.FolderPath);
                    using (var client = new WebClient())
                        client.DownloadFile(ProfilePictureURL, ProfilePictureFilePath);
                }
            }
            catch (UriFormatException exc)
            {
                // TODO: Handle exception
                Console.WriteLine($"Not a valid URL: '{ProfilePictureURL}'\nSystem.UriFormatException: {exc.Message}");
                ProfilePictureFileName = "";
            }
        }

        /// <summary>
        /// Saves user profile information to account.xml
        /// </summary>
        public void Save()
        {
            /*
             <Account id="41275740">
                 <Authentification>
                     <APIKey>xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx</APIKey>
                 </Authentification>
                 <Profile>
                     <Username>datasnake01</Username>
                     <Membership>Premium</Membership>
                     <Picture url="https://xxxxxxx" file="profile.jpg"/>
                 </Profile>
                 <RateLimit daily="2500" hourly="100">
                     <DailyResetTime>2020-12-07 00:00:00 +0010</DailyResetTime>
                 </RateLimit>
             </Account>
             */

            XDocument xmlDoc = new XDocument();
            XElement xmlRoot = new XElement("Account", new XAttribute("id", UserID));
            xmlDoc.Add(xmlRoot);

            /*
             * Authentification
             */

            // Add apikey:
            XElement xmlAuth = new XElement("Authentification");
            if (APIKey != null && APIKey != "")
                xmlAuth.Add(new XElement("APIKey", APIKey));
            xmlRoot.Add(xmlAuth);


            /*
             * Profile
             */

            XElement xmlProfile = new XElement("Profile",
                new XElement("Username", UserName),
                new XElement("Membership", Status.ToString())
            );
            xmlRoot.Add(xmlProfile);

            if (ProfilePictureURL != "" && ProfilePictureFileName != "")
            {
                xmlProfile.Add(new XElement("Picture",
                    new XAttribute("url", ProfilePictureURL),
                    new XAttribute("file", ProfilePictureFileName)
                ));
            }


            /*
             * RateLimit
             */

            xmlRoot.Add(new XElement("RateLimit",
                new XAttribute("daily", DailyRateLimit),
                new XAttribute("hourly", HourlyRateLimit),
                new XElement("DailyResetTime", DailyRateLimitResetString)
            ));

            xmlDoc.Save(NexusMods.AccountXMLPath);
        }

        /// <summary>
        /// Loads user profile information from account.xml
        /// </summary>
        public bool Load()
        {
            if (!File.Exists(NexusMods.AccountXMLPath))
                return false;

            XDocument xmlDoc = XDocument.Load(NexusMods.AccountXMLPath);
            XElement xmlRoot = xmlDoc.Root;

            if (xmlRoot.Attribute("id") != null)
                if (!xmlRoot.Attribute("id").TryParseLong(out UserID))
                    UserID = -1;

            /*
             * Authentification
             */

            XElement xmlAuth = xmlRoot.Element("Authentification");
            if (xmlAuth != null && xmlAuth.Element("APIKey") != null)
                APIKey = xmlAuth.Element("APIKey").Value;


            /*
             * Profile
             */

            XElement xmlProfile = xmlRoot.Element("Profile");
            if (xmlProfile != null)
            {
                if (xmlProfile.Element("Username") != null)
                    UserName = xmlProfile.Element("Username").Value;
                if (xmlProfile.Element("Membership") != null)
                    Enum.TryParse(xmlProfile.Element("Membership").Value, out Status);

                // Profile picture
                XElement xmlProfilePicture = xmlProfile.Element("Picture");
                if (xmlProfilePicture != null && xmlProfilePicture.Attribute("url") != null && xmlProfilePicture.Attribute("file") != null)
                {
                    ProfilePictureURL = xmlProfilePicture.Attribute("url").Value;
                    ProfilePictureFileName = xmlProfilePicture.Attribute("file").Value;
                }
            }


            /*
             * RateLimit
             */

            XElement xmlRateLimit = xmlRoot.Element("RateLimit");
            if (xmlRateLimit != null)
            {
                if (xmlRateLimit.Attribute("daily") != null)
                    xmlRateLimit.Attribute("daily").TryParseInt(out DailyRateLimit);

                if (xmlRateLimit.Attribute("hourly") != null)
                    xmlRateLimit.Attribute("hourly").TryParseInt(out HourlyRateLimit);

                if (xmlRateLimit.Element("DailyResetTime") != null)
                    DailyRateLimitResetString = xmlRateLimit.Element("DailyResetTime").Value;
            }

            return true;
        }

        public bool TryParseDailyRateLimitReset(out DateTime result)
        {
            try
            {
                result = DateTime.ParseExact(DailyRateLimitResetString, "yyyy-MM-dd HH:mm:ss zzz", System.Globalization.CultureInfo.InvariantCulture);
                return true;
            }
            catch
            {
                result = DateTime.Now;
                return false;
            }
        }

        /// <summary>
        /// Removes user profile information and thumbnail.
        /// </summary>
        public void Remove()
        {
            // Remove old values from config.ini:
            IniFiles.Config.Remove("NexusMods", "sAPIKey");
            IniFiles.Config.Remove("NexusMods", "bAPIKeyValid");
            IniFiles.Config.Remove("NexusMods", "sUserName");
            IniFiles.Config.Remove("NexusMods", "iUserID");
            IniFiles.Config.Remove("NexusMods", "sProfileURL");
            IniFiles.Config.Remove("NexusMods", "sProfile");
            IniFiles.Config.Remove("NexusMods", "iDailyRateLimit");
            IniFiles.Config.Remove("NexusMods", "iHourlyRateLimit");
            IniFiles.Config.Remove("NexusMods", "sDailyRateLimitReset");
            IniFiles.Config.Remove("NexusMods", "sMembership");
            IniFiles.Config.Save();

            // Remove accounts.xml:
            if (File.Exists(NexusMods.AccountXMLPath))
                File.Delete(NexusMods.AccountXMLPath);

            // Remove profile picture:
            try
            {
                if (File.Exists(ProfilePictureFilePath))
                    File.Delete(ProfilePictureFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Couldn't remove profile picture: {ex.Message}");
            }

            // Reset values:
            APIKey = "";
            UserName = "Anonymous";
            UserID = -1;
            ProfilePictureFileName = "";
            ProfilePictureURL = "";
            Status = Membership.Basic;
            DailyRateLimit = 0;
            HourlyRateLimit = 0;
            DailyRateLimitResetString = "";
        }
    }
}
