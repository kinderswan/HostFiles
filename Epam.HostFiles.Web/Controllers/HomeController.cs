using Epam.HostFiles.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Epam.HostFiles.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserInfoService _userService;

        public HomeController(IUserInfoService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            var x = _userService.GetUserInfo(1);
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
