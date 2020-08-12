using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Domain
{
    public class Order
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Start { get; set; }

        public TimeSpan Finish { get; set; }

        public string Description { get; set; }

        public Guid EmployeeId { get; set; }

        public Guid CustomerId { get; set; }

        public Employee Employee { get; set; }

        public Customer Customer { get; set; }
    }
}
