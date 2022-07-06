using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fo76ini.Controls
{
    public partial class UserControlHero : UserControl
    {
        // https://www.steamgriddb.com/game/5067850
        public static String HeroURL = "https://cdn.cloudflare.steamstatic.com/steam/apps/1151340/library_hero.jpg"; // ?t=1655226238
        public static float HeroAspectRatio = 1920f / 620f;

        public UserControlHero()
        {
            InitializeComponent();
        }

        private void UserControlHero_Load(object sender, EventArgs e)
        {
            // Load hero banner from Steam:
            long timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
            this.pictureBoxHero.LoadAsync(HeroURL + "?t=" + timestamp.ToString());
        }

        private void pictureBoxHero_Resize(object sender, EventArgs e)
        {
            // Resize image to fit:
            this.pictureBoxHero.Height = (int)(Width / HeroAspectRatio) + 5;

            // Center image:
            this.pictureBoxHero.Top = (this.Height - this.pictureBoxHero.Height) / 2;
        }

        // https://stackoverflow.com/a/37764157
    }
}
