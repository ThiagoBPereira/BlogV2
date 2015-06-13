using System.Collections.Generic;
using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Dominio.Interfaces.Repositorio;
using System.Linq;

namespace TBP.Blog.Infra.Data.Repositorios
{
    public class PostRepositorio : BaseRepositorio<Post>, IPostRepositorio
    {
        public override IEnumerable<Post> ListAllByUser(string username)
        {
            var lista = DbSet.Where(i => i.UserId == username);
            return lista;
        }

        public IEnumerable<Post> ListAllByUser(string username, int indexPagina, int qtddPorPagina)
        {
            var index = indexPagina - 1;

            var vistos = (index * qtddPorPagina);
            var todos = ListAllByUser(username)
                .Skip(vistos)
                .Take(qtddPorPagina);

            return todos;
        }

        public IEnumerable<Post> GetByTagName(string username, string tag)
        {
            //TODO 1: Verificar como melhorar essa consulta
            var este =
                Contexto.Tags.FirstOrDefault(i => i.UserId.Equals(username) && i.Nome.ToLower().Equals(tag.ToLower()));

            return este != null ?
                este.Posts :
                new List<Post>();

        }
    }
}