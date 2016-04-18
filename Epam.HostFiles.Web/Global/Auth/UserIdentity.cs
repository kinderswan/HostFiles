using Epam.HostFiles.Model.Models;
using Epam.HostFiles.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Epam.HostFiles.Web.Global.Auth
{
    public class UserIdentity : IIdentity, IUserProvider
    {
        public string Name
        {
            get
            {
                return User != null ? User.Login : "anonym";
            }
        }

        public string AuthenticationType
        {
            get
            {
                return typeof(UserInfo).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get { return User != null; }
        }

        public UserInfo User { get; set; }

        public void Init(string login, IUserInfoService service)
        {
            if (!string.IsNullOrEmpty(login))
            {
                User = service.GetUserInfo(login);
            }
        }
    }
}