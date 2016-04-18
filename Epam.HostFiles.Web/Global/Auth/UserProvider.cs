using System.Security.Principal;
using Epam.HostFiles.Services.Interfaces;

namespace Epam.HostFiles.Web.Global.Auth
{
    internal class UserProvider : IPrincipal
    {
        private readonly UserIdentity _userIdentity;

        public UserProvider(string email, IUserInfoService service)
        {
            _userIdentity = new UserIdentity();
            _userIdentity.Init(email, service);
        }

        public bool IsInRole(string role)
        {
            if (_userIdentity.User == null)
            {
                return false;
            }
            return _userIdentity.User.UserRole.Role == role;
        }

        public IIdentity Identity
        {
            get { return _userIdentity; }
        }

        public override string ToString()
        {
            return _userIdentity.Name;
        }
    }
}