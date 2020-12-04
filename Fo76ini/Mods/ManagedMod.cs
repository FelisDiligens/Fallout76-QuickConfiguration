using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using Fo76ini.NexusAPI;
using Fo76ini.Utilities;

namespace Fo76ini.Mods
{
    /// <summary>
    /// Represents a managed mod. Stores information about the mod and how it's installed.
    /// </summary>
    public class ManagedMod
    {
        /// <summary>
        /// How a mod should be deployed.
        /// Loose       - Copy files over without packing
        /// BundledBA2  - Bundle it with other mods in one package
        /// SeparateBA2 - Pack it as a separate *.ba2 archive
        /// </summary>
        public enum DeploymentMethod
        {
            LooseFiles,
            BundledBA2,
            SeparateBA2
        }

        /// <summary>
        /// Archive format
        /// Auto     - Automatically detect
        /// General  - Use "Archive2.Format.General"
        /// Textures - Use "Archive2.Format.DDS"
        /// 
        /// (Does only apply to DeploymentMethod.SeparateBA2)
        /// </summary>
        public enum ArchiveFormat
        {
            Auto,
            General,
            Textures
        }

        /// <summary>
        /// Archive compression
        /// Auto         - Automatically detect
        /// Compressed   - Use "Archive2.Compression.Default"
        /// Uncompressed - Use "Archive2.Compression.None"
        /// 
        /// (Does only apply to DeploymentMethod.SeparateBA2)
        /// </summary>
        public enum ArchiveCompression
        {
            Auto,
            Compressed,
            Uncompressed
        }

        /// <summary>
        /// Convert DeploymentMethod enum to string.
        /// </summary>
        private static string GetMethodName(DeploymentMethod method)
        {
            return Enum.GetName(typeof(DeploymentMethod), (int)method);
        }

        /// <summary>
        /// Convert string to DeploymentMethod enum.
        /// </summary>
        private static DeploymentMethod GetMethod(String method)
        {
            switch (method)
            {
                case "Loose":
                case "LooseFiles":
                    return DeploymentMethod.LooseFiles;
                case "BundledBA2":
                    return DeploymentMethod.BundledBA2;
                case "SeparateBA2":
                    return DeploymentMethod.SeparateBA2;
                default:
                    throw new InvalidDataException($"Invalid mod deployment method: {method}");
            }
        }

        /// <summary>
        /// Convert ArchiveFormat enum to string.
        /// </summary>
        private static string GetFormatName(ArchiveFormat format)
        {
            return Enum.GetName(typeof(ArchiveFormat), (int)format);
        }

        /// <summary>
        /// Convert string to ArchiveFormat enum.
        /// </summary>
        private static ArchiveFormat GetFormat(String format)
        {
            switch (format)
            {
                case "General":
                    return ArchiveFormat.General;
                case "Textures":
                    return ArchiveFormat.Textures;
                case "Auto":
                    return ArchiveFormat.Auto;
                default:
                    throw new InvalidDataException($"Invalid mod archive format: {format}");
            }
        }

        /// <summary>
        /// Convert ArchiveCompression enum to string.
        /// </summary>
        private static string GetCompressionName(ArchiveCompression compression)
        {
            return Enum.GetName(typeof(ArchiveCompression), (int)compression);
        }

        /// <summary>
        /// Convert string to ArchiveCompression enum.
        /// </summary>
        private static ArchiveCompression GetCompression(String compression)
        {
            switch (compression)
            {
                case "Compressed":
                    return ArchiveCompression.Compressed;
                case "Uncompressed":
                    return ArchiveCompression.Uncompressed;
                case "Auto":
                    return ArchiveCompression.Auto;
                default:
                    throw new InvalidDataException($"Invalid mod archive compression: {compression}");
            }
        }

        /// <summary>
        /// Enabled for deployment: Whether we want to have this mod deployed or not.
        /// </summary>
        public bool Enabled = false;

