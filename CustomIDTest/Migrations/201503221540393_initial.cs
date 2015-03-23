namespace CustomIDTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        Reference = c.String(maxLength: 450),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .Index(t => t.Reference, unique: true);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "Reference" });
            DropTable("dbo.Employees");
        }
    }
}
