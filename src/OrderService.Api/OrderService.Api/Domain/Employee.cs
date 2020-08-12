using OrderService.Api.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string DocumentNumber { get; set; }

        public DateTime BirthDate { get; set; }

        public GenderEnum Gender { get; set; }
    }
}
