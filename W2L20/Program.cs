using OrderManagement.App.Concrete;
using OrderManagement.App.Managers;
using System;
using System.Collections.Generic;


namespace W2L20
{
    class Program
    {
        static void Main(string[] args)
        {

            MenuOptionsService menuOptionsList = new MenuOptionsService();
            FiltersService filtersService = new FiltersService();
            OrdersService ordersService = new OrdersService();
            OrdersManager ordersManager = new OrdersManager();
            var orderList = ordersService.GetAllItems();

            Console.WriteLine("Witaj w aplikacji do zarządzania zleceniami.");
            while (true)
            {
                Console.WriteLine("Wybierz co chcesz zrobić:");

                menuOptionsList.ShowItems();
                var operation = Console.ReadKey();
                switch (operation.KeyChar)
                {
                    case '1':
                        var key = ordersService.CreateNewOrder();
                        break;
                    case '2':
                        var key1 = ordersManager.CancelOrder(orderList);
                        break;
                    case '3':
                        var key2 = ordersManager.SearchOrder(orderList);
                        break;
                    case '4':
                        var key3 = filtersService.ShowItems();
                        var choosenFilter = Console.ReadKey();
                        filtersService.ChooseFilter(choosenFilter, orderList);
                        break;
                    default:
                        Console.WriteLine("Wybrana operacja nie istnieje.");
                        break;
                }

            }

        }

    }
}
