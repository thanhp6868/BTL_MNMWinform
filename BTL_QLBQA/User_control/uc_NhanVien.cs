using BTL_QLBQA.Dtos.Employees;
using BTL_QLBQA.Models;
using BTL_QLBQA.Services.BaseService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBQA.User_control
{
    public partial class uc_NhanVien : UserControl
    {
        private static uc_NhanVien ucNhanVien;
        public static uc_NhanVien Instance
        {
            get
            {
                if (ucNhanVien == null)
                    ucNhanVien = new uc_NhanVien();
                return ucNhanVien;
            }
        }
        private readonly IBaseService<Employee> _emplyeeService;
        public uc_NhanVien()
        {
            InitializeComponent();
            _emplyeeService = new BaseService<Employee>();
        }

        private void uc_NhanVien_Load(object sender, EventArgs e)
        {

        }
        public void loadData()
        {
            var data = _emplyeeService.GetAll().ToList().Select(s => Program.mapper.Map<EmployeeDto>(s)).ToList();
            if(data.Count > 0)
            {
                  dgvNhanVien.DataSource = data;
            }
            else
            {
                dgvNhanVien.DataSource = new List<EmployeeDto>();
            }

        }
    }
}
