using Epam.HostFiles.Model.Models;
using System.Collections.Generic;

namespace Epam.HostFiles.Services.Interfaces
{
    public interface IUserRoleService
    {
        UserRole GetUserRole(int id);
        IEnumerable<UserRole> GetUserRoles();
        UserRole CreateRole(UserRole userRole);
        void UpdateRole(UserRole userRole);
        void DeleteRole(int id);
        void SaveUserRole();
    }
}
