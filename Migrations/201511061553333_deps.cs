namespace Ejercicio1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departamentoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Empleadoes", "Departamento_id", c => c.Int());
            CreateIndex("dbo.Empleadoes", "Departamento_id");
            AddForeignKey("dbo.Empleadoes", "Departamento_id", "dbo.Departamentoes", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleadoes", "Departamento_id", "dbo.Departamentoes");
            DropIndex("dbo.Empleadoes", new[] { "Departamento_id" });
            DropColumn("dbo.Empleadoes", "Departamento_id");
            DropTable("dbo.Departamentoes");
        }
    }
}
