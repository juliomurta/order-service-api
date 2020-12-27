using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using OrderService.Api.Common.Extensions;

namespace OrderService.Api.Domain
{
    public class Customer
    {
        private string documentNumber = string.Empty;

        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "nvarchar(30)")]
        [Required(ErrorMessage = "O campo Name é obrigatório")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        [Required(ErrorMessage = "O campo DocumentNumber é obrigatório")]
        public string DocumentNumber
        {
            get
            {
                return this.documentNumber.RemoveCpfCnpjPunctuation();
            }

            set
            {
                this.documentNumber = value;
            }
        }

        [Column(TypeName = "nvarchar(40)")]
        [Required(ErrorMessage = "O campo Email é obrigatório")]
        public string Email { get; set; }

        public IEnumerable<Order> Orders { get; set; }
    }
}
