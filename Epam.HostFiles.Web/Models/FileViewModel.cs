using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.HostFiles.Web.Models
{
    public class FileViewModel
    {
        public string Filename { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
    }
}