namespace BTL_QLBQA.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BTL_QLBQA.DataAccess.QLBQA_dbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BTL_QLBQA.DataAccess.QLBQA_dbContext context)
        {
            context.Admins.AddOrUpdate(x => x.Id,
                new Models.Admin()
                {
                    Id = 1,
                    Username = "Admin",
                    Password = "Admin"
                }
                );
            context.ProductCategories.AddOrUpdate(x => x.Id,
                new Models.ProductCategory()
                {
                    Id = 1,
                    Name = "Áo mùa đông"
                }
                );
            context.Suppliers.AddOrUpdate(x => x.Id,
               new Models.Supplier()
               {
                   Id = 1,
                   Name = "Quyết đỉnh vl"
               }
               );
            context.Units.AddOrUpdate(x => x.Id,
               new Models.Unit()
               {
                   Id = 2,
                   Name = "Cái"
               }
               );
            context.Products.AddOrUpdate(x => x.Id,
                new Models.Product()
                {
                    Id = 1,
                    Name = "Áo nữ đẹp vcl",
                    ProductCategoryId = 1,
                    UnitId = 1,
                    SupplierId = 1
                }
                );
        }
    }
}
