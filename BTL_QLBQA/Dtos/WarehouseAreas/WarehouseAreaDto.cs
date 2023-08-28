using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Dtos.WarehouseAreas
{
    public class WarehouseAreaDto
    {
        [DisplayName("Mã")]
        public int Id { get; set; }
        [DisplayName("Tên khu vực")]
        public string Name { get; set; }
    }
}
