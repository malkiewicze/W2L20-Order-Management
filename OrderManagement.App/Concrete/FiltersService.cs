using OrderManagement.App.Common;
using OrderManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;
using W2L20;

namespace OrderManagement.App.Concrete
{
    public class FiltersService : BaseService<FilterCriteria>
    {
        public FiltersService()
        {
            Initialize();
        }
        private void Initialize()
        {
            AddNewItem(new FilterCriteria(1, "Start date"));
            AddNewItem(new FilterCriteria(2, "End date"));
            AddNewItem(new FilterCriteria(3, "Duration"));
            AddNewItem(new FilterCriteria(4, "Address"));
            AddNewItem(new FilterCriteria(5, "Order Value"));
            AddNewItem(new FilterCriteria(6, "Order status"));
            AddNewItem(new FilterCriteria(7, "Number of employees"));

        }

        public void ChooseFilter(ConsoleKeyInfo choosenFilter, List<Order> orderList)
        {

            var filterNumber = choosenFilter;
            switch (filterNumber.KeyChar)
            {
                case '1':
                    var keyA = FilterByStartDate(orderList);
                    break;
                case '2':
                    var keyB = FilterByEndDate(orderList);
                    break;
                case '3':
                    var keyC = FilterByDuration(orderList);
                    break;
                case '4':
                    var keyD = FilterByAdress(orderList);
                    break;
                case '5':
                    var keyE = FilterByOrderValue(orderList);
                    break;
                case '6':
                    var keyF = FilterByOrderStatus(orderList);
                    break;
                case '7':
                    var keyG = FilterByNumOfEmployees(orderList);
                    break;
                default:
                    Console.WriteLine("Wybrana operacja nie istnieje.");
                    break;
            }
        }

        #region Filters

        public List<Order> FilterByStartDate(List<Order> orderList)
        {
            List<Order> orderByStartDate = new List<Order>();
            Console.WriteLine("Podaj filtr: data początkowa");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            foreach (Order order in orderList)
            {
                if (order.StartDate == startDate)
                {
                    orderByStartDate.Add(order);
                }
            }
            return orderByStartDate;
        }

        public List<Order> FilterByEndDate(List<Order> orderList)
        {
            List<Order> orderByEndDate = new List<Order>();
            Console.WriteLine("Podaj filtr: data końcowa");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            foreach (Order order in orderList)
            {
                if (order.StartDate == endDate)
                {
                    orderByEndDate.Add(order);
                }
            }
            return orderByEndDate;
        }

        public List<Order> FilterByDuration(List<Order> orderList)
        {
            List<Order> orderByDuration = new List<Order>();
            Console.WriteLine("Podaj filtr: czas trwania zlecenia");
            TimeSpan duration = TimeSpan.Parse(Console.ReadLine());
            foreach (Order order in orderList)
            {
                if (order.Duration == duration)
                {
                    orderByDuration.Add(order);
                }
            }
            return orderByDuration;
        }

        public List<Order> FilterByAdress(List<Order> orderList)
        {
            List<Order> orderByAdress = new List<Order>();
            Console.WriteLine("Podaj filtr: adres");
            string address = Console.ReadLine();
            foreach (Order order in orderList)
            {
                if (order.Address == address)
                {
                    orderByAdress.Add(order);
                }
            }
            return orderByAdress;
        }

        public List<Order> FilterByOrderValue(List<Order> orderList)
        {
            List<Order> orderByValue = new List<Order>();
            Console.WriteLine("Podaj filtr: wartość zlecenia");
            double orderValue = Double.Parse(Console.ReadLine());
            foreach (Order order in orderList)
            {
                if (order.OrderValue == orderValue)
                {
                    orderByValue.Add(order);
                }
            }
            return orderByValue;
        }

        public List<Order> FilterByOrderStatus(List<Order> orderList)
        {
            List<Order> orderByStatus = new List<Order>();
            Console.WriteLine("Podaj filtr: status zlecenia");
            string status = Console.ReadLine();
            foreach (Order order in orderList)
            {
                if (order.OrderStatus == status)
                {
                    orderByStatus.Add(order);
                }
            }
            return orderByStatus;
        }

        public List<Order> FilterByNumOfEmployees(List<Order> orderList)
        {
            List<Order> orderByNumOfEmp = new List<Order>();
            Console.WriteLine("Podaj filtr: wartość zlecenia");
            int numOfEmp = Int32.Parse(Console.ReadLine());
            foreach (Order order in orderList)
            {
                if (order.NumberOfEmployees == numOfEmp)
                {
                    orderByNumOfEmp.Add(order);
                }
            }
            return orderByNumOfEmp;
        }

        #endregion
    }
}