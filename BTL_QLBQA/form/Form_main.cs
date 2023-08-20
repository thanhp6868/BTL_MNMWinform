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

        private void btn_Lop_Click(object sender, EventArgs e)
        {
            if (!pMain.Controls.Contains(uc_Product.Instance))
            {
                pMain.Controls.Add(uc_Product.Instance);
                uc_Product.Instance.Dock = DockStyle.Fill;
                uc_Product.Instance.BringToFront();
            }
            else uc_Product.Instance.BringToFront();
            //
            btn_Lop.BackColor = Color.DeepSkyBlue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!pMain.Controls.Contains(uc_NhaCungCap.Instance))
            {
                pMain.Controls.Add(uc_NhaCungCap.Instance);
                uc_NhaCungCap.Instance.Dock = DockStyle.Fill;
                uc_NhaCungCap.Instance.BringToFront();
            }
            else uc_Product.Instance.BringToFront();
            //
            button1.BackColor = Color.DeepSkyBlue;
        }

        private void btn_dangky_Click(object sender, EventArgs e)
        {
            if (!pMain.Controls.Contains(uc_NhanVien.Instance))
            {
                pMain.Controls.Add(uc_NhanVien.Instance);
                uc_NhanVien.Instance.Dock = DockStyle.Fill;
                uc_NhanVien.Instance.BringToFront();
            }
            else uc_NhanVien.Instance.BringToFront();
            //
            button1.BackColor = Color.DeepSkyBlue;
        }
    }
}
