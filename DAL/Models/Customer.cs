using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Cars = new HashSet<Car>();
            PolicyHolders = new HashSet<PolicyHolder>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<PolicyHolder> PolicyHolders { get; set; }
    }
}
