namespace FinalProgIII.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nose : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ViewModelFacturas",
                c => new
                    {
                        VentaID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.VentaID);
            
            AddColumn("dbo.Productoes", "Factura_FacturaID", c => c.Int());
            AddColumn("dbo.Facturas", "EmailCliente", c => c.String());
            AddColumn("dbo.Facturas", "Clientes_ClientesID", c => c.Int());
            CreateIndex("dbo.Productoes", "Factura_FacturaID");
            CreateIndex("dbo.Facturas", "Clientes_ClientesID");
            AddForeignKey("dbo.Facturas", "Clientes_ClientesID", "dbo.Clientes", "ClientesID");
            AddForeignKey("dbo.Productoes", "Factura_FacturaID", "dbo.Facturas", "FacturaID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productoes", "Factura_FacturaID", "dbo.Facturas");
            DropForeignKey("dbo.Facturas", "Clientes_ClientesID", "dbo.Clientes");
            DropIndex("dbo.Facturas", new[] { "Clientes_ClientesID" });
            DropIndex("dbo.Productoes", new[] { "Factura_FacturaID" });
            DropColumn("dbo.Facturas", "Clientes_ClientesID");
            DropColumn("dbo.Facturas", "EmailCliente");
            DropColumn("dbo.Productoes", "Factura_FacturaID");
            DropTable("dbo.ViewModelFacturas");
        }
    }
}
