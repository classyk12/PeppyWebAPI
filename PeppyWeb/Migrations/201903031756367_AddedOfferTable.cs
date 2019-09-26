namespace PeppyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedOfferTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ImagePath = c.String(),
                        ExpiryDate = c.DateTime(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Offers");
        }
    }
}
