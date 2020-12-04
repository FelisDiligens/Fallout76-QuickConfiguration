using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Drawing;
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

        public string APIKey;

        /// <summary>
        /// Whether the API key is valid.
        /// </summary>
        public bool ValidKey;

        public string UserName = "Anonymous";
        public long UserID;
        public Membership Status;

        public string ProfilePictureURL;
        public string ProfilePictureFileName;

        public string ProfilePictureFilePath
        {
            get => Path.Combine(NexusMods.FolderPath, ProfilePictureFileName);
        }

        public int DailyRateLimit;
        public int HourlyRateLimit;
        public string DailyRateLimitResetString;

        /// <summary>
        /// Whether the user is currently logged in.
        /// </summary>
        public bool IsLoggedIn
        {
            get { return ValidKey || UserID > 0; }
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
                    JObject json = request.GetJSON();

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
                        MsgBox.Get("failed").FormatText($"Server returned: HTTP {request.StatusCode}\n{request.GetJSON()["message"]}").Show(MessageBoxIcon.Error);
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
                Uri uri = new Uri(ProfilePictureURL);
                ProfilePictureFileName = "profile" + Path.GetExtension(Path.GetFileName(uri.LocalPath));

                // Download if non-existent:
                if (!File.Exists(ProfilePictureFilePath))
                    using (var client = new WebClient())
                        client.DownloadFile(ProfilePictureURL, ProfilePictureFilePath);
            }
            catch (UriFormatException exc)
            {
                // TODO: Handle exception
                Console.WriteLine($"Not a valid URL: '{ProfilePictureURL}'\nSystem.UriFormatException: {exc.Message}");
                ProfilePictureFileName = "";
            }
        }

        /// <summary>
        /// Saves user profile information to the configuration.
        /// </summary>
        public void Save()
        {
            IniFiles.Config.Set("NexusMods", "sAPIKey", APIKey);
            IniFiles.Config.Set("NexusMods", "iUserID", UserID);
            IniFiles.Config.Set("NexusMods", "bAPIKeyValid", ValidKey);
            IniFiles.Config.Set("NexusMods", "sUserName", UserName);
            IniFiles.Config.Set("NexusMods", "sProfileURL", ProfilePictureURL);
            IniFiles.Config.Set("NexusMods", "sProfile", ProfilePictureFileName);
            IniFiles.Config.Set("NexusMods", "iDailyRateLimit", DailyRateLimit);
            IniFiles.Config.Set("NexusMods", "iHourlyRateLimit", HourlyRateLimit);
            IniFiles.Config.Set("NexusMods", "sDailyRateLimitReset", DailyRateLimitResetString);
            IniFiles.Config.Set("NexusMods", "sMembership", Status.ToString());
            IniFiles.Config.Save();
        }

        /// <summary>
        /// Loads user profile information from the configuration.
        /// </summary>
        public void Load()
        {
            APIKey = IniFiles.Config.GetString("NexusMods", "sAPIKey", "");
            UserID = IniFiles.Config.GetLong("NexusMods", "iUserID", -1);
            ValidKey = IniFiles.Config.GetBool("NexusMods", "bAPIKeyValid", false);
            UserName = IniFiles.Config.GetString("NexusMods", "sUserName", "Anonymous");
            ProfilePictureURL = IniFiles.Config.GetString("NexusMods", "sPicURL", "");
            ProfilePictureFileName = IniFiles.Config.GetString("NexusMods", "sProfile", "");
            DailyRateLimit = IniFiles.Config.GetInt("NexusMods", "iDailyRateLimit", 0);
            HourlyRateLimit = IniFiles.Config.GetInt("NexusMods", "iHourlyRateLimit", 0);
            DailyRateLimitResetString = IniFiles.Config.GetString("NexusMods", "sDailyRateLimitReset", "");
            Enum.TryParse(IniFiles.Config.GetString("NexusMods", "sMembership", "Basic"), out Status);
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
            APIKey = "";
            ValidKey = false;
            UserName = "Anonymous";
            UserID = -1;
            ProfilePictureFileName = "";
            ProfilePictureURL = "";
            Status = Membership.Basic;
            DailyRateLimit = 0;
            HourlyRateLimit = 0;
            DailyRateLimitResetString = "";

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

            try
            {
                if (File.Exists(ProfilePictureFileName))
                    File.Delete(ProfilePictureFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Couldn't remove profile picture: {ex.Message}");
            }
        }
    }
}
