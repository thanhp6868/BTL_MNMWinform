using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Models
{
    public class WarehouseAreaDetail
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int WarehouseAreaId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [ForeignKey("WarehouseAreaId")]
        public WarehouseArea WarehouseArea { get; set; }
        public int Quantity { get; set; }
    }
}
