﻿using System;
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
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar(15)")]
        [Required]
        public string DocumentNumber { get; set; }

        [Column(TypeName = "nvarchar(40)")]
        [Required]
        public string Email { get; set; }
    }
}
