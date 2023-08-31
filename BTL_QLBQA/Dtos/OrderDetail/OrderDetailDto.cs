using BTL_QLBQA.Dtos.Order;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Dtos.OrderDetail
{
   public class OrderDetailDto : OrderDto
    {
        [DisplayName("Mã đơn")]
        public int Code { get; set; }
        [DisplayName("Ngày tạo")]
        public int CreatedAt { get; set; }
        [DisplayName("Trạng thái đơn")]
        public int Status { get; set; }
        [DisplayName("Mã nhân viên")]
        public int EmployeeId { get; set; }
        [DisplayName("Mã khách hàng")]
        public int CustomerId { get; set; }
        [DisplayName("Số lượng")]
        public string Quantity { get; set; }
        [DisplayName("Sản phẩm")]
        public string ProductId { get; set; }
        [DisplayName("Tổng")]
        public string GetTotal { get; set; }
     
    }
}
