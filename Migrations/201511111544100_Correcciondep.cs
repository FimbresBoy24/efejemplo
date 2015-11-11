namespace Ejercicio1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Correcciondep : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Empleadoes", "Departamento_id", "dbo.Departamentoes");
            DropIndex("dbo.Empleadoes", new[] { "Departamento_id" });
            RenameColumn(table: "dbo.Empleadoes", name: "Departamento_id", newName: "DepartamentoId");
            AlterColumn("dbo.Empleadoes", "DepartamentoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Empleadoes", "DepartamentoId");
            AddForeignKey("dbo.Empleadoes", "DepartamentoId", "dbo.Departamentoes", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Empleadoes", "DepartamentoId", "dbo.Departamentoes");
            DropIndex("dbo.Empleadoes", new[] { "DepartamentoId" });
            AlterColumn("dbo.Empleadoes", "DepartamentoId", c => c.Int());
            RenameColumn(table: "dbo.Empleadoes", name: "DepartamentoId", newName: "Departamento_id");
            CreateIndex("dbo.Empleadoes", "Departamento_id");
            AddForeignKey("dbo.Empleadoes", "Departamento_id", "dbo.Departamentoes", "id");
        }
    }
}
