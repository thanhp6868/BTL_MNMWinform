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
        private int ProductId = 0;

        private static uc_NhaCungCap ucSupplier;
        public static uc_NhaCungCap Instance
        {
            get
            {
                if (ucSupplier == null)
                    ucSupplier = new uc_NhaCungCap();
                return ucSupplier;
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
        public void loadData()
        {
            dgvSuppiler.DataSource = _supplierService.GetAll().ToList().Select(s => Program.mapper.Map<SupplierDto>(s)).ToList();
            
        }
    }
}
