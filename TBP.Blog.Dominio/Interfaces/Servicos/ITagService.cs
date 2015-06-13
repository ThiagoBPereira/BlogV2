using System.Collections.Generic;
using TBP.Blog.Dominio.Entidades;

namespace TBP.Blog.Dominio.Interfaces.Servicos
{
    public interface ITagService : IBaseService<Tag>
    {
        IEnumerable<Tag> GetByName(string username, string nome);
    }
}