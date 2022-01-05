namespace Infraestructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class montocheque : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cheques", "Monto", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cheques", "Monto");
        }
    }
}
