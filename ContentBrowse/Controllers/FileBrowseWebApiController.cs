using DirectoryFileBrowsing.Common;
using DirectoryFileBrowsing.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DirectoryFileBrowsing.Controllers
{
    public class FileBrowseWebApiController : ApiController
    {
        /// <summary>
        /// Get content of foder
        /// </summary>
        /// <param name="path">path to folder</param>
        /// <returns>DirectoryFileBrowsing.Models.CurrentFolder</returns>
        [HttpGet]
        public CurrentFolder Get(string path, bool parrent)
        {
            if (parrent) 
            {
                DirectoryInfo d = new DirectoryInfo(path);
                    if (d.Parent != null )
                    {
                        path = Directory.GetParent(path).FullName;
                    }
                    else { path = ""; }

            }
                return FolderOperation.GetContent(path);            
        }

    }
}
