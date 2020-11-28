using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Domain
{
    public class Customer
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required(ErrorMessage = "O campo Name é obrigatório")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        [Required(ErrorMessage = "O campo DocumentNumber é obrigatório")]
        public string DocumentNumber { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }
    }
}
