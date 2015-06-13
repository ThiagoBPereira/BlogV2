using TBP.Blog.Dominio.Specification.Post;
using TBP.Blog.Dominio.Validation.Base.ProjetoModelo.Domain.Validation.Base;

namespace TBP.Blog.Dominio.Validation.Post
{
    public class PostAptoParaCadastro : FiscalBase<Entidades.Post>
    {
        public PostAptoParaCadastro()
        {
            var tituloNaoNulo = new PostComTituloValido();
            var corpoNaoNulo = new PostComCorpoValido();
            var dataValida = new PostComDataValida();
            var pertencerAUmUsuario = new PostComUsuarioValido();

            AdicionarRegra("TituloNaoValido", new Regra<Entidades.Post>(tituloNaoNulo, "Título não foi preenchido corretamente"));
            AdicionarRegra("CorpoNaoNulo", new Regra<Entidades.Post>(corpoNaoNulo, "A postagem não foi preenchida corretamente"));
            AdicionarRegra("DataValida", new Regra<Entidades.Post>(dataValida, "Ocorreu um erro ao inserir a data de postagem"));
            AdicionarRegra("PertencerAUmUsuario", new Regra<Entidades.Post>(pertencerAUmUsuario, "A postagem não está ligada a um usuário"));
        }
    }
}
