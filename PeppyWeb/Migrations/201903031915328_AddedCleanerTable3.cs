namespace PeppyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCleanerTable3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cleaners", "ImagePath", c => c.String());
            DropColumn("dbo.Cleaners", "ImageUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cleaners", "ImageUrl", c => c.String());
            DropColumn("dbo.Cleaners", "ImagePath");
        }
    }
}
