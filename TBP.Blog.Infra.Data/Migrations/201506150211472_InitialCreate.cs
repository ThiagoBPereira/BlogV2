namespace TBP.Blog.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comentarios",
                c => new
                    {
                        IdComentario = c.Guid(nullable: false),
                        Nome = c.String(maxLength: 8000, unicode: false),
                        Email = c.String(maxLength: 8000, unicode: false),
                        DataComentario = c.DateTime(nullable: false),
                        IdPost = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.IdComentario)
                .ForeignKey("dbo.Posts", t => t.IdPost, cascadeDelete: true)
                .Index(t => t.IdPost);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        IdPost = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 8000, unicode: false),
                        Titulo = c.String(maxLength: 8000, unicode: false),
                        Corpo = c.String(maxLength: 8000, unicode: false),
                        DataPostagem = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IdPost);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        IdTag = c.Guid(nullable: false),
                        UserId = c.String(maxLength: 8000, unicode: false),
                        Nome = c.String(maxLength: 8000, unicode: false),
                    })
                .PrimaryKey(t => t.IdTag);
            
            CreateTable(
                "dbo.TagsDosPosts",
                c => new
                    {
                        IdTags = c.Guid(nullable: false),
                        IdPosts = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdTags, t.IdPosts })
                .ForeignKey("dbo.Posts", t => t.IdTags, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.IdPosts, cascadeDelete: true)
                .Index(t => t.IdTags)
                .Index(t => t.IdPosts);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagsDosPosts", "IdPosts", "dbo.Tags");
            DropForeignKey("dbo.TagsDosPosts", "IdTags", "dbo.Posts");
            DropForeignKey("dbo.Comentarios", "IdPost", "dbo.Posts");
            DropIndex("dbo.TagsDosPosts", new[] { "IdPosts" });
            DropIndex("dbo.TagsDosPosts", new[] { "IdTags" });
            DropIndex("dbo.Comentarios", new[] { "IdPost" });
            DropTable("dbo.TagsDosPosts");
            DropTable("dbo.Tags");
            DropTable("dbo.Posts");
            DropTable("dbo.Comentarios");
        }
    }
}
