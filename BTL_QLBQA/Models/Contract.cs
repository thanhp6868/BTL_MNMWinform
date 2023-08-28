using BTL_QLBQA.ConstLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTL_QLBQA.Models
{
    public class Contract
    {
        
        public int Id { get; set; }
        public String Name { get; set; }
        public EnumContractType Type { get; set; }
        public EnumContractStatus Status{ get; set; }
        public EnumExpiryContract Expiry { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate{ get; set; }
    }
}
