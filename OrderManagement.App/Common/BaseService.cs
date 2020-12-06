using OrderManagement.App.Abstract;
using OrderManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace OrderManagement.App.Common
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {
        public List<T> Items { get; set; }

        public BaseService()
        {
            Items = new List<T>();
        }

        public void AddNewItem(T obj)
        {
            Items.Add(obj);
        }

        public List<T> GetAllItems()
        {
            return Items;
        }

        public  List<T> ShowItems()
        {
            foreach (var obj in Items)
            {
                Console.WriteLine($"{obj.Id}. {obj.Name}");
            }
            return Items;
        }

        public int GetLastId()
        {
            int lastId;
            if (Items.Any())
            {
                lastId = Items.OrderBy(p => p.Id).LastOrDefault().Id;
            }
            else
            {
                lastId = 0;
            }
            return lastId;
        }

        public T GetItemById(int id)
        {
            T item = Items.Find(x => x.Id == id);
            if (item == null)
            {
                throw new NullReferenceException("Choosen item is null.");
            }
            else
                return item;
        }

    }
}
