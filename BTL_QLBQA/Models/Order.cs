
using BTL_QLBQA.Components;
using BTL_QLBQA.ConstLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace BTL_QLBQA.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; } = StringHelper.RandomString();
        public string Note { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int? CouponId{ get; set; }
        public EnumOrder Status { get; set; }
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        public float Total { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        [ForeignKey("CouponId")]
        public Coupon Coupon{ get; set; }

        [ForeignKey("CustomerId")]
        public Customer Customer{ get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
