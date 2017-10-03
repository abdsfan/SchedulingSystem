namespace SchedulingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdscheduletable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        ShiftDate = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        TotalCost = c.Double(nullable: false),
                        CapId = c.String(),
                        ApplicationUserId = c.String(maxLength: 128),
                        Cap_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Caps", t => t.Cap_Id)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.Cap_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "Cap_Id", "dbo.Caps");
            DropForeignKey("dbo.Schedules", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Schedules", new[] { "Cap_Id" });
            DropIndex("dbo.Schedules", new[] { "ApplicationUserId" });
            DropTable("dbo.Schedules");
        }
    }
}
