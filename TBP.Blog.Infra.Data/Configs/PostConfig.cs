using System.Data.Entity.ModelConfiguration;
using TBP.Blog.Dominio.Entidades;

namespace TBP.Blog.Infra.Data.Configs
{
    public class PostConfig : EntityTypeConfiguration<Post>
    {
        public PostConfig()
        {
            HasKey(i => i.IdPost);
            ToTable("Posts");

            HasMany(i => i.Tags)
                .WithMany(i => i.Posts)
                .Map(i =>
                    i.MapLeftKey("IdTags")
                        .MapRightKey("IdPosts")
                        .ToTable("TagsDosPosts")
                );

            HasMany(i => i.Comentarios)
                .WithRequired(i => i.Post)
                .HasForeignKey(i => i.IdPost);

            Ignore(i => i.ResultadoValidacao);

        }

    }
}