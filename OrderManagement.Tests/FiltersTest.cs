using FluentAssertions;
using Moq;
using OrderManagement.App.Abstract;
using OrderManagement.App.Common;
using OrderManagement.App.Concrete;
using OrderManagement.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OrderManagement.Tests
{
    public class FiltersTest
    {
        [Fact]
        public void FilterByTest()
        {
            Order order1 = new Order(1, "Ania", new DateTime(2020, 11, 23), new DateTime(2020, 11, 30), new TimeSpan(7), "Katowice", "542355691", "malowanie", 900, "W realizacji", 2);
            Order order2 = new Order(2, "Zygmunt", new DateTime(2020, 11, 01), new DateTime(2020, 11, 14), new TimeSpan(13), "Bytom", "696778441", "kafelkowanie", 5000, "W realizacji", 3);
            Order order3 = new Order(3, "Dawid", new DateTime(2020, 11, 01), new DateTime(2020, 11, 10), new TimeSpan(9), "Katowice", "542355691", "gładzie", 2400, "W realizacji", 2);
            List<Order> listOrder = new List<Order>();
            listOrder.Add(order1);
            listOrder.Add(order2);
            listOrder.Add(order3);
            FiltersService service = new FiltersService();

            var result = service.FilterBy("Address", "Katowice", listOrder);

            result.Should().Contain(order1);
            result.Should().Contain(order3);
            result.Should().HaveCount(2);
        }

        [Fact]
        public void FilterByTestFailed()
        {
            Order order1 = new Order(2, "Zygmunt", new DateTime(2020, 11, 01), new DateTime(2020, 11, 14), new TimeSpan(13), "Bytom", "696778441", "kafelkowanie", 5000, "W realizacji", 3);
            Order order2 = new Order(3, "Dawid", new DateTime(2020, 11, 01), new DateTime(2020, 11, 10), new TimeSpan(9), "Katowice", "542355691", "gładzie", 2400, "W realizacji", 2);
            List<Order> listOrder1 = new List<Order>();
            listOrder1.Add(order1);
            listOrder1.Add(order2);
            FiltersService service = new FiltersService();

            Assert.Throws<NullReferenceException>(() => service.FilterBy("Name", "Daniel", listOrder1));
        }
    }
}
