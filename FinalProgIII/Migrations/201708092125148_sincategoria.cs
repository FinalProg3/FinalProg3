namespace FinalProgIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sincategoria : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productoes", "Categoria_CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Productoes", new[] { "Categoria_CategoriaID" });
            DropColumn("dbo.Productoes", "Categoria_CategoriaID");
            DropTable("dbo.Categorias");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            AddColumn("dbo.Productoes", "Categoria_CategoriaID", c => c.Int());
            CreateIndex("dbo.Productoes", "Categoria_CategoriaID");
            AddForeignKey("dbo.Productoes", "Categoria_CategoriaID", "dbo.Categorias", "CategoriaID");
        }
    }
}
