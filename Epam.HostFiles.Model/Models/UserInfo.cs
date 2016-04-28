namespace Epam.HostFiles.Model.Models
{
    public class UserInfo
    {
        public int UserInfoId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        
        public int UserRoleId { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}
