namespace PeppyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOfferTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Offers", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Offers", "Title");
        }
    }
}
