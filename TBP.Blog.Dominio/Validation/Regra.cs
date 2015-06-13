using TBP.Blog.Dominio.Interfaces.Specification;
using TBP.Blog.Dominio.Interfaces.Validation;

namespace TBP.Blog.Dominio.Validation
{
    public class Regra<TEntity> : IRegra<TEntity>
    {
        private readonly ISpecification<TEntity> _specificationRule;
        public string MensagemErro { get; private set; }

        public Regra(ISpecification<TEntity> rule, string mensagemErro)
        {
            _specificationRule = rule;
            MensagemErro = mensagemErro;
        }

        public bool Validar(TEntity entity)
        {
            return _specificationRule.IsSatisfiedBy(entity);
        }
    }
}
