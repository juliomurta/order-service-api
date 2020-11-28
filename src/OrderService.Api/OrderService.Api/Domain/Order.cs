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
        [Required(ErrorMessage = "O campo Date é obrigatório")]
        public DateTime Date { get; set; }

        [Column(TypeName = "time")]
        [Required(ErrorMessage = "O campo Start é obrigatório")]
        public TimeSpan Start { get; set; }

        [Column(TypeName = "time")]
        [Required(ErrorMessage = "O campo Finish é obrigatório")]
        public TimeSpan Finish { get; set; }

        [Column(TypeName = "nvarchar(500)")]
        [Required(ErrorMessage = "O campo Description é obrigatório")]
        public string Description { get; set; }

        [Required]
        public virtual Guid EmployeeId { get; set; }

        [Required]
        public virtual Guid CustomerId { get; set; }

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
