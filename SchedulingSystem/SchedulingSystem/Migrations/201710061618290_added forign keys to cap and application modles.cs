namespace SchedulingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedforignkeystocapandapplicationmodles : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Caps", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Caps", new[] { "ApplicationUser_Id" });
            CreateTable(
                "dbo.ApplicationUserCaps",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Cap_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Cap_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Caps", t => t.Cap_Id, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Cap_Id);
            
            DropColumn("dbo.Caps", "ApplicationUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Caps", "ApplicationUser_Id", c => c.String(maxLength: 128));
            DropForeignKey("dbo.ApplicationUserCaps", "Cap_Id", "dbo.Caps");
            DropForeignKey("dbo.ApplicationUserCaps", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplicationUserCaps", new[] { "Cap_Id" });
            DropIndex("dbo.ApplicationUserCaps", new[] { "ApplicationUser_Id" });
            DropTable("dbo.ApplicationUserCaps");
            CreateIndex("dbo.Caps", "ApplicationUser_Id");
            AddForeignKey("dbo.Caps", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