        /// <summary>
        /// Has it been deployed? Is it on disk?
        /// </summary>
        public bool Deployed = false;

        /// <summary>
        /// Do we have a frozen archive for deployment? (SeparateBA2)
        /// </summary>
        public bool Frozen = false;

        /// <summary>
        /// Do we want to freeze this archive? Do we want to use a frozen archive if available? (SeparateBA2)
        /// </summary>
        public bool Freeze = false;

        /// <summary>
        /// How the mod got installed. (Current disk state)
        /// </summary>
        public DeploymentMethod PreviousMethod;

        /// <summary>
        /// How the mod should get installed. (Pending disk state)
        /// </summary>
        public DeploymentMethod Method = DeploymentMethod.BundledBA2;

        /// <summary>
        /// How it should get compressed on deployment.
        /// </summary>
        public ArchiveCompression Compression = ArchiveCompression.Auto;

        /// <summary>
        /// How it should get formatted on deployment.
        /// </summary>
        public ArchiveFormat Format = ArchiveFormat.Auto;

        /// <summary>
        /// How the archive in Data is compressed.
        /// </summary>
        public ArchiveCompression CurrentCompression = ArchiveCompression.Auto;

        /// <summary>
        /// How the archive in Data is formatted.
        /// </summary>
        public ArchiveFormat CurrentFormat = ArchiveFormat.Auto;

        /// <summary>
        /// How the archive in FrozenData is compressed.
        /// </summary>
        public ArchiveCompression FrozenCompression = ArchiveCompression.Auto;

        /// <summary>
        /// How the archive in FrozenData is formatted.
        /// </summary>
        public ArchiveFormat FrozenFormat = ArchiveFormat.Auto;

        /// <summary>
        /// Relative paths of the mod files that are currently deployed.
        /// </summary>
        public List<string> LooseFiles = new List<string>();

        /// <summary>
        /// The folder where loose files are currently copied to.
        /// </summary>
        public string CurrentRootFolder = ".";

        /// <summary>
        /// The folder where to copy loose files to on deployment.
        /// </summary>
        public string RootFolder = ".";

        /// <summary>
        /// If deployed as SeparateBA2, what is the archive in Data called? (SeparateBA2)
        /// </summary>
        public string CurrentArchiveName;

        /// <summary>
        /// Get the path to the currently deployed archive.
        /// Example: @"C:\Program Files (x86)\Steam\steamapps\common\Fallout 76\Data\Foobar.ba2"
        /// </summary>
        public string CurrentArchivePath
        {
            get { return Path.Combine(GamePath, "Data", this.ArchiveName); }
        }

        private string archiveName;

        /// <summary>
        /// How is the archive going to be called after deployment? (SeparateBA2)
        /// </summary>
        public string ArchiveName
        {
            get { return this.archiveName; }
            set
            {
                if (value.Trim().Length < 0)
                    return;
                this.archiveName = Utils.GetValidFileName(value, ".ba2");
            }
        }

        /// <summary>
        /// Get the path to where the archive should get deployed.
        /// Example: @"C:\Program Files (x86)\Steam\steamapps\common\Fallout 76\Data\Foobar.ba2"
        /// </summary>
        public string ArchivePath
        {
            get { return Path.Combine(GamePath, "Data", this.ArchiveName); }
        }

        /// <summary>
        /// Get the folder name (not path). This folder stores the mod's files.
        /// Example: @"{2f2d3b3b-b21b-4ec2-b555-c8806a801b16}"
        /// </summary>
        public string ManagedFolderName
        {
            get { return "{" + guid.ToString() + "}"; }
        }

        /// <summary>
        /// Get the path to where the mod's files are stored.
        /// Example: @"C:\Program Files (x86)\Steam\steamapps\common\Fallout 76\Mods\{2f2d3b3b-b21b-4ec2-b555-c8806a801b16}"
        /// </summary>
        public string ManagedFolderPath
        {
            get { return Path.Combine(GamePath, "Mods", ManagedFolderName); }
        }

