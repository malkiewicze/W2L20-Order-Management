using FluentAssertions;
using Moq;
using OrderManagement.App.Abstract;
using OrderManagement.App.Common;
using OrderManagement.App.Concrete;
using OrderManagement.App.Managers;
using OrderManagement.Domain.Entity;
using System;
using Xunit;

namespace OrderManagement.Tests
{
    public class OrdersTests
    {
        [Fact]
        public void GetOrderByIdTest()
        {
            //Arrange
            Order order = new Order(1, "Ania", new DateTime(2020, 11, 23), new DateTime(2020, 11, 30), new TimeSpan(7), "Katowice", "542355691", "malowanie", 900, "W realizacji", 2);
            var service = new OrdersService();
            service.AddNewItem(order);

            //Act
            var result = service.GetItemById(1);

            //Assert
            result.Should().BeOfType(typeof(Order));
            result.Should().NotBeNull();
            result.Should().BeSameAs(order);
            Assert.Throws<NullReferenceException>(() => service.GetItemById(2));

        }

        [Fact]
        public void CheckContactDetailsTest()
        {
            Order order = new Order(1, "Ania", new DateTime(2020, 11, 23), new DateTime(2020, 11, 30), new TimeSpan(7), "Katowice", "542355691", "malowanie", 900, "W realizacji", 2);
            Order order2 = new Order(2, "Ania", new DateTime(2020, 11, 23), new DateTime(2020, 11, 30), new TimeSpan(7), "Katowice", "542355cd1", "malowanie", 900, "W realizacji", 2);
            var service = new OrdersService();

            var result = service.CheckContactDetails(order.ContactDetails);
            var result2 = service.CheckContactDetails(order2.ContactDetails);

            result.Should().BeTrue();
            result2.Should().BeFalse();
        }

        [Fact]
        public void CheckEndDateTest()
        {
            Order order = new Order(1, "Ania", new DateTime(2020, 11, 23), new DateTime(2020, 11, 30), new TimeSpan(7), "Katowice", "542355691", "malowanie", 900, "W realizacji", 2);
            Order order1 = new Order(2, "Ania", new DateTime(2020, 11, 23), new DateTime(2020, 11, 20), new TimeSpan(7), "Katowice", "542355691", "malowanie", 900, "W realizacji", 2);
            var service = new OrdersService();

            var result = service.CheckEndDate(order.EndDate, order.StartDate);
            var result1 = service.CheckEndDate(order1.EndDate, order1.StartDate);

            result.Should().BeTrue();
            result1.Should().BeFalse();
        }

        [Fact]
        public void CheckValueTest()
        {
            Order order = new Order(1, "Ania", new DateTime(2020, 11, 23), new DateTime(2020, 11, 30), new TimeSpan(7), "Katowice", "542355691", "malowanie", 900, "W realizacji", 2);
            Order order1 = new Order(2, "Ania", new DateTime(2020, 11, 23), new DateTime(2020, 11, 30), new TimeSpan(7), "Katowice", "542355691", "malowanie", 0, "W realizacji", 2);
            var service = new OrdersService();

            var result = service.CheckValue(order.OrderValue);
            var result1 = service.CheckValue(order1.OrderValue);

            result.Should().BeTrue();
            result1.Should().BeFalse();
        }

        [Fact]
        public void SetTheOrderStatusTest()
        {
            var service = new OrdersService();

            var result = service.SetTheOrderStatus(3);
            var result2 = service.SetTheOrderStatus(2);
            var result3 = service.SetTheOrderStatus(5);

            result.Should().Be("Zakoñczone");
            result2.Should().Be("W realizacji");
            result3.Should().Be("Error");
        }

        [Fact]
        public void CheckChoosenOperationTest()
        {
            var service = new OrdersService();

            var result = service.CheckChoosenOperation(5);

            result.Should().BeFalse();

        }

        [Fact]
        public void CheckEmployeesTest()
        {
            Order order = new Order(1, "Ania", new DateTime(2020, 11, 23), new DateTime(2020, 11, 30), new TimeSpan(7), "Katowice", "542355691", "malowanie", 900, "W realizacji", 2);
            Order order2 = new Order(2, "Ania", new DateTime(2020, 11, 23), new DateTime(2020, 11, 30), new TimeSpan(7), "Katowice", "542355691", "malowanie", 900, "W realizacji", 0);
            var service = new OrdersService();

            var result = service.CheckEmployees(order.NumberOfEmployees);
            var result2 = service.CheckEmployees(order2.NumberOfEmployees);

            result.Should().BeTrue();
            result2.Should().BeFalse();
        }

        [Fact]
        public void StatusToCancelTest()
        {
            Order order = new Order(1, "Ania", new DateTime(2020, 11, 23), new DateTime(2020, 11, 30), new TimeSpan(7), "Katowice", "542355691", "malowanie", 900, "W realizacji", 0);
            Order order2 = new Order(1, "Ania", new DateTime(2020, 11, 23), new DateTime(2020, 11, 30), new TimeSpan(7), "Katowice", "542355691", "malowanie", 900, "Zakoñczone", 0);
            var service = new OrdersService();
            service.AddNewItem(order);

            var result = service.StatusToCancel(order);
            var result2 = service.StatusToCancel(order2);

            result.Should().BeTrue();
            result2.Should().BeFalse();
        }
    }
}
