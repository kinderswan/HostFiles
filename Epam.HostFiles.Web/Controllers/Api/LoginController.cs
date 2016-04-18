using Epam.HostFiles.Services.Interfaces;
using Epam.HostFiles.Web.Global.Auth;
using Epam.HostFiles.Web.Mapping;
using Epam.HostFiles.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login([FromBody]UserInfoRegisterModel userRegisterModel, bool isRemember = false)
        {
            if (!ModelState.IsValid)
            {
                return Json(HttpStatusCode.BadRequest);
            }
            var user = _auth.Login(userRegisterModel.Login, userRegisterModel.Password, isRemember);
            if (user != null)
            {
                return Json(_auth.CurrentUser.Identity.Name);
            }
            return Json(HttpStatusCode.BadRequest);

        }
        [HttpPost]
        [Route("api/logout")]
        public IHttpActionResult Logout()
        {
            _auth.LogOut();
            return Json(_auth.CurrentUser.Identity.Name);
        }
    }
}
