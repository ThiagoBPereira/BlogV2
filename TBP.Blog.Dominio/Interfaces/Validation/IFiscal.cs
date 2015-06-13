

using TBP.Blog.Dominio.ValueObjects;

namespace TBP.Blog.Dominio.Interfaces.Validation
{
    public interface IFiscal<in TEntity>
    {
        ValidationResult Validar(TEntity entity);
    }
}
