using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;
using Syroot.Windows.IO;

namespace Fo76ini
{
    public static class Configuration
    {
        // https://stackoverflow.com/questions/1873658/net-windows-forms-remember-windows-size-and-location
        public static void SaveWindowState(string formName, Form form)
        {
            if (form.WindowState == FormWindowState.Maximized)
            {
                IniFiles.Config.Set(formName, "iLocationX", form.RestoreBounds.Location.X);
                IniFiles.Config.Set(formName, "iLocationY", form.RestoreBounds.Location.Y);
                IniFiles.Config.Set(formName, "iWidth", form.RestoreBounds.Size.Width);
                IniFiles.Config.Set(formName, "iHeight", form.RestoreBounds.Size.Height);
                IniFiles.Config.Set(formName, "bMaximised", true);
            }
            else
            {
                IniFiles.Config.Set(formName, "iLocationX", form.Location.X);
                IniFiles.Config.Set(formName, "iLocationY", form.Location.Y);
                IniFiles.Config.Set(formName, "iWidth", form.Size.Width);
                IniFiles.Config.Set(formName, "iHeight", form.Size.Height);
                IniFiles.Config.Set(formName, "bMaximised", false);
            }
            IniFiles.Config.Save();
        }

        public static void LoadWindowState(string formName, Form form)
        {
            int locX = IniFiles.Config.GetInt(formName, "iLocationX", -1);
            int locY = IniFiles.Config.GetInt(formName, "iLocationY", -1);
            if (locX >= 0 && locY >= 0)
                form.Location = new System.Drawing.Point(locX, locY);

            int width = IniFiles.Config.GetInt(formName, "iWidth", form.Size.Width);
            int height = IniFiles.Config.GetInt(formName, "iHeight", form.Size.Height);
            if (width >= form.MinimumSize.Width && height >= form.MinimumSize.Height)
                form.Size = new System.Drawing.Size(width, height);

            if (IniFiles.Config.GetBool(formName, "bMaximised", false))
                form.WindowState = FormWindowState.Maximized;
        }

        public static void SaveListViewState(string formName, ListView listView)
        {
            List<int> widths = new List<int>();
            foreach (ColumnHeader column in listView.Columns)
            {
                widths.Add(column.Width);
            }
            IniFiles.Config.Set(formName, "sColumnWidths", string.Join(",", widths));
        }

        public static void LoadListViewState(string formName, ListView listView)
        {
            List<int> lWidths = new List<int>();
            string[] sWidths = IniFiles.Config.GetString(formName, "sColumnWidths", "").Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string sWidth in sWidths)
                lWidths.Add(Convert.ToInt32(sWidth));

            int i = 0;
            foreach (ColumnHeader column in listView.Columns)
            {
                if (i < lWidths.Count)
                    column.Width = lWidths[i++];
            }
        }

        // TODO: Remove
        public static bool bUseHardlinks
        {
            get
            {
                return IniFiles.Config.GetBool("Mods", "bUseHardlinks", true);
            }
            set
            {
                IniFiles.Config.Set("Mods", "bUseHardlinks", value);
            }
        }

        public static string DownloadsFolder
        {
            get
            {
                return Path.GetFullPath(IniFiles.Config.GetString("Preferences", "sDownloadPath", KnownFolders.Downloads.Path));
            }
        }
    }
}
