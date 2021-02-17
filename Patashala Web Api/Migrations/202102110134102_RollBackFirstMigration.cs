namespace Patashala_Web_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RollBackFirstMigration : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Administratives", newName: "Teachers");
            RenameColumn(table: "dbo.Addresses", name: "Administrative_Id", newName: "Teachers_Id");
            RenameIndex(table: "dbo.Addresses", name: "IX_Administrative_Id", newName: "IX_Teachers_Id");
            AddColumn("dbo.Teachers", "Salary", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Salary");
            RenameIndex(table: "dbo.Addresses", name: "IX_Teachers_Id", newName: "IX_Administrative_Id");
            RenameColumn(table: "dbo.Addresses", name: "Teachers_Id", newName: "Administrative_Id");
            RenameTable(name: "dbo.Teachers", newName: "Administratives");
        }
    }
}
