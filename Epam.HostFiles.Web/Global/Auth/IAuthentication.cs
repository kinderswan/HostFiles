using Epam.HostFiles.Model.Models;
using System.Security.Principal;
using System.Web;

namespace Epam.HostFiles.Web.Global.Auth
{
    public interface IAuthentication
    {
        HttpContext HttpContext { get; set; }
        UserInfo Login(string login, string password, bool isPersistent);
        void LogOut();
        IPrincipal CurrentUser { get; }
    }
}
