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
    public class CustomerTest
    {
        [Fact]
        public void CreateValidCustomer_CPF()
        {
            var customer = new Customer
            {
                DocumentNumber = "02569701068",
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
        public void CreateValidCustomer_CPFWithPunctuation()
        {
            var customer = new Customer
            {
                DocumentNumber = "025.697.010-68",
                Email = "aaaa@bbbb.com.br",
                Name = "Test test"
            };

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.Get(It.IsAny<Func<Customer, bool>>()))
                                  .Returns((Customer)null);

            customerRepositoryMock.Setup(x => x.Create(customer)).Returns(customer);

            var customerService = new CustomerService(customerRepositoryMock.Object);
            var result = customerService.Create(customer);

            Assert.NotNull(result);
        }

        [Fact]
        public void CreateValidCustomer_CNPJ()
        {
            var customer = new Customer
            {
                DocumentNumber = "53846057000172",
                Email = "aaaa@bbbb.com.br",
                Name = "Test test"
            };

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.Get(It.IsAny<Func<Customer, bool>>()))
                                  .Returns((Customer)null);

            customerRepositoryMock.Setup(x => x.Create(customer)).Returns(customer);

            var customerService = new CustomerService(customerRepositoryMock.Object);
            var result = customerService.Create(customer);

            Assert.NotNull(result);
        }

        [Fact]
        public void CreateValidCustomer_CNPJWithPunctuation()
        {
            var customer = new Customer
            {
                DocumentNumber = "53.846.057/0001-72",
                Email = "aaaa@bbbb.com.br",
                Name = "Test test"
            };

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.Get(It.IsAny<Func<Customer, bool>>()))
                                  .Returns((Customer)null);

            customerRepositoryMock.Setup(x => x.Create(customer)).Returns(customer);

            var customerService = new CustomerService(customerRepositoryMock.Object);
            var result = customerService.Create(customer);

            Assert.NotNull(result);
        }

        [Fact]
        public void SaveCustomerWithInvalidDocumentNumber_NumbersAndChars()
        {
            var customer = new Customer
            {
                DocumentNumber = "11111111111aaaaaassss3333333333",
                Email = "aaa@aa.com.br",
                Name = "test test"
            };

            this.AssertCreateCustomerException<ArgumentException>("CPf/CNPJ inválido", customer);
        }

        [Fact]
        public void SaveCustomerWithInvalidDocumentNumber_LessThan11Digits()
        {
            var customer = new Customer
            {
                DocumentNumber = "111",
                Email = "aaa@aa.com.br",
                Name = "test test"
            };

            this.AssertCreateCustomerException<ArgumentException>("CPf/CNPJ inválido", customer);
        }

        [Fact]
        public void SaveCustomerWithInvalidDocumentNumber_MoreThan14Digits()
        {
            var customer = new Customer
            {
                DocumentNumber = "111222333444555666777888999",
                Email = "aaa@aa.com.br",
                Name = "test test"
            };

            this.AssertCreateCustomerException<ArgumentException>("CPf/CNPJ inválido", customer);
        }

        [Fact]
        public void SaveCustomerWithInvalidDocumentNumber_With13Digits()
        {
            var customer = new Customer
            {
                DocumentNumber = "111222333444555666777888999",
                Email = "aaa@aa.com.br",
                Name = "test test"
            };

            this.AssertCreateCustomerException<ArgumentException>("CPf/CNPJ inválido", customer);
        }

        [Fact]
        public void SaveCustomerWithInvalidDocumentNumber_CPF()
        {
            var customer = new Customer
            {
                DocumentNumber = "35345353556",
                Email = "aaa@aa.com.br",
                Name = "test test"
            };

            this.AssertCreateCustomerException<ArgumentException>("CPf/CNPJ inválido", customer);
        }

        [Fact]
        public void SaveCustomerWithInvalidDocumentNumber_CPF11111111111()
        {
            var customer = new Customer
            {
                DocumentNumber = "11111111111",
                Email = "aaa@aa.com.br",
                Name = "test test"                
            };

            this.AssertCreateCustomerException<ArgumentException>("CPf/CNPJ inválido", customer);
        }

        [Fact]
        public void SaveCustomerWithInvalidDocumentNumber_CPF99999999999()
        {
            var customer = new Customer
            {
                DocumentNumber = "99999999999",
                Email = "aaa@aa.com.br",
                Name = "test test"
            };

            this.AssertCreateCustomerException<ArgumentException>("CPf/CNPJ inválido", customer);
        }

        public void SaveCustomerWithInvalidDocumentNumber_CNPJ()
        {
            var customer = new Customer
            {
                DocumentNumber = "73850284716385",
                Email = "aaa@aa.com.br",
                Name = "test test"
            };

            this.AssertCreateCustomerException<ArgumentException>("CPf/CNPJ inválido", customer);
        }

        [Fact]
        public void SaveCustomerWithInvalidDocumentNumber_CNPJ11111111111111()
        {
            var customer = new Customer
            {
                DocumentNumber = "11111111111111",
                Email = "aaa@aa.com.br",
                Name = "test test"
            };

            this.AssertCreateCustomerException<ArgumentException>("CPf/CNPJ inválido", customer);
        }

        [Fact]
        public void SaveCustomerWithInvalidDocumentNumber_CNPJ99999999999999()
        {
            var customer = new Customer
            {
                DocumentNumber = "99999999999999",
                Email = "aaa@aa.com.br",
                Name = "test test"
            };

            this.AssertCreateCustomerException<ArgumentException>("CPf/CNPJ inválido", customer);
        }

        [Fact]
        public void SaveCustomerWithSameDocumentNumber()
        {
            const string documentNumber = "02569701068";

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

            var exception = Assert.Throws<ArgumentException>(() => customerService.Create(customer));
            Assert.Equal("Já existe um cliente cadastrado com esse Cpf/Cnpj.", exception.Message);
        }

        [Fact]
        public void SaveCustomerWithoutValidEmail()
        {
            var customer = new Customer
            {
                DocumentNumber = "02569701068",
                Email = "aaaaaaaaa",
                Name = "Test test"
            };

            this.AssertCreateCustomerException<ArgumentException>("O e-mail do cliente não é válido.", customer);
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

        [Fact]
        public void UpdateValidCustomer_CPF()
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Test test",
                DocumentNumber = "02569701068",
                Email = "asdfg@fsfff.com"                
            };

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.Update(It.IsAny<Customer>())).Returns(customer);

            var customerService = new CustomerService(customerRepositoryMock.Object);
            var result = customerService.Update(customer);
            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateValidCustomer_CNPJ()
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Test test",
                DocumentNumber = "53846057000172",
                Email = "asdfg@fsfff.com"
            };

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.Update(It.IsAny<Customer>())).Returns(customer);

            var customerService = new CustomerService(customerRepositoryMock.Object);
            var result = customerService.Update(customer);
            Assert.NotNull(result);
        }

        public void UpdateCustomerWithoutValidDocumentNumber_CPF()
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Test test",
                DocumentNumber = "12345678910",
                Email = "asdfg@fsfff.com"
            };

            this.AssertUpdateCustomerException<ArgumentException>("CPf / CNPJ inválido", customer);
        }

        public void UpdateCustomerWithoutValidDocumentNumber_CNPJ()
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Test test",
                DocumentNumber = "12345678910123",
                Email = "asdfg@fsfff.com"
            };

            this.AssertUpdateCustomerException<ArgumentException>("CPf / CNPJ inválido", customer);
        }

        [Fact]
        public void UpdateCustomerWithoutValidEmail()
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Test test",
                DocumentNumber = "02569701068",
                Email = "aaaaaaaaaaaa"
            };

            this.AssertUpdateCustomerException<ArgumentException>("O e-mail do cliente não é válido.", customer);
        }

        [Fact]
        public void GetCustomerById()
        {
            var id = Guid.NewGuid();
            var customer = new Customer
            {
                DocumentNumber = "02569701068",
                Email = "aaa@aaa.com.br",
                Name = "Test test",
                Id = id
            };

            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.Get(It.IsAny<Func<Customer, bool>>()))
                                  .Returns(customer);

            var customerService = new CustomerService(customerRepositoryMock.Object);

            var result = customerService.Get(x => x.Id == id);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public void GetCustomerList()
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.Search(It.IsAny<CustomerFilter>()))
                                  .Returns(new List<Customer>
                                  {
                                      new Customer
                                      {
                                          DocumentNumber = "123456789",
                                          Email = "aaa@bbb.com",
                                          Name = "Test 1"                                          
                                      },
                                      new Customer
                                      {
                                          DocumentNumber = "123456789",
                                          Email = "aaa@bbb.com",
                                          Name = "Test 2"
                                      },
                                      new Customer
                                      {
                                          DocumentNumber = "123456789",
                                          Email = "aaa@bbb.com",
                                          Name = "Test 3"
                                      }
                                  });

            var customerService = new CustomerService(customerRepositoryMock.Object);

            var result = customerService.Search(new CustomerFilter());
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }

        private void AssertCreateCustomerException<TException>(string expectedMessage, Customer customer) where TException : Exception
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.Get(It.IsAny<Func<Customer, bool>>()))
                                  .Returns((Customer)null);

            var customerService = new CustomerService(customerRepositoryMock.Object);

            var exception = Assert.Throws<TException>(() => customerService.Create(customer));
            Assert.Equal(expectedMessage, exception.Message);
        }

        private void AssertUpdateCustomerException<TException>(string expectedMessage, Customer customer) where TException : Exception
        {
            var customerRepositoryMock = new Mock<ICustomerRepository>();
            customerRepositoryMock.Setup(x => x.Update(It.IsAny<Customer>())).Returns(customer);

            var customerService = new CustomerService(customerRepositoryMock.Object);

            var exception = Assert.Throws<TException>(() => customerService.Update(customer));
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}
