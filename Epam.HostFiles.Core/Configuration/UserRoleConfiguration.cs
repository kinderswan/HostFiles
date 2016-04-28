using Epam.HostFiles.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Epam.HostFiles.Core.Configuration
{
    public class UserRoleConfiguration : EntityTypeConfiguration<UserRole>
    {
        public UserRoleConfiguration()
        {
            ToTable("UserRole");
            HasKey(u => u.UserRoleId);
            HasMany(u => u.Users).WithRequired(u => u.UserRole).HasForeignKey(u => u.UserRoleId);
        }
    }
}
