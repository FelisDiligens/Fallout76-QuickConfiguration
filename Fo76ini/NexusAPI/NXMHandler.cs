using Fo76ini.Interface;
using Fo76ini.Utilities;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.NexusAPI
{
    public struct NXMLink
    {
        public int modId;
        public int fileId;
        public string key;
        public int expires;
    }

    public static class NXMHandler
    {
        public static void Register()
        {
            // https://codingvision.net/c-register-a-url-protocol

            RegistryKey key = Registry.ClassesRoot.CreateSubKey("nxm");
            key.SetValue(string.Empty, "URL:NXM Protocol");
            key.SetValue("URL Protocol", string.Empty);

            key = key.CreateSubKey(@"shell\open\command");
            key.SetValue(string.Empty, GetCommand());

            key.Close();
        }

        public static void Unregister()
        {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey("nxm");
            if (key != null)
                Registry.ClassesRoot.DeleteSubKeyTree("nxm");
        }

        public static bool IsRegistered()
        {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey("nxm");
            if (key == null)
                return false;
            
            RegistryKey subKey = key.OpenSubKey(@"shell\open\command");
            if (subKey == null)
                return false;
            if ((string)subKey.GetValue(string.Empty) == GetCommand())
                return true;

            return false;
        }

        private static string GetCommand()
        {
            return $"\"{Application.ExecutablePath}\" \"%1\"";
        }

        public static NXMLink ParseLink(string nxmLink)
        {
            // nxm://fallout76/mods/<mod_id>/files/<file_id>?key=...&expires=1621492286&user_id=41275740

            if (!nxmLink.StartsWith("nxm://"))
                throw new ArgumentException("Invalid nxm link: " + nxmLink);

            Uri uri = new Uri(nxmLink);
            var query = uri.Query.Trim('?').Split('&')
                         .ToDictionary(c => c.Split('=')[0],
                                       c => Uri.UnescapeDataString(c.Split('=')[1]));

            NXMLink parsed = new NXMLink();
            parsed.modId = Utils.ToInt(uri.Segments[2].Trim('/'));
            parsed.fileId = Utils.ToInt(uri.Segments[4].Trim('/'));
            parsed.key = query["key"];
            parsed.expires = Utils.ToInt(query["expires"]);

            return parsed;
        }

        /*public static NXMLink ParseLink(string nxmLink)
        {
            // nxm://fallout76/mods/<mod_id>/files/<file_id>?key=...&expires=1621492286&user_id=41275740
            if (!nxmLink.StartsWith("nxm://"))
                throw new ArgumentException("Invalid nxm link: " + nxmLink);

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

            NXMLink parsed = new NXMLink();
            parsed.modId = Utils.ToInt(modId);
            parsed.fileId = Utils.ToInt(fileId);
            parsed.key = key;
            parsed.expires = Utils.ToInt(expires);

            return parsed;
        }*/
    }
}
