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
        public uc_Product()
        {
            _productSerivce = new ProductService();
            InitializeComponent();
        }

        private void uc_Product_Load(object sender, EventArgs e)
        {
            dgvProduct.DataSource = _productSerivce.GetAll().Include(p => p.ProductCategory).ToList();
        }
    }
}
