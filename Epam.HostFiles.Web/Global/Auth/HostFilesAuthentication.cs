using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Epam.HostFiles.Model.Models;
using Epam.HostFiles.Services.Interfaces;
using System.Web.Helpers;
using System.Web.Security;
using System.Web.Http;

namespace Epam.HostFiles.Web.Global.Auth
{
    public class HostFilesAuthentication : IAuthentication
    {
        private readonly IUserInfoService _userInfoService;
        private const string CookieName = "__AUTH_COOKIE";
        private IPrincipal _currentUser;

        public HttpContext HttpContext { get; set; }

        public string InstanceProperty { get; set; }

        public HostFilesAuthentication(IUserInfoService userService)
        {
            _userInfoService = userService;
        }

        public IPrincipal CurrentUser
        {
            get
            {
                return CurrUser();
            }
        }

        public UserInfo Login(string login, string password, bool isPersistent)
        {
            var retUser = _userInfoService.GetUserInfo(login, Crypto.SHA1(password));
            if (retUser != null)
            {
                CreateCookie(login, isPersistent);
            }
            return retUser;

        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[CookieName];
            if (httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }

        private void CreateCookie(string email, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(1, email, DateTime.Now,
                DateTime.Now.Add(new TimeSpan(1, 0, 0)), isPersistent, string.Empty,
                FormsAuthentication.FormsCookiePath);
            var encTicket = FormsAuthentication.Encrypt(ticket);
            var authCookie = new HttpCookie(CookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(new TimeSpan(1, 0, 0))
            };
            HttpContext.Response.Cookies.Set(authCookie);
        }

        private IPrincipal CurrUser()
        {
            try
            {
                HttpCookie authCookie = HttpContext.Request.Cookies.Get(CookieName);
                if (authCookie != null && !string.IsNullOrEmpty(authCookie.Value))
                {
                    var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                    _currentUser = new UserProvider(ticket.Name, _userInfoService);
                }
                else
                {
                    _currentUser = new UserProvider(null, null);
                }
            }
            catch
            {
                _currentUser = new UserProvider(null, null);
            }
            return _currentUser;
        }
    }
}