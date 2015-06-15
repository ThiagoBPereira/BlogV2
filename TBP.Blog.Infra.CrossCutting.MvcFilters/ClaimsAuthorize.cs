using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace TBP.Blog.Infra.CrossCutting.MvcFilters
{
    //Criação da Verificação de Claims - Implementação para área de admin
    //TODO 4: Criar AuthorizeAttribute de edição e create
    public class ClaimsAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string _claimName;
        private readonly string _claimValue;

        public ClaimsAuthorizeAttribute(string claimName, string claimValue)
        {
            _claimName = claimName;
            _claimValue = claimValue;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var identity = (ClaimsIdentity)httpContext.User.Identity;

            var claim = identity.Claims.FirstOrDefault(c => c.Type == _claimName);

            if (claim != null)
            {
                return claim.Value == _claimValue;
            }

            return false;
        }
    }
}