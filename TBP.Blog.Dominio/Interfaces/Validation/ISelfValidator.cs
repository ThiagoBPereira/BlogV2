using TBP.Blog.Dominio.ValueObjects;

namespace TBP.Blog.Dominio.Interfaces.Validation
{
    public interface ISelfValidator
    {
        ValidationResult ResultadoValidacao { get; }
        bool IsValid();
    }
}