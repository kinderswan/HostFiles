using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.HostFiles.IO.Interfaces
{
    public interface IDirectoryMethods
    {
        IEnumerable<string> GetDirectories(string path);
        DirectoryInfo AddDirectory(string path);
    }
}
