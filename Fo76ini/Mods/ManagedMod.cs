using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Fo76ini.Mods
{
    public class ManagedMod
    {
        /// <summary>
        /// Contains information about the current or desired deployment state.
        /// </summary>
        public class DiskState
        {
            /// <summary>
            /// How a mod should be deployed.
            /// Loose       - Copy files over without packing
            /// BundledBA2  - Bundle it with other mods in one package
            /// SeparateBA2 - Pack it as a separate *.ba2 archive
            /// </summary>
            public enum DeploymentMethod
            {
                Loose,
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

            public bool Enabled = false;
            public readonly Guid guid;
            public DeploymentMethod Method = DeploymentMethod.BundledBA2;

            /// <summary>
            /// The folder where to copy loose files to.
            /// </summary>
            public string RootFolder;

            /* Does only apply for Loose */
            public List<string> LooseFiles = new List<string>();

            /* Does only apply for SeparateBA2 */
            public ArchiveCompression Compression = ArchiveCompression.Auto;
            private string archiveName = "untitled.ba2";
            public ArchiveFormat Format = ArchiveFormat.Auto;
            public bool Frozen = false;

            /// <summary>
            /// Creates an empty object.
            /// </summary>
            public DiskState() { }

            public DiskState(Guid guid)
            {
                this.guid = guid;
                //this.ManagedFolderName = guid.ToString();
            }

            /// <summary>
            /// Creates a deep copy of 'state'.
            /// </summary>
            /// <param name="state">The object it makes a copy of.</param>
            public DiskState(DiskState state)
            {
                this.LooseFiles = new List<string>(state.LooseFiles);
                //this.ManagedFolderName = state.ManagedFolderName;
                this.Enabled = state.Enabled;
                this.Method = state.Method;
                this.RootFolder = state.RootFolder;
                this.Compression = state.Compression;
                this.Format = state.Format;
                this.archiveName = state.archiveName;
                this.Frozen = state.Frozen;
                this.guid = state.guid;
            }

            public DiskState CreateDeepCopy()
            {
                return new DiskState(this);
            }

            /// <summary>
            /// Name of the archive in @"Fallout 76\Data".
            /// (Does only apply to DeploymentMethod.SeparateBA2)
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
            /// Get the name of the deployment method.
            /// </summary>
            /// <returns></returns>
            public string GetMethodName()
            {
                return Enum.GetName(typeof(DeploymentMethod), (int)this.Method);
            }

            /// <summary>
            /// Get the name of the archive format.
            /// </summary>
            /// <returns></returns>
            public string GetFormatName()
            {
                return Enum.GetName(typeof(ArchiveFormat), (int)this.Format);
            }

            /// <summary>
            /// Get the name of the archive compression.
            /// </summary>
            /// <returns></returns>
            public string GetCompressionName()
            {
                return Enum.GetName(typeof(ArchiveCompression), (int)this.Compression);
            }

            /// <summary>
            /// Get the folder name (not path). This folder stores the mod's files.
            /// </summary>
            /// <returns>Example: @"2f2d3b3b-b21b-4ec2-b555-c8806a801b16"</returns>
            public string GetManagedFolderName()
            {
                return "{" + guid.ToString() + "}";
            }

            /// <summary>
            /// Get the path to where the mod's files are stored.
            /// </summary>
            /// <returns>Example: @"C:\Program Files (x86)\Steam\steamapps\common\Fallout 76\Mods\2f2d3b3b-b21b-4ec2-b555-c8806a801b16"</returns>
            public string GetManagedFolderPath()
            {
                return Path.Combine(Shared.GamePath, "Mods", GetManagedFolderName());
            }

            /// <summary>
            /// Get the path where frozen archives are stored.
            /// </summary>
            /// <returns>Example: @"C:\Program Files (x86)\Steam\steamapps\common\Fallout 76\FrozenData"</returns>
            public string GetFrozenDataPath()
            {
                return Path.Combine(Shared.GamePath, "FrozenData");
            }

            /// <summary>
            /// Get the name of the frozen archive.
            /// </summary>
            /// <returns>Example: @"{2f2d3b3b-b21b-4ec2-b555-c8806a801b16}.ba2"</returns>
            public string GetFrozenArchiveName()
            {
                return "{" + this.guid.ToString() + "}.ba2";
            }

            /// <summary>
            /// Get the path to where the mod's frozen archive is stored.
            /// </summary>
            /// <returns>Example: @"C:\Program Files (x86)\Steam\steamapps\common\Fallout 76\FrozenData\{2f2d3b3b-b21b-4ec2-b555-c8806a801b16}.ba2"</returns>
            public string GetFrozenArchivePath()
            {
                return Path.Combine(GetFrozenDataPath(), GetFrozenArchiveName());
            }

            /// <summary>
            /// Get the path to the deployed archive.
            /// </summary>
            /// <returns>Example: @"C:\Program Files (x86)\Steam\steamapps\common\Fallout 76\Data\Foobar.ba2"</returns>
            public string GetArchivePath()
            {
                return Path.Combine(Shared.GamePath, "Data", this.ArchiveName);
            }

            /// <summary>
            /// Clear the list 'LooseFiles'.
            /// </summary>
            public void ClearFiles()
            {
                this.LooseFiles.Clear();
            }

            /// <summary>
            /// Adds a relative file path to the list 'LooseFiles'.
            /// </summary>
            /// <param name="path">Relative file path</param>
            public void AddFile(string path)
            {
                this.LooseFiles.Add(path);
            }

            public XElement Serialize(XElement parent)
            {
                parent.Add(
                    new XAttribute("enabled", this.Enabled),
                    new XElement("DeploymentMethod", this.GetMethodName())/*,
                    new XElement("ManagedFolder", this.ManagedFolderName)*/
                );

                if (this.Method == DeploymentMethod.Loose)
                {
                    parent.Add(new XElement("Destination", this.RootFolder));

                    if (this.Enabled)
                    {
                        XElement files = new XElement("Files");
                        foreach (string filePath in this.LooseFiles)
                            files.Add(new XElement("File", new XAttribute("path", filePath)));
                        parent.Add(files);
                    }
                }

                if (this.Method == DeploymentMethod.SeparateBA2)
                {
                    XElement archive = new XElement("Archive");
                    archive.Add(
                        new XAttribute("frozen", this.Frozen),
                        new XElement("Format", this.GetFormatName()),
                        new XElement("Compression", this.GetCompressionName()),
                        new XElement("ArchiveName", this.ArchiveName)
                    );
                    parent.Add(archive);
                }

                return parent;
            }

            public static DiskState Deserialize(XElement xmlDiskState, Guid uuid)
            {
                DiskState diskState = new DiskState(uuid);
                //diskState.ManagedFolderName = xmlDiskState.Element("ManagedFolder").Value;

                try
                {
                    diskState.Enabled = Convert.ToBoolean(xmlDiskState.Attribute("enabled").Value);
                }
                catch (FormatException ex)
                {
                    throw new InvalidDataException($"Invalid 'enabled' value: {xmlDiskState.Attribute("enabled").Value}");
                }

                switch (xmlDiskState.Element("DeploymentMethod").Value)
                {
                    case "Loose":
                        diskState.Method = DeploymentMethod.Loose;
                        break;
                    case "BundledBA2":
                        diskState.Method = DeploymentMethod.BundledBA2;
                        break;
                    case "SeparateBA2":
                        diskState.Method = DeploymentMethod.SeparateBA2;
                        break;
                    default:
                        throw new InvalidDataException($"Invalid mod deployment method: {xmlDiskState.Element("DeploymentMethod").Value}");
                }

                if (diskState.Method == DeploymentMethod.Loose)
                {
                    diskState.RootFolder = xmlDiskState.Element("Destination").Value;

                    XElement xmlFiles = xmlDiskState.Element("Files");
                    if (diskState.Enabled && xmlFiles != null)
                        foreach (XElement xmlFile in xmlFiles.Descendants("File"))
                            if (xmlFile.Attribute("path") != null)
                                diskState.AddFile(xmlFile.Attribute("path").Value);
                }

                if (diskState.Method == DeploymentMethod.SeparateBA2)
                {
                    XElement xmlArchive = xmlDiskState.Element("Archive");

                    diskState.ArchiveName = xmlArchive.Element("ArchiveName").Value;

                    try
                    {
                        diskState.Frozen = Convert.ToBoolean(xmlArchive.Attribute("frozen").Value);
                    }
                    catch (FormatException ex)
                    {
                        throw new InvalidDataException($"Invalid 'frozen' value: {xmlArchive.Attribute("frozen").Value}");
                    }

                    switch (xmlArchive.Element("Format").Value)
                    {
                        case "General":
                            diskState.Format = ArchiveFormat.General;
                            break;
                        case "Textures":
                            diskState.Format = ArchiveFormat.Textures;
                            break;
                        case "Auto":
                        default:
                            diskState.Format = ArchiveFormat.Auto;
                            break;
                    }

                    switch (xmlArchive.Element("Compression").Value)
                    {
                        case "Compressed":
                            diskState.Compression = ArchiveCompression.Compressed;
                            break;
                        case "Uncompressed":
                            diskState.Compression = ArchiveCompression.Uncompressed;
                            break;
                        case "Auto":
                        default:
                            diskState.Compression = ArchiveCompression.Auto;
                            break;
                    }
                }

                return diskState;
            }
        }

        public readonly Guid guid;

        /// <summary>
        /// How the mod is currently deployed (e.g. under "Data")
        /// </summary>
        public DiskState CurrentDiskState;

        /// <summary>
        /// How the mod is currently frozen under "FrozenData"
        /// </summary>
        public DiskState FrozenDiskState;

        /// <summary>
        /// How the mod will be deployed on next deployment
        /// </summary>
        public DiskState PendingDiskState;

        private string title;
        public string Version = "1.0";
        private string url = "";
        public int ID = -1;

        public ManagedMod(Guid uuid)
        {
            this.guid = uuid;
            this.CurrentDiskState = new DiskState(uuid);
            this.FrozenDiskState = new DiskState(uuid);
            this.PendingDiskState = new DiskState(uuid);
        }

        public ManagedMod()
        {
            this.guid = Guid.NewGuid();
            this.CurrentDiskState = new DiskState(this.guid);
            this.FrozenDiskState = new DiskState(this.guid);
            this.PendingDiskState = new DiskState(this.guid);
        }

        /// <summary>
        /// Creates a deep copy of 'mod'.
        /// </summary>
        /// <param name="mod">The object it makes a copy of.</param>
        public ManagedMod(ManagedMod mod)
        {
            this.title = mod.title;
            this.ID = mod.ID;
            this.URL = mod.URL;
            this.Version = mod.Version;
            this.CurrentDiskState = this.CurrentDiskState.CreateDeepCopy();
            this.FrozenDiskState = this.FrozenDiskState.CreateDeepCopy();
            this.PendingDiskState = this.PendingDiskState.CreateDeepCopy();
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
                new XElement("Version", this.Version)
            );

            XElement xmlNexusMods = new XElement("NexusMods",
                new XAttribute("id", this.ID),
                new XElement("URL", this.URL)
            );
            XElement xmlCurrentDiskState = this.CurrentDiskState.Serialize(new XElement("CurrentDiskState"));
            XElement xmlFrozenDiskState = this.FrozenDiskState.Serialize(new XElement("FrozenDiskState"));
            XElement xmlPendingDiskState = this.PendingDiskState.Serialize(new XElement("PendingDiskState"));

            xmlMod.Add(
                xmlNexusMods,
                xmlCurrentDiskState,
                xmlFrozenDiskState,
                xmlPendingDiskState
            );

            return xmlMod;
        }

        public static ManagedMod Deserialize(XElement xmlMod)
        {
            ManagedMod mod = new ManagedMod(new Guid(xmlMod.Attribute("guid").Value));
            mod.Title = xmlMod.Element("Title").Value;
            mod.Version = xmlMod.Element("Version").Value;

            XElement xmlNexusMods = xmlMod.Element("NexusMods");
            mod.ID = Convert.ToInt32(xmlNexusMods.Attribute("id").Value);
            mod.URL = xmlNexusMods.Element("URL").Value;

            mod.CurrentDiskState = DiskState.Deserialize(xmlMod.Element("CurrentDiskState"), mod.guid);
            mod.FrozenDiskState = DiskState.Deserialize(xmlMod.Element("FrozenDiskState"), mod.guid);
            mod.PendingDiskState = DiskState.Deserialize(xmlMod.Element("PendingDiskState"), mod.guid);

            return mod;
        }

        /// <summary>
        /// Compares CurrentDiskState with PendingDiskState and returns true, if they're different.
        /// </summary>
        /// <returns></returns>
        public bool isDeploymentNecessary()
        {
            // TODO: isDeploymentNecessary()
            return false;
        }

        /// <summary>
        /// Get the path to where the mod's files are.
        /// </summary>
        /// <returns>Example: @"C:\Program Files (x86)\Steam\steamapps\common\Fallout 76\Mods\2f2d3b3b-b21b-4ec2-b555-c8806a801b16"</returns>
        public string GetManagedFolderPath()
        {
            return this.CurrentDiskState.GetManagedFolderPath();
        }

        /// <summary>
        /// Returns whether the mod has been enabled for deployment.
        /// </summary>
        /// <returns>PendingDiskState.Enabled</returns>
        public bool isEnabled()
        {
            return this.PendingDiskState.Enabled;
        }
    }
}
