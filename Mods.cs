using SharpCompress.Common;
using SharpCompress.Readers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Fo76ini
{
    class Mod
    {
        public enum FileType
        {
            Loose,
            BA2Archive
        }

        private String title;
        private String managedFolderName;
        private Mod.FileType type;
        private String root;
        private bool enabled;
        private List<String> looseFiles = new List<String>();

        public Mod()
        {
            this.title = "Unnamed";
            this.managedFolderName = "Unnamed";
            this.enabled = false;
            this.type = Mod.FileType.BA2Archive;
        }

        // Deep copy:
        public Mod(Mod mod)
        {
            this.title = mod.title;
            this.managedFolderName = mod.managedFolderName;
            this.enabled = mod.enabled;
            this.type = mod.type;
            this.root = mod.root;
            this.looseFiles = new List<String>(mod.looseFiles);
        }

        public Mod CreateCopy()
        {
            return new Mod(this);
        }

        public Mod(String title, String managedFolderName, Mod.FileType type, bool enabled)
        {
            this.Title = title;
            this.ManagedFolder = managedFolderName;
            this.isEnabled = enabled;
            this.Type = type;
        }

        public String Title
        {
            get { return this.title; }
            set { this.title = value.Trim().Length > 0 ? value.Trim() : "Unnamed"; }
        }

        public Mod.FileType Type
        {
            get { return this.type; }
            set { this.type = value; }
        }

        public String GetTypeName()
        {
            return Enum.GetName(typeof(Mod.FileType), (int)this.type);
        }

        public String RootFolder
        {
            get { return this.root; }
            set { this.root = value; }
        }

        public String ManagedFolder
        {
            get { return this.managedFolderName; }
            set { this.managedFolderName = value; }
        }

        public bool isEnabled
        {
            get { return this.enabled; }
            set { this.enabled = value; }
        }

        public void AddFile(String path)
        {
            if (this.type == Mod.FileType.Loose)
                this.looseFiles.Add(path);
            else
                throw new InvalidOperationException($"Can't add loose files to a \"{this.GetTypeName()}\" type mod.");
        }

        public void ClearFiles()
        {
            this.looseFiles.Clear();
        }

        public List<String> LooseFiles
        {
            get { return this.looseFiles; }
            set
            {
                if (this.type == Mod.FileType.Loose)
                    this.looseFiles = value;
                else
                    throw new InvalidOperationException($"Can't set loose files because mod is of \"{this.GetTypeName()}\" type.");
            }
        }

        public String ToString()
        {
            return $"Mod \"{Title}\":\n  Enabled: {isEnabled}\n  Installation type: {this.GetTypeName()}\n  Root folder: {RootFolder}\n  File count: {this.looseFiles.Count}";
        }

        public XElement Serialize()
        {
            // <Mod title="Some awesome mod" root="Data" modFolder="awesome" installType="BA2Archive" enabled="true" />
            XElement xmlMod = new XElement("Mod",
                new XAttribute("title", this.title),
                new XAttribute("root", this.root),
                new XAttribute("modFolder", this.managedFolderName),
                new XAttribute("installType", this.GetTypeName()),
                new XAttribute("enabled", this.enabled));

            if (this.type == Mod.FileType.Loose && this.enabled)
                foreach (String filePath in this.looseFiles)
                    xmlMod.Add(new XElement("File", new XAttribute("path", filePath)));

            return xmlMod;
        }

        public static Mod Deserialize(XElement xmlMod)
        {
            if (xmlMod.Attribute("title") == null ||
                xmlMod.Attribute("root") == null ||
                xmlMod.Attribute("modFolder") == null ||
                xmlMod.Attribute("enabled") == null ||
                xmlMod.Attribute("installType") == null)
                throw new InvalidDataException("Some attributes are missing.");
            Mod mod = new Mod();
            mod.Title = xmlMod.Attribute("title").Value;
            mod.RootFolder = xmlMod.Attribute("root").Value;
            mod.ManagedFolder = xmlMod.Attribute("modFolder").Value;
            try
            {
                mod.isEnabled = Convert.ToBoolean(xmlMod.Attribute("enabled").Value);
            }
            catch (FormatException ex)
            {
                throw new InvalidDataException($"Invalid 'enabled' value: {xmlMod.Attribute("enabled").Value}");
            }
            switch (xmlMod.Attribute("installType").Value)
            {
                case "Loose":
                    mod.Type = Mod.FileType.Loose;
                    break;
                case "BA2Archive":
                    mod.Type = Mod.FileType.BA2Archive;
                    break;
                default:
                    throw new InvalidDataException($"Invalid mod installation type: {xmlMod.Attribute("installType").Value}");
            }
            if (mod.Type == Mod.FileType.Loose && mod.isEnabled)
                foreach (XElement xmlFile in xmlMod.Descendants("File"))
                    if (xmlFile.Attribute("path") != null)
                        mod.AddFile(xmlFile.Attribute("path").Value);
                    else
                        throw new InvalidDataException("path attribute is missing from <File> tag");
            return mod;
        }
    }

    class ManagedMods
    {
        private List<Mod> mods = new List<Mod>();
        private List<Mod> changedMods = new List<Mod>();
        private String gamePath = null;
        public bool nuclearWinterMode = false;

        private List<Mod> CreateDeepCopy(List<Mod> original)
        {
            List<Mod> copy = new List<Mod>();
            foreach (Mod mod in original)
                copy.Add(mod.CreateCopy());
            return copy;
        }

        public List<Mod> Mods
        {
            get { return this.changedMods; }
        }

        /// <summary>
        /// Delete all files of the mod and remove it from the list.
        /// Saves the manifest afterwards.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="done"></param>
        public void DeleteMod(int index, Action done = null)
        {
            String managedFolderPath = Path.Combine(gamePath, "Mods", mods[index].ManagedFolder);
            if (Directory.Exists(managedFolderPath))
                Directory.Delete(managedFolderPath, true);
            this.changedMods.RemoveAt(index);
            //this.mods.RemoveAt(index);
            this.Save();
            if (done != null)
                done();
        }

        private void ManipulateModFolder(String managedFolderPath, Action<String, int> updateProgress = null)
        {
            foreach (String path in Directory.GetFiles(managedFolderPath))
            {
                // If a *.ba2 archive was found, extract it:
                if (path.EndsWith(".ba2"))
                {
                    if (ExtractBA2Archive(path, managedFolderPath, updateProgress))
                        File.Delete(path);
                }

                // Remove crap:
                if (path.EndsWith(".txt"))
                    File.Delete(path);
            }

            // String[] typicalFolders = new string[] { "meshes", "strings", "music", "sound", "textures", "materials", "interface", "geoexporter", "programs", "vis", "scripts", "misc", "shadersfx" };
            foreach (String path in Directory.GetDirectories(managedFolderPath))
            {
                String name = Path.GetFileName(path);

                // If only a data folder is in the mod folder... 
                if (name.ToLower() == "data" && Directory.GetFiles(managedFolderPath).Length == 0)
                {
                    // ... move all files in data on up:
                    Directory.Move(path, managedFolderPath);
                    // Delete the empty data folder afterwards:
                    // Directory.Delete(path);
                }
            }
        }

        private bool ExtractBA2Archive(String archivePath, String destinationPath, Action<String, int> updateProgress = null)
        {
            String filePath = Path.GetFullPath(archivePath);
            String fileName = Path.GetFileNameWithoutExtension(filePath);
            String fileExtension = Path.GetExtension(filePath);

            if (fileExtension.ToLower() == ".ba2")
            {
                // For *.ba2 archives, Archive2 has to be installed:
                if (!Archive2.ValidatePath())
                {
                    //MessageBox.Show("Please install Archive2 to decompress *.ba2 archives.", "Archive2 needed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MsgBox.ShowID("modsArchive2NotSet", MessageBoxIcon.Error);
                    return false;
                }

                if (updateProgress != null)
                    updateProgress($"Extracting {fileName}.ba2 ...", -1);
                Archive2.Extract(filePath, destinationPath);

                return true;
            }
            else
                return false;
        }

        private bool ExtractModArchive(String archivePath, String managedFolderPath, Action<String, int> updateProgress = null)
        {
            String filePath = Path.GetFullPath(archivePath);
            String fileName = Path.GetFileNameWithoutExtension(filePath);
            String fileExtension = Path.GetExtension(filePath);

            if (fileExtension.ToLower() == ".ba2")
            {
                return ExtractBA2Archive(filePath, managedFolderPath);
            }
            else if ((new String[] { ".zip", ".rar", ".tar", ".tar.gz", ".gz", ".xz", ".lz", ".bz2" }).Contains(fileExtension.ToLower()))
            {
                try
                {
                    using (Stream stream = File.OpenRead(filePath))
                    using (var reader = ReaderFactory.Open(stream))
                    {
                        while (reader.MoveToNextEntry())
                        {
                            if (!reader.Entry.IsDirectory)
                            {
                                if (updateProgress != null)
                                    updateProgress(reader.Entry.Key, -1);
                                reader.WriteEntryToDirectory(managedFolderPath, new ExtractionOptions()
                                {
                                    ExtractFullPath = true,
                                    Overwrite = true
                                });
                            }
                        }
                    }

                    return true;
                }
                catch (InvalidOperationException exc)
                {
                    MsgBox.Get("modsExtractUnknownError").FormatText(exc.Message).Show(MessageBoxIcon.Error);
                    return false;
                }
            }
            else if ((new String[] { ".7z" }).Contains(fileExtension.ToLower()))
            {
                try
                {
                    Utils.ExtractArchive(filePath, managedFolderPath);

                    if (Directory.Exists(managedFolderPath))
                    {
                        return true;
                    }
                    else
                    {
                        MsgBox.ShowID("modsExtractUnknownErrorText", MessageBoxIcon.Error);
                        //MessageBox.Show($"Please uncompress the archive and add the mod as a folder.", "Archive couldn't be uncompressed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (Exception exc)
                {
                    MsgBox.Get("modsExtractUnknownError7zip").FormatText(exc.Message).Show(MessageBoxIcon.Error);
                    return false;
                }
            }
            else
            {
                //MessageBox.Show($"*{fileExtension} files are not supported.\nPlease uncompress the archive and add the mod as a folder.", "Unsupported file format", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MsgBox.Get("modsArchiveTypeNotSupported").FormatText(fileExtension).Show(MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Extracts the archive and adds the mod.
        /// Saves the manifest afterwards.
        /// </summary>
        /// <param name="filePath">Path to archive</param>
        /// <param name="updateProgress">Callback: Progress has been made.</param>
        /// <param name="done">Callback: It's done.</param>
        public void InstallModArchive(String filePath, Action<String, int> updateProgress = null, Action done = null)
        {
            // Some conditions have to be met:
            if (this.gamePath == null)
            {
                if (done != null)
                    done();
                return;
            }

            if (!Directory.Exists(Path.Combine(this.gamePath, "Mods")))
                Directory.CreateDirectory(Path.Combine(this.gamePath, "Mods"));

            if (!File.Exists(filePath))
                throw new FileNotFoundException(filePath);


            if (!Archive2.ValidatePath())
            {
                MsgBox.ShowID("modsArchive2NotSet", MessageBoxIcon.Error);
                if (done != null)
                    done();
                return;
            }

            // Get paths:
            filePath = Path.GetFullPath(filePath);
            String fileName = Path.GetFileNameWithoutExtension(filePath);
            String fileExtension = Path.GetExtension(filePath);
            String managedFolder = fileName;
            String managedFolderPath = Path.Combine(this.GamePath, "Mods", managedFolder);
            if (Directory.Exists(managedFolderPath))
            {
                managedFolder += DateTime.Now.ToString("(yyyy-MM-dd_HH-mm-ss)");
                managedFolderPath = Path.Combine(this.GamePath, "Mods", managedFolder);
            }

            // Create a new mod:
            Mod mod = new Mod();
            mod.Title = fileName;
            mod.ManagedFolder = managedFolder;
            mod.RootFolder = "Data";
            mod.Type = Mod.FileType.BA2Archive;
            mod.isEnabled = false;

            // Extract the archive:
            if (ExtractModArchive(filePath, managedFolderPath, updateProgress))
            {
                ManipulateModFolder(managedFolderPath, updateProgress);
                this.AddInstalledMod(mod);
                this.Save();
            }
            
            if (done != null)
                done();
        }

        /// <summary>
        /// Copies the folder's contents and adds the mod.
        /// Saves the manifest afterwards.
        /// </summary>
        /// <param name="folderPath">Path to directory</param>
        /// <param name="updateProgress">Callback: "Copying file xyz" and percentage.</param>
        /// <param name="done">Callback: It's done.</param>
        public void InstallModFolder(String folderPath, Action<String, int> updateProgress = null, Action done = null)
        {
            // Some conditions have to be met:
            if (this.gamePath == null)
            {
                if (done != null)
                    done();
                return;
            }

            if (!Directory.Exists(Path.Combine(this.gamePath, "Mods")))
                Directory.CreateDirectory(Path.Combine(this.gamePath, "Mods"));

            if (!Directory.Exists(folderPath))
                throw new FileNotFoundException(folderPath);


            if (!Archive2.ValidatePath())
            {
                MsgBox.ShowID("modsArchive2NotSet", MessageBoxIcon.Error);
                if (done != null)
                    done();
                return;
            }

            // Get paths:
            folderPath = Path.GetFullPath(folderPath);
            String folderName = Path.GetFileName(folderPath);
            String managedFolder = folderName;
            String managedFolderPath = Path.Combine(this.GamePath, "Mods", managedFolder);
            if (Directory.Exists(managedFolderPath))
            {
                managedFolder += DateTime.Now.ToString("(yyyy-MM-dd_HH-mm-ss)");
                managedFolderPath = Path.Combine(this.GamePath, "Mods", managedFolder);
            }

            // Create a new mod:
            Mod mod = new Mod();
            mod.Title = folderName;
            mod.ManagedFolder = managedFolder;
            mod.RootFolder = "Data";
            mod.Type = Mod.FileType.BA2Archive;
            mod.isEnabled = false;

            // Copy every file found in the folder:
            if (updateProgress != null)
                updateProgress($"Indexing {folderName}...", -1);
            String[] files = Directory.GetFiles(folderPath, "*.*", SearchOption.AllDirectories);
            float count = (float)files.Length;
            for (int i = 0; i < files.Length; i++)
            {
                if (updateProgress != null)
                    updateProgress($"Copying {Path.GetFileName(files[i])} ...", Convert.ToInt32((float)i / (float)count * 100));

                // Make a relative path, create directories and copy file:
                String destinationPath = Path.Combine(managedFolderPath, Utils.MakeRelativePath(folderPath, files[i]));
                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                File.Copy(files[i], destinationPath);
            }

            ManipulateModFolder(managedFolderPath, updateProgress);

            // Add to mods:
            AddInstalledMod(mod);
            this.Save();

            if (done != null)
                done();
        }

        private void AddInstalledMod(Mod mod)
        {
            mods.Add(mod.CreateCopy());
            AddMod(mod);
        }

        public void AddMod(Mod mod)
        {
            changedMods.Add(mod);
        }

        public void EnableMod(int index)
        {
            if (changedMods[index].isEnabled)
                return;
            changedMods[index].isEnabled = true;
        }

        public void DisableMod(int index)
        {
            if (!changedMods[index].isEnabled)
                return;
            changedMods[index].isEnabled = false;
        }

        public void ToggleMod(int index, bool enabled)
        {
            if (changedMods[index].isEnabled == enabled)
                return;
            changedMods[index].isEnabled = enabled;
        }

        public bool isModEnabled(int index)
        {
            return changedMods[index].isEnabled;
        }

        private int MoveMod(int oldIndex, int newIndex)
        {
            // https://stackoverflow.com/questions/450233/generic-list-moving-an-item-within-the-list
            Mod mod = this.changedMods[oldIndex];

            this.changedMods.RemoveAt(oldIndex);

            // the actual index could have shifted due to the removal
            // if (newIndex > oldIndex) newIndex--;

            this.changedMods.Insert(newIndex, mod);

            return newIndex;
        }


        public int MoveModUp(int index)
        {
            if (index > 0)
                return MoveMod(index, index - 1);
            return index;
        }

        public int MoveModDown(int index)
        {
            if (index < this.changedMods.Count - 1)
                return MoveMod(index, index + 1);
            return index;
        }

        /// <summary>
        /// Compares this.mods and this.changedMods.
        /// Since this.mods represents the state on disk and this.changedMods represents changed that are due,
        /// if both aren't equal then deployment is necessary.
        /// </summary>
        /// <returns></returns>
        public bool isDeploymentNecessary()
        {
            if (this.changedMods.Count() != this.mods.Count())
                return true;
            for (int i = 0; i < this.changedMods.Count(); i++)
            {
                Console.WriteLine($"{this.changedMods[i].Title}: {this.changedMods[i].isEnabled} != {this.mods[i].isEnabled}");
                if (this.changedMods[i].isEnabled != this.mods[i].isEnabled ||
                    this.changedMods[i].LooseFiles.Count() != this.mods[i].LooseFiles.Count() ||
                    this.changedMods[i].RootFolder != this.mods[i].RootFolder ||
                    this.changedMods[i].Type != this.mods[i].Type ||
                    this.changedMods[i].ManagedFolder != this.mods[i].ManagedFolder)
                    return true;
            }
            return false;
        }

        public String GamePath
        {
            get { return this.gamePath; }
            set
            {
                if (value != null && Directory.Exists(value))
                    this.gamePath = Path.GetFullPath(value);
            }
        }

        public String GetModPath(int index)
        {
            return Path.Combine(this.gamePath, "Mods", this.changedMods[index].ManagedFolder);
        }

        public String GetInstalledModPath(int index)
        {
            return Path.Combine(this.gamePath, "Mods", this.mods[index].ManagedFolder);
        }

        public String[] GetConflictingFiles()
        {
            List<String> filesFound = new List<String>();
            List<String> conflictingFiles = new List<String>();
            foreach (Mod mod in this.changedMods)
            {
                if (!mod.isEnabled)
                    continue;

                String managedFolderPath = Path.Combine(this.gamePath, "Mods", mod.ManagedFolder);
                String[] files = Directory.GetFiles(managedFolderPath, "*.*", SearchOption.AllDirectories);
                foreach (String filePath in files)
                {
                    String relPath = Utils.MakeRelativePath(managedFolderPath, filePath);
                    if (filesFound.Contains(relPath))
                        conflictingFiles.Add(relPath);
                    else
                        filesFound.Add(relPath);
                }
            }
            return conflictingFiles.ToArray();
        }

        public XDocument Serialize()
        {
            /*
             Fallout76\Mods\manifest.xml
             <Mods>
                <Mod ... />
                <Mod ... />
                <Mod ... />
             </Mods>
             */
            XDocument xmlDoc = new XDocument();
            XElement xmlRoot = new XElement("Mods");
            xmlDoc.Add(xmlRoot);
            foreach (Mod mod in mods)
            {
                xmlRoot.Add(mod.Serialize());
            }
            return xmlDoc;
        }

        public void Load()
        {
            this.mods.Clear();
            this.changedMods.Clear();

            if (this.gamePath == null)
                return;

            String manifestPath = Path.Combine(this.gamePath, "Mods", "manifest.xml");

            if (!File.Exists(manifestPath))
                return;

            XDocument xmlDoc = XDocument.Load(manifestPath);
            foreach (XElement xmlMod in xmlDoc.Descendants("Mod"))
            {
                try
                {
                    Mod mod = Mod.Deserialize(xmlMod);
                    if (!Directory.Exists(Path.Combine(this.gamePath, "Mods", mod.ManagedFolder)))
                        continue;
                    this.AddInstalledMod(mod);
                }
                catch (InvalidDataException ex)
                {
                    MsgBox.Get("modsInvalidManifestEntry").FormatText(ex.Message).Show(MessageBoxIcon.Warning);
                }
            }
        }

        public void Save()
        {
            if (this.gamePath == null)
            {
                MsgBox.ShowID("modsGamePathNotSet", MessageBoxIcon.Error);
                return;
            }

            if (!Directory.Exists(Path.Combine(this.gamePath, "Mods")))
                Directory.CreateDirectory(Path.Combine(this.gamePath, "Mods"));

            this.Serialize().Save(Path.Combine(this.gamePath, "Mods", "manifest.xml"));
        }

        public void Deploy(Action<String, int> updateProgress = null, Action done = null)
        {
            if (!Archive2.ValidatePath())
            {
                MsgBox.ShowID("modsArchive2NotSet", MessageBoxIcon.Error);
                if (done != null)
                    done();
                return;
            }

            if (this.gamePath == null)
            {
                if (done != null)
                    done();
                return;
            }

            if (!Directory.Exists(Path.Combine(this.gamePath, "Data")))
            {
                MsgBox.ShowID("modsGamePathInvalid", MessageBoxIcon.Error);
                if (done != null)
                    done();
                return;
            }

            String modDataPath = Path.Combine(this.gamePath, "ModData");
            if (Directory.Exists(modDataPath))
                Directory.Delete(modDataPath, true);
            Directory.CreateDirectory(modDataPath);

            // sResourceIndexFileList, sResourceArchive2List, sResourceDataDirsFinal
            List<String> sResourceIndexFileList = new List<String>(IniFiles.Instance.GetString(IniFile.F76Custom, "Archive", "sResourceIndexFileList", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            sResourceIndexFileList.AddRange(IniFiles.Instance.GetString(IniFile.Config, "Archive", "sResourceIndexFileList", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            List<String> sResourceDataDirsFinal = new List<String>(IniFiles.Instance.GetString(IniFile.F76Custom, "Archive", "sResourceDataDirsFinal", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));

            /*
             * Remove any leftover files from previous installations:
             */
            int i = 0;
            foreach (Mod mod in this.mods)
            {
                if (updateProgress != null)
                    updateProgress($"Removing loose files of mod {mod.Title} ({i} of {this.mods.Count})", Convert.ToInt32((float)i / (float)this.mods.Count * 20));

                if (!mod.isEnabled || mod.Type != Mod.FileType.Loose)
                    continue;

                foreach (String relFilePath in mod.LooseFiles)
                {
                    String installedFilePath = Path.Combine(this.gamePath, mod.RootFolder, relFilePath);

                    // Delete file, if existing:
                    if (File.Exists(installedFilePath))
                        File.Delete(installedFilePath);

                    // Use backups, if there are any:
                    if (File.Exists(installedFilePath + ".old"))
                        File.Move(installedFilePath + ".old", installedFilePath);
                    else
                    {
                        // Remove empty folders one by one, if existing:
                        String parent = Path.GetDirectoryName(installedFilePath);
                        while (Directory.Exists(parent) && Utils.IsDirectoryEmpty(parent))
                        {
                            Directory.Delete(parent);
                            parent = Path.GetDirectoryName(parent);
                        }
                    }
                }

                i++;
            }


            /*
             * Copy all mods to ModData
             */
            i = 0;
            int enabledBA2Mods = 0;
            int enabledLooseMods = 0;
            List<String> allModRelPaths = new List<String>();
            foreach (Mod mod in this.changedMods)
            {
                if (this.nuclearWinterMode)
                    break;

                if (updateProgress != null)
                    updateProgress($"Copying mod {mod.Title} ({i} of {this.changedMods.Count})", Convert.ToInt32((float)i / (float)this.changedMods.Count * 80 + 20));

                if (!mod.isEnabled)
                    continue;

                String managedFolderPath = Path.Combine(this.gamePath, "Mods", mod.ManagedFolder);
                if (!Directory.Exists(managedFolderPath))
                {
                    //MessageBox.Show($"Directory \"{managedFolderPath}\" does not exist.\nPlease restart the mod manager and add the mod again.", $"Mod {mod.Title} couldn't be deployed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MsgBox.Get("modsDeployErrorModDirNotFound")
                        .FormatTitle(mod.Title)
                        .FormatText(managedFolderPath)
                        .Show(MessageBoxIcon.Error);
                    continue;
                }

                if (mod.Type == Mod.FileType.BA2Archive)
                {
                    // Bundled *.ba2 archive
                    if (!mod.RootFolder.Contains("Data"))
                    {
                        MsgBox.Get("modsDeployErrorBA2RootIsNotData")
                            .FormatTitle(mod.Title)
                            .Show(MessageBoxIcon.Error);
                        //MessageBox.Show("The root folder has to be set to \".\\Data\" for mods, that are to be installed as a bundled *.ba2 archive.", $"Mod {mod.Title} couldn't be deployed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        continue;
                    }
                    String[] files = Directory.GetFiles(managedFolderPath, "*.*", SearchOption.AllDirectories);
                    foreach (String filePath in files)
                    {
                        // Make a relative path, create directories and copy file:
                        String destinationPath = Path.Combine(modDataPath, Utils.MakeRelativePath(managedFolderPath, filePath));
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                        File.Copy(filePath, destinationPath, true);
                    }
                    enabledBA2Mods++;
                }
                else if (mod.Type == Mod.FileType.Loose)
                {
                    // Loose files
                    List<String> modRelPaths = new List<String>();
                    String[] files = Directory.GetFiles(managedFolderPath, "*.*", SearchOption.AllDirectories);
                    foreach (String filePath in files)
                    {
                        String relPath = Utils.MakeRelativePath(managedFolderPath, filePath);
                        modRelPaths.Add(relPath);
                        String destinationPath = Path.Combine(this.gamePath, mod.RootFolder, relPath);
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                        if (!allModRelPaths.Contains(relPath) && File.Exists(destinationPath))
                            File.Move(destinationPath, destinationPath + ".old");
                        File.Copy(filePath, destinationPath, true);
                    }
                    mod.LooseFiles = modRelPaths;
                    allModRelPaths.AddRange(modRelPaths);
                    enabledLooseMods++;
                }

                i++;
            }

            /*
             * Create bundled *.ba2 archive
             */
            String bundledArchiveName = "bundled.ba2";
            String bundledArchivePath = Path.Combine(this.gamePath, "Data", bundledArchiveName);
            if (!this.nuclearWinterMode && enabledBA2Mods > 0)
            {
                if (updateProgress != null)
                    updateProgress("Creating bundled *.ba2 archive...", -1);
                Archive2.Create(bundledArchivePath, modDataPath);
            }
            else
            {
                if (File.Exists(bundledArchivePath))
                    File.Delete(bundledArchivePath);
            }

            /*
             * Finishing up...
             */
            if (updateProgress != null)
                updateProgress("Finishing up...", -1);
            
            // sResourceIndexFileList
            if (!this.nuclearWinterMode && enabledBA2Mods > 0)
                sResourceIndexFileList.Add(bundledArchiveName);
            else
            {
                sResourceIndexFileList = sResourceIndexFileList.Distinct().ToList();
                sResourceIndexFileList.Remove(bundledArchiveName);
            }

            if (this.nuclearWinterMode)
            {
                if (sResourceIndexFileList.Count() > 0)
                    IniFiles.Instance.Set(IniFile.Config, "Archive", "sResourceIndexFileList", String.Join(",", sResourceIndexFileList));
                else
                    IniFiles.Instance.Remove(IniFile.Config, "Archive", "sResourceIndexFileList");
                IniFiles.Instance.Remove(IniFile.F76Custom, "Archive", "sResourceIndexFileList");
            }
            else
            {
                if (sResourceIndexFileList.Count() > 0)
                    IniFiles.Instance.Set(IniFile.F76Custom, "Archive", "sResourceIndexFileList", String.Join(",", sResourceIndexFileList.Distinct().ToArray()));
                else
                    IniFiles.Instance.Remove(IniFile.F76Custom, "Archive", "sResourceIndexFileList");
                IniFiles.Instance.Remove(IniFile.Config, "Archive", "sResourceIndexFileList");
            }

            // sResourceDataDirsFinal
            sResourceDataDirsFinal.Clear();
            String[] resourceFolders = new string[] { "meshes", "strings", "music", "sound", "textures", "materials", "interface", "geoexporter", "programs", "vis", "scripts", "misc", "shadersfx", "lodsettings" };
            foreach (String folder in Directory.GetDirectories(Path.Combine(this.gamePath, "Data")))
            {
                String folderName = Path.GetFileName(folder);
                if (resourceFolders.Contains(folderName.ToLower()))
                    sResourceDataDirsFinal.Add(folderName.ToUpper() + "\\");
            }
            if (sResourceDataDirsFinal.Count() > 0)
            {
                IniFiles.Instance.Set(IniFile.F76Custom, "Archive", "sResourceDataDirsFinal", String.Join(",", sResourceDataDirsFinal.Distinct().ToArray()));
                IniFiles.Instance.Set(IniFile.F76Custom, "Archive", "bInvalidateOlderFiles", true);
            }
            else
            {
                IniFiles.Instance.Remove(IniFile.F76Custom, "Archive", "sResourceDataDirsFinal");
                IniFiles.Instance.Remove(IniFile.F76Custom, "Archive", "bInvalidateOlderFiles");
            }

            IniFiles.Instance.SaveAll();
            this.mods = CreateDeepCopy(this.changedMods);
            this.Save();
            Directory.Delete(modDataPath, true);
            if (done != null)
                done();
        }
    }

    class Archive2
    {
        public enum Compression
        {
            None,
            Default,
            XBox
        }

        private static String archive2Path = null;

        public static String Archive2Path
        {
            get { return Archive2.archive2Path; }
            set
            {
                if (value == null)
                    return;
                else if (Directory.Exists(value))
                {
                    if (File.Exists(Path.Combine(value, "Archive2.exe")))
                        Archive2.archive2Path = Path.GetFullPath(Path.Combine(value, "Archive2.exe"));
                    else
                        return;
                }
                else if (File.Exists(value) && value.Trim().EndsWith(".exe"))
                    Archive2.archive2Path = Path.GetFullPath(value);
                else
                    return;
            }
        }

        private static void Call(String arguments)
        {
            if (Archive2.archive2Path == null)
                return;

            using (Process proc = new Process())
            {
                proc.StartInfo.UseShellExecute = true; // false
                //proc.StartInfo.RedirectStandardOutput = true;
                proc.StartInfo.FileName = Archive2.archive2Path;
                proc.StartInfo.Arguments = arguments;
                //proc.StartInfo.CreateNoWindow = true;
                proc.Start();

                // TODO: Remove this. :P
                //MessageBox.Show(proc.StandardOutput.ReadToEnd(), $"Archive2.exe {arguments}");
                proc.WaitForExit();
            }
        }

        public static void Extract(String ba2Archive, String outputFolder)
        {
            Archive2.Call($"\"{ba2Archive}\" -extract=\"{outputFolder}\"");
        }

        public static void Create(String ba2Archive, String folder)
        {
            Archive2.Create(ba2Archive, folder, Archive2.Compression.Default);
        }

        public static void Create(String ba2Archive, String folder, Archive2.Compression compression)
        {
            if (!Directory.Exists(folder))
                return;

            String compressionStr = Enum.GetName(typeof(Archive2.Compression), (int)compression);
            folder = Path.GetFullPath(folder);
            Archive2.Call($"\"{folder}\" -create=\"{ba2Archive}\" -compression={compressionStr} -root=\"{folder}\"");
        }

        public static bool ValidatePath(String path)
        {
            return path != null && File.Exists(path) && path.EndsWith(".exe");
        }

        public static bool ValidatePath()
        {
            return ValidatePath(Archive2.Archive2Path);
        }
    }
}
