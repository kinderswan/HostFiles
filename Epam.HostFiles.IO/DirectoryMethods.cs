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
            if (!Directory.Exists(path))
            {
                return Directory.CreateDirectory(path);
            }
            return null;
            
        }

        public IEnumerable<string> GetDirectories(string path)
        {
            //Unauthorized access
            return Directory.GetDirectories(path);
        }
    }
}
