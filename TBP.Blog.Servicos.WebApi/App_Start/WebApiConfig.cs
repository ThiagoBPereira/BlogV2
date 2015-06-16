using System.Web.Http;
using Newtonsoft.Json;

namespace TBP.Blog.Servicos.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.EnableCors();

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        public static void FormatadorDeResposta(HttpConfiguration config)
        {
            //Remover formato XML
            var formatters = config.Formatters;

            formatters.Remove(formatters.XmlFormatter);


            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

        }


    }
}
