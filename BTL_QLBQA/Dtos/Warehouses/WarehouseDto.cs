using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Dtos.Warehouse
{
    public class WarehouseDto
    {

        [DisplayName("Mã kho")]
        public int Id { get; set; }
        [DisplayName("Tên kho")]
        public string Name { get; set; }
    }
}
