using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace TBP.Blog.Infra.CrossCutting.MvcFilters
{
    //TODO 4: Criar AuthorizeAttribute de edição e create
    public class EditAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _validadorDeUsuario;

        public EditAuthorizeAttribute(string validadorDeUsuario)
        {
            _validadorDeUsuario = validadorDeUsuario;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Caso o usuário logado seja igual ao usuário da rota ele poderá editar a página
            //Pode ser executada uma ação de pesquisa no banco, se necessária maior validação
            var identity = httpContext.User.Identity.GetUserName() as string;
            var valor = httpContext.Request.RequestContext.RouteData.Values[_validadorDeUsuario].ToString();

            return valor.ToLower().Equals(identity.ToLower());
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //Caso o usuário seja diferente, ele deverá setar o erro
            filterContext.Result = new HttpStatusCodeResult(403);
            //base.HandleUnauthorizedRequest(filterContext);
        }
    }
}