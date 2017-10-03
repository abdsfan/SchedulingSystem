namespace SchedulingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class populatecaptable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO CAPS (CapNumber) VALUES(100)");
            Sql("INSERT INTO CAPS (CapNumber) VALUES(200)");
            Sql("INSERT INTO CAPS (CapNumber) VALUES(300)");
            Sql("INSERT INTO CAPS (CapNumber) VALUES(400)");
            Sql("INSERT INTO CAPS (CapNumber) VALUES(500)");
        }
        
        public override void Down()
        {
        }
    }
}
