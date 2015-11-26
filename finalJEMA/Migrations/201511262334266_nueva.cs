namespace finalJEMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nueva : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Servicios", "ProveedorIdProveedor", c => c.Int(nullable: false));
            CreateIndex("dbo.Servicios", "ProveedorIdProveedor");
            AddForeignKey("dbo.Servicios", "ProveedorIdProveedor", "dbo.Proveedors", "IdProveedor", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Servicios", "ProveedorIdProveedor", "dbo.Proveedors");
            DropIndex("dbo.Servicios", new[] { "ProveedorIdProveedor" });
            DropColumn("dbo.Servicios", "ProveedorIdProveedor");
        }
    }
}
