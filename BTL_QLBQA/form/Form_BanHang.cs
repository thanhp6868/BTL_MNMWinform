using BTL_QLBQA.Components;
using BTL_QLBQA.Models;
using BTL_QLBQA.Services.BaseService;
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

namespace BTL_QLBQA.form
{
    public partial class Form_BanHang : Form
    {
        private readonly BaseService<Order> _orderService;
        private readonly BaseService<OrderDetail> _orderDetailService;

        public Form_BanHang()
        {
            InitializeComponent();
            _orderService = new BaseService<Order>();
            _orderDetailService = new BaseService<OrderDetail>();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form_BanHang_Load(object sender, EventArgs e)
        {
            formHelper.comboBoxLoad<Order>(cbxMaHoaDon, _orderService.GetAll().ToList(), "id", "id");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if(cbxMaHoaDon.SelectedIndex > 0)
            {
                dataGridView1.DataSource = _orderService.GetAll().Include(o => o.OrderDetails).ToList().FirstOrDefault(o => o.Id == (int)cbxMaHoaDon.SelectedValue);
            }
        }

        private void Form_BanHang_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_main_menu form = new Form_main_menu();
            form.Show();
        }
    }
}
