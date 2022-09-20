using Fo76ini.Interface;
using Fo76ini.Profiles;
using Fo76ini.Tweaks;
using Fo76ini.Tweaks.General;
using Fo76ini.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Fo76ini.Forms.FormMain
{
    public partial class UserControlGallery : UserControl
    {
        private GameInstance game;

        private List<string> galleryImagePaths = new List<string>();
        private ImageList galleryImageList = new ImageList();

        private static string[] ValidImageFormats = new string[]
        {
            ".png",
            ".jpg",
            ".gif",
            ".jpeg"
        };

        // These images can be found in the game folder of the Xbox version:
        private static string[] IgnoreImages = new string[]
        {
            "LiveLogo.png",
            "SmallLogo.png",
            "SplashScreen.png",
            "StoreLogo.png",
            "WideLogo.png"
        };

        private int galleryImageSizeMult = 4;

        public UserControlGallery()
        {
            InitializeComponent();

            if (this.DesignMode)
                return;

            // Handle translations:
            Translation.LanguageChanged += Translation_LanguageChanged;

            ProfileManager.ProfileChanged += OnProfileChanged;

            this.backgroundWorkerLoadGallery.RunWorkerCompleted += backgroundWorkerLoadGallery_RunWorkerCompleted;
            this.backgroundWorkerLoadGallery.DoWork += backgroundWorkerLoadGallery_DoWork;
            this.backgroundWorkerLoadGallery.WorkerReportsProgress = true;

            this.listViewScreenshots.MouseDoubleClick += listViewScreenshots_MouseDoubleClick;
            this.listViewScreenshots.MouseUp += listViewScreenshots_MouseUp;

            LinkControls();
            HideGalleryOptions();
            //LoadGallery();
        }

        private void Translation_LanguageChanged(object sender, TranslationEventArgs e)
        {
            Translation translation = (Translation)sender;

            this.labelGalleryTitle.Font = CustomFonts.GetHeaderFont();
        }

        private void LinkControls()
        {
            // Screenshot index
            LinkedTweaks.LinkInfo(numScreenshotIndex, toolTip, screenshotIndexTweak);
            LinkedTweaks.LinkInfo(labelScreenshotIndex, toolTip, screenshotIndexTweak);
            LinkedTweaks.LinkTweak(numScreenshotIndex, screenshotIndexTweak);
        }

        private void OnProfileChanged(object sender, ProfileEventArgs e)
        {
            this.game = e.ActiveGameInstance;

            LoadGallery();
        }

        private void LoadGallery()
        {
            this.textBoxGalleryPaths.Text = String.Join("\r\n", Configuration.Gallery.CustomPaths);
            this.checkBoxGallerySearchRecursively.Checked = Configuration.Gallery.SearchDirsRecursively;
        }

        private void UpdateScreenShotGalleryThreaded()
        {
            this.backgroundWorkerLoadGallery.RunWorkerAsync();
        }

        private void backgroundWorkerLoadGallery_DoWork(object sender, DoWorkEventArgs e)
        {
            UpdateScreenShotGallery();
        }

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
             * Search the game folder for screenshots:
             * C:\...\Fallout76\*.png
             */
            string gamePath = this.game.GamePath;
            if (Directory.Exists(gamePath))
            {
                IEnumerable<string> screenshots = Directory.EnumerateFiles(gamePath, "*.png", SearchOption.TopDirectoryOnly);
                foreach (string filePath in screenshots)
                {
                    string fileName = Path.GetFileName(filePath);

                    // Ignore certain images:
                    if (IgnoreImages.Contains(fileName))
                        continue;

                    string thumbPath = Path.Combine(thumbnailsPath, fileName) + ".jpg";
                    Bitmap thumbnail;

                    if (!File.Exists(thumbPath))
                        thumbnail = new Bitmap(Utils.MakeThumbnail(filePath, thumbPath, true));
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

            /*
             * Search the Photos folder for... you guessed it... photos:
             * C:\Users\<your name>\Documents\My Games\Fallout 76\Photos\<UUID>\*.png
             * C:\Users\<your name>\Documents\My Games\Fallout 76\Photos\<UUID>\*-thumbnail.png
             */
            string photosFolder = Path.Combine(IniFiles.ParentPath, "Photos");
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
                            Utils.MakeThumbnail(filePath, thumbnailFilePath, true);
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
                string steamPTSFolder = Path.Combine(Directory.GetDirectories(steamFolder)[0], @"760\remote\1836200\screenshots");
                string steamThumbnailFolder = Path.Combine(steamFolder, "thumbnails");
                string steamPTSThumbnailFolder = Path.Combine(steamPTSFolder, "thumbnails");

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
                                Utils.MakeThumbnail(filePath, thumbnailFilePath, true);
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

                if (Directory.Exists(steamPTSFolder))
                {
                    List<string> screenshots = Directory.GetFiles(steamPTSFolder, "*.jpg", SearchOption.TopDirectoryOnly).ToList();
                    foreach (string filePath in screenshots)
                    {
                        string fileName = Path.GetFileName(filePath);

                        string thumbnailFilePath = Path.Combine(steamPTSThumbnailFolder, fileName);
                        if (!File.Exists(thumbnailFilePath))
                        {
                            thumbnailFilePath = Path.Combine(thumbnailsPath, fileName + ".jpg");
                            if (!File.Exists(thumbnailFilePath))
                                Utils.MakeThumbnail(filePath, thumbnailFilePath, true);
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
                        Utils.MakeThumbnail(filePath, thumbnailFilePath, true);

                    Bitmap thumbnail = new Bitmap(thumbnailFilePath);
                    this.Invoke(() => galleryImageList.Images.Add(fileName, thumbnail));

                    var item = new ListViewItem();
                    item.Text = fileName;
                    item.ImageKey = fileName;
                    this.Invoke(() => this.listViewScreenshots.Items.Add(item));

                    this.galleryImagePaths.Add(filePath);
                }
            }

            //this.Invoke(() => this.pictureBoxGalleryLoadingGIF.Visible = false);
            //this.Invoke(() => this.buttonRefreshGallery.Enabled = true);
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

        private void ShowGalleryOptions()
        {
            this.panelGalleryOptions.Visible = true;
            this.panelGallery.Width -= this.panelGalleryOptions.Width;
        }

        private void HideGalleryOptions()
        {
            this.panelGalleryOptions.Visible = false;
            this.panelGallery.Width += this.panelGalleryOptions.Width;
        }

        private void buttonGalleryShowOptions_Click(object sender, EventArgs e)
        {
            bool isVisible = this.panelGalleryOptions.Visible;

            // is visible? then hide it:
            if (isVisible)
            {
                HideGalleryOptions();
            }
            // is not visible? then show it:
            else
            {
                ShowGalleryOptions();
            }
        }

        private void sliderGalleryThumbnailSize_Scroll(object sender, ScrollEventArgs e)
        {
            galleryImageSizeMult = (int)(this.sliderGalleryThumbnailSize.Value) * 3 + 1;
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
                    Utils.DeleteDirectory(thumbnailsPath);
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
            Configuration.Gallery.CustomPaths = this.textBoxGalleryPaths.Text.Replace("\r\n", "\n").Split('\n');
        }

        private void checkBoxGallerySearchRecursively_CheckedChanged(object sender, EventArgs e)
        {
            Configuration.Gallery.SearchDirsRecursively = this.checkBoxGallerySearchRecursively.Checked;
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


        // Screenshot index
        private ScreenshotIndexTweak screenshotIndexTweak = new ScreenshotIndexTweak();


        private void openFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open one folder.
            // I doubt anyone wants to actually open multiple folders at once
            int index = galleryContextMenuItems[0];
            Utils.OpenExplorer(Path.GetDirectoryName(galleryImagePaths[index]));
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<String> files = new List<String>();
            foreach (int index in galleryContextMenuItems)
                files.Add(galleryImagePaths[index]);
            ClipboardUtils.CutFiles(files);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<String> files = new List<String>();
            foreach (int index in galleryContextMenuItems)
                files.Add(galleryImagePaths[index]);
            ClipboardUtils.CopyFiles(files);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool ok = false;
            if (galleryContextMenuItems.Count == 1)
            {
                String fileName = Path.GetFileName(galleryImagePaths[galleryContextMenuItems[0]]);
                ok = MsgBox.Get("galleryDeleteScreenshot").FormatTitle(fileName).FormatText(fileName).Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }
            else
            {
                ok = MsgBox.Get("galleryDeleteScreenshots").FormatTitle(galleryContextMenuItems.Count.ToString()).FormatText(galleryContextMenuItems.Count.ToString()).Show(MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
            }

            if (ok)
            {
                try
                {
                    foreach (int index in galleryContextMenuItems)
                    {
                        String path = galleryImagePaths[index];
                        Utils.DeleteFile(path);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.GetType().Name}: {ex.Message}", "Couldn't delete image(s)", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                UpdateScreenShotGalleryThreaded();
            }
        }
    }
}
