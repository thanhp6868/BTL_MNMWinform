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
    public partial class Form_main_menu : Form
    {
        public Form_main_menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_main form = new Form_main();
            form.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_BanHang form = new Form_BanHang();
            form.ShowDialog();
            this.Hide();
        }

        private void Form_main_menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}
