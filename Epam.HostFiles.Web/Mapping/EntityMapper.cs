using Epam.HostFiles.Model.Models;
using Epam.HostFiles.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Epam.HostFiles.Web.Mapping
{
    public static class EntityMapper
    {
        public static UserInfo ToUserInfo(this UserInfoViewModel vm)
        {
            return new UserInfo
            {
                UserInfoId = vm.UserInfoId,
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
                UserRoleId = vm.UserRoleId,
                Role = vm.Role,
                RoleDescription = vm.RoleDescription
            };
        }
        public static UserInfoViewModel ToUserInfoViewModel(this UserInfo info)
        {
            if (info == null) return null;
            return new UserInfoViewModel
            {
                UserInfoId = info.UserInfoId,
                UserRoleId = info.UserRoleId,
                UserRole = info.UserRole.Role,
                Login = info.Login,
                Name = info.Name
            };
        }
        public static UserRoleViewModel ToUserRoleViewModel(this UserRole role)
        {
            if (role == null) return null;
            return new UserRoleViewModel
            {
                Role = role.Role,
                UserRoleId = role.UserRoleId,
                RoleDescription = role.RoleDescription
            };
        }
        public static UserInfo ToUserInfo(this UserInfoRegisterModel model)
        {
            return new UserInfo
            {
                Name = model.Name,
                Login = model.Login,
                Password = Crypto.SHA1(model.Password),
                UserRoleId = 2 //User id
            };
        }
        public static DirectoryViewModel ToDirectoryViewModel(this DirectoryInfo dir)
        {
            if (dir == null) return null;
            return new DirectoryViewModel
            {
                DirectoryName = dir.FullName
            };

        }
        public static FileViewModel ToFileViewModel(this FileInfo file)
        {
            return new FileViewModel
            {
                Filename = file.Name,
                Path = file.FullName,
                Size = file.Length
            };
        }
        public static DriveViewModel ToDriveViewModel(this DriveInfo drive)
        {
            return new DriveViewModel
            {
                DriveName = drive.Name
            };
        }

    }
}