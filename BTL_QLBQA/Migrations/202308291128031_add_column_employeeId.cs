namespace BTL_QLBQA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_employeeId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contracts", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Contracts", "EmployeeId");
            AddForeignKey("dbo.Contracts", "EmployeeId", "dbo.Users", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Contracts", "EmployeeId", "dbo.Users");
            DropIndex("dbo.Contracts", new[] { "EmployeeId" });
            DropColumn("dbo.Contracts", "EmployeeId");
        }
    }
}
