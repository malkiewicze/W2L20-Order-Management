using OrderManagement.App.Common;
using OrderManagement.App.Concrete;
using OrderManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using W2L20;

namespace OrderManagement.App.Managers
{
    public class FiltersManager
    {
        private FiltersService _filtersService;
        private OrdersService _ordersService;
        private List<Order> _ordersList;


        public FiltersManager(OrdersService ordersService)
        {
            _filtersService = new FiltersService();
            _ordersService = ordersService;
            _ordersList = _ordersService.GetAllItems();
        }

        public void ChooseFilter(ConsoleKeyInfo choosenFilter)
        {

            var filterNumber = choosenFilter;
            switch (filterNumber.KeyChar)
            {
                case '1':
                    var keyA = EnterNameFilter();
                    break;
                case '2':
                    var keyB = EnterStartDateFilter();
                    break;
                case '3':
                    var keyC = EnterEndDateFilter();
                    break;
                case '4':
                    var keyD = EnterDurationFilter();
                    break;
                case '5':
                    var keyE = EnterAdressFilter();
                    break;
                case '6':
                    var keyF = EnterValueFilter();
                    break;
                case '7':
                    var keyG = EnterStatusFilter();
                    break;
                case '8':
                    var keyH = EnterEmployeesFilter();
                    break;
                default:
                    Console.WriteLine("Wybrana operacja nie istnieje.");
                    break;
            }
        }

        public List<Order> EnterEmployeesFilter()
        {
            Console.WriteLine("Podaj filtr: Ilość pracowników wykonujących zlecenie");
            int employees = Int32.Parse(Console.ReadLine());
            var filterCriterion = "NumberOfEmployees";
            List<Order> resultList = _filtersService.FilterBy(filterCriterion, employees, _ordersList);
            ShowOrders(resultList);
            return resultList;
        }

        public List<Order> EnterStatusFilter()
        {
            Console.WriteLine("Podaj filtr: Status zlecenia");
            string status = Console.ReadLine();
            var filterCriterion = "OrderStatus";
            List<Order> resultList = _filtersService.FilterBy(filterCriterion, status, _ordersList);
            ShowOrders(resultList);
            return resultList;
        }

        public List<Order> EnterValueFilter()
        {
            Console.WriteLine("Podaj filtr: Wartość zlecenia");
            double value = Double.Parse(Console.ReadLine());
            var filterCriterion = "OrderValue";
            List<Order> resultList = _filtersService.FilterBy(filterCriterion, value, _ordersList);
            ShowOrders(resultList);
            return resultList;
        }

        public List<Order> EnterAdressFilter()
        {
            Console.WriteLine("Podaj filtr: Adres");
            string address = Console.ReadLine();
            var filterCriterion = "Address";
            List<Order> resultList = _filtersService.FilterBy(filterCriterion, address, _ordersList);
            ShowOrders(resultList);
            return resultList;
        }

        public List<Order> EnterDurationFilter()
        {
            Console.WriteLine("Podaj filtr: Czas trwania zlecenia");
            TimeSpan duration = TimeSpan.Parse(Console.ReadLine());
            var filterCriterion = "Duration";
            List<Order> resultList = _filtersService.FilterBy(filterCriterion, duration, _ordersList);
            ShowOrders(resultList);
            return resultList;
        }

        public List<Order> EnterEndDateFilter()
        {
            Console.WriteLine("Podaj filtr: Data końcowa");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            string filterCriterion = "EndDate";
            List<Order> resultList = _filtersService.FilterBy(filterCriterion, endDate, _ordersList);
            ShowOrders(resultList);
            return resultList;
        }

        public List<Order> EnterStartDateFilter()
        {
            Console.WriteLine("Podaj filtr: Data początkowa");
            DateTime startDate = DateTime.Parse(Console.ReadLine());
            string filterCriterion = "StartDate";
            List<Order> resultList = _filtersService.FilterBy(filterCriterion, startDate, _ordersList);
            ShowOrders(resultList);
            return resultList;
        }

        public List<Order> EnterNameFilter()
        {
            Console.WriteLine("Podaj filtr: Nazwa");
            string input = Console.ReadLine();
            string name = input.ToUpper();
            string filterCriterion = "Name";
            List<Order> resultList = _filtersService.FilterBy(filterCriterion, name, _ordersList);
            ShowOrders(resultList);
            return resultList;
        }

        public void ShowOrders(List<Order> orderList)
        {
            if (orderList == null)
            {
                Console.WriteLine("Lista zleceń spełniającuch podane kryteria jest pusta.");
            }
            else
            {
                foreach (var order in orderList)
                {
                    Console.WriteLine($"Numer zlecenia: {order.Id}\r\n Data początkowa: {order.StartDate}\r\n Data końcowa: {order.EndDate}\r\n " +
                         $"Czas trwania zlecenia: {order.Duration}\r\n Adres: {order.Address}\r\n Dane kontakowe: {order.ContactDetails}\r\n" +
                         $"Opis zlecenia: {order.OrderDescription}\r\n Wartość zlecenia w zł: {order.OrderValue}\r\n Status zlecenia: {order.OrderStatus}\r\n " +
                         $"Ilość pracowników wykonujących zlecenie: {order.NumberOfEmployees}");
                }
            }


        }

    }
}
