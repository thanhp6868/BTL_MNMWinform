namespace BTL_QLBQA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addemployeeidtableorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "EmployeeId", c => c.Int());
            CreateIndex("dbo.Orders", "EmployeeId");
            AddForeignKey("dbo.Orders", "EmployeeId", "dbo.Users", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropColumn("dbo.Orders", "EmployeeId");
        }
    }
}
