using System.ComponentModel.DataAnnotations;

namespace Epam.HostFiles.Web.Models
{
    public class UserInfoViewModel
    {
        [Required]
        public int UserInfoId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
        [Required]    
        public int UserRoleId { get; set; }
    }
}
