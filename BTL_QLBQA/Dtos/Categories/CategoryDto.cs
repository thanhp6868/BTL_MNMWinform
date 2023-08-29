using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Dtos.Categories
{
    public class CategoryDto
    {
        [DisplayName("Mã")]
        public int Id { get; set; }
        [DisplayName("Loại sản phẩm")]
        public string Name { get; set; }
        [DisplayName("Mô tả")]
        public float Description { get; set; }
        //[DisplayName("Giờ kết thúc")]
        //public float EndHour { get; set; }
    }
}
