using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_QLBQA.Models
{
    public class Product 
    {
       
        [Key]
        public int Id { get; set; }
        [DisplayName("Tên sản phẩm")]
        public string Name { get; set; }
        public float ImportPrice { get; set; }
        public float ExportPrice { get; set; }
        public int Quantity { get; set; }
        [System.ComponentModel.Browsable(false)]
        public int SupplierId { get; set; }
        [System.ComponentModel.Browsable(false)]
        public int ProductCategoryId { get; set; }
        [System.ComponentModel.Browsable(false)]
        public int UnitId { get; set; }
        public string Note { get; set; }
        [System.ComponentModel.Browsable(false)]
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
        [System.ComponentModel.Browsable(false)]
        [ForeignKey("ProductCategoryId")]
        public ProductCategory ProductCategory { get; set; }
        [System.ComponentModel.Browsable(false)]
        [ForeignKey("UnitId")]
        public Unit Unit { get; set; }
        
    }
}
