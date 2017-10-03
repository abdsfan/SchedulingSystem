namespace SchedulingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRatingtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRated = c.DateTime(nullable: false),
                        Score = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        CapId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Caps", t => t.CapId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.CapId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ratings", "CapId", "dbo.Caps");
            DropForeignKey("dbo.Ratings", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Ratings", new[] { "CapId" });
            DropIndex("dbo.Ratings", new[] { "ApplicationUserId" });
            DropTable("dbo.Ratings");
        }
    }
}
