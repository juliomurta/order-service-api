using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Api.Service.Interface
{
    public interface ICustomerService
    {
        Customer Create(Customer model);

        Customer Update(Customer model);

        bool Delete(Func<Customer, bool> func);

        Customer Get(Func<Customer, bool> func);

        IEnumerable<Customer> Search(CustomerFilter filter);
    }
}
