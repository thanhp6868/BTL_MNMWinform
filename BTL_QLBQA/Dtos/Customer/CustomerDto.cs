using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Dtos.Customer
{
    public class CustomerDto
    {

        [DisplayName("Mã khách hàng")]
        public int Id { get; set; }
        [DisplayName("Tên khách hàng")]
        public string FullName { get; set; }
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [DisplayName("SĐT")]
        public string PhoneNumber { get; set; }
        [DisplayName("Vai trò")]
        public string Rule { get; set; }
        [DisplayName("Ghi chú")]
        public string Note { get; set; }

    }
}
