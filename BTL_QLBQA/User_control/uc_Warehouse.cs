using BTL_QLBQA.Components;
using BTL_QLBQA.Dtos.Warehouse;
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
    public partial class uc_Warehouse : UserControl
    {
        private int WarehouseID = 0;
        private readonly IBaseService<WareHouse> _warehouseService;
        public uc_Warehouse()
        {
            InitializeComponent();
            _warehouseService = new BaseService<WareHouse>();
        }

        private static uc_Warehouse ucWarehouse;
        public static uc_Warehouse Instance
        {
            get
            {
                if (ucWarehouse == null)
                    ucWarehouse = new uc_Warehouse();
                return ucWarehouse;
            }
        }
        private void uc_Warehouse_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            dgvWarehouse.DataSource = _warehouseService.GetAll().ToList().Select(s => Program.mapper.Map<WarehouseDto>(s)).ToList();

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
            WareHouse p = WarehouseID > 0 ? _warehouseService.GetByID(int.Parse(txtId.Text)) : new WareHouse();
            if (p == null)
            {
                MessageBox.Show("Thông tin không tồn tại");
                return;
            }
            p.Name = txtName.Text;
           
           
            if (WarehouseID > 0)
            {
                _warehouseService.Update(p);
            }
            else
            {
                _warehouseService.Insert(p);
            }
            loadData();
            setEnable(true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            loadData();
            setEnable(true);
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            WarehouseID = 0;
            formHelper.loadGroupBox(gbForm);
            setEnable(false);
        }

        private void dgvWarehouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && !gbForm.Enabled)
            {
                var p = _warehouseService.GetByID(int.Parse(dgvWarehouse.Rows[e.RowIndex].Cells[0].Value.ToString()));
                if (p != null)
                {
                    WarehouseID = p.Id;
                    txtId.Text = p.Id.ToString();
                    txtName.Text = p.Name.ToString();
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (WarehouseID > 0)
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
            if (WarehouseID > 0)
            {
                WareHouse p = _warehouseService.GetByID(WarehouseID);
                if (p != null)
                {
                    if (_warehouseService.Delete(p.Id))
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
