namespace TBP.Blog.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SegundaMudanca : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tags", "UserId", c => c.String(maxLength: 8000, unicode: false));
            DropColumn("dbo.Posts", "ResultadoValidacao_Mensagem");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "ResultadoValidacao_Mensagem", c => c.String(maxLength: 8000, unicode: false));
            DropColumn("dbo.Tags", "UserId");
        }
    }
}
