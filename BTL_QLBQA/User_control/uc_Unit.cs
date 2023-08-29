using BTL_QLBQA.Components;
using BTL_QLBQA.Dtos.Unit;
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
    public partial class uc_Unit : UserControl
    {
        private int UnitID = 0;
        private readonly IBaseService<Unit> _unitService;
        public uc_Unit()
        {
            InitializeComponent();
            _unitService = new BaseService<Unit>();
        }
        private static uc_Unit ucUnit;
        public static uc_Unit Instance
        {
            get
            {
                if (ucUnit == null)
                    ucUnit = new uc_Unit();
                return ucUnit;
            }
        }

        private void uc_Unit_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            _unitService.loadData<UnitDto>(dgvUnit);
            //dgvUnit.DataSource = _unitService.GetAll().ToList().Select(s => Program.mapper.Map<UnitDto>(s)).ToList();


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
            Unit p = UnitID > 0 ? _unitService.GetByID(int.Parse(txtId.Text)) : new Unit();
            if (p == null)
            {
                MessageBox.Show("Thông tin không tồn tại");
                return;
            }
            p.Name = txtName.Text;
            p.Description = txtDescription.Text;

            if (UnitID > 0)
            {
                _unitService.Update(p);
            }
            else
            {
                _unitService.Insert(p);
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
            UnitID = 0;
            formHelper.loadGroupBox(gbForm);
            setEnable(false);
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (UnitID > 0)
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

            if (UnitID > 0)
            {
                Unit p = _unitService.GetByID(UnitID);
                if (p != null)
                {
                    if (_unitService.Delete(p.Id))
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

        private void dgvUnit_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex >= 0 && !gbForm.Enabled)
            {
                var p = _unitService.GetByID(int.Parse(dgvUnit.Rows[e.RowIndex].Cells[0].Value.ToString()));
                if (p != null)
                {
                    UnitID = p.Id;
                    txtId.Text = p.Id.ToString();
                    txtName.Text = p.Name.ToString();
                    txtDescription.Text = p.Description;

                }
            }
        }
    }
}
