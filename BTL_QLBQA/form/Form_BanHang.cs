﻿using BTL_QLBQA.Components;
using BTL_QLBQA.Models;
using BTL_QLBQA.Services.BaseService;
using BTL_QLBQA.Services.OrdersService;
using BTL_QLBQA.Services.ProductService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBQA.form
{
    public partial class Form_BanHang : Form
    {
        private Order OrderCurrent;
        private int OrderIdCurrent;
        private readonly IOrderService _orderService;
        private readonly BaseService<OrderDetail> _orderDetailService;
        private readonly BaseService<Employee> _employeeService;
        private readonly BaseService<Customer> _customerService;
        private readonly ProductService _productService;

        public Form_BanHang()
        {
            InitializeComponent();
            _orderService = new OrderService();
            _orderDetailService = new BaseService<OrderDetail>();
            _employeeService = new BaseService<Employee>();
            _customerService = new BaseService<Customer>();
            _productService = new ProductService();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Form_BanHang_Load(object sender, EventArgs e)
        {
            _orderService.loadComboBox(cbxMaHoaDon, "Code");
            _employeeService.loadComboBox(cbxTenNV, "FullName");
            _customerService.loadComboBox(cbxTenKH, "FullName");
            _productService.loadComboBox(cbxTenHang);
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

        private void button1_Click(object sender, EventArgs e)
        {
            OrderCurrent = new Order();
            setOrderData(OrderCurrent);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(!(OrderCurrent is null))
            {
                DialogResult res =  MessageBox.Show("Đơn hàng hiện tại chưa được lưu, bạn có muốn lưu không ?", "Thông báo", MessageBoxButtons.YesNoCancel);
                if(res == DialogResult.Yes)
                {
                    _orderService.setDraftOrder(OrderCurrent);
                }
            }
            int orderId = cbxMaHoaDon.SelectedIndex >= 0 ? (int)cbxMaHoaDon.SelectedValue : 0;
            if(orderId > 0)
            {
                OrderCurrent = _orderService.getOrderAndOrderDetailById(orderId);
                setOrderData(OrderCurrent);
            }
            else
            {
               MessageBox.Show("Hoá đơn không hợp lệ", "Thông báo");

            }

        }

        private void button6_Click_1(object sender, EventArgs e)
        {

        }
        private void setOrderData(Order order)
        {
            if(order == null)
            {
                MessageBox.Show("Hoá đơn không hợp lệ", "Thông báo");
                return;
            }
            OrderIdCurrent = order.Id;
            txtMaHoaDon.Text = order.Code;
            dateNgayvaGioban.Value = order.CreatedAt;
            if (!(order.OrderDetails is null))
                loadOrderDetail(order);
        }
        public void loadOrderDetail(Order order)
        {
            dataGridView1.DataSource = order.OrderDetails.ToList();
        }
        private void cbxTenHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadProduct();
        }

        private void numUDSoLuong_ValueChanged(object sender, EventArgs e)
        {
            loadProduct();
        }
        private void loadProduct()
        {
            if (cbxTenHang.SelectedIndex > 0)
            {
                Product product = _productService.GetByID((int)cbxTenHang.SelectedValue);
                if (product is null)
                {
                    MessageBox.Show("Sản phẩm không tồn tại", "Thông báo");
                    return;
                }
                else if (product.Quantity == 0)
                {
                    MessageBox.Show("Sản phẩm đã hết hàng", "Thông báo");
                    return;
                }
                txtMaHang.Text = product.Id.ToString();
                txtDonGia.Text = product.ExportPrice.ToString();
                float total = product.ExportPrice * (int)numUDSoLuong.Value;
                txtThanhTien.Text = (total - total / 100 * (int)numericUpDown1.Value).ToString();
                numUDSoLuong.Maximum = product.Quantity;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            loadProduct();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if(!(OrderCurrent is null))
            {
                OrderDetail orderDetail = removeDetail();
                orderDetail.Quantity += (int)numUDSoLuong.Value;
                orderDetail.Quantity = (int)numUDSoLuong.Value;
                orderDetail.Discount = (int)numericUpDown1.Value;
                orderDetail.Price = float.Parse(txtDonGia.Text);
                orderDetail.Discount = (int)numericUpDown1.Value;
                OrderCurrent.OrderDetails.Add(orderDetail);
                loadOrderDetail(OrderCurrent);

            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            removeDetail();
        }
        private OrderDetail removeDetail()
        {
            OrderDetail orderDetail = OrderCurrent.OrderDetails.Where(od => od.ProductId == (int)cbxTenHang.SelectedValue).FirstOrDefault() ?? new OrderDetail()
            {
                ProductId = (int)cbxTenHang.SelectedValue,
            };
            OrderCurrent.OrderDetails.Remove(orderDetail);
            return orderDetail;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OrderCurrent.EmployeeId = (int)cbxTenNV.SelectedValue;
            OrderCurrent.CustomerId = (int)cbxTenKH.SelectedValue;
            _orderService.Insert(OrderCurrent);
            _orderService.setDraftOrder(OrderCurrent);
        }
    }
}
