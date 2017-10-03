namespace SchedulingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedPaymentstable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Double(nullable: false),
                        Status = c.String(),
                        PaymentDate = c.DateTime(nullable: false),
                        PaymentTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PaymentTypes", t => t.PaymentTypeId, cascadeDelete: true)
                .Index(t => t.PaymentTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payments", "PaymentTypeId", "dbo.PaymentTypes");
            DropIndex("dbo.Payments", new[] { "PaymentTypeId" });
            DropTable("dbo.Payments");
        }
    }
}
