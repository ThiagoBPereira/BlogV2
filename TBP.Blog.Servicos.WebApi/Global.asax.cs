using System.Web;
using System.Web.Http;
using TBP.Blog.Aplicacao.AutoMpp;

namespace TBP.Blog.Servicos.WebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(WebApiConfig.FormatadorDeResposta);
            AutoMapperConfig.RegisterMappings();
        }
    }
}
