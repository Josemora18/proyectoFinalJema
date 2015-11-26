namespace finalJEMA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nosequehacer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Facturas", "fecha", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Facturas", "fecha");
        }
    }
}
