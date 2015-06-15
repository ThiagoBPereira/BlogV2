using TBP.Blog.Dominio.Interfaces.Specification;

namespace TBP.Blog.Dominio.Specification.Comentario
{
    public class ComentarioNomeValidoSpecification : ISpecification<Entidades.Comentario>
    {
        public bool IsSatisfiedBy(Entidades.Comentario entity)
        {
            return (entity.Nome.Length >= 3);
        }
    }
}