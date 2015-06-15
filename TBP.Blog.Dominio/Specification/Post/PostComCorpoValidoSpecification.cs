using TBP.Blog.Dominio.Interfaces.Specification;

namespace TBP.Blog.Dominio.Specification.Post
{
    public class PostComCorpoValidoSpecification : ISpecification<Entidades.Post>
    {
        public bool IsSatisfiedBy(Entidades.Post entity)
        {
            return (entity.Corpo.Length > 3);
        }
    }
}