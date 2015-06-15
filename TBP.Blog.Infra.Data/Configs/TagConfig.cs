using System.Data.Entity.ModelConfiguration;
using TBP.Blog.Dominio.Entidades;

namespace TBP.Blog.Infra.Data.Configs
{
    public class TagConfig : EntityTypeConfiguration<Tag>
    {
        public TagConfig()
        {
            HasKey(i => i.IdTag);
            ToTable("Tags");

            Ignore(i => i.ResultadoValidacao);
        }

    }
}