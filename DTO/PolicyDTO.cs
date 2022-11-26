using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class PolicyDTO
    {

        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime EndDate { get; set; }
        public int CompanyId { get; set; }
        //public virtual CompanyDTO Company { get; set; }
        //public string CompanyName { get; set; }

        public override string ToString()
        {
            return $"|{Id,-3}|{IssuedDate,-30}|{EndDate,-30}|{Price,-10}|";
        }
    }
}
