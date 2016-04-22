using Epam.HostFiles.Model.Models;
using Epam.HostFiles.Web.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
                UserRole = info.UserRole.Role,
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
        public static UserInfo ToUserInfo(this UserInfoRegisterModel model)
        {
            return new UserInfo
            {
                Login = model.Login,
                Password = model.Password
            };
        }
        public static DirectoryViewModel ToDirectoryViewModel(this string dir)
        {
            return new DirectoryViewModel
            {
                DirectoryName = dir
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