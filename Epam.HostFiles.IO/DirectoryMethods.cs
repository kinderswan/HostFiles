using Epam.HostFiles.IO.Interfaces;
using System;
using System.Collections.Generic;
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

        public IEnumerable<DirectoryInfo> GetDirectories(string path)
        {
            //Unauthorized access
            try
            {
                return new DirectoryInfo(path).GetDirectories();
            }
            catch(UnauthorizedAccessException ex)
            {
                throw new UnauthorizedAccessException("Unauthorized access was thrown", ex);
            }
        }
    }
}
