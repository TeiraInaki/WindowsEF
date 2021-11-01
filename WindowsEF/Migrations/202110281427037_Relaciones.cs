namespace WindowsEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Relaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        MedicoId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Apellido = c.String(),
                        Matricula = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MedicoId);
            
            AddColumn("dbo.Paciente", "MedicoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Paciente", "MedicoId");
            AddForeignKey("dbo.Paciente", "MedicoId", "dbo.Medicos", "MedicoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paciente", "MedicoId", "dbo.Medicos");
            DropIndex("dbo.Paciente", new[] { "MedicoId" });
            DropColumn("dbo.Paciente", "MedicoId");
            DropTable("dbo.Medicos");
        }
    }
}
