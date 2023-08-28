using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_QLBQA.Models
{
    public class WareHouse
    {

        [Key]
        public int Id { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }
        public ICollection <WarehouseArea> WarehouseAreas { get; set; }


    }
}
