using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Repositories.Interface
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        IEnumerable<Employee> Search(EmployeeFilter filter);
    }
}
