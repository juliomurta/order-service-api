using OrderService.Api.Controllers.Model;
using OrderService.Api.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Repositories.Interface
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        IEnumerable<Order> Search(OrderFilter filter);
    }
}
