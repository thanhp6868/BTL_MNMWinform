using BTL_QLBQA.Components;
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
        private int EmployeeID = 0;

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
        private readonly IBaseService<Employee> _employeeService;
        public uc_NhanVien()
        {
            InitializeComponent();
            _employeeService = new BaseService<Employee>();
        }

        private void uc_NhanVien_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            dgvNhanVien.DataSource= _employeeService.GetAll().ToList().Select(s => Program.mapper.Map<EmployeeDto>(s)).ToList();
        }
        public void setEnable(bool value)
        {
            btn_them.Enabled = value;
            btn_sua.Enabled = value;
            btn_xoa.Enabled = value;
            gbForm.Enabled = !value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            Employee p = EmployeeID > 0 ? _employeeService.GetByID(int.Parse(txtId.Text)) : new Employee();
            if (p == null)
            {
                MessageBox.Show("Thông tin không tồn tại");
                return;
            }
            p.FullName = txtName.Text;
            p.PhoneNumber = txtPhoneNum.Text;
            p.Address = txtAddress.Text;
            p.Username = txtUser.Text;
            p.Note = txtNote.Text;
            p.Rule = txtRule.Text;

            if (EmployeeID > 0)
            {
                _employeeService.Update(p);
            }
            else
            {
                _employeeService.Insert(p);
            }
            loadData();
            setEnable(true);
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && !gbForm.Enabled)
            {
                var p = _employeeService.GetByID(int.Parse(dgvNhanVien.Rows[e.RowIndex].Cells[0].Value.ToString()));
                if (p != null)
                {
                    EmployeeID = p.Id;
                    txtId.Text = p.Id.ToString();
                    txtName.Text = p.FullName.ToString();
                    txtAddress.Text = p.Address.ToString();
                    txtPhoneNum.Text = p.PhoneNumber.ToString();
                    txtUser.Text = p.Username.ToString();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            loadData();
            setEnable(true);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            EmployeeID = 0;
            formHelper.loadGroupBox(gbForm);
            setEnable(false);
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (EmployeeID > 0)
            {
                setEnable(false);
            }
            else
            {
                MessageBox.Show("Vui lòng thông tin cần sửa");
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (EmployeeID > 0)
            {
                Employee p = _employeeService.GetByID(EmployeeID);
                if (p != null)
                {
                    if (_employeeService.Delete(p.Id))
                    {
                        MessageBox.Show("Xóa thành công");
                        loadData();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy ");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn thông tin cần sửa");
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
