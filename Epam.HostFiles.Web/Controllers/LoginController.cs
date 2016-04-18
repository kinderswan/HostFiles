using Epam.HostFiles.Model.Models;
using Epam.HostFiles.Services.Interfaces;
using Epam.HostFiles.Web.Global.Auth;
using Epam.HostFiles.Web.Mapping;
using Epam.HostFiles.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Epam.HostFiles.Web.Controllers
{
    public class LoginController : Controller
    {
        protected IAuthentication Auth;
        protected IUserInfoService UserService;
        public LoginController(IAuthentication auth, IUserInfoService uService)
        {
            Auth = auth;
            UserService = uService;
        }
        // GET: Default/Login
        public ActionResult Index()
        {
            return View(new UserInfoViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(UserInfoViewModel userRegisterModel, bool isRemember = false)
        {
            var userData = userRegisterModel.ToUserInfo();
            if(!ModelState.IsValid)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;

            }
            if (ModelState.IsValid)
            {
                var user = Auth.Login(userData.Login, userData.Password, isRemember);
                if (user != null)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(new UserInfoViewModel());
        }
        public ActionResult Logout()
        {
            Auth.LogOut();
            return RedirectToAction("Index", "Home");
        }
    }
}