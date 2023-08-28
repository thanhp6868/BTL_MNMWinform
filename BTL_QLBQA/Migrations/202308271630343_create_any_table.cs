namespace BTL_QLBQA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_any_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        TimeOut = c.DateTime(nullable: false),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Contracts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Expiry = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EmployeeSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContractId = c.Int(nullable: false),
                        Month = c.Int(nullable: false),
                        Year = c.Int(nullable: false),
                        ShiftSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bonus = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fine = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Debit = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Insurance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActuallyReceived = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contracts", t => t.ContractId, cascadeDelete: true)
                .Index(t => t.ContractId);
            
            CreateTable(
                "dbo.WarehouseAreaDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        WarehouseAreaId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.WarehouseAreas", t => t.WarehouseAreaId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.WarehouseAreaId);
            
            CreateTable(
                "dbo.WarehouseAreas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameArea = c.String(),
                        WareHouseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WareHouses", t => t.WareHouseId, cascadeDelete: true)
                .Index(t => t.WareHouseId);
            
            CreateTable(
                "dbo.WareHouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WarehouseAreaDetails", "WarehouseAreaId", "dbo.WarehouseAreas");
            DropForeignKey("dbo.WarehouseAreas", "WareHouseId", "dbo.WareHouses");
            DropForeignKey("dbo.WarehouseAreaDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.EmployeeSalaries", "ContractId", "dbo.Contracts");
            DropForeignKey("dbo.Attendances", "EmployeeId", "dbo.Users");
            DropIndex("dbo.WarehouseAreas", new[] { "WareHouseId" });
            DropIndex("dbo.WarehouseAreaDetails", new[] { "WarehouseAreaId" });
            DropIndex("dbo.WarehouseAreaDetails", new[] { "ProductId" });
            DropIndex("dbo.EmployeeSalaries", new[] { "ContractId" });
            DropIndex("dbo.Attendances", new[] { "EmployeeId" });
            DropTable("dbo.WareHouses");
            DropTable("dbo.WarehouseAreas");
            DropTable("dbo.WarehouseAreaDetails");
            DropTable("dbo.EmployeeSalaries");
            DropTable("dbo.Contracts");
            DropTable("dbo.Attendances");
        }
    }
}
