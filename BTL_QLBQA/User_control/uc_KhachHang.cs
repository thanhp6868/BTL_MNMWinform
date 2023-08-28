using BTL_QLBQA.Components;
using BTL_QLBQA.Dtos.Customer;
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
    public partial class uc_KhachHang : UserControl
    {
        private int CustomerID = 0;
        private readonly IBaseService<Customer> _customerService;

        public uc_KhachHang()
        {
            InitializeComponent();
            _customerService = new BaseService<Customer>();
        }
        private static uc_KhachHang ucKhachHang;
        public static uc_KhachHang Instance
        {
            get
            {
                if (ucKhachHang == null)
                    ucKhachHang = new uc_KhachHang();
                return ucKhachHang;
            }
        }

        private void uc_KhachHang_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            dgvCustomer.DataSource = _customerService.GetAll().ToList().Select(s => Program.mapper.Map<CustomerDto>(s)).ToList();

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
            Customer p = CustomerID > 0 ? _customerService.GetByID(int.Parse(txtId.Text)) : new Customer();
            if (p == null)
            {
                MessageBox.Show("Thông tin không tồn tại");
                return;
            }
            p.FullName = txtName.Text;
            p.PhoneNumber = txtPhoneNum.Text;
            p.Address = txtAddress.Text;
            p.Note = txtNote.Text;
            if (CustomerID > 0)
            {
                _customerService.Update(p);
            }
            else
            {
                _customerService.Insert(p);
            }
            loadData();
            setEnable(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            loadData();
            setEnable(true);
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && !gbForm.Enabled)
            {
                var p = _customerService.GetByID(int.Parse(dgvCustomer.Rows[e.RowIndex].Cells[0].Value.ToString()));
                if (p != null)
                {
                    CustomerID = p.Id;
                    txtId.Text = p.Id.ToString();
                    txtName.Text = p.FullName.ToString();
                    txtAddress.Text = p.Address.ToString();
                    txtPhoneNum.Text = p.PhoneNumber.ToString();
                    txtNote.Text = p.Note.ToString();
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            CustomerID = 0;
            formHelper.loadGroupBox(gbForm);
            setEnable(false);
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (CustomerID > 0)
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
            if (CustomerID > 0)
            {
                Customer p = _customerService.GetByID(CustomerID);
                if (p != null)
                {
                    if (_customerService.Delete(p.Id))
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
