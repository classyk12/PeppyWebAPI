namespace PeppyWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedBookingsAndUserTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Feedbacks", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Feedbacks", "UserId");
            AddForeignKey("dbo.Feedbacks", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Feedbacks", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Feedbacks", new[] { "UserId" });
            DropColumn("dbo.Feedbacks", "UserId");
        }
    }
}
