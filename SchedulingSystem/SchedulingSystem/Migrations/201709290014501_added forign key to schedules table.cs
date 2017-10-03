namespace SchedulingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforignkeytoschedulestable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "PaymentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Schedules", "PaymentId");
            AddForeignKey("dbo.Schedules", "PaymentId", "dbo.Payments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Schedules", "PaymentId", "dbo.Payments");
            DropIndex("dbo.Schedules", new[] { "PaymentId" });
            DropColumn("dbo.Schedules", "PaymentId");
        }
    }
}
