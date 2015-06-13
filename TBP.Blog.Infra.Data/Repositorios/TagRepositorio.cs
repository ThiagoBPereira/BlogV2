using System.Collections.Generic;
using System.Linq;
using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Dominio.Interfaces.Repositorio;

namespace TBP.Blog.Infra.Data.Repositorios
{
    public class TagRepositorio : BaseRepositorio<Tag>, ITagRepositorio
    {
        public IEnumerable<Tag> GetByName(string username, string nome)
        {
            return DbSet.Where(i => i.Nome.ToLower().Contains(nome.ToLower()) && i.UserId.Equals(username));
        }
    }
}