namespace PeppyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChnagedDateTimeToStringInBookingsMoodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "StartDate", c => c.String(nullable: false));
            AlterColumn("dbo.Bookings", "EndDate", c => c.String());
            AlterColumn("dbo.Bookings", "ServiceTime", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "ServiceTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Bookings", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Bookings", "StartDate", c => c.DateTime(nullable: false));
        }
    }
}
