namespace finalJEMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class quitarForanea : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Servicios", "ProveedorIdProveedor", "dbo.Proveedors");
            DropIndex("dbo.Servicios", new[] { "ProveedorIdProveedor" });
            DropColumn("dbo.Servicios", "ProveedorIdProveedor");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Servicios", "ProveedorIdProveedor", c => c.Int(nullable: false));
            CreateIndex("dbo.Servicios", "ProveedorIdProveedor");
            AddForeignKey("dbo.Servicios", "ProveedorIdProveedor", "dbo.Proveedors", "IdProveedor", cascadeDelete: true);
        }
    }
}
