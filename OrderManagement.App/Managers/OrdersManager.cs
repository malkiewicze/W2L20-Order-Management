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
        public OrdersManager()
        {
            _ordersService = new OrdersService();
        }

        public Order CreateNewOrder()
        {

            int LastId = _ordersService.GetLastId();
            int id = LastId + 1;
            Console.WriteLine($"Numer zlecenia: {id}");

            Console.WriteLine("Podaj imię i nazwisko Klienta: ");
            string input = Console.ReadLine();
            string name = input.ToUpper();


            Console.WriteLine("Podaj datę rozpoczęcia zlecenia: dd/mm/rrrr");
            var startDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Podaj datę zakończenia zlecenia: dd/mm/rrrr");
            var endDate = DateTime.Parse(Console.ReadLine());
            bool validDate = _ordersService.CheckEndDate(endDate, startDate);
            if (!validDate)
            {
                Console.WriteLine("Wprowadzona data zakończenia zlecenia nie może być wcześniejsza niż rozpoczęcia.");
            }

            TimeSpan duration = endDate - startDate;

            Console.WriteLine("Podaj adres zlecenia: miasto/ulica/numer domu");
            string orderAddress = Console.ReadLine();

            Console.WriteLine("Podaj dane kontaktowe:");
            string contact = Console.ReadLine();

            bool validPhoneNumber = _ordersService.CheckContactDetails(contact);
            if (!validPhoneNumber)
            {
                Console.WriteLine("Błędny format numeru telefonu.");
            }

            Console.WriteLine("Podaj szczegóły zlecenia:");
            string orderDescription = Console.ReadLine();

            Console.WriteLine("Podaj wartość zlecenia:");
            double orderValue = Double.Parse(Console.ReadLine());
            bool validValue = _ordersService.CheckValue(orderValue);
            if (!validValue)
            {
                Console.WriteLine("Wartość zlecenia musi być większa od zera.");
            }

            Console.WriteLine($"Podaj status zlecenia: \r\n 1. W kolejce \r\n 2.W realizacji \r\n 3.Zakończone");
            var operation = Int32.Parse(Console.ReadLine());
            string orderStatus = _ordersService.SetTheOrderStatus(operation); //czy tu nie zmienić logiki??
            Console.WriteLine($"{orderStatus}");

            Console.WriteLine("Podaj ilu pracowników wykonywało zlecenie:");
            int numberEmployees = Int32.Parse(Console.ReadLine());
            bool validEmployees = _ordersService.CheckEmployees(numberEmployees);
            if (!validEmployees)
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
            int id = Int32.Parse(Console.ReadLine());
            bool canceled = _ordersService.StatusToCancel(id);
            if (canceled)
            {
                Console.WriteLine($"Zlecenie numer: {id} zostało anulowane.");
            }
            return canceled;
        }

        public Order SearchOrder()
        {
            Console.WriteLine("Podaj numer zlecenia:");
            int id = Int32.Parse(Console.ReadLine());
            var searchedOrder = _ordersService.GetItemById(id);
            if (searchedOrder != null)
            {
                Console.WriteLine($"Numer zlecenia: {searchedOrder.Id}\r\n Data początkowa: {searchedOrder.StartDate}\r\n Data końcowa: {searchedOrder.EndDate}\r\n " +
                    $"Czas trwania zlecenia: {searchedOrder.Duration}\r\n Adres: {searchedOrder.Address}\r\n Dane kontakowe: {searchedOrder.ContactDetails}\r\n" +
                    $"Opis zlecenia: {searchedOrder.OrderDescription}\r\n Wartość zlecenia w zł: {searchedOrder.OrderValue}\r\n Status zlecenia: {searchedOrder.OrderStatus}\r\n " +
                    $"Ilość pracowników wykonujących zlecenie: {searchedOrder.NumberOfEmployees}");
            }
            return searchedOrder;
        }

    }
}
