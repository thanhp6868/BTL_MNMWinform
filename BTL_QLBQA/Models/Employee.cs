using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BTL_QLBQA.Models
{
    public class Employee : User
    {

        public ICollection<Shift> Shifts { get; set; }

    }
}
