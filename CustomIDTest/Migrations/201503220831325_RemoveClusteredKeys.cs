namespace CustomIDTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveClusteredKeys : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "EmployeeID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Employees", "Reference", c => c.String());
            AddPrimaryKey("dbo.Employees", "EmployeeID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Employees");
            AlterColumn("dbo.Employees", "Reference", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Employees", "EmployeeID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Employees", new[] { "EmployeeID", "Reference" });
        }
    }
}
