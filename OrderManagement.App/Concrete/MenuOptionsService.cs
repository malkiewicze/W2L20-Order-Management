using OrderManagement.App.Common;
using OrderManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Text;

namespace OrderManagement.App.Concrete
{
    public class MenuOptionsService : BaseService<MenuOption>
    {

        public MenuOptionsService()
        {
            Initialize();
        }

        private void Initialize()
        {
            AddNewItem(new MenuOption(1, "Add Order"));
            AddNewItem(new MenuOption(2, "Cancel Order"));
            AddNewItem(new MenuOption(3, "Search Order"));
            AddNewItem(new MenuOption(4, "Filter Orders"));
        }
    }
}
