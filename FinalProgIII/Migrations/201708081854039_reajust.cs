namespace FinalProgIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reajust : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Productoes", "Cantidad");
            DropColumn("dbo.Proveedors", "Precio");
            DropColumn("dbo.Proveedors", "Cantidad");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Proveedors", "Cantidad", c => c.Int(nullable: false));
            AddColumn("dbo.Proveedors", "Precio", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Productoes", "Cantidad", c => c.Int(nullable: false));
        }
    }
}
