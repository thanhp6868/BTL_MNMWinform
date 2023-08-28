using BTL_QLBQA.ConstLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Models
{
    public class EmployeeSalary
    {
        public int Id { get; set; }
        public int ContractId { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public decimal ShiftSalary { get; set; }
        public decimal Bonus { get; set; }
        public decimal Fine { get; set; }
        public decimal Debit { get; set; }
        public decimal Insurance { get; set; }
        public decimal Total { get; set; }
        public decimal ActuallyReceived { get; set; }
        public EnumEmployeeSalary Status { get; set; }
        [ForeignKey("ContractId")]
        public Contract Contract { get; set; }
    }
}
