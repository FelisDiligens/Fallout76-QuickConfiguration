using Fo76ini.Utilities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.API.GitHub
{
    public class GitHubAPI
    {
        public const string APIDomain = "https://api.github.com";

        public struct RateLimit
        {
            public int limit;
            public int remaining;
            public DateTime reset;
            public bool exceeded;
        }

        public static RateLimit GetRateLimit()
        {
            RateLimit rateLimit = new RateLimit();

            APIRequest request = new APIRequest($"{APIDomain}/rate_limit");
            request.Accept = "application/vnd.github.v3+json";
            APIResponse response = request.GetResponse();

            if (response.Success)
            {
                rateLimit.limit = Convert.ToInt32(response.Headers["X-RateLimit-Limit"]);
                rateLimit.remaining = Convert.ToInt32(response.Headers["X-RateLimit-Remaining"]);
                rateLimit.reset = Utils.UnixTimeStampToDateTime(Convert.ToDouble(response.Headers["X-RateLimit-Reset"]));

                if (rateLimit.limit <= 0)
                    rateLimit.exceeded = true;

                return rateLimit;
            }
            else
            {
                throw response.Exception;
            }
        }

        public struct ReleaseInfo
        {
            public string Name;
            public string TagName;
            public bool Prerelease;
            public string Body; // you could also call this description
            public ReleaseAsset[] Assets;
        }

        public struct ReleaseAsset
        {
            public string ContentType; // e.g. "application/x-zip-compressed" or "application/x-msdownload"
            public string FileName;
            public string FileExtension;
            public string BrowserDownloadURL;
        }

        /// <summary>
        /// Returns information about the latest release of the given repository.
        /// </summary>
        /// <param name="user">User name. e.g. "FelisDiligens"</param>
        /// <param name="repo">Repository. e.g. "Fallout76-QuickConfiguration"</param>
        /// <returns>Tag name (aka. version) and assets (including download urls).</returns>
        public static ReleaseInfo GetLatestRelease(string user, string repo)
        {
            ReleaseInfo releaseInfo = new ReleaseInfo();
            List<ReleaseAsset> releaseAssets = new List<ReleaseAsset>();

            APIRequest request = new APIRequest($"{APIDomain}/repos/{user}/{repo}/releases/latest");
            request.Accept = "application/vnd.github.v3+json";
            APIResponse response = request.GetResponse();

            if (response.Success && response.StatusCode == HttpStatusCode.OK)
            {
                JObject responseJSON = response.GetJObject();
                releaseInfo.Name = responseJSON["name"].ToString();
                releaseInfo.TagName = responseJSON["tag_name"].ToString();
                releaseInfo.Prerelease = responseJSON["prerelease"].ToObject<bool>();
                releaseInfo.Body = responseJSON["body"].ToString();

                JArray joAssets = (JArray)responseJSON["assets"];
                foreach (JObject joAsset in joAssets)
                {
                    ReleaseAsset asset = new ReleaseAsset();
                    asset.FileName = (String)joAsset["name"];
                    asset.FileExtension = Path.GetExtension(asset.FileName);
                    asset.ContentType = (String)joAsset["content_type"];
                    asset.BrowserDownloadURL = (String)joAsset["browser_download_url"];
                    releaseAssets.Add(asset);
                }

                releaseInfo.Assets = releaseAssets.ToArray();

                return releaseInfo;
            }
            else
            {
                throw response.Exception;
            }
        }

        /// <summary>
        /// Fetches the last commit to the given repository under the given path from the GitHub API.  
        /// Then extract the date and return it. If something went wrong, it returns null.
        /// </summary>
        /// <param name="user">User name. e.g. "FelisDiligens"</param>
        /// <param name="repo">Repository. e.g. "Fallout76-QuickConfiguration"</param>
        /// <param name="path">Path relative to the repos root. e.g. "Fo76ini/languages"</param>
        /// <returns>Date of the last commit or null</returns>
        public static DateTime? FetchLastCommitDate(string user, string repo, string path)
        {
            APIRequest request = new APIRequest($"{APIDomain}/repos/{user}/{repo}/commits?path={path.Replace("/", "%2F").Replace("\\", "%2F")}&page=1&per_page=1");
            request.Accept = "application/vnd.github.v3+json";
            APIResponse response = request.GetResponse();

            if (response.Success && response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    JArray responseJSON = response.GetJArray();
                    JObject firstEl = (JObject)responseJSON[0];
                    JObject commit = (JObject)firstEl["commit"];
                    JObject committer = (JObject)commit["committer"];
                    return committer["date"].ToObject<DateTime>();
                }
                catch
                {
                    return null;
                }
            }

            return null;
        }
    }
}
