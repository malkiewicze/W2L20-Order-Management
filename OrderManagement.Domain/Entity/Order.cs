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

        public Order()
        {

        }
        public Order(int id, string name, DateTime startDate, DateTime endDate, TimeSpan duration, string address, string contactDetails, string orderDescription,
            double orderValue, string orderStatus, int numberOfEmployees)
        {
            Id = id;
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            Address = address;
            Duration = duration;
            ContactDetails = contactDetails;
            OrderDescription = orderDescription;
            OrderValue = orderValue;
            OrderStatus = orderStatus;
            NumberOfEmployees = numberOfEmployees;

        }
    }


}
