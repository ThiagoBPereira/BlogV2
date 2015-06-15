using System.Collections.Generic;
using TBP.Blog.Dominio.Entidades;

namespace TBP.Blog.Dominio.Interfaces.Repositorio
{
    public interface IPostRepositorio : IBaseRepositorio<Post>
    {
        IEnumerable<Post> ListAllByUser(string username, int indexPagina, int qtddPorPagina);
        IEnumerable<Post> GetByTagName(string username, string tag, int indexPagina, int qtddPorPagina);
        int ObterTotalRegistros(string username);
        int ObterTotalRegistrosByTag(string username, string tag);
    }
}