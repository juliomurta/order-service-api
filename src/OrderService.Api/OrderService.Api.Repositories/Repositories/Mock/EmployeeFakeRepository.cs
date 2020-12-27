using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using OrderService.Api.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Repositories.Mock
{
    public class EmployeeFakeRepository : IEmployeeRepository
    {
        public Employee Create(Employee model)
        {
            return new Employee
            {
                Id = Guid.NewGuid(),
                BirthDate = DateTime.Now,
                DocumentNumber = "12345678",
                Gender = Domain.Enum.GenderEnum.Male,
                Name = "teste",
                Email = "teste@teste.com"
            };
        }

        public bool Delete(Func<Employee, bool> func)
        {
            return true;
        }

        public Employee Get(Func<Employee, bool> func)
        {
            return new Employee
            {
                Id = Guid.NewGuid(),
                BirthDate = DateTime.Now,
                DocumentNumber = "12345678",
                Gender = Domain.Enum.GenderEnum.Male,
                Name = "teste",
                Email = "teste@teste.com"
            };
        }

        public IEnumerable<Employee> Search(EmployeeFilter filter)
        {
            return new List<Employee>
            {
                new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste 1",
                    Email = "teste@teste.com"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste 2",
                    Email = "teste@teste.com"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste 3",
                    Email = "teste@teste.com"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste 4",
                    Email = "teste@teste.com"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste 5",
                    Email = "teste@teste.com"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste 6",
                    Email = "teste@teste.com"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste 7",
                    Email = "teste@teste.com"
                }
            };
        }

        public Employee Update(Employee model)
        {
            return new Employee
            {
                Id = Guid.NewGuid(),
                BirthDate = DateTime.Now,
                DocumentNumber = "12345678",
                Gender = Domain.Enum.GenderEnum.Male,
                Name = "teste",
                Email = "teste@teste.com"
            };
        }
    }
}
