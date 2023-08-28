using BTL_QLBQA.Components;
using BTL_QLBQA.Dtos.WarehouseAreas;
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
    public partial class uc_WarehouseArea : UserControl
    {
        private int WarehouseAreaID = 0;

        private static uc_WarehouseArea WarehouseArea;
        public static uc_WarehouseArea Instance
        {
            get
            {
                if (WarehouseArea == null)
                    WarehouseArea = new uc_WarehouseArea();
                return WarehouseArea;
            }
        }
        private readonly IBaseService<WarehouseArea> _warehouseAreaService;
        private readonly IBaseService<WareHouse> _warehouseService;
       

        public uc_WarehouseArea()
        {
            InitializeComponent();
            _warehouseAreaService = new BaseService<WarehouseArea>();
            _warehouseService = new BaseService<WareHouse>();
        }

        private void uc_WarehouseArea_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            dgvWarehouse.DataSource = _warehouseAreaService.GetAll().ToList().Select(s => Program.mapper.Map<WarehouseAreaDto>(s)).ToList();
            formHelper.comboBoxLoad<WareHouse>(cbxKhoChua, _warehouseService.GetAll().ToList());
        }
    }
}
