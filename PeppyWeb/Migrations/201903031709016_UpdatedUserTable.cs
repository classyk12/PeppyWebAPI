namespace PeppyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Alias", c => c.String());
            AddColumn("dbo.AspNetUsers", "DateJoined", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DateJoined");
            DropColumn("dbo.AspNetUsers", "Alias");
        }
    }
}
