using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using OrderService.Api.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Repositories.Mock
{
    public class OrderFakeRepository : IOrderRepository
    {
        public Order Create(Order model)
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Description = "Testeeeeee",
                Start = new TimeSpan(8),
                Finish = new TimeSpan(17),
                CustomerId = Guid.NewGuid(),
                EmployeeId = Guid.NewGuid(),
                Customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    DocumentNumber = "1234567",
                    Name = "teste"
                },
                Employee = new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste"
                }
            };
        }

        public bool Delete(Func<Order, bool> func)
        {
            return true;
        }

        public Order Get(Func<Order, bool> func)
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Description = "Testeeeeee",
                Start = new TimeSpan(8),
                Finish = new TimeSpan(17),
                CustomerId = Guid.NewGuid(),
                EmployeeId = Guid.NewGuid(),
                Customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    DocumentNumber = "1234567",
                    Name = "teste"
                },
                Employee = new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste"
                }
            };
        }

        public IEnumerable<Order> Search(OrderFilter filter)
        {
            return new List<Order>
            {
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Description = "Testee 11",
                    Start = new TimeSpan(8),
                    Finish = new TimeSpan(17),
                    CustomerId = Guid.NewGuid(),
                    EmployeeId = Guid.NewGuid(),
                    Customer = new Customer
                    {
                        Id = Guid.NewGuid(),
                        DocumentNumber = "1234567",
                        Name = "teste"
                    },
                    Employee = new Employee
                    {
                        Id = Guid.NewGuid(),
                        BirthDate = DateTime.Now,
                        DocumentNumber = "12345678",
                        Gender = Domain.Enum.GenderEnum.Male,
                        Name = "teste"
                    }
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Description = "Testeeeeee 222",
                    Start = new TimeSpan(8),
                    Finish = new TimeSpan(17),
                    CustomerId = Guid.NewGuid(),
                    EmployeeId = Guid.NewGuid(),
                    Customer = new Customer
                    {
                        Id = Guid.NewGuid(),
                        DocumentNumber = "1234567",
                        Name = "teste"
                    },
                    Employee = new Employee
                    {
                        Id = Guid.NewGuid(),
                        BirthDate = DateTime.Now,
                        DocumentNumber = "12345678",
                        Gender = Domain.Enum.GenderEnum.Male,
                        Name = "teste"
                    }
                },
                new Order
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Description = "Testeeeeee 333",
                    Start = new TimeSpan(8),
                    Finish = new TimeSpan(17),
                    CustomerId = Guid.NewGuid(),
                    EmployeeId = Guid.NewGuid(),
                    Customer = new Customer
                    {
                        Id = Guid.NewGuid(),
                        DocumentNumber = "1234567",
                        Name = "teste"
                    },
                    Employee = new Employee
                    {
                        Id = Guid.NewGuid(),
                        BirthDate = DateTime.Now,
                        DocumentNumber = "12345678",
                        Gender = Domain.Enum.GenderEnum.Male,
                        Name = "teste"
                    }
                }
            };
        }

        public Order Update(Order model)
        {
            return new Order
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Description = "Testeeeeee",
                Start = new TimeSpan(8),
                Finish = new TimeSpan(17),
                CustomerId = Guid.NewGuid(),
                EmployeeId = Guid.NewGuid(),
                Customer = new Customer
                {
                    Id = Guid.NewGuid(),
                    DocumentNumber = "1234567",
                    Name = "teste"
                },
                Employee = new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste"
                }
            };
        }
    }
}
