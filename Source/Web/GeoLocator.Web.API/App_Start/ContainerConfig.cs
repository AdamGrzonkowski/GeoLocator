using Autofac;
using Autofac.Integration.WebApi;

using GeoLocator.Application.Services;
using GeoLocator.Application.Services.Interfaces;
using GeoLocator.Domain.Services;
using GeoLocator.Domain.Services.Interfaces;

using System.Reflection;
using System.Web.Http;

namespace GeoLocator.Web.API.App_Start
{
    public static class ContainerConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            RegisterServices(builder);

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationContext>().As<IDbContext>().InstancePerRequest();

            builder.RegisterType<GeoLocationRepository>().As<IGeoLocationRepository>().InstancePerRequest();
            builder.RegisterType<GeoLocationService>().As<IGeoLocationService>().InstancePerRequest();
        }
    }
}