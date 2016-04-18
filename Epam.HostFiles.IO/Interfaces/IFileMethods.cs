using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Epam.HostFiles.IO.Interfaces
{
    public interface IFileMethods
    {
        IEnumerable<FileInfo> GetFiles(string path);
        Task AddFile(Stream contentStream, string path);
        Stream DownloadFile(string path);

    }
}
