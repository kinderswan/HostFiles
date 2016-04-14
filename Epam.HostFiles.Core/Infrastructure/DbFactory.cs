using Epam.HostFiles.Core.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
