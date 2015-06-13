using System.Collections.Generic;
using TBP.Blog.Dominio.Entidades;

namespace TBP.Blog.Dominio.Interfaces.Servicos
{
    public interface IPostService : IBaseService<Post>
    {
        IEnumerable<Post> ListAllByUser(string username, int indexPagina, int qtddPorPagina);

        IEnumerable<Post> GetByTagName(string username, string tag);
    }
}