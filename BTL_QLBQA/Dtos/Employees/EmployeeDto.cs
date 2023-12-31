﻿using System;
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
        public string FullName { get; set; }
        [DisplayName("Địa chỉ")]
        public string Address { get; set; }
        [DisplayName("SĐT")]
        public string PhoneNumber { get; set;}
        [DisplayName("Tài khoản")]
        public string Username { get; set; }
        [DisplayName("Quyền")]
        public string Rule { get; set; }
        [DisplayName("Ghi chú")]
        public string Note { get; set; }
    }
}
