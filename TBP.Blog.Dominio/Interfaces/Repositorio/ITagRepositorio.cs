using System.Collections.Generic;
using TBP.Blog.Dominio.Entidades;

namespace TBP.Blog.Dominio.Interfaces.Repositorio
{
    public interface ITagRepositorio : IBaseRepositorio<Tag>
    {
        IEnumerable<Tag> GetByName(string username, string nome);
    }
}