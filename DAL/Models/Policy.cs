using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Policy
    {
        public Policy()
        {
            PolicyHolders = new HashSet<PolicyHolder>();
        }

        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual ICollection<PolicyHolder> PolicyHolders { get; set; }
    }
}
