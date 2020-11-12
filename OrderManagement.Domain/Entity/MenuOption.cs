using OrderManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagement.Domain.Entity
{
    public class MenuOption : BaseEntity
    {
        public MenuOption(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
