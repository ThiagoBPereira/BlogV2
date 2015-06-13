using System;

namespace TBP.Blog.Dominio.Entidades
{
    public class Comentario
    {
        public Comentario()
        {
            IdComentario = Guid.NewGuid();
        }

        public Guid IdComentario { get; set; }
        public string Nome { get; set; }
        public DateTime DataComentario { get; set; }
        public Post Post { get; set; }
        public Guid IdPost { get; set; }

    }
}
