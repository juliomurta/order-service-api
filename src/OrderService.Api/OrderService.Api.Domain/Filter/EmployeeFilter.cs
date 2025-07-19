using OrderService.Api.Domain.Enum;
using System;

namespace OrderService.Api.Domain.Filter
{
    public class EmployeeFilter : BaseFilter
    {
        public string Name { get; set; }

        public string DocumentNumber { get; set; }

        public DateTime? BeginBirthDate { get; set; } 

        public DateTime? EndBirthDate { get; set; } 

        public GenderEnum? Gender { get; set; }
    }
}
