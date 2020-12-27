using Moq;
using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using OrderService.Api.Repositories.Interface;
using OrderService.Api.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OrderService.Api.Test
{
    public class OrderTest
    {
        [Fact]
        public void CreateValidOrder()
        {
            var order = new Order
            {
                CustomerId = Guid.NewGuid(),
                EmployeeId = Guid.NewGuid(),
                Date = DateTime.Now,
                Start = DateTime.Now.Date.TimeOfDay,
                Finish = DateTime.Now.Date.AddHours(8).TimeOfDay,
                Description = "teste teste teste"
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(x => x.Create(It.IsAny<Order>())).Returns(order);

            var orderService = new OsService(orderRepositoryMock.Object);
            var result = orderService.Create(order);

            Assert.NotNull(result);
        }

        [Fact]
        public void CreateOrderWithoutEmployee()
        {
            var order = new Order
            {
                CustomerId = Guid.NewGuid(),
                EmployeeId = Guid.Empty,
                Date = DateTime.Now,
                Start = DateTime.Now.Date.TimeOfDay,
                Finish = DateTime.Now.Date.AddHours(8).TimeOfDay,
                Description = "teste teste teste"
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(x => x.Create(It.IsAny<Order>())).Returns(order);

            var orderService = new OsService(orderRepositoryMock.Object);
            var exception = Assert.Throws<ArgumentException>(() => orderService.Create(order));

            Assert.Equal("Não é possível salvar uma Ordem de Serviço sem funcionário.", exception.Message);
        }

        [Fact]
        public void CreateOrderWithoutCustomer()
        {
            var order = new Order
            {
                CustomerId = Guid.Empty,
                EmployeeId = Guid.NewGuid(),
                Date = DateTime.Now,
                Start = DateTime.Now.Date.TimeOfDay,
                Finish = DateTime.Now.Date.AddHours(8).TimeOfDay,
                Description = "teste teste teste"
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(x => x.Create(It.IsAny<Order>())).Returns(order);

            var orderService = new OsService(orderRepositoryMock.Object);
            var exception = Assert.Throws<ArgumentException>(() => orderService.Create(order));

            Assert.Equal("Não é possível salvar uma Ordem de Serviço sem cliente.", exception.Message);
        }

        [Fact]
        public void CreateOrderWithStartHigherThanFinish()
        {
            var order = new Order
            {
                CustomerId = Guid.NewGuid(),
                EmployeeId = Guid.NewGuid(),
                Date = DateTime.Now,
                Start = DateTime.Now.Date.AddHours(8).TimeOfDay,
                Finish = DateTime.Now.Date.TimeOfDay,
                Description = "teste teste teste"
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(x => x.Create(It.IsAny<Order>())).Returns(order);

            var orderService = new OsService(orderRepositoryMock.Object);
            var exception = Assert.Throws<ArgumentException>(() => orderService.Create(order));

            Assert.Equal("Hora de início não pode ser maior ou igual a hora de término da Ordem de Serviço.", exception.Message);
        }

        [Fact]
        public void CreateOrderWithStartEqualsToFinish()
        {
            var order = new Order
            {
                CustomerId = Guid.NewGuid(),
                EmployeeId = Guid.NewGuid(),
                Date = DateTime.Now,
                Start = DateTime.Now.Date.AddHours(8).TimeOfDay,
                Finish = DateTime.Now.Date.AddHours(8).TimeOfDay,
                Description = "teste teste teste"
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(x => x.Create(It.IsAny<Order>())).Returns(order);

            var orderService = new OsService(orderRepositoryMock.Object);
            var exception = Assert.Throws<ArgumentException>(() => orderService.Create(order));

            Assert.Equal("Hora de início não pode ser maior ou igual a hora de término da Ordem de Serviço.", exception.Message);
        }

        [Fact]
        public void UpdateValidOrder()
        {
            var order = new Order
            {
                CustomerId = Guid.NewGuid(),
                EmployeeId = Guid.NewGuid(),
                Date = DateTime.Now,
                Start = DateTime.Now.Date.TimeOfDay,
                Finish = DateTime.Now.Date.AddHours(8).TimeOfDay,
                Description = "teste teste teste"
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(x => x.Update(It.IsAny<Order>())).Returns(order);

            var orderService = new OsService(orderRepositoryMock.Object);
            var result = orderService.Update(order);

            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateOrderWithoutEmployee()
        {
            var order = new Order
            {
                CustomerId = Guid.NewGuid(),
                EmployeeId = Guid.Empty,
                Date = DateTime.Now,
                Start = DateTime.Now.Date.TimeOfDay,
                Finish = DateTime.Now.Date.AddHours(8).TimeOfDay,
                Description = "teste teste teste"
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(x => x.Update(It.IsAny<Order>())).Returns(order);

            var orderService = new OsService(orderRepositoryMock.Object);
            var exception = Assert.Throws<ArgumentException>(() => orderService.Update(order));

            Assert.Equal("Não é possível salvar uma Ordem de Serviço sem funcionário.", exception.Message);
        }

        [Fact]
        public void UpdateOrderWithoutCustomer()
        {
            var order = new Order
            {
                CustomerId = Guid.Empty,
                EmployeeId = Guid.NewGuid(),
                Date = DateTime.Now,
                Start = DateTime.Now.Date.TimeOfDay,
                Finish = DateTime.Now.Date.AddHours(8).TimeOfDay,
                Description = "teste teste teste"
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(x => x.Update(It.IsAny<Order>())).Returns(order);

            var orderService = new OsService(orderRepositoryMock.Object);
            var exception = Assert.Throws<ArgumentException>(() => orderService.Update(order));

            Assert.Equal("Não é possível salvar uma Ordem de Serviço sem cliente.", exception.Message);
        }

        [Fact]
        public void UpdateOrderWithStartHigherThanFinish()
        {
            var order = new Order
            {
                CustomerId = Guid.NewGuid(),
                EmployeeId = Guid.NewGuid(),
                Date = DateTime.Now,
                Start = DateTime.Now.Date.AddHours(8).TimeOfDay,
                Finish = DateTime.Now.Date.TimeOfDay,
                Description = "teste teste teste"
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(x => x.Update(It.IsAny<Order>())).Returns(order);

            var orderService = new OsService(orderRepositoryMock.Object);
            var exception = Assert.Throws<ArgumentException>(() => orderService.Update(order));

            Assert.Equal("Hora de início não pode ser maior ou igual a hora de término da Ordem de Serviço.", exception.Message);
        }

        [Fact]
        public void UpdateOrderWithStartEqualsToFinish()
        {
            var order = new Order
            {
                CustomerId = Guid.NewGuid(),
                EmployeeId = Guid.NewGuid(),
                Date = DateTime.Now,
                Start = DateTime.Now.Date.AddHours(8).TimeOfDay,
                Finish = DateTime.Now.Date.AddHours(8).TimeOfDay,
                Description = "teste teste teste"
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(x => x.Update(It.IsAny<Order>())).Returns(order);

            var orderService = new OsService(orderRepositoryMock.Object);
            var exception = Assert.Throws<ArgumentException>(() => orderService.Update(order));

            Assert.Equal("Hora de início não pode ser maior ou igual a hora de término da Ordem de Serviço.", exception.Message);
        }

        [Fact]
        public void DeleteOrder()
        {
            var orderRepository = new Mock<IOrderRepository>();
            orderRepository.Setup(x => x.Delete(It.IsAny<Func<Order, bool>>())).Returns(true);

            var orderService = new OsService(orderRepository.Object);
            var result = orderService.Delete(x => x.Id == Guid.NewGuid());
            Assert.True(result);
        }

        [Fact]
        public void GetOrderById()
        {
            var order = new Order
            {
                CustomerId = Guid.NewGuid(),
                EmployeeId = Guid.NewGuid(),
                Date = DateTime.Now,
                Start = DateTime.Now.Date.TimeOfDay,
                Finish = DateTime.Now.Date.AddHours(8).TimeOfDay,
                Description = "teste teste teste"
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(x => x.Get(It.IsAny<Func<Order, bool>>())).Returns(order);

            var orderService = new OsService(orderRepositoryMock.Object);
            var result = orderService.Get(x => x.Id == Guid.NewGuid());

            Assert.NotNull(result);
        }

        [Fact]
        public void GetListOfOrders()
        {
            var orders = new List<Order>
            {
                new Order
                {
                    CustomerId = Guid.NewGuid(),
                    EmployeeId = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Start = DateTime.Now.Date.TimeOfDay,
                    Finish = DateTime.Now.Date.AddHours(8).TimeOfDay,
                    Description = "teste teste teste 1"
                },
                new Order
                {
                    CustomerId = Guid.NewGuid(),
                    EmployeeId = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Start = DateTime.Now.Date.TimeOfDay,
                    Finish = DateTime.Now.Date.AddHours(8).TimeOfDay,
                    Description = "teste teste teste 2"
                },
                new Order
                {
                    CustomerId = Guid.NewGuid(),
                    EmployeeId = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Start = DateTime.Now.Date.TimeOfDay,
                    Finish = DateTime.Now.Date.AddHours(8).TimeOfDay,
                    Description = "teste teste teste 3"
                }
            };

            var orderRepositoryMock = new Mock<IOrderRepository>();
            orderRepositoryMock.Setup(x => x.Search(It.IsAny<OrderFilter>())).Returns(orders);

            var orderService = new OsService(orderRepositoryMock.Object);
            var result = orderService.Search(new OrderFilter());

            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }
    }
}
