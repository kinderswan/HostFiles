using Epam.HostFiles.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.HostFiles.Web.Global.Auth
{
    public interface IUserProvider
    {
        UserInfo User { get; set; }
    }
}