namespace Infraestructura.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class conceptogastos : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ConceptoGastos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gastos",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        ConceptoGastoId = c.Long(nullable: false),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 400, unicode: false),
                        Monto = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EstaEliminado = c.Boolean(nullable: false),
                        RowVersion = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ConceptoGastos", t => t.ConceptoGastoId)
                .Index(t => t.ConceptoGastoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gastos", "ConceptoGastoId", "dbo.ConceptoGastos");
            DropIndex("dbo.Gastos", new[] { "ConceptoGastoId" });
            DropTable("dbo.Gastos");
            DropTable("dbo.ConceptoGastos");
        }
    }
}
