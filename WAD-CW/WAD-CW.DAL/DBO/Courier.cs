using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WAD_CW.DAL.DBO
{
    public class Courier
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string PhoneNum { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
