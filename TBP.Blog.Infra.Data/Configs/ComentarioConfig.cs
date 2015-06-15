using System.Data.Entity.ModelConfiguration;
using TBP.Blog.Dominio.Entidades;

namespace TBP.Blog.Infra.Data.Configs
{
    public class ComentarioConfig : EntityTypeConfiguration<Comentario>
    {
        public ComentarioConfig()
        {
            HasKey(i => i.IdComentario);
            ToTable("Comentarios");

            Ignore(i => i.ResultadoValidacao);
        }

    }
}