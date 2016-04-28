using System.ComponentModel.DataAnnotations;

namespace Epam.HostFiles.Web.Models
{
    public class UserRoleViewModel
    {
        [Required]
        public int UserRoleId { get; set; }
        public string Role { get; set; }
        public string RoleDescription { get; set; }
    }
}
