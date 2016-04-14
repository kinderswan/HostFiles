using Epam.HostFiles.Core.Infrastructure;
using Epam.HostFiles.Core.Infrastructure.Interfaces;
using Epam.HostFiles.Core.Repository.Interfaces;
using Epam.HostFiles.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.HostFiles.Core.Repository
{
    public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
