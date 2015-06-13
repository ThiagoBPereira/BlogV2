using TBP.Blog.Infra.Data.Contexto;

namespace TBP.Blog.Infra.Data.Interfaces
{
    public interface IContextManager
    {
        BlogContexto GetContext();
    }
}