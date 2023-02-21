using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.API.BethesdaNet
{
    public class BethesdaNetAPI
    {
        /// <summary>
        /// Request the server status from Bethesda.net's API.
        /// </summary>
        /// <returns>Server status</returns>
        public static String ScrapeServerStatus()
        {
            string f76Status = "unknown";

            // Send request:
            // Previous URL: https://bethesda.net/en/status/api/statuses
            APIRequest request = new APIRequest("https://status.bethesda.net/en/status/api/statuses");
            request.Execute();

            if (request.Success && request.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    // Scrap for Fallout 76 Status:
                    JObject responseJSON = request.GetJObject();
                    JArray components = (JArray)responseJSON["components"];
                    foreach (JObject component in components)
                    {
                        string id = component["id"].ToObject<string>();
                        string name = component["name"].ToObject<string>();
                        string status = component["status"].ToObject<string>();

                        if (id == "m39k311rzvkg" || name == "Fallout 76")
                            f76Status = status;
                    }
                }
                catch (Newtonsoft.Json.JsonReaderException)
                {
                    f76Status = $"Error: Couldn't parse server response";
                }
                catch (Exception e)
                {
                    f76Status = $"Unknown error: {e.Message}";
                }
            }
            else
            {
                if (!request.Success)
                    f76Status = $"Error: No connection";
                else
                    f76Status = $"Error: HTTP {request.StatusCode}";
            }

            return f76Status;
        }

        /// <summary>
        /// Server status => Status key for translation 
        /// </summary>
        /// <param name="serverStatus"></param>
        /// <returns></returns>
        public static String GetKeyFromStatus(String serverStatus)
        {
            String statusKey = serverStatus;
            switch (serverStatus)
            {
                case "operational":
                case "all_systems_operational":
                    statusKey = "operational";
                    break;
                case "maintenance":
                case "under_maintenance":
                case "service_under_maintenance":
                    statusKey = "maintenance";
                    break;
                case "degraded_performance":
                case "partially_degraded_service":
                    statusKey = "degraded";
                    break;
                case "partial_outage":
                case "partial_system_outage":
                case "minor_service_outage":
                    statusKey = "partial";
                    break;
                /*case "minor_service_outage":
                    statusKey = "minor";
                    break;*/
                case "major_outage":
                case "major_system_outage":
                    statusKey = "major";
                    break;
            }
            return statusKey;
        }

        /// <summary>
        /// Request the localized string of the given server status in the given language from "api.locize.app".
        /// </summary>
        /// <remarks>
        /// "statusKey": {
        ///     "degraded": "Herabgesetzte Performance",
        ///     "information": "Informationen/Keine Auswirkungen",
        ///     "maintenance": "Wartung",
        ///     "major": "Ausfall",
        ///     "operational": "Funktionsfähig",
        ///     "partial": "Teilweiser Ausfall",
        ///     "title": "Dienst-Statussymbole"
        /// }
        /// </remarks>
        /// <param name="language">ISO code, two characters long</param>
        /// <param name="statusKey">Status key for translation</param>
        /// <returns></returns>
        public static String GetLocalizedServerStatus(String language, String statusKey)
        {
            // Send request:
            APIRequest request = new APIRequest($"https://api.locize.app/657e9e0e-8225-4266-88dd-75f047f1a2b3/live/{language.ToLower()}/status");
            request.Execute();

            if (request.Success && request.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    JObject responseJSON = request.GetJObject();
                    JObject statusKeys = (JObject)responseJSON["statusKey"];

                    // If translation does not exist, the server returns an empty JSON object {}
                    // In this situation, fallback to English:
                    if (statusKeys == null)
                        return GetLocalizedServerStatus("en", statusKey);

                    if (statusKeys[statusKey] != null)
                        return statusKeys[statusKey].ToObject<string>();

                    return statusKey;
                }
                catch (Exception) // Newtonsoft.Json.JsonReaderException
                {
                    return statusKey;
                }
            }

            return statusKey;
        }
    }
}
