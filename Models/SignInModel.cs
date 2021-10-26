using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace armcoordination_dashboard.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage = "Por favor, introduzca su correo electrónico"), EmailAddress(ErrorMessage = "Por favor, introduzca una dirección de correo electrónico válida")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, introduzca su contraseña")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
