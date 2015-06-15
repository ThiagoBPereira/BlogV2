using TBP.Blog.Dominio.Specification.Comentario;
using TBP.Blog.Dominio.Validation.Base.ProjetoModelo.Domain.Validation.Base;

namespace TBP.Blog.Dominio.Validation.Comentario
{
    public class ComentarioAptoParaCadastro : FiscalBase<Entidades.Comentario>
    {
        public ComentarioAptoParaCadastro()
        {
            var validacaoDeNome = new ComentarioNomeValidoSpecification();
            var relacionadoAPost = new ComentarioRelacionadoAoPostSpecification();
            var dataValida = new ComentarioComDataValidaPostSpecification();

            //TODO 5: Criar verificação de email válido

            AdicionarRegra("ValidacaoDeNome", new Regra<Entidades.Comentario>(validacaoDeNome, "Preencha o seu nome corretamente."));
            AdicionarRegra("RelacionadoAPost", new Regra<Entidades.Comentario>(relacionadoAPost, "O comentário não está relacionado a nenhuma postagem."));
            AdicionarRegra("DataValida", new Regra<Entidades.Comentario>(dataValida, "A data do seu comentário, não confere."));
        }

    }
}
