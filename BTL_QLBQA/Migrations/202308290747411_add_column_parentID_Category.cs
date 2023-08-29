namespace BTL_QLBQA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_parentID_Category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "CategoryId", c => c.Int());
            CreateIndex("dbo.Categories", "CategoryId");
            AddForeignKey("dbo.Categories", "CategoryId", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "CategoryId" });
            DropColumn("dbo.Categories", "CategoryId");
        }
    }
}
