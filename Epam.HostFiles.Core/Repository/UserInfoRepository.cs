using Epam.HostFiles.Core.Infrastructure;
using Epam.HostFiles.Core.Infrastructure.Interfaces;
using Epam.HostFiles.Core.Repository.Interfaces;
using Epam.HostFiles.Model.Models;

namespace Epam.HostFiles.Core.Repository
{
    public class UserInfoRepository : RepositoryBase<UserInfo>, IUserInfoRepository
    {
        public UserInfoRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
