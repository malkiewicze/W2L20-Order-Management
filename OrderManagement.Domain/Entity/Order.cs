using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Domain.Entity
{
    public class Order : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan Duration { get; set; }
        public string Address { get; set; }
        public string ContactDetails { get; set; }
        public string OrderDescription { get; set; }
        public double OrderValue { get; set; }
        public string OrderStatus { get; set; }
        public int NumberOfEmployees { get; set; }
    }
}
