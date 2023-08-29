namespace BTL_QLBQA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcreateattableorder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "CreatedAt");
        }
    }
}
