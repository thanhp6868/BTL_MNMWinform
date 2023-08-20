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
            btn_sinhvien.BackColor = Color.LightBlue;
            btn_diem.BackColor = Color.LightBlue;
            btn_dangky.BackColor = Color.LightBlue;
            btn_hocphan.BackColor = Color.LightBlue;
        }
    }
}
