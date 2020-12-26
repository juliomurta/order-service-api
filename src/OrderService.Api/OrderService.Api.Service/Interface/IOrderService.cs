using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Api.Service.Interface
{
    public interface IOrderService
    {
        Order Create(Order model);

        Order Update(Order model);

        bool Delete(Func<Order, bool> func);

        Order Get(Func<Order, bool> func);

        IEnumerable<Order> Search(OrderFilter filter);
    }
}
