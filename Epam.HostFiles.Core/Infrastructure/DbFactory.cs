using Epam.HostFiles.Core.Infrastructure.Interfaces;

namespace Epam.HostFiles.Core.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        HostFilesEntities _dbContext;

        public HostFilesEntities Init()
        {
            return _dbContext ?? (_dbContext = new HostFilesEntities());
        }

        protected override void DisposeCore()
        {
            if (_dbContext != null)
                _dbContext.Dispose();
        }
    }
}
