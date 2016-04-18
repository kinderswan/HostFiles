﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Epam.HostFiles.Web.Global.Auth
{
    public class AuthHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += Authenticate;
        }

        public void Dispose()
        {
        }

        private void Authenticate(object source, EventArgs e)
        {
            HttpApplication app = (HttpApplication)source;
            HttpContext context = app.Context;
            var auth = (IAuthentication)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IAuthentication));
            auth.HttpContext = context;
            context.User = auth.CurrentUser;
        }
    }
}