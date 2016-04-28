using System;

namespace Epam.HostFiles.Core.Infrastructure.Interfaces
{
    public interface IDbFactory : IDisposable
    {
        HostFilesEntities Init();
    }
}