        /// <summary>
        /// Path where frozen archives are stored.
        /// Example: @"C:\Program Files (x86)\Steam\steamapps\common\Fallout 76\FrozenData"
        /// </summary>
        public string FrozenDataPath
        {
            get { return Path.Combine(GamePath, "FrozenData"); }
        }

        /// <summary>
        /// Name of the frozen archive.
        /// Example: @"{2f2d3b3b-b21b-4ec2-b555-c8806a801b16}.ba2"
        /// </summary>
        public string FrozenArchiveName
        {
            get { return "{" + this.guid.ToString() + "}.ba2"; }
        }

        /// <summary>
        /// Path to the mod's frozen archive.
        /// Example: @"C:\Program Files (x86)\Steam\steamapps\common\Fallout 76\FrozenData\{2f2d3b3b-b21b-4ec2-b555-c8806a801b16}.ba2"
        /// </summary>
        public string FrozenArchivePath
        {
            get { return Path.Combine(FrozenDataPath, FrozenArchiveName); }
        }

        public readonly Guid guid;

        private string title;
        public string Version = "1.0";
        private string url = "";
        public int ID = -1;
        public readonly string GamePath;

        public ManagedMod(string gamePath, Guid uuid)
        {
            this.GamePath = gamePath;
            this.guid = uuid;
        }

        public ManagedMod(string gamePath)
        {
            this.GamePath = gamePath;
            this.guid = Guid.NewGuid();
        }

        /// <summary>
        /// Creates a deep copy of 'mod'.
        /// </summary>
        /// <param name="mod">The object it makes a copy of.</param>
        public ManagedMod(ManagedMod mod)
        {
            /*
             * Info
             */

            this.title = mod.title;
            this.ID = mod.ID;
            this.URL = mod.URL;
            this.Version = mod.Version;
            this.guid = mod.guid;
            this.GamePath = mod.GamePath;


            /*
             * General
             */
            this.Enabled = mod.Enabled;
            this.Deployed = mod.Deployed;
            this.Method = mod.Method;
            this.PreviousMethod = mod.PreviousMethod;


            /*
             * SeparateBA2
             */

            this.archiveName = mod.archiveName;
            this.CurrentArchiveName = mod.CurrentArchiveName;
            this.Compression = mod.Compression;
            this.CurrentCompression = mod.CurrentCompression;
            this.Format = mod.Format;
            this.CurrentFormat = mod.CurrentFormat;


            /*
             * SeparateBA2 Frozen
             */
            this.Freeze = mod.Freeze;
            this.Frozen = mod.Frozen;
            this.FrozenCompression = mod.FrozenCompression;
            this.FrozenFormat = mod.FrozenFormat;


            /*
             * Loose
             */
            this.LooseFiles = new List<string>(mod.LooseFiles);
            this.RootFolder = mod.RootFolder;
            this.CurrentRootFolder = mod.CurrentRootFolder;
        }

        /// <summary>
        /// URL to the NexusMods page of the mod.
        /// </summary>
        public string URL
        {
            get
            {
                return this.url;
            }
            set
            {
                this.url = value;
                this.ID = NexusMods.GetIDFromURL(value);
            }
        }

        /// <summary>
        /// Returns remote info from NexusMods if available.
        /// Returns null if not available.
        /// </summary>
        public NMMod RemoteInfo
        {
            get
            {
                if (this.ID >= 0 && NexusMods.Mods.ContainsKey(this.ID))
                    return NexusMods.Mods[this.ID];
                else
                    return null;
            }
        }

        public string Title
        {
            get { return this.title; }
            set { this.title = value.Trim().Length > 0 ? value.Trim() : "Untitled"; }
        }

        public ManagedMod CreateDeepCopy()
        {
            return new ManagedMod(this);
        }

