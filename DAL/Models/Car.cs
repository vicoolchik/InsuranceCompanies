using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Car
    {
        public Car()
        {
            Accidents = new HashSet<Accident>();
        }

        public int Id { get; set; }
        public string CarNumber { get; set; }
        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Accident> Accidents { get; set; }
    }
}
