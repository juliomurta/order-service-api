using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Api.Service.Interface
{
    public interface IEmployeeService
    {
        Employee Create(Employee model);

        Employee Update(Employee model);

        bool Delete(Func<Employee, bool> func);

        Employee Get(Func<Employee, bool> func);

        IEnumerable<Employee> Search(EmployeeFilter filter);
    }
}
