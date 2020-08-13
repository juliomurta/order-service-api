using OrderService.Api.Controllers.Model;
using OrderService.Api.Domain;
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
                Name = "teste"
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
                Name = "teste"
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
                    Name = "teste 1"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste 2"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste 3"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste 4"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste 5"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste 6"
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    BirthDate = DateTime.Now,
                    DocumentNumber = "12345678",
                    Gender = Domain.Enum.GenderEnum.Male,
                    Name = "teste 7"
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
                Name = "teste"
            };
        }
    }
}
