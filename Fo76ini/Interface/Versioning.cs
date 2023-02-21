using Fo76ini.API.GitHub;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini.Interface
{
    public static class Versioning
    {
        public static void GetLatestVersion ()
        {
            try
            {
                GitHubAPI.ReleaseInfo info = GitHubAPI.GetLatestRelease("FelisDiligens", "Fallout76-QuickConfiguration");
                Shared.LatestVersion = info.TagName;
                Console.WriteLine(info.TagName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return;
            }
        }

        public static bool UpdateAvailable
        {
            get { return Shared.LatestVersion != null && Utils.CompareVersions(Shared.LatestVersion, Shared.VERSION) > 0; }
        }
    }
}
