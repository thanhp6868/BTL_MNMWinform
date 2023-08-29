namespace BTL_QLBQA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_address_WareHouse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WareHouses", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WareHouses", "Address");
        }
    }
}
