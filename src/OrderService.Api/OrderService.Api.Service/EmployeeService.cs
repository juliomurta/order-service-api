using OrderService.Api.Common.Validators;
using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using OrderService.Api.Repositories.Interface;
using OrderService.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderService.Api.Service
{
    public class EmployeeService : IEmployeeService
    {
        protected IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Employee Create(Employee model)
        {
            if (new CnpjValidator().IsValid(model.DocumentNumber))
            {
                throw new ArgumentException("Não é possivel salvar funcionários com CNPJ.");
            }
            else if (!new CpfValidator().IsValid(model.DocumentNumber))
            {
                throw new ArgumentException("CPF inválido");
            }

            var alreadyExists = this.employeeRepository.Get(x => x.DocumentNumber == model.DocumentNumber);
            if (alreadyExists != null)
            {
                throw new ArgumentException("Já existe um funcionário cadastrado com esse CPF.");
            }
            else if (!new EmailValidator().IsEmailValid(model.Email))
            {
                throw new ArgumentException("O e-mail do funcionário não é válido.");
            }

            return this.employeeRepository.Create(model);
        }

        public bool Delete(Func<Employee, bool> func)
        {
            var employee = this.employeeRepository.Get(func);

            if (employee == null)
            {
                throw new ArgumentException("Funcionário não encontrado.");
            }
            else if (employee.Orders != null && employee.Orders.Count() > 0)
            {
                throw new Exception("Não é possível excluir um funcionário com Ordens de Serviço associadas.");
            }

            return this.employeeRepository.Delete(func);
        }

        public Employee Get(Func<Employee, bool> func)
        {
            return this.employeeRepository.Get(func);
        }

        public IEnumerable<Employee> Search(EmployeeFilter filter)
        {
            return this.employeeRepository.Search(filter);
        }

        public Employee Update(Employee model)
        {
            if (!new CpfValidator().IsValid(model.DocumentNumber))
            {
                throw new ArgumentException("CPF válido.");
            }
            else if (!new EmailValidator().IsEmailValid(model.Email))
            {
                throw new ArgumentException("O e-mail do funcionário não é válido.");
            }

            return this.employeeRepository.Update(model);
        }
    }
}
