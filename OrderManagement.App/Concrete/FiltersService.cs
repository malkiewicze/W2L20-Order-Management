using OrderManagement.App.Common;
using OrderManagement.Domain.Entity;
using System.Collections.Generic;
using W2L20;
using OrderManagement.App.Managers;

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

            AddNewItem(new FilterCriteria(1, "Name"));
            AddNewItem(new FilterCriteria(2, "Start date"));
            AddNewItem(new FilterCriteria(3, "End date"));
            AddNewItem(new FilterCriteria(4, "Duration"));
            AddNewItem(new FilterCriteria(5, "Address"));
            AddNewItem(new FilterCriteria(6, "Order Value"));
            AddNewItem(new FilterCriteria(7, "Order status"));
            AddNewItem(new FilterCriteria(8, "Number of employees"));

        }

                
        public List<Order> FilterBy(string filterCriterion, object criterionValue, List<Order> orderList)
        {
            List<Order> resultList = new List<Order>();
            foreach (Order item in orderList)
            {
                var property = item.GetType().GetProperty(filterCriterion).GetValue(item);
                if (property == criterionValue)
                    resultList.Add(item);
            }
            return resultList;
        }


        //public List<Order> FilterByEndDate(DateTime endDate, List<Order> orderList)
        //{
        //    List<Order> orderByEndDate = new List<Order>();
        //    foreach (Order order in orderList)
        //    {
        //        if (order.StartDate == endDate)
        //            orderByEndDate.Add(order);
        //    }
        //    return orderByEndDate;
        //}

        //public List<Order> FilterByDuration(TimeSpan duration, List<Order> orderList)
        //{
        //    List<Order> orderByDuration = new List<Order>();
        //    foreach (Order order in orderList)
        //    {
        //        if (order.Duration == duration)
        //            orderByDuration.Add(order);
        //    }
        //    return orderByDuration;
        //}

        //public List<Order> FilterByAdress(List<Order> orderList)
        //{
        //    List<Order> orderByAdress = new List<Order>();
        //    Console.WriteLine("Podaj filtr: adres");
        //    string address = Console.ReadLine();
        //    foreach (Order order in orderList)
        //    {
        //        if (order.Address == address)
        //        {
        //            orderByAdress.Add(order);
        //        }
        //    }
        //    return orderByAdress;
        //}

        //public List<Order> FilterByOrderValue(List<Order> orderList)
        //{
        //    List<Order> orderByValue = new List<Order>();
        //    Console.WriteLine("Podaj filtr: wartość zlecenia");
        //    double orderValue = Double.Parse(Console.ReadLine());
        //    foreach (Order order in orderList)
        //    {
        //        if (order.OrderValue == orderValue)
        //        {
        //            orderByValue.Add(order);
        //        }
        //    }
        //    return orderByValue;
        //}

        //public List<Order> FilterByOrderStatus(List<Order> orderList)
        //{
        //    List<Order> orderByStatus = new List<Order>();
        //    Console.WriteLine("Podaj filtr: status zlecenia");
        //    string status = Console.ReadLine();
        //    foreach (Order order in orderList)
        //    {
        //        if (order.OrderStatus == status)
        //        {
        //            orderByStatus.Add(order);
        //        }
        //    }
        //    return orderByStatus;
        //}

        //public List<Order> FilterByNumOfEmployees(List<Order> orderList)
        //{
        //    List<Order> orderByNumOfEmp = new List<Order>();
        //    Console.WriteLine("Podaj filtr: wartość zlecenia");
        //    int numOfEmp = Int32.Parse(Console.ReadLine());
        //    foreach (Order order in orderList)
        //    {
        //        if (order.NumberOfEmployees == numOfEmp)
        //        {
        //            orderByNumOfEmp.Add(order);
        //        }
        //    }
        //    return orderByNumOfEmp;
        //}

    }
}