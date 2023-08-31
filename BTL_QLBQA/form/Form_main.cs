using BTL_QLBQA.User_control;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_QLBQA.form
{
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();
        }

        private void Form_main_Load(object sender, EventArgs e)
        {

        }

        private void sảnPhẩmToolStripMenuItem2_Click(object sender, EventArgs e)
        {

            if (!pMain.Controls.Contains(uc_Product.Instance))
            {
                pMain.Controls.Add(uc_Product.Instance);
                uc_Product.Instance.Dock = DockStyle.Fill;
                uc_Product.Instance.BringToFront();
            }
            else uc_Product.Instance.BringToFront();
        }

        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pMain.Controls.Contains(uc_NhaCungCap.Instance))
            {
                pMain.Controls.Add(uc_NhaCungCap.Instance);
                uc_NhaCungCap.Instance.Dock = DockStyle.Fill;
                uc_NhaCungCap.Instance.BringToFront();
            }
            else uc_NhaCungCap.Instance.BringToFront();
        }

        private void quảnLýNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pMain.Controls.Contains(uc_NhanVien.Instance))
            {
                pMain.Controls.Add(uc_NhanVien.Instance);
                uc_NhanVien.Instance.Dock = DockStyle.Fill;
                uc_NhanVien.Instance.BringToFront();
            }
            else uc_NhanVien.Instance.BringToFront();
        }

        private void khoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pMain.Controls.Contains(uc_KhachHang.Instance))
            {
                pMain.Controls.Add(uc_KhachHang.Instance);
                uc_KhachHang.Instance.Dock = DockStyle.Fill;
                uc_KhachHang.Instance.BringToFront();
            }
            else uc_KhachHang.Instance.BringToFront();
        }

        private void khoToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void caLàmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pMain.Controls.Contains(ShiftManagement.Instance))
            {
                pMain.Controls.Add(ShiftManagement.Instance);
                ShiftManagement.Instance.Dock = DockStyle.Fill;
                ShiftManagement.Instance.BringToFront();
            }
            else ShiftManagement.Instance.BringToFront();
        }

        private void lươngNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void khoToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!pMain.Controls.Contains(uc_Warehouse.Instance))
            {
                pMain.Controls.Add(uc_Warehouse.Instance);
                uc_Warehouse.Instance.Dock = DockStyle.Fill;
                uc_Warehouse.Instance.BringToFront();
            }
            else uc_Warehouse.Instance.BringToFront();
        }

        private void loạiSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pMain.Controls.Contains(uc_Category.Instance))
            {
                pMain.Controls.Add(uc_Category.Instance);
                uc_Category.Instance.Dock = DockStyle.Fill;
                uc_Category.Instance.BringToFront();
            }
            else uc_Category.Instance.BringToFront();
        }

        private void đơnVịSảnPhẩmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!pMain.Controls.Contains(uc_Unit.Instance))
            {
                pMain.Controls.Add(uc_Unit.Instance);
                uc_Unit.Instance.Dock = DockStyle.Fill;
                uc_Unit.Instance.BringToFront();
            }
            else uc_Unit.Instance.BringToFront();
        }

        private void Form_main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Form_main_menu form = new Form_main_menu();
            form.Show();
        }



        //private void btn_SanPham_Click(object sender, EventArgs e)
        //{
        //    if (!pMain.Controls.Contains(uc_Product.Instance))
        //    {
        //        pMain.Controls.Add(uc_Product.Instance);
        //        uc_Product.Instance.Dock = DockStyle.Fill;
        //        uc_Product.Instance.BringToFront();
        //    }
        //    else uc_Product.Instance.BringToFront();
        //    //
        //    btn_SanPham.BackColor = Color.DarkSeaGreen;
        //    btn_DonHang.BackColor = Color.LightGreen;
        //    btn_KhachHang.BackColor = Color.LightGreen;
        //    btn_NhanVien.BackColor = Color.LightGreen;
        //    btn_PhanQuyen.BackColor = Color.LightGreen;
        //    btn_Supplier.BackColor = Color.LightGreen;
        //    btn_Warehouse.BackColor = Color.LightGreen;
        //    btn_DoanhThu.BackColor = Color.LightGreen;
        //    btn_Luong.BackColor = Color.LightGreen;

        //}

        //private void btn_DonHang_Click(object sender, EventArgs e)
        //{
        //    if (!pMain.Controls.Contains(uc_Donhang.Instance))
        //    {
        //        pMain.Controls.Add(uc_Donhang.Instance);
        //        uc_Donhang.Instance.Dock = DockStyle.Fill;
        //        uc_Donhang.Instance.BringToFront();
        //    }
        //    else uc_Donhang.Instance.BringToFront();
        //    //
        //    btn_DonHang.BackColor = Color.DarkSeaGreen;
        //    btn_SanPham.BackColor = Color.LightGreen;
        //    btn_KhachHang.BackColor = Color.LightGreen;
        //    btn_NhanVien.BackColor = Color.LightGreen;
        //    btn_PhanQuyen.BackColor = Color.LightGreen;
        //    btn_Supplier.BackColor = Color.LightGreen;
        //    btn_Warehouse.BackColor = Color.LightGreen;
        //    btn_DoanhThu.BackColor = Color.LightGreen;
        //    btn_Luong.BackColor = Color.LightGreen;
        //}

        //private void btn_KhachHang_Click(object sender, EventArgs e)
        //{
        // 
        //    //
        //    btn_Supplier.BackColor = Color.LightGreen;
        //    btn_SanPham.BackColor = Color.LightGreen;
        //    btn_DonHang.BackColor = Color.LightGreen;
        //    btn_KhachHang.BackColor = Color.DarkSeaGreen;
        //    btn_NhanVien.BackColor = Color.LightGreen;
        //    btn_PhanQuyen.BackColor = Color.LightGreen;
        //    btn_Warehouse.BackColor = Color.LightGreen;
        //    btn_DoanhThu.BackColor = Color.LightGreen;
        //    btn_Luong.BackColor = Color.LightGreen;
        //}

        //private void Form_main_FormClosed(object sender, FormClosedEventArgs e)
        //{

        //    Form_main_menu form = new Form_main_menu();
        //    form.Show();
        //}

        //private void btn_Supplier_Click(object sender, EventArgs e)
        //{

        //    if (!pMain.Controls.Contains(uc_NhaCungCap.Instance))
        //    {
        //        pMain.Controls.Add(uc_NhaCungCap.Instance);
        //        uc_NhaCungCap.Instance.Dock = DockStyle.Fill;
        //        uc_NhaCungCap.Instance.BringToFront();
        //    }
        //    else uc_Product.Instance.BringToFront();
        //    //
        //    btn_Supplier.BackColor = Color.DarkSeaGreen;
        //    btn_SanPham.BackColor = Color.LightGreen;
        //    btn_DonHang.BackColor = Color.LightGreen;
        //    btn_KhachHang.BackColor = Color.LightGreen;
        //    btn_NhanVien.BackColor = Color.LightGreen;
        //    btn_PhanQuyen.BackColor = Color.LightGreen;
        //    btn_Warehouse.BackColor = Color.LightGreen;
        //    btn_DoanhThu.BackColor = Color.LightGreen;
        //    btn_Luong.BackColor = Color.LightGreen;
        //}

        //private void btn_NhanVien_Click(object sender, EventArgs e)
        //{
        //  
        //    //
        //    btn_NhanVien.BackColor = Color.DarkSeaGreen;
        //    btn_SanPham.BackColor = Color.LightGreen;
        //    btn_DonHang.BackColor = Color.LightGreen;
        //    btn_KhachHang.BackColor = Color.LightGreen;
        //    btn_PhanQuyen.BackColor = Color.LightGreen;
        //    btn_Supplier.BackColor = Color.LightGreen;
        //    btn_Warehouse.BackColor = Color.LightGreen;
        //    btn_DoanhThu.BackColor = Color.LightGreen;
        //    btn_Luong.BackColor = Color.LightGreen;
        //}

        //private void btn_PhanQuyen_Click(object sender, EventArgs e)
        //{

        //    if (!pMain.Controls.Contains(uc_PhanQuyen.Instance))
        //    {
        //        pMain.Controls.Add(uc_PhanQuyen.Instance);
        //        uc_PhanQuyen.Instance.Dock = DockStyle.Fill;
        //        uc_PhanQuyen.Instance.BringToFront();
        //    }
        //    else uc_PhanQuyen.Instance.BringToFront();
        //    //
        //    btn_PhanQuyen.BackColor = Color.DarkSeaGreen;
        //    btn_SanPham.BackColor = Color.LightGreen;
        //    btn_DonHang.BackColor = Color.LightGreen;
        //    btn_NhanVien.BackColor = Color.LightGreen;
        //    btn_KhachHang.BackColor = Color.LightGreen;
        //    btn_Supplier.BackColor = Color.LightGreen;
        //    btn_Warehouse.BackColor = Color.LightGreen;
        //    btn_DoanhThu.BackColor = Color.LightGreen;
        //    btn_Luong.BackColor = Color.LightGreen;
        //}
        //private void btn_thoat_Click(object sender, EventArgs e)
        //{
        //    Form_main_menu form = new Form_main_menu();
        //    form.ShowDialog();
        //}

    }
}
