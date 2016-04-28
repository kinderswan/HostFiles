using System.Collections.Generic;
using System.IO;

namespace Epam.HostFiles.IO.Interfaces
{
    public interface IDriveMethods
    {
        IEnumerable<DriveInfo> GetDrives();
    }
}
