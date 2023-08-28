using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Dtos.Shifts
{
    public class ShiftDto
    {
        [DisplayName("Mã")]
        public int Id { get; set; }
        [DisplayName("Tên ca")]
        public string Name { get; set; }
        [DisplayName("Giờ bắt đầu")]
        public float StartHour { get; set; }
        [DisplayName("Giờ kết thúc")]
        public float EndHour { get; set; }
        
    }
}
