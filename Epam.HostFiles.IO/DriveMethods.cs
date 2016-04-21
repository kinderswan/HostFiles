using Epam.HostFiles.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
