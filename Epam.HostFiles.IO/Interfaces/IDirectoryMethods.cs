using System.Collections.Generic;
using System.IO;

namespace Epam.HostFiles.IO.Interfaces
{
    public interface IDirectoryMethods
    {
        IEnumerable<DirectoryInfo> GetDirectories(string path);
        DirectoryInfo AddDirectory(string path);
    }
}
