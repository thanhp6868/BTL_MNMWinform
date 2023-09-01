using BTL_QLBQA.Dtos.Products;
using BTL_QLBQA.Models;
using BTL_QLBQA.Services.BaseService;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace BTL_QLBQA.Services.ProductService
{
    public class ProductService : BaseService<Product>, IProductSerivce
    {
        public List<ProductDto> getDataSoucreDto(string nameFilter = "", int idFillter = 0)
        {
            return GetAll()
               .Include(p => p.ProductCategory)
               .Include(p => p.Unit)
               .Include(p => p.Supplier)
               .Where(p => (nameFilter == "" || p.Name.ToLower().Contains(nameFilter.ToLower())) && (idFillter == 0 || p.Id == idFillter))
               .ToList()
               .Select(p => Program.mapper.Map<ProductDto>(p))
               .ToList();
        }


        public void getProductByCategory(DataGridView d, int CategoryID = 0, string CategoryName = "")
        {
            var list = GetAll()
               .Include(p => p.ProductCategory)
               .Where(p =>   (CategoryID == 0 || p.ProductCategory.Id == CategoryID))
               .ToList()
               .Select(p => Program.mapper.Map<ProductDto>(p))
               .ToList();
            setDataGridView<ProductDto>(d, list);
        }

        public override void loadComboBox(ComboBox b, string valueName = "Name")
        {
            base.loadComboBox(b, valueName);
            b.SelectedIndex = -1;
        }

    }
}
