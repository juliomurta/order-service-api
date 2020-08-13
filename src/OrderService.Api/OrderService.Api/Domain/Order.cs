using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Domain
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Date { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan Start { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan Finish { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Description { get; set; }

        public virtual Guid EmployeeId { get; set; }

        public virtual Guid CustomerId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
