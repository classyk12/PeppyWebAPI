namespace PeppyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookingsTbale : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingId = c.Guid(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        ServiceType = c.String(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        ServiceDuration = c.Double(nullable: false),
                        ServiceTime = c.Time(nullable: false, precision: 7),
                        ExtraDescription = c.String(),
                        IsNeedIroning = c.Boolean(nullable: false),
                        IsNeedCleaningMaterials = c.Boolean(nullable: false),
                        IsHavePets = c.Boolean(nullable: false),
                        ModeOfEntry = c.String(nullable: false),
                        PaymentMethod = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        HomeNumber = c.String(),
                        City = c.String(nullable: false),
                        DirectionsOrLandmarks = c.String(),
                        IsCompleted = c.Boolean(nullable: false),
                        TotalCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.BookingId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bookings");
        }
    }
}
