namespace CustomIDTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class referenceAsAKey : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "EmployeeID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "Reference", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Employees", new[] { "EmployeeID", "Reference" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "Reference", c => c.String());
            AlterColumn("dbo.Employees", "EmployeeID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Employees", "EmployeeID");
        }
    }
}
