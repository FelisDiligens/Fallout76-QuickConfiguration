using Fo76ini.Interface;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.NexusAPI
{
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
    }
}
