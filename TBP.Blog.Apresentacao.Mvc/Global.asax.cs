using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TBP.Blog.Aplicacao.AutoMpp;
using TBP.Blog.Aplicacao.ViewModels;

namespace TBP.Blog.Apresentacao.Mvc
{
    public class MvcApplication : System.Web.HttpApplication
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




        }
    }
}
