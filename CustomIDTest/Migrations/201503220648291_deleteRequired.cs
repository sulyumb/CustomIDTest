namespace CustomIDTest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Reference", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Reference", c => c.String(nullable: false));
        }
    }
}
