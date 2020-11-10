using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fo76ini.Profiles
{
    /// <summary>
    /// Represents a profile in the Document\My Games\Profiles folder.
    /// </summary>
    public class Profile
    {
        public readonly Guid guid;
        public string Name;

        public Profile ()
        {
            Name = "Default";
            guid = Guid.NewGuid();
        }

        private Profile(string name, Guid guid)
        {
            Name = name;
            this.guid = guid;
        }

        public string FolderPath
        {
            get { return Path.Combine(IniFiles.ParentPath, "Profiles", FolderName); }
        }

        public string FolderName
        {
            get { return "{" + guid.ToString() + "}";  }
        }

        /// <summary>
        /// Delete the folder of the profile.
        /// </summary>
        public void DeleteFolder()
        {
            if (Directory.Exists(FolderPath))
                Directory.Delete(FolderPath, true);
        }

        /// <summary>
        /// Copy *.ini files from My Games\Fallout 76 to the profile folder.
        /// </summary>
        public void CopyINI()
        {
            // TODO
            CreateINI("Fallout76");
            return;
            DeleteFolder();
            Directory.CreateDirectory(FolderPath);
            foreach (string fileName in Directory.EnumerateFiles(IniFiles.ParentPath, "*.ini", SearchOption.TopDirectoryOnly))
                File.Copy(
                    Path.Combine(IniFiles.ParentPath, fileName),
                    Path.Combine(FolderPath, fileName),
                    true
                );
        }

        /// <summary>
        /// Copy default *.ini files to the profile folder.
        /// </summary>
        /// <param name="iniPrefix">Prefix for *.ini files. "Fallout76" prefix will create "Fallout76.ini" and "Fallout76Prefs.ini".</param>
        public void CreateINI(String iniPrefix)
        {
            DeleteFolder();
            Directory.CreateDirectory(FolderPath);
            File.Copy(
                Path.Combine(Shared.AppInstallationFolder, "DefaultINI", "Fallout76.ini"),
                Path.Combine(FolderPath, $"{iniPrefix}.ini")
            );
            File.Copy(
                Path.Combine(Shared.AppInstallationFolder, "DefaultINI", "Medium.ini"),
                Path.Combine(FolderPath, $"{iniPrefix}Prefs.ini")
            );
        }

        /// <summary>
        /// Restores *.ini files from the profile folder into My Games\Fallout 76.
        /// </summary>
        public void RestoreINI()
        {
            foreach (string fileName in Directory.EnumerateFiles(FolderPath, "*.ini", SearchOption.TopDirectoryOnly))
                File.Copy(
                    Path.Combine(FolderPath, fileName),
                    Path.Combine(IniFiles.ParentPath, fileName),
                    true
                );
        }

        public XElement Serialize()
        {
            XElement xmlProfile = new XElement("Profile");
            xmlProfile.Add(new XAttribute("guid", guid));
            xmlProfile.Add(new XElement("Name", Name));
            return xmlProfile;
        }

        public static Profile Deserialize(XElement xmlProfile)
        {
            return new Profile(
                xmlProfile.Element("Name").Value,
                new Guid(xmlProfile.Attribute("guid").Value)
            );
        }
    }
}
