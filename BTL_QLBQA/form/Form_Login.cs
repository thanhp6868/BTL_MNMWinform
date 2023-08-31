using System;
using BTL_QLBQA.Services.AdminService;
using BTL_QLBQA.Services.BaseService;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using BTL_QLBQA.form;

namespace BTL_QLBQA
{
    public partial class Form_Login : Form
    {
        private IAdminService _adminService;
        public Form_Login()
        {
            _adminService = new AdminService();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

        private void bt_dangnhap_Click(object sender, EventArgs e)
        {
            //DialogResult tb = MessageBox.Show("Bạn đang cố gắng thoát khỏi chương trình này?", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //if (tb == DialogResult.Yes)
            //    this.Close();
            var u = _adminService.CheckLogin(txt_username.Text, txt_password.Text);
            if (u != null)
            {
                //co tai khoan
                Form_main_menu form = new Form_main_menu();
                form.Show();
                this.Hide();

            }
            else
            {
                //cut
                MessageBox.Show("Thong tin tai khoan hoac mat khau deo dung, thu lai!", "Thong bao");
            }
        }

        private void ck_showpass_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_showpass.Checked)
            {
                txt_password.UseSystemPasswordChar = true;
            }
            else txt_password.UseSystemPasswordChar = false;
        }

        private void Form_Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
