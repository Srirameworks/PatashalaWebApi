namespace Patashala_Web_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HouseNo = c.String(nullable: false, maxLength: 20),
                        Area = c.String(nullable: false, maxLength: 50),
                        Village = c.String(nullable: false, maxLength: 50),
                        Mandel = c.String(nullable: false, maxLength: 50),
                        District = c.String(nullable: false, maxLength: 50),
                        State = c.String(nullable: false, maxLength: 50),
                        PIN = c.String(nullable: false, maxLength: 6),
                        Administrative_Id = c.Int(),
                        Students_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Administratives", t => t.Administrative_Id)
                .ForeignKey("dbo.Students", t => t.Students_Id)
                .Index(t => t.Administrative_Id)
                .Index(t => t.Students_Id);
            
            CreateTable(
                "dbo.Administratives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DOJ = c.DateTime(nullable: false),
                        AdministrativeRoll = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DOB = c.DateTime(nullable: false),
                        IdentityNumber = c.String(nullable: false, maxLength: 30),
                        IdentityType = c.Int(nullable: false),
                        IsSameAddress = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectName = c.String(nullable: false, maxLength: 50),
                        Teachers_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Administratives", t => t.Teachers_Id)
                .Index(t => t.Teachers_Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DOE = c.DateTime(nullable: false),
                        Class = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        DOB = c.DateTime(nullable: false),
                        IdentityNumber = c.String(nullable: false, maxLength: 30),
                        IdentityType = c.Int(nullable: false),
                        IsSameAddress = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Students_Id", "dbo.Students");
            DropForeignKey("dbo.Subjects", "Teachers_Id", "dbo.Administratives");
            DropForeignKey("dbo.Addresses", "Administrative_Id", "dbo.Administratives");
            DropIndex("dbo.Subjects", new[] { "Teachers_Id" });
            DropIndex("dbo.Addresses", new[] { "Students_Id" });
            DropIndex("dbo.Addresses", new[] { "Administrative_Id" });
            DropTable("dbo.Students");
            DropTable("dbo.Subjects");
            DropTable("dbo.Administratives");
            DropTable("dbo.Addresses");
        }
    }
}
