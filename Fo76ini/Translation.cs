using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fo76ini
{
    public class Translation
    {
        /*
         * WORK IN PROGRESS
         */

        public static Dictionary<String, String> localizedStrings = new Dictionary<String, String>();

        static Translation()
        {
            localizedStrings["newVersionAvailable"] = "There is a newer version available: {0}";
            localizedStrings["modsDeploymentNecessary"] = "Deployment necessary";
            localizedStrings["modsAllDone"] = "All set";
            localizedStrings["modsTableFormatGeneral"] = "General";
            localizedStrings["modsTableFormatTextures"] = "Textures";
            localizedStrings["modsTableFormatAutoDetect"] = "Auto";
            localizedStrings["modsTableTypeBundled"] = "Bundled";
            localizedStrings["modsTableTypeSeparate"] = "Separate";
            localizedStrings["modsTableTypeLoose"] = "Loose";
            localizedStrings["notApplicable"] = "N/A";
        }
    }
}
