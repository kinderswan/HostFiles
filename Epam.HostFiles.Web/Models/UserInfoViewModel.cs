using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.HostFiles.Web.Model.Models
{
    public class UserInfoViewModel
    {
        [Required]
        public int UserInfoId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }    
        [Required]    
        public int UserRoleId { get; set; }
    }
}
