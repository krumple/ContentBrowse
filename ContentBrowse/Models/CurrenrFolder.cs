using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DirectoryFileBrowsing.Models
{
    public class CurrentFolder
    {
        public string CurrentFolderName { get; set; }
        public string CurrentFolderPath { get; set; }
        public List<Folder> Folders { get; set; }
        public List<string> Files { get; set; }
        public int LessThanTen { get; set; }
        public int TenToFiveth { get; set; }
        public int MoreThanOneThousend { get; set; }
        public CurrentFolder()
        {
            this.Folders = new List<Folder>();
            this.Files = new List<string>();
            this.LessThanTen = 0;
            this.TenToFiveth = 0;
            this.MoreThanOneThousend = 0;
            }
    }
}