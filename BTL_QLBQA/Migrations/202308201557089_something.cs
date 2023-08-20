namespace BTL_QLBQA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class something : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Money = c.Single(nullable: false),
                        Percent = c.Single(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Shifts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartHour = c.Int(nullable: false),
                        EndHour = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShiftEmployees",
                c => new
                    {
                        Shift_Id = c.Int(nullable: false),
                        Employee_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Shift_Id, t.Employee_Id })
                .ForeignKey("dbo.Shifts", t => t.Shift_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Employee_Id, cascadeDelete: true)
                .Index(t => t.Shift_Id)
                .Index(t => t.Employee_Id);
            
            AddColumn("dbo.Users", "Address", c => c.String());
            AddColumn("dbo.Users", "PhoneNumber", c => c.String());
            AddColumn("dbo.Users", "Note", c => c.String());
            AddColumn("dbo.OrderDetails", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.OrderDetails", "Discount", c => c.Single(nullable: false));
            AddColumn("dbo.OrderDetails", "Price", c => c.Single(nullable: false));
            AddColumn("dbo.Orders", "Code", c => c.String());
            AddColumn("dbo.Orders", "Note", c => c.String());
            AddColumn("dbo.Orders", "CouponId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Name", c => c.String());
            AddColumn("dbo.Products", "ImportPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Products", "ExportPrice", c => c.Single(nullable: false));
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "SupplierId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ProductCategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "UnitId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Note", c => c.String());
            CreateIndex("dbo.Orders", "CouponId");
            CreateIndex("dbo.Orders", "CustomerId");
            CreateIndex("dbo.Products", "SupplierId");
            CreateIndex("dbo.Products", "ProductCategoryId");
            CreateIndex("dbo.Products", "UnitId");
            AddForeignKey("dbo.Orders", "CouponId", "dbo.Coupons", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "ProductCategoryId", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Products", "UnitId", "dbo.Categories", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UnitId", "dbo.Categories");
            DropForeignKey("dbo.Products", "SupplierId", "dbo.Suppliers");
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.Categories");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Users");
            DropForeignKey("dbo.Orders", "CouponId", "dbo.Coupons");
            DropForeignKey("dbo.ShiftEmployees", "Employee_Id", "dbo.Users");
            DropForeignKey("dbo.ShiftEmployees", "Shift_Id", "dbo.Shifts");
            DropIndex("dbo.ShiftEmployees", new[] { "Employee_Id" });
            DropIndex("dbo.ShiftEmployees", new[] { "Shift_Id" });
            DropIndex("dbo.Products", new[] { "UnitId" });
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropIndex("dbo.Products", new[] { "SupplierId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Orders", new[] { "CouponId" });
            DropColumn("dbo.Products", "Note");
            DropColumn("dbo.Products", "UnitId");
            DropColumn("dbo.Products", "ProductCategoryId");
            DropColumn("dbo.Products", "SupplierId");
            DropColumn("dbo.Products", "Quantity");
            DropColumn("dbo.Products", "ExportPrice");
            DropColumn("dbo.Products", "ImportPrice");
            DropColumn("dbo.Products", "Name");
            DropColumn("dbo.Orders", "CustomerId");
            DropColumn("dbo.Orders", "Status");
            DropColumn("dbo.Orders", "CouponId");
            DropColumn("dbo.Orders", "Note");
            DropColumn("dbo.Orders", "Code");
            DropColumn("dbo.OrderDetails", "Price");
            DropColumn("dbo.OrderDetails", "Discount");
            DropColumn("dbo.OrderDetails", "Quantity");
            DropColumn("dbo.Users", "Note");
            DropColumn("dbo.Users", "PhoneNumber");
            DropColumn("dbo.Users", "Address");
            DropTable("dbo.ShiftEmployees");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Shifts");
            DropTable("dbo.Coupons");
            DropTable("dbo.Categories");
        }
    }
}
