namespace finalJEMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EjemploProyecto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EjemploProyectoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EjemploProyectoes");
        }
    }
}
