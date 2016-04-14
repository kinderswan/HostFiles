using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.HostFiles.Model.Models
{
    public class UserRole
    {
        public int UserRoleId { get; set; }
        public string Role { get; set; }
        public string RoleDescription { get; set; }

        public virtual ICollection<UserInfo> Users { get; set; }
    }
}
