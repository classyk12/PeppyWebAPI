namespace PeppyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedCleanerAndBookingTableFinal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "CleanerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bookings", "CleanerId");
            AddForeignKey("dbo.Bookings", "CleanerId", "dbo.Cleaners", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "CleanerId", "dbo.Cleaners");
            DropIndex("dbo.Bookings", new[] { "CleanerId" });
            DropColumn("dbo.Bookings", "CleanerId");
        }
    }
}
