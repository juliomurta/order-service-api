using OrderService.Api.Domain;
using OrderService.Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Repositories.Interface
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
        IEnumerable<Customer> Search(CustomerFilter filter);
    }
}
