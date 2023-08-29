using BTL_QLBQA.Components;
using BTL_QLBQA.Dtos.Categories;
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
    public partial class uc_Category : UserControl
    {
        private int CategoryID = 0;
        private readonly IBaseService<Category> _categoryService;
        public uc_Category()
        {
            InitializeComponent();
            _categoryService = new BaseService<Category>();
        }
        private static uc_Category ucCategory;
        public static uc_Category Instance
        {
            get
            {
                if (ucCategory == null)
                    ucCategory = new uc_Category();
                return ucCategory;
            }
        }

        private void uc_Category_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            dgvCategory.DataSource = _categoryService.GetAll().ToList().Select(s => Program.mapper.Map<CategoryDto>(s)).ToList();

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
            Category p = CategoryID > 0 ? _categoryService.GetByID(int.Parse(txtId.Text)) : new Category();
            if (p == null)
            {
                MessageBox.Show("Thông tin không tồn tại");
                return;
            }
            p.Name = txtName.Text;
            p.Description = txtDescription.Text;
           
            if (CategoryID > 0)
            {
                _categoryService.Update(p);
            }
            else
            {
                _categoryService.Insert(p);
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
            CategoryID = 0;
            formHelper.loadGroupBox(gbForm);
            setEnable(false);
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (CategoryID > 0)
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
            if (CategoryID > 0)
            {
                Category p = _categoryService.GetByID(CategoryID);
                if (p != null)
                {
                    if (_categoryService.Delete(p.Id))
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

        private void dgvCategory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && !gbForm.Enabled)
            {
                var p = _categoryService.GetByID(int.Parse(dgvCategory.Rows[e.RowIndex].Cells[0].Value.ToString()));
                if (p != null)
                {
                    CategoryID = p.Id;
                    txtId.Text = p.Id.ToString();
                    txtName.Text = p.Name.ToString();
                    txtDescription.Text = p.Description.ToString();
                    
                }
            }
        }
    }
}
