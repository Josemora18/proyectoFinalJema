namespace finalJEMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nosequehacerya : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Asistentes",
                c => new
                    {
                        IdAsistente = c.Int(nullable: false, identity: true),
                        nomAsistente = c.String(),
                        apeAsistente = c.String(),
                        telAsistente = c.String(),
                    })
                .PrimaryKey(t => t.IdAsistente);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        idFactura = c.Int(nullable: false, identity: true),
                        fecha = c.DateTime(nullable: false),
                        ProveedorIdProveedor = c.Int(nullable: false),
                        ServicioIdServicio = c.Int(nullable: false),
                        AsistenteIdAsistente = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.idFactura)
                .ForeignKey("dbo.Asistentes", t => t.AsistenteIdAsistente, cascadeDelete: true)
                .ForeignKey("dbo.Proveedors", t => t.ProveedorIdProveedor, cascadeDelete: true)
                .ForeignKey("dbo.Servicios", t => t.ServicioIdServicio, cascadeDelete: true)
                .Index(t => t.ProveedorIdProveedor)
                .Index(t => t.ServicioIdServicio)
                .Index(t => t.AsistenteIdAsistente);
            
            CreateTable(
                "dbo.cuentaProveedors",
                c => new
                    {
                        IdCuenta = c.Int(nullable: false, identity: true),
                        usuario = c.String(),
                        contraseña = c.String(),
                    })
                .PrimaryKey(t => t.IdCuenta);
            
            CreateTable(
                "dbo.Proveedors",
                c => new
                    {
                        IdProveedor = c.Int(nullable: false, identity: true),
                        NombreProveedor = c.String(),
                        Direccion = c.String(),
                        Giro = c.String(),
                    })
                .PrimaryKey(t => t.IdProveedor);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        IdServicio = c.Int(nullable: false, identity: true),
                        nomServicio = c.String(),
                        precio = c.Single(nullable: false),
                        Proveedor_IdProveedor = c.Int(),
                    })
                .PrimaryKey(t => t.IdServicio)
                .ForeignKey("dbo.Proveedors", t => t.Proveedor_IdProveedor)
                .Index(t => t.Proveedor_IdProveedor);
            
            DropTable("dbo.EjemploProyectoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EjemploProyectoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.Servicios", "Proveedor_IdProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.Facturas", "ServicioIdServicio", "dbo.Servicios");
            DropForeignKey("dbo.Facturas", "ProveedorIdProveedor", "dbo.Proveedors");
            DropForeignKey("dbo.Facturas", "AsistenteIdAsistente", "dbo.Asistentes");
            DropIndex("dbo.Servicios", new[] { "Proveedor_IdProveedor" });
            DropIndex("dbo.Facturas", new[] { "AsistenteIdAsistente" });
            DropIndex("dbo.Facturas", new[] { "ServicioIdServicio" });
            DropIndex("dbo.Facturas", new[] { "ProveedorIdProveedor" });
            DropTable("dbo.Servicios");
            DropTable("dbo.Proveedors");
            DropTable("dbo.cuentaProveedors");
            DropTable("dbo.Facturas");
            DropTable("dbo.Asistentes");
        }
    }
}
