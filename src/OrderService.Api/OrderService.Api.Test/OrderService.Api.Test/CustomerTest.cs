using Moq;
using OrderService.Api.Domain;
using OrderService.Api.Repositories.Interface;
using OrderService.Api.Service;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OrderService.Api.Test
{
    public class CustomerTest
    {
        [Fact]
        public void CreateValidCustomer()
        {
            var customer = new Customer
            {
                DocumentNumber = "123456789",
                Email = "aaaa@bbbb.com.br",
                Name = "Test test"                
            };

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.Get(It.IsAny<Func<Customer, bool>>()))
                                  .Returns((Customer) null);

            customerRepositoryMock.Setup(x => x.Create(customer)).Returns(customer);

            var customerService = new CustomerService(customerRepositoryMock.Object);
            var result = customerService.Create(customer);

            Assert.NotNull(result);
        }

        [Fact]
        public void SaveCustomerWithSameDocumentNumber()
        {
            const string documentNumber = "123456789";

            var customer = new Customer
            {
                DocumentNumber = documentNumber,
                Email = "aaaa@bbbb.com.br",
                Name = "Test test"
            };

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.Get(It.IsAny<Func<Customer, bool>>()))
                                  .Returns(new Customer
                                           {
                                                DocumentNumber = documentNumber,
                                                Email = "cccc@bbbb.com.br",
                                                Name = "Charlene",
                                                Id = Guid.NewGuid()
                                           });

            customerRepositoryMock.Setup(x => x.Create(customer)).Returns(customer);

            var customerService = new CustomerService(customerRepositoryMock.Object);

            Assert.Throws<ArgumentException>(() => customerService.Create(customer));
        }

        [Fact]
        public void SaveCustomerWithnotValidEmail()
        {
            var customer = new Customer
            {
                DocumentNumber = "123456789",
                Email = "aaaaaaaaa",
                Name = "Test test"
            };

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.Get(It.IsAny<Func<Customer, bool>>()))
                                  .Returns((Customer)null);

            customerRepositoryMock.Setup(x => x.Create(customer)).Returns(customer);

            var customerService = new CustomerService(customerRepositoryMock.Object);

            Assert.Throws<ArgumentException>(() => customerService.Create(customer));
        }
    
        [Fact]
        public void DeleteCustomerNotFound()
        {
            var customerRepository = new Mock<ICustomerRepository>();
            customerRepository.Setup(x => x.Get(It.IsAny<Func<Customer, bool>>()))
                              .Returns((Customer)null);

            var customerService = new CustomerService(customerRepository.Object);
            Assert.Throws<ArgumentException>(() => customerService.Delete(It.IsAny<Func<Customer, bool>>()));
        }

        [Fact]
        public void DeleteCustomerWithoutOrderService()
        {
            var customerRepository = new Mock<ICustomerRepository>();
            customerRepository.Setup(x => x.Get(It.IsAny<Func<Customer, bool>>()))
                              .Returns(new Customer
                              {
                                  Id = Guid.NewGuid(),
                                  Email = "aaa@aa.com",
                                  Name = "Test test",
                                  DocumentNumber = "123456789",
                                  Orders = null
                              });

            customerRepository.Setup(x => x.Delete(It.IsAny<Func<Customer, bool>>()))
                              .Returns(true);

            var customerService = new CustomerService(customerRepository.Object);
            Assert.True(customerService.Delete(x => x.Id == It.IsAny<Guid>()));
        }

        [Fact]
        public void DeleteCustomerWithOrderService()
        {

            var customerRepository = new Mock<ICustomerRepository>();
            customerRepository.Setup(x => x.Get(It.IsAny<Func<Customer, bool>>()))
                              .Returns(new Customer
                              {
                                  Id = Guid.NewGuid(),
                                  Email = "aaa@aa.com",
                                  Name = "Test test",
                                  DocumentNumber = "123456789",
                                  Orders = new List<Order> 
                                  { 
                                      new Order 
                                      { 
                                        Date = DateTime.Now,
                                        Start = DateTime.Now.TimeOfDay,
                                        Finish = DateTime.Now.AddHours(8).TimeOfDay,
                                        Description = "test test test test test teste",
                                        Id = Guid.Empty
                                      } 
                                  }
                              });

            var customerService = new CustomerService(customerRepository.Object);
            Assert.Throws<Exception>(() => customerService.Delete(x => x.Id == It.IsAny<Guid>()));
        }
    }
}
