using BTL_QLBQA.Components;
using BTL_QLBQA.Dtos.Products;
using BTL_QLBQA.Models;
using BTL_QLBQA.Services.BaseService;
using BTL_QLBQA.Services.ProductService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBQA.User_control
{
    public partial class uc_Product : UserControl
    {
        private int ProductId = 0;

        private static uc_Product ucProduct;
        public static uc_Product Instance
        {
            get
            {
                if (ucProduct == null)
                    ucProduct = new uc_Product();
                return ucProduct;
            }
        }
        private readonly IProductSerivce _productSerivce;
        private readonly IBaseService<Supplier> _supplierService;
        private readonly IBaseService<Unit> _unitService;
        private readonly IBaseService<ProductCategory> _productCategoryService;
        public uc_Product()
        {
            _productSerivce = new ProductService();
            _supplierService = new BaseService<Supplier>();
            _unitService = new BaseService<Unit>();
            _productCategoryService = new BaseService<ProductCategory>();
            InitializeComponent();
        }

        private void uc_Product_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            dgvProduct.DataSource = _productSerivce.getDataSoucreDto(txt_timkiem.Text);
            formHelper.comboBoxLoad<Supplier>(cbbSupplier, _supplierService.GetAll().ToList());
            formHelper.comboBoxLoad<Unit>(cbbUnit, _unitService.GetAll().ToList());
            formHelper.comboBoxLoad<ProductCategory>(cbbProductCategory, _productCategoryService.GetAll().ToList());
            ProductId = 0;
            formHelper.loadGroupBox(gbForm);
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            loadData();
        }
        
        private void btn_them_Click(object sender, EventArgs e)
        {
            ProductId = 0;
            formHelper.loadGroupBox(gbForm);
            setEnable(false);
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
            Product p = ProductId > 0 ? _productSerivce.GetByID(int.Parse(txtId.Text)) : new Product();
            p.Name = txtName.Text;
            p.ImportPrice = float.Parse(txtImportPrice.Text);
            p.ExportPrice = float.Parse(txtExportPrice.Text);
            p.SupplierId = int.Parse(cbbSupplier.SelectedValue.ToString());
            p.ProductCategoryId = int.Parse(cbbProductCategory.SelectedValue.ToString());
            p.UnitId = int.Parse(cbbUnit.SelectedValue.ToString());
            p.Note = txtNote.Text;
            p.Quantity = int.Parse(txtQuantity.Text);
            if(ProductId > 0)
            {
                _productSerivce.Update(p);
            }
            else
            {
                _productSerivce.Insert(p);
            }
            loadData();
            setEnable(true);
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            loadData();
            setEnable(true);
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex > 0 && !gbForm.Enabled)
            {
                var product = _productSerivce.GetByID(int.Parse(dgvProduct.Rows[e.RowIndex].Cells[0].Value.ToString()));
                if(product != null)
                {
                    txtId.Text = product.Id.ToString();
                    txtName.Text = product.Name;
                    txtImportPrice.Text = product.ImportPrice.ToString();
                    txtExportPrice.Text = product.ExportPrice.ToString();
                    txtQuantity.Text = product.Quantity.ToString();
                    txtNote.Text = product.Note;
                    cbbSupplier.SelectedValue = product.SupplierId;
                    cbbProductCategory.SelectedValue = product.ProductCategoryId;
                    cbbUnit.SelectedValue = product.UnitId;
                    ProductId = product.Id;
                }
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if(ProductId > 0)
            {
                setEnable(false);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn san pham cần sửa");
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if (ProductId > 0)
            {
                Product p = _productSerivce.GetByID(ProductId);
                if (p != null)
                {
                    if (_productSerivce.Delete(p.Id))
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
                MessageBox.Show("Vui lòng chọn san pham cần sửa");
            }
        }

        private void btn_timkiem_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_timkiem.Text = "";
            loadData();
        }
    }
}
