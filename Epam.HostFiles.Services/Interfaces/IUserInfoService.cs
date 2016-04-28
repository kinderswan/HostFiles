using Epam.HostFiles.Model.Models;
using System.Collections.Generic;

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
