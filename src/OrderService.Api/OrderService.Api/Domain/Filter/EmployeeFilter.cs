using OrderService.Api.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Domain.Filter
{
    public class EmployeeFilter
    {
        public string Name { get; set; }

        public string DocumentNumber { get; set; }

        public DateTime? BeginBirthDate { get; set; } 

        public DateTime? EndBirthDate { get; set; } 

        public GenderEnum? Gender { get; set; }
    }
}
