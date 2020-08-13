using OrderService.Api.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Domain
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        public string DocumentNumber { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime BirthDate { get; set; }

        [Column(TypeName = "int")]
        public GenderEnum Gender { get; set; }
    }
}
