using Newtonsoft.Json;
using OrderManagement.App.Common;
using OrderManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            AddNewItem(new FilterCriteria(1, "Name"));
            AddNewItem(new FilterCriteria(2, "Start date"));
            AddNewItem(new FilterCriteria(3, "End date"));
            AddNewItem(new FilterCriteria(4, "Duration"));
            AddNewItem(new FilterCriteria(5, "Address"));
            AddNewItem(new FilterCriteria(6, "Order Value"));
            AddNewItem(new FilterCriteria(7, "Order status"));
            AddNewItem(new FilterCriteria(8, "Number of employees"));

        }

        public List<Order> FilterBy(string filterCriterion, object criterionValue, List<Order> ordersList)
        {
            List<Order> resultList = new List<Order>();
            foreach (Order item in ordersList)
            {
                var property = item.GetType().GetProperty(filterCriterion).GetValue(item);
                if (property.Equals(criterionValue))
                    resultList.Add(item);
            }
            if (resultList.Count() == 0)
            {
                throw new NullReferenceException("List is empty.");
            }
            else
                return resultList;
        }

        public void SaveReportToFile(List<Order> filteredList, string filterCriterion)
        {
            string fileName = filterCriterion;
            string creationDate = DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss-tt");

            File.WriteAllText(@"C:\Users\malki\source\repos\W2L20-Order-Management\Temp\" + fileName + @"_" + creationDate + @".txt",
                JsonConvert.SerializeObject(filteredList, Formatting.Indented));
        }
    }
}