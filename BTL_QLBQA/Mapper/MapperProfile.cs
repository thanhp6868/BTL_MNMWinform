using AutoMapper;
using BTL_QLBQA.Dtos.Categories;
using BTL_QLBQA.Dtos.Customer;
using BTL_QLBQA.Dtos.Employees;
using BTL_QLBQA.Dtos.Products;
using BTL_QLBQA.Dtos.Shifts;
using BTL_QLBQA.Dtos.Suppliers;
using BTL_QLBQA.Dtos.Unit;
using BTL_QLBQA.Dtos.Warehouse;
using BTL_QLBQA.Dtos.WarehouseAreas;
using BTL_QLBQA.Models;
using System.Drawing.Design;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Product, ProductDto>().
            ForMember(pd => pd.ProductCategoryName, p =>
            p.MapFrom(src => (src.ProductCategory != null) ? src.ProductCategory.Name : ""))
            .ForMember(pd => pd.UnitName, p =>
            p.MapFrom(src => (src.Unit != null) ? src.Unit.Name : ""))
            .ForMember(pd => pd.SupplierName, p =>
            p.MapFrom(src => (src.Supplier != null) ? src.Supplier.Name : ""));

        CreateMap<Supplier, SupplierDto>();
        CreateMap<Employee, EmployeeDto>();
        CreateMap<Shift, ShiftDto>();
        CreateMap<Customer, CustomerDto>();
        CreateMap<WareHouse, WarehouseDto>();
        CreateMap<WarehouseArea, WarehouseAreaDto>();
        CreateMap<Category, CategoryDto>();
        CreateMap<Unit, UnitDto>();
        CreateMap<ProductCategory, ProductCategoryDto>();
    }
}