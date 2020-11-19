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
        private List<Order> orderList;

        public FiltersManager()
        {
            _filtersService = new FiltersService();
            _ordersService = new OrdersService();
            orderList = _ordersService.GetAllItems();
        }

        public void ChooseFilter(ConsoleKeyInfo choosenFilter, List<Order> orderList)
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

        private object EnterEmployeesFilter()
        {
            throw new NotImplementedException();
        }

        private object EnterStatusFilter()
        {
            throw new NotImplementedException();
        }

        private object EnterValueFilter()
        {
            throw new NotImplementedException();
        }

        private object EnterAdressFilter()
        {
            throw new NotImplementedException();
        }

        private object EnterDurationFilter()
        {
            throw new NotImplementedException();
        }

        private object EnterEndDateFilter()
        {
            throw new NotImplementedException();
        }

        private object EnterStartDateFilter()
        {
            Console.WriteLine("Podaj filtr: Data początkowa");
            DateTime endDate = DateTime.Parse(Console.ReadLine());
            string filterCriterion = "StartDate";
            List<Order> resultList = _filtersService.FilterBy(filterCriterion, endDate, orderList);
            return resultList;
        }

        public List<Order> EnterNameFilter()
        {
            Console.WriteLine("Podaj filtr: Nazwa");
            string input = Console.ReadLine();
            string name = input.ToUpper();
            string filterCriterion = "Name";
            List<Order> resultList = _filtersService.FilterBy(filterCriterion, name, orderList);
            return resultList;
        }



        //public List<Order> EnterDurationFilter()
        //{
        //    Console.WriteLine("Podaj filtr: czas trwania zlecenia");
        //    TimeSpan duration = TimeSpan.Parse(Console.ReadLine());
        //    var filterCriterion = "Duration";

        //    var resultList = _filtersService.FilterBy(filterCriterion, duration, _orderList);
        //    return resultList;
        //}

        //private List<Order> EnterEndDateFilter()
        //{
        //    Console.WriteLine("Podaj filtr: data początkowa");
        //    DateTime endDate = DateTime.Parse(Console.ReadLine());
        //    var resultList = _filtersService.FilterByEndDate(endDate, _orderList);
        //    return resultList;
        //}

        //private List<Order> EnterStartDateFilter()
        //{
        //    Console.WriteLine("Podaj filtr: data początkowa");
        //    DateTime startDate = DateTime.Parse(Console.ReadLine());
        //    var resultList = _filtersService.FilterByStartDate(startDate, _orderList);
        //    return resultList;
        //}
    }
}
