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
        private OrdersService _ordersService;
        public OrdersManager(OrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        public Order CreateNewOrder()
        {

            int LastId = _ordersService.GetLastId();
            int id = LastId + 1;
            Console.WriteLine($"Numer zlecenia: {id}");

            Console.WriteLine("Podaj imię i nazwisko Klienta: ");
            string inputName = Console.ReadLine();
            string name = inputName.ToUpper();


            Console.WriteLine("Podaj datę rozpoczęcia zlecenia: dd/mm/rrrr");
            DateTime startDate;
            while (!DateTime.TryParse(Console.ReadLine(), out startDate))
            {
                Console.WriteLine("Podaj właściwy format daty");
            }

            Console.WriteLine("Podaj datę zakończenia zlecenia: dd/mm/rrrr");
            DateTime endDate;
            while (!DateTime.TryParse(Console.ReadLine(), out endDate) || !_ordersService.CheckEndDate(endDate, startDate))
            {
                Console.WriteLine("Wprowadź właściwy format daty. Pamiętaj, że data końcowa nie może być wcześniejsza niż początkowa.");
            }

            TimeSpan duration = endDate - startDate;

            Console.WriteLine("Podaj adres zlecenia: miasto/ulica/numer domu");
            string inputAddress = Console.ReadLine();
            string orderAddress = inputAddress.ToUpper();

            Console.WriteLine("Podaj dane kontaktowe:");
            string contact = Console.ReadLine();
            if (!_ordersService.CheckContactDetails(contact))
            {
                Console.WriteLine("Błędny format numeru telefonu. Podaj jeszcze raz:");
                contact = Console.ReadLine();
            }

            Console.WriteLine("Podaj szczegóły zlecenia:");
            string orderDescription = Console.ReadLine();

            Console.WriteLine("Podaj wartość zlecenia:");
            double orderValue;
            if (!Double.TryParse(Console.ReadLine(), out orderValue) || !_ordersService.CheckValue(orderValue))
            {
                Console.WriteLine("Wprowadź właściwą wartość zlecenia, która musi być większa od zera.");
            }

            Console.WriteLine($"Podaj status zlecenia: \r\n 1. W kolejce \r\n 2.W realizacji \r\n 3.Zakończone");
            int operation;
            if (!Int32.TryParse(Console.ReadLine(), out operation) || !_ordersService.CheckChoosenOperation(operation))
            {
                Console.WriteLine("Podaj właściwy numer operacji: 1, 2 lub 3.");
            }
            string orderStatus = _ordersService.SetTheOrderStatus(operation);
            Console.WriteLine($"{orderStatus}");

            Console.WriteLine("Podaj ilu pracowników wykonywało zlecenie:");
            int numberEmployees;
            if (!Int32.TryParse(Console.ReadLine(), out numberEmployees) || !_ordersService.CheckEmployees(numberEmployees))
            {
                Console.WriteLine("Liczba pracowników musi być większa od 0!");
            }

            Order order = new Order(id, name, startDate, endDate, duration, orderAddress, contact, orderDescription, orderValue, orderStatus, numberEmployees);
            _ordersService.AddNewItem(order);

            return order;
        }

        public bool CancelOrder()
        {
            Console.WriteLine("Podaj numer zlecenia do anulowania:");
            int id;
            if (!Int32.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Podany format numeru zlecenia jest niewłaściwy.");
            }

            Order orderToCancel = _ordersService.GetItemById(id);
            if (orderToCancel != null)
            {
                if (_ordersService.StatusToCancel(orderToCancel))
                {
                    Console.WriteLine($"Zlecenie numer: {id} zostało anulowane.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"Nie można anulować tego zlecenia, gdyż jego status to {orderToCancel.OrderStatus}.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"Zlecenie o numerze {id} nie istnieje.");
                return false;
            }
        }

        public Order SearchOrder()
        {
            Console.WriteLine("Podaj numer zlecenia:");
            int id;
            if (!Int32.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Podany format numeru zlecenia jest niewłaściwy.");
            }
            var searchedOrder = _ordersService.GetItemById(id);
            if (searchedOrder != null)
            {
                Console.WriteLine($"Numer zlecenia: {searchedOrder.Id}\r\n Data początkowa: {searchedOrder.StartDate}\r\n Data końcowa: {searchedOrder.EndDate}\r\n " +
                    $"Czas trwania zlecenia: {searchedOrder.Duration}\r\n Adres: {searchedOrder.Address}\r\n Dane kontakowe: {searchedOrder.ContactDetails}\r\n" +
                    $"Opis zlecenia: {searchedOrder.OrderDescription}\r\n Wartość zlecenia w zł: {searchedOrder.OrderValue}\r\n Status zlecenia: {searchedOrder.OrderStatus}\r\n " +
                    $"Ilość pracowników wykonujących zlecenie: {searchedOrder.NumberOfEmployees}");
            }
            else
            {
                Console.WriteLine($"Zlecenie o numerze {id} nie istnieje.");

            }
            return searchedOrder;
        }

    }
}
