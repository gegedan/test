using System;
using System.Web.Mvc;
using System.Web.Http;
using System.Reflection;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using VehicleSales.Data;
using Serilog;

namespace VehicleSales.Host.Ioc
{
    public static class IoCBootstrapper
    {
        public static void Init()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => new LoggerConfiguration().WriteTo.RollingFile($@"{AppDomain.CurrentDomain.BaseDirectory}\logs\log.txt").CreateLogger())
                .As<ILogger>().SingleInstance(); ;

            builder.RegisterType<VehicleRepository>()
                .As<IVehicleRepository>()
                .SingleInstance();

            //mvc
            builder.RegisterControllers(typeof(Global).Assembly);

            //api
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}