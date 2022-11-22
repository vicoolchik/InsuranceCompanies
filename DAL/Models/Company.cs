using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Company
    {
        public Company()
        {
            Policies = new HashSet<Policy>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Policy> Policies { get; set; }
    }
}
