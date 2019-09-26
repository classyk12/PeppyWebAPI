namespace PeppyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedRatinModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.AppRatings");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AppRatings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        UI = c.Int(nullable: false),
                        Responsiveness = c.Int(nullable: false),
                        Navigation = c.Int(nullable: false),
                        UX = c.Int(nullable: false),
                        Overall = c.Int(nullable: false),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
