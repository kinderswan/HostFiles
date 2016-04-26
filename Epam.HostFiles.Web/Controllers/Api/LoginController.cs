using Epam.HostFiles.Services.Interfaces;
using Epam.HostFiles.Web.Global.Auth;
using Epam.HostFiles.Web.Mapping;
using Epam.HostFiles.Web.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Epam.HostFiles.Web.Controllers.Api
{
    public class LoginController : ApiController
    {
        private readonly IAuthentication _auth;
        private readonly IUserInfoService _userService;
        public LoginController(IAuthentication auth, IUserInfoService userService)
        {
            _auth = auth;
            _userService = userService;
        }
        [HttpGet]
        [Route("api/registeredUser")]
        public IHttpActionResult GetRegisteredUser()
        {
            var user = _auth.CurrentUser.Identity.Name;
            return Json(_userService.GetUserInfo(user).ToUserInfoViewModel());
        }
        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login(UserInfoRegisterModel userRegisterModel)
        {
            var logModel = userRegisterModel.ToUserInfo();
            var user = _auth.Login(logModel.Login, logModel.Password, true);
            if (user != null)
            {
                var x = _auth.CurrentUser.Identity.Name;
                return Json(_auth.CurrentUser.Identity.Name);
            }
            return Json(HttpStatusCode.BadRequest);

        }
        [HttpPost]
        [Route("api/logout")]
        public IHttpActionResult Logout()
        {
            _auth.LogOut();
            var x = _auth.CurrentUser.Identity.Name;
            return Json(_auth.CurrentUser.Identity.Name);
        }

        [HttpPost]
        [Route("api/register")]
        public IHttpActionResult Register(UserInfoRegisterModel regModel)
        {
            var regUser = regModel.ToUserInfo();
            if(_userService.GetUserInfo(regUser.Login)!=null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.Conflict, "Sorry, but user with the same login exists"));
            }
            _userService.CreateUser(regUser);
            _userService.SaveUserInfo();
            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK));
        }
    }
}
