using OrderService.Api.Common.Validators;
using OrderService.Api.Common.Validators.Interface;
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
            if (!this.IsValidDocumentNumber(model.DocumentNumber))
            {
                throw new ArgumentException("CPF/CNPJ inválido");
            }

            var alreadyExists = this.customerRepository.Get(x => x.DocumentNumber == model.DocumentNumber);
            if (alreadyExists != null)
            {
                throw new ArgumentException("Já existe um cliente cadastrado com esse Cpf/Cnpj.");
            }
            else if (!new EmailValidator().IsEmailValid(model.Email))
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
            else if (customer.Orders != null && customer.Orders.Count() > 0)
            {
                throw new Exception("Não é possível excluir um cliente com Ordens de Serviço associadas.");
            }

            return this.customerRepository.Delete(func);
        }

        public Customer Get(Func<Customer, bool> func)
        {
            return this.customerRepository.Get(func);
        }

        public IEnumerable<Customer> Search(CustomerFilter filter)
        {
            return this.customerRepository.Search(filter);
        }

        public Customer Update(Customer model)
        {
            if (!this.IsValidDocumentNumber(model.DocumentNumber))
            {
                throw new ArgumentException("CPF/CNPJ inválido");
            }
            else if (!new EmailValidator().IsEmailValid(model.Email))
            {
                throw new ArgumentException("O e-mail do cliente não é válido.");
            }

            return this.customerRepository.Update(model);
        }

        private bool IsValidDocumentNumber(string documentNumber)
        {
            const int cnpjSize = 14;
            const int cpfSize = 11;

            if (documentNumber.All(char.IsDigit))
            {
                IIdentificationDocument identificationDocument = null;

                if (documentNumber.Length == cpfSize)
                {
                    identificationDocument = new CpfValidator();
                }
                else if (documentNumber.Length == cnpjSize)
                {
                    identificationDocument = new CnpjValidator();
                }
                else
                {
                    identificationDocument = new NullDocumentValidator();
                }

                return identificationDocument.IsValid(documentNumber);
            }
            else
            {
                return false;
            }
        }
    }
}
