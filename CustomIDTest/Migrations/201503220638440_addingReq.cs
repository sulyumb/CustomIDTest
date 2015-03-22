namespace CustomIDTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingReq : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Reference", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Reference", c => c.String());
        }
    }
}
