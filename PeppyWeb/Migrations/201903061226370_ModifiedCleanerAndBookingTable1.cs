namespace PeppyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedCleanerAndBookingTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            AlterColumn("dbo.Feedbacks", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Feedbacks", "UserId");
            AddForeignKey("dbo.Feedbacks", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            AlterColumn("dbo.Feedbacks", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Feedbacks", "UserId");
            AddForeignKey("dbo.Feedbacks", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
