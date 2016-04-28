using Epam.HostFiles.Model.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Epam.HostFiles.Core
{
    public class HostFilesSeedData : CreateDatabaseIfNotExists<HostFilesEntities>
    {
        protected override void Seed(HostFilesEntities context)
        {
            GetUserRoles().ForEach(item => context.UserRoles.Add(item));
            context.Commit();
            GetUserInfos().ForEach(item => context.UserInfos.Add(item));
            context.Commit();
        }
        private static List<UserInfo> GetUserInfos()
        {
            return new List<UserInfo>
            {
                new UserInfo()
                {
                    Login = "kinderswan",
                    Password = "8cb2237d0679ca88db6464eac60da96345513964",
                    UserRoleId = 1
                }
            };
        }
        private static List<UserRole> GetUserRoles()
        {
            return new List<UserRole>
            {
               new UserRole()
               {
                   Role = "Admin"
               },
               new UserRole()
               {
                   Role = "User"
               }
            };
        }
    }
}
