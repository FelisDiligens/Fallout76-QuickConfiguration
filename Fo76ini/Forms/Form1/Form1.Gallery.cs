using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini
{
    public partial class Form1
    {
        private List<string> galleryImagePaths = new List<string>();
        private ImageList galleryImageList = new ImageList();

        private static string[] ValidImageFormats = new string[] { 
            ".png",
            ".jpg",
            ".gif",
            ".jpeg"
        };

        private int galleryImageSizeMult = 4;

        private void LoadGallery()
        {
            // https://stackoverflow.com/questions/6481304/how-to-use-a-backgroundworker
            //this.backgroundWorkerLoadGallery.DoWork += backgroundWorker1_DoWork;
            //this.backgroundWorkerLoadGallery.ProgressChanged += backgroundWorker1_ProgressChanged;
            this.backgroundWorkerLoadGallery.RunWorkerCompleted += backgroundWorkerLoadGallery_RunWorkerCompleted;
            this.backgroundWorkerLoadGallery.WorkerReportsProgress = true;
            //this.backgroundWorkerLoadGallery.WorkerSupportsCancellation = true;

            this.listViewScreenshots.MouseDoubleClick += listViewScreenshots_MouseDoubleClick;
            this.listViewScreenshots.MouseUp += listViewScreenshots_MouseUp;
            //this.sliderGalleryThumbnailSize.ValueChanged += sliderGalleryThumbnailSize_ValueChanged;

            this.textBoxGalleryPaths.Text = IniFiles.Instance.GetString(IniFile.Config, "Gallery", "sCustomPathsList", "").Replace(",", "\r\n");
            this.checkBoxGallerySearchRecursively.Checked = IniFiles.Instance.GetBool(IniFile.Config, "Gallery", "bSearchDirectoriesRecursively", false);
        }

        private void UpdateScreenShotGalleryThreaded()
        {
            /*Thread thread = new Thread(UpdateScreenShotGallery);
            thread.IsBackground = true;
            thread.Start();*/

            this.backgroundWorkerLoadGallery.RunWorkerAsync();
        }

        private void backgroundWorkerLoadGallery_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateScreenShotGallery();
        }

        /*private void backgroundWorkerLoadGallery_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }*/

        private void backgroundWorkerLoadGallery_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            this.pictureBoxGalleryLoadingGIF.Visible = false;
            this.buttonRefreshGallery.Enabled = true;
        }

        private void UpdateScreenShotGallery()
        {
            this.Invoke(() => this.labelGalleryTip.Visible = false);
            this.Invoke(() => this.pictureBoxGalleryLoadingGIF.Visible = true);
            this.Invoke(() => this.buttonRefreshGallery.Enabled = false);

            this.Invoke(() => this.galleryImageList.Images.Clear());
            this.Invoke(() => this.listViewScreenshots.Items.Clear());

            this.galleryImagePaths.Clear();

            this.galleryImageList.ImageSize = new Size(16 * galleryImageSizeMult, 9 * galleryImageSizeMult); // new Size(256, 144);
            this.galleryImageList.ColorDepth = ColorDepth.Depth32Bit;

            this.Invoke(() => this.listViewScreenshots.LargeImageList = this.galleryImageList);

            /*
             * Thumbnails folder:
             */
            string thumbnailsPath = Path.Combine(Shared.AppConfigFolder, "thumbnails", "screenshots");
            if (!Directory.Exists(thumbnailsPath))
                Directory.CreateDirectory(thumbnailsPath);

            /*
             * Search the game folders for screenshots:
             * C:\...\Fallout76\*.png
             */
            string[] gamePaths = new string[] {
                IniFiles.Instance.GetString(IniFile.Config, "Preferences", "sGamePathSteam", ""),
                IniFiles.Instance.GetString(IniFile.Config, "Preferences", "sGamePathBethesdaNet", ""),
                IniFiles.Instance.GetString(IniFile.Config, "Preferences", "sGamePathBethesdaNetPTS", "")
            };
            foreach (string gamePath in gamePaths)
            {
                if (Directory.Exists(gamePath))
                {
                    IEnumerable<string> screenshots = Directory.EnumerateFiles(gamePath, "*.png", SearchOption.TopDirectoryOnly);
                    foreach (string filePath in screenshots)
                    {
                        string fileName = Path.GetFileName(filePath);
                        string thumbPath = Path.Combine(thumbnailsPath, fileName) + ".jpg";
                        Bitmap thumbnail;

                        if (!File.Exists(thumbPath))
                            thumbnail = new Bitmap(Utils.MakeThumbnail(filePath, thumbPath));
                        else
                            thumbnail = new Bitmap(thumbPath);

                        this.Invoke(() => galleryImageList.Images.Add(fileName, thumbnail));

                        var item = new ListViewItem();
                        item.Text = fileName;
                        item.ImageKey = fileName;
                        this.Invoke(() => this.listViewScreenshots.Items.Add(item));

                        this.galleryImagePaths.Add(filePath);
                    }
                }
            }

            /*
             * Search the Photos folder for... you guessed it... photos:
             * C:\Users\<your name>\Documents\My Games\Fallout 76\Photos\<UUID>\*.png
             * C:\Users\<your name>\Documents\My Games\Fallout 76\Photos\<UUID>\*-thumbnail.png
             */
            string photosFolder = Path.Combine(IniFiles.Instance.iniParentPath, "Photos");
            if (Directory.Exists(photosFolder))
            {
                IEnumerable<string> photos = Directory.EnumerateFiles(photosFolder, "*.png", SearchOption.AllDirectories);
                foreach (string filePath in photos)
                {
                    string fileName = Path.GetFileName(filePath);

                    if (fileName.EndsWith("-thumbnail.png"))
                        continue;

                    string thumbnailFilePath = fileName.Replace(".png", "-thumbnail.png");
                    if (!File.Exists(thumbnailFilePath))
                    {
                        thumbnailFilePath = Path.Combine(thumbnailsPath, fileName + ".jpg");
                        if (!File.Exists(thumbnailFilePath))
                            Utils.MakeThumbnail(filePath, thumbnailFilePath);
                        //thumbnailFilePath = filePath;
                    }

                    Bitmap thumbnail = new Bitmap(thumbnailFilePath);
                    this.Invoke(() => galleryImageList.Images.Add(fileName, thumbnail));

                    var item = new ListViewItem();
                    item.Text = fileName;
                    item.ImageKey = fileName;
                    this.Invoke(() => this.listViewScreenshots.Items.Add(item));

                    this.galleryImagePaths.Add(filePath);
                }
            }

            /*
             * Search the Steam screenshot folder for screenshots:
             * C:\Program Files (x86)\Steam\userdata\<user id>\760\remote\1151340\screenshots\*.jpg
             * C:\Program Files (x86)\Steam\userdata\<user id>\760\remote\1151340\screenshots\thumbnails\*.jpg
             */
            string steamFolder = @"C:\Program Files (x86)\Steam\userdata\";
            if (Directory.Exists(steamFolder))
            {
                steamFolder = Path.Combine(Directory.GetDirectories(steamFolder)[0], @"760\remote\1151340\screenshots");
                string steamThumbnailFolder = Path.Combine(steamFolder, "thumbnails");

                if (Directory.Exists(steamFolder))
                {
                    List<string> screenshots = Directory.GetFiles(steamFolder, "*.jpg", SearchOption.TopDirectoryOnly).ToList();
                    foreach (string filePath in screenshots)
                    {
                        string fileName = Path.GetFileName(filePath);

                        string thumbnailFilePath = Path.Combine(steamThumbnailFolder, fileName);
                        if (!File.Exists(thumbnailFilePath))
                        {
                            thumbnailFilePath = Path.Combine(thumbnailsPath, fileName + ".jpg");
                            if (!File.Exists(thumbnailFilePath))
                                Utils.MakeThumbnail(filePath, thumbnailFilePath);
                            //thumbnailFilePath = filePath;
                        }

                        Bitmap thumbnail = new Bitmap(thumbnailFilePath);
                        this.Invoke(() => galleryImageList.Images.Add(fileName, thumbnail));

                        var item = new ListViewItem();
                        item.Text = fileName;
                        item.ImageKey = fileName;
                        this.Invoke(() => this.listViewScreenshots.Items.Add(item));

                        this.galleryImagePaths.Add(filePath);
                    }
                }
            }

            /*
             * Search additional paths added by the user:
             */
            foreach (string path in GetAdditionalPathList())
            {
                Console.WriteLine(path);
                string folderName = new DirectoryInfo(path).Name;
                IEnumerable<string> pictures = Directory.EnumerateFiles(path, "*.*",
                    this.checkBoxGallerySearchRecursively.Checked ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly
                );
                foreach (string filePath in pictures)
                {
                    FileInfo info = new FileInfo(filePath);
                    string fileName = info.Name;

                    if (!ValidImageFormats.Contains(info.Extension))
                        continue;

                    string thumbnailFilePath = Path.Combine(thumbnailsPath, folderName + "-" + fileName + ".jpg");
                    if (!File.Exists(thumbnailFilePath))
                        Utils.MakeThumbnail(filePath, thumbnailFilePath);

                    Bitmap thumbnail = new Bitmap(thumbnailFilePath);
                    this.Invoke(() => galleryImageList.Images.Add(fileName, thumbnail));

                    var item = new ListViewItem();
                    item.Text = fileName;
                    item.ImageKey = fileName;
                    this.Invoke(() => this.listViewScreenshots.Items.Add(item));

                    this.galleryImagePaths.Add(filePath);
                }
            }

            this.Invoke(() => this.pictureBoxGalleryLoadingGIF.Visible = false);
            this.Invoke(() => this.buttonRefreshGallery.Enabled = true);
        }

        private List<string> GetAdditionalPathList()
        {
            List<string> paths = new List<string>();
            foreach (string path in this.textBoxGalleryPaths.Text.Replace("\r\n", "\n").Split('\n'))
            {
                if (Directory.Exists(path.Trim()))
                    paths.Add(path.Trim());
            }
            return paths;
        }

        private void listViewScreenshots_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int index = this.listViewScreenshots.SelectedIndices[0];
                Process.Start(galleryImagePaths[index]);
            }
        }

        private void buttonRefreshGallery_Click(object sender, EventArgs e)
        {
            UpdateScreenShotGalleryThreaded();
        }

        private void sliderGalleryThumbnailSize_Scroll(object sender, EventArgs e)
        {
            galleryImageSizeMult = this.sliderGalleryThumbnailSize.Value * 3 + 1;
            if (this.listViewScreenshots.LargeImageList != null)
                this.listViewScreenshots.LargeImageList.ImageSize = new Size(16 * galleryImageSizeMult, 9 * galleryImageSizeMult);
        }

        private void buttonGalleryDeleteThumbnails_Click(object sender, EventArgs e)
        {
            if (MsgBox.ShowID("galleryDeleteThumbnails", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // Remove every image from memory:
                this.galleryImageList.Images.Clear();
                this.galleryImagePaths.Clear();
                this.listViewScreenshots.Items.Clear();

                // Delete thumbnails:
                string thumbnailsPath = Path.Combine(Shared.AppConfigFolder, "thumbnails", "screenshots");
                try
                {
                    Directory.Delete(thumbnailsPath, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.GetType().Name}: {ex.Message}", "Something went wrong", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Setup UI:
                this.labelGalleryTip.Visible = true;
            }
        }

        private void textBoxGalleryPaths_TextChanged(object sender, EventArgs e)
        {
            IniFiles.Instance.Set(IniFile.Config, "Gallery", "sCustomPathsList", this.textBoxGalleryPaths.Text.Replace("\r\n", ",").Replace("\n", ","));
        }

        private void checkBoxGallerySearchRecursively_CheckedChanged(object sender, EventArgs e)
        {
            IniFiles.Instance.Set(IniFile.Config, "Gallery", "bSearchDirectoriesRecursively", this.checkBoxGallerySearchRecursively.Checked);
        }

        private void Invoke(Action func)
        {
            this.pictureBoxGalleryLoadingGIF.Invoke(func);
        }


        /*
         * Context menu
         */

        List<int> galleryContextMenuItems = new List<int>();

        private void listViewScreenshots_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && this.listViewScreenshots.SelectedItems.Count > 0)
            {
                this.galleryContextMenuItems.Clear();
                foreach (ListViewItem item in this.listViewScreenshots.SelectedItems)
                    this.galleryContextMenuItems.Add(item.Index);
                // this.listViewMods.Items[index]

                this.contextMenuStripGallery.Show();
                this.contextMenuStripGallery.Top = Cursor.Position.Y;
                this.contextMenuStripGallery.Left = Cursor.Position.X;
            }
        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // I doubt anyone wants to actually open multiple images at once
            int index = galleryContextMenuItems[0];
            Process.Start(galleryImagePaths[index]);
        }

        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open all folders, but no duplicates:
            List<string> folders = new List<string>();
            foreach (int index in galleryContextMenuItems)
            {
                string folder = Path.GetDirectoryName(galleryImagePaths[index]);
                if (!folders.Contains(folder))
                    folders.Add(folder);
            }
            foreach (string folder in folders)
                Utils.OpenExplorer(folder);
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> files = new List<string>();
            foreach (int index in galleryContextMenuItems)
                files.Add(galleryImagePaths[index]);
            ClipboardUtils.CutFiles(files);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> files = new List<string>();
            foreach (int index in galleryContextMenuItems)
                files.Add(galleryImagePaths[index]);
            ClipboardUtils.CopyFiles(files);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool ok = false;
            if (galleryContextMenuItems.Count == 1)
            {
                string fileName = Path.GetFileName(galleryImagePaths[galleryContextMenuItems[0]]);
                ok = MsgBox.Get("galleryDeleteScreenshot").FormatTitle(fileName).FormatText(fileName).Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }
            else
            {
                ok = MsgBox.Get("galleryDeleteScreenshots").FormatTitle(galleryContextMenuItems.Count.ToString()).FormatText(galleryContextMenuItems.Count.ToString()).Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }

            if (ok)
            {
                foreach (int index in galleryContextMenuItems)
                {
                    string path = galleryImagePaths[index];
                    if (File.Exists(path))
                        File.Delete(path);
                }

                UpdateScreenShotGalleryThreaded();
            }
        }
    }
}
