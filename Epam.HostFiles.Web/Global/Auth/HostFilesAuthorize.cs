using System.Web.Http;
using System.Web.Http.Controllers;

namespace Epam.HostFiles.Web.Global.Auth
{
    public class HostFilesAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly IAuthentication _auth = (IAuthentication)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IAuthentication));

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            if (_auth.CurrentUser.Identity.IsAuthenticated && _auth.CurrentUser.IsInRole(Roles))
            {
                base.HandleUnauthorizedRequest(actionContext);
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
        }
    }
}