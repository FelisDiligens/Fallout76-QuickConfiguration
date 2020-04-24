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
            localizedStrings["modsDeploymentNecessary"] = "Deployment necessary";
            localizedStrings["modsAllDone"] = "All set";
        }
    }
}
