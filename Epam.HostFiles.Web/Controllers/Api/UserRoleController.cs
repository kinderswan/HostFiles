using Epam.HostFiles.Services.Interfaces;
using Epam.HostFiles.Web.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Epam.HostFiles.Web.Controllers.Api
{
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
            return Json(_roleService.GetUserRoles().Select(x=>x.ToUserRoleViewModel()));
        }

        [HttpGet]
        [Route("api/roles/{id}")]
        public IHttpActionResult GetUserRoles(int id)
        {
            return Json(_roleService.GetUserRole(id).ToUserRoleViewModel());
        }

    }
}
