
namespace TBP.Blog.Dominio.Interfaces.Specification
{
    public interface ISpecification<in T>
    {
        bool IsSatisfiedBy(T entity);
    }
}
