using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.App.Abstract
{
    public interface IService<T>
    {

        List<T> Items { get; set; }
        List<T> GetAllItems();
        void AddNewItem(T obj);
        List<T> ShowItems();
        int GetLastId();
    }
}
