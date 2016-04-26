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
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserRoleService(IUserRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _userRoleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }

        public UserRole CreateRole(UserRole userRole)
        {
            if(!_userRoleRepository.GetMany(r=>r.Role==userRole.Role).Any())
            {
                _userRoleRepository.Add(userRole);
                return userRole;
            }
            return null;           

        }

        public void DeleteRole(int id)
        {
            _userRoleRepository.Delete(r => r.UserRoleId == id);
        }

        public IEnumerable<UserRole> GetUserRoles()
        {
            return _userRoleRepository.GetAll();
        }

        public UserRole GetUserRole(int id)
        {
            return _userRoleRepository.Get(r => r.UserRoleId == id);
        }

        public void UpdateRole(UserRole userRole)
        {
            _userRoleRepository.Update(userRole);
        }
        public void SaveUserRole()
        {
            _unitOfWork.Commit();
        }
    }
}
