using System.Runtime.InteropServices;
using TBP.Blog.Dominio.Specification.Tag;
using TBP.Blog.Dominio.Validation.Base.ProjetoModelo.Domain.Validation.Base;

namespace TBP.Blog.Dominio.Validation.Tag
{
    public class TagDevidamentePreenchidaValidation : FiscalBase<Entidades.Tag>
    {
        public TagDevidamentePreenchidaValidation()
        {
            var tagComNomeValido = new TagComNomeValidoSpecification();

            AdicionarRegra("TagComNomeValido", new Regra<Entidades.Tag>(tagComNomeValido, "A tag não está com o nome válido."));
        }
    }
}
