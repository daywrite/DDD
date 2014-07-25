using DDD.Domain.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DDD.Infrastructure;
using Autofac;
using Autofac.Integration.Mvc; 
using log4net;
using DDD.Domain.Repositories.MongoDB;
namespace DDD.Web
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //数据库生成初始入口
            DatabaseInitializer.Initialize();
            //Ioc注入
            var builder = AutofacHelper.RegisterService();
            //MongoDB
            //builder.RegisterType<DDD.Domain.Repositories.MongoDB.MongoDBRepositoryContext>().AsImplementedInterfaces();
            //builder.RegisterType<DDD.Domain.Repositories.MongoDB.UserRepository>().AsImplementedInterfaces();
            //EF
            builder.RegisterType<DDD.Domain.Repositories.EntityFramework.EFRepositoryContext>().AsImplementedInterfaces();
            builder.RegisterType<DDD.Domain.Repositories.EntityFramework.UserRepository>().AsImplementedInterfaces();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(builder.Build()));
        }
    }
}