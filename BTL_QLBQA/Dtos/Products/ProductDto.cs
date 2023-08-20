using BTL_QLBQA.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Dtos.Products
{
    public class ProductDto
    {
        [DisplayName("Mã")]
        public int Id { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }
        [DisplayName("Giá nhập")]
        public float ImportPrice { get; set; }
        [DisplayName("Giá bán")]
        public float ExportPrice { get; set; }
        [DisplayName("Số lượng tồn")]
        public int Quantity { get; set; }
        [DisplayName("Đơn vị")]
        public string UnitName { get; set; }
        [DisplayName("Tên nhà cung cấp")]
        public string SupplierName { get; set; }
        [DisplayName("Loại SP")]
        public string ProductCategoryName { get; set; }
        [DisplayName("Ghi chú")]
        public string Note { get; set; }
       
    }
}
