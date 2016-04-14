using Epam.HostFiles.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.HostFiles.Services.Interfaces
{
    public interface IUserInfoService
    {
        UserInfo GetUserInfo(int id);
        void CreateUser(UserInfo userInfo);
        void UpdateUser(UserInfo userInfo);
        void DeleteUser(int id);
        void SaveUserInfo();
    }
}