        public XElement Serialize()
        {
            XElement xmlMod = new XElement("Mod",
                new XAttribute("guid", this.guid.ToString()),
                new XElement("Title", this.Title),
                new XElement("Version", this.Version),
                new XElement("NexusMods",
                    new XAttribute("id", this.ID),
                    new XElement("URL", this.URL)
                )
            );

            XElement xmlLooseFiles = new XElement("InstalledLooseFiles");
            if (this.PreviousMethod == DeploymentMethod.LooseFiles && this.Deployed)
                foreach (string filePath in this.LooseFiles)
                    xmlLooseFiles.Add(new XElement("File", new XAttribute("path", filePath)));

            XElement xmlDiskState = new XElement("DiskState",
                new XElement("Current",
                    new XAttribute("isDeployed", this.Deployed),
                    new XElement("InstallationMethod", GetMethodName(this.PreviousMethod)),
                    new XElement("ArchiveName", this.CurrentArchiveName),
                    new XElement("ArchiveFormat", GetFormatName(this.CurrentFormat)),
                    new XElement("ArchiveCompression", GetCompressionName(this.CurrentCompression)),
                    new XElement("RootFolder", this.CurrentRootFolder),
                    xmlLooseFiles
                ),
                new XElement("Pending",
                    new XAttribute("isEnabled", this.Enabled),
                    new XElement("InstallationMethod", GetMethodName(this.Method)),
                    new XElement("ArchiveName", this.ArchiveName),
                    new XElement("ArchiveFormat", GetFormatName(this.Format)),
                    new XElement("ArchiveCompression", GetCompressionName(this.Compression)),
                    new XElement("RootFolder", this.RootFolder)
                ),
                new XElement("FrozenData",
                    new XAttribute("isFrozen", this.Frozen),
                    new XAttribute("freeze", this.Freeze),
                    new XElement("ArchiveFormat", GetFormatName(this.FrozenFormat)),
                    new XElement("ArchiveCompression", GetCompressionName(this.FrozenCompression))
                )
            );

            xmlMod.Add(xmlDiskState);

            return xmlMod;
        }

