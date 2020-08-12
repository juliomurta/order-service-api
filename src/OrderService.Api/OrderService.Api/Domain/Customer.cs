using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Domain
{
    public class Customer
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DocumentNumber { get; set; }
    }
}
