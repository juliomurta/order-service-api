using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderService.Api.Model
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Nome do usuário é obrigatório")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória")]
        public string Password { get; set; }
    }
}
