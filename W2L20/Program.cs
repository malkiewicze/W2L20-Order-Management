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
            OrdersService ordersService = new OrdersService();
            FiltersService filtersService = new FiltersService();
            OrdersManager ordersManager = new OrdersManager(ordersService);
            FiltersManager filtersManager = new FiltersManager(ordersService);
            ordersService.LoadFromFile();

            Console.WriteLine("Witaj w aplikacji do zarządzania zleceniami.");
            while (true)
            {

                Console.WriteLine("Wybierz co chcesz zrobić:");

                menuOptionsList.ShowItems();
                var operation = Console.ReadKey();
                switch (operation.KeyChar)
                {
                    case '1':
                        var key = ordersManager.CreateNewOrder();
                        break;
                    case '2':
                        var key1 = ordersManager.CancelOrder();
                        break;
                    case '3':
                        var key2 = ordersManager.SearchOrder();
                        break;
                    case '4':
                        var key3 = filtersService.ShowItems();
                        var choosenFilter = Console.ReadKey();
                        filtersManager.ChooseFilter(choosenFilter);
                        break;
                    default:
                        Console.WriteLine("Wybrana operacja nie istnieje.");
                        break;
                }

            }

        }

    }
}
