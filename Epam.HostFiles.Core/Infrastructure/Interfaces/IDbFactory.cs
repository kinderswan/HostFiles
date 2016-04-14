using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.HostFiles.Core.Infrastructure.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        HostFilesEntities Init();
    }
}
