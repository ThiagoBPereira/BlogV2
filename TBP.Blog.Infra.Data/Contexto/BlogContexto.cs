using System.Data.Entity;
using TBP.Blog.Dominio.Entidades;
using TBP.Blog.Infra.Data.Configs;

namespace TBP.Blog.Infra.Data.Contexto
{
    public class BlogContexto : DbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        public BlogContexto()
            : base("BlogConnectionString")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Setar Propriedades do tipo string como Varchar(Max), caso não tenha configuração Pré estabelecida
            modelBuilder.Properties<string>()
                .Configure(i => i.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(i => i.IsMaxLength());

            modelBuilder.Configurations.Add(new PostConfig());
            modelBuilder.Configurations.Add(new TagConfig());
            modelBuilder.Configurations.Add(new ComentarioConfig());

        }
    }
}