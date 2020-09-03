using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Fo76ini
{
    // https://stackoverflow.com/questions/2077981/cut-files-to-clipboard-in-c-sharp
    public class ClipboardUtils
    {
        public static void CopyFile(String file)
        {
            FileSystemInfo fsinfo = null;
            if (File.Exists(file))
                fsinfo = new FileInfo(file);
            else if (Directory.Exists(file))
                fsinfo = new DirectoryInfo(file);

            ClipboardUtils.PutFilesOnClipboard(
                new List<FileSystemInfo> { fsinfo },
                DragDropEffects.Copy);
        }

        public static void CutFile(String file)
        {
            FileSystemInfo fsinfo = null;
            if (File.Exists(file))
                fsinfo = new FileInfo(file);
            else if (Directory.Exists(file))
                fsinfo = new DirectoryInfo(file);

            ClipboardUtils.PutFilesOnClipboard(
                new List<FileSystemInfo> { fsinfo },
                DragDropEffects.Move);
        }

        public static void CopyFiles(IEnumerable<String> filesAndFolders)
        {
            ClipboardUtils.PutFilesOnClipboard(
                ClipboardUtils.GetFileSystemInfoList(filesAndFolders),
                DragDropEffects.Copy);
        }

        public static void CutFiles(IEnumerable<String> filesAndFolders)
        {
            ClipboardUtils.PutFilesOnClipboard(
                ClipboardUtils.GetFileSystemInfoList(filesAndFolders),
                DragDropEffects.Move);
        }

        private static List<FileSystemInfo> GetFileSystemInfoList (IEnumerable<String> filesAndFolders)
        {
            List<FileSystemInfo> fileSystemInfos = new List<FileSystemInfo>();
            foreach (String fileOrFolder in filesAndFolders)
            {
                FileSystemInfo fsinfo = null;

                if (File.Exists(fileOrFolder))
                    fsinfo = new FileInfo(fileOrFolder);
                else if (Directory.Exists(fileOrFolder))
                    fsinfo = new DirectoryInfo(fileOrFolder);

                if (fsinfo != null)
                    fileSystemInfos.Add(fsinfo);
            }
            return fileSystemInfos;
        }

        private static void PutFilesOnClipboard(IEnumerable<FileSystemInfo> filesAndFolders, DragDropEffects dropEffect)
        {
            var droplist = new StringCollection();
            droplist.AddRange(filesAndFolders.Select(x => x.FullName).ToArray());

            var data = new DataObject();
            data.SetFileDropList(droplist);
            data.SetData("Preferred Dropeffect", new MemoryStream(BitConverter.GetBytes((int)dropEffect)));
            Clipboard.SetDataObject(data);
        }
    }
}
