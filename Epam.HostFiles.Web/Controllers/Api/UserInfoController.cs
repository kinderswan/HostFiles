﻿using Epam.HostFiles.Services.Interfaces;
using Epam.HostFiles.Web.Global.Auth;
using Epam.HostFiles.Web.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Epam.HostFiles.Web.Controllers.Api
{
    public class UserInfoController : ApiController
    {
        private readonly IUserInfoService _userService;

        public UserInfoController(IUserInfoService userService)
        {
            _userService = userService;
        }

        [Route("api/users/")]
        public IHttpActionResult GetUsers()
        {
            return Json(_userService.GetUserInfos().Select(u => u.ToUserInfoViewModel()));
        }
        [Route("api/users/{id}")]
        public IHttpActionResult GetUser(int id)
        {
            return Json(_userService.GetUserInfo(id).ToUserInfoViewModel());
        }
    }
}
