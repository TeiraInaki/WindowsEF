namespace WindowsEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Clinicas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clinicas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        FechaInicioActividades = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Habitacions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Numero = c.Int(nullable: false),
                        Estado = c.String(nullable: false, maxLength: 12, unicode: false),
                        ClinicaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clinicas", t => t.ClinicaId, cascadeDelete: true)
                .Index(t => t.ClinicaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Habitacions", "ClinicaId", "dbo.Clinicas");
            DropIndex("dbo.Habitacions", new[] { "ClinicaId" });
            DropTable("dbo.Habitacions");
            DropTable("dbo.Clinicas");
        }
    }
}