        public static ManagedMod Deserialize(XElement xmlMod, string GamePath)
        {
            if (xmlMod.Attribute("guid") == null)
                throw new Exception("Invalid *.xml entry for mod.");

            ManagedMod mod = new ManagedMod(GamePath, new Guid(xmlMod.Attribute("guid").Value));

            if (xmlMod.Element("Title") == null)
                throw new Exception("Invalid *.xml entry for mod.");
            else
                mod.Title = xmlMod.Element("Title").Value;

            if (xmlMod.Element("Version") != null)
                mod.Version = xmlMod.Element("Version").Value;

            XElement xmlNexusMods = xmlMod.Element("NexusMods");
            int modId;
            if (xmlNexusMods != null && xmlNexusMods.Attribute("id") != null && xmlNexusMods.Element("URL") != null)
            {
                if (xmlNexusMods.Attribute("id").TryParseInt(out modId))
                    mod.ID = modId;
                mod.URL = xmlNexusMods.Element("URL").Value;
            }

            XElement xmlDiskState = xmlMod.Element("DiskState");
            if (xmlDiskState == null)
                throw new Exception("Invalid *.xml entry for mod.");

            XElement xmlCurrentDiskState = xmlDiskState.Element("Current");
            if (xmlCurrentDiskState == null)
                throw new Exception("Invalid *.xml entry for mod.");
            if (xmlCurrentDiskState.Attribute("isDeployed") != null &&
                xmlCurrentDiskState.Attribute("isDeployed").TryParseBool(out bool deployed))
                mod.Deployed = deployed;
            if (xmlCurrentDiskState.Element("InstallationMethod") != null)
                mod.PreviousMethod = GetMethod(xmlCurrentDiskState.Element("InstallationMethod").Value);
            if (xmlCurrentDiskState.Element("ArchiveFormat") != null)
                mod.CurrentFormat = GetFormat(xmlCurrentDiskState.Element("ArchiveFormat").Value);
            if (xmlCurrentDiskState.Element("ArchiveCompression") != null)
                mod.CurrentCompression = GetCompression(xmlCurrentDiskState.Element("ArchiveCompression").Value);
            if (xmlCurrentDiskState.Element("ArchiveName") != null)
                mod.CurrentArchiveName = xmlCurrentDiskState.Element("ArchiveName").Value;
            if (xmlCurrentDiskState.Element("RootFolder") != null)
                mod.CurrentRootFolder = xmlCurrentDiskState.Element("RootFolder").Value;

            XElement xmlInstalledLooseFiles = xmlCurrentDiskState.Element("InstalledLooseFiles");
            if (xmlInstalledLooseFiles != null)
                foreach (XElement xmlFile in xmlInstalledLooseFiles.Descendants("File"))
                    if (xmlFile.Attribute("path") != null)
                        mod.LooseFiles.Add(xmlFile.Attribute("path").Value);

            XElement xmlPendingDiskState = xmlDiskState.Element("Pending");
            if (xmlPendingDiskState == null)
                throw new Exception("Invalid *.xml entry for mod.");
            if (xmlPendingDiskState.Attribute("isEnabled") != null &&
                xmlPendingDiskState.Attribute("isEnabled").TryParseBool(out bool enabled))
                mod.Enabled = enabled;
            if (xmlPendingDiskState.Element("InstallationMethod") != null)
                mod.Method = GetMethod(xmlPendingDiskState.Element("InstallationMethod").Value);
            if (xmlPendingDiskState.Element("ArchiveName") != null)
                mod.ArchiveName = xmlPendingDiskState.Element("ArchiveName").Value;
            if (xmlPendingDiskState.Element("ArchiveFormat") != null)
                mod.Format = GetFormat(xmlPendingDiskState.Element("ArchiveFormat").Value);
            if (xmlPendingDiskState.Element("ArchiveCompression") != null)
                mod.Compression = GetCompression(xmlPendingDiskState.Element("ArchiveCompression").Value);
            if (xmlPendingDiskState.Element("RootFolder") != null)
                mod.RootFolder = xmlPendingDiskState.Element("RootFolder").Value;

            XElement xmlFrozenDiskState = xmlDiskState.Element("FrozenData");
            if (xmlFrozenDiskState == null)
                throw new Exception("Invalid *.xml entry for mod.");
            if (xmlFrozenDiskState.Attribute("isFrozen") != null &&
                xmlFrozenDiskState.Attribute("isFrozen").TryParseBool(out bool frozen))
                mod.Frozen = frozen;
            if (xmlFrozenDiskState.Attribute("freeze") != null &&
                xmlFrozenDiskState.Attribute("freeze").TryParseBool(out bool freeze))
                mod.Freeze = freeze;
            if (xmlFrozenDiskState.Element("ArchiveFormat") != null)
                mod.FrozenFormat = GetFormat(xmlFrozenDiskState.Element("ArchiveFormat").Value);
            if (xmlFrozenDiskState.Element("ArchiveCompression") != null)
                mod.FrozenCompression = GetCompression(xmlFrozenDiskState.Element("ArchiveCompression").Value);

            return mod;
        }

        /// <summary>
        /// Compares current disk state with pending disk state and returns true, if they're different.
        /// </summary>
        /// <returns></returns>
        public bool isDeploymentNecessary()
        {
            if (Deployed != Enabled)
                return true;

            if (!Enabled && !Deployed)
                return false;

            if (PreviousMethod != Method)
                return true;

            if (Method == DeploymentMethod.SeparateBA2)
            {
                if (CurrentArchiveName != ArchiveName)
                    return true;

                if (CurrentFormat != Format)
                    return true;

                if (CurrentCompression != Compression)
                    return true;

                if (Freeze && !Frozen)
                    return true;
            }
            else if (Method == DeploymentMethod.LooseFiles)
            {
                if (CurrentRootFolder != RootFolder)
                    return true;
            }

            return false;
        }
    }
}
