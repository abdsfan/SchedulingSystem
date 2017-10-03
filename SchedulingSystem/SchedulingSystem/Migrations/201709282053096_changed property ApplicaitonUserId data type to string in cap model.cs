namespace SchedulingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedpropertyApplicaitonUserIddatatypetostringincapmodel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Caps", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Caps", "ApplicationUserId");
            RenameColumn(table: "dbo.Caps", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            AlterColumn("dbo.Caps", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Caps", "ApplicationUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Caps", new[] { "ApplicationUserId" });
            AlterColumn("dbo.Caps", "ApplicationUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Caps", name: "ApplicationUserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Caps", "ApplicationUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Caps", "ApplicationUser_Id");
        }
    }
}
