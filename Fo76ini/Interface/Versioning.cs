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
                WebClient wc = new WebClient();
                byte[] raw = wc.DownloadData("https://raw.githubusercontent.com/FelisDiligens/Fallout76-QuickConfiguration/master/VERSION");
                Shared.LatestVersion = Encoding.UTF8.GetString(raw).Trim();
            }
            catch (WebException exc)
            {
                return;
            }
        }

        public static bool UpdateAvailable
        {
            get { return Shared.LatestVersion != null && Utils.CompareVersions(Shared.LatestVersion, Shared.VERSION) > 0; }
        }

        /*public static bool PrereleaseUsed
        {
            get { return Shared.LatestVersion != null && Utils.CompareVersions(Shared.LatestVersion, Shared.VERSION) < 0; }
        }*/
    }
}
