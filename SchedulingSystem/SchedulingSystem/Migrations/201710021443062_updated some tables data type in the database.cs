namespace SchedulingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedsometablesdatatypeinthedatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Payments", "PaymentTypeId", "dbo.PaymentTypes");
            DropForeignKey("dbo.Ratings", "CapId", "dbo.Caps");
            DropForeignKey("dbo.Schedules", "PaymentId", "dbo.Payments");
            DropIndex("dbo.Payments", new[] { "PaymentTypeId" });
            DropIndex("dbo.Ratings", new[] { "CapId" });
            DropIndex("dbo.Schedules", new[] { "PaymentId" });
            RenameColumn(table: "dbo.Caps", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Payments", name: "PaymentTypeId", newName: "PaymentType_Id");
            RenameColumn(table: "dbo.Ratings", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Ratings", name: "CapId", newName: "Cap_Id");
            RenameColumn(table: "dbo.Schedules", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            RenameColumn(table: "dbo.Schedules", name: "PaymentId", newName: "Payment_Id");
            RenameIndex(table: "dbo.Caps", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.Ratings", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            RenameIndex(table: "dbo.Schedules", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            DropPrimaryKey("dbo.Schedules");
            AlterColumn("dbo.Payments", "PaymentType_Id", c => c.Int());
            AlterColumn("dbo.Ratings", "Cap_Id", c => c.Int());
            AlterColumn("dbo.Schedules", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Schedules", "Payment_Id", c => c.Int());
            AddPrimaryKey("dbo.Schedules", "Id");
            CreateIndex("dbo.Payments", "PaymentType_Id");
            CreateIndex("dbo.Ratings", "Cap_Id");
            CreateIndex("dbo.Schedules", "Payment_Id");
            AddForeignKey("dbo.Payments", "PaymentType_Id", "dbo.PaymentTypes", "Id");
            AddForeignKey("dbo.Ratings", "Cap_Id", "dbo.Caps", "Id");
            AddForeignKey("dbo.Schedules", "Payment_Id", "dbo.Payments", "Id");
            DropColumn("dbo.Schedules", "CapId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "CapId", c => c.String());
            DropForeignKey("dbo.Schedules", "Payment_Id", "dbo.Payments");
            DropForeignKey("dbo.Ratings", "Cap_Id", "dbo.Caps");
            DropForeignKey("dbo.Payments", "PaymentType_Id", "dbo.PaymentTypes");
            DropIndex("dbo.Schedules", new[] { "Payment_Id" });
            DropIndex("dbo.Ratings", new[] { "Cap_Id" });
            DropIndex("dbo.Payments", new[] { "PaymentType_Id" });
            DropPrimaryKey("dbo.Schedules");
            AlterColumn("dbo.Schedules", "Payment_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Schedules", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Ratings", "Cap_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Payments", "PaymentType_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Schedules", "Id");
            RenameIndex(table: "dbo.Schedules", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
            RenameIndex(table: "dbo.Ratings", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
            RenameIndex(table: "dbo.Caps", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
            RenameColumn(table: "dbo.Schedules", name: "Payment_Id", newName: "PaymentId");
            RenameColumn(table: "dbo.Schedules", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.Ratings", name: "Cap_Id", newName: "CapId");
            RenameColumn(table: "dbo.Ratings", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameColumn(table: "dbo.Payments", name: "PaymentType_Id", newName: "PaymentTypeId");
            RenameColumn(table: "dbo.Caps", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            CreateIndex("dbo.Schedules", "PaymentId");
            CreateIndex("dbo.Ratings", "CapId");
            CreateIndex("dbo.Payments", "PaymentTypeId");
            AddForeignKey("dbo.Schedules", "PaymentId", "dbo.Payments", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Ratings", "CapId", "dbo.Caps", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Payments", "PaymentTypeId", "dbo.PaymentTypes", "Id", cascadeDelete: true);
        }
    }
}
