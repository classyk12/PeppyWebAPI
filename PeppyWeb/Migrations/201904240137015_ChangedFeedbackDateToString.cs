namespace PeppyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedFeedbackDateToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Feedbacks", "DateAdded", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Feedbacks", "DateAdded", c => c.DateTime(nullable: false));
        }
    }
}
