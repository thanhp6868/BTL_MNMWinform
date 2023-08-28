using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Models
{
   public  class WarehouseArea
    {
        [Key]
        public int Id { get; set; }

        public String NameArea { get; set; }
        
        public int WareHouseId { get; set; }
       
        [ForeignKey("WareHouseId")]
        public WareHouse WareHouse { get; set; }
    }
}
