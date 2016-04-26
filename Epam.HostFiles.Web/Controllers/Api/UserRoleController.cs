using Epam.HostFiles.Services.Interfaces;
using Epam.HostFiles.Web.Global.Auth;
using Epam.HostFiles.Web.Mapping;
using Epam.HostFiles.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Epam.HostFiles.Web.Controllers.Api
{

    [HostFilesAuthorize(Roles = "Admin")]
    public class UserRoleController : ApiController
    {
        private readonly IUserRoleService _roleService;
        public UserRoleController(IUserRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        [Route("api/roles/")]
        public IHttpActionResult GetUserRoles()
        {
            return Json(_roleService.GetUserRoles().Select(x => x.ToUserRoleViewModel()));
        }

        [HttpGet]
        [Route("api/roles/{id}")]
        public IHttpActionResult GetUserRoles(int id)
        {
            return Json(_roleService.GetUserRole(id).ToUserRoleViewModel());
        }

        [HttpPut]
        [Route("api/roles/{id}")]
        public IHttpActionResult UpdateUserRole(UserRoleViewModel role,int id)
        {
            _roleService.UpdateRole(role.ToUserRole());
            _roleService.SaveUserRole();
            return Json(role);
        }

        [HttpPost]
        [Route("api/roles")]
        public IHttpActionResult AddUserRole(UserRoleViewModel role)
        {
            var result = _roleService.CreateRole(role.ToUserRole());
            _roleService.SaveUserRole();
            if(result!=null)
            {
                return Json(result.ToUserRoleViewModel());
            }
            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.Conflict, "Creating the role that already exists"));
        }


    }
}
