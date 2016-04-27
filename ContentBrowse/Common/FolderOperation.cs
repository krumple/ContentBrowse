using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using DirectoryFileBrowsing.Models;
namespace DirectoryFileBrowsing.Common
{
    public static class FolderOperation
    {
        public static CurrentFolder GetContent(string path)
        {

            
            CurrentFolder currentFolder = new CurrentFolder();
            if (!String.IsNullOrEmpty(path))
            {
                string[] folders = Directory.GetDirectories(path);
                string[] files = Directory.GetFiles(path);
                currentFolder.CurrentFolderPath = path;
                foreach (string folder in folders)
                {
                    Folder folderInfo = new Folder();
                    folderInfo.Name = Path.GetFileName(folder);
                    folderInfo.Path = folder;
                    currentFolder.Folders.Add(folderInfo);
                }

                    foreach (string file in files)
                    {
                        currentFolder.Files.Add(Path.GetFileName(file));
                    }
                    SetFilesCount(currentFolder, path);
            }
            else
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                currentFolder.CurrentFolderPath = "root";
                foreach (DriveInfo drive in drives)
                {
                    if (drive.DriveType == DriveType.Fixed)
                    {
                        Folder folderInfo = new Folder();
                        folderInfo.Name = drive.Name;
                        folderInfo.Path = drive.Name;
                        currentFolder.Folders.Add(folderInfo);
                    }
                }

            }
            return currentFolder;
        }
        public static void SetFilesCount( CurrentFolder folder, string path)
        { string[] folders = null;
        string[] files = null;
          folders = Directory.GetDirectories(path);
          files = Directory.GetFiles(path);
            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);
                if (info.Length <= 10485760) 
                {
                    folder.LessThanTen++;
                }
                else if (info.Length >= 10485760 && info.Length <= 52428800)
                {
                    folder.TenToFiveth++;
                }
                else if (info.Length >= 104857600)
                {
                    folder.MoreThanOneThousend++;
                }
            }
            if (folders != null)
            {
                foreach (string folderInside in folders)
                {
                    bool isError = false;
                    try
                    {
                        string[] Checkfolders = Directory.GetDirectories(folderInside);
                    }
                    catch
                    {
                        isError = true;
                    }
                    if (isError)
                    {
                        continue;
                    }
                    else
                    {
                        SetFilesCount(folder, folderInside);
                    }
                    
                }
            }
        }

    }
}