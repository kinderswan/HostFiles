using Epam.HostFiles.Model.Models;
using Epam.HostFiles.Web.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Epam.HostFiles.Web.Mapping
{
    public static class EntityMapper
    {
        public static UserInfo ToUserInfo(this UserInfoViewModel vm)
        {
            return new UserInfo
            {
                Login = vm.Login,
                Name = vm.Name,
                Password = vm.Password,
                UserRoleId = vm.UserRoleId
            };
        }
        public static UserRole ToUserRole(this UserRoleViewModel vm)
        {
            return new UserRole
            {
                Role = vm.Role,
                RoleDescription = vm.RoleDescription
            };
        }
        public static UserInfoViewModel ToUserInfoViewModel(this UserInfo info)
        {
            return new UserInfoViewModel
            {
                Password = info.Password,
                UserInfoId = info.UserInfoId,
                UserRoleId = info.UserRoleId,
                Login = info.Login,
                Name = info.Name
            };
        }
        public static UserRoleViewModel ToUserRoleViewModel(this UserRole role)
        {
            return new UserRoleViewModel
            {
                Role = role.Role,
                UserRoleId = role.UserRoleId,
                RoleDescription = role.RoleDescription
            };
        }


    }
}