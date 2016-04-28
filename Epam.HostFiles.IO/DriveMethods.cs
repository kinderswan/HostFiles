using Epam.HostFiles.IO.Interfaces;
using System.Collections.Generic;
using System.IO;

namespace Epam.HostFiles.IO
{
    public class DriveMethods : IDriveMethods
    {
        public IEnumerable<DriveInfo> GetDrives()
        {
            return DriveInfo.GetDrives();
        }
    }
}
