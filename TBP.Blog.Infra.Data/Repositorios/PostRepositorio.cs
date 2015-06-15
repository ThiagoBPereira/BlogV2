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
            var lista = DbSet.Where(i => i.UserId.ToLower().Equals(username.ToLower())).OrderByDescending(i => i.DataPostagem);
            return lista;
        }
        public IEnumerable<Post> ListAllByUserAndTagName(string username, string tag)
        {
            var lista =
                Contexto.Tags.FirstOrDefault(i => i.UserId.Equals(username) && i.Nome.ToLower().Equals(tag.ToLower()));

            return lista != null ? lista.Posts.OrderByDescending(i => i.DataPostagem).AsEnumerable() : new List<Post>();
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

        public IEnumerable<Post> GetByTagName(string username, string tag, int indexPagina, int qtddPorPagina)
        {
            //TODO 1: Verificar como melhorar essa consulta
            var este = ListAllByUserAndTagName(username, tag);

            var vistos = ((indexPagina - 1) * qtddPorPagina);

            return este.Skip(vistos)
                .Take(qtddPorPagina);

        }

        public int ObterTotalRegistros(string username)
        {
            return ListAllByUser(username).Count();
        }

        public int ObterTotalRegistrosByTag(string username, string tag)
        {
            return ListAllByUserAndTagName(username, tag).Count();
        }
    }
}