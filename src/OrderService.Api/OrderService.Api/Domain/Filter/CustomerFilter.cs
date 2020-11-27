using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Domain.Filter
{
    public class CustomerFilter
    {
        public string Name { get; set; }

        public string DocumentNumber { get; set; }
    }
}
