namespace SchedulingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class madepaymentDatenullableinpaymentmodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Payments", "PaymentDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Payments", "PaymentDate", c => c.DateTime(nullable: false));
        }
    }
}
