namespace WindowsEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambiosEnPaciente : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Pacientes", newName: "Paciente");
            AlterColumn("dbo.Paciente", "Nombre", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Paciente", "Apellido", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.Paciente", "FechaNacimiento", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Paciente", "FechaNacimiento", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Paciente", "Apellido", c => c.String());
            AlterColumn("dbo.Paciente", "Nombre", c => c.String());
            RenameTable(name: "dbo.Paciente", newName: "Pacientes");
        }
    }
}
