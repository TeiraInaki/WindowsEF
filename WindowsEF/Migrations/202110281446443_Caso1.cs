namespace WindowsEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Caso1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Especialidads",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Medicos", "EspecialidadId", c => c.Int(nullable: false));
            CreateIndex("dbo.Medicos", "EspecialidadId");
            AddForeignKey("dbo.Medicos", "EspecialidadId", "dbo.Especialidads", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Medicos", "EspecialidadId", "dbo.Especialidads");
            DropIndex("dbo.Medicos", new[] { "EspecialidadId" });
            DropColumn("dbo.Medicos", "EspecialidadId");
            DropTable("dbo.Especialidads");
        }
    }
}
