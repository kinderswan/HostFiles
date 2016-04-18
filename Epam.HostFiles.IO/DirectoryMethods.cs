using Epam.HostFiles.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Epam.HostFiles.IO
{
    public class DirectoryMethods : IDirectoryMethods
    {
        public DirectoryInfo AddDirectory(string path)
        {
            return Directory.CreateDirectory(path);
        }

        public IEnumerable<string> GetDirectories(string path)
        {
            return Directory.GetDirectories(path);
        }
    }
}
