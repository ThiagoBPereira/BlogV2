using System;
using TBP.Blog.Dominio.Interfaces.Specification;

namespace TBP.Blog.Dominio.Specification.Post
{
    public class PostComDataValida : ISpecification<Entidades.Post>
    {
        public bool IsSatisfiedBy(Entidades.Post entity)
        {
            return (entity.DataPostagem != DateTime.MinValue);
        }
    }
}