using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using Epam.HostFiles.Services.Interfaces;
using Epam.HostFiles.Core.Repository.Interfaces;
using Epam.HostFiles.Core.Infrastructure.Interfaces;
using Epam.HostFiles.Services;
using Epam.HostFiles.Core.Repository;
using Epam.HostFiles.Core.Infrastructure;
using System.Web.Http;

namespace Epam.HostFiles.Web
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUserRoleService, UserRoleService>();
            container.RegisterType<IUserInfoService, UserInfoService>();
            container.RegisterType<IUserRoleRepository, UserRoleRepository>();
            container.RegisterType<IUserInfoRepository, UserInfoRepository>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            container.RegisterType<IDbFactory, DbFactory>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}