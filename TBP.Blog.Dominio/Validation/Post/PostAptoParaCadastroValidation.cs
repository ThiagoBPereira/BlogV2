using TBP.Blog.Dominio.Specification.Post;
using TBP.Blog.Dominio.Validation.Base.ProjetoModelo.Domain.Validation.Base;

namespace TBP.Blog.Dominio.Validation.Post
{
    public class PostAptoParaCadastroValidation : FiscalBase<Entidades.Post>
    {
        public PostAptoParaCadastroValidation()
        {
            var tituloNaoNulo = new PostComTituloValidoSpecification();
            var corpoNaoNulo = new PostComCorpoValidoSpecification();
            var dataValida = new PostComDataValidaSpecification();
            var pertencerAUmUsuario = new PostComUsuarioValidoSpecification();

            AdicionarRegra("TituloNaoValido", new Regra<Entidades.Post>(tituloNaoNulo, "Título não foi preenchido corretamente"));
            AdicionarRegra("CorpoNaoNulo", new Regra<Entidades.Post>(corpoNaoNulo, "A postagem não foi preenchida corretamente"));
            AdicionarRegra("DataValida", new Regra<Entidades.Post>(dataValida, "Ocorreu um erro ao inserir a data de postagem"));
            AdicionarRegra("PertencerAUmUsuario", new Regra<Entidades.Post>(pertencerAUmUsuario, "A postagem não está ligada a um usuário"));
        }

    }
}
