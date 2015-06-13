using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Dominio.Interfaces.Repositorio;
using TBP.Blog.Dominio.Interfaces.Servicos;

namespace TBP.Blog.Dominio.Servicos
{
    public class ComentarioService : BaseService<Comentario>, IComentarioService
    {
        private readonly IComentarioRepositorio _repositorio;

        public ComentarioService(IComentarioRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }


    }
}