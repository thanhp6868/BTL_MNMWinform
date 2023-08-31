using BTL_QLBQA.Dtos.Products;
using BTL_QLBQA.Models;
using BTL_QLBQA.Services.BaseService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBQA.Services.ProductService
{
    public interface IProductSerivce : IBaseService<Product>
    {
       List<ProductDto> getDataSoucreDto(string nameFilter = "", int idFillter = 0);
        void getProductByCategory(DataGridView d, int CategoryID =0, string CategoryName= ""); 
    }
}
