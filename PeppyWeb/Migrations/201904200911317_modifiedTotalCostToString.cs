namespace PeppyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifiedTotalCostToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "TotalCost", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "TotalCost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
