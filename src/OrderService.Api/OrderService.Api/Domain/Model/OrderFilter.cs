using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Domain.Model
{
    public class OrderFilter
    {
        public Guid EmployeeId { get; set; }

        public Guid CustomerId { get; set; }

        public string Description { get; set; }
    }
}
