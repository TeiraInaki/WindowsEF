namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prueba : DbMigration
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
            
            CreateTable(
                "dbo.Paciente",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                        FechaNacimiento = c.DateTime(nullable: false, storeType: "date"),
                        NroHistoriaClinica = c.Int(nullable: false),
                        MedicoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Medicos", t => t.MedicoId, cascadeDelete: true)
                .Index(t => t.MedicoId);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        MedicoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Matricula = c.Int(nullable: false),
                        EspecialidadId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicoId)
                .ForeignKey("dbo.Especialidads", t => t.EspecialidadId, cascadeDelete: true)
                .Index(t => t.EspecialidadId);
            
            CreateTable(
                "dbo.Especialidads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paciente", "MedicoId", "dbo.Medicos");
            DropForeignKey("dbo.Medicos", "EspecialidadId", "dbo.Especialidads");
            DropForeignKey("dbo.Habitacions", "ClinicaId", "dbo.Clinicas");
            DropIndex("dbo.Medicos", new[] { "EspecialidadId" });
            DropIndex("dbo.Paciente", new[] { "MedicoId" });
            DropIndex("dbo.Habitacions", new[] { "ClinicaId" });
            DropTable("dbo.Especialidads");
            DropTable("dbo.Medicos");
            DropTable("dbo.Paciente");
            DropTable("dbo.Habitacions");
            DropTable("dbo.Clinicas");
        }
    }
}
