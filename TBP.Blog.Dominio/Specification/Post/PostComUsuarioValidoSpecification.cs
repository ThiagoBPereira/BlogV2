using TBP.Blog.Dominio.Interfaces.Specification;

namespace TBP.Blog.Dominio.Specification.Post
{
    public class PostComUsuarioValidoSpecification : ISpecification<Entidades.Post>
    {
        public bool IsSatisfiedBy(Entidades.Post entity)
        {
            return !string.IsNullOrEmpty(entity.UserId);
        }
    }
}