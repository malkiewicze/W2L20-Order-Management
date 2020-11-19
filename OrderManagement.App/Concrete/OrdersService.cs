using OrderManagement.App.Common;
using OrderManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OrderManagement.App.Concrete
{
    public class OrdersService : BaseService<Order>
    {
        
        public bool CheckEndDate(DateTime endDate, DateTime startDate)
        {
            if (endDate < startDate)
                return false;
            else
                return true;
        }

        public bool CheckContactDetails(string contact)
        {
            string pattern = @"(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)";
            Regex regexNum = new Regex(pattern);
            if (regexNum.IsMatch(contact))
                return true;
            else

                return false;
        }

        public bool CheckValue(double value)
        {
            if (value <= 0)
                return false;
            else
                return true;
        }

        public string SetTheOrderStatus(int operation)
        {
            string[] status = new string[3] { "W kolejce", "W realizacji", "Zakończone" };
            string orderStatus;
            for (int i = 0; i < status.Length; i++)
            {
                var z = i + 1;
                if (operation == z)
                {
                    orderStatus = status[i];
                    return orderStatus;
                }
            }
            return "Error";

        }

        public bool CheckEmployees(int numberEmployees)
        {
            if (numberEmployees <= 0)
                return false;
            else
                return true;
        }

        public bool StatusToCancel(int id)
        {
            Order canceledOrder = GetItemById(id);
            if (canceledOrder.OrderStatus == "W realizacji" || canceledOrder.OrderStatus == "W kolejce")
            {
                canceledOrder.OrderStatus = "Anulowane";
                return true;
            }
            else
                return false;
        }

    }
}
