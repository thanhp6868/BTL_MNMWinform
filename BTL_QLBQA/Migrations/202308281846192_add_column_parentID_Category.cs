namespace BTL_QLBQA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_parentID_Category : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "ParentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Categories", "ParentID");
            AddForeignKey("dbo.Categories", "ParentID", "dbo.Categories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Categories", "ParentID", "dbo.Categories");
            DropIndex("dbo.Categories", new[] { "ParentID" });
            DropColumn("dbo.Categories", "ParentID");
        }
    }
}
