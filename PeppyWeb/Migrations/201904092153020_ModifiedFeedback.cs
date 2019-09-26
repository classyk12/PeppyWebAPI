namespace PeppyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedFeedback : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "username", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Feedbacks", "username");
        }
    }
}
