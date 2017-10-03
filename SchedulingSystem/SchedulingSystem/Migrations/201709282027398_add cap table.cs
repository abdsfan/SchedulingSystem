namespace SchedulingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcaptable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Caps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CapNumber = c.Int(nullable: false),
                        ApplicationUserId = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Caps", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Caps", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Caps");
        }
    }
}
