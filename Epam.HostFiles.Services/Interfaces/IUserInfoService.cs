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
        UserInfo GetUserInfo(string login);
        UserInfo GetUserInfo(string login, string password);
        IEnumerable<UserInfo> GetUserInfos();
        void CreateUser(UserInfo userInfo);
        void UpdateUser(UserInfo userInfo);
        void DeleteUser(int id);
        void SaveUserInfo();
    }
}
