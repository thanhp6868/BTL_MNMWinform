using BTL_QLBQA.Models;
using System.Data.Entity;


namespace BTL_QLBQA.DataAccess
{
    public class QLBQA_dbContext : DbContext 
    {
        public QLBQA_dbContext() : base("name=QLBQA")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Coupon> Coupons { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<EmployeeSalary> EmployeeSalaryies { get; set; }
        public DbSet<WarehouseArea> WarehouseAreas { get; set; }
        public DbSet<WareHouse> Warehouses { get; set; }
        public DbSet<WarehouseAreaDetail> WarehouseAreaDetails { get; set; }
    }
}
