using TBP.Blog.Dominio.Interfaces.Specification;

namespace TBP.Blog.Dominio.Specification.Tag
{
    public class TagComNomeValidoSpecification : ISpecification<Entidades.Tag>
    {
        public bool IsSatisfiedBy(Entidades.Tag entity)
        {
            return entity.Nome.Length >= 3;
        }
    }
}