using System.Collections.Generic;
using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Dominio.Interfaces.Repositorio;
using TBP.Blog.Dominio.Interfaces.Servicos;

namespace TBP.Blog.Dominio.Servicos
{
    public class TagService : BaseService<Tag>, ITagService
    {
        private readonly ITagRepositorio _repositorio;

        public TagService(ITagRepositorio repositorio)
            : base(repositorio)
        {
            _repositorio = repositorio;
        }

        public IEnumerable<Tag> GetByName(string username, string nome)
        {
            return _repositorio.GetByName(username, nome);

        }
    }
}
