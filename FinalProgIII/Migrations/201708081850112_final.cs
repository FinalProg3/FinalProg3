namespace FinalProgIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientes",
                c => new
                    {
                        ClientesID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        Email = c.String(),
                        Telefono = c.String(),
                    })
                .PrimaryKey(t => t.ClientesID);
            
            CreateTable(
                "dbo.Productoes",
                c => new
                    {
                        ProductoID = c.Int(nullable: false, identity: true),
                        ProveedorID = c.Int(nullable: false),
                        Nombre = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Int(nullable: false),
                        FechaPedido = c.DateTime(nullable: false),
                        Disponibilidad = c.Boolean(nullable: false),
                        FotoPROD = c.String(),
                    })
                .PrimaryKey(t => t.ProductoID)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorID, cascadeDelete: true)
                .Index(t => t.ProveedorID);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        ProveedorID = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Direccion = c.String(),
                        Telefono = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProveedorID);
            
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        VentaID = c.Int(nullable: false, identity: true),
                        ClienteID = c.Int(nullable: false),
                        ProductoID = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        PrecioTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.VentaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "ProveedorID", "dbo.Proveedors");
            DropIndex("dbo.Productoes", new[] { "ProveedorID" });
            DropTable("dbo.Ventas");
            DropTable("dbo.Proveedors");
            DropTable("dbo.Productoes");
            DropTable("dbo.Clientes");
        }
    }
}
