using Epam.HostFiles.Model.Models;

namespace Epam.HostFiles.Web.Global.Auth
{
    public interface IUserProvider
    {
        UserInfo User { get; set; }
    }
}