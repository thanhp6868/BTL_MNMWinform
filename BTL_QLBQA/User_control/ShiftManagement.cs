using BTL_QLBQA.Components;
using BTL_QLBQA.Dtos.Shifts;
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
    public partial class ShiftManagement : UserControl
    {
        private int ShiftID = 0;

        private static ShiftManagement ShiftManagements;
        public static ShiftManagement Instance
        {
            get
            {
                if (ShiftManagements == null)
                    ShiftManagements = new ShiftManagement();
                return ShiftManagements;
            }
        }
        public ShiftManagement()
        {
            InitializeComponent();
            _shiftService = new BaseService<Shift>();
        }
        private readonly IBaseService<Shift> _shiftService;


        private void ShiftManagement_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            formHelper.loadDatagridView(dgvShift, _shiftService.GetListDataSource<ShiftDto>());
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
            Shift p = ShiftID > 0 ? _shiftService.GetByID(int.Parse(txtId.Text)) : new Shift();
            if (p == null)
            {
                MessageBox.Show("Không tồn tại thông tin này");
                return;
            }
            p.Name = txtName.Text;
            p.StartHour = int.Parse(numUDStart.Value.ToString());
            p.EndHour = int.Parse(numUDEnd.Value.ToString());
            
            if (ShiftID > 0)
            {
                _shiftService.Update(p);
            }
            else
            {
                _shiftService.Insert(p);
            }
            loadData();
            setEnable(true);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            loadData();
            setEnable(true);
        }

        private void dgvShift_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && !gbForm.Enabled)
            {
                var shift = _shiftService.GetByID(int.Parse(dgvShift.Rows[e.RowIndex].Cells[0].Value.ToString()));
                if (shift != null)
                {
                    ShiftID = shift.Id;
                    txtId.Text = shift.Id.ToString();
                    txtName.Text = shift.Name;
                    numUDStart.Text = shift.StartHour.ToString();
                    numUDEnd.Text = shift.EndHour.ToString();
                   
                }
            }
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            ShiftID = 0;
            formHelper.loadGroupBox(gbForm);
            setEnable(false);
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (ShiftID > 0)
            {
                setEnable(false);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa");
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (ShiftID > 0)
            {
                Shift p = _shiftService.GetByID(ShiftID);
                if (p != null)
                {
                    if (_shiftService.Delete(p.Id))
                    {
                        MessageBox.Show("Xóa thành công");
                        loadData();
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sản phẩm");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm cần sửa");
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
