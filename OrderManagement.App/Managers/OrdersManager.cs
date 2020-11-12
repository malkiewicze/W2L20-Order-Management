using OrderManagement.App.Common;
using OrderManagement.App.Concrete;
using OrderManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.App.Managers
{
    public class OrdersManager
    {
        public Order CancelOrder(List<Order> Items)
        {
            Console.WriteLine("Podaj numer zlecenia do anulowania:");
            int id = Int32.Parse(Console.ReadLine());
            Order canceledOrder = Items.Find(x => x.OrderStatus == "w realizacji" || x.OrderStatus == "w kolejce");
            if (canceledOrder.Id == id)
            {
                canceledOrder.OrderStatus = "anulowane";
                Console.WriteLine($"Zlecenie numer: {canceledOrder.Id} zostało anulowane.");
            }

            return canceledOrder;
        }

        public Order SearchOrder(List<Order> Items)
        {
            Console.WriteLine("Podaj numer zlecenia:");
            int id = Int32.Parse(Console.ReadLine());
            Order searchedOrder = Items.Find(x => x.Id == id);
            if (searchedOrder != null)
            {

                Console.WriteLine($"Numer zlecenia: {searchedOrder.Id}\r\n Data początkowa: {searchedOrder.StartDate}\r\n Data końcowa: {searchedOrder.EndDate}\r\n Czas trwania zlecenia: {searchedOrder.Duration}\r\n Adres: {searchedOrder.Address}\r\n" +
                $"Dane kontakowe: {searchedOrder.ContactDetails}\r\n Opis zlecenia: {searchedOrder.OrderDescription}\r\n Wartość zlecenia w zł: {searchedOrder.OrderValue}\r\n Status zlecenia: {searchedOrder.OrderStatus}\r\n Ilość pracowników wykonujących zlecenie: {searchedOrder.NumberOfEmployees}");
            }

            return searchedOrder;
        }

    }
}
