namespace FinalProgIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class categoria : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaID);
            
            AddColumn("dbo.Productoes", "Categoria_CategoriaID", c => c.Int());
            CreateIndex("dbo.Productoes", "Categoria_CategoriaID");
            AddForeignKey("dbo.Productoes", "Categoria_CategoriaID", "dbo.Categorias", "CategoriaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "Categoria_CategoriaID", "dbo.Categorias");
            DropIndex("dbo.Productoes", new[] { "Categoria_CategoriaID" });
            DropColumn("dbo.Productoes", "Categoria_CategoriaID");
            DropTable("dbo.Categorias");
        }
    }
}
