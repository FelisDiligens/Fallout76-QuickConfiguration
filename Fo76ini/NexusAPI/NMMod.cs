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
        public EndorseStatus Endorsement = EndorseStatus.Undecided;
        public bool ContainsAdultContent = false;

        public string ThumbnailURL = "";
        public string ThumbnailFileName = "";

        public string ThumbnailFilePath
        {
            get => Path.Combine(NexusMods.ThumbnailsPath, ThumbnailFileName);
        }

        public long CreatedTimestamp = -1;
        public long UpdatedTimestamp = -1;
        public long LastAccessTimestamp = -1;

        public enum EndorseStatus
        {
            Undecided,
            Endorsed,
            Abstained
        }

        /// <summary>
        /// Creates a new mod from a URL.
        /// </summary>
        /// <param name="url">URL to the mod page.</param>
        public NMMod(string url)
        {
            this.URL = url;
            this.ID = NexusMods.GetIDFromURL(url);
        }

        /// <summary>
        /// Creates a new mod from an ID.
        /// </summary>
        /// <param name="id">Mod ID</param>
        public NMMod(int id)
        {
            this.ID = id;
            this.URL = $"https://www.nexusmods.com/fallout76/mods/{id}";
        }

        /// <summary>
        /// Sends a request to the API and retrieves all mod information.
        /// Will (optionally) download thumbnails.
        /// </summary>
        public void RequestInformation()
        {
            if (!NexusMods.User.IsLoggedIn)
            {
                MsgBox.ShowID("nexusModsNotLoggedIn", MessageBoxIcon.Information);
                return;
            }

            // Make API request:
            APIRequest request = new APIRequest("https://api.nexusmods.com/v1/games/fallout76/mods/" + this.ID + ".json");
            request.Headers["apikey"] = NexusMods.User.APIKey;
            request.Execute();
            if (request.Success && request.StatusCode == HttpStatusCode.OK)
            {
                /*
                 * Get data:
                 */

                JObject json = request.GetJObject();
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


                /*
                 * Download thumbnail:
                 */

                if (!Directory.Exists(NexusMods.ThumbnailsPath))
                    Directory.CreateDirectory(NexusMods.ThumbnailsPath);

                // If user opted in:
                if (IniFiles.Config.GetBool("NexusMods", "bDownloadThumbnailsOnUpdate", true))
                {
                    try
                    {
                        // Example: "https://staticdelivery.nexusmods.com/mods/2590/images/84/84-1542823522-262308780.png"

                        // Download if non-existent:
                        ThumbnailFileName = $"thumb_{this.ID}.jpg"; // Path.GetExtension(Path.GetFileName(uri.LocalPath));
                        if (!File.Exists(ThumbnailFilePath))
                        {
                            var thumbRequest = WebRequest.Create(this.ThumbnailURL);
                            using (var thumbResponse = thumbRequest.GetResponse())
                            using (var stream = thumbResponse.GetResponseStream())
                            {
                                // Create a thumbnail (small *.jpg) from the downloaded image:
                                Image image = Image.FromStream(stream);
                                Utils.MakeThumbnail(image, ThumbnailFilePath, false, 400, 160, 90L);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // TODO: Handle: Thumbnail couldn't be downloaded.
                        Console.WriteLine($"Couldn't download thumbnail.\n{ex.GetType().Name}: {ex.Message}");
                    }
                }
            }
            else
            {
                // TODO: Handle: Couldn't retrieve info.
                Console.WriteLine($"Couldn't retrieve info.\n{request.Exception.GetType().Name}: {request.Exception.Message}\n{request.ResponseText}");
            }
            this.LastAccessTimestamp = Utils.GetUnixTimeStamp();
        }

        /// <summary>
        /// Requests a download link for a file.
        /// </summary>
        /// <param name="nxmLink"></param>
        /// <returns></returns>
        public static string RequestDownloadLink(string nxmLink)
        {
            // nxm://fallout76/mods/<mod_id>/files/<file_id>?key=...&expires=1621492286&user_id=41275740
            if (!nxmLink.StartsWith("nxm://"))
                return null;

            string key = "";
            string expires = "-1";

            string modId = nxmLink.Substring(nxmLink.IndexOf("fallout76/mods/") + 15);
            modId = modId.Substring(0, modId.IndexOf("/files/"));

            string fileId = nxmLink.Substring(nxmLink.IndexOf("/files/") + 7);
            if (fileId.Contains("?"))
                fileId = fileId.Substring(0, fileId.IndexOf("?"));

            if (nxmLink.Contains("key="))
            {
                key = nxmLink.Substring(nxmLink.IndexOf("key=") + 4);
                if (key.Contains("&"))
                    key = key.Substring(0, key.IndexOf("&"));
            }

            if (nxmLink.Contains("expires="))
            {
                expires = nxmLink.Substring(nxmLink.IndexOf("expires=") + 8);
                if (expires.Contains("&"))
                    expires = expires.Substring(0, expires.IndexOf("&"));
            }

            return RequestDownloadLink(
                Utils.ToInt(modId),
                Utils.ToInt(fileId),
                key,
                Utils.ToInt(expires)
            );
        }

        /// <summary>
        /// Requests a download link for a file.
        /// </summary>
        /// <param name="modId"></param>
        /// <param name="fileId"></param>
        /// <param name="key"></param>
        /// <param name="expires"></param>
        /// <returns></returns>
        public static string RequestDownloadLink(int modId, int fileId, string key = "", int expires = -1)
        {
            string requestUrl = "https://api.nexusmods.com/v1/games/fallout76/mods/" + modId + "/files/" + fileId + "/download_link.json";
            if (key != null && key != "" && expires > 0)
                requestUrl += "?key=" + key + "&expires=" + expires;

            APIRequest request = new APIRequest(requestUrl);
            request.Headers["apikey"] = NexusMods.User.APIKey;
            request.Execute();
            if (request.Success && request.StatusCode == HttpStatusCode.OK)
            {
                List<string> links = new List<string>();
                JArray list = request.GetJArray();
                foreach (JToken obj in list)
                {
                    links.Add(
                        ((JObject)obj)["URI"].ToString()
                    );
                }
                if (links.Count() > 0)
                    return links[0];
                return null;
            }

            return null;
        }

        /// <summary>
        /// Endorses this mod.
        /// </summary>
        /// <param name="endorsedVersion">Version that will be endorsed.</param>
        /// <returns>true if successful; false otherwise</returns>
        public bool Endorse(string endorsedVersion)
        {
            APIRequest request = new APIRequest("https://api.nexusmods.com/v1/games/fallout76/mods/" + this.ID + "/endorse.json");
            request.Headers["apikey"] = NexusMods.User.APIKey;
            request.Method = "POST";

            // Without a version: {"code":400,"message":"You must provide a version"}
            request.RequestContentType = "application/x-www-form-urlencoded";
            request.PostData = $"version={endorsedVersion}";

            request.Execute();
            if (request.Success)
            {
                JObject json = request.GetJObject();
                if (json.ContainsKey("status") && json["status"].ToString() == "Endorsed")
                {
                    this.Endorsement = EndorseStatus.Endorsed;
                    return true;
                }
                else
                {
                    MsgBox.Get("failed").FormatText($"Couldn't endorse mod.\nServer message: {json["message"]}").Show(MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MsgBox.Get("failed").FormatText($"Couldn't endorse mod.\nError: {request.Exception.Message}").Show(MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Abstains from endorsing this mod.
        /// </summary>
        /// <param name="endorsedVersion">Version that will be abstained.</param>
        /// <returns>true if successful; false otherwise</returns>
        public bool Abstain(string abstainedVersion)
        {
            APIRequest request = new APIRequest("https://api.nexusmods.com/v1/games/fallout76/mods/" + this.ID + "/abstain.json");
            request.Headers["apikey"] = NexusMods.User.APIKey;
            request.Method = "POST";

            // Without a version: {"code":400,"message":"You must provide a version"}
            request.RequestContentType = "application/x-www-form-urlencoded";
            request.PostData = $"version={abstainedVersion}";

            request.Execute();
            if (request.Success)
            {
                JObject json = request.GetJObject();
                if (json.ContainsKey("status") && json["status"].ToString() == "Abstained")
                {
                    this.Endorsement = EndorseStatus.Abstained;
                    return true;
                }
                else
                {
                    MsgBox.Get("failed").FormatText($"Couldn't abstain from endorsing mod.\nServer message: {json["message"]}").Show(MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                MsgBox.Get("failed").FormatText($"Couldn't abstain from endorsing mod.\nError: {request.Exception.Message}").Show(MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Serializes this mod to an XML element.
        /// </summary>
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

            if (this.ThumbnailFileName != "" && this.ThumbnailURL != "")
            {
                XElement thumbnail = new XElement("Thumbnail");
                thumbnail.Add(new XElement("URL", this.ThumbnailURL));
                thumbnail.Add(new XElement("File", this.ThumbnailFileName));
                xmlMod.Add(thumbnail);
            }

            xmlMod.Add(new XElement("LastUpdated", this.LastAccessTimestamp));

            return xmlMod;
        }

        /// <summary>
        /// Deserializes an XML element to a NMMod.
        /// </summary>
        /// <param name="xmlMod"></param>
        /// <returns></returns>
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
                mod.ThumbnailFileName = thumbnail.Element("File").Value;
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
}
