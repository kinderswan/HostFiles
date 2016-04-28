using Epam.HostFiles.Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Epam.HostFiles.Core.Configuration
{
    public class UserInfoConfiguration : EntityTypeConfiguration<UserInfo>
    {
        public UserInfoConfiguration()
        {
            ToTable("UserInfo");
            HasKey(u => u.UserInfoId);
        }

    }
}
