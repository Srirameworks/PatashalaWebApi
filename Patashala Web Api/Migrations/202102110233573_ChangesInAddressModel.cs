namespace Patashala_Web_Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangesInAddressModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Addresses", "IsContactAddress", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Addresses", "IsContactAddress");
        }
    }
}
