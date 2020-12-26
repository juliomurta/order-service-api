using OrderService.Api.Domain;
using OrderService.Api.Domain.Filter;
using OrderService.Api.Repositories.Interface;
using OrderService.Api.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderService.Api.Service
{
    public class OsService : IOrderService
    {
        public OsService(IOrderRepository orderRepository)
        {

        }

        public Order Create(Order model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Func<Order, bool> func)
        {
            throw new NotImplementedException();
        }

        public Order Get(Func<Order, bool> func)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Order> Search(OrderFilter filter)
        {
            throw new NotImplementedException();
        }

        public Order Update(Order model)
        {
            throw new NotImplementedException();
        }
    }
}
