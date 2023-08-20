using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Dtos.Employees
{
    public class EmployeeDto
    {
        [DisplayName("Mã nhân viên")]
        public int Id { get; set; }
        [DisplayName("Tên nhân viên")]
        public string Name { get; set; }
        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set;}
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [DisplayName("Email")]
        public string Email { get; set; }
        [DisplayName("Ca làm")]
        public string Shift { get; set; }
    }
}
