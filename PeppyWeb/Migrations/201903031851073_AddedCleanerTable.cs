namespace PeppyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCleanerTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cleaners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cleaners");
        }
    }
}
