using System;
using TBP.Blog.Dominio.Interfaces.Specification;

namespace TBP.Blog.Dominio.Specification.Comentario
{
    public class ComentarioRelacionadoAoPostSpecification : ISpecification<Entidades.Comentario>
    {
        public bool IsSatisfiedBy(Entidades.Comentario entity)
        {
            return (entity.IdPost != Guid.Empty);
        }
    }
}