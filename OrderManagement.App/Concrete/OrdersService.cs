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
        public Order CreateNewOrder()
        {
            Order order = new Order();

            order.Id = SetTheOrderNumber();

            order.Name = SetName();

            order.StartDate = SetTheStartDate();

            order.EndDate = SetTheEndDate(order);

            order.Address = SetTheAddress();

            order.ContactDetails = SetTheContactDetails(order);

            order.OrderDescription = SetTheDescription();

            order.OrderValue = SetTheOrderValue();

            order.OrderStatus = SetTheOrderStatus();

            order.NumberOfEmployees = SetEmployees();

            order.Duration = order.EndDate - order.StartDate;

            Items.Add(order);

            return order;
        }


        private int SetTheOrderNumber()
        {
            int orderNum = GetLastId();
            orderNum = orderNum + 1;
            Console.WriteLine($"Numer zlecenia: {orderNum}");
            return orderNum;
        }

        private string SetName()
        {
            Console.WriteLine("Podaj imię i nazwisko Klienta: ");
            string name = Console.ReadLine();
            return name;
        }


        private DateTime SetTheStartDate()
        {
            Console.WriteLine("Podaj datę rozpoczęcia zlecenia: dd/mm/rrrr");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            return startDate;
        }


        private DateTime SetTheEndDate(Order order)
        {
            Console.WriteLine("Podaj datę zakończenia zlecenia: dd/mm/rrrr");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            if (endDate < order.StartDate)
            {
                Console.WriteLine("Wprowadzona data zakończenia zlecenia nie może być wcześniejsza niż rozpoczęcia.");
            }
            else
            {
                order.EndDate = endDate;
            }
            return endDate;
        }

        private string SetTheAddress()
        {
            Console.WriteLine("Podaj adres zlecenia: miasto/ulica/numer domu");
            string orderAddress = Console.ReadLine();
            return orderAddress;
        }


        private string SetTheContactDetails(Order order)
        {
            string pattern = @"(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)";
            Console.WriteLine("Podaj dane kontaktowe:");
            string contact = Console.ReadLine();
            Regex regexNum = new Regex(pattern);
            if (regexNum.IsMatch(contact))
            {
                order.ContactDetails = contact;
            }
            else
            {
                Console.WriteLine("Błędny format numeru telefonu.");
            }
            return contact;
        }


        private string SetTheDescription()
        {
            Console.WriteLine("Podaj szczegóły zlecenia:");
            string orderDetails = Console.ReadLine();
            return orderDetails;
        }


        private double SetTheOrderValue()
        {
            Console.WriteLine("Podaj wartość zlecenia:");
            double orderValue = Double.Parse(Console.ReadLine());
            if (orderValue <= 0)
            {
                Console.WriteLine("Wartość zlecenia musi być większa od 0.");
            }
            return orderValue;
        }


        private string SetTheOrderStatus()
        {
            string[] status = new string[3] { "W kolejce", "W realizacji", "Zakończone" };
            string orderStatus;
            Console.WriteLine($"Podaj status zlecenia: \r\n 1. W kolejce \r\n 2.W realizacji \r\n 3.Zakończone");
            var operation = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < status.Length; i++)
            {
                var z = i + 1;
                if (operation == z)
                {
                    orderStatus = status[i];
                    Console.WriteLine($"{status[i]}");
                    return orderStatus;
                }
            }
            return "Error";

        }


        private int SetEmployees()
        {
            Console.WriteLine("Podaj ilu pracowników wykonywało zlecenie:");
            int numberEmployees = Int32.Parse(Console.ReadLine());
            if (numberEmployees <= 0)
            {
                Console.WriteLine("Liczba pracowników musi być większa od 0!");
            }
            return numberEmployees;

        }


    }
}
