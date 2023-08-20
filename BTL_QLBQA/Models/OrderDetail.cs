using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BTL_QLBQA.Models
{
    public class OrderDetail
    {
        [Key]
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public float Discount { get; set; }
        public float Price { get; set; }

        [ForeignKey("OrderId")]
        public Order Order { get; set; }
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public float GetTotal()
        {
            return Price * Quantity - Discount;
        }
    }
}
