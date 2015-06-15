using TBP.Blog.Dominio.Interfaces.Repositorio;
using TBP.Blog.Dominio.Specification.Tag;
using TBP.Blog.Dominio.Validation.Base.ProjetoModelo.Domain.Validation.Base;

namespace TBP.Blog.Dominio.Validation.Tag
{
    public class TagAptaParaCadastroValidation : FiscalBase<Entidades.Tag>
    {
        private ITagRepositorio _itagRepositorio;

        public TagAptaParaCadastroValidation(ITagRepositorio itagRepositorio)
        {
            _itagRepositorio = itagRepositorio;

            var tagComNomeValido = new TagEhUnicaSpecification(itagRepositorio);

            AdicionarRegra("TagComNomeValido", new Regra<Entidades.Tag>(tagComNomeValido, "A tag não está com o nome válido."));
        }
    }
}