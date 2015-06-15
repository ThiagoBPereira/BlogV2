using System.Linq;
using TBP.Blog.Dominio.Interfaces.Repositorio;
using TBP.Blog.Dominio.Interfaces.Specification;

namespace TBP.Blog.Dominio.Specification.Tag
{
    public class TagEhUnicaSpecification : ISpecification<Entidades.Tag>
    {
        private readonly ITagRepositorio _repTag;
        public TagEhUnicaSpecification(ITagRepositorio repTag)
        {
            _repTag = repTag;
        }

        public bool IsSatisfiedBy(Entidades.Tag entity)
        {
            return !_repTag.ListAllByUser(entity.UserId).Any(i => i.Nome.ToLower().Equals(entity.Nome.ToLower()));
        }
    }
}