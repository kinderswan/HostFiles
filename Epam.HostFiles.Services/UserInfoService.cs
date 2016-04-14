using Epam.HostFiles.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.HostFiles.Model.Models;
using Epam.HostFiles.Core.Repository.Interfaces;
using Epam.HostFiles.Core.Infrastructure.Interfaces;

namespace Epam.HostFiles.Services
{
    public class UserInfoService : IUserInfoService
    {
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserInfoService(IUserInfoRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userInfoRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public void CreateUser(UserInfo userInfo)
        {
            _userInfoRepository.Add(userInfo);
        }

        public void DeleteUser(int id)
        {
            _userInfoRepository.Delete(u => u.UserInfoId == id);
        }

        public UserInfo GetUserInfo(int id)
        {
            return _userInfoRepository.Get(u => u.UserInfoId == id);
        }

        public void SaveUserInfo()
        {
            _unitOfWork.Commit();
        }

        public void UpdateUser(UserInfo userInfo)
        {
            _userInfoRepository.Update(userInfo);
        }
    }
}
