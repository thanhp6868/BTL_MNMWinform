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
    public partial class uc_PhanQuyen : UserControl
    {
        public uc_PhanQuyen()
        {
            InitializeComponent();
        }
        private static uc_PhanQuyen ucPhanQuyen;
        public static uc_PhanQuyen Instance
        {
            get
            {
                if (ucPhanQuyen == null)
                    ucPhanQuyen = new uc_PhanQuyen();
                return ucPhanQuyen;
            }
        }
    }
}
