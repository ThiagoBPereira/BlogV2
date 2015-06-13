using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TBP.Blog.Apresentacao.Mvc.Startup))]
namespace TBP.Blog.Apresentacao.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
