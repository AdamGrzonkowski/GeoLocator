using GeoLocator.Web.API;

using log4net;

using Swashbuckle.Application;

using System.IO;
using System.Net.Http;
using System.Web.Http;

using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), nameof(SwaggerConfig.Register))]

namespace GeoLocator.Web.API
{
    public class SwaggerConfig
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(SwaggerConfig));

        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            string xmlCommentsPath = Path.Combine(Path.GetDirectoryName(thisAssembly.CodeBase), "GeoLocator.Web.API.xml").Replace("file:\\", string.Empty);

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "GeoLocator.Web.API");
                        c.PrettyPrint();

                        if (File.Exists(xmlCommentsPath))
                        {
                            c.IncludeXmlComments(xmlCommentsPath);
                        }
                        else
                        {
                            _logger.Error("XML documentation file was not found. Api methods have no descriptions in Swagger UI!");
                        }
                    })
                .EnableSwaggerUi(c =>
                {
                    c.SupportedSubmitMethods(nameof(HttpMethod.Get), nameof(HttpMethod.Head));
                });
        }
    }
}
