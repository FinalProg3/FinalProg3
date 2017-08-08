namespace FinalProgIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reajust2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ventas", "FechaPedido", c => c.DateTime(nullable: false));
            DropColumn("dbo.Productoes", "FechaPedido");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productoes", "FechaPedido", c => c.DateTime(nullable: false));
            DropColumn("dbo.Ventas", "FechaPedido");
        }
    }
}
