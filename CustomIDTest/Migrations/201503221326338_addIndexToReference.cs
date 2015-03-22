namespace CustomIDTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIndexToReference : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Reference", c => c.String(maxLength: 450));
            CreateIndex("dbo.Employees", "Reference", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employees", new[] { "Reference" });
            AlterColumn("dbo.Employees", "Reference", c => c.String());
        }
    }
}
