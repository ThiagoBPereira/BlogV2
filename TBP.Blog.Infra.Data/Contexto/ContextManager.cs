using System.Web;
using TBP.Blog.Infra.Data.Interfaces;

namespace TBP.Blog.Infra.Data.Contexto
{
    public class ContextManager : IContextManager
    {
        private const string ContextKey = "ContextManager.Context";
        public BlogContexto GetContext()
        {
            if (HttpContext.Current.Items[ContextKey] == null)
            {
                HttpContext.Current.Items[ContextKey] = new BlogContexto();
            }

            return (BlogContexto)HttpContext.Current.Items[ContextKey];
        }
    }
}