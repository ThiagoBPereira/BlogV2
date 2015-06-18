using System;
using TBP.Blog.Dominio.Interfaces.Specification;

namespace TBP.Blog.Dominio.Specification.Comentario
{
    public class ComentarioComDataValidaPostSpecification : ISpecification<Entidades.Comentario>
    {
        public bool IsSatisfiedBy(Entidades.Comentario entity)
        {
            return (entity.DataComentario > DateTime.MinValue);
        }
    }
}