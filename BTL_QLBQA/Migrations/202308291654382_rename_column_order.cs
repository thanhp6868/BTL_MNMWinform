namespace BTL_QLBQA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename_column_order : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CouponId", "dbo.Coupons");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Users");
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "CouponId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            AlterColumn("dbo.Orders", "CouponId", c => c.Int());
            AlterColumn("dbo.Orders", "CustomerId", c => c.Int());
            AlterColumn("dbo.Orders", "EmployeeId", c => c.Int());
            CreateIndex("dbo.Orders", "CouponId");
            CreateIndex("dbo.Orders", "CustomerId");
            CreateIndex("dbo.Orders", "EmployeeId");
            AddForeignKey("dbo.Orders", "CouponId", "dbo.Coupons", "Id");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Users", "Id");
            AddForeignKey("dbo.Orders", "EmployeeId", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "EmployeeId", "dbo.Users");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Users");
            DropForeignKey("dbo.Orders", "CouponId", "dbo.Coupons");
            DropIndex("dbo.Orders", new[] { "EmployeeId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "CouponId" });
            AlterColumn("dbo.Orders", "EmployeeId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "CouponId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "EmployeeId");
            CreateIndex("dbo.Orders", "CustomerId");
            CreateIndex("dbo.Orders", "CouponId");
            AddForeignKey("dbo.Orders", "EmployeeId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CouponId", "dbo.Coupons", "Id", cascadeDelete: true);
        }
    }
}
