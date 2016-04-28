using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Epam.HostFiles.IO.Interfaces
{
    public interface IFileMethods
    {
        IEnumerable<FileInfo> GetFiles(string path);
        Task<FileInfo> AddFile(Stream contentStream, string path);
        Stream DownloadFile(string path);

    }
}
