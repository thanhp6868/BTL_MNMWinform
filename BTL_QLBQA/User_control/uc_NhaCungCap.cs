using BTL_QLBQA.Components;
using BTL_QLBQA.Dtos.Suppliers;
using BTL_QLBQA.Models;
using BTL_QLBQA.Services.BaseService;
using BTL_QLBQA.Services.ProductService;
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
    public partial class uc_NhaCungCap : UserControl
    {
        private int SupplierID = 0;

        private static uc_NhaCungCap ucNhaCungCap;
        public static uc_NhaCungCap Instance
        {
            get
            {
                if (ucNhaCungCap == null)
                    ucNhaCungCap = new uc_NhaCungCap();
                return ucNhaCungCap;
            }
        }
        private readonly IBaseService<Supplier> _supplierService;
        public uc_NhaCungCap()
        {
            InitializeComponent();
            _supplierService = new BaseService<Supplier>();
        }

        private void uc_NhaCungCap_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void setEnable(bool value)
        {
            btn_them.Enabled = value;
            btn_sua.Enabled = value;
            btn_xoa.Enabled = value;
            groupBox2.Enabled = !value;
        }
        public void loadData()
        {
            formHelper.loadDatagridView(dgvSuppiler, _supplierService.GetListDataSource<SupplierDto>());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Supplier p = SupplierID > 0 ? _supplierService.GetByID(int.Parse(txtMaNCC.Text)) : new Supplier();
            if (p == null)
            {
                MessageBox.Show("Thông tin không tồn tại");
                return;
            }
            p.Name = txtTenNCC.Text;
            p.PhoneNumber = txtSDT.Text;
            p.Address = txtDiaChi.Text;
            p.Email = txtEmail.Text;
           
            if (SupplierID > 0)
            {
                _supplierService.Update(p);
            }
            else
            {
                _supplierService.Insert(p);
            }
            loadData();
            setEnable(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            loadData();
            setEnable(true);
        }

        private void dgvSuppiler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && !groupBox2.Enabled)
            {
                var p = _supplierService.GetByID(int.Parse(dgvSuppiler.Rows[e.RowIndex].Cells[0].Value.ToString()));
                if (p != null)
                {
                    SupplierID = p.Id;
                    txtMaNCC.Text = p.Id.ToString();
                    txtTenNCC.Text = p.Name;
                    txtDiaChi.Text = p.Address;
                    txtSDT.Text = p.PhoneNumber;
                    txtEmail.Text = p.Email;
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (SupplierID > 0)
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
            if (SupplierID > 0)
            {
                Supplier p = _supplierService.GetByID(SupplierID);
                if (p != null)
                {
                    if (_supplierService.Delete(p.Id))
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

        private void btn_them_Click(object sender, EventArgs e)
        {
            SupplierID = 0;
            formHelper.loadGroupBox(groupBox2);
            setEnable(false);
        }
    }
}
