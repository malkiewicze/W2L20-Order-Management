using OrderManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace W2L20
{
    public class FilterCriteria : BaseEntity
    {
        public FilterCriteria(int id, string name)
        {
            Id = id;
            Name = name;
        }



      }
}
