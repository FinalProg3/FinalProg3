namespace FinalProgIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reajust3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        FacturaID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        ProductoID = c.Int(nullable: false),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.FacturaID);
            
            DropColumn("dbo.Categorias", "Descripcion");
            DropColumn("dbo.Proveedors", "Direccion");
            DropColumn("dbo.Proveedors", "Telefono");
            DropTable("dbo.Ventas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        VentaID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        ProductoID = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        FechaPedido = c.DateTime(nullable: false),
                        PrecioTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.VentaID);
            
            AddColumn("dbo.Proveedors", "Telefono", c => c.String());
            AddColumn("dbo.Proveedors", "Direccion", c => c.String());
            AddColumn("dbo.Categorias", "Descripcion", c => c.String());
            DropTable("dbo.Facturas");
        }
    }
}
