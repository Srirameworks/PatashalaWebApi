namespace Patashala_Web_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JWT : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthModels",
                c => new
                    {
                        AuthId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        AppToken = c.String(nullable: false, maxLength: 32),
                        AppSecret = c.String(nullable: false, maxLength: 32),
                        TokenExpiration = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AuthId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AuthModels");
        }
    }
}
