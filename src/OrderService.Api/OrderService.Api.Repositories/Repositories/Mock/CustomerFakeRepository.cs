using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using OrderService.Api.Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Repositories.Mock
{
    public class CustomerFakeRepository : ICustomerRepository
    {
        public Customer Create(Customer model)
        {
            return new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Teste",
                DocumentNumber = "123456789",
                Email = "teste@teste.com"
            };
        }

        public bool Delete(Func<Customer, bool> func)
        {
            return true;
        }

        public Customer Get(Func<Customer, bool> func)
        {
            return new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Teste",
                DocumentNumber = "123456789",
                Email = "teste@teste.com"
            };
        }

        public IEnumerable<Customer> Search(CustomerFilter filter)
        {
            return new List<Customer>
            {
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Teste 1",
                    DocumentNumber = "123456789",
                    Email = "teste@teste.com"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Teste 2",
                    DocumentNumber = "123456789",
                    Email = "teste@teste.com"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Teste 3",
                    DocumentNumber = "123456789",
                    Email = "teste@teste.com"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Teste 4",
                    DocumentNumber = "123456789",
                    Email = "teste@teste.com"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Teste 5",
                    DocumentNumber = "123456789",
                    Email = "teste@teste.com"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Teste 6",
                    DocumentNumber = "123456789",
                    Email = "teste@teste.com"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Teste 7",
                    DocumentNumber = "123456789",
                    Email = "teste@teste.com"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Teste 8",
                    DocumentNumber = "123456789",
                    Email = "teste@teste.com"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Teste 9",
                    DocumentNumber = "123456789",
                    Email = "teste@teste.com"
                },
                new Customer
                {
                    Id = Guid.NewGuid(),
                    Name = "Teste 10",
                    DocumentNumber = "123456789",
                    Email = "teste@teste.com"
                },
            };
        }

        public Customer Update(Customer model)
        {
            return new Customer
            {
                Id = Guid.NewGuid(),
                Name = "Teste",
                DocumentNumber = "123456789",
                Email = "teste@teste.com"
            };
        }
    }
}
