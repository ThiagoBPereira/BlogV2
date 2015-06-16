using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Newtonsoft.Json;
using TBP.Blog.Aplicacao.AutoMpp;
using TBP.Blog.Aplicacao.ViewModels;

namespace TBP.Blog.Apresentacao.Mvc
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();

            ModelBinders.Binders.Add(typeof(TagViewModel), new TagsEnumModelBinder());
            ModelBinders.Binders.Add(typeof(IEnumerable<TagViewModel>), new TagsEnumModelBinder());
            ModelBinders.Binders.Add(typeof(PostViewModel), new PostModelBinder());


            //Setar configurações do Json convert para ignorar referencia circular
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };


        }
    }
}
