using Moq;
using OrderService.Api.Domain;
using OrderService.Api.Domain.Enum;
using OrderService.Api.Domain.Filter;
using OrderService.Api.Repositories.Interface;
using OrderService.Api.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace OrderService.Api.Test
{
    public class EmployeeTest
    {
        [Fact]
        public void CreateValidEmployee()
        {
            var employee = new Employee
            {
                DocumentNumber = "64667825065",
                Email = "aaaa@bbbb.com.br",
                Name = "Test test",
                Gender = GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-30)
            };

            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(x => x.Get(It.IsAny<Func<Employee, bool>>()))
                                  .Returns((Employee)null);

            employeeRepositoryMock.Setup(x => x.Create(employee)).Returns(employee);

            var employeeService = new EmployeeService(employeeRepositoryMock.Object);
            var result = employeeService.Create(employee);

            Assert.NotNull(result);
        }

        [Fact]
        public void CreateValidCEmployee_CPFWithPunctuation()
        {
            var employee = new Employee
            {
                DocumentNumber = "646.678.250-65",
                Email = "aaaa@bbbb.com.br",
                Name = "Test test",
                Gender = GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-30)
            };

            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(x => x.Get(It.IsAny<Func<Employee, bool>>()))
                                  .Returns((Employee)null);

            employeeRepositoryMock.Setup(x => x.Create(employee)).Returns(employee);

            var employeeService = new EmployeeService(employeeRepositoryMock.Object);
            var result = employeeService.Create(employee);

            Assert.NotNull(result);
        }

        [Fact]
        public void SaveEmployeeWithCNPJ()
        {
            var employee = new Employee
            {
                DocumentNumber = "71926350000121",
                Email = "aaaa@bbbb.com.br",
                Name = "Test test",
                Gender = GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-30)
            };

            this.AssertCreateEmployeeException<ArgumentException>("Não é possivel salvar funcionários com CNPJ.", employee);
        }

        [Fact]
        public void SaveEmployeeWithInvalidDocumentNumber_NumbersAndChars()
        {
            var employee = new Employee
            {
                DocumentNumber = "11111111111aaaaaassss3333333333",
                Email = "aaaa@bbbb.com.br",
                Name = "Test test",
                Gender = GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-30)
            };

            this.AssertCreateEmployeeException<ArgumentException>("CPF inválido", employee);
        }

        [Fact]
        public void SaveEmployeeWithInvalidDocumentNumber_LessThan11Digits()
        {
            var employee = new Employee
            {
                DocumentNumber = "111",
                Email = "aaaa@bbbb.com.br",
                Name = "Test test",
                Gender = GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-30)
            };

            this.AssertCreateEmployeeException<ArgumentException>("CPF inválido", employee);
        }

        [Fact]
        public void SaveEmployeeWithInvalidDocumentNumber_MoreThan11Digits()
        {
            var employee = new Employee
            {
                DocumentNumber = "111222333444555666777888999",
                Email = "aaaa@bbbb.com.br",
                Name = "Test test",
                Gender = GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-30)
            };

            this.AssertCreateEmployeeException<ArgumentException>("CPF inválido", employee);
        }

        [Fact]
        public void SaveEmployeeWithInvalidDocumentNumber_CPF()
        {
            var employee = new Employee
            {
                DocumentNumber = "35345353556",
                Email = "aaaa@bbbb.com.br",
                Name = "Test test",
                Gender = GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-30)
            };

            this.AssertCreateEmployeeException<ArgumentException>("CPF inválido", employee);
        }

        [Fact]
        public void SaveEmployeeWithInvalidDocumentNumber_CPF11111111111()
        {
            var employee = new Employee
            {
                DocumentNumber = "11111111111",
                Email = "aaaa@bbbb.com.br",
                Name = "Test test",
                Gender = GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-30)
            };

            this.AssertCreateEmployeeException<ArgumentException>("CPF inválido", employee);
        }

        [Fact]
        public void SaveEmployeeWithInvalidDocumentNumber_CPF99999999999()
        {
            var employee = new Employee
            {
                DocumentNumber = "99999999999",
                Email = "aaaa@bbbb.com.br",
                Name = "Test test",
                Gender = GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-30)
            };

            this.AssertCreateEmployeeException<ArgumentException>("CPF inválido", employee);
        }

        [Fact]
        public void SaveEmployeeWithSameDocumentNumber()
        {
            const string documentNumber = "02569701068";

            var employee = new Employee
            {
                DocumentNumber = documentNumber,
                Email = "aaaa@bbbb.com.br",
                Name = "Test test",
                Gender = GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-30)
            };

            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(x => x.Get(It.IsAny<Func<Employee, bool>>()))
                                  .Returns(new Employee
                                  {
                                      DocumentNumber = documentNumber,
                                      Email = "cccc@bbbb.com.br",
                                      Name = "Charlene",
                                      Gender = GenderEnum.Female,
                                      BirthDate = DateTime.Now.AddYears(-30),
                                      Id = Guid.NewGuid()
                                  });

            employeeRepositoryMock.Setup(x => x.Create(employee)).Returns(employee);

            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            var exception = Assert.Throws<ArgumentException>(() => employeeService.Create(employee));
            Assert.Equal("Já existe um funcionário cadastrado com esse CPF.", exception.Message);
        }

        [Fact]
        public void SaveEmployeeWithoutValidEmail()
        {
            var employee = new Employee
            {
                DocumentNumber = "02569701068",
                Email = "aaaaaaaaa",
                Name = "Test test",
                Gender = GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-30)
            };

            this.AssertCreateEmployeeException<ArgumentException>("O e-mail do funcionário não é válido.", employee);
        }

        [Fact]
        public void DeleteEmployeeNotFound()
        {
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(x => x.Get(It.IsAny<Func<Employee, bool>>()))
                              .Returns((Employee)null);

            var employeeService = new EmployeeService(employeeRepository.Object);
            Assert.Throws<ArgumentException>(() => employeeService.Delete(It.IsAny<Func<Employee, bool>>()));
        }

        [Fact]
        public void DeleteEmployeeWithoutOrderService()
        {
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(x => x.Get(It.IsAny<Func<Employee, bool>>()))
                              .Returns(new Employee
                              {
                                  Id = Guid.NewGuid(),
                                  Email = "aaa@aa.com",
                                  Name = "Test test",
                                  DocumentNumber = "123456789",
                                  Gender = GenderEnum.Male,
                                  BirthDate = DateTime.Now.AddYears(-30),
                                  Orders = null
                              });

            employeeRepository.Setup(x => x.Delete(It.IsAny<Func<Employee, bool>>()))
                              .Returns(true);

            var employeeService = new EmployeeService(employeeRepository.Object);
            Assert.True(employeeService.Delete(x => x.Id == It.IsAny<Guid>()));
        }

        [Fact]
        public void DeleteEmployeeWithOrderService()
        {
            var employeeRepository = new Mock<IEmployeeRepository>();
            employeeRepository.Setup(x => x.Get(It.IsAny<Func<Employee, bool>>()))
                              .Returns(new Employee
                              {
                                  Id = Guid.NewGuid(),
                                  Email = "aaa@aa.com",
                                  Name = "Test test",
                                  DocumentNumber = "123456789",
                                  Gender = GenderEnum.Male,
                                  BirthDate = DateTime.Now.AddYears(-30),
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

            var employeeService = new EmployeeService(employeeRepository.Object);
            Assert.Throws<Exception>(() => employeeService.Delete(x => x.Id == It.IsAny<Guid>()));
        }

        [Fact]
        public void UpdateValidEmployee_CPF()
        {
            var employee = new Employee
            {
                DocumentNumber = "02569701068",
                Email = "aaaa@aaaaa.com",
                Name = "Test test",
                Gender = GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-30)
            };

            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(x => x.Update(It.IsAny<Employee>())).Returns(employee);

            var employeeService = new EmployeeService(employeeRepositoryMock.Object);
            var result = employeeService.Update(employee);
            Assert.NotNull(result);
        }

        public void UpdateEmployeeWithoutValidDocumentNumber_CPF()
        {
            var employee = new Employee
            {
                DocumentNumber = "02569701068",
                Email = "aaaaaaaaa",
                Name = "Test test",
                Gender = GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-30)
            };

            this.AssertUpdateEmployeeException<ArgumentException>("CPF inválido", employee);
        }

        [Fact]
        public void UpdateEmployeeWithoutValidEmail()
        {
            var employee = new Employee
            {
                DocumentNumber = "02569701068",
                Email = "aaaaaaaaa",
                Name = "Test test",
                Gender = GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-30)
            };

            this.AssertUpdateEmployeeException<ArgumentException>("O e-mail do funcionário não é válido.", employee);
        }

        [Fact]
        public void GetEmployeeById()
        {
            var id = Guid.NewGuid();
            var employee = new Employee
            {
                DocumentNumber = "02569701068",
                Email = "aaaaaaaaa",
                Name = "Test test",
                Gender = GenderEnum.Male,
                BirthDate = DateTime.Now.AddYears(-30),
                Id = id
            };

            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(x => x.Get(It.IsAny<Func<Employee, bool>>()))
                                  .Returns(employee);

            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            var result = employeeService.Get(x => x.Id == id);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
        }

        [Fact]
        public void GetEmployeeList()
        {
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(x => x.Search(It.IsAny<EmployeeFilter>()))
                                  .Returns(new List<Employee>
                                  {
                                      new Employee
                                      {
                                          DocumentNumber = "123456789",
                                          Email = "aaa@bbb.com",
                                          Gender = GenderEnum.Male,
                                          BirthDate = DateTime.Now.AddYears(-30),
                                          Name = "Test 1"
                                      },
                                      new Employee
                                      {
                                          DocumentNumber = "123456789",
                                          Email = "aaa@bbb.com",
                                          Gender = GenderEnum.Male,
                                          BirthDate = DateTime.Now.AddYears(-30),
                                          Name = "Test 2"
                                      },
                                      new Employee
                                      {
                                          DocumentNumber = "123456789",
                                          Email = "aaa@bbb.com",
                                          Gender = GenderEnum.Male,
                                          BirthDate = DateTime.Now.AddYears(-30),
                                          Name = "Test 3"
                                      }
                                  });

            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            var result = employeeService.Search(new EmployeeFilter());
            Assert.NotNull(result);
            Assert.Equal(3, result.Count());
        }

        private void AssertCreateEmployeeException<TException>(string expectedMessage, Employee employee) where TException : Exception
        {
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(x => x.Get(It.IsAny<Func<Employee, bool>>()))
                                  .Returns((Employee)null);

            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            var exception = Assert.Throws<TException>(() => employeeService.Create(employee));
            Assert.Equal(expectedMessage, exception.Message);
        }

        private void AssertUpdateEmployeeException<TException>(string expectedMessage, Employee employee) where TException : Exception
        {
            var employeeRepositoryMock = new Mock<IEmployeeRepository>();
            employeeRepositoryMock.Setup(x => x.Update(It.IsAny<Employee>())).Returns(employee);

            var employeeService = new EmployeeService(employeeRepositoryMock.Object);

            var exception = Assert.Throws<TException>(() => employeeService.Update(employee));
            Assert.Equal(expectedMessage, exception.Message);
        }
    }
}

