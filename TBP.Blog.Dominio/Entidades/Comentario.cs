using System;
using TBP.Blog.Dominio.Interfaces.Validation;
using TBP.Blog.Dominio.Validation.Comentario;
using TBP.Blog.Dominio.ValueObjects;

namespace TBP.Blog.Dominio.Entidades
{
    public class Comentario : ISelfValidator
    {
        public Comentario()
        {
            IdComentario = Guid.NewGuid();
            DataComentario = DateTime.Now;
        }

        public Guid IdComentario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataComentario { get; set; }
        public Post Post { get; set; }
        public Guid IdPost { get; set; }

        public ValidationResult ResultadoValidacao { get; private set; }

        public bool IsValid()
        {
            var validacao = new ComentarioAptoParaCadastro();

            var fiscalizar = validacao.Validar(this);

            return fiscalizar.IsValid;
        }
    }
}
