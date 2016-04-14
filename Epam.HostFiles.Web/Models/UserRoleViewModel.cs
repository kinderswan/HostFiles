using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.HostFiles.Model.Models
{
    public class UserRoleViewModel
    {
        [Required]
        public int UserRoleId { get; set; }
        public string Role { get; set; }
        public string RoleDescription { get; set; }
    }
}
