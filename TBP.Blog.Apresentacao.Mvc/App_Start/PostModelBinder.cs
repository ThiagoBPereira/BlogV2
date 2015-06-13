using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using TBP.Blog.Aplicacao.ViewModels;

namespace TBP.Blog.Apresentacao.Mvc
{
    public class PostModelBinder : DefaultModelBinder
    {

        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            if (bindingContext.ModelType != typeof(PostViewModel))
                return base.BindModel(controllerContext, bindingContext);

            //Pegando Id do usuario logado
            var usuario = controllerContext.RequestContext.HttpContext.User.Identity.GetUserId();

            //usando os Binds normais
            var esta = base.BindModel(controllerContext, bindingContext) as PostViewModel;

            //Setando Id do usuário
            esta.UserId = usuario;

            return esta;
        }
    }
}