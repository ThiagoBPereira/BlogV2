using System.Collections.Generic;
using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Dominio.Interfaces.Repositorio;
using TBP.Blog.Dominio.Interfaces.Servicos;

namespace TBP.Blog.Dominio.Servicos
{
    public class PostService : BaseService<Post>, IPostService
    {
        private readonly IPostRepositorio _repositorio;

        public PostService(IPostRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }


        public IEnumerable<Post> ListAllByUser(string username, int indexPagina, int qtddPorPagina)
        {
            return _repositorio.ListAllByUser(username, indexPagina, qtddPorPagina);
        }

        public IEnumerable<Post> GetByTagName(string username, string tag)
        {
            return _repositorio.GetByTagName(username, tag);
        }
    }
}