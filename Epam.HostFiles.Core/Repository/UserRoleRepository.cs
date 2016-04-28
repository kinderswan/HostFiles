using Epam.HostFiles.Core.Infrastructure;
using Epam.HostFiles.Core.Infrastructure.Interfaces;
using Epam.HostFiles.Core.Repository.Interfaces;
using Epam.HostFiles.Model.Models;

namespace Epam.HostFiles.Core.Repository
{
    public class UserRoleRepository : RepositoryBase<UserRole>, IUserRoleRepository
    {
        public UserRoleRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
