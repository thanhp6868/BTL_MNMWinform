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
    public partial class uc_Donhang : UserControl
    {
        private static uc_Donhang ucDonHang;
        public static uc_Donhang Instance
        {
            get
            {
                if (ucDonHang == null)
                    ucDonHang = new uc_Donhang();
                return ucDonHang;
            }
        }
        public uc_Donhang()
        {
            InitializeComponent();
        }

    }
}
