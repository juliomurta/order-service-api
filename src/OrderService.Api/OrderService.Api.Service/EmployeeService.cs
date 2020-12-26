using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using OrderService.Api.Repositories.Interface;
using OrderService.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Api.Service
{
    public class EmployeeService : IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository)
        {

        }

        public Employee Create(Employee model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Func<Employee, bool> func)
        {
            throw new NotImplementedException();
        }

        public Employee Get(Func<Employee, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Search(EmployeeFilter filter)
        {
            throw new NotImplementedException();
        }

        public Employee Update(Employee model)
        {
            throw new NotImplementedException();
        }
    }
}
