namespace BTL_QLBQA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rename_column : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Categories", name: "CategoryId", newName: "ParentId");
            RenameIndex(table: "dbo.Categories", name: "IX_CategoryId", newName: "IX_ParentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Categories", name: "IX_ParentId", newName: "IX_CategoryId");
            RenameColumn(table: "dbo.Categories", name: "ParentId", newName: "CategoryId");
        }
    }
}
