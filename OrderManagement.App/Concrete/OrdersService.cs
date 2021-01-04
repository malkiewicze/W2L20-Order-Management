using Newtonsoft.Json;
using OrderManagement.App.Common;
using OrderManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace OrderManagement.App.Concrete
{
    public class OrdersService : BaseService<Order>
    {
        public void LoadFromFile()
        {
            string readText = File.ReadAllText(@"C:\Users\malki\source\repos\W2L20-Order-Management\Temp\startingList.txt");
            var files = JsonConvert.DeserializeObject<List<Order>>(readText);
            foreach(var file in files)
            {
                AddNewItem(file);
            }
            
        }
        public void SaveToFile()
        {
            List<Order> ordersList = GetAllItems();
            File.WriteAllText(@"C:\Users\malki\source\repos\W2L20-Order-Management\Temp\ordersList.txt",
                JsonConvert.SerializeObject(ordersList, Formatting.Indented));
        }

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
        public bool CheckChoosenOperation(int operation)
        {
            if (operation > 0 && operation < 4)
                return true;
            else
                return false;
        }

        public bool CheckEmployees(int numberEmployees)
        {
            if (numberEmployees <= 0)
                return false;
            else
                return true;
        }

        public bool StatusToCancel(Order orderToCancel)
        {
            if (orderToCancel.OrderStatus == "W realizacji" || orderToCancel.OrderStatus == "W kolejce")
            {
                orderToCancel.OrderStatus = "Anulowane";
                return true;
            }
            else
                return false;
        }

    }
}
