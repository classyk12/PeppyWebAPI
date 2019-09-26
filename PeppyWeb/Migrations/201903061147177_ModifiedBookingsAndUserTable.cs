namespace PeppyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedBookingsAndUserTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            AddColumn("dbo.Bookings", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Bookings", "UserId");
            AddForeignKey("dbo.Bookings", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            DropColumn("dbo.Feedbacks", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Feedbacks", "UserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Bookings", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Bookings", new[] { "UserId" });
            DropColumn("dbo.Bookings", "UserId");
            CreateIndex("dbo.Feedbacks", "UserId");
            AddForeignKey("dbo.Feedbacks", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
