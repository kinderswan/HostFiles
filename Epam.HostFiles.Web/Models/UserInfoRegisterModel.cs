using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.HostFiles.Web.Models
{
    public class UserInfoRegisterModel
    {
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}