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
        private List<String> galleryImagePaths = new List<String>();
        private ImageList galleryImageList = new ImageList();

        private int galleryImageSizeMult = 4;

        private void LoadGallery()
        {
            // https://stackoverflow.com/questions/6481304/how-to-use-a-backgroundworker
            //this.backgroundWorkerLoadGallery.DoWork += backgroundWorker1_DoWork;
            //this.backgroundWorkerLoadGallery.ProgressChanged += backgroundWorker1_ProgressChanged;
            this.backgroundWorkerLoadGallery.RunWorkerCompleted += backgroundWorkerLoadGallery_RunWorkerCompleted;
            this.backgroundWorkerLoadGallery.WorkerReportsProgress = true;
            //this.backgroundWorkerLoadGallery.WorkerSupportsCancellation = true;

            this.listViewScreenshots.DoubleClick += listViewScreenshots_DoubleClick;
            //this.sliderGalleryThumbnailSize.ValueChanged += sliderGalleryThumbnailSize_ValueChanged;
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
            String thumbnailsPath = Path.Combine(Shared.AppConfigFolder, "thumbnails", "screenshots");
            if (!Directory.Exists(thumbnailsPath))
                Directory.CreateDirectory(thumbnailsPath);

            /*
             * Search the game folders for screenshots:
             * C:\...\Fallout76\*.png
             */
            String[] gamePaths = new String[] {
                IniFiles.Instance.GetString(IniFile.Config, "Preferences", "sGamePathSteam", ""),
                IniFiles.Instance.GetString(IniFile.Config, "Preferences", "sGamePathBethesdaNet", ""),
                IniFiles.Instance.GetString(IniFile.Config, "Preferences", "sGamePathBethesdaNetPTS", "")
            };
            foreach (String gamePath in gamePaths)
            {
                if (Directory.Exists(gamePath))
                {
                    IEnumerable<String> screenshots = Directory.EnumerateFiles(gamePath, "*.png", SearchOption.TopDirectoryOnly);
                    foreach (String filePath in screenshots)
                    {
                        String fileName = Path.GetFileName(filePath);
                        String thumbPath = Path.Combine(thumbnailsPath, fileName) + ".jpg";
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
            String photosFolder = Path.Combine(IniFiles.Instance.iniParentPath, "Photos");
            if (Directory.Exists(photosFolder))
            {
                IEnumerable<String> photos = Directory.EnumerateFiles(photosFolder, "*.png", SearchOption.AllDirectories);
                foreach (String filePath in photos)
                {
                    String fileName = Path.GetFileName(filePath);

                    if (fileName.EndsWith("-thumbnail.png"))
                        continue;

                    String thumbnailFilePath = fileName.Replace(".png", "-thumbnail.png");
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
            String steamFolder = @"C:\Program Files (x86)\Steam\userdata\";
            if (Directory.Exists(steamFolder))
            {
                steamFolder = Path.Combine(Directory.GetDirectories(steamFolder)[0], @"760\remote\1151340\screenshots");
                String steamThumbnailFolder = Path.Combine(steamFolder, "thumbnails");

                if (Directory.Exists(steamFolder))
                {
                    List<String> screenshots = Directory.GetFiles(steamFolder, "*.jpg", SearchOption.TopDirectoryOnly).ToList();
                    foreach (String filePath in screenshots)
                    {
                        String fileName = Path.GetFileName(filePath);

                        String thumbnailFilePath = Path.Combine(steamThumbnailFolder, fileName);
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

            this.Invoke(() => this.pictureBoxGalleryLoadingGIF.Visible = false);
            this.Invoke(() => this.buttonRefreshGallery.Enabled = true);
        }

        private void listViewScreenshots_DoubleClick(object sender, EventArgs e)
        {
            int index = this.listViewScreenshots.SelectedIndices[0];
            Process.Start(galleryImagePaths[index]);
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

        private void Invoke(Action func)
        {
            this.pictureBoxGalleryLoadingGIF.Invoke(func);
        }
    }
}
