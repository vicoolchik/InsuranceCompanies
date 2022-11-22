using System;
using System.Collections.Generic;

#nullable disable

namespace DAL.Models
{
    public partial class Accident
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public int CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}
