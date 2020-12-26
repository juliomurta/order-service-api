using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using OrderService.Api.Repositories.Interface;
using OrderService.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderService.Api.Service
{
    public class CustomerService : ICustomerService
    {
        protected ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public Customer Create(Customer model)
        {
            var alreadyExists = this.customerRepository.Get(x => x.DocumentNumber == model.DocumentNumber);
            if (alreadyExists != null)
            {
                throw new ArgumentException("Já existe um cliente cadastrado com esse Cpf/Cnpj.");
            }

            if (string.IsNullOrEmpty(model.Email) || !model.Email.Contains('@') || !model.Email.Contains('.'))
            {
                throw new ArgumentException("O e-mail do cliente não é válido.");
            }

            return this.customerRepository.Create(model);
        }

        public bool Delete(Func<Customer, bool> func)
        {
            var customer = this.customerRepository.Get(func);

            if (customer == null)
            {
                throw new ArgumentException("Cliente não encontrado.");
            }

            if (customer.Orders != null && customer.Orders.Count() > 0)
            {
                throw new Exception("Não é possível excluir um cliente com Ordens de Serviço associadas");
            }

            return this.customerRepository.Delete(func);
        }

        public Customer Get(Func<Customer, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Search(CustomerFilter filter)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer model)
        {
            throw new NotImplementedException();
        }
    }
}
